Public Class tabel_clase_I_XII
    Private Shared date_valori As New List(Of claseI_XII)
    Public nume_fereastra As String
    Shared Property valori() As List(Of claseI_XII)
        Get
            Return date_valori
        End Get
        Set
            date_valori = Value
        End Set
    End Property


    Private Sub tabel_clase_I_XII_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = nume_fereastra
        For i As Integer = 1 To 15
            DataGridView1.Columns.Add("", "")
        Next

        DataGridView1.Rows.Add("Dimensiuni de la", "Pana la", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII")

        For Each obj As claseI_XII In date_valori
            DataGridView1.Rows.Add(obj.DimensiuneDeLa, obj.DimensiunePanaLa, obj.I, obj.II, obj.III, obj.IV, obj.V, obj.VI, obj.VII, obj.VIII, obj.IX, obj.X, obj.XI, obj.XII)

        Next
        DataGridView1.ColumnHeadersVisible = False
        'DataGridView1.DataSource = objectsList_fara_tesitura


        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.Size = New Size(DataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 100,
                                      DataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + DataGridView1.ColumnHeadersHeight + 10)

        ' Set window size based on column widths
        Me.Size = New Size(DataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 100,
                                      DataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + DataGridView1.ColumnHeadersHeight + 50)
    End Sub


End Class