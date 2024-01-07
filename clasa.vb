Public Class clasa
    Public Property it As New List(Of String)
    Public Property value As Double
    Public Property hasDelta As Boolean = False
    Public Sub subk4()
        it.Add("IT4")
        it.Add("IT5")
        it.Add("IT6")
        it.Add("IT7")
    End Sub
    Public Sub subkf4()
        it.Add("IT01")
        it.Add("IT0")
        it.Add("IT1")
        it.Add("IT2")
        it.Add("IT3")

        For i As Integer = 8 To 18
            it.Add("IT" & i)
        Next
    End Sub
    Public Sub it_all()
        it.Add("IT01")
        For i As Integer = 0 To 18
            it.Add("IT" & i)
        Next

    End Sub
    Public Sub sub8()
        it.Add("IT01")
        For i As Integer = 0 To 8
            it.Add("IT" & i)
        Next
    End Sub
    Public Sub peste8()
        For i As Integer = 9 To 18
            it.Add("IT" & i)
        Next
    End Sub
End Class
