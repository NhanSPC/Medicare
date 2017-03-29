
Imports Csla
Imports Csla.Data
Imports System.Xml
Imports pbs.Helper
Imports System.Data.SqlClient

Namespace HR

    <Serializable()> _
    Public Class CMPNTInfoList
        Inherits Csla.ReadOnlyListBase(Of CMPNTInfoList, CMPNTInfo)

#Region " Transfer and Report Function "

        Public Shared Function TransferOut(ByVal Code_From As String, ByVal Code_To As String, ByVal FileName As String) As Integer
            Dim _dt As New DataTable(GetType(CMPNT).ToString)
            Dim oa As New ObjectAdapter()

            For Each info As CMPNTInfo In CMPNTInfoList.GetCMPNTInfoList
                If info.Code >= Code_From AndAlso info.Code <= Code_To Then
                    oa.Fill(_dt, CMPNT.GetBO(info.ToString))
                End If
            Next
            Try
                _dt.Columns.Remove("IsNew")
                _dt.Columns.Remove("IsValid")
                _dt.Columns.Remove("IsSavable")
                _dt.Columns.Remove("IsDeleted")
                _dt.Columns.Remove("IsDirty")
                _dt.Columns.Remove("BrokenRulesCollection")
            Catch ex As Exception
            End Try

            For Each col As DataColumn In _dt.Columns
                col.ColumnMapping = MappingType.Attribute
            Next

            _dt.WriteXml(FileName)

            Return _dt.Rows.Count

        End Function

        Public Shared Function GetMyReportDataset() As List(Of DataTable)
            CMPNTInfoList.InvalidateCache()

            Dim thelist = CMPNTInfoList.GetCMPNTInfoList.ToList()

            Dim shr = New pbs.BO.ObjectShredder(Of CMPNTInfo)
            Dim dts As New List(Of DataTable)
            dts.Add(shr.Shred(thelist, Nothing, LoadOption.OverwriteChanges))

            Return dts
        End Function

#End Region

#Region " Business Properties and Methods "
        Private Shared _DTB As String = String.Empty
        Const _SUNTB As String = ""
        Private Shared _list As CMPNTInfoList
#End Region 'Business Properties and Methods

#Region " Factory Methods "

        Private Sub New()
            _DTB = Context.CurrentBECode
        End Sub

        Public Shared Function GetCMPNTInfo(ByVal pLineNo As String) As CMPNTInfo
            Dim Info As CMPNTInfo = CMPNTInfo.EmptyCMPNTInfo(pLineNo)
            ContainsCode(pLineNo, Info)
            Return Info
        End Function

        Public Shared Function GetDescription(ByVal pLineNo As String) As String
            Return GetCMPNTInfo(pLineNo).Description
        End Function

        Public Shared Function GetCMPNTInfoList() As CMPNTInfoList
            If _list Is Nothing Or _DTB <> Context.CurrentBECode Then

                _DTB = Context.CurrentBECode
                _list = DataPortal.Fetch(Of CMPNTInfoList)(New FilterCriteria())

            End If
            Return _list
        End Function

        Public Shared Sub InvalidateCache()
            _list = Nothing
            _cmpntDic = Nothing
        End Sub

        Public Shared Sub ResetCache()
            _list = Nothing
            _cmpntDic = Nothing
        End Sub

        'Private Shared invalidateLock As New Object
        'Public Shared Sub InvalidateCache()
        '    SyncLock invalidateLock
        '        If Not SettingsProvider.SoftInvalidateCache Then
        '            ResetCache()
        '        Else
        '            Dim thelist = GetCMPNTInfoList_Full()
        '            If thelist.Count > GetServerRecordCount() Then
        '                'someone delete some record on server. need to reload everything
        '                ResetCache()
        '            Else
        '                If thelist IsNot Nothing Then thelist.UpdatedInfoList()
        '            End If
        '        End If
        '    End SyncLock
        'End Sub

        Public Shared Function ContainsCode(ByVal pLineNo As String, Optional ByRef RetInfo As CMPNTInfo = Nothing) As Boolean

            RetInfo = CMPNTInfo.EmptyCMPNTInfo(pLineNo)
            If GetCMPNTDic.ContainsKey(pLineNo) Then
                RetInfo = GetCMPNTDic(pLineNo)
                Return True
            End If

        End Function

        'Public Shared Function ContainsCode(ByVal Target As Object, ByVal e As Validation.RuleArgs) As Boolean
        '    Dim value As String = CType(CallByName(Target, e.PropertyName, CallType.Get), String)
        '    'no thing to check
        '    If String.IsNullOrEmpty(value) Then Return True

        '    If ContainsCode(value) Then
        '        Return True
        '    Else
        '        e.Description = String.Format(ResStr(Msg.NOSUCHITEM), ResStr("CMPNT"), value)
        '        Return False
        '    End If
        'End Function

