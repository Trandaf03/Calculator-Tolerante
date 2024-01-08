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
        ToleranțeIndividualeLaRectilinitatePlanitateFormaDatăAProfiluluiȘiFormaDatăASuprafețeiToolStripMenuItem = New ToolStripMenuItem()
        ValorileToleranțelorIndividualeLaCircularitateȘiLaCilindricitateToolStripMenuItem = New ToolStripMenuItem()
        ToleranteleLaPozițiaNominalăLaCoaxialitateȘiConcentricitateȘiLaSimetrieToolStripMenuItem = New ToolStripMenuItem()
        ToleranteleIndividualeLaParalelismPerpendicularitateȘiÎnclinareToolStripMenuItem = New ToolStripMenuItem()
        ToleranteleIndividualeIndependenteDeDimensiunealeBiitiiiiRadialeToolStripMenuItem = New ToolStripMenuItem()
        ToleranțeleIndividualeIndependenteDeDimensiuneAleBătăiiFrontaleToolStripMenuItem = New ToolStripMenuItem()
        text_dimensiune = New TextBox()
        Label1 = New Label()
        combobox_treapta_toleranta_fundamentala = New ComboBox()
        Label2 = New Label()
        buton_calculeaza = New Button()
        text_afisare = New TextBox()
        Label3 = New Label()
        combobox_clasa_toleranta = New ComboBox()
        checkbox_este_tesitura = New CheckBox()
        label_arbore_ei = New Label()
        checkbox_arbore_ei = New ComboBox()
        label_arbore_es = New Label()
        checkbox_arbore_es = New ComboBox()
        label_alezaj_EI = New Label()
        checkbox_alezaj_EI = New ComboBox()
        label_alezaj_ES = New Label()
        checkbox_alezaj_ES = New ComboBox()
        combobox_tipul_piesei = New ComboBox()
        Label8 = New Label()
        Label4 = New Label()
        ComboBox_toleranta_la_nr1 = New ComboBox()
        Label5 = New Label()
        ComboBox_toleranta_la_nr2 = New ComboBox()
        Label6 = New Label()
        ComboBox_toleranta_la_nr3 = New ComboBox()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(24, 24)
        MenuStrip1.Items.AddRange(New ToolStripItem() {VeziTabeleToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New Padding(9, 3, 0, 3)
        MenuStrip1.Size = New Size(1143, 35)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' VeziTabeleToolStripMenuItem
        ' 
        VeziTabeleToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ToleranteFundamentaleLiniareToolStripMenuItem, AbaterileLimitaGeneraleLiniareToolStripMenuItem, AbateriFundamentaleArboriToolStripMenuItem, ToleranțeIndividualeLaRectilinitatePlanitateFormaDatăAProfiluluiȘiFormaDatăASuprafețeiToolStripMenuItem, ValorileToleranțelorIndividualeLaCircularitateȘiLaCilindricitateToolStripMenuItem, ToleranteleLaPozițiaNominalăLaCoaxialitateȘiConcentricitateȘiLaSimetrieToolStripMenuItem, ToleranteleIndividualeLaParalelismPerpendicularitateȘiÎnclinareToolStripMenuItem, ToleranteleIndividualeIndependenteDeDimensiunealeBiitiiiiRadialeToolStripMenuItem, ToleranțeleIndividualeIndependenteDeDimensiuneAleBătăiiFrontaleToolStripMenuItem})
        VeziTabeleToolStripMenuItem.Name = "VeziTabeleToolStripMenuItem"
        VeziTabeleToolStripMenuItem.Size = New Size(112, 29)
        VeziTabeleToolStripMenuItem.Text = "Vezi tabele"
        ' 
        ' ToleranteFundamentaleLiniareToolStripMenuItem
        ' 
        ToleranteFundamentaleLiniareToolStripMenuItem.Name = "ToleranteFundamentaleLiniareToolStripMenuItem"
        ToleranteFundamentaleLiniareToolStripMenuItem.Size = New Size(853, 34)
        ToleranteFundamentaleLiniareToolStripMenuItem.Text = "Tolerante fundamentale liniare"
        ' 
        ' AbaterileLimitaGeneraleLiniareToolStripMenuItem
        ' 
        AbaterileLimitaGeneraleLiniareToolStripMenuItem.Name = "AbaterileLimitaGeneraleLiniareToolStripMenuItem"
        AbaterileLimitaGeneraleLiniareToolStripMenuItem.Size = New Size(853, 34)
        AbaterileLimitaGeneraleLiniareToolStripMenuItem.Text = "Abaterile limita generale liniare"
        ' 
        ' AbateriFundamentaleArboriToolStripMenuItem
        ' 
        AbateriFundamentaleArboriToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ArboriToolStripMenuItem, AlezajeToolStripMenuItem})
        AbateriFundamentaleArboriToolStripMenuItem.Name = "AbateriFundamentaleArboriToolStripMenuItem"
        AbateriFundamentaleArboriToolStripMenuItem.Size = New Size(853, 34)
        AbateriFundamentaleArboriToolStripMenuItem.Text = "Abateri fundamentale"
        ' 
        ' ArboriToolStripMenuItem
        ' 
        ArboriToolStripMenuItem.Name = "ArboriToolStripMenuItem"
        ArboriToolStripMenuItem.Size = New Size(169, 34)
        ArboriToolStripMenuItem.Text = "Arbori"
        ' 
        ' AlezajeToolStripMenuItem
        ' 
        AlezajeToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {DeltaToolStripMenuItem})
        AlezajeToolStripMenuItem.Name = "AlezajeToolStripMenuItem"
        AlezajeToolStripMenuItem.Size = New Size(169, 34)
        AlezajeToolStripMenuItem.Text = "Alezaje"
        ' 
        ' DeltaToolStripMenuItem
        ' 
        DeltaToolStripMenuItem.Name = "DeltaToolStripMenuItem"
        DeltaToolStripMenuItem.Size = New Size(155, 34)
        DeltaToolStripMenuItem.Text = "Delta"
        ' 
        ' ToleranțeIndividualeLaRectilinitatePlanitateFormaDatăAProfiluluiȘiFormaDatăASuprafețeiToolStripMenuItem
        ' 
        ToleranțeIndividualeLaRectilinitatePlanitateFormaDatăAProfiluluiȘiFormaDatăASuprafețeiToolStripMenuItem.Name = "ToleranțeIndividualeLaRectilinitatePlanitateFormaDatăAProfiluluiȘiFormaDatăASuprafețeiToolStripMenuItem"
        ToleranțeIndividualeLaRectilinitatePlanitateFormaDatăAProfiluluiȘiFormaDatăASuprafețeiToolStripMenuItem.Size = New Size(853, 34)
        ToleranțeIndividualeLaRectilinitatePlanitateFormaDatăAProfiluluiȘiFormaDatăASuprafețeiToolStripMenuItem.Text = "Toleranțe individuale la rectilinitate, planitate, forma dată a profilului și forma dată a suprafeței"
        ' 
        ' ValorileToleranțelorIndividualeLaCircularitateȘiLaCilindricitateToolStripMenuItem
        ' 
        ValorileToleranțelorIndividualeLaCircularitateȘiLaCilindricitateToolStripMenuItem.Name = "ValorileToleranțelorIndividualeLaCircularitateȘiLaCilindricitateToolStripMenuItem"
        ValorileToleranțelorIndividualeLaCircularitateȘiLaCilindricitateToolStripMenuItem.Size = New Size(853, 34)
        ValorileToleranțelorIndividualeLaCircularitateȘiLaCilindricitateToolStripMenuItem.Text = "Valorile toleranțelor individuale la circularitate și la cilindricitate"
        ' 
        ' ToleranteleLaPozițiaNominalăLaCoaxialitateȘiConcentricitateȘiLaSimetrieToolStripMenuItem
        ' 
        ToleranteleLaPozițiaNominalăLaCoaxialitateȘiConcentricitateȘiLaSimetrieToolStripMenuItem.Name = "ToleranteleLaPozițiaNominalăLaCoaxialitateȘiConcentricitateȘiLaSimetrieToolStripMenuItem"
        ToleranteleLaPozițiaNominalăLaCoaxialitateȘiConcentricitateȘiLaSimetrieToolStripMenuItem.Size = New Size(853, 34)
        ToleranteleLaPozițiaNominalăLaCoaxialitateȘiConcentricitateȘiLaSimetrieToolStripMenuItem.Text = "Tolerantele la poziția nominală, la coaxialitate și concentricitate și la simetrie"
        ' 
        ' ToleranteleIndividualeLaParalelismPerpendicularitateȘiÎnclinareToolStripMenuItem
        ' 
        ToleranteleIndividualeLaParalelismPerpendicularitateȘiÎnclinareToolStripMenuItem.Name = "ToleranteleIndividualeLaParalelismPerpendicularitateȘiÎnclinareToolStripMenuItem"
        ToleranteleIndividualeLaParalelismPerpendicularitateȘiÎnclinareToolStripMenuItem.Size = New Size(853, 34)
        ToleranteleIndividualeLaParalelismPerpendicularitateȘiÎnclinareToolStripMenuItem.Text = "Tolerantele individuale la paralelism, perpendicularitate și înclinare"
        ' 
        ' ToleranteleIndividualeIndependenteDeDimensiunealeBiitiiiiRadialeToolStripMenuItem
        ' 
        ToleranteleIndividualeIndependenteDeDimensiunealeBiitiiiiRadialeToolStripMenuItem.Name = "ToleranteleIndividualeIndependenteDeDimensiunealeBiitiiiiRadialeToolStripMenuItem"
        ToleranteleIndividualeIndependenteDeDimensiunealeBiitiiiiRadialeToolStripMenuItem.Size = New Size(853, 34)
        ToleranteleIndividualeIndependenteDeDimensiunealeBiitiiiiRadialeToolStripMenuItem.Text = "Tolerantele individuale independente de dimensiuneale bătăii radiale"
        ' 
        ' ToleranțeleIndividualeIndependenteDeDimensiuneAleBătăiiFrontaleToolStripMenuItem
        ' 
        ToleranțeleIndividualeIndependenteDeDimensiuneAleBătăiiFrontaleToolStripMenuItem.Name = "ToleranțeleIndividualeIndependenteDeDimensiuneAleBătăiiFrontaleToolStripMenuItem"
        ToleranțeleIndividualeIndependenteDeDimensiuneAleBătăiiFrontaleToolStripMenuItem.Size = New Size(853, 34)
        ToleranțeleIndividualeIndependenteDeDimensiuneAleBătăiiFrontaleToolStripMenuItem.Text = "Toleranțele individuale independente de dimensiune ale bătăii frontale"
        ' 
        ' text_dimensiune
        ' 
        text_dimensiune.Location = New Point(73, 150)
        text_dimensiune.Margin = New Padding(4, 5, 4, 5)
        text_dimensiune.Name = "text_dimensiune"
        text_dimensiune.Size = New Size(144, 31)
        text_dimensiune.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(71, 120)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(176, 25)
        Label1.TabIndex = 2
        Label1.Text = "Introdu dimensiunea"
        ' 
        ' combobox_treapta_toleranta_fundamentala
        ' 
        combobox_treapta_toleranta_fundamentala.FormattingEnabled = True
        combobox_treapta_toleranta_fundamentala.Location = New Point(313, 148)
        combobox_treapta_toleranta_fundamentala.Margin = New Padding(4, 5, 4, 5)
        combobox_treapta_toleranta_fundamentala.Name = "combobox_treapta_toleranta_fundamentala"
        combobox_treapta_toleranta_fundamentala.Size = New Size(161, 33)
        combobox_treapta_toleranta_fundamentala.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(313, 118)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(169, 25)
        Label2.TabIndex = 4
        Label2.Text = "Treapta de toleranță"
        ' 
        ' buton_calculeaza
        ' 
        buton_calculeaza.Location = New Point(419, 850)
        buton_calculeaza.Margin = New Padding(4, 5, 4, 5)
        buton_calculeaza.Name = "buton_calculeaza"
        buton_calculeaza.Size = New Size(311, 73)
        buton_calculeaza.TabIndex = 5
        buton_calculeaza.Text = "Calculează!"
        buton_calculeaza.UseVisualStyleBackColor = True
        ' 
        ' text_afisare
        ' 
        text_afisare.Location = New Point(156, 528)
        text_afisare.Margin = New Padding(4, 5, 4, 5)
        text_afisare.Multiline = True
        text_afisare.Name = "text_afisare"
        text_afisare.Size = New Size(867, 309)
        text_afisare.TabIndex = 6
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(567, 120)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(153, 25)
        Label3.TabIndex = 8
        Label3.Text = "Clasa de toleranță"
        ' 
        ' combobox_clasa_toleranta
        ' 
        combobox_clasa_toleranta.FormattingEnabled = True
        combobox_clasa_toleranta.Location = New Point(567, 150)
        combobox_clasa_toleranta.Margin = New Padding(4, 5, 4, 5)
        combobox_clasa_toleranta.Name = "combobox_clasa_toleranta"
        combobox_clasa_toleranta.Size = New Size(161, 33)
        combobox_clasa_toleranta.TabIndex = 7
        ' 
        ' checkbox_este_tesitura
        ' 
        checkbox_este_tesitura.AutoSize = True
        checkbox_este_tesitura.Location = New Point(774, 153)
        checkbox_este_tesitura.Margin = New Padding(4, 5, 4, 5)
        checkbox_este_tesitura.Name = "checkbox_este_tesitura"
        checkbox_este_tesitura.Size = New Size(282, 29)
        checkbox_este_tesitura.TabIndex = 9
        checkbox_este_tesitura.Text = "Este dimensiunea ta o teșitură?"
        checkbox_este_tesitura.UseVisualStyleBackColor = True
        ' 
        ' label_arbore_ei
        ' 
        label_arbore_ei.AutoSize = True
        label_arbore_ei.Location = New Point(567, 223)
        label_arbore_ei.Margin = New Padding(4, 0, 4, 0)
        label_arbore_ei.Name = "label_arbore_ei"
        label_arbore_ei.Size = New Size(180, 25)
        label_arbore_ei.TabIndex = 13
        label_arbore_ei.Text = "Abaterea inferioară ei"
        ' 
        ' checkbox_arbore_ei
        ' 
        checkbox_arbore_ei.FormattingEnabled = True
        checkbox_arbore_ei.Location = New Point(567, 253)
        checkbox_arbore_ei.Margin = New Padding(4, 5, 4, 5)
        checkbox_arbore_ei.Name = "checkbox_arbore_ei"
        checkbox_arbore_ei.Size = New Size(161, 33)
        checkbox_arbore_ei.TabIndex = 12
        ' 
        ' label_arbore_es
        ' 
        label_arbore_es.AutoSize = True
        label_arbore_es.Location = New Point(313, 221)
        label_arbore_es.Margin = New Padding(4, 0, 4, 0)
        label_arbore_es.Name = "label_arbore_es"
        label_arbore_es.Size = New Size(193, 25)
        label_arbore_es.TabIndex = 11
        label_arbore_es.Text = "Abaterea superioară es"
        ' 
        ' checkbox_arbore_es
        ' 
        checkbox_arbore_es.FormattingEnabled = True
        checkbox_arbore_es.Location = New Point(313, 251)
        checkbox_arbore_es.Margin = New Padding(4, 5, 4, 5)
        checkbox_arbore_es.Name = "checkbox_arbore_es"
        checkbox_arbore_es.Size = New Size(161, 33)
        checkbox_arbore_es.TabIndex = 10
        ' 
        ' label_alezaj_EI
        ' 
        label_alezaj_EI.AutoSize = True
        label_alezaj_EI.Location = New Point(567, 223)
        label_alezaj_EI.Margin = New Padding(4, 0, 4, 0)
        label_alezaj_EI.Name = "label_alezaj_EI"
        label_alezaj_EI.Size = New Size(190, 25)
        label_alezaj_EI.TabIndex = 18
        label_alezaj_EI.Text = "Abaterea superioară EI"
        ' 
        ' checkbox_alezaj_EI
        ' 
        checkbox_alezaj_EI.FormattingEnabled = True
        checkbox_alezaj_EI.Location = New Point(567, 253)
        checkbox_alezaj_EI.Margin = New Padding(4, 5, 4, 5)
        checkbox_alezaj_EI.Name = "checkbox_alezaj_EI"
        checkbox_alezaj_EI.Size = New Size(161, 33)
        checkbox_alezaj_EI.TabIndex = 17
        ' 
        ' label_alezaj_ES
        ' 
        label_alezaj_ES.AutoSize = True
        label_alezaj_ES.Location = New Point(313, 221)
        label_alezaj_ES.Margin = New Padding(4, 0, 4, 0)
        label_alezaj_ES.Name = "label_alezaj_ES"
        label_alezaj_ES.Size = New Size(186, 25)
        label_alezaj_ES.TabIndex = 16
        label_alezaj_ES.Text = "Abaterea inferioară ES"
        ' 
        ' checkbox_alezaj_ES
        ' 
        checkbox_alezaj_ES.FormattingEnabled = True
        checkbox_alezaj_ES.Location = New Point(313, 251)
        checkbox_alezaj_ES.Margin = New Padding(4, 5, 4, 5)
        checkbox_alezaj_ES.Name = "checkbox_alezaj_ES"
        checkbox_alezaj_ES.Size = New Size(161, 33)
        checkbox_alezaj_ES.TabIndex = 15
        ' 
        ' combobox_tipul_piesei
        ' 
        combobox_tipul_piesei.FormattingEnabled = True
        combobox_tipul_piesei.Location = New Point(73, 253)
        combobox_tipul_piesei.Margin = New Padding(4, 5, 4, 5)
        combobox_tipul_piesei.Name = "combobox_tipul_piesei"
        combobox_tipul_piesei.Size = New Size(161, 33)
        combobox_tipul_piesei.TabIndex = 19
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(73, 223)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(100, 25)
        Label8.TabIndex = 20
        Label8.Text = "Tipul piesei"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(73, 319)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(113, 25)
        Label4.TabIndex = 22
        Label4.Text = "Toleranță la..."
        ' 
        ' ComboBox_toleranta_la_nr1
        ' 
        ComboBox_toleranta_la_nr1.FormattingEnabled = True
        ComboBox_toleranta_la_nr1.Location = New Point(73, 349)
        ComboBox_toleranta_la_nr1.Margin = New Padding(4, 5, 4, 5)
        ComboBox_toleranta_la_nr1.Name = "ComboBox_toleranta_la_nr1"
        ComboBox_toleranta_la_nr1.Size = New Size(161, 33)
        ComboBox_toleranta_la_nr1.TabIndex = 21
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(313, 317)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(113, 25)
        Label5.TabIndex = 24
        Label5.Text = "Toleranță la..."
        ' 
        ' ComboBox_toleranta_la_nr2
        ' 
        ComboBox_toleranta_la_nr2.FormattingEnabled = True
        ComboBox_toleranta_la_nr2.Location = New Point(313, 347)
        ComboBox_toleranta_la_nr2.Margin = New Padding(4, 5, 4, 5)
        ComboBox_toleranta_la_nr2.Name = "ComboBox_toleranta_la_nr2"
        ComboBox_toleranta_la_nr2.Size = New Size(161, 33)
        ComboBox_toleranta_la_nr2.TabIndex = 23
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(567, 319)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(113, 25)
        Label6.TabIndex = 26
        Label6.Text = "Toleranță la..."
        ' 
        ' ComboBox_toleranta_la_nr3
        ' 
        ComboBox_toleranta_la_nr3.FormattingEnabled = True
        ComboBox_toleranta_la_nr3.Location = New Point(567, 349)
        ComboBox_toleranta_la_nr3.Margin = New Padding(4, 5, 4, 5)
        ComboBox_toleranta_la_nr3.Name = "ComboBox_toleranta_la_nr3"
        ComboBox_toleranta_la_nr3.Size = New Size(161, 33)
        ComboBox_toleranta_la_nr3.TabIndex = 25
        ' 
        ' main_window
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1143, 943)
        Controls.Add(Label6)
        Controls.Add(ComboBox_toleranta_la_nr3)
        Controls.Add(Label5)
        Controls.Add(ComboBox_toleranta_la_nr2)
        Controls.Add(Label4)
        Controls.Add(ComboBox_toleranta_la_nr1)
        Controls.Add(Label8)
        Controls.Add(combobox_tipul_piesei)
        Controls.Add(label_alezaj_EI)
        Controls.Add(checkbox_alezaj_EI)
        Controls.Add(label_alezaj_ES)
        Controls.Add(checkbox_alezaj_ES)
        Controls.Add(label_arbore_ei)
        Controls.Add(checkbox_arbore_ei)
        Controls.Add(label_arbore_es)
        Controls.Add(checkbox_arbore_es)
        Controls.Add(checkbox_este_tesitura)
        Controls.Add(Label3)
        Controls.Add(combobox_clasa_toleranta)
        Controls.Add(text_afisare)
        Controls.Add(buton_calculeaza)
        Controls.Add(Label2)
        Controls.Add(combobox_treapta_toleranta_fundamentala)
        Controls.Add(Label1)
        Controls.Add(text_dimensiune)
        Controls.Add(MenuStrip1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MainMenuStrip = MenuStrip1
        Margin = New Padding(4, 5, 4, 5)
        Name = "main_window"
        SizeGripStyle = SizeGripStyle.Hide
        Text = "Fereastra principală"
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
    Friend WithEvents text_dimensiune As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents combobox_treapta_toleranta_fundamentala As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents buton_calculeaza As Button
    Friend WithEvents text_afisare As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents combobox_clasa_toleranta As ComboBox
    Friend WithEvents checkbox_este_tesitura As CheckBox
    Friend WithEvents label_arbore_ei As Label
    Friend WithEvents checkbox_arbore_ei As ComboBox
    Friend WithEvents label_arbore_es As Label
    Friend WithEvents checkbox_arbore_es As ComboBox
    Friend WithEvents label_alezaj_EI As Label
    Friend WithEvents checkbox_alezaj_EI As ComboBox
    Friend WithEvents label_alezaj_ES As Label
    Friend WithEvents checkbox_alezaj_ES As ComboBox
    Friend WithEvents combobox_tipul_piesei As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents ToleranțeIndividualeLaRectilinitatePlanitateFormaDatăAProfiluluiȘiFormaDatăASuprafețeiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ValorileToleranțelorIndividualeLaCircularitateȘiLaCilindricitateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToleranteleLaPozițiaNominalăLaCoaxialitateȘiConcentricitateȘiLaSimetrieToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToleranteleIndividualeLaParalelismPerpendicularitateȘiÎnclinareToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToleranteleIndividualeIndependenteDeDimensiunealeBiitiiiiRadialeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToleranțeleIndividualeIndependenteDeDimensiuneAleBătăiiFrontaleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBox_toleranta_la_nr1 As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBox_toleranta_la_nr2 As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox_toleranta_la_nr3 As ComboBox
End Class
