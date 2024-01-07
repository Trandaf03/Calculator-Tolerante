<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main_window
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        MenuStrip1 = New MenuStrip()
        VeziTabeleToolStripMenuItem = New ToolStripMenuItem()
        ToleranteFundamentaleLiniareToolStripMenuItem = New ToolStripMenuItem()
        AbaterileLimitaGeneraleLiniareToolStripMenuItem = New ToolStripMenuItem()
        AbateriFundamentaleArboriToolStripMenuItem = New ToolStripMenuItem()
        ArboriToolStripMenuItem = New ToolStripMenuItem()
        AlezajeToolStripMenuItem = New ToolStripMenuItem()
        DeltaToolStripMenuItem = New ToolStripMenuItem()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {VeziTabeleToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(800, 24)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' VeziTabeleToolStripMenuItem
        ' 
        VeziTabeleToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ToleranteFundamentaleLiniareToolStripMenuItem, AbaterileLimitaGeneraleLiniareToolStripMenuItem, AbateriFundamentaleArboriToolStripMenuItem})
        VeziTabeleToolStripMenuItem.Name = "VeziTabeleToolStripMenuItem"
        VeziTabeleToolStripMenuItem.Size = New Size(74, 20)
        VeziTabeleToolStripMenuItem.Text = "Vezi tabele"
        ' 
        ' ToleranteFundamentaleLiniareToolStripMenuItem
        ' 
        ToleranteFundamentaleLiniareToolStripMenuItem.Name = "ToleranteFundamentaleLiniareToolStripMenuItem"
        ToleranteFundamentaleLiniareToolStripMenuItem.Size = New Size(237, 22)
        ToleranteFundamentaleLiniareToolStripMenuItem.Text = "Tolerante fundamentale liniare"
        ' 
        ' AbaterileLimitaGeneraleLiniareToolStripMenuItem
        ' 
        AbaterileLimitaGeneraleLiniareToolStripMenuItem.Name = "AbaterileLimitaGeneraleLiniareToolStripMenuItem"
        AbaterileLimitaGeneraleLiniareToolStripMenuItem.Size = New Size(237, 22)
        AbaterileLimitaGeneraleLiniareToolStripMenuItem.Text = "Abaterile limita generale liniare"
        ' 
        ' AbateriFundamentaleArboriToolStripMenuItem
        ' 
        AbateriFundamentaleArboriToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ArboriToolStripMenuItem, AlezajeToolStripMenuItem})
        AbateriFundamentaleArboriToolStripMenuItem.Name = "AbateriFundamentaleArboriToolStripMenuItem"
        AbateriFundamentaleArboriToolStripMenuItem.Size = New Size(237, 22)
        AbateriFundamentaleArboriToolStripMenuItem.Text = "Abateri fundamentale"
        ' 
        ' ArboriToolStripMenuItem
        ' 
        ArboriToolStripMenuItem.Name = "ArboriToolStripMenuItem"
        ArboriToolStripMenuItem.Size = New Size(180, 22)
        ArboriToolStripMenuItem.Text = "Arbori"
        ' 
        ' AlezajeToolStripMenuItem
        ' 
        AlezajeToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {DeltaToolStripMenuItem})
        AlezajeToolStripMenuItem.Name = "AlezajeToolStripMenuItem"
        AlezajeToolStripMenuItem.Size = New Size(180, 22)
        AlezajeToolStripMenuItem.Text = "Alezaje"
        ' 
        ' DeltaToolStripMenuItem
        ' 
        DeltaToolStripMenuItem.Name = "DeltaToolStripMenuItem"
        DeltaToolStripMenuItem.Size = New Size(180, 22)
        DeltaToolStripMenuItem.Text = "Delta"
        ' 
        ' main_window
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 566)
        Controls.Add(MenuStrip1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MainMenuStrip = MenuStrip1
        Name = "main_window"
        SizeGripStyle = SizeGripStyle.Hide
        Text = "Fereastra principala"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents VeziTabeleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToleranteFundamentaleLiniareToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AbaterileLimitaGeneraleLiniareToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AbateriFundamentaleArboriToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ArboriToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AlezajeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeltaToolStripMenuItem As ToolStripMenuItem
End Class
