Imports Microsoft.VisualBasic.FileIO

Public Class tabel_abateri_fundamentale_alezaje
    Private Sub tabel_abateri_fundamentale_alezaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim list As New List(Of abateri_fundamentale_alezaje)

        readDataAbateriFundamentaleAlezaje("tabel311.csv", list)
    End Sub








    Private Sub readDataAbateriFundamentaleAlezaje(filePath As String, list As List(Of abateri_fundamentale_alezaje))

        Using parser As New TextFieldParser(filePath)
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",")

            parser.ReadLine()
            parser.ReadLine()
            parser.ReadLine()

            While Not parser.EndOfData
                Dim fields As String() = parser.ReadFields()
                Dim dimensiuneDeLa As Double = If(fields(0) = "-", 0, If(Double.TryParse(fields(0), dimensiuneDeLa), dimensiuneDeLa, 0))
                Dim dimensiunePanaLa As Double = If(fields(1) = "-", 0, If(Double.TryParse(fields(1), dimensiunePanaLa), dimensiunePanaLa, 0))
                Dim a_citit As clasa
                ReadClasaFieldValue(a_citit, fields(1))



                'Dim newObj As New abateri_fundamentale_arbori(dimensiuneDeLa, dimensiunePanaLa, a_citit, b_citit, c_citit, cd_citit, d_citit, e_citit, ef_citit, f_citit, fg_citit, g_citit, h_citit, js_citit, j56_citit, j7_citit, j8_citit, k4567_citit, kfara4567_citit, m_citit, n_citit, p_citit, r_citit, s_citit, t_citit, u_citit, v_citit, x_citit, y_citit, z_citit, za_citit, zb_citit, zc_citit)
                'newObj.load()
                ' list.Add(newObj)
            End While
        End Using
    End Sub

    Private Sub ReadClasaFieldValue(obj As clasa, fields As String)
        Dim field As String = fields
        If field.ToLower().Contains("+delta") Then
            obj.hasDelta = True
            field = field.Replace("+delta", "")
        Else
            obj.value = If(fields = "-", 0, If(Double.TryParse(fields, obj.value), obj.value, 0))
        End If



    End Sub


End Class