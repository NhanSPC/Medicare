Imports pbs.Helper
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Csla.Validation
Imports pbs.BO.DataAnnotations
Imports pbs.BO.Script
Imports pbs.BO.BusinessRules


Namespace HR

    <Serializable()> _
    <DB(TableName:="pbs_BO_HR_OFFTYPE_{XXX}")>
    Public Class OFFTYPE
        Inherits Csla.BusinessBase(Of OFFTYPE)
        Implements Interfaces.IGenPartObject
        Implements IComparable
        Implements IDocLink



#Region "Property Changed"
        Protected Overrides Sub OnDeserialized(context As Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            AddHandler Me.PropertyChanged, AddressOf BO_PropertyChanged
        End Sub

        Private Sub BO_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Handles Me.PropertyChanged
            'Select Case e.PropertyName

            '    Case "OrderType"
            '        If Not Me.GetOrderTypeInfo.ManualRef Then
            '            Me._orderNo = POH.AutoReference
            '        End If

            '    Case "OrderDate"
            '        If String.IsNullOrEmpty(Me.OrderPrd) Then Me._orderPrd.Text = Me._orderDate.Date.ToSunPeriod

            '    Case "SuppCode"
            '        For Each line In Lines
            '            line._suppCode = Me.SuppCode
            '        Next

            '    Case "ConvCode"
            '        If String.IsNullOrEmpty(Me.ConvCode) Then
            '            _convRate.Float = 0
            '        Else
            '            Dim conv = pbs.BO.LA.CVInfoList.GetConverter(Me.ConvCode, _orderPrd, String.Empty)
            '            If conv IsNot Nothing Then
            '                _convRate.Float = conv.DefaultRate
            '            End If
            '        End If

            '    Case Else

            'End Select

            pbs.BO.Rules.CalculationRules.Calculator(sender, e)
        End Sub
#End Region

#Region " Business Properties and Methods "
        Friend _DTB As String = String.Empty


        Private _lineNo As String = String.Empty
        <System.ComponentModel.DataObjectField(True, False)> _
        Public ReadOnly Property LineNo() As String
            Get
                Return _lineNo
            End Get
        End Property

        Private _candidateId As String = String.Empty
        <CellInfo("pbs.BO.HR.CANDIDATE", GroupName:="Offer type", Tips:="Enter Candidate ID")>
        <Rule(Required:=True)>
        Public Property CandidateId() As String
            Get
                Return _candidateId
            End Get
            Set(ByVal value As String)
                CanWriteProperty("CandidateId", True)
                If value Is Nothing Then value = String.Empty
                If Not _candidateId.Equals(value) Then
                    _candidateId = value
                    PropertyHasChanged("CandidateId")
                End If
            End Set
        End Property

        Private _offerType As String = String.Empty
        <CellInfo(GroupName:="Offer type", Tips:="Enter salary type and allowance")>
        Public Property OfferType() As String
            Get
                Return _offerType
            End Get
            Set(ByVal value As String)
                CanWriteProperty("OfferType", True)
                If value Is Nothing Then value = String.Empty
                If Not _offerType.Equals(value) Then
                    _offerType = value
                    PropertyHasChanged("OfferType")
                End If
            End Set
        End Property

        Private _effectiveDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="Offer type", Tips:="Enter effective date")>
        Public Property EffectiveDate() As String
            Get
                Return _effectiveDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("EffectiveDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _effectiveDate.Equals(value) Then
                    _effectiveDate.Text = value
                    PropertyHasChanged("EffectiveDate")
                End If
            End Set
        End Property

        Private _issueDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="Offer type", Tips:="Enter issue date")>
        Public Property IssueDate() As String
            Get
                Return _issueDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("IssueDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _issueDate.Equals(value) Then
                    _issueDate.Text = value
                    PropertyHasChanged("IssueDate")
                End If
            End Set
        End Property

        Private _status As String = String.Empty
        <CellInfo(GroupName:="Offer type", Tips:="Status")>
        Public Property Status() As String
            Get
                Return _status
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Status", True)
                If value Is Nothing Then value = String.Empty
                If Not _status.Equals(value) Then
                    _status = value
                    PropertyHasChanged("Status")
                End If
            End Set
        End Property

        Private _descriptn As String = String.Empty
        <CellInfo(GroupName:="Offer type", Tips:="Enter description")>
        Public Property Descriptn() As String
            Get
                Return _descriptn
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Descriptn", True)
                If value Is Nothing Then value = String.Empty
                If Not _descriptn.Equals(value) Then
                    _descriptn = value
                    PropertyHasChanged("Descriptn")
                End If
            End Set
        End Property

        Private _position As String = String.Empty
        <CellInfo(GroupName:="Offer type", Tips:="Enter position in offer")>
        Public Property Position() As String
            Get
                Return _position
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Position", True)
                If value Is Nothing Then value = String.Empty
                If Not _position.Equals(value) Then
                    _position = value
                    PropertyHasChanged("Position")
                End If
            End Set
        End Property

        Private _workingLocation As String = String.Empty
        <CellInfo(GroupName:="Offer type", Tips:="Enter working location code")>
        Public Property WorkingLocation() As String
            Get
                Return _workingLocation
            End Get
            Set(ByVal value As String)
                CanWriteProperty("WorkingLocation", True)
                If value Is Nothing Then value = String.Empty
                If Not _workingLocation.Equals(value) Then
                    _workingLocation = value
                    PropertyHasChanged("WorkingLocation")
                End If
            End Set
        End Property

        Private _extdesc5 As String = String.Empty
        <CellInfo(GroupName:="Extended description")>
        Public Property Extdesc5() As String
            Get
                Return _extdesc5
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Extdesc5", True)
                If value Is Nothing Then value = String.Empty
                If Not _extdesc5.Equals(value) Then
                    _extdesc5 = value
                    PropertyHasChanged("Extdesc5")
                End If
            End Set
        End Property

        Private _extdesc4 As String = String.Empty
        <CellInfo(GroupName:="Extended description")>
        Public Property Extdesc4() As String
            Get
                Return _extdesc4
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Extdesc4", True)
                If value Is Nothing Then value = String.Empty
                If Not _extdesc4.Equals(value) Then
                    _extdesc4 = value
                    PropertyHasChanged("Extdesc4")
                End If
            End Set
        End Property

        Private _extdesc3 As String = String.Empty
        <CellInfo(GroupName:="Extended description")>
        Public Property Extdesc3() As String
            Get
                Return _extdesc3
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Extdesc3", True)
                If value Is Nothing Then value = String.Empty
                If Not _extdesc3.Equals(value) Then
                    _extdesc3 = value
                    PropertyHasChanged("Extdesc3")
                End If
            End Set
        End Property

        Private _extdesc2 As String = String.Empty
        <CellInfo(GroupName:="Extended description")>
        Public Property Extdesc2() As String
            Get
                Return _extdesc2
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Extdesc2", True)
                If value Is Nothing Then value = String.Empty
                If Not _extdesc2.Equals(value) Then
                    _extdesc2 = value
                    PropertyHasChanged("Extdesc2")
                End If
            End Set
        End Property

        Private _extdesc1 As String = String.Empty
        <CellInfo(GroupName:="Extended description")>
        Public Property Extdesc1() As String
            Get
                Return _extdesc1
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Extdesc1", True)
                If value Is Nothing Then value = String.Empty
                If Not _extdesc1.Equals(value) Then
                    _extdesc1 = value
                    PropertyHasChanged("Extdesc1")
                End If
            End Set
        End Property

        Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="System", Hidden:=True)>
        Public Property Updated() As String
            Get
                Return _updated.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Updated", True)
                If value Is Nothing Then value = String.Empty
                If Not _updated.Equals(value) Then
                    _updated.Text = value
                    PropertyHasChanged("Updated")
                End If
            End Set
        End Property

        Private _updatedBy As String = String.Empty
        <CellInfo(GroupName:="System", Hidden:=True)>
        Public Property UpdatedBy() As String
            Get
                Return _updatedBy
            End Get
            Set(ByVal value As String)
                CanWriteProperty("UpdatedBy", True)
                If value Is Nothing Then value = String.Empty
                If Not _updatedBy.Equals(value) Then
                    _updatedBy = value
                    PropertyHasChanged("UpdatedBy")
                End If
            End Set
        End Property


        'Get ID
        Protected Overrides Function GetIdValue() As Object
            Return _lineNo
        End Function

        'IComparable
        Public Function CompareTo(ByVal IDObject) As Integer Implements System.IComparable.CompareTo
            Dim ID = IDObject.ToString
            Dim pLineNo As String = ID.Trim
            If _lineNo < pLineNo Then Return -1
            If _lineNo > pLineNo Then Return 1
            Return 0
        End Function

