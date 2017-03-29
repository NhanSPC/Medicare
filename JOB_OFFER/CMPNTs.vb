Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports pbs.Helper

Namespace HR

    <Serializable()> _
    Public Class CMPNTs
        Inherits Csla.BusinessListBase(Of CMPNTs, CMPNT)

#Region " Business Methods"
        Friend _parent As OFFTYPE = Nothing

        Protected Overrides Function AddNewCore() As Object
            If _parent IsNot Nothing Then
                Dim theNewLine = CMPNT.NewCMPNT(_parent.LineNo.ToString)
                AddNewLine(theNewLine)
                theNewLine.CheckRules()
                Return theNewLine
            Else
                Return MyBase.AddNewCore
            End If
        End Function

        Friend Sub AddNewLine(ByVal pline As CMPNT)
            If pline Is Nothing Then Exit Sub

            'get the next line number
            Dim nextnumber As Integer = 1
            If Me.Count > 0 Then
                Dim allNumbers = (From line In Me Select line.LineNo).ToList
                nextnumber = allNumbers.Max + 1
            End If

            '_line.{LINE_NO} = String.Format("{0:00000}", nextnumber)
            pline._lineNo = nextnumber

            'Populate _line with info from parent here
            Me.Add(pline)

        End Sub

#End Region
#Region " Factory Methods "

        Friend Shared Function NewCMPNTs(ByVal pParent As OFFTYPE) As CMPNTs
            Return New CMPNTs(pParent)
        End Function

        Friend Shared Function GetCMPNTs(ByVal dr As SafeDataReader, ByVal parent As OFFTYPE) As CMPNTs
            Dim ret = New CMPNTs(dr, parent)
            ret.MarkAsChild()
            Return ret
        End Function

        Private Sub New(ByVal parent As OFFTYPE)
            _parent = parent
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As SafeDataReader, ByVal parent As OFFTYPE)
            _parent = parent
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region ' Factory Methods
#Region " Data Access "

        Private Sub Fetch(ByVal dr As SafeDataReader)
            RaiseListChangedEvents = False

            'Dim suppressChildValidation = True
            While dr.Read()
                Dim Line = CMPNT.GetChildCMPNT(dr)
                Me.Add(Line)
            End While

            RaiseListChangedEvents = True
        End Sub

        Friend Sub Update(ByVal cn As SqlConnection, ByVal parent As OFFTYPE)
            RaiseListChangedEvents = False

            ' loop through each deleted child object
            For Each deletedChild As CMPNT In DeletedList
                deletedChild._DTB = parent._DTB
                deletedChild.DeleteSelf(cn)
            Next
            DeletedList.Clear()

            ' loop through each non-deleted child object
            For Each child As CMPNT In Me
                child._DTB = parent._DTB
                child.OfferNo = parent.LineNo
                'child.OrderNo = parent.OrderNo
                If child.IsNew Then
                    child.Insert(cn)
                Else
                    child.Update(cn)
                End If
            Next

            RaiseListChangedEvents = True
        End Sub

#End Region ' Data Access                   
    End Class

End Namespace