Imports Microsoft.VisualBasic.FileIO
Imports System.Globalization

Public Class tabel_abateri_limita_generale_liniare


    Dim objectsList_tesitura As New List(Of abateri_limita_generale)
    Dim objectsList_fara_tesitura As New List(Of abateri_limita_generale)
    Private Sub abateri_limita_generale_liniare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        readDataAbateriLimita("tabel39.csv", objectsList_tesitura)
        readDataAbateriLimita("tabel38.csv", objectsList_fara_tesitura)


        DataGridView1.Columns.Add("", "")
        DataGridView1.Columns.Add("", "")
        DataGridView1.Columns.Add("", "")
        DataGridView1.Columns.Add("", "")
        DataGridView1.Columns.Add("", "")
        DataGridView1.Columns.Add("", "")
        DataGridView1.Columns.Add("", "")
        DataGridView1.Rows.Add("Valori pentru abateri cu exceptia tesiturilor", "", "", "", "", "", "")
        DataGridView1.Rows.Add("", "", "", "f", "m", "c", "v")
        DataGridView1.Rows.Add("", "Dimensiuni de la", "Pana la", "Fină", "Mijlocie", "Grosieră", "Grosolană")

        For Each obj As abateri_limita_generale In objectsList_fara_tesitura
            DataGridView1.Rows.Add("", obj.DimensiuneDeLa, obj.DimensiunePanaLa, "±" & obj.f, "±" & obj.m, "±" & obj.c, "±" & obj.v)
        Next


        DataGridView1.Rows.Add("Valori pentru abateri ale tesiturilor", "", "", "", "", "", "")

        For Each obj As abateri_limita_generale In objectsList_tesitura
            DataGridView1.Rows.Add("", obj.DimensiuneDeLa, obj.DimensiunePanaLa, "±" & obj.f, "±" & obj.m, "±" & obj.c, "±" & obj.v)
        Next

        DataGridView1.ColumnHeadersVisible = False
        'DataGridView1.DataSource = objectsList_fara_tesitura


        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.Size = New Size(DataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 50,
                                      DataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + DataGridView1.ColumnHeadersHeight + 10)

        ' Set window size based on column widths
        Me.Size = New Size(DataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 100,
                                      DataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + DataGridView1.ColumnHeadersHeight + 100)

    End Sub





    Private Sub readDataAbateriLimita(filePath As String, list As List(Of abateri_limita_generale))

        Using parser As New TextFieldParser(filePath)
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",")

            parser.ReadLine()
            parser.ReadLine()
            While Not parser.EndOfData
                Dim fields As String() = parser.ReadFields()

                Dim dimensiuneDeLa As Double = If(fields(0) = "-", 0, If(Double.TryParse(fields(0), CultureInfo.InvariantCulture, dimensiuneDeLa), dimensiuneDeLa, 0))
                Dim dimensiunePanaLa As Double = If(fields(1) = "-", 0, If(Double.TryParse(fields(1), CultureInfo.InvariantCulture, dimensiunePanaLa), dimensiunePanaLa, 0))
                Dim f As Double = If(fields(2) = "-", 0, If(Double.TryParse(fields(2), CultureInfo.InvariantCulture, f), f, 0))
                Dim m As Double = If(fields(3) = "-", 0, If(Double.TryParse(fields(3), CultureInfo.InvariantCulture, m), m, 0))
                Dim c As Double = If(fields(4) = "-", 0, If(Double.TryParse(fields(4), CultureInfo.InvariantCulture, c), c, 0))
                Dim v As Double = If(fields(5) = "-", 0, If(Double.TryParse(fields(5), CultureInfo.InvariantCulture, v), v, 0))

                Dim newObj As New abateri_limita_generale(dimensiuneDeLa, dimensiunePanaLa, f, m, c, v)
                list.Add(newObj)
            End While
        End Using
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class