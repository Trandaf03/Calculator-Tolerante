<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class tabel_tolerante_fundamentale_liniare
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        DataGridView1 = New DataGridView()
        MenuStrip1 = New MenuStrip()
        TransformăToolStripMenuItem = New ToolStripMenuItem()
        UnitateDeMăsurăToolStripMenuItem = New ToolStripMenuItem()
        MicrometriiToolStripMenuItem = New ToolStripMenuItem()
        MilimetriiToolStripMenuItem = New ToolStripMenuItem()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(12, 27)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(1184, 592)
        DataGridView1.TabIndex = 0
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {TransformăToolStripMenuItem, UnitateDeMăsurăToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1208, 24)
        MenuStrip1.TabIndex = 1
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' TransformăToolStripMenuItem
        ' 
        TransformăToolStripMenuItem.Name = "TransformăToolStripMenuItem"
        TransformăToolStripMenuItem.Size = New Size(22, 20)
        TransformăToolStripMenuItem.Text = " "
        ' 
        ' UnitateDeMăsurăToolStripMenuItem
        ' 
        UnitateDeMăsurăToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {MicrometriiToolStripMenuItem, MilimetriiToolStripMenuItem})
        UnitateDeMăsurăToolStripMenuItem.Name = "UnitateDeMăsurăToolStripMenuItem"
        UnitateDeMăsurăToolStripMenuItem.Size = New Size(115, 20)
        UnitateDeMăsurăToolStripMenuItem.Text = "Unitate de măsură"
        ' 
        ' MicrometriiToolStripMenuItem
        ' 
        MicrometriiToolStripMenuItem.Name = "MicrometriiToolStripMenuItem"
        MicrometriiToolStripMenuItem.Size = New Size(136, 22)
        MicrometriiToolStripMenuItem.Text = "Micrometrii"
        ' 
        ' MilimetriiToolStripMenuItem
        ' 
        MilimetriiToolStripMenuItem.Name = "MilimetriiToolStripMenuItem"
        MilimetriiToolStripMenuItem.Size = New Size(136, 22)
        MilimetriiToolStripMenuItem.Text = "Milimetrii"
        ' 
        ' tabel_tolerante_fundamentale_liniare
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        ClientSize = New Size(1208, 666)
        Controls.Add(DataGridView1)
        Controls.Add(MenuStrip1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MainMenuStrip = MenuStrip1
        Name = "tabel_tolerante_fundamentale_liniare"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterScreen
        Text = "Valorile toleranțelor fundamentale pentru dimensiuni liniare nominale (micrometrii)"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents TransformăToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnitateDeMăsurăToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MicrometriiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MilimetriiToolStripMenuItem As ToolStripMenuItem

End Class
