Imports Microsoft.VisualBasic.FileIO

Public Class tabel_abateri_fundamentale_arbori
    Private Sub tabel_abateri_fundamentale_arbori_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim list As New List(Of abateri_fundamentale_arbori)

        readDataAbateriFundamentaleArbori("tabel310.csv", list)

        ' Bind the objectsList to the DataGridView
        For i As Integer = 0 To 32
            DataGridView1.Columns.Add("", "")
        Next
        DataGridView1.Rows.Add("", "", "es", "es", "es", "es", "es", "es", "es", "es", "es", "es", "es", "ei", "ei", "ei", "ei", "ei", "ei", "ei", "ei", "ei", "ei", "ei", "ei", "ei", "ei", "ei", "ei", "ei", "ei", "ei", "ei")
        DataGridView1.Rows.Add("Dimensiunea", "Nominala", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "IT5,IT6", "IT7", "IT8", "IT4-7", "IT01-3,IT8-18", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn")
        DataGridView1.Rows.Add("De la", "Pana la", "a", "b", "c", "cd", "d", "e", "ef", "f", "fg", "g", "h", "js", "j", "j", "j", "k", "k", "m", "n", "p", "r", "s", "t", "u", "v", "x", "y", "z", "za", "zb", "zc")
        DataGridView1.RowTemplate.Height = 19

        For Each obj As abateri_fundamentale_arbori In list
            Dim aValue As Double = obj.a.value
            Dim bValue As Double = obj.b.value
            Dim cValue As Double = obj.c.value
            Dim cdValue As Double = obj.cd.value
            Dim dValue As Double = obj.d.value
            Dim eValue As Double = obj.e.value
            Dim efValue As Double = obj.ef.value
            Dim fValue As Double = obj.f.value
            Dim fgValue As Double = obj.fg.value
            Dim gValue As Double = obj.g.value
            Dim hValue As Double = obj.h.value
            Dim jsValue As Double = obj.js.value
            Dim j56Value As Double = obj.j56.value
            Dim j7Value As Double = obj.j7.value
            Dim j8Value As Double = obj.j8.value
            Dim k4567Value As Double = obj.k4567.value
            Dim kfara4567Value As Double = obj.kfara4567.value
            Dim mValue As Double = obj.m.value
            Dim nValue As Double = obj.n.value
            Dim pValue As Double = obj.p.value
            Dim rValue As Double = obj.r.value
            Dim sValue As Double = obj.s.value
            Dim tValue As Double = obj.t.value
            Dim uValue As Double = obj.u.value
            Dim vValue As Double = obj.v.value
            Dim xValue As Double = obj.x.value
            Dim yValue As Double = obj.y.value
            Dim zValue As Double = obj.z.value
            Dim zaValue As Double = obj.za.value
            Dim zbValue As Double = obj.zb.value
            Dim zcValue As Double = obj.zc.value

            ' Add a new row to the DataGridView with values from the current object
            DataGridView1.Rows.Add(obj.DimensiuneDeLa, obj.DimensiunePanaLa, aValue, bValue, cValue, cdValue, dValue, eValue, efValue, fValue, fgValue, gValue, hValue, jsValue, j56Value, j7Value, j8Value, k4567Value, kfara4567Value, mValue, nValue, pValue, rValue, sValue, tValue, uValue, vValue, xValue, yValue, zValue, zaValue, zbValue, zcValue)
        Next



        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.Size = New Size(DataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 50,
                                      DataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + DataGridView1.ColumnHeadersHeight + 10)

        ' Set window size based on column widths
        Me.Size = New Size(DataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 100,
                                      DataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + DataGridView1.ColumnHeadersHeight + 100)


    End Sub




    Private Sub readDataAbateriFundamentaleArbori(filePath As String, list As List(Of abateri_fundamentale_arbori))

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
                Dim a_citit As clasa = ReadClasaFieldValue(2, fields)
                Dim b_citit As clasa = ReadClasaFieldValue(3, fields)
                Dim c_citit As clasa = ReadClasaFieldValue(4, fields)
                Dim cd_citit As clasa = ReadClasaFieldValue(5, fields)
                Dim d_citit As clasa = ReadClasaFieldValue(6, fields)
                Dim e_citit As clasa = ReadClasaFieldValue(7, fields)
                Dim ef_citit As clasa = ReadClasaFieldValue(8, fields)
                Dim f_citit As clasa = ReadClasaFieldValue(9, fields)
                Dim fg_citit As clasa = ReadClasaFieldValue(10, fields)
                Dim g_citit As clasa = ReadClasaFieldValue(11, fields)
                Dim h_citit As clasa = ReadClasaFieldValue(12, fields)
                Dim js_citit As clasa = ReadClasaFieldValue(13, fields)
                Dim j56_citit As clasa = ReadClasaFieldValue(14, fields)
                Dim j7_citit As clasa = ReadClasaFieldValue(15, fields)
                Dim j8_citit As clasa = ReadClasaFieldValue(16, fields)
                Dim k4567_citit As clasa = ReadClasaFieldValue(17, fields)
                Dim kfara4567_citit As clasa = ReadClasaFieldValue(18, fields)
                Dim m_citit As clasa = ReadClasaFieldValue(19, fields)
                Dim n_citit As clasa = ReadClasaFieldValue(20, fields)
                Dim p_citit As clasa = ReadClasaFieldValue(21, fields)
                Dim r_citit As clasa = ReadClasaFieldValue(22, fields)
                Dim s_citit As clasa = ReadClasaFieldValue(23, fields)
                Dim t_citit As clasa = ReadClasaFieldValue(24, fields)
                Dim u_citit As clasa = ReadClasaFieldValue(25, fields)
                Dim v_citit As clasa = ReadClasaFieldValue(26, fields)
                Dim x_citit As clasa = ReadClasaFieldValue(27, fields)
                Dim y_citit As clasa = ReadClasaFieldValue(28, fields)
                Dim z_citit As clasa = ReadClasaFieldValue(29, fields)
                Dim za_citit As clasa = ReadClasaFieldValue(30, fields)
                Dim zb_citit As clasa = ReadClasaFieldValue(31, fields)
                Dim zc_citit As clasa = ReadClasaFieldValue(32, fields)


                Dim newObj As New abateri_fundamentale_arbori(dimensiuneDeLa, dimensiunePanaLa, a_citit, b_citit, c_citit, cd_citit, d_citit, e_citit, ef_citit, f_citit, fg_citit, g_citit, h_citit, js_citit, j56_citit, j7_citit, j8_citit, k4567_citit, kfara4567_citit, m_citit, n_citit, p_citit, r_citit, s_citit, t_citit, u_citit, v_citit, x_citit, y_citit, z_citit, za_citit, zb_citit, zc_citit)
                newObj.load()
                list.Add(newObj)
            End While
        End Using
    End Sub

    Private Function ReadClasaFieldValue(fieldIndex As Integer, fields As String()) As clasa
        Dim clasaValue As clasa = New clasa()

        ' Check if the fields array has enough elements
        If fieldIndex >= 0 AndAlso fieldIndex < fields.Length Then
            clasaValue.value = If(fields(fieldIndex) = "-", 0, If(Double.TryParse(fields(fieldIndex), clasaValue.value), clasaValue.value, 0))
        Else
            ' Handle the case where the index is out of bounds
            clasaValue.value = 0
        End If

        Return clasaValue
    End Function



End Class