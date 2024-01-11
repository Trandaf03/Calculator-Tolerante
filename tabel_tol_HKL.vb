Public Class tabel_tol_HKL

    Private Shared date_valori As New List(Of tol_HKL)
    Public nume_fereastra As String
    Shared Property valori() As List(Of tol_HKL)
        Get
            Return date_valori
        End Get
        Set
            date_valori = Value
        End Set
    End Property
    Private Sub tabel_tol_HKL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = nume_fereastra
        For i As Integer = 1 To 5
            DataGridView1.Columns.Add("", "")
        Next

        DataGridView1.Rows.Add("Dimensiuni de la", "Pana la", "H", "K", "L")

        For Each obj As tol_HKL In date_valori
            DataGridView1.Rows.Add(obj.DimensiuneDeLa, obj.DimensiunePanaLa, obj.H, obj.K, obj.L)
        Next
        DataGridView1.ColumnHeadersVisible = False


        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.Size = New Size(DataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 100,
                                      DataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + DataGridView1.ColumnHeadersHeight + 10)

        Me.Size = New Size(DataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 100,
                                      DataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + DataGridView1.ColumnHeadersHeight + 50)

    End Sub
End Class