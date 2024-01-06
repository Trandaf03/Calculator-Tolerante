Imports Microsoft.VisualBasic.FileIO
Imports System.Globalization

Public Class tabel_tolerante_fundamentale_liniare


    Dim micrometrii As Boolean = True
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objectsList As New List(Of tolerante_fundamentale)
        readDataToleranteGenerale("tabel37.csv", objectsList)

        ' Bind the objectsList to the DataGridView
        DataGridView1.DataSource = objectsList


        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.Size = New Size(DataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 50,
                                      DataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + DataGridView1.ColumnHeadersHeight + 10)

        ' Set window size based on column widths
        Me.Size = New Size(DataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 100,
                                      DataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + DataGridView1.ColumnHeadersHeight + 100)

    End Sub

    Private Sub readDataToleranteGenerale(filePath As String, list As List(Of tolerante_fundamentale))

        Using parser As New TextFieldParser(filePath)
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",")

            parser.ReadLine()

            While Not parser.EndOfData
                Dim fields As String() = parser.ReadFields()
                Dim dimensiuneDeLa As Double = If(fields(0) = "-", 0, If(Double.TryParse(fields(0), dimensiuneDeLa), dimensiuneDeLa, 0))
                Dim dimensiunePanaLa As Double = If(fields(1) = "-", 0, If(Double.TryParse(fields(1), dimensiunePanaLa), dimensiunePanaLa, 0))
                Dim it01 As Double = If(fields(2) = "-", 0, If(Double.TryParse(fields(2), it01), it01, 0))
                Dim it0 As Double = If(fields(3) = "-", 0, If(Double.TryParse(fields(3), it0), it0, 0))
                Dim it1 As Double = If(fields(4) = "-", 0, If(Double.TryParse(fields(4), it1), it1, 0))
                Dim it2 As Double = If(fields(5) = "-", 0, If(Double.TryParse(fields(5), it2), it2, 0))
                Dim it3 As Double = If(fields(6) = "-", 0, If(Double.TryParse(fields(6), it3), it3, 0))
                Dim it4 As Double = If(fields(7) = "-", 0, If(Double.TryParse(fields(7), it4), it4, 0))
                Dim it5 As Double = If(fields(8) = "-", 0, If(Double.TryParse(fields(8), it5), it5, 0))
                Dim it6 As Double = If(fields(9) = "-", 0, If(Double.TryParse(fields(9), it6), it6, 0))
                Dim it7 As Double = If(fields(10) = "-", 0, If(Double.TryParse(fields(10), it7), it7, 0))
                Dim it8 As Double = If(fields(11) = "-", 0, If(Double.TryParse(fields(11), it8), it8, 0))
                Dim it9 As Double = If(fields(12) = "-", 0, If(Double.TryParse(fields(12), it9), it9, 0))
                Dim it10 As Double = If(fields(13) = "-", 0, If(Double.TryParse(fields(13), it10), it10, 0))
                Dim it11 As Double = If(fields(14) = "-", 0, If(Double.TryParse(fields(14), it11), it11, 0))
                Dim it12 As Double = If(fields(15) = "-", 0, If(Double.TryParse(fields(15), it12), it12, 0))
                Dim it13 As Double = If(fields(16) = "-", 0, If(Double.TryParse(fields(16), it13), it13, 0))
                Dim it14 As Double = If(fields(17) = "-", 0, If(Double.TryParse(fields(17), it14), it14, 0))
                Dim it15 As Double = If(fields(18) = "-", 0, If(Double.TryParse(fields(18), it15), it15, 0))
                Dim it16 As Double = If(fields(19) = "-", 0, If(Double.TryParse(fields(19), it16), it16, 0))
                Dim it17 As Double = If(fields(20) = "-", 0, If(Double.TryParse(fields(20), it17), it17, 0))
                Dim it18 As Double = If(fields(21) = "-", 0, If(Double.TryParse(fields(21), it18), it18, 0))

                Dim newObj As New tolerante_fundamentale(dimensiuneDeLa, dimensiunePanaLa, it01, it0, it1, it2, it3, it4, it5, it6, it7, it8, it9, it10, it11, it12, it13, it14, it15, it16, it17, it18)
                list.Add(newObj)
            End While
        End Using
    End Sub

    Private Sub MicrometriiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MicrometriiToolStripMenuItem.Click
        If micrometrii Then
            MessageBox.Show("Valorile sunt deja in micrometrii!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            For rowIndex As Integer = 1 To DataGridView1.Rows.Count - 1
                For colIndex As Integer = 2 To DataGridView1.Columns.Count - 1
                    If IsNumeric(DataGridView1.Rows(rowIndex).Cells(colIndex).Value) Then
                        Dim millimeters As Double = CDbl(DataGridView1.Rows(rowIndex).Cells(colIndex).Value)
                        Dim micrometers As Double = millimeters * 1000
                        DataGridView1.Rows(rowIndex).Cells(colIndex).Value = micrometers.ToString("0.######")
                    End If
                Next
            Next
            micrometrii = True
            Me.Text = "Valorile toleranțelor fundamentale pentru dimensiuni liniare nominale (micrometrii)"
        End If
    End Sub




    Private Sub MilimetriiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MilimetriiToolStripMenuItem.Click
        If micrometrii = False Then
            MessageBox.Show("Valorile sunt deja in milimetrii!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            For rowIndex As Integer = 1 To DataGridView1.Rows.Count - 1
                For colIndex As Integer = 2 To DataGridView1.Columns.Count - 1
                    If IsNumeric(DataGridView1.Rows(rowIndex).Cells(colIndex).Value) Then
                        Dim micrometers As Double = CDbl(DataGridView1.Rows(rowIndex).Cells(colIndex).Value)
                        Dim millimeters As Double = micrometers / 1000
                        DataGridView1.Rows(rowIndex).Cells(colIndex).Value = millimeters.ToString("0.######")
                    End If
                Next
            Next
            micrometrii = False
            Me.Text = "Valorile toleranțelor fundamentale pentru dimensiuni liniare nominale (milimetrii)"
        End If
    End Sub

End Class