#End Region 'Business Properties and Methods

#Region "Validation Rules"

        Private Sub AddSharedCommonRules()
            'Sample simple custom rule
            'ValidationRules.AddRule(AddressOf LDInfo.ContainsValidPeriod, "Period", 1)           

            'Sample dependent property. when check one , check the other as well
            'ValidationRules.AddDependantProperty("AccntCode", "AnalT0")
        End Sub

        Protected Overrides Sub AddBusinessRules()
            AddSharedCommonRules()

            For Each _field As ClassField In ClassSchema(Of OFFTYPE)._fieldList
                If _field.Required Then
                    ValidationRules.AddRule(AddressOf Csla.Validation.CommonRules.StringRequired, _field.FieldName, 0)
                End If
                If Not String.IsNullOrEmpty(_field.RegexPattern) Then
                    ValidationRules.AddRule(AddressOf Csla.Validation.CommonRules.RegExMatch, New RegExRuleArgs(_field.FieldName, _field.RegexPattern), 1)
                End If
                '----------using lookup, if no user lookup defined, fallback to predefined by developer----------------------------
                If CATMAPInfoList.ContainsCode(_field) Then
                    ValidationRules.AddRule(AddressOf LKUInfoList.ContainsLiveCode, _field.FieldName, 2)
                    'Else
                    '    Select Case _field.FieldName
                    '        Case "LocType"
                    '            ValidationRules.AddRule(Of LOC, AnalRuleArg)(AddressOf LOOKUPInfoList.ContainsSysCode, New AnalRuleArg(_field.FieldName, SysCats.LocationType))
                    '        Case "Status"
                    '            ValidationRules.AddRule(Of LOC, AnalRuleArg)(AddressOf LOOKUPInfoList.ContainsSysCode, New AnalRuleArg(_field.FieldName, SysCats.LocationStatus))
                    '    End Select
                End If
            Next
            Rules.BusinessRules.RegisterBusinessRules(Me)
            MyBase.AddBusinessRules()
        End Sub