#End Region ' Factory Methods

#Region " Data Access "

#Region " Filter Criteria "

        <Serializable()> _
        Private Class FilterCriteria
            Friend _timeStamp() As Byte
            Public Sub New()
            End Sub
        End Class

#End Region
        Private Shared _lockObj As New Object

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As FilterCriteria)
            SyncLock _lockObj
                RaiseListChangedEvents = False
                IsReadOnly = False
                Using cn = New SqlClient.SqlConnection(Database.PhoebusConnection)
                    cn.Open()

                    Using cm = cn.CreateCommand()
                        cm.CommandType = CommandType.Text
                        cm.CommandText = <SqlText>SELECT * FROM pbs_HR_OFF_CMPNT_<%= _DTB %></SqlText>.Value.Trim

                        ' If criteria._timeStamp IsNot Nothing AndAlso criteria._timeStamp.Length > 0 Then
                        'cm.CommandText = <SqlText>SELECT * FROM pbs_HR_OFF_CMPNT_DEM WHERE DTB='<%= _DTB %>'</SqlText>.Value.Trim AND TIME_STAMP > @CurrentTimeStamp.Value.Trim
                        '     cm.Parameters.AddWithValue("@CurrentTimeStamp", criteria._timeStamp)
                        ' Else
                        '     cm.CommandText = <SqlText>SELECT * FROM pbs_HR_OFF_CMPNT_DEM WHERE DTB='<%= _DTB %>'</SqlText>.Value.Trim
                        ' End If

                        Using dr As New SafeDataReader(cm.ExecuteReader)
                            While dr.Read
                                Dim info = CMPNTInfo.GetCMPNTInfo(dr)
                                Me.Add(Info)
                            End While
                        End Using

                    End Using

                    ' 'read the current version of the list
                    ' Using cm As SqlCommand = cn.CreateSQLCommand()
                    'cm.CommandText = SELECT max(TIME_STAMP) FROM pbs_HR_OFF_CMPNT_DEM WHERE DTB.Value.Tri
                    '     Dim ret = cm.ExecuteScalar
                    '     If ret IsNot Nothing Then _listTimeStamp = ret
                    ' End Using

                End Using
                IsReadOnly = True
                RaiseListChangedEvents = True
            End SyncLock
        End Sub

#End Region ' Data Access                   
#Region "CMPNT Dictionary"

        Private Shared _cmpntDic As Dictionary(Of String, CMPNTInfo)

        Private Shared Function GetCMPNTDic() As Dictionary(Of String, CMPNTInfo)
            If _cmpntDic Is Nothing OrElse _DTB <> Context.CurrentBECode Then
                _cmpntDic = New Dictionary(Of String, CMPNTInfo)

                For Each itm In CMPNTInfoList.GetCMPNTInfoList
                    _cmpntDic.Add(itm.Code, itm)
                Next
            End If

            Return _cmpntDic

        End Function

#End Region

#Region "TimeStamp"
        'Private _listTimeStamp() As Byte

        'Private Sub UpdatedInfoList()
        '    'get new updated notes by row stamp
        '    Dim newInfos = DataPortal.Fetch(Of PODInfoList)(New FilterCriteria() With {._timeStamp = _listTimeStamp})

        '    If newInfos.Count = 0 Then Exit Sub

        '    'merge new notes with the old one

        '    Dim oldPODs = GetPODInfoList_Full()
        '    Dim oldDic = New Dictionary(Of String, PODInfo)
        '    For Each itm In oldPODs
        '        oldDic.Add(itm.Code, itm)
        '    Next

        '    oldPODs.IsReadOnly = False
        '    oldPODs.RaiseListChangedEvents = False

        '    For Each info In newInfos
        '        If oldDic.ContainsKey(info.Code) Then

        '            Dim oldNote = oldDic(info.Code)
        '            oldPODs.Remove(oldNote)
        '            oldPODs.Add(info)

        '            oldDic(info.Code) = info
        '        Else
        '            oldPODs.Add(info)

        '            oldDic.Add(info.Code, info)
        '        End If
        '    Next


        '    oldPODs.IsReadOnly = False
        '    oldPODs.RaiseListChangedEvents = False

        '    _podDic = oldDic
        '    _list = oldPODs
        '    _list._listTimeStamp = newInfos._listTimeStamp

        'End Sub

        'Private Shared Function GetServerRecordCount() As Integer
        '    Dim script = SELECT count(*) FROM pbs_HR_OFF_CMPNT_DEM  _DTB .Value.Tri
        '    Return SQLCommander.GetScalarInteger(script)
        'End Function
#End Region

    End Class

End Namespace