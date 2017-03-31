﻿
Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports System.Data
Imports Csla
Imports Csla.Data
Imports Csla.Validation

Namespace MC

    <Serializable()>
    Public Class LABTESTInfo
        Inherits Csla.ReadOnlyBase(Of LABTESTInfo)
        Implements IComparable
        Implements IInfo
        Implements IDocLink
        'Implements IInfoStatus


#Region " Business Properties and Methods "


        Private _lineNo As Integer
        Public ReadOnly Property LineNo() As Integer
            Get
                Return _lineNo
            End Get
        End Property

        Private _labCode As String = String.Empty
        Public ReadOnly Property LabCode() As String
            Get
                Return _labCode
            End Get
        End Property

        Private _testCode As String = String.Empty
        Public ReadOnly Property TestCode() As String
            Get
                Return _testCode
            End Get
        End Property

        Private _descriptn As String = String.Empty
        Public ReadOnly Property Descriptn() As String
            Get
                Return _descriptn
            End Get
        End Property

        Private _unit As String = String.Empty
        Public ReadOnly Property Unit() As String
            Get
                Return _unit
            End Get
        End Property

        Private _minValue As String = String.Empty
        Public ReadOnly Property MinValue() As String
            Get
                Return _minValue
            End Get
        End Property

        Private _maxValue As String = String.Empty
        Public ReadOnly Property MaxValue() As String
            Get
                Return _maxValue
            End Get
        End Property

        Private _minValueMale As String = String.Empty
        Public ReadOnly Property MinValueMale() As String
            Get
                Return _minValueMale
            End Get
        End Property

        Private _maxValueMale As String = String.Empty
        Public ReadOnly Property MaxValueMale() As String
            Get
                Return _maxValueMale
            End Get
        End Property

        Private _minValueFemale As String = String.Empty
        Public ReadOnly Property MinValueFemale() As String
            Get
                Return _minValueFemale
            End Get
        End Property

        Private _maxValueFemale As String = String.Empty
        Public ReadOnly Property MaxValueFemale() As String
            Get
                Return _maxValueFemale
            End Get
        End Property

        Private _notes As String = String.Empty
        Public ReadOnly Property Notes() As String
            Get
                Return _notes
            End Get
        End Property

        Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property Updated() As String
            Get
                Return _updated.DateViewFormat
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
            Dim pLineNo As Integer = ID.Trim.ToInteger
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
                Return _labCode
            End Get
        End Property

        Public ReadOnly Property Description As String Implements IInfo.Description
            Get
                Return _descriptn
            End Get
        End Property


        Public Sub InvalidateCache() Implements IInfo.InvalidateCache
            LABTESTInfoList.InvalidateCache()
        End Sub


#End Region 'Business Properties and Methods

#Region " Factory Methods "

        Friend Shared Function GetLABTESTInfo(ByVal dr As SafeDataReader) As LABTESTInfo
            Return New LABTESTInfo(dr)
        End Function

        Friend Shared Function EmptyLABTESTInfo(Optional ByVal pLineNo As String = "") As LABTESTInfo
            Dim info As LABTESTInfo = New LABTESTInfo
            With info
                ._lineNo = pLineNo.ToInteger

            End With
            Return info
        End Function

        Private Sub New(ByVal dr As SafeDataReader)
            _lineNo = dr.GetInt32("LINE_NO")
            _labCode = dr.GetString("LAB_CODE").TrimEnd
            _testCode = dr.GetString("TEST_CODE").TrimEnd
            _descriptn = dr.GetString("DESCRIPTN").TrimEnd
            _unit = dr.GetString("UNIT").TrimEnd
            _minValue = dr.GetString("MIN_VALUE").TrimEnd
            _maxValue = dr.GetString("MAX_VALUE").TrimEnd
            _minValueMale = dr.GetString("MIN_VALUE_MALE").TrimEnd
            _maxValueMale = dr.GetString("MAX_VALUE_MALE").TrimEnd
            _minValueFemale = dr.GetString("MIN_VALUE_FEMALE").TrimEnd
            _maxValueFemale = dr.GetString("MAX_VALUE_FEMALE").TrimEnd
            _notes = dr.GetString("NOTES").TrimEnd
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