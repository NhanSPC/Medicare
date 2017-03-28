Imports pbs.Helper.Interfaces
Imports pbs.BO
Imports pbs.Helper


Namespace MC
    Public Class SplitName
        Implements IRunable

        Public ReadOnly Property Notes As String Implements IRunable.Notes
            Get
                Return <syntax>
                            This function use to split name in Appointment form to patient
                       </syntax>
            End Get
        End Property

        Public Sub Run(args As pbsCmdArgs) Implements IRunable.Run

        End Sub
    End Class
End Namespace