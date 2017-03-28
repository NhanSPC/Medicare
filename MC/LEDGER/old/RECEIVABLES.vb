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
    Public Class RECEIVABLES
        Inherits Csla.BusinessBase(Of RECEIVABLES)
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

        Private _transactionType As String = String.Empty
        <CellInfo(GroupName:="Trans", Tips:="Enter transaction type")>
        Public Property TransactionType() As String
            Get
                Return _transactionType
            End Get
            Set(ByVal value As String)
                CanWriteProperty("TransactionType", True)
                If value Is Nothing Then value = String.Empty
                If Not _transactionType.Equals(value) Then
                    _transactionType = value
                    PropertyHasChanged("TransactionType")
                End If
            End Set
        End Property

        Private _reference As String = String.Empty
        <CellInfo(GroupName:="Trans", Tips:="Enter reference number")>
        Public Property Reference() As String
            Get
                Return _reference
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Reference", True)
                If value Is Nothing Then value = String.Empty
                If Not _reference.Equals(value) Then
                    _reference = value
                    PropertyHasChanged("Reference")
                End If
            End Set
        End Property

        Private _transDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="Trans", Tips:="Enter transfer date")>
        Public Property TransDate() As String
            Get
                Return _transDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("TransDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _transDate.Equals(value) Then
                    _transDate.Text = value
                    PropertyHasChanged("TransDate")
                End If
            End Set
        End Property

        Private _period As SmartPeriod = New pbs.Helper.SmartPeriod()
        <CellInfo(GroupName:="Trans", Tips:="Enter transfer period")>
        Public Property Period() As String
            Get
                Return _period.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Period", True)
                If value Is Nothing Then value = String.Empty
                If Not _period.Equals(value) Then
                    _period.Text = value
                    PropertyHasChanged("Period")
                End If
            End Set
        End Property

        Private _candidateId As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="Trans", Tips:="Enter candidate ID")>
        Public Property CandidateId() As String
            Get
                Return _candidateId.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("CandidateId", True)
                If value Is Nothing Then value = String.Empty
                If Not _candidateId.Equals(value) Then
                    _candidateId.Text = value
                    PropertyHasChanged("CandidateId")
                End If
            End Set
        End Property

        Private _patientCode As String = String.Empty
        <CellInfo(GroupName:="Trans", Tips:="Enter patient code")>
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

        Private _clinic As String = String.Empty
        <CellInfo(GroupName:="Trans", Tips:="Enter clinic code")>
        Public Property Clinic() As String
            Get
                Return _clinic
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Clinic", True)
                If value Is Nothing Then value = String.Empty
                If Not _clinic.Equals(value) Then
                    _clinic = value
                    PropertyHasChanged("Clinic")
                End If
            End Set
        End Property

        Private _itemCode As String = String.Empty
        <CellInfo(GroupName:="Invoice info", Tips:="Enter item code")>
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

        Private _descriptn As String = String.Empty
        <CellInfo(GroupName:="Invoice info", Tips:="Enter item description")>
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

        Private _quantity As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Invoice info", Tips:="Enter item quatity")>
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

        Private _unitCode As String = String.Empty
        <CellInfo(GroupName:="Invoice info", Tips:="Enter unit code")>
        Public Property UnitCode() As String
            Get
                Return _unitCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("UnitCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _unitCode.Equals(value) Then
                    _unitCode = value
                    PropertyHasChanged("UnitCode")
                End If
            End Set
        End Property

        Private _unitPrice As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Invoice info", Tips:="Enter item price")>
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

        Private _transAmt As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Invoice info", Tips:="")>
        Public Property TransAmt() As String
            Get
                Return _transAmt.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("TransAmt", True)
                If value Is Nothing Then value = String.Empty
                If Not _transAmt.Equals(value) Then
                    _transAmt.Text = value
                    PropertyHasChanged("TransAmt")
                End If
            End Set
        End Property

        Private _convCode As String = String.Empty
        <CellInfo(GroupName:="Invoice info", Tips:="Enter conversion code")>
        Public Property ConvCode() As String
            Get
                Return _convCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ConvCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _convCode.Equals(value) Then
                    _convCode = value
                    PropertyHasChanged("ConvCode")
                End If
            End Set
        End Property

        Private _convRate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Invoice info", Tips:="Enter conversion rate")>
        Public Property ConvRate() As String
            Get
                Return _convRate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ConvRate", True)
                If value Is Nothing Then value = String.Empty
                If Not _convRate.Equals(value) Then
                    _convRate.Text = value
                    PropertyHasChanged("ConvRate")
                End If
            End Set
        End Property

        Private _amount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Invoice info", Tips:="Enter amount of money")>
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

        Private _dC As String = String.Empty
        <CellInfo(GroupName:="Invoice info", Tips:="Enter invoice type. Debit or Credit")>
        Public Property DC() As String
            Get
                Return _dC
            End Get
            Set(ByVal value As String)
                CanWriteProperty("DC", True)
                If value Is Nothing Then value = String.Empty
                If Not _dC.Equals(value) Then
                    _dC = value
                    PropertyHasChanged("DC")
                End If
            End Set
        End Property

        Private _paymentRef As String = String.Empty
        <CellInfo(GroupName:="Invoice info", Tips:="Enter payment's reference")>
        Public Property PaymentRef() As String
            Get
                Return _paymentRef
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PaymentRef", True)
                If value Is Nothing Then value = String.Empty
                If Not _paymentRef.Equals(value) Then
                    _paymentRef = value
                    PropertyHasChanged("PaymentRef")
                End If
            End Set
        End Property

        Private _payMethod As String = String.Empty
        <CellInfo(GroupName:="Invoice info", Tips:="Enter payment method")>
        Public Property PayMethod() As String
            Get
                Return _payMethod
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PayMethod", True)
                If value Is Nothing Then value = String.Empty
                If Not _payMethod.Equals(value) Then
                    _payMethod = value
                    PropertyHasChanged("PayMethod")
                End If
            End Set
        End Property

        Private _paymentDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="Invoice info", Tips:="Enter payment date")>
        Public Property PaymentDate() As String
            Get
                Return _paymentDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PaymentDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _paymentDate.Equals(value) Then
                    _paymentDate.Text = value
                    PropertyHasChanged("PaymentDate")
                End If
            End Set
        End Property

        Private _paymentPeriod As SmartPeriod = New pbs.Helper.SmartPeriod()
        <CellInfo(GroupName:="Invoice info", Tips:="Enter paymenperiod")>
        Public Property PaymentPeriod() As String
            Get
                Return _paymentPeriod.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PaymentPeriod", True)
                If value Is Nothing Then value = String.Empty
                If Not _paymentPeriod.Equals(value) Then
                    _paymentPeriod.Text = value
                    PropertyHasChanged("PaymentPeriod")
                End If
            End Set
        End Property

        Private _directInvoice As String = String.Empty
        <CellInfo(GroupName:="Invoice info", Tips:="")>
        Public Property DirectInvoice() As String
            Get
                Return _directInvoice
            End Get
            Set(ByVal value As String)
                CanWriteProperty("DirectInvoice", True)
                If value Is Nothing Then value = String.Empty
                If Not _directInvoice.Equals(value) Then
                    _directInvoice = value
                    PropertyHasChanged("DirectInvoice")
                End If
            End Set
        End Property

        Private _invoiceInfo As String = String.Empty
        <CellInfo(GroupName:="Invoice info", Tips:="Enter invoice information")>
        Public Property InvoiceInfo() As String
            Get
                Return _invoiceInfo
            End Get
            Set(ByVal value As String)
                CanWriteProperty("InvoiceInfo", True)
                If value Is Nothing Then value = String.Empty
                If Not _invoiceInfo.Equals(value) Then
                    _invoiceInfo = value
                    PropertyHasChanged("InvoiceInfo")
                End If
            End Set
        End Property

        Private _invoiceNo As String = String.Empty
        <CellInfo(GroupName:="Invoice info", Tips:="Enter invoice number")>
        Public Property InvoiceNo() As String
            Get
                Return _invoiceNo
            End Get
            Set(ByVal value As String)
                CanWriteProperty("InvoiceNo", True)
                If value Is Nothing Then value = String.Empty
                If Not _invoiceNo.Equals(value) Then
                    _invoiceNo = value
                    PropertyHasChanged("InvoiceNo")
                End If
            End Set
        End Property

        Private _invoiceSerial As String = String.Empty
        <CellInfo(GroupName:="Invoice info", Tips:="Enter invoice serial")>
        Public Property InvoiceSerial() As String
            Get
                Return _invoiceSerial
            End Get
            Set(ByVal value As String)
                CanWriteProperty("InvoiceSerial", True)
                If value Is Nothing Then value = String.Empty
                If Not _invoiceSerial.Equals(value) Then
                    _invoiceSerial = value
                    PropertyHasChanged("InvoiceSerial")
                End If
            End Set
        End Property

        Private _invoiceBook As String = String.Empty
        <CellInfo(GroupName:="Invoice info", Tips:="Enter invoice book")>
        Public Property InvoiceBook() As String
            Get
                Return _invoiceBook
            End Get
            Set(ByVal value As String)
                CanWriteProperty("InvoiceBook", True)
                If value Is Nothing Then value = String.Empty
                If Not _invoiceBook.Equals(value) Then
                    _invoiceBook = value
                    PropertyHasChanged("InvoiceBook")
                End If
            End Set
        End Property

        Private _invoiceDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="Invoice info", Tips:="Enter invoice date")>
        Public Property InvoiceDate() As String
            Get
                Return _invoiceDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("InvoiceDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _invoiceDate.Equals(value) Then
                    _invoiceDate.Text = value
                    PropertyHasChanged("InvoiceDate")
                End If
            End Set
        End Property

        Private _invoicePeriod As SmartPeriod = New pbs.Helper.SmartPeriod()
        <CellInfo(GroupName:="Invoice info", Tips:="Enter invoice period")>
        Public Property InvoicePeriod() As String
            Get
                Return _invoicePeriod.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("InvoicePeriod", True)
                If value Is Nothing Then value = String.Empty
                If Not _invoicePeriod.Equals(value) Then
                    _invoicePeriod.Text = value
                    PropertyHasChanged("InvoicePeriod")
                End If
            End Set
        End Property

        Private _vatRate As String = String.Empty
        <CellInfo(GroupName:="Invoice info", Tips:="Enter VAT rate")>
        Public Property VatRate() As String
            Get
                Return _vatRate
            End Get
            Set(ByVal value As String)
                CanWriteProperty("VatRate", True)
                If value Is Nothing Then value = String.Empty
                If Not _vatRate.Equals(value) Then
                    _vatRate = value
                    PropertyHasChanged("VatRate")
                End If
            End Set
        End Property

        Private _vatAmount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Invoice info", Tips:="Enter VAT amount")>
        Public Property VatAmount() As String
            Get
                Return _vatAmount.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("VatAmount", True)
                If value Is Nothing Then value = String.Empty
                If Not _vatAmount.Equals(value) Then
                    _vatAmount.Text = value
                    PropertyHasChanged("VatAmount")
                End If
            End Set
        End Property

        Private _ncPl0 As String = String.Empty
        <CellInfo(GroupName:="NCPL")>
        Public Property NcPl0() As String
            Get
                Return _ncPl0
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcPl0", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncPl0.Equals(value) Then
                    _ncPl0 = value
                    PropertyHasChanged("NcPl0")
                End If
            End Set
        End Property

        Private _ncPl1 As String = String.Empty
        <CellInfo(GroupName:="NCPL")>
        Public Property NcPl1() As String
            Get
                Return _ncPl1
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcPl1", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncPl1.Equals(value) Then
                    _ncPl1 = value
                    PropertyHasChanged("NcPl1")
                End If
            End Set
        End Property

        Private _ncPl2 As String = String.Empty
        <CellInfo(GroupName:="NCPL")>
        Public Property NcPl2() As String
            Get
                Return _ncPl2
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcPl2", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncPl2.Equals(value) Then
                    _ncPl2 = value
                    PropertyHasChanged("NcPl2")
                End If
            End Set
        End Property

        Private _ncPl3 As String = String.Empty
        <CellInfo(GroupName:="NCPL")>
        Public Property NcPl3() As String
            Get
                Return _ncPl3
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcPl3", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncPl3.Equals(value) Then
                    _ncPl3 = value
                    PropertyHasChanged("NcPl3")
                End If
            End Set
        End Property

        Private _ncPl4 As String = String.Empty
        <CellInfo(GroupName:="NCPL")>
        Public Property NcPl4() As String
            Get
                Return _ncPl4
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcPl4", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncPl4.Equals(value) Then
                    _ncPl4 = value
                    PropertyHasChanged("NcPl4")
                End If
            End Set
        End Property

        Private _ncPl5 As String = String.Empty
        <CellInfo(GroupName:="NCPL")>
        Public Property NcPl5() As String
            Get
                Return _ncPl5
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcPl5", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncPl5.Equals(value) Then
                    _ncPl5 = value
                    PropertyHasChanged("NcPl5")
                End If
            End Set
        End Property

        Private _ncPl6 As String = String.Empty
        <CellInfo(GroupName:="NCPL")>
        Public Property NcPl6() As String
            Get
                Return _ncPl6
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcPl6", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncPl6.Equals(value) Then
                    _ncPl6 = value
                    PropertyHasChanged("NcPl6")
                End If
            End Set
        End Property

        Private _ncPl7 As String = String.Empty
        <CellInfo(GroupName:="NCPL")>
        Public Property NcPl7() As String
            Get
                Return _ncPl7
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcPl7", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncPl7.Equals(value) Then
                    _ncPl7 = value
                    PropertyHasChanged("NcPl7")
                End If
            End Set
        End Property

        Private _ncPl8 As String = String.Empty
        <CellInfo(GroupName:="NCPL")>
        Public Property NcPl8() As String
            Get
                Return _ncPl8
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcPl8", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncPl8.Equals(value) Then
                    _ncPl8 = value
                    PropertyHasChanged("NcPl8")
                End If
            End Set
        End Property

        Private _ncPl9 As String = String.Empty
        <CellInfo(GroupName:="NCPL")>
        Public Property NcPl9() As String
            Get
                Return _ncPl9
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcPl9", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncPl9.Equals(value) Then
                    _ncPl9 = value
                    PropertyHasChanged("NcPl9")
                End If
            End Set
        End Property

        Private _allocation As String = String.Empty
        <CellInfo(GroupName:="Invoice info", Tips:="Allocation")>
        Public Property Allocation() As String
            Get
                Return _allocation
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Allocation", True)
                If value Is Nothing Then value = String.Empty
                If Not _allocation.Equals(value) Then
                    _allocation = value
                    PropertyHasChanged("Allocation")
                End If
            End Set
        End Property

        Private _allocRef As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        <CellInfo(GroupName:="Invoice info", Tips:="Enter allocation reference")>
        Public Property AllocRef() As String
            Get
                Return _allocRef.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AllocRef", True)
                If value Is Nothing Then value = String.Empty
                If Not _allocRef.Equals(value) Then
                    _allocRef.Text = value
                    PropertyHasChanged("AllocRef")
                End If
            End Set
        End Property

        Private _allocDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="Invoice info", Tips:="Enter allocation date")>
        Public Property AllocDate() As String
            Get
                Return _allocDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AllocDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _allocDate.Equals(value) Then
                    _allocDate.Text = value
                    PropertyHasChanged("AllocDate")
                End If
            End Set
        End Property

        Private _allocPeriod As SmartPeriod = New pbs.Helper.SmartPeriod()
        <CellInfo(GroupName:="Invoice info", Tips:="Enter allocation period")>
        Public Property AllocPeriod() As String
            Get
                Return _allocPeriod.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AllocPeriod", True)
                If value Is Nothing Then value = String.Empty
                If Not _allocPeriod.Equals(value) Then
                    _allocPeriod.Text = value
                    PropertyHasChanged("AllocPeriod")
                End If
            End Set
        End Property

        Private _status As String = String.Empty
        <CellInfo(GroupName:="Invoice info", Tips:="Enter status")>
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

        Private _lockFlag As String = String.Empty
        <CellInfo(GroupName:="Invoice info")>
        Public Property LockFlag() As String
            Get
                Return _lockFlag
            End Get
            Set(ByVal value As String)
                CanWriteProperty("LockFlag", True)
                If value Is Nothing Then value = String.Empty
                If Not _lockFlag.Equals(value) Then
                    _lockFlag = value
                    PropertyHasChanged("LockFlag")
                End If
            End Set
        End Property

        Private _postingDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="Invoice info", Tips:="Enter posting date")>
        Public Property PostingDate() As String
            Get
                Return _postingDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PostingDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _postingDate.Equals(value) Then
                    _postingDate.Text = value
                    PropertyHasChanged("PostingDate")
                End If
            End Set
        End Property

        Private _postedBy As String = String.Empty
        <CellInfo(GroupName:="Invoice info", Tips:="Enter poster code")>
        Public Property PostedBy() As String
            Get
                Return _postedBy
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PostedBy", True)
                If value Is Nothing Then value = String.Empty
                If Not _postedBy.Equals(value) Then
                    _postedBy = value
                    PropertyHasChanged("PostedBy")
                End If
            End Set
        End Property

        Private _holdOpId As String = String.Empty
        <CellInfo(GroupName:="Invoice info", Tips:="")>
        Public Property HoldOpId() As String
            Get
                Return _holdOpId
            End Get
            Set(ByVal value As String)
                CanWriteProperty("HoldOpId", True)
                If value Is Nothing Then value = String.Empty
                If Not _holdOpId.Equals(value) Then
                    _holdOpId = value
                    PropertyHasChanged("HoldOpId")
                End If
            End Set
        End Property

        Private _bphNo As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        <CellInfo(GroupName:="Input", Tips:="")>
        Public Property BphNo() As String
            Get
                Return _bphNo.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("BphNo", True)
                If value Is Nothing Then value = String.Empty
                If Not _bphNo.Equals(value) Then
                    _bphNo.Text = value
                    PropertyHasChanged("BphNo")
                End If
            End Set
        End Property

        Private _pfdNo As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        <CellInfo(GroupName:="Input", Tips:="")>
        Public Property PfdNo() As String
            Get
                Return _pfdNo.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PfdNo", True)
                If value Is Nothing Then value = String.Empty
                If Not _pfdNo.Equals(value) Then
                    _pfdNo.Text = value
                    PropertyHasChanged("PfdNo")
                End If
            End Set
        End Property

        Private _extDesc1 As String = String.Empty
        <CellInfo(GroupName:="Extended description")>
        Public Property ExtDesc1() As String
            Get
                Return _extDesc1
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtDesc1", True)
                If value Is Nothing Then value = String.Empty
                If Not _extDesc1.Equals(value) Then
                    _extDesc1 = value
                    PropertyHasChanged("ExtDesc1")
                End If
            End Set
        End Property

        Private _extDesc2 As String = String.Empty
        <CellInfo(GroupName:="Extended description")>
        Public Property ExtDesc2() As String
            Get
                Return _extDesc2
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtDesc2", True)
                If value Is Nothing Then value = String.Empty
                If Not _extDesc2.Equals(value) Then
                    _extDesc2 = value
                    PropertyHasChanged("ExtDesc2")
                End If
            End Set
        End Property

        Private _extDesc3 As String = String.Empty
        <CellInfo(GroupName:="Extended description")>
        Public Property ExtDesc3() As String
            Get
                Return _extDesc3
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtDesc3", True)
                If value Is Nothing Then value = String.Empty
                If Not _extDesc3.Equals(value) Then
                    _extDesc3 = value
                    PropertyHasChanged("ExtDesc3")
                End If
            End Set
        End Property

        Private _extDesc4 As String = String.Empty
        <CellInfo(GroupName:="Extended description")>
        Public Property ExtDesc4() As String
            Get
                Return _extDesc4
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtDesc4", True)
                If value Is Nothing Then value = String.Empty
                If Not _extDesc4.Equals(value) Then
                    _extDesc4 = value
                    PropertyHasChanged("ExtDesc4")
                End If
            End Set
        End Property

        Private _extDesc5 As String = String.Empty
        <CellInfo(GroupName:="Extended description")>
        Public Property ExtDesc5() As String
            Get
                Return _extDesc5
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtDesc5", True)
                If value Is Nothing Then value = String.Empty
                If Not _extDesc5.Equals(value) Then
                    _extDesc5 = value
                    PropertyHasChanged("ExtDesc5")
                End If
            End Set
        End Property

        Private _extDate1 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="Extended date")>
        Public Property ExtDate1() As String
            Get
                Return _extDate1.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtDate1", True)
                If value Is Nothing Then value = String.Empty
                If Not _extDate1.Equals(value) Then
                    _extDate1.Text = value
                    PropertyHasChanged("ExtDate1")
                End If
            End Set
        End Property

        Private _extDate2 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="Extended date")>
        Public Property ExtDate2() As String
            Get
                Return _extDate2.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtDate2", True)
                If value Is Nothing Then value = String.Empty
                If Not _extDate2.Equals(value) Then
                    _extDate2.Text = value
                    PropertyHasChanged("ExtDate2")
                End If
            End Set
        End Property

        Private _extDate3 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="Extended date")>
        Public Property ExtDate3() As String
            Get
                Return _extDate3.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtDate3", True)
                If value Is Nothing Then value = String.Empty
                If Not _extDate3.Equals(value) Then
                    _extDate3.Text = value
                    PropertyHasChanged("ExtDate3")
                End If
            End Set
        End Property

        Private _extDate4 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="Extended date")>
        Public Property ExtDate4() As String
            Get
                Return _extDate4.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtDate4", True)
                If value Is Nothing Then value = String.Empty
                If Not _extDate4.Equals(value) Then
                    _extDate4.Text = value
                    PropertyHasChanged("ExtDate4")
                End If
            End Set
        End Property

        Private _extDate5 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="Extended date")>
        Public Property ExtDate5() As String
            Get
                Return _extDate5.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtDate5", True)
                If value Is Nothing Then value = String.Empty
                If Not _extDate5.Equals(value) Then
                    _extDate5.Text = value
                    PropertyHasChanged("ExtDate5")
                End If
            End Set
        End Property

        Private _extVal1 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Extended value")>
        Public Property ExtVal1() As String
            Get
                Return _extVal1.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtVal1", True)
                If value Is Nothing Then value = String.Empty
                If Not _extVal1.Equals(value) Then
                    _extVal1.Text = value
                    PropertyHasChanged("ExtVal1")
                End If
            End Set
        End Property

        Private _extVal2 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Extended value")>
        Public Property ExtVal2() As String
            Get
                Return _extVal2.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtVal2", True)
                If value Is Nothing Then value = String.Empty
                If Not _extVal2.Equals(value) Then
                    _extVal2.Text = value
                    PropertyHasChanged("ExtVal2")
                End If
            End Set
        End Property

        Private _extVal3 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Extended value")>
        Public Property ExtVal3() As String
            Get
                Return _extVal3.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtVal3", True)
                If value Is Nothing Then value = String.Empty
                If Not _extVal3.Equals(value) Then
                    _extVal3.Text = value
                    PropertyHasChanged("ExtVal3")
                End If
            End Set
        End Property

        Private _extVal4 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Extended value")>
        Public Property ExtVal4() As String
            Get
                Return _extVal4.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtVal4", True)
                If value Is Nothing Then value = String.Empty
                If Not _extVal4.Equals(value) Then
                    _extVal4.Text = value
                    PropertyHasChanged("ExtVal4")
                End If
            End Set
        End Property

        Private _extVal5 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Extended value")>
        Public Property ExtVal5() As String
            Get
                Return _extVal5.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtVal5", True)
                If value Is Nothing Then value = String.Empty
                If Not _extVal5.Equals(value) Then
                    _extVal5.Text = value
                    PropertyHasChanged("ExtVal5")
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

        Private _updateBy As String = String.Empty
        <CellInfo(GroupName:="System")>
        Public Property UpdateBy() As String
            Get
                Return _updateBy
            End Get
            Set(ByVal value As String)
                CanWriteProperty("UpdateBy", True)
                If value Is Nothing Then value = String.Empty
                If Not _updateBy.Equals(value) Then
                    _updateBy = value
                    PropertyHasChanged("UpdateBy")
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

            For Each _field As ClassField In ClassSchema(Of RECEIVABLES)._fieldList
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

        Public Shared Function BlankRECEIVABLES() As RECEIVABLES
            Return New RECEIVABLES
        End Function

        Public Shared Function NewRECEIVABLES(ByVal pLineNo As String) As RECEIVABLES
            'If KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(String.Format(ResStr(ResStrConst.NOACCESS), ResStr("RECEIVABLES")))
            Return DataPortal.Create(Of RECEIVABLES)(New Criteria(pLineNo))
        End Function

        Public Shared Function NewBO(ByVal ID As String) As RECEIVABLES
            Dim pLineNo As String = ID.Trim

            Return NewRECEIVABLES(pLineNo)
        End Function

        Public Shared Function GetRECEIVABLES(ByVal pLineNo As String) As RECEIVABLES
            Return DataPortal.Fetch(Of RECEIVABLES)(New Criteria(pLineNo))
        End Function

        Public Shared Function GetBO(ByVal ID As String) As RECEIVABLES
            Dim pLineNo As String = ID.Trim

            Return GetRECEIVABLES(pLineNo)
        End Function

        Public Shared Sub DeleteRECEIVABLES(ByVal pLineNo As String)
            DataPortal.Delete(New Criteria(pLineNo))
        End Sub

        Public Overrides Function Save() As RECEIVABLES
            If Not IsDirty Then ExceptionThower.NotDirty(ResStr(ResStrConst.NOTDIRTY))
            If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("RECEIVABLES")))

            Me.ApplyEdit()
            RECEIVABLESInfoList.InvalidateCache()
            Return MyBase.Save()
        End Function

        Public Function CloneRECEIVABLES(ByVal pLineNo As String) As RECEIVABLES

            'If RECEIVABLES.KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(ResStr(ResStrConst.CreateAlreadyExists), Me.GetType.ToString.Leaf.Translate)

            Dim cloningRECEIVABLES As RECEIVABLES = MyBase.Clone
            cloningRECEIVABLES._lineNo = pLineNo

            'Todo:Remember to reset status of the new object here 
            cloningRECEIVABLES.MarkNew()
            cloningRECEIVABLES.ApplyEdit()

            cloningRECEIVABLES.ValidationRules.CheckRules()

            Return cloningRECEIVABLES
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
                    cm.CommandText = <SqlText>SELECT * FROM pbs_MC_RECEIVABLES_DEM WHERE DTB='<%= _DTB %>'  AND LINE_NO= '<%= criteria._lineNo %>' </SqlText>.Value.Trim

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
            _transactionType = dr.GetString("TRANSFER_TYPE").TrimEnd
            _reference = dr.GetString("REFERENCE").TrimEnd
            _transDate.Text = dr.GetInt32("TRANS_DATE")
            _period.Text = dr.GetInt32("PERIOD")
            _candidateId.Text = dr.GetInt32("CANDIDATE_ID")
            _patientCode = dr.GetString("PATIENT_CODE").TrimEnd
            _clinic = dr.GetString("CLINIC").TrimEnd
            _itemCode = dr.GetString("ITEM_CODE").TrimEnd
            _descriptn = dr.GetString("DESCRIPTION").TrimEnd
            _quantity.Text = dr.GetDecimal("QUANTITY")
            _unitCode = dr.GetString("UNIT_CODE").TrimEnd
            _unitPrice.Text = dr.GetDecimal("UNIT_PRICE")
            _transAmt.Text = dr.GetDecimal("TRANS_AMT")
            _convCode = dr.GetString("CONV_CODE").TrimEnd
            _convRate.Text = dr.GetDecimal("CONV_RATE")
            _amount.Text = dr.GetDecimal("AMOUNT")
            _dC = dr.GetString("D_C").TrimEnd
            _paymentRef = dr.GetString("PAYMENT_REF").TrimEnd
            _payMethod = dr.GetString("PAY_METHOD").TrimEnd
            _paymentDate.Text = dr.GetInt32("PAYMENT_DATE")
            _paymentPeriod.Text = dr.GetInt32("PAYMENT_PERIOD")
            _directInvoice = dr.GetString("DIRECT_INVOICE").TrimEnd
            _invoiceInfo = dr.GetString("INVOICE_INFO").TrimEnd
            _invoiceNo = dr.GetString("INVOICE_NO").TrimEnd
            _invoiceSerial = dr.GetString("INVOICE_SERIAL").TrimEnd
            _invoiceBook = dr.GetString("INVOICE_BOOK").TrimEnd
            _invoiceDate.Text = dr.GetInt32("INVOICE_DATE")
            _invoicePeriod.Text = dr.GetInt32("INVOICE_PERIOD")
            _vatRate = dr.GetString("VAT_RATE").TrimEnd
            _vatAmount.Text = dr.GetDecimal("VAT_AMOUNT")
            _ncPl0 = dr.GetString("NC_PL0").TrimEnd
            _ncPl1 = dr.GetString("NC_PL1").TrimEnd
            _ncPl2 = dr.GetString("NC_PL2").TrimEnd
            _ncPl3 = dr.GetString("NC_PL3").TrimEnd
            _ncPl4 = dr.GetString("NC_PL4").TrimEnd
            _ncPl5 = dr.GetString("NC_PL5").TrimEnd
            _ncPl6 = dr.GetString("NC_PL6").TrimEnd
            _ncPl7 = dr.GetString("NC_PL7").TrimEnd
            _ncPl8 = dr.GetString("NC_PL8").TrimEnd
            _ncPl9 = dr.GetString("NC_PL9").TrimEnd
            _allocation = dr.GetString("ALLOCATION").TrimEnd
            _allocRef.Text = dr.GetInt32("ALLOC_REF")
            _allocDate.Text = dr.GetInt32("ALLOC_DATE")
            _allocPeriod.Text = dr.GetInt32("ALLOC_PERIOD")
            _status = dr.GetString("STATUS").TrimEnd
            _lockFlag = dr.GetString("LOCK_FLAG").TrimEnd
            _postingDate.Text = dr.GetInt32("POSTING_DATE")
            _postedBy = dr.GetString("POSTED_BY").TrimEnd
            _holdOpId = dr.GetString("HOLD_OP_ID").TrimEnd
            _bphNo.Text = dr.GetInt32("BPH_NO")
            _pfdNo.Text = dr.GetInt32("PFD_NO")
            _extDesc1 = dr.GetString("EXT_DESC1").TrimEnd
            _extDesc2 = dr.GetString("EXT_DESC2").TrimEnd
            _extDesc3 = dr.GetString("EXT_DESC3").TrimEnd
            _extDesc4 = dr.GetString("EXT_DESC4").TrimEnd
            _extDesc5 = dr.GetString("EXT_DESC5").TrimEnd
            _extDate1.Text = dr.GetInt32("EXT_DATE1")
            _extDate2.Text = dr.GetInt32("EXT_DATE2")
            _extDate3.Text = dr.GetInt32("EXT_DATE3")
            _extDate4.Text = dr.GetInt32("EXT_DATE4")
            _extDate5.Text = dr.GetInt32("EXT_DATE5")
            _extVal1.Text = dr.GetDecimal("EXT_VAL1")
            _extVal2.Text = dr.GetDecimal("EXT_VAL2")
            _extVal3.Text = dr.GetDecimal("EXT_VAL3")
            _extVal4.Text = dr.GetDecimal("EXT_VAL4")
            _extVal5.Text = dr.GetDecimal("EXT_VAL5")
            _updated.Text = dr.GetInt32("UPDATED")
            _updateBy = dr.GetString("UPDATE_BY").TrimEnd

        End Sub

        Private Shared _lockObj As New Object
        Protected Overrides Sub DataPortal_Insert()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    Using cm = ctx.Connection.CreateCommand()

                        cm.CommandType = CommandType.StoredProcedure
                        cm.CommandText = String.Format("pbs_MC_RECEIVABLES_{0}_InsertUpdate", _DTB)

                        cm.Parameters.AddWithValue("@LINE_NO", _lineNo.Trim.ToInteger).Direction = ParameterDirection.Output
                        AddInsertParameters(cm)
                        cm.ExecuteNonQuery()

                        _lineNo = CInt(cm.Parameters("@LINE_NO").Value)
                    End Using
                End Using
            End SyncLock
        End Sub

        Private Sub AddInsertParameters(ByVal cm As SqlCommand)

            cm.Parameters.AddWithValue("@TRANSFER_TYPE", _transactionType.Trim)
            cm.Parameters.AddWithValue("@REFERENCE", _reference.Trim)
            cm.Parameters.AddWithValue("@TRANS_DATE", _transDate.DBValue)
            cm.Parameters.AddWithValue("@PERIOD", _period.DBValue)
            cm.Parameters.AddWithValue("@CANDIDATE_ID", _candidateId.DBValue)
            cm.Parameters.AddWithValue("@PATIENT_CODE", _patientCode.Trim)
            cm.Parameters.AddWithValue("@CLINIC", _clinic.Trim)
            cm.Parameters.AddWithValue("@ITEM_CODE", _itemCode.Trim)
            cm.Parameters.AddWithValue("@DESCRIPTION", _descriptn.Trim)
            cm.Parameters.AddWithValue("@QUANTITY", _quantity.DBValue)
            cm.Parameters.AddWithValue("@UNIT_CODE", _unitCode.Trim)
            cm.Parameters.AddWithValue("@UNIT_PRICE", _unitPrice.DBValue)
            cm.Parameters.AddWithValue("@TRANS_AMT", _transAmt.DBValue)
            cm.Parameters.AddWithValue("@CONV_CODE", _convCode.Trim)
            cm.Parameters.AddWithValue("@CONV_RATE", _convRate.DBValue)
            cm.Parameters.AddWithValue("@AMOUNT", _amount.DBValue)
            cm.Parameters.AddWithValue("@D_C", _dC.Trim)
            cm.Parameters.AddWithValue("@PAYMENT_REF", _paymentRef.Trim)
            cm.Parameters.AddWithValue("@PAY_METHOD", _payMethod.Trim)
            cm.Parameters.AddWithValue("@PAYMENT_DATE", _paymentDate.DBValue)
            cm.Parameters.AddWithValue("@PAYMENT_PERIOD", _paymentPeriod.DBValue)
            cm.Parameters.AddWithValue("@DIRECT_INVOICE", _directInvoice.Trim)
            cm.Parameters.AddWithValue("@INVOICE_INFO", _invoiceInfo.Trim)
            cm.Parameters.AddWithValue("@INVOICE_NO", _invoiceNo.Trim)
            cm.Parameters.AddWithValue("@INVOICE_SERIAL", _invoiceSerial.Trim)
            cm.Parameters.AddWithValue("@INVOICE_BOOK", _invoiceBook.Trim)
            cm.Parameters.AddWithValue("@INVOICE_DATE", _invoiceDate.DBValue)
            cm.Parameters.AddWithValue("@INVOICE_PERIOD", _invoicePeriod.DBValue)
            cm.Parameters.AddWithValue("@VAT_RATE", _vatRate.Trim)
            cm.Parameters.AddWithValue("@VAT_AMOUNT", _vatAmount.DBValue)
            cm.Parameters.AddWithValue("@NC_PL0", _ncPl0.Trim)
            cm.Parameters.AddWithValue("@NC_PL1", _ncPl1.Trim)
            cm.Parameters.AddWithValue("@NC_PL2", _ncPl2.Trim)
            cm.Parameters.AddWithValue("@NC_PL3", _ncPl3.Trim)
            cm.Parameters.AddWithValue("@NC_PL4", _ncPl4.Trim)
            cm.Parameters.AddWithValue("@NC_PL5", _ncPl5.Trim)
            cm.Parameters.AddWithValue("@NC_PL6", _ncPl6.Trim)
            cm.Parameters.AddWithValue("@NC_PL7", _ncPl7.Trim)
            cm.Parameters.AddWithValue("@NC_PL8", _ncPl8.Trim)
            cm.Parameters.AddWithValue("@NC_PL9", _ncPl9.Trim)
            cm.Parameters.AddWithValue("@ALLOCATION", _allocation.Trim)
            cm.Parameters.AddWithValue("@ALLOC_REF", _allocRef.DBValue)
            cm.Parameters.AddWithValue("@ALLOC_DATE", _allocDate.DBValue)
            cm.Parameters.AddWithValue("@ALLOC_PERIOD", _allocPeriod.DBValue)
            cm.Parameters.AddWithValue("@STATUS", _status.Trim)
            cm.Parameters.AddWithValue("@LOCK_FLAG", _lockFlag.Trim)
            cm.Parameters.AddWithValue("@POSTING_DATE", _postingDate.DBValue)
            cm.Parameters.AddWithValue("@POSTED_BY", _postedBy.Trim)
            cm.Parameters.AddWithValue("@HOLD_OP_ID", _holdOpId.Trim)
            cm.Parameters.AddWithValue("@BPH_NO", _bphNo.DBValue)
            cm.Parameters.AddWithValue("@PFD_NO", _pfdNo.DBValue)
            cm.Parameters.AddWithValue("@EXT_DESC1", _extDesc1.Trim)
            cm.Parameters.AddWithValue("@EXT_DESC2", _extDesc2.Trim)
            cm.Parameters.AddWithValue("@EXT_DESC3", _extDesc3.Trim)
            cm.Parameters.AddWithValue("@EXT_DESC4", _extDesc4.Trim)
            cm.Parameters.AddWithValue("@EXT_DESC5", _extDesc5.Trim)
            cm.Parameters.AddWithValue("@EXT_DATE1", _extDate1.DBValue)
            cm.Parameters.AddWithValue("@EXT_DATE2", _extDate2.DBValue)
            cm.Parameters.AddWithValue("@EXT_DATE3", _extDate3.DBValue)
            cm.Parameters.AddWithValue("@EXT_DATE4", _extDate4.DBValue)
            cm.Parameters.AddWithValue("@EXT_DATE5", _extDate5.DBValue)
            cm.Parameters.AddWithValue("@EXT_VAL1", _extVal1.DBValue)
            cm.Parameters.AddWithValue("@EXT_VAL2", _extVal2.DBValue)
            cm.Parameters.AddWithValue("@EXT_VAL3", _extVal3.DBValue)
            cm.Parameters.AddWithValue("@EXT_VAL4", _extVal4.DBValue)
            cm.Parameters.AddWithValue("@EXT_VAL5", _extVal5.DBValue)
            cm.Parameters.AddWithValue("@UPDATED", _updated.DBValue)
            cm.Parameters.AddWithValue("@UPDATE_BY", _updateBy.Trim)
        End Sub


        Protected Overrides Sub DataPortal_Update()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    Using cm = ctx.Connection.CreateCommand()

                        cm.CommandType = CommandType.StoredProcedure
                        cm.CommandText = String.Format("pbs_MC_RECEIVABLES_{0}_Update", _DTB)

                        cm.Parameters.AddWithValue("@LINE_NO", _lineNo.Trim)
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
                    cm.CommandText = <SqlText>DELETE pbs_MC_RECEIVABLES_DEM WHERE DTB='<%= _DTB %>'  AND LINE_NO= '<%= criteria._lineNo %>' </SqlText>.Value.Trim
                    cm.ExecuteNonQuery()

                End Using
            End Using

        End Sub

        Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(ByVal e As Csla.DataPortalEventArgs)
            If Csla.ApplicationContext.ExecutionLocation = ExecutionLocations.Server Then
                RECEIVABLESInfoList.InvalidateCache()
            End If
        End Sub


#End Region 'Data Access                           

#Region " Exists "
        Public Shared Function Exists(ByVal pLineNo As String) As Boolean
            Return RECEIVABLESInfoList.ContainsCode(pLineNo)
        End Function

        'Public Shared Function KeyDuplicated(ByVal pLineNo As String) As Boolean
        '    Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_MC_RECEIVABLES_DEM WHERE DTB='<%= Context.CurrentBECode %>'  AND LINE_NO= '<%= pLineNo %>'</SqlText>.Value.Trim
        '    Return SQLCommander.GetScalarInteger(SqlText) > 0
        'End Function
#End Region

#Region " IGenpart "

        Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
            Return CloneRECEIVABLES(id)
        End Function

        Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
            Return GetBO(id)
        End Function

        Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
            Return pbs.Helper.Action.StandardReferenceCommands
        End Function

        Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
            Return GetType(RECEIVABLES).ToString
        End Function

        Public Function myName() As String Implements Interfaces.IGenPartObject.myName
            Return GetType(RECEIVABLES).ToString.Leaf
        End Function

        Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
            Return RECEIVABLESInfoList.GetRECEIVABLESInfoList
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