#End Region ' Validation

#Region " Factory Methods "

        Private Sub New()
            _DTB = Context.CurrentBECode
        End Sub

        Public Shared Function BlankOFFTYPE() As OFFTYPE
            Return New OFFTYPE
        End Function

        Public Shared Function NewOFFTYPE(ByVal pLineNo As String) As OFFTYPE
            'If KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(String.Format(ResStr(ResStrConst.NOACCESS), ResStr("OFFTYPE")))
            Return DataPortal.Create(Of OFFTYPE)(New Criteria(pLineNo))
        End Function

        Public Shared Function NewBO(ByVal ID As String) As OFFTYPE
            Dim pLineNo As String = ID.Trim

            Return NewOFFTYPE(pLineNo)
        End Function

        Public Shared Function GetOFFTYPE(ByVal pLineNo As String) As OFFTYPE
            Return DataPortal.Fetch(Of OFFTYPE)(New Criteria(pLineNo))
        End Function

        Public Shared Function GetBO(ByVal ID As String) As OFFTYPE
            Dim pLineNo As String = ID.Trim

            Return GetOFFTYPE(pLineNo)
        End Function

        Public Shared Sub DeleteOFFTYPE(ByVal pLineNo As String)
            DataPortal.Delete(New Criteria(pLineNo))
        End Sub

        Public Overrides Function Save() As OFFTYPE
            If Not IsDirty Then ExceptionThower.NotDirty(ResStr(ResStrConst.NOTDIRTY))
            If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("OFFTYPE")))

            Me.ApplyEdit()
            OFFTYPEInfoList.InvalidateCache()
            Return MyBase.Save()
        End Function

        Public Function CloneOFFTYPE(ByVal pLineNo As String) As OFFTYPE

            'If OFFTYPE.KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(ResStr(ResStrConst.CreateAlreadyExists), Me.GetType.ToString.Leaf.Translate)

            Dim cloningOFFTYPE As OFFTYPE = MyBase.Clone
            cloningOFFTYPE._lineNo = pLineNo

            'Todo:Remember to reset status of the new object here 
            cloningOFFTYPE.MarkNew()
            cloningOFFTYPE.ApplyEdit()

            cloningOFFTYPE.ValidationRules.CheckRules()

            Return cloningOFFTYPE
        End Function

