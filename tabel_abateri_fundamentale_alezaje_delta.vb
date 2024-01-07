Imports Microsoft.VisualBasic.FileIO
Imports System.Globalization

Public Class tabel_abateri_fundamentale_alezaje_delta
    Private Sub tabel_abateri_fundamentale_alezaje_delta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim list As New List(Of abateri_fundamentale_alezaje_delta)
        readDataDelta("tabel311_delta.csv", list)

        For i As Integer = 1 To 8
            DataGridView1.Columns.Add("", "")
        Next

        DataGridView1.Rows.Add("Dimensiuni de la", "Pana la", "IT3", "IT4", "IT5", "IT6", "IT7", "IT8")

        For Each obj As abateri_fundamentale_alezaje_delta In list
            DataGridView1.Rows.Add(obj.DimensiuneDeLa, obj.DimensiunePanaLa, obj.IT3, obj.IT4, obj.IT5, obj.IT6, obj.IT7, obj.IT8)

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


    Private Sub readDataDelta(filePath As String, list As List(Of abateri_fundamentale_alezaje_delta))

        Using parser As New TextFieldParser(filePath)
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",")

            parser.ReadLine()
            While Not parser.EndOfData
                Dim fields As String() = parser.ReadFields()

                Dim dimensiuneDeLa As Double = If(fields(0) = "-", 0, If(Double.TryParse(fields(0), CultureInfo.InvariantCulture, dimensiuneDeLa), dimensiuneDeLa, 0))
                Dim dimensiunePanaLa As Double = If(fields(1) = "-", 0, If(Double.TryParse(fields(1), CultureInfo.InvariantCulture, dimensiunePanaLa), dimensiunePanaLa, 0))
                Dim IT3 As Double = If(fields(2) = "-", 0, If(Double.TryParse(fields(2), CultureInfo.InvariantCulture, IT3), IT3, 0))
                Dim IT4 As Double = If(fields(3) = "-", 0, If(Double.TryParse(fields(3), CultureInfo.InvariantCulture, IT4), IT4, 0))
                Dim IT5 As Double = If(fields(4) = "-", 0, If(Double.TryParse(fields(4), CultureInfo.InvariantCulture, IT5), IT5, 0))
                Dim IT6 As Double = If(fields(5) = "-", 0, If(Double.TryParse(fields(5), CultureInfo.InvariantCulture, IT6), IT6, 0))
                Dim IT7 As Double = If(fields(5) = "-", 0, If(Double.TryParse(fields(5), CultureInfo.InvariantCulture, IT7), IT7, 0))
                Dim IT8 As Double = If(fields(5) = "-", 0, If(Double.TryParse(fields(5), CultureInfo.InvariantCulture, IT8), IT8, 0))

                Dim newObj As New abateri_fundamentale_alezaje_delta(dimensiuneDeLa, dimensiunePanaLa, IT3, IT4, IT5, IT6, IT7, IT8)
                list.Add(newObj)
            End While
        End Using
    End Sub

End Class