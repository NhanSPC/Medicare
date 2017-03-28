Imports pbs.BO
Imports pbs.Helper
Imports pbs.Helper.Interfaces

Namespace MC


    Public Class InstitutionFee
        Implements IRunable


        Public ReadOnly Property Notes As String Implements IRunable.Notes
            Get
                Return <syntax>
                           This function is used to calculate fees of patient.
                           Syntax: pbs.BO.MC.InstitutionFee?FeeType=[FeeType]&amp;CheckinNo=[CheckinNo]
                           FeeType must in list: Exam: khám bệnh. Treatment: Điều trị. Emergency: Cấp cứu. Test: Xét nghiệm. Xray: X-quang, CT scanner, MRI. SupperSonic: Siêu âm, điện tim, điện não.
                   </syntax>
            End Get
        End Property

        Public Sub Run(args As pbsCmdArgs) Implements IRunable.Run
            Dim fee = args.GetValueByKey("FeeStyle", String.Empty)
            Dim checkinNo = args.GetValueByKey("CheckinNo", String.Empty)

            Dim feeMana = FEEMANAGEMENTInfoList.GetFEEMANAGEMENTInfoList

            Select Case fee
                Case "Exam", "Treatment", "Emergency"

                    Dim cin = CHECKINInfoList.GetCHECKINInfo(checkinNo)



                Case "Test", "Xray", "Suppersonic"


                Case "Prescription"

                Case Else

            End Select



        End Sub
    End Class
End Namespace

