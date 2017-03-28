Imports pbs.Helper
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Csla.Validation
Imports pbs.BO.DataAnnotations
Imports pbs.BO.Script
Imports pbs.BO.BusinessRules


Namespace MC

    <Serializable()> _
    Public Class FEEMANAGEMENT
        Inherits Csla.BusinessBase(Of FEEMANAGEMENT)
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
        Private _DTB As String = String.Empty


        Private _lineNo As String = String.Empty
        <System.ComponentModel.DataObjectField(True, False)> _
        Public ReadOnly Property LineNo() As String
            Get
                Return _lineNo
            End Get
        End Property

        Private _patientCode As String = String.Empty
        <CellInfo("PBS.BO.MC.PATIENT", GroupName:="General Info", Tips:="Enter patient code")>
        Public Property PatientCode() As String
            Get
                Return _patientCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PatientCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _patientCode.Equals(value) Then
                    _patientCode = value
                    PropertyHasChanged("PatientCode")
                End If
            End Set
        End Property

        Private _checkinNo As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        <CellInfo("pbs.BO.MC.CHECKIN", GroupName:="General Info", Tips:="Enter check-in number")>
        Public Property CheckinNo() As String
            Get
                Return _checkinNo.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("CheckinNo", True)
                If value Is Nothing Then value = String.Empty
                If Not _checkinNo.Equals(value) Then
                    _checkinNo.Text = value
                    PropertyHasChanged("CheckinNo")
                End If
            End Set
        End Property

        Private _institutionFeeType As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="General Info", Tips:="Enter institution fee type, this used for grouping fees")>
        Public Property InstitutionFeeType() As String
            Get
                Return _institutionFeeType.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("InstitutionFeeType", True)
                If value Is Nothing Then value = String.Empty
                If Not _institutionFeeType.Equals(value) Then
                    _institutionFeeType.Text = value
                    PropertyHasChanged("InstitutionFeeType")
                End If
            End Set
        End Property

        Private _itemCode As String = String.Empty
        <CellInfo(GroupName:="Detail", Tips:="Enter item code")>
        Public Property ItemCode() As String
            Get
                Return _itemCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ItemCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _itemCode.Equals(value) Then
                    _itemCode = value
                    PropertyHasChanged("ItemCode")
                End If
            End Set
        End Property

        Private _unitPrice As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Detail", Tips:="Enter unit price")>
        Public Property UnitPrice() As String
            Get
                Return _unitPrice.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("UnitPrice", True)
                If value Is Nothing Then value = String.Empty
                If Not _unitPrice.Equals(value) Then
                    _unitPrice.Text = value
                    PropertyHasChanged("UnitPrice")
                End If
            End Set
        End Property

        Private _quantity As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        <CellInfo(GroupName:="Detail", Tips:="Enter quantity of item or service")>
        Public Property Quantity() As String
            Get
                Return _quantity.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Quantity", True)
                If value Is Nothing Then value = String.Empty
                If Not _quantity.Equals(value) Then
                    _quantity.Text = value
                    PropertyHasChanged("Quantity")
                End If
            End Set
        End Property

        Private _totalPayment As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Detail", Tips:="Enter total payment before health insurance cover")>
        Public Property TotalPayment() As String
            Get
                Return _totalPayment.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("TotalPayment", True)
                If value Is Nothing Then value = String.Empty
                If Not _totalPayment.Equals(value) Then
                    _totalPayment.Text = value
                    PropertyHasChanged("TotalPayment")
                End If
            End Set
        End Property

        Private _healthInsuranceCover As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Detail", Tips:="Enter amound of money that health insurance cover")>
        Public Property HealthInsuranceCover() As String
            Get
                Return _healthInsuranceCover.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("HealthInsuranceCover", True)
                If value Is Nothing Then value = String.Empty
                If Not _healthInsuranceCover.Equals(value) Then
                    _healthInsuranceCover.Text = value
                    PropertyHasChanged("HealthInsuranceCover")
                End If
            End Set
        End Property

        Private _realPayment As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Detail", Tips:="Enter real payment that patient will pay")>
        Public Property RealPayment() As String
            Get
                Return _realPayment.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("RealPayment", True)
                If value Is Nothing Then value = String.Empty
                If Not _realPayment.Equals(value) Then
                    _realPayment.Text = value
                    PropertyHasChanged("RealPayment")
                End If
            End Set
        End Property

        Private _status As String = String.Empty
        <CellInfo(GroupName:="Detail", Tips:="Enter status")>
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

        Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="System")>
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
        <CellInfo(GroupName:="System")>
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

            For Each _field As ClassField In ClassSchema(Of FEEMANAGEMENT)._fieldList
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

        Public Shared Function BlankFEEMANAGEMENT() As FEEMANAGEMENT
            Return New FEEMANAGEMENT
        End Function

        Public Shared Function NewFEEMANAGEMENT(ByVal pLineNo As String) As FEEMANAGEMENT
            'If KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(String.Format(ResStr(ResStrConst.NOACCESS), ResStr("FEEMANAGEMENT")))
            Return DataPortal.Create(Of FEEMANAGEMENT)(New Criteria(pLineNo))
        End Function

        Public Shared Function NewBO(ByVal ID As String) As FEEMANAGEMENT
            Dim pLineNo As String = ID.Trim

            Return NewFEEMANAGEMENT(pLineNo)
        End Function

        Public Shared Function GetFEEMANAGEMENT(ByVal pLineNo As String) As FEEMANAGEMENT
            Return DataPortal.Fetch(Of FEEMANAGEMENT)(New Criteria(pLineNo))
        End Function

        Public Shared Function GetBO(ByVal ID As String) As FEEMANAGEMENT
            Dim pLineNo As String = ID.Trim

            Return GetFEEMANAGEMENT(pLineNo)
        End Function

        Public Shared Sub DeleteFEEMANAGEMENT(ByVal pLineNo As String)
            DataPortal.Delete(New Criteria(pLineNo))
        End Sub

        Public Overrides Function Save() As FEEMANAGEMENT
            If Not IsDirty Then ExceptionThower.NotDirty(ResStr(ResStrConst.NOTDIRTY))
            If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("FEEMANAGEMENT")))

            Me.ApplyEdit()
            FEEMANAGEMENTInfoList.InvalidateCache()
            Return MyBase.Save()
        End Function

        Public Function CloneFEEMANAGEMENT(ByVal pLineNo As String) As FEEMANAGEMENT

            'If FEEMANAGEMENT.KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(ResStr(ResStrConst.CreateAlreadyExists), Me.GetType.ToString.Leaf.Translate)

            Dim cloningFEEMANAGEMENT As FEEMANAGEMENT = MyBase.Clone
            cloningFEEMANAGEMENT._lineNo = pLineNo

            'Todo:Remember to reset status of the new object here 
            cloningFEEMANAGEMENT.MarkNew()
            cloningFEEMANAGEMENT.ApplyEdit()

            cloningFEEMANAGEMENT.ValidationRules.CheckRules()

            Return cloningFEEMANAGEMENT
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
                    cm.CommandText = <SqlText>SELECT * FROM pbs_MC_FEE_MANAGEMENT_DEM WHERE DTB='<%= _DTB %>'  AND LINE_NO= '<%= criteria._lineNo %>' </SqlText>.Value.Trim

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
            _patientCode = dr.GetString("PATIENT_CODE").TrimEnd
            _checkinNo.Text = dr.GetInt32("CHECKIN_NO")
            _institutionFeeType.Text = dr.GetDecimal("INSTITUTION_FEE_TYPE")
            _itemCode = dr.GetString("ITEM_CODE").TrimEnd
            _unitPrice.Text = dr.GetDecimal("UNIT_PRICE")
            _quantity.Text = dr.GetInt32("QUANTITY")
            _totalPayment.Text = dr.GetDecimal("TOTAL_PAYMENT")
            _healthInsuranceCover.Text = dr.GetDecimal("HEALTH_INSURANCE_COVER")
            _realPayment.Text = dr.GetDecimal("REAL_PAYMENT")
            _status = dr.GetString("STATUS").TrimEnd
            _updated.Text = dr.GetInt32("UPDATED")
            _updatedBy = dr.GetString("UPDATED_BY").TrimEnd

        End Sub

        Private Shared _lockObj As New Object
        Protected Overrides Sub DataPortal_Insert()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    Using cm = ctx.Connection.CreateCommand()

                        cm.CommandType = CommandType.StoredProcedure
                        cm.CommandText = String.Format("pbs_MC_FEE_MANAGEMENT_{0}_Insert", _DTB)

                        cm.Parameters.AddWithValue("@LINE_NO", _lineNo.ToInteger).Direction = ParameterDirection.Output
                        AddInsertParameters(cm)
                        cm.ExecuteNonQuery()

                        _lineNo = CInt(cm.Parameters("@LINE_NO").Value)
                    End Using
                End Using
            End SyncLock
        End Sub

        Private Sub AddInsertParameters(ByVal cm As SqlCommand)

            cm.Parameters.AddWithValue("@PATIENT_CODE", _patientCode.Trim)
            cm.Parameters.AddWithValue("@CHECKIN_NO", _checkinNo.DBValue)
            cm.Parameters.AddWithValue("@INSTITUTION_FEE_TYPE", _institutionFeeType.DBValue)
            cm.Parameters.AddWithValue("@ITEM_CODE", _itemCode.Trim)
            cm.Parameters.AddWithValue("@UNIT_PRICE", _unitPrice.DBValue)
            cm.Parameters.AddWithValue("@QUANTITY", _quantity.DBValue)
            cm.Parameters.AddWithValue("@TOTAL_PAYMENT", _totalPayment.DBValue)
            cm.Parameters.AddWithValue("@HEALTH_INSURANCE_COVER", _healthInsuranceCover.DBValue)
            cm.Parameters.AddWithValue("@REAL_PAYMENT", _realPayment.DBValue)
            cm.Parameters.AddWithValue("@STATUS", _status.Trim)
            cm.Parameters.AddWithValue("@UPDATED", _updated.DBValue)
            cm.Parameters.AddWithValue("@UPDATED_BY", _updatedBy.Trim)
        End Sub


        Protected Overrides Sub DataPortal_Update()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    Using cm = ctx.Connection.CreateCommand()

                        cm.CommandType = CommandType.StoredProcedure
                        cm.CommandText = String.Format("pbs_MC_FEE_MANAGEMENT_{0}_Update", _DTB)

                        cm.Parameters.AddWithValue("@LINE_NO", _lineNo)
                        AddInsertParameters(cm)
                        cm.ExecuteNonQuery()

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
                    cm.CommandText = <SqlText>DELETE pbs_MC_FEE_MANAGEMENT_<%= _DTB %> WHERE LINE_NO= '<%= criteria._lineNo %>' </SqlText>.Value.Trim
                    cm.ExecuteNonQuery()

                End Using
            End Using

        End Sub

        Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(ByVal e As Csla.DataPortalEventArgs)
            If Csla.ApplicationContext.ExecutionLocation = ExecutionLocations.Server Then
                FEEMANAGEMENTInfoList.InvalidateCache()
            End If
        End Sub


#End Region 'Data Access                           

#Region " Exists "
        Public Shared Function Exists(ByVal pLineNo As String) As Boolean
            Return FEEMANAGEMENTInfoList.ContainsCode(pLineNo)
        End Function

        'Public Shared Function KeyDuplicated(ByVal pLineNo As String) As Boolean
        '    Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_MC_FEE_MANAGEMENT_DEM WHERE DTB='<%= Context.CurrentBECode %>'  AND LINE_NO= '<%= pLineNo %>'</SqlText>.Value.Trim
        '    Return SQLCommander.GetScalarInteger(SqlText) > 0
        'End Function
#End Region

#Region " IGenpart "

        Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
            Return CloneFEEMANAGEMENT(id)
        End Function

        Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
            Return GetBO(id)
        End Function

        Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
            Return pbs.Helper.Action.StandardReferenceCommands
        End Function

        Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
            Return GetType(FEEMANAGEMENT).ToString
        End Function

        Public Function myName() As String Implements Interfaces.IGenPartObject.myName
            Return GetType(FEEMANAGEMENT).ToString.Leaf
        End Function

        Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
            Return FEEMANAGEMENTInfoList.GetFEEMANAGEMENTInfoList
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