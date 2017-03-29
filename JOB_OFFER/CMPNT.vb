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
    <DB(TableName:="pbs_HR_OFF_CMPNT_{XXX}")>
    Public Class CMPNT
        Inherits Csla.BusinessBase(Of CMPNT)
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


        Friend _lineNo As String = String.Empty
        <System.ComponentModel.DataObjectField(True, True)> _
        Public ReadOnly Property LineNo() As String
            Get
                Return _lineNo
            End Get
        End Property

        Private _offerNo As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        <CellInfo(GroupName:="Component", Tips:="Line No of parent table")>
        Public Property OfferNo() As String
            Get
                Return _offerNo.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("OfferNo", True)
                If value Is Nothing Then value = String.Empty
                If Not _offerNo.Equals(value) Then
                    _offerNo.Text = value
                    PropertyHasChanged("OfferNo")
                End If
            End Set
        End Property

        Private _cmpntCode As String = String.Empty
        <CellInfo(GroupName:="Component", Tips:="Enter Component code")>
        <Rule(Required:=True)>
        Public Property CmpntCode() As String
            Get
                Return _cmpntCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("CmpntCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _cmpntCode.Equals(value) Then
                    _cmpntCode = value
                    PropertyHasChanged("CmpntCode")
                End If
            End Set
        End Property

        Friend _effectiveDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="Component", Tips:="Enter effective date")>
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

        Private _status As String = String.Empty
        <CellInfo(GroupName:="Component", Tips:="Status")>
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

        Private _description As String = String.Empty
        <CellInfo(GroupName:="Component", Tips:="Description")>
        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Description", True)
                If value Is Nothing Then value = String.Empty
                If Not _description.Equals(value) Then
                    _description = value
                    PropertyHasChanged("Description")
                End If
            End Set
        End Property

        Private _offerType As String = String.Empty
        <CellInfo(GroupName:="Component", Tips:="Enter salary type and allowance")>
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

        Private _frequency As String = String.Empty
        <CellInfo(GroupName:="Component", Tips:="Salary payment and allowance cycle")>
        Public Property Frequency() As String
            Get
                Return _frequency
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Frequency", True)
                If value Is Nothing Then value = String.Empty
                If Not _frequency.Equals(value) Then
                    _frequency = value
                    PropertyHasChanged("Frequency")
                End If
            End Set
        End Property

        Private _currencyCode As String = String.Empty
        <CellInfo(GroupName:="Component", Tips:="Enter currency code")>
        Public Property CurrencyCode() As String
            Get
                Return _currencyCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("CurrencyCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _currencyCode.Equals(value) Then
                    _currencyCode = value
                    PropertyHasChanged("CurrencyCode")
                End If
            End Set
        End Property

        Private _cash As String = String.Empty
        <CellInfo(GroupName:="Component", Tips:="Payment by Cash")>
        Public Property Cash() As Boolean
            Get
                Return _cash.ToBoolean
            End Get
            Set(ByVal value As Boolean)
                CanWriteProperty("Cash", True)
                If Not _cash.Equals(value) Then
                    _cash = If(value, "Y", "N")
                    PropertyHasChanged("Cash")
                End If
            End Set
        End Property

        Private _amount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Component", Tips:="Enter currency code")>
        Public Property Amount() As String
            Get
                Return _amount.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Amount", True)
                If value Is Nothing Then value = String.Empty
                If Not _amount.Equals(value) Then
                    _amount.Text = value
                    PropertyHasChanged("Amount")
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

        Sub CheckRules()
            ValidationRules.CheckRules()
        End Sub

        Private Sub AddSharedCommonRules()
            'Sample simple custom rule
            'ValidationRules.AddRule(AddressOf LDInfo.ContainsValidPeriod, "Period", 1)           

            'Sample dependent property. when check one , check the other as well
            'ValidationRules.AddDependantProperty("AccntCode", "AnalT0")
        End Sub

        Protected Overrides Sub AddBusinessRules()
            AddSharedCommonRules()

            For Each _field As ClassField In ClassSchema(Of CMPNT)._fieldList
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

        Public Shared Function BlankCMPNT() As CMPNT
            Return New CMPNT
        End Function

        Public Shared Function NewCMPNT(ByVal pLineNo As String) As CMPNT
            'If KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(String.Format(ResStr(ResStrConst.NOACCESS), ResStr("CMPNT")))
            Return DataPortal.Create(Of CMPNT)(New Criteria(pLineNo))
        End Function

        Public Shared Function NewBO(ByVal ID As String) As CMPNT
            Dim pLineNo As String = ID.Trim

            Return NewCMPNT(pLineNo)
        End Function

        Public Shared Function GetCMPNT(ByVal pLineNo As String) As CMPNT
            Return DataPortal.Fetch(Of CMPNT)(New Criteria(pLineNo))
        End Function

        Public Shared Function GetBO(ByVal ID As String) As CMPNT
            Dim pLineNo As String = ID.Trim

            Return GetCMPNT(pLineNo)
        End Function

        Public Shared Sub DeleteCMPNT(ByVal pLineNo As String)
            DataPortal.Delete(New Criteria(pLineNo))
        End Sub

        Public Overrides Function Save() As CMPNT
            If Not IsDirty Then ExceptionThower.NotDirty(ResStr(ResStrConst.NOTDIRTY))
            If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("CMPNT")))

            Me.ApplyEdit()
            CMPNTInfoList.InvalidateCache()
            Return MyBase.Save()
        End Function

        Public Function CloneCMPNT(ByVal pLineNo As String) As CMPNT

            'If CMPNT.KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(ResStr(ResStrConst.CreateAlreadyExists), Me.GetType.ToString.Leaf.Translate)

            Dim cloningCMPNT As CMPNT = MyBase.Clone
            cloningCMPNT._lineNo = pLineNo

            'Todo:Remember to reset status of the new object here 
            cloningCMPNT.MarkNew()
            cloningCMPNT.ApplyEdit()

            cloningCMPNT.ValidationRules.CheckRules()

            Return cloningCMPNT
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
                    cm.CommandText = <SqlText>SELECT * FROM pbs_HR_OFF_CMPNT_<%= _DTB %> WHERE LINE_NO= '<%= criteria._lineNo %>' </SqlText>.Value.Trim

                    Using dr As New SafeDataReader(cm.ExecuteReader)
                        If dr.Read Then
                            FetchObject(dr)
                            MarkOld()
                        End If
                    End Using

                End Using
            End Using
        End Sub

        Private Sub FetchObject(ByVal dr As SafeDataReader)
            _lineNo = dr.GetInt32("LINE_NO")
            _offerNo.Text = dr.GetInt32("OFFER_NO")
            _cmpntCode = dr.GetString("CMPNT_CODE").TrimEnd
            _effectiveDate.Text = dr.GetInt32("EFFECTIVE_DATE")
            _status = dr.GetString("STATUS").TrimEnd
            _description = dr.GetString("DESCRIPTION").TrimEnd
            _offerType = dr.GetString("OFFER_TYPE").TrimEnd
            _frequency = dr.GetString("FREQUENCY").TrimEnd
            _currencyCode = dr.GetString("CURRENCY_CODE").TrimEnd
            _cash = dr.GetString("CASH").TrimEnd
            _amount.Text = dr.GetDecimal("AMOUNT")
            _updated.Text = dr.GetInt32("UPDATED")
            _updatedBy = dr.GetString("UPDATED_BY").TrimEnd

        End Sub

        Private Shared _lockObj As New Object
        Protected Overrides Sub DataPortal_Insert()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    Using cm = ctx.Connection.CreateCommand()

                        'cm.CommandType = CommandType.StoredProcedure
                        'cm.CommandText = String.Format("pbs_HR_OFF_CMPNT_{0}_Insert", _DTB)

                        'cm.Parameters.AddWithValue("@LINE_NO", _lineNo.Trim.ToString).Direction = ParameterDirection.Output
                        'AddInsertParameters(cm)
                        'cm.ExecuteNonQuery()

                        '_lineNo = CInt(cm.Parameters("@LINE_NO").Value)

                        Insert(ctx.Connection)

                    End Using
                End Using
            End SyncLock
        End Sub

        Private Sub AddInsertParameters(ByVal cm As SqlCommand)

            cm.Parameters.AddWithValue("@OFFER_NO", _offerNo.DBValue)
            cm.Parameters.AddWithValue("@CMPNT_CODE", _cmpntCode.Trim)
            cm.Parameters.AddWithValue("@EFFECTIVE_DATE", _effectiveDate.DBValue)
            cm.Parameters.AddWithValue("@STATUS", _status.Trim)
            cm.Parameters.AddWithValue("@DESCRIPTION", _description.Trim)
            cm.Parameters.AddWithValue("@OFFER_TYPE", _offerType.Trim)
            cm.Parameters.AddWithValue("@FREQUENCY", _frequency.Trim)
            cm.Parameters.AddWithValue("@CURRENCY_CODE", _currencyCode.Trim)
            cm.Parameters.AddWithValue("@CASH", _cash.Trim)
            cm.Parameters.AddWithValue("@AMOUNT", _amount.DBValue)
            cm.Parameters.AddWithValue("@UPDATED", ToDay.ToSunDate)
            cm.Parameters.AddWithValue("@UPDATED_BY", Context.CurrentUserCode)
        End Sub


        Protected Overrides Sub DataPortal_Update()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    Using cm = ctx.Connection.CreateCommand()

                        'cm.CommandType = CommandType.StoredProcedure
                        'cm.CommandText = String.Format("pbs_HR_OFF_CMPNT_{0}_Update", _DTB)

                        'cm.Parameters.AddWithValue("@LINE_NO", _lineNo.Trim.ToString).Direction = ParameterDirection.Output
                        'AddInsertParameters(cm)
                        'cm.ExecuteNonQuery()

                        '_lineNo = CInt(cm.Parameters("@LINE_NO").Value)

                        Update(ctx.Connection)
                    End Using
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
                    cm.CommandText = <SqlText>DELETE pbs_HR_OFF_CMPNT_<%= _DTB %> WHERE LINE_NO= '<%= criteria._lineNo %>' </SqlText>.Value.Trim
                    cm.ExecuteNonQuery()

                End Using
            End Using

        End Sub

        Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(ByVal e As Csla.DataPortalEventArgs)
            If Csla.ApplicationContext.ExecutionLocation = ExecutionLocations.Server Then
                CMPNTInfoList.InvalidateCache()
            End If
        End Sub


