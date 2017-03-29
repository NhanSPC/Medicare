
Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports System.Data
Imports Csla
Imports Csla.Data
Imports Csla.Validation

Namespace HR

    <Serializable()> _
    Public Class CMPNTInfo
        Inherits Csla.ReadOnlyBase(Of CMPNTInfo)
        Implements IComparable
        Implements IInfo
        Implements IDocLink
        'Implements IInfoStatus


#Region " Business Properties and Methods "


        Private _lineNo As String = String.Empty
        Public ReadOnly Property LineNo() As String
            Get
                Return _lineNo
            End Get
        End Property

        Private _offerNo As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        Public ReadOnly Property OfferNo() As String
            Get
                Return _offerNo.Text
            End Get
        End Property

        Private _cmpntCode As String = String.Empty
        Public ReadOnly Property CmpntCode() As String
            Get
                Return _cmpntCode
            End Get
        End Property

        Private _effectiveDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property EffectiveDate() As String
            Get
                Return _effectiveDate.Text
            End Get
        End Property

        Private _status As String = String.Empty
        Public ReadOnly Property Status() As String
            Get
                Return _status
            End Get
        End Property

        Private _descriptn As String = String.Empty
        Public ReadOnly Property Descriptn() As String
            Get
                Return _descriptn
            End Get
        End Property

        Private _offerType As String = String.Empty
        Public ReadOnly Property OfferType() As String
            Get
                Return _offerType
            End Get
        End Property

        Private _frequency As String = String.Empty
        Public ReadOnly Property Frequency() As String
            Get
                Return _frequency
            End Get
        End Property

        Private _currencyCode As String = String.Empty
        Public ReadOnly Property CurrencyCode() As String
            Get
                Return _currencyCode
            End Get
        End Property

        Private _cash As String = String.Empty
        Public ReadOnly Property Cash() As Boolean
            Get
                Return _cash.ToBoolean
            End Get
        End Property

        Private _amount As pbs.Helper.SmartFloat = New SmartFloat(0)
        Public ReadOnly Property Amount() As String
            Get
                Return _amount.Text
            End Get
        End Property

        Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property Updated() As String
            Get
                Return _updated.Text
            End Get
        End Property

        Private _updatedBy As String = String.Empty
        Public ReadOnly Property UpdatedBy() As String
            Get
                Return _updatedBy
            End Get
        End Property

        'Get ID
        Protected Overrides Function GetIdValue() As Object
            Return _lineNo
        End Function

        'IComparable
        Public Function CompareTo(ByVal IDObject) As Integer Implements System.IComparable.CompareTo
            Dim ID = IDObject.ToString
            Dim pLineNo As String = id.Trim
            If _lineNo < pLineNo Then Return -1
            If _lineNo > pLineNo Then Return 1
            Return 0
        End Function

        Public ReadOnly Property Code As String Implements IInfo.Code
            Get
                Return _lineNo
            End Get
        End Property

        Public ReadOnly Property LookUp As String Implements IInfo.LookUp
            Get
                Return _lineNo
            End Get
        End Property

        Public ReadOnly Property Description As String Implements IInfo.Description
            Get
                Return _descriptn
            End Get
        End Property


        Public Sub InvalidateCache() Implements IInfo.InvalidateCache
            CMPNTInfoList.InvalidateCache()
        End Sub


#End Region 'Business Properties and Methods

#Region " Factory Methods "

        Friend Shared Function GetCMPNTInfo(ByVal dr As SafeDataReader) As CMPNTInfo
            Return New CMPNTInfo(dr)
        End Function

        Friend Shared Function EmptyCMPNTInfo(Optional ByVal pLineNo As String = "") As CMPNTInfo
            Dim info As CMPNTInfo = New CMPNTInfo
            With info
                ._lineNo = pLineNo

            End With
            Return info
        End Function

        Private Sub New(ByVal dr As SafeDataReader)
            _lineNo = dr.GetInt32("LINE_NO")
            _offerNo.Text = dr.GetInt32("OFFER_NO")
            _cmpntCode = dr.GetString("CMPNT_CODE").TrimEnd
            _effectiveDate.Text = dr.GetInt32("EFFECTIVE_DATE")
            _status = dr.GetString("STATUS").TrimEnd
            _descriptn = dr.GetString("DESCRIPTION").TrimEnd
            _offerType = dr.GetString("OFFER_TYPE").TrimEnd
            _frequency = dr.GetString("FREQUENCY").TrimEnd
            _currencyCode = dr.GetString("CURRENCY_CODE").TrimEnd
            _cash = dr.GetString("CASH").TrimEnd
            _amount.Text = dr.GetDecimal("AMOUNT")
            _updated.Text = dr.GetInt32("UPDATED")
            _updatedBy = dr.GetString("UPDATED_BY").TrimEnd

        End Sub

        Private Sub New()
        End Sub


#End Region ' Factory Methods

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