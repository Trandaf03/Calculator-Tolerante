Public Class abateri_limita_generale

    Public Property DimensiuneDeLa As Double
    Public Property DimensiunePanaLa As Double
    Public Property f As Double
    Public Property m As Double
    Public Property c As Double
    Public Property v As Double

    Public Sub New(dimensiuneDeLa As Double, dimensiunePanaLa As Double, it01 As Double, it0 As Double, it1 As Double, it2 As Double)
        Me.DimensiuneDeLa = dimensiuneDeLa
        Me.DimensiunePanaLa = dimensiunePanaLa
        Me.f = it01
        Me.m = it0
        Me.c = it1
        Me.v = it2
    End Sub

End Class