#End Region 'Data Access                           

#Region " Exists "
        Public Shared Function Exists(ByVal pLineNo As String) As Boolean
            Return CMPNTInfoList.ContainsCode(pLineNo)
        End Function

        'Public Shared Function KeyDuplicated(ByVal pLineNo As String) As Boolean
        '    Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_HR_OFF_CMPNT_DEM WHERE DTB='<%= Context.CurrentBECode %>'  AND LINE_NO= '<%= pLineNo %>'</SqlText>.Value.Trim
        '    Return SQLCommander.GetScalarInteger(SqlText) > 0
        'End Function
#End Region

#Region " IGenpart "

        Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
            Return CloneCMPNT(id)
        End Function

        Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
            Return GetBO(id)
        End Function

        Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
            Return pbs.Helper.Action.StandardReferenceCommands
        End Function

        Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
            Return GetType(CMPNT).ToString
        End Function

        Public Function myName() As String Implements Interfaces.IGenPartObject.myName
            Return GetType(CMPNT).ToString.Leaf
        End Function

        Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
            Return CMPNTInfoList.GetCMPNTInfoList
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

#Region "Child"
        Shared Function NewCMPNTChild(pParentID As String) As CMPNT
            Dim ret = New CMPNT
            ret.OfferNo = pParentID
            ret.MarkAsChild()
            Return ret
        End Function

        Shared Function GetChildCMPNT(dr As SafeDataReader)
            Dim child = New CMPNT
            child.FetchObject(dr)
            child.MarkAsChild()
            child.MarkOld()
            Return child
        End Function

        Sub DeleteSelf(cn As SqlConnection)
            Using cm = cn.CreateCommand
                cm.CommandType = CommandType.Text
                cm.CommandText = <sqltext>DELETE FROM pbs_HR_OFF_CMPNT_<%= _DTB %> WHERE LINE_NO = <%= _lineNo %></sqltext>
                cm.ExecuteNonQuery()
            End Using
        End Sub

        Sub Insert(cn As SqlConnection)
            Using cm = cn.CreateCommand()

                cm.CommandType = CommandType.StoredProcedure
                cm.CommandText = String.Format("pbs_HR_OFF_CMPNT_{0}_Insert", _DTB)

                cm.Parameters.AddWithValue("@LINE_NO", _lineNo.Trim.ToInteger).Direction = ParameterDirection.Output
                AddInsertParameters(cm)
                cm.ExecuteNonQuery()

                _lineNo = CInt(cm.Parameters("@LINE_NO").Value)

            End Using
        End Sub

        Sub Update(cn As SqlConnection)

            Using cm = cn.CreateCommand()

                cm.CommandType = CommandType.StoredProcedure
                cm.CommandText = String.Format("pbs_HR_OFF_CMPNT_{0}_Update", _DTB)

                cm.Parameters.AddWithValue("@LINE_NO", _lineNo.Trim)
                AddInsertParameters(cm)
                cm.ExecuteNonQuery()

            End Using

        End Sub
#End Region

    End Class

End Namespace