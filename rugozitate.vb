Public Class rugozitate

    Public Property ISO As String
    Public Property STAS As String
    Public Property Ra As Double
    Public Property Rz As Double
    Public Property Ry As Double
    Public Property l As Double

    Public Sub New(ISO As String, STAS As String, Ra As Double, Rz As Double, Ry As Double, l As Double)
        Me.ISO = ISO
        Me.STAS = STAS
        Me.Ra = Ra
        Me.Rz = Rz
        Me.Ry = Ry
        Me.l = l

    End Sub

End Class
