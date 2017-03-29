
Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports System.Data
Imports Csla
Imports Csla.Data
Imports Csla.Validation

Namespace HR

    <Serializable()> _
    Public Class OFFTYPEInfo
        Inherits Csla.ReadOnlyBase(Of OFFTYPEInfo)
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

        Private _candidateId As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property CandidateId() As String
            Get
                Return _candidateId.Text
            End Get
        End Property

        Private _offerType As String = String.Empty
        Public ReadOnly Property OfferType() As String
            Get
                Return _offerType
            End Get
        End Property

        Private _effectiveDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property EffectiveDate() As String
            Get
                Return _effectiveDate.Text
            End Get
        End Property

        Private _issueDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property IssueDate() As String
            Get
                Return _issueDate.Text
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

        Private _position As String = String.Empty
        Public ReadOnly Property Position() As String
            Get
                Return _position
            End Get
        End Property

        Private _workingLocation As String = String.Empty
        Public ReadOnly Property WorkingLocation() As String
            Get
                Return _workingLocation
            End Get
        End Property

        Private _extdesc5 As String = String.Empty
        Public ReadOnly Property Extdesc5() As String
            Get
                Return _extdesc5
            End Get
        End Property

        Private _extdesc4 As String = String.Empty
        Public ReadOnly Property Extdesc4() As String
            Get
                Return _extdesc4
            End Get
        End Property

        Private _extdesc3 As String = String.Empty
        Public ReadOnly Property Extdesc3() As String
            Get
                Return _extdesc3
            End Get
        End Property

        Private _extdesc2 As String = String.Empty
        Public ReadOnly Property Extdesc2() As String
            Get
                Return _extdesc2
            End Get
        End Property

        Private _extdesc1 As String = String.Empty
        Public ReadOnly Property Extdesc1() As String
            Get
                Return _extdesc1
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
            OFFTYPEInfoList.InvalidateCache()
        End Sub


#End Region 'Business Properties and Methods

#Region " Factory Methods "

        Friend Shared Function GetOFFTYPEInfo(ByVal dr As SafeDataReader) As OFFTYPEInfo
            Return New OFFTYPEInfo(dr)
        End Function

        Friend Shared Function EmptyOFFTYPEInfo(Optional ByVal pLineNo As String = "") As OFFTYPEInfo
            Dim info As OFFTYPEInfo = New OFFTYPEInfo
            With info
                ._lineNo = pLineNo

            End With
            Return info
        End Function

        Private Sub New(ByVal dr As SafeDataReader)
            _lineNo = dr.GetInt32("LINE_NO")
            _candidateId.Text = dr.GetInt32("CANDIDATE_ID")
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