#End Region ' Factory Methods

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public _lineNo As String = String.Empty

            Public Sub New(ByVal pLineNo As String)
                _lineNo = pLineNo

            End Sub
        End Class

        <RunLocal()> _
        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)
            _lineNo = criteria._lineNo

            ValidationRules.CheckRules()
        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()
                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>SELECT * FROM pbs_HR_OFF_TYPE_<%= _DTB %> WHERE LINE_NO= '<%= criteria._lineNo %>'
                                              SELECT * FROM pbs_HR_OFF_CMPNT_<%= _DTB %> WHERE OFFER_NO = '<%= criteria._lineNo %>'
                                     </SqlText>.Value.Trim

                    Using dr As New SafeDataReader(cm.ExecuteReader)
                        If dr.Read Then
                            FetchObject(dr)
                            MarkOld()
                        End If

                        If dr.NextResult Then
                            _details = CMPNTs.GetCMPNTs(dr, Me)
                        End If
                    End Using

                End Using
            End Using
        End Sub

        Private Sub FetchObject(ByVal dr As SafeDataReader)
            _lineNo = dr.GetInt32("LINE_NO")
            _candidateId = dr.GetInt32("CANDIDATE_ID")
            _offerType = dr.GetString("OFFER_TYPE").TrimEnd
            _effectiveDate.Text = dr.GetInt32("EFFECTIVE_DATE")
            _issueDate.Text = dr.GetInt32("ISSUE_DATE")
            _status = dr.GetString("STATUS").TrimEnd
            _descriptn = dr.GetString("DESCRIPTN").TrimEnd
            _position = dr.GetString("POSITION").TrimEnd
            _workingLocation = dr.GetString("WORKING_LOCATION").TrimEnd
            _extdesc5 = dr.GetString("EXTDESC5").TrimEnd
            _extdesc4 = dr.GetString("EXTDESC4").TrimEnd
            _extdesc3 = dr.GetString("EXTDESC3").TrimEnd
            _extdesc2 = dr.GetString("EXTDESC2").TrimEnd
            _extdesc1 = dr.GetString("EXTDESC1").TrimEnd
            _updated.Text = dr.GetInt32("UPDATED")
            _updatedBy = dr.GetString("UPDATED_BY").TrimEnd

        End Sub

        Private Shared _lockObj As New Object
        Protected Overrides Sub DataPortal_Insert()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    Using cm = ctx.Connection.CreateCommand()

                        cm.CommandType = CommandType.StoredProcedure
                        cm.CommandText = String.Format("pbs_HR_OFF_TYPE_{0}_Insert", _DTB)

                        cm.Parameters.AddWithValue("@LINE_NO", _lineNo.Trim.ToInteger).Direction = ParameterDirection.InputOutput
                        AddInsertParameters(cm)
                        cm.ExecuteNonQuery()

                        _lineNo = CInt(cm.Parameters("@LINE_NO").Value)
                    End Using

                    Me.Details.Update(ctx.Connection, Me)
                End Using
            End SyncLock
        End Sub

        Private Sub AddInsertParameters(ByVal cm As SqlCommand)

            cm.Parameters.AddWithValue("@CANDIDATE_ID", _candidateId.Trim)
            cm.Parameters.AddWithValue("@OFFER_TYPE", _offerType.Trim)
            cm.Parameters.AddWithValue("@EFFECTIVE_DATE", _effectiveDate.DBValue)
            cm.Parameters.AddWithValue("@ISSUE_DATE", _issueDate.DBValue)
            cm.Parameters.AddWithValue("@STATUS", _status.Trim)
            cm.Parameters.AddWithValue("@DESCRIPTN", _descriptn.Trim)
            cm.Parameters.AddWithValue("@POSITION", _position.Trim)
            cm.Parameters.AddWithValue("@WORKING_LOCATION", _workingLocation.Trim)
            cm.Parameters.AddWithValue("@EXTDESC5", _extdesc5.Trim)
            cm.Parameters.AddWithValue("@EXTDESC4", _extdesc4.Trim)
            cm.Parameters.AddWithValue("@EXTDESC3", _extdesc3.Trim)
            cm.Parameters.AddWithValue("@EXTDESC2", _extdesc2.Trim)
            cm.Parameters.AddWithValue("@EXTDESC1", _extdesc1.Trim)
            cm.Parameters.AddWithValue("@UPDATED", ToDay.ToSunDate)
            cm.Parameters.AddWithValue("@UPDATED_BY", Context.CurrentUserCode)
        End Sub


        Protected Overrides Sub DataPortal_Update()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    Using cm = ctx.Connection.CreateCommand()

                        cm.CommandType = CommandType.StoredProcedure
                        cm.CommandText = String.Format("pbs_HR_OFF_TYPE_{0}_Update", _DTB)

                        cm.Parameters.AddWithValue("@LINE_NO", _lineNo.Trim)
                        AddInsertParameters(cm)
                        cm.ExecuteNonQuery()

                    End Using

                    Me.Details.Update(ctx.Connection, Me)
                End Using
            End SyncLock
        End Sub

        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_lineNo))
        End Sub

        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()

                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>DELETE pbs_HR_OFF_TYPE_<%= _DTB %> WHERE LINE_NO= '<%= criteria._lineNo %>' </SqlText>.Value.Trim
                    cm.ExecuteNonQuery()

                End Using
            End Using

        End Sub

        Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(ByVal e As Csla.DataPortalEventArgs)
            If Csla.ApplicationContext.ExecutionLocation = ExecutionLocations.Server Then
                OFFTYPEInfoList.InvalidateCache()
            End If
        End Sub


