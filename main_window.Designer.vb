﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        ToleranțeGeneraleLaRectilinitateȘiPlanitateToolStripMenuItem = New ToolStripMenuItem()
        ToleranțeGeneraleLaSimetrieToolStripMenuItem = New ToolStripMenuItem()
        ToleranțeGeneraleLaPerpendicularitateToolStripMenuItem = New ToolStripMenuItem()
        ToleranțeGeneraleAleBătăiiSuprafețelorToolStripMenuItem = New ToolStripMenuItem()
        ClaseleDeRugozitateȘiParametriiAsociațiToolStripMenuItem = New ToolStripMenuItem()
        CalculAjustajToolStripMenuItem = New ToolStripMenuItem()
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
        Label7 = New Label()
        combobox_clasa_precizie = New ComboBox()
        Label9 = New Label()
        combobox_clasa_toleranta_hkl = New ComboBox()
        Label10 = New Label()
        ComboBox_toleranta_la_nr6 = New ComboBox()
        Label11 = New Label()
        ComboBox_toleranta_la_nr5 = New ComboBox()
        Label12 = New Label()
        ComboBox_toleranta_la_nr4 = New ComboBox()
        Label13 = New Label()
        combobox_rugozitate = New ComboBox()
        Label14 = New Label()
        ComboBox2 = New ComboBox()
        switch_stas = New CheckBox()
        cmb_iso_stas = New ComboBox()
        btn_reset = New Button()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(24, 24)
        MenuStrip1.Items.AddRange(New ToolStripItem() {VeziTabeleToolStripMenuItem, CalculAjustajToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(800, 24)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' VeziTabeleToolStripMenuItem
        ' 
        VeziTabeleToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ToleranteFundamentaleLiniareToolStripMenuItem, AbaterileLimitaGeneraleLiniareToolStripMenuItem, AbateriFundamentaleArboriToolStripMenuItem, ToleranțeIndividualeLaRectilinitatePlanitateFormaDatăAProfiluluiȘiFormaDatăASuprafețeiToolStripMenuItem, ValorileToleranțelorIndividualeLaCircularitateȘiLaCilindricitateToolStripMenuItem, ToleranteleLaPozițiaNominalăLaCoaxialitateȘiConcentricitateȘiLaSimetrieToolStripMenuItem, ToleranteleIndividualeLaParalelismPerpendicularitateȘiÎnclinareToolStripMenuItem, ToleranteleIndividualeIndependenteDeDimensiunealeBiitiiiiRadialeToolStripMenuItem, ToleranțeleIndividualeIndependenteDeDimensiuneAleBătăiiFrontaleToolStripMenuItem, ToleranțeGeneraleLaRectilinitateȘiPlanitateToolStripMenuItem, ToleranțeGeneraleLaSimetrieToolStripMenuItem, ToleranțeGeneraleLaPerpendicularitateToolStripMenuItem, ToleranțeGeneraleAleBătăiiSuprafețelorToolStripMenuItem, ClaseleDeRugozitateȘiParametriiAsociațiToolStripMenuItem})
        VeziTabeleToolStripMenuItem.Name = "VeziTabeleToolStripMenuItem"
        VeziTabeleToolStripMenuItem.Size = New Size(74, 20)
        VeziTabeleToolStripMenuItem.Text = "Vezi tabele"
        ' 
        ' ToleranteFundamentaleLiniareToolStripMenuItem
        ' 
        ToleranteFundamentaleLiniareToolStripMenuItem.Name = "ToleranteFundamentaleLiniareToolStripMenuItem"
        ToleranteFundamentaleLiniareToolStripMenuItem.Size = New Size(569, 22)
        ToleranteFundamentaleLiniareToolStripMenuItem.Text = "Tolerante fundamentale liniare"
        ' 
        ' AbaterileLimitaGeneraleLiniareToolStripMenuItem
        ' 
        AbaterileLimitaGeneraleLiniareToolStripMenuItem.Name = "AbaterileLimitaGeneraleLiniareToolStripMenuItem"
        AbaterileLimitaGeneraleLiniareToolStripMenuItem.Size = New Size(569, 22)
        AbaterileLimitaGeneraleLiniareToolStripMenuItem.Text = "Abaterile limita generale liniare"
        ' 
        ' AbateriFundamentaleArboriToolStripMenuItem
        ' 
        AbateriFundamentaleArboriToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ArboriToolStripMenuItem, AlezajeToolStripMenuItem})
        AbateriFundamentaleArboriToolStripMenuItem.Name = "AbateriFundamentaleArboriToolStripMenuItem"
        AbateriFundamentaleArboriToolStripMenuItem.Size = New Size(569, 22)
        AbateriFundamentaleArboriToolStripMenuItem.Text = "Abateri fundamentale"
        ' 
        ' ArboriToolStripMenuItem
        ' 
        ArboriToolStripMenuItem.Name = "ArboriToolStripMenuItem"
        ArboriToolStripMenuItem.Size = New Size(111, 22)
        ArboriToolStripMenuItem.Text = "Arbori"
        ' 
        ' AlezajeToolStripMenuItem
        ' 
        AlezajeToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {DeltaToolStripMenuItem})
        AlezajeToolStripMenuItem.Name = "AlezajeToolStripMenuItem"
        AlezajeToolStripMenuItem.Size = New Size(111, 22)
        AlezajeToolStripMenuItem.Text = "Alezaje"
        ' 
        ' DeltaToolStripMenuItem
        ' 
        DeltaToolStripMenuItem.Name = "DeltaToolStripMenuItem"
        DeltaToolStripMenuItem.Size = New Size(101, 22)
        DeltaToolStripMenuItem.Text = "Delta"
        ' 
        ' ToleranțeIndividualeLaRectilinitatePlanitateFormaDatăAProfiluluiȘiFormaDatăASuprafețeiToolStripMenuItem
        ' 
        ToleranțeIndividualeLaRectilinitatePlanitateFormaDatăAProfiluluiȘiFormaDatăASuprafețeiToolStripMenuItem.Name = "ToleranțeIndividualeLaRectilinitatePlanitateFormaDatăAProfiluluiȘiFormaDatăASuprafețeiToolStripMenuItem"
        ToleranțeIndividualeLaRectilinitatePlanitateFormaDatăAProfiluluiȘiFormaDatăASuprafețeiToolStripMenuItem.Size = New Size(569, 22)
        ToleranțeIndividualeLaRectilinitatePlanitateFormaDatăAProfiluluiȘiFormaDatăASuprafețeiToolStripMenuItem.Text = "Toleranțe individuale la rectilinitate, planitate, forma dată a profilului și forma dată a suprafeței"
        ' 
        ' ValorileToleranțelorIndividualeLaCircularitateȘiLaCilindricitateToolStripMenuItem
        ' 
        ValorileToleranțelorIndividualeLaCircularitateȘiLaCilindricitateToolStripMenuItem.Name = "ValorileToleranțelorIndividualeLaCircularitateȘiLaCilindricitateToolStripMenuItem"
        ValorileToleranțelorIndividualeLaCircularitateȘiLaCilindricitateToolStripMenuItem.Size = New Size(569, 22)
        ValorileToleranțelorIndividualeLaCircularitateȘiLaCilindricitateToolStripMenuItem.Text = "Valorile toleranțelor individuale la circularitate și la cilindricitate"
        ' 
        ' ToleranteleLaPozițiaNominalăLaCoaxialitateȘiConcentricitateȘiLaSimetrieToolStripMenuItem
        ' 
        ToleranteleLaPozițiaNominalăLaCoaxialitateȘiConcentricitateȘiLaSimetrieToolStripMenuItem.Name = "ToleranteleLaPozițiaNominalăLaCoaxialitateȘiConcentricitateȘiLaSimetrieToolStripMenuItem"
        ToleranteleLaPozițiaNominalăLaCoaxialitateȘiConcentricitateȘiLaSimetrieToolStripMenuItem.Size = New Size(569, 22)
        ToleranteleLaPozițiaNominalăLaCoaxialitateȘiConcentricitateȘiLaSimetrieToolStripMenuItem.Text = "Tolerantele la poziția nominală, la coaxialitate și concentricitate și la simetrie"
        ' 
        ' ToleranteleIndividualeLaParalelismPerpendicularitateȘiÎnclinareToolStripMenuItem
        ' 
        ToleranteleIndividualeLaParalelismPerpendicularitateȘiÎnclinareToolStripMenuItem.Name = "ToleranteleIndividualeLaParalelismPerpendicularitateȘiÎnclinareToolStripMenuItem"
        ToleranteleIndividualeLaParalelismPerpendicularitateȘiÎnclinareToolStripMenuItem.Size = New Size(569, 22)
        ToleranteleIndividualeLaParalelismPerpendicularitateȘiÎnclinareToolStripMenuItem.Text = "Tolerantele individuale la paralelism, perpendicularitate și înclinare"
        ' 
        ' ToleranteleIndividualeIndependenteDeDimensiunealeBiitiiiiRadialeToolStripMenuItem
        ' 
        ToleranteleIndividualeIndependenteDeDimensiunealeBiitiiiiRadialeToolStripMenuItem.Name = "ToleranteleIndividualeIndependenteDeDimensiunealeBiitiiiiRadialeToolStripMenuItem"
        ToleranteleIndividualeIndependenteDeDimensiunealeBiitiiiiRadialeToolStripMenuItem.Size = New Size(569, 22)
        ToleranteleIndividualeIndependenteDeDimensiunealeBiitiiiiRadialeToolStripMenuItem.Text = "Tolerantele individuale independente de dimensiuneale bătăii radiale"
        ' 
        ' ToleranțeleIndividualeIndependenteDeDimensiuneAleBătăiiFrontaleToolStripMenuItem
        ' 
        ToleranțeleIndividualeIndependenteDeDimensiuneAleBătăiiFrontaleToolStripMenuItem.Name = "ToleranțeleIndividualeIndependenteDeDimensiuneAleBătăiiFrontaleToolStripMenuItem"
        ToleranțeleIndividualeIndependenteDeDimensiuneAleBătăiiFrontaleToolStripMenuItem.Size = New Size(569, 22)
        ToleranțeleIndividualeIndependenteDeDimensiuneAleBătăiiFrontaleToolStripMenuItem.Text = "Toleranțele individuale independente de dimensiune ale bătăii frontale"
        ' 
        ' ToleranțeGeneraleLaRectilinitateȘiPlanitateToolStripMenuItem
        ' 
        ToleranțeGeneraleLaRectilinitateȘiPlanitateToolStripMenuItem.Name = "ToleranțeGeneraleLaRectilinitateȘiPlanitateToolStripMenuItem"
        ToleranțeGeneraleLaRectilinitateȘiPlanitateToolStripMenuItem.Size = New Size(569, 22)
        ToleranțeGeneraleLaRectilinitateȘiPlanitateToolStripMenuItem.Text = "Toleranțe generale la rectilinitate și planitate"
        ' 
        ' ToleranțeGeneraleLaSimetrieToolStripMenuItem
        ' 
        ToleranțeGeneraleLaSimetrieToolStripMenuItem.Name = "ToleranțeGeneraleLaSimetrieToolStripMenuItem"
        ToleranțeGeneraleLaSimetrieToolStripMenuItem.Size = New Size(569, 22)
        ToleranțeGeneraleLaSimetrieToolStripMenuItem.Text = "Toleranțe generale la simetrie"
        ' 
        ' ToleranțeGeneraleLaPerpendicularitateToolStripMenuItem
        ' 
        ToleranțeGeneraleLaPerpendicularitateToolStripMenuItem.Name = "ToleranțeGeneraleLaPerpendicularitateToolStripMenuItem"
        ToleranțeGeneraleLaPerpendicularitateToolStripMenuItem.Size = New Size(569, 22)
        ToleranțeGeneraleLaPerpendicularitateToolStripMenuItem.Text = "Toleranțe generale la perpendicularitate"
        ' 
        ' ToleranțeGeneraleAleBătăiiSuprafețelorToolStripMenuItem
        ' 
        ToleranțeGeneraleAleBătăiiSuprafețelorToolStripMenuItem.Name = "ToleranțeGeneraleAleBătăiiSuprafețelorToolStripMenuItem"
        ToleranțeGeneraleAleBătăiiSuprafețelorToolStripMenuItem.Size = New Size(569, 22)
        ToleranțeGeneraleAleBătăiiSuprafețelorToolStripMenuItem.Text = "Toleranțe generale ale bătăii suprafețelor"
        ' 
        ' ClaseleDeRugozitateȘiParametriiAsociațiToolStripMenuItem
        ' 
        ClaseleDeRugozitateȘiParametriiAsociațiToolStripMenuItem.Name = "ClaseleDeRugozitateȘiParametriiAsociațiToolStripMenuItem"
        ClaseleDeRugozitateȘiParametriiAsociațiToolStripMenuItem.Size = New Size(569, 22)
        ClaseleDeRugozitateȘiParametriiAsociațiToolStripMenuItem.Text = "Clasele de rugozitate și parametrii asociați"
        ' 
        ' CalculAjustajToolStripMenuItem
        ' 
        CalculAjustajToolStripMenuItem.Name = "CalculAjustajToolStripMenuItem"
        CalculAjustajToolStripMenuItem.Size = New Size(89, 20)
        CalculAjustajToolStripMenuItem.Text = "Calcul ajustaj"
        ' 
        ' text_dimensiune
        ' 
        text_dimensiune.Location = New Point(54, 60)
        text_dimensiune.Name = "text_dimensiune"
        text_dimensiune.Size = New Size(102, 23)
        text_dimensiune.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(53, 42)
        Label1.Name = "Label1"
        Label1.Size = New Size(117, 15)
        Label1.TabIndex = 2
        Label1.Text = "Introdu dimensiunea"
        ' 
        ' combobox_treapta_toleranta_fundamentala
        ' 
        combobox_treapta_toleranta_fundamentala.FormattingEnabled = True
        combobox_treapta_toleranta_fundamentala.Location = New Point(222, 59)
        combobox_treapta_toleranta_fundamentala.Name = "combobox_treapta_toleranta_fundamentala"
        combobox_treapta_toleranta_fundamentala.Size = New Size(114, 23)
        combobox_treapta_toleranta_fundamentala.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(222, 41)
        Label2.Name = "Label2"
        Label2.Size = New Size(111, 15)
        Label2.TabIndex = 4
        Label2.Text = "Treapta de toleranță"
        ' 
        ' buton_calculeaza
        ' 
        buton_calculeaza.Location = New Point(296, 280)
        buton_calculeaza.Name = "buton_calculeaza"
        buton_calculeaza.Size = New Size(218, 44)
        buton_calculeaza.TabIndex = 5
        buton_calculeaza.Text = "Calculează!"
        buton_calculeaza.UseVisualStyleBackColor = True
        ' 
        ' text_afisare
        ' 
        text_afisare.Location = New Point(104, 330)
        text_afisare.Multiline = True
        text_afisare.Name = "text_afisare"
        text_afisare.Size = New Size(608, 373)
        text_afisare.TabIndex = 6
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(400, 42)
        Label3.Name = "Label3"
        Label3.Size = New Size(101, 15)
        Label3.TabIndex = 8
        Label3.Text = "Clasa de toleranță"
        ' 
        ' combobox_clasa_toleranta
        ' 
        combobox_clasa_toleranta.FormattingEnabled = True
        combobox_clasa_toleranta.Location = New Point(400, 60)
        combobox_clasa_toleranta.Name = "combobox_clasa_toleranta"
        combobox_clasa_toleranta.Size = New Size(114, 23)
        combobox_clasa_toleranta.TabIndex = 7
        ' 
        ' checkbox_este_tesitura
        ' 
        checkbox_este_tesitura.AutoSize = True
        checkbox_este_tesitura.Location = New Point(536, 59)
        checkbox_este_tesitura.Name = "checkbox_este_tesitura"
        checkbox_este_tesitura.Size = New Size(108, 19)
        checkbox_este_tesitura.TabIndex = 9
        checkbox_este_tesitura.Text = "Nu este tesitura"
        checkbox_este_tesitura.UseVisualStyleBackColor = True
        ' 
        ' label_arbore_ei
        ' 
        label_arbore_ei.AutoSize = True
        label_arbore_ei.Location = New Point(400, 104)
        label_arbore_ei.Name = "label_arbore_ei"
        label_arbore_ei.Size = New Size(119, 15)
        label_arbore_ei.TabIndex = 13
        label_arbore_ei.Text = "Abaterea inferioară ei"
        ' 
        ' checkbox_arbore_ei
        ' 
        checkbox_arbore_ei.FormattingEnabled = True
        checkbox_arbore_ei.Location = New Point(400, 122)
        checkbox_arbore_ei.Name = "checkbox_arbore_ei"
        checkbox_arbore_ei.Size = New Size(114, 23)
        checkbox_arbore_ei.TabIndex = 12
        ' 
        ' label_arbore_es
        ' 
        label_arbore_es.AutoSize = True
        label_arbore_es.Location = New Point(222, 103)
        label_arbore_es.Name = "label_arbore_es"
        label_arbore_es.Size = New Size(126, 15)
        label_arbore_es.TabIndex = 11
        label_arbore_es.Text = "Abaterea superioară es"
        ' 
        ' checkbox_arbore_es
        ' 
        checkbox_arbore_es.FormattingEnabled = True
        checkbox_arbore_es.Location = New Point(222, 121)
        checkbox_arbore_es.Name = "checkbox_arbore_es"
        checkbox_arbore_es.Size = New Size(114, 23)
        checkbox_arbore_es.TabIndex = 10
        ' 
        ' label_alezaj_EI
        ' 
        label_alezaj_EI.AutoSize = True
        label_alezaj_EI.Location = New Point(400, 104)
        label_alezaj_EI.Name = "label_alezaj_EI"
        label_alezaj_EI.Size = New Size(124, 15)
        label_alezaj_EI.TabIndex = 18
        label_alezaj_EI.Text = "Abaterea superioară EI"
        ' 
        ' checkbox_alezaj_EI
        ' 
        checkbox_alezaj_EI.FormattingEnabled = True
        checkbox_alezaj_EI.Location = New Point(400, 122)
        checkbox_alezaj_EI.Name = "checkbox_alezaj_EI"
        checkbox_alezaj_EI.Size = New Size(114, 23)
        checkbox_alezaj_EI.TabIndex = 17
        ' 
        ' label_alezaj_ES
        ' 
        label_alezaj_ES.AutoSize = True
        label_alezaj_ES.Location = New Point(222, 103)
        label_alezaj_ES.Name = "label_alezaj_ES"
        label_alezaj_ES.Size = New Size(122, 15)
        label_alezaj_ES.TabIndex = 16
        label_alezaj_ES.Text = "Abaterea inferioară ES"
        ' 
        ' checkbox_alezaj_ES
        ' 
        checkbox_alezaj_ES.FormattingEnabled = True
        checkbox_alezaj_ES.Location = New Point(222, 121)
        checkbox_alezaj_ES.Name = "checkbox_alezaj_ES"
        checkbox_alezaj_ES.Size = New Size(114, 23)
        checkbox_alezaj_ES.TabIndex = 15
        ' 
        ' combobox_tipul_piesei
        ' 
        combobox_tipul_piesei.FormattingEnabled = True
        combobox_tipul_piesei.Location = New Point(54, 122)
        combobox_tipul_piesei.Name = "combobox_tipul_piesei"
        combobox_tipul_piesei.Size = New Size(114, 23)
        combobox_tipul_piesei.TabIndex = 19
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(54, 104)
        Label8.Name = "Label8"
        Label8.Size = New Size(66, 15)
        Label8.TabIndex = 20
        Label8.Text = "Tipul piesei"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(222, 167)
        Label4.Name = "Label4"
        Label4.Size = New Size(76, 15)
        Label4.TabIndex = 22
        Label4.Text = "Toleranță la..."
        ' 
        ' ComboBox_toleranta_la_nr1
        ' 
        ComboBox_toleranta_la_nr1.FormattingEnabled = True
        ComboBox_toleranta_la_nr1.Location = New Point(222, 185)
        ComboBox_toleranta_la_nr1.Name = "ComboBox_toleranta_la_nr1"
        ComboBox_toleranta_la_nr1.Size = New Size(162, 23)
        ComboBox_toleranta_la_nr1.TabIndex = 21
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(390, 166)
        Label5.Name = "Label5"
        Label5.Size = New Size(76, 15)
        Label5.TabIndex = 24
        Label5.Text = "Toleranță la..."
        ' 
        ' ComboBox_toleranta_la_nr2
        ' 
        ComboBox_toleranta_la_nr2.FormattingEnabled = True
        ComboBox_toleranta_la_nr2.Location = New Point(390, 184)
        ComboBox_toleranta_la_nr2.Name = "ComboBox_toleranta_la_nr2"
        ComboBox_toleranta_la_nr2.Size = New Size(162, 23)
        ComboBox_toleranta_la_nr2.TabIndex = 23
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(568, 167)
        Label6.Name = "Label6"
        Label6.Size = New Size(76, 15)
        Label6.TabIndex = 26
        Label6.Text = "Toleranță la..."
        ' 
        ' ComboBox_toleranta_la_nr3
        ' 
        ComboBox_toleranta_la_nr3.FormattingEnabled = True
        ComboBox_toleranta_la_nr3.Location = New Point(568, 184)
        ComboBox_toleranta_la_nr3.Name = "ComboBox_toleranta_la_nr3"
        ComboBox_toleranta_la_nr3.Size = New Size(162, 23)
        ComboBox_toleranta_la_nr3.TabIndex = 25
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(53, 167)
        Label7.Name = "Label7"
        Label7.Size = New Size(94, 15)
        Label7.TabIndex = 28
        Label7.Text = "Clasa de precizie"
        ' 
        ' combobox_clasa_precizie
        ' 
        combobox_clasa_precizie.FormattingEnabled = True
        combobox_clasa_precizie.Location = New Point(53, 185)
        combobox_clasa_precizie.Name = "combobox_clasa_precizie"
        combobox_clasa_precizie.Size = New Size(114, 23)
        combobox_clasa_precizie.TabIndex = 27
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(53, 217)
        Label9.Name = "Label9"
        Label9.Size = New Size(101, 15)
        Label9.TabIndex = 30
        Label9.Text = "Clasa de toleranță"
        ' 
        ' combobox_clasa_toleranta_hkl
        ' 
        combobox_clasa_toleranta_hkl.FormattingEnabled = True
        combobox_clasa_toleranta_hkl.Location = New Point(53, 235)
        combobox_clasa_toleranta_hkl.Name = "combobox_clasa_toleranta_hkl"
        combobox_clasa_toleranta_hkl.Size = New Size(114, 23)
        combobox_clasa_toleranta_hkl.TabIndex = 29
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(568, 217)
        Label10.Name = "Label10"
        Label10.Size = New Size(76, 15)
        Label10.TabIndex = 36
        Label10.Text = "Toleranță la..."
        ' 
        ' ComboBox_toleranta_la_nr6
        ' 
        ComboBox_toleranta_la_nr6.FormattingEnabled = True
        ComboBox_toleranta_la_nr6.Location = New Point(568, 234)
        ComboBox_toleranta_la_nr6.Name = "ComboBox_toleranta_la_nr6"
        ComboBox_toleranta_la_nr6.Size = New Size(162, 23)
        ComboBox_toleranta_la_nr6.TabIndex = 35
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(390, 216)
        Label11.Name = "Label11"
        Label11.Size = New Size(76, 15)
        Label11.TabIndex = 34
        Label11.Text = "Toleranță la..."
        ' 
        ' ComboBox_toleranta_la_nr5
        ' 
        ComboBox_toleranta_la_nr5.FormattingEnabled = True
        ComboBox_toleranta_la_nr5.Location = New Point(390, 234)
        ComboBox_toleranta_la_nr5.Name = "ComboBox_toleranta_la_nr5"
        ComboBox_toleranta_la_nr5.Size = New Size(162, 23)
        ComboBox_toleranta_la_nr5.TabIndex = 33
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(222, 217)
        Label12.Name = "Label12"
        Label12.Size = New Size(76, 15)
        Label12.TabIndex = 32
        Label12.Text = "Toleranță la..."
        ' 
        ' ComboBox_toleranta_la_nr4
        ' 
        ComboBox_toleranta_la_nr4.FormattingEnabled = True
        ComboBox_toleranta_la_nr4.Location = New Point(222, 235)
        ComboBox_toleranta_la_nr4.Name = "ComboBox_toleranta_la_nr4"
        ComboBox_toleranta_la_nr4.Size = New Size(162, 23)
        ComboBox_toleranta_la_nr4.TabIndex = 31
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(655, 123)
        Label13.Name = "Label13"
        Label13.Size = New Size(133, 15)
        Label13.TabIndex = 40
        Label13.Text = "Parametrii de rugozitate"
        ' 
        ' combobox_rugozitate
        ' 
        combobox_rugozitate.FormattingEnabled = True
        combobox_rugozitate.Location = New Point(655, 141)
        combobox_rugozitate.Name = "combobox_rugozitate"
        combobox_rugozitate.Size = New Size(114, 23)
        combobox_rugozitate.TabIndex = 39
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(655, 123)
        Label14.Name = "Label14"
        Label14.Size = New Size(119, 15)
        Label14.TabIndex = 38
        Label14.Text = "Abaterea inferioară ei"
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(655, 141)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(114, 23)
        ComboBox2.TabIndex = 37
        ' 
        ' switch_stas
        ' 
        switch_stas.AutoSize = True
        switch_stas.Location = New Point(583, 116)
        switch_stas.Name = "switch_stas"
        switch_stas.Size = New Size(51, 19)
        switch_stas.TabIndex = 41
        switch_stas.Text = "STAS"
        switch_stas.UseVisualStyleBackColor = True
        ' 
        ' cmb_iso_stas
        ' 
        cmb_iso_stas.FormattingEnabled = True
        cmb_iso_stas.Location = New Point(583, 141)
        cmb_iso_stas.Name = "cmb_iso_stas"
        cmb_iso_stas.Size = New Size(52, 23)
        cmb_iso_stas.TabIndex = 42
        ' 
        ' btn_reset
        ' 
        btn_reset.Location = New Point(520, 300)
        btn_reset.Name = "btn_reset"
        btn_reset.Size = New Size(68, 24)
        btn_reset.TabIndex = 43
        btn_reset.Text = "Reseteaza"
        btn_reset.UseVisualStyleBackColor = True
        ' 
        ' main_window
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 715)
        Controls.Add(btn_reset)
        Controls.Add(cmb_iso_stas)
        Controls.Add(switch_stas)
        Controls.Add(Label13)
        Controls.Add(combobox_rugozitate)
        Controls.Add(Label14)
        Controls.Add(ComboBox2)
        Controls.Add(Label10)
        Controls.Add(ComboBox_toleranta_la_nr6)
        Controls.Add(Label11)
        Controls.Add(ComboBox_toleranta_la_nr5)
        Controls.Add(Label12)
        Controls.Add(ComboBox_toleranta_la_nr4)
        Controls.Add(Label9)
        Controls.Add(combobox_clasa_toleranta_hkl)
        Controls.Add(Label7)
        Controls.Add(combobox_clasa_precizie)
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
    Friend WithEvents Label7 As Label
    Friend WithEvents combobox_clasa_precizie As ComboBox
    Friend WithEvents ToleranțeGeneraleLaRectilinitateȘiPlanitateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToleranțeGeneraleLaSimetrieToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToleranțeGeneraleLaPerpendicularitateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToleranțeGeneraleAleBătăiiSuprafețelorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label9 As Label
    Friend WithEvents combobox_clasa_toleranta_hkl As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ComboBox_toleranta_la_nr6 As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ComboBox_toleranta_la_nr5 As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents ComboBox_toleranta_la_nr4 As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents combobox_rugozitate As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ClaseleDeRugozitateȘiParametriiAsociațiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents switch_stas As CheckBox
    Friend WithEvents cmb_iso_stas As ComboBox
    Friend WithEvents CalculAjustajToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btn_reset As Button
End Class
