Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class main_window
    Private Sub main_window_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToleranteFundamentaleLiniareToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToleranteFundamentaleLiniareToolStripMenuItem.Click

        Dim window As New tabel_tolerante_fundamentale_liniare()
        window.Show()
    End Sub

    Private Sub AbaterileLimitaGeneraleLiniareToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbaterileLimitaGeneraleLiniareToolStripMenuItem.Click
        Dim window As New abateri_limita_generale_liniare()
        window.Show()
    End Sub

    Private Sub AbateriFundamentaleArboriToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbateriFundamentaleArboriToolStripMenuItem.Click
        Dim window As New tabel_abateri_fundamentale_arbori()
        window.Show()
    End Sub
End Class