#End Region 'Data Access                           

#Region " Exists "
        Public Shared Function Exists(ByVal pLineNo As String) As Boolean
            Return OFFTYPEInfoList.ContainsCode(pLineNo)
        End Function

        'Public Shared Function KeyDuplicated(ByVal pLineNo As String) As Boolean
        '    Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_HR_OFF_TYPE_DEM WHERE DTB='<%= Context.CurrentBECode %>'  AND LINE_NO= '<%= pLineNo %>'</SqlText>.Value.Trim
        '    Return SQLCommander.GetScalarInteger(SqlText) > 0
        'End Function
#End Region

#Region " IGenpart "

        Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
            Return CloneOFFTYPE(id)
        End Function

        Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
            Return GetBO(id)
        End Function

        Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
            Return pbs.Helper.Action.StandardReferenceCommands
        End Function

        Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
            Return GetType(OFFTYPE).ToString
        End Function

        Public Function myName() As String Implements Interfaces.IGenPartObject.myName
            Return GetType(OFFTYPE).ToString.Leaf
        End Function

        Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
            Return OFFTYPEInfoList.GetOFFTYPEInfoList
        End Function
#End Region

#Region "IDoclink"
        Public Function Get_DOL_Reference() As String Implements IDocLink.Get_DOL_Reference
            Return String.Format("{0}#{1}", Get_TransType, _lineNo)
        End Function

        Public Function Get_TransType() As String Implements IDocLink.Get_TransType
            Return Me.GetType.ToClassSchemaName.Leaf
        End Function
#End Region

    End Class

End Namespace