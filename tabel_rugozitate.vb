Public Class tabel_rugozitate
    Public date_valori As New List(Of rugozitate)
    Public nume_fereastra As String

    Private Sub tabel_rugozitate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = nume_fereastra
        For i As Integer = 1 To 6
            DataGridView1.Columns.Add("", "")
        Next

        DataGridView1.Rows.Add("ISO", "STAS", "Ra", "Rz", "Ry", "l")

        For Each obj As rugozitate In date_valori
            DataGridView1.Rows.Add(obj.ISO, obj.STAS, obj.Ra, obj.Rz, obj.Ry, obj.l)
        Next
        DataGridView1.ColumnHeadersVisible = False


        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.Size = New Size(DataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 100,
                                      DataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + DataGridView1.ColumnHeadersHeight + 10)

        Me.Size = New Size(DataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 100,
                                      DataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + DataGridView1.ColumnHeadersHeight + 50)

    End Sub
End Class