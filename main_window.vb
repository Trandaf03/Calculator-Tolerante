﻿Imports System.Globalization
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports Microsoft.VisualBasic.FileIO

Public Class main_window

    'valori in micrometrii
    Dim delta_values_abateri_alezaje As New List(Of abateri_fundamentale_alezaje_delta)
    'valori in micrometrii
    Dim values_abateri_alezaje As New List(Of abateri_fundamentale_alezaje)
    'valori in micrometrii
    Dim values_abateri_arbori As New List(Of abateri_fundamentale_arbori)
    'valori in milimetrii
    Dim values_abateri_cu_tesitura As New List(Of abateri_limita_generale)
    'valori in milimetrii
    Dim values_abateri_fara_tesitura As New List(Of abateri_limita_generale)
    'valori in micrometrii
    Dim values_tolerante_fundamentale_liniare As New List(Of tolerante_fundamentale)
    'valori in micrometrii
    Dim values_ToleranteRectilinePlanitateFormaProfiluluiSuprafetei As New List(Of claseI_XII)
    'valori in micrometrii
    Dim values_ToleranteCircularitateCilindritate As New List(Of claseI_XII)
    'valori in micrometrii
    Dim values_TolerantePozitiaNominalaCoaxialitateConcentritateSimetri As New List(Of claseI_XII)
    'valori in micrometrii
    Dim values_ToleranteParalelismPerpendicularitateInclinare As New List(Of claseI_XII)
    'valori in micrometrii
    Dim values_ToleranteindependenteDeDimensiuniAleBataiiRadiale As New List(Of claseI_XII)
    'valori in micrometrii
    Dim values_ToleranteindependenteDeDimensiuniAleBataiiFrontale As New List(Of claseI_XII)
    'valori in milimetrii
    Dim values_tolerante_generale_la_rectilinitate_si_planitate As New List(Of tol_HKL)
    Dim values_generale_la_simetrie As New List(Of tol_HKL)
    Dim values_generale_la_perpendicularitate As New List(Of tol_HKL)
    Dim values_generale_la_vataii_suprafetelor As New List(Of tol_HKL)
    Dim values_rugozitate As New List(Of rugozitate)


    Private Sub main_window_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        readDataDelta("tabel311_delta.csv", delta_values_abateri_alezaje)
        readDataAbateriFundamentaleAlezaje("tabel311.csv", values_abateri_alezaje)
        readDataAbateriFundamentaleArbori("tabel310.csv", values_abateri_arbori)
        readDataAbateriLimita("tabel39.csv", values_abateri_cu_tesitura)
        readDataAbateriLimita("tabel38.csv", values_abateri_fara_tesitura)
        readDataToleranteGenerale("tabel37.csv", values_tolerante_fundamentale_liniare)
        readClase_I_XII("tabel41.csv", values_ToleranteRectilinePlanitateFormaProfiluluiSuprafetei)
        readClase_I_XII("tabel42.csv", values_ToleranteCircularitateCilindritate)
        readClase_I_XII("tabelul61.csv", values_TolerantePozitiaNominalaCoaxialitateConcentritateSimetri)
        readClase_I_XII("tabelul62.csv", values_ToleranteParalelismPerpendicularitateInclinare)
        readClase_I_XII("tabelul63.csv", values_ToleranteindependenteDeDimensiuniAleBataiiRadiale)
        readClase_I_XII("tabelul64.csv", values_ToleranteindependenteDeDimensiuniAleBataiiFrontale)
        readHKL("tabel43.csv", values_tolerante_generale_la_rectilinitate_si_planitate)
        readHKL("tabel65.csv", values_generale_la_simetrie)
        readHKL("tabel66.csv", values_generale_la_perpendicularitate)
        readHKL("tabel67.csv", values_generale_la_vataii_suprafetelor)
        readRugozitate("tabelul55.csv", values_rugozitate)

        loadObjectsMenu()
        ShowFirstTimeMessage()

    End Sub

    Private Sub ShowFirstTimeMessage()
        Dim configFilePath As String = "config.txt"

        If Not File.Exists(configFilePath) Then
            ' Show the message box
            MessageBox.Show("Pentru a folosi această interfață nu este nevoie ca toate datele să fie introduse! În cazul în care lipsesc date importante, în momentul calculării valorilor va apărea o eroare.", "Atenție!", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Create the config file to indicate that the message has been shown
            Using writer As New StreamWriter(configFilePath)
                writer.Write("MessageShown=True")
            End Using
        End If
    End Sub
    Private Sub calculeaza(sender As Object, e As EventArgs) Handles buton_calculeaza.Click
        Dim dimensiune_piesa As Double
        If Double.TryParse(text_dimensiune.Text, dimensiune_piesa) Then
        Else
            MessageBox.Show("Dimensiunea nu este un număr real!")
            Return
        End If


        Dim toleranta_fundamentala As Double = 0
        Dim marime_toleranta_fundamentala As String = "µm"

        Dim abaterea_limita_generala As Double = 0
        Dim abatere_fundamentala_alezaj_EI As Double = 0
        Dim marimea_batere_fundamentala_alezaj_EI As String = "µm"
        Dim abatere_fundamentala_alezaj_ES As Double = 0
        Dim marimea_abatere_fundamentala_alezaj_ES As String = "µm"
        Dim abatere_fundamentala_arbore_ei As Double = 0
        Dim marimea_abatere_fundamentala_arbore_ei As String = "µm"
        Dim abatere_fundamentala_arbore_es As Double = 0
        Dim marimea_abatere_fundamentala_arbore_es As String = "µm"
        Dim delta As Double = 0
        Dim abatere_fundamentala_special_js As Double = 0
        Dim marimea_abatere_fundamentala_special_js As String = "µm"

        Dim tol_1_la As Double
        Dim tol_2_la As Double
        Dim tol_3_la As Double
        Dim tol_4_la As Double
        Dim tol_5_la As Double
        Dim tol_6_la As Double

        Dim tol_hkl_1 As Double
        Dim tol_hkl_2 As Double
        Dim tol_hkl_3 As Double
        Dim tol_hkl_4 As Double


        If combobox_treapta_toleranta_fundamentala.SelectedItem IsNot Nothing Then
            Dim toleranta_tinta As tolerante_fundamentale

            For Each tol As tolerante_fundamentale In values_tolerante_fundamentale_liniare
                If tol.DimensiuneDeLa <= dimensiune_piesa AndAlso tol.DimensiunePanaLa > dimensiune_piesa Then
                    toleranta_tinta = tol
                    Exit For
                End If
            Next

            If IsNothing(toleranta_tinta) Then
                toleranta_tinta = values_tolerante_fundamentale_liniare(values_tolerante_fundamentale_liniare.Count() - 1)
            End If

            Dim selectedValue As String = combobox_treapta_toleranta_fundamentala.SelectedItem.ToString()
            Select Case selectedValue
                Case "IT01"
                    toleranta_fundamentala = toleranta_tinta.IT01
                Case "IT0"
                    toleranta_fundamentala = toleranta_tinta.IT0
                Case "IT1"
                    toleranta_fundamentala = toleranta_tinta.IT1
                Case "IT2"
                    toleranta_fundamentala = toleranta_tinta.IT2
                Case "IT3"
                    toleranta_fundamentala = toleranta_tinta.IT3
                Case "IT4"
                    toleranta_fundamentala = toleranta_tinta.IT4
                Case "IT5"
                    toleranta_fundamentala = toleranta_tinta.IT5
                Case "IT6"
                    toleranta_fundamentala = toleranta_tinta.IT6
                Case "IT7"
                    toleranta_fundamentala = toleranta_tinta.IT7
                Case "IT8"
                    toleranta_fundamentala = toleranta_tinta.IT8
                Case "IT9"
                    toleranta_fundamentala = toleranta_tinta.IT9
                Case "IT10"
                    toleranta_fundamentala = toleranta_tinta.IT10
                Case "IT11"
                    toleranta_fundamentala = toleranta_tinta.IT11
                Case "IT12"
                    toleranta_fundamentala = toleranta_tinta.IT12
                Case "IT13"
                    toleranta_fundamentala = toleranta_tinta.IT13
                Case "IT14"
                    toleranta_fundamentala = toleranta_tinta.IT14
                Case "IT15"
                    toleranta_fundamentala = toleranta_tinta.IT15
                Case "IT16"
                    toleranta_fundamentala = toleranta_tinta.IT16
                Case "IT17"
                    toleranta_fundamentala = toleranta_tinta.IT17
                Case "IT18"
                    toleranta_fundamentala = toleranta_tinta.IT18
            End Select
        Else
            toleranta_fundamentala = 0
        End If




        If combobox_clasa_toleranta.SelectedItem IsNot Nothing Then

            Dim abaterea_limita_tinta_tesitura As abateri_limita_generale
            Dim abaterea_limita_tinta_faratesitura As abateri_limita_generale

            For Each abat As abateri_limita_generale In values_abateri_cu_tesitura
                If abat.DimensiuneDeLa <= dimensiune_piesa AndAlso abat.DimensiunePanaLa > dimensiune_piesa Then
                    abaterea_limita_tinta_tesitura = abat
                    Exit For
                End If
            Next

            If IsNothing(abaterea_limita_tinta_tesitura) Then
                abaterea_limita_tinta_tesitura = values_abateri_cu_tesitura(values_abateri_cu_tesitura.Count() - 1)
            End If

            For Each abat As abateri_limita_generale In values_abateri_fara_tesitura
                If abat.DimensiuneDeLa <= dimensiune_piesa AndAlso abat.DimensiunePanaLa > dimensiune_piesa Then
                    abaterea_limita_tinta_faratesitura = abat
                    Exit For
                End If
            Next

            If IsNothing(abaterea_limita_tinta_faratesitura) Then
                abaterea_limita_tinta_faratesitura = values_abateri_fara_tesitura(values_abateri_fara_tesitura.Count() - 1)
            End If

            Dim selectedValue As String = combobox_clasa_toleranta.SelectedItem.ToString()
            Select Case selectedValue
                Case "Fină (f)"
                    If checkbox_este_tesitura.Checked Then
                        abaterea_limita_generala = abaterea_limita_tinta_tesitura.f
                    Else
                        abaterea_limita_generala = abaterea_limita_tinta_faratesitura.f
                    End If
                Case "Mijlocie (m)"
                    If checkbox_este_tesitura.Checked Then
                        abaterea_limita_generala = abaterea_limita_tinta_tesitura.m
                    Else
                        abaterea_limita_generala = abaterea_limita_tinta_faratesitura.m
                    End If
                Case "Grosieră (c)"
                    If checkbox_este_tesitura.Checked Then
                        abaterea_limita_generala = abaterea_limita_tinta_tesitura.c
                    Else
                        abaterea_limita_generala = abaterea_limita_tinta_faratesitura.c
                    End If
                Case "Grosolană (v)"
                    If checkbox_este_tesitura.Checked Then
                        abaterea_limita_generala = abaterea_limita_tinta_tesitura.v
                    Else
                        abaterea_limita_generala = abaterea_limita_tinta_faratesitura.v
                    End If
            End Select
        Else
            abaterea_limita_generala = 0
        End If


        If combobox_tipul_piesei.SelectedItem IsNot Nothing Then
            If Double.TryParse(text_dimensiune.Text, dimensiune_piesa) Then
            Else
                MessageBox.Show("Dimensiunea nu este un număr real!")
                Return
            End If

            Dim abatere_fundamentala_alezaj_EI_TINTA As abateri_fundamentale_alezaje
            Dim abatere_fundamentala_alezaj_ES_TINTA As abateri_fundamentale_alezaje
            Dim abatere_fundamentala_arbore_es_TINTA As abateri_fundamentale_arbori
            Dim abatere_fundamentala_arbore_ei_TINTA As abateri_fundamentale_arbori
            Dim delta_tinta As abateri_fundamentale_alezaje_delta

            For Each abale As abateri_fundamentale_alezaje In values_abateri_alezaje
                If abale.DimensiuneDeLa <= dimensiune_piesa AndAlso abale.DimensiunePanaLa > dimensiune_piesa Then
                    abatere_fundamentala_alezaj_EI_TINTA = abale
                    Exit For
                End If
            Next
            If IsNothing(abatere_fundamentala_alezaj_EI_TINTA) Then
                abatere_fundamentala_alezaj_EI_TINTA = values_abateri_alezaje(values_abateri_alezaje.Count() - 1)
            End If

            For Each abale As abateri_fundamentale_alezaje In values_abateri_alezaje
                If abale.DimensiuneDeLa <= dimensiune_piesa AndAlso abale.DimensiunePanaLa > dimensiune_piesa Then
                    abatere_fundamentala_alezaj_ES_TINTA = abale
                    Exit For
                End If
            Next
            If IsNothing(abatere_fundamentala_alezaj_ES_TINTA) Then
                abatere_fundamentala_alezaj_ES_TINTA = values_abateri_alezaje(values_abateri_alezaje.Count() - 1)
            End If


            Debug.WriteLine(abatere_fundamentala_alezaj_ES_TINTA.A.value)



            For Each abaar As abateri_fundamentale_arbori In values_abateri_arbori
                If abaar.DimensiuneDeLa <= dimensiune_piesa AndAlso abaar.DimensiunePanaLa > dimensiune_piesa Then
                    abatere_fundamentala_arbore_es_TINTA = abaar
                    Exit For
                End If
            Next
            If IsNothing(abatere_fundamentala_arbore_es_TINTA) Then
                abatere_fundamentala_arbore_es_TINTA = values_abateri_arbori(values_abateri_arbori.Count() - 1)
            End If

            For Each abaar As abateri_fundamentale_arbori In values_abateri_arbori
                If abaar.DimensiuneDeLa <= dimensiune_piesa AndAlso abaar.DimensiunePanaLa > dimensiune_piesa Then
                    abatere_fundamentala_arbore_ei_TINTA = abaar
                    Exit For
                End If
            Next
            If IsNothing(abatere_fundamentala_arbore_ei_TINTA) Then
                abatere_fundamentala_arbore_ei_TINTA = values_abateri_arbori(values_abateri_arbori.Count() - 1)
            End If

            For Each deltacaut As abateri_fundamentale_alezaje_delta In delta_values_abateri_alezaje
                If deltacaut.DimensiuneDeLa <= dimensiune_piesa AndAlso deltacaut.DimensiunePanaLa > dimensiune_piesa Then
                    delta_tinta = deltacaut
                    Exit For
                End If
            Next
            If IsNothing(delta_tinta) Then
                delta_tinta = delta_values_abateri_alezaje(delta_values_abateri_alezaje.Count() - 1)
            End If

            Dim it_value As String
            Dim it_error_not_existing As Boolean = False
            If combobox_treapta_toleranta_fundamentala.SelectedItem IsNot Nothing Then
                it_value = combobox_treapta_toleranta_fundamentala.SelectedItem.ToString()
            Else
                MessageBox.Show("Selectează o treaptă de toleranțe!")
                Return
            End If

            If dimensiune_piesa <= 500 Then
                If it_value.Equals("IT3") Then
                    delta = delta_tinta.IT3
                ElseIf it_value.Equals("IT4") Then
                    delta = delta_tinta.IT4
                ElseIf it_value.Equals("IT5") Then
                    delta = delta_tinta.IT5
                ElseIf it_value.Equals("IT6") Then
                    delta = delta_tinta.IT6
                ElseIf it_value.Equals("IT7") Then
                    delta = delta_tinta.IT7
                ElseIf it_value.Equals("IT8") Then
                    delta = delta_tinta.IT8
                Else
                    delta = 0
                End If
            Else
                delta = 0
            End If


            If checkbox_arbore_es.SelectedItem IsNot Nothing Then
                Dim selectedValue_arbore_es As String = checkbox_arbore_es.SelectedItem.ToString()
                Select Case selectedValue_arbore_es
                    Case "a"
                        abatere_fundamentala_arbore_es = abatere_fundamentala_arbore_es_TINTA.a.value
                    Case "b"
                        abatere_fundamentala_arbore_es = abatere_fundamentala_arbore_es_TINTA.b.value
                    Case "c"
                        abatere_fundamentala_arbore_es = abatere_fundamentala_arbore_es_TINTA.c.value
                    Case "cd"
                        abatere_fundamentala_arbore_es = abatere_fundamentala_arbore_es_TINTA.cd.value
                    Case "d"
                        abatere_fundamentala_arbore_es = abatere_fundamentala_arbore_es_TINTA.d.value
                    Case "e"
                        abatere_fundamentala_arbore_es = abatere_fundamentala_arbore_es_TINTA.e.value
                    Case "ef"
                        abatere_fundamentala_arbore_es = abatere_fundamentala_arbore_es_TINTA.ef.value
                    Case "f"
                        abatere_fundamentala_arbore_es = abatere_fundamentala_arbore_es_TINTA.f.value
                    Case "fg"
                        abatere_fundamentala_arbore_es = abatere_fundamentala_arbore_es_TINTA.fg.value
                    Case "g"
                        abatere_fundamentala_arbore_es = abatere_fundamentala_arbore_es_TINTA.g.value
                    Case "h"
                        abatere_fundamentala_arbore_es = abatere_fundamentala_arbore_es_TINTA.h.value
                    Case "js"
                        Dim copie_it As String = it_value.Replace("IT", "")
                        If copie_it.Equals("01") Then
                            copie_it = "0"
                        End If
                        Dim nr_it As Integer = copie_it
                        Dim nr_afisare As Double = nr_it / 2
                        abatere_fundamentala_arbore_es = nr_afisare * -1
                        abatere_fundamentala_special_js = nr_afisare
                End Select

            End If
            If checkbox_arbore_ei.SelectedItem IsNot Nothing Then
                Dim selectedValue_arbore_ei As String = checkbox_arbore_ei.SelectedItem.ToString()
                Select Case selectedValue_arbore_ei
                    Case "j"
                        If it_value.Equals("IT5") OrElse it_value.Equals("IT6") Then
                            abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.j56.value
                        ElseIf it_value.Equals("IT7") Then
                            abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.j7.value
                        ElseIf it_value.Equals("IT8") Then
                            abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.j8.value
                        Else
                            abatere_fundamentala_arbore_ei = 0
                            it_error_not_existing = True
                        End If
                    Case "k"
                        If it_value.Equals("IT4") OrElse it_value.Equals("IT5") OrElse it_value.Equals("IT6") OrElse it_value.Equals("IT7") Then
                            abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.k4567.value
                        Else
                            abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.kfara4567.value
                        End If
                    Case "m"
                        abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.m.value
                    Case "n"
                        abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.n.value
                    Case "p"
                        abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.p.value
                    Case "r"
                        abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.r.value
                    Case "s"
                        abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.s.value
                    Case "t"
                        abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.t.value
                    Case "u"
                        abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.u.value
                    Case "v"
                        abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.v.value
                    Case "x"
                        abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.x.value
                    Case "y"
                        abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.y.value
                    Case "z"
                        abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.z.value
                    Case "za"
                        abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.za.value
                    Case "zb"
                        abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.zb.value
                    Case "zc"
                        abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei_TINTA.zc.value
                End Select
            End If
            If checkbox_alezaj_EI.SelectedItem IsNot Nothing Then
                Dim selectedValue_alezaj_EI As String = checkbox_alezaj_EI.SelectedItem.ToString()
                Select Case selectedValue_alezaj_EI
                    Case "A"
                        abatere_fundamentala_alezaj_EI = abatere_fundamentala_alezaj_EI_TINTA.A.value
                    Case "B"
                        abatere_fundamentala_alezaj_EI = abatere_fundamentala_alezaj_EI_TINTA.B.value
                    Case "C"
                        abatere_fundamentala_alezaj_EI = abatere_fundamentala_alezaj_EI_TINTA.C.value
                    Case "CD"
                        abatere_fundamentala_alezaj_EI = abatere_fundamentala_alezaj_EI_TINTA.CD.value
                    Case "D"
                        abatere_fundamentala_alezaj_EI = abatere_fundamentala_alezaj_EI_TINTA.D.value
                    Case "E"
                        abatere_fundamentala_alezaj_EI = abatere_fundamentala_alezaj_EI_TINTA.E.value
                    Case "EF"
                        abatere_fundamentala_alezaj_EI = abatere_fundamentala_alezaj_EI_TINTA.EF.value
                    Case "F"
                        abatere_fundamentala_alezaj_EI = abatere_fundamentala_alezaj_EI_TINTA.F.value
                    Case "FG"
                        abatere_fundamentala_alezaj_EI = abatere_fundamentala_alezaj_EI_TINTA.FG.value
                    Case "G"
                        abatere_fundamentala_alezaj_EI = abatere_fundamentala_alezaj_EI_TINTA.G.value
                    Case "H"
                        abatere_fundamentala_alezaj_EI = abatere_fundamentala_alezaj_EI_TINTA.H.value
                    Case "JS"
                        Dim copie_it As String = it_value.Replace("IT", "")
                        If copie_it.Equals("01") Then
                            copie_it = "0"
                        End If
                        Dim nr_it As Integer = copie_it
                        Dim nr_afisare As Double = nr_it / 2
                        abatere_fundamentala_arbore_es = nr_afisare * -1
                        abatere_fundamentala_special_js = nr_afisare
                End Select


            End If
            If checkbox_alezaj_ES.SelectedItem IsNot Nothing Then
                Dim selectedValue_alezaj_ES As String = checkbox_alezaj_ES.SelectedItem.ToString()
                Dim selectedValue_alezaj_ES_hasDelta As Boolean = False


                Select Case selectedValue_alezaj_ES
                    Case "J"
                        If it_value.Equals("IT6") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.J6.value
                        ElseIf it_value.Equals("IT7") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.J7.value
                        ElseIf it_value.Equals("IT8") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.J8.value
                        Else
                            abatere_fundamentala_alezaj_ES = 0
                            it_error_not_existing = True
                        End If
                    Case "K"
                        If it_value.Equals("IT01") OrElse it_value.Equals("IT0") OrElse it_value.Equals("IT1") OrElse it_value.Equals("IT2") OrElse it_value.Equals("IT3") OrElse it_value.Equals("IT4") OrElse it_value.Equals("IT5") OrElse it_value.Equals("IT6") OrElse it_value.Equals("IT7") OrElse it_value.Equals("IT8") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.K8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.K8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        Else
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.Kpeste8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.K8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        End If
                    Case "M"
                        If it_value.Equals("IT01") OrElse it_value.Equals("IT0") OrElse it_value.Equals("IT1") OrElse it_value.Equals("IT2") OrElse it_value.Equals("IT3") OrElse it_value.Equals("IT4") OrElse it_value.Equals("IT5") OrElse it_value.Equals("IT6") OrElse it_value.Equals("IT7") OrElse it_value.Equals("IT8") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.M8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.M8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        Else
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.Mpeste8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.Mpeste8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        End If
                    Case "N"
                        If it_value.Equals("IT01") OrElse it_value.Equals("IT0") OrElse it_value.Equals("IT1") OrElse it_value.Equals("IT2") OrElse it_value.Equals("IT3") OrElse it_value.Equals("IT4") OrElse it_value.Equals("IT5") OrElse it_value.Equals("IT6") OrElse it_value.Equals("IT7") OrElse it_value.Equals("IT8") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.N8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.N8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        Else
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.Npeste8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.Npeste8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        End If
                    Case "P"
                        If it_value.Equals("IT01") OrElse it_value.Equals("IT0") OrElse it_value.Equals("IT1") OrElse it_value.Equals("IT2") OrElse it_value.Equals("IT3") OrElse it_value.Equals("IT4") OrElse it_value.Equals("IT5") OrElse it_value.Equals("IT6") OrElse it_value.Equals("IT7") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.P8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.P8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        Else
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.Ppeste8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.Ppeste8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        End If
                    Case "R"
                        If it_value.Equals("IT01") OrElse it_value.Equals("IT0") OrElse it_value.Equals("IT1") OrElse it_value.Equals("IT2") OrElse it_value.Equals("IT3") OrElse it_value.Equals("IT4") OrElse it_value.Equals("IT5") OrElse it_value.Equals("IT6") OrElse it_value.Equals("IT7") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.R8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.R8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        Else
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.Rpeste8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.Rpeste8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        End If
                    Case "S"
                        If it_value.Equals("IT01") OrElse it_value.Equals("IT0") OrElse it_value.Equals("IT1") OrElse it_value.Equals("IT2") OrElse it_value.Equals("IT3") OrElse it_value.Equals("IT4") OrElse it_value.Equals("IT5") OrElse it_value.Equals("IT6") OrElse it_value.Equals("IT7") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.S8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.S8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        Else
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.Speste8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.Speste8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        End If
                    Case "T"
                        If it_value.Equals("IT01") OrElse it_value.Equals("IT0") OrElse it_value.Equals("IT1") OrElse it_value.Equals("IT2") OrElse it_value.Equals("IT3") OrElse it_value.Equals("IT4") OrElse it_value.Equals("IT5") OrElse it_value.Equals("IT6") OrElse it_value.Equals("IT7") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.T8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.T8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        Else
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.Tpeste8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.Tpeste8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        End If
                    Case "U"
                        If it_value.Equals("IT01") OrElse it_value.Equals("IT0") OrElse it_value.Equals("IT1") OrElse it_value.Equals("IT2") OrElse it_value.Equals("IT3") OrElse it_value.Equals("IT4") OrElse it_value.Equals("IT5") OrElse it_value.Equals("IT6") OrElse it_value.Equals("IT7") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.U8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.U8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        Else
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.Upeste8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.Upeste8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        End If
                    Case "V"
                        If it_value.Equals("IT01") OrElse it_value.Equals("IT0") OrElse it_value.Equals("IT1") OrElse it_value.Equals("IT2") OrElse it_value.Equals("IT3") OrElse it_value.Equals("IT4") OrElse it_value.Equals("IT5") OrElse it_value.Equals("IT6") OrElse it_value.Equals("IT7") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.V8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.V8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        Else
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.Vpeste8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.Vpeste8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        End If
                    Case "X"
                        If it_value.Equals("IT01") OrElse it_value.Equals("IT0") OrElse it_value.Equals("IT1") OrElse it_value.Equals("IT2") OrElse it_value.Equals("IT3") OrElse it_value.Equals("IT4") OrElse it_value.Equals("IT5") OrElse it_value.Equals("IT6") OrElse it_value.Equals("IT7") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.X8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.X8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        Else
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.Xpeste8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.Xpeste8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        End If
                    Case "Y"
                        If it_value.Equals("IT01") OrElse it_value.Equals("IT0") OrElse it_value.Equals("IT1") OrElse it_value.Equals("IT2") OrElse it_value.Equals("IT3") OrElse it_value.Equals("IT4") OrElse it_value.Equals("IT5") OrElse it_value.Equals("IT6") OrElse it_value.Equals("IT7") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.Y8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.Y8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        Else
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.Ypeste8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.Ypeste8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        End If
                    Case "Z"
                        If it_value.Equals("IT01") OrElse it_value.Equals("IT0") OrElse it_value.Equals("IT1") OrElse it_value.Equals("IT2") OrElse it_value.Equals("IT3") OrElse it_value.Equals("IT4") OrElse it_value.Equals("IT5") OrElse it_value.Equals("IT6") OrElse it_value.Equals("IT7") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.Z8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.Z8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        Else
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.Zpeste8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.Zpeste8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        End If
                    Case "ZA"
                        If it_value.Equals("IT01") OrElse it_value.Equals("IT0") OrElse it_value.Equals("IT1") OrElse it_value.Equals("IT2") OrElse it_value.Equals("IT3") OrElse it_value.Equals("IT4") OrElse it_value.Equals("IT5") OrElse it_value.Equals("IT6") OrElse it_value.Equals("IT7") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.ZA8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.ZA8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        Else
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.ZApeste8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.ZApeste8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        End If
                    Case "ZB"
                        If it_value.Equals("IT01") OrElse it_value.Equals("IT0") OrElse it_value.Equals("IT1") OrElse it_value.Equals("IT2") OrElse it_value.Equals("IT3") OrElse it_value.Equals("IT4") OrElse it_value.Equals("IT5") OrElse it_value.Equals("IT6") OrElse it_value.Equals("IT7") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.ZB8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.ZB8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        Else
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.ZBpeste8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.ZBpeste8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        End If
                    Case "ZC"
                        If it_value.Equals("IT01") OrElse it_value.Equals("IT0") OrElse it_value.Equals("IT1") OrElse it_value.Equals("IT2") OrElse it_value.Equals("IT3") OrElse it_value.Equals("IT4") OrElse it_value.Equals("IT5") OrElse it_value.Equals("IT6") OrElse it_value.Equals("IT7") Then
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.ZC8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.ZC8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        Else
                            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES_TINTA.ZCpeste8.value
                            If abatere_fundamentala_alezaj_ES_TINTA.ZCpeste8.hasDelta Then
                                selectedValue_alezaj_ES_hasDelta = True
                            End If
                        End If
                End Select

                If selectedValue_alezaj_ES_hasDelta Then
                    abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES + delta
                End If


            End If


        Else
            abatere_fundamentala_alezaj_EI = 0
            abatere_fundamentala_alezaj_ES = 0
            abatere_fundamentala_arbore_ei = 0
            abatere_fundamentala_special_js = 0
            abatere_fundamentala_arbore_es = 0
            delta = 0
        End If


        If combobox_clasa_precizie.SelectedItem IsNot Nothing Then
            'values_ToleranteRectilinePlanitateFormaProfiluluiSuprafetei
            Dim target_1 As claseI_XII
            'values_ToleranteCircularitateCilindritate
            Dim target_2 As claseI_XII
            'values_TolerantePozitiaNominalaCoaxialitateConcentritateSimetri 
            Dim target_3 As claseI_XII
            'values_ToleranteParalelismPerpendicularitateInclinare
            Dim target_4 As claseI_XII
            'values_ToleranteindependenteDeDimensiuniAleBataiiRadiale
            Dim target_5 As claseI_XII
            'values_ToleranteindependenteDeDimensiuniAleBataiiFrontale
            Dim target_6 As claseI_XII

            For Each smth As claseI_XII In values_ToleranteRectilinePlanitateFormaProfiluluiSuprafetei
                If smth.DimensiuneDeLa <= dimensiune_piesa AndAlso smth.DimensiunePanaLa > dimensiune_piesa Then
                    target_1 = smth
                    Exit For
                End If
            Next
            For Each smth As claseI_XII In values_ToleranteCircularitateCilindritate
                If smth.DimensiuneDeLa <= dimensiune_piesa AndAlso smth.DimensiunePanaLa > dimensiune_piesa Then
                    target_2 = smth
                    Exit For
                End If
            Next
            For Each smth As claseI_XII In values_TolerantePozitiaNominalaCoaxialitateConcentritateSimetri
                If smth.DimensiuneDeLa <= dimensiune_piesa AndAlso smth.DimensiunePanaLa > dimensiune_piesa Then
                    target_3 = smth
                    Exit For
                End If
            Next
            For Each smth As claseI_XII In values_ToleranteParalelismPerpendicularitateInclinare
                If smth.DimensiuneDeLa <= dimensiune_piesa AndAlso smth.DimensiunePanaLa > dimensiune_piesa Then
                    target_4 = smth
                    Exit For
                End If
            Next
            For Each smth As claseI_XII In values_ToleranteindependenteDeDimensiuniAleBataiiRadiale
                If smth.DimensiuneDeLa <= dimensiune_piesa AndAlso smth.DimensiunePanaLa > dimensiune_piesa Then
                    target_5 = smth
                    Exit For
                End If
            Next
            For Each smth As claseI_XII In values_ToleranteindependenteDeDimensiuniAleBataiiFrontale
                If smth.DimensiuneDeLa <= dimensiune_piesa AndAlso smth.DimensiunePanaLa > dimensiune_piesa Then
                    target_6 = smth
                    Exit For
                End If
            Next

            If IsNothing(target_1) Then
                target_1 = values_ToleranteRectilinePlanitateFormaProfiluluiSuprafetei(values_ToleranteRectilinePlanitateFormaProfiluluiSuprafetei.Count() - 1)
            End If
            If IsNothing(target_2) Then
                target_2 = values_ToleranteCircularitateCilindritate(values_ToleranteCircularitateCilindritate.Count() - 1)
            End If
            If IsNothing(target_3) Then
                target_3 = values_TolerantePozitiaNominalaCoaxialitateConcentritateSimetri(values_TolerantePozitiaNominalaCoaxialitateConcentritateSimetri.Count() - 1)
            End If
            If IsNothing(target_4) Then
                target_4 = values_ToleranteParalelismPerpendicularitateInclinare(values_ToleranteParalelismPerpendicularitateInclinare.Count() - 1)
            End If
            If IsNothing(target_5) Then
                target_5 = values_ToleranteindependenteDeDimensiuniAleBataiiRadiale(values_ToleranteindependenteDeDimensiuniAleBataiiRadiale.Count() - 1)
            End If
            If IsNothing(target_6) Then
                target_6 = values_ToleranteindependenteDeDimensiuniAleBataiiFrontale(values_ToleranteindependenteDeDimensiuniAleBataiiFrontale.Count() - 1)
            End If

            Dim selectedValueIIXXII As String = combobox_clasa_precizie.SelectedItem.ToString()
            Select Case selectedValueIIXXII
                Case "I"
                    If ComboBox_toleranta_la_nr1.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr1.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_1_la = target_1.I
                            Case "Rectilinitate"
                                tol_1_la = target_1.I
                            Case "Forma profilului"
                                tol_1_la = target_1.I
                            Case "Forma suprafetei"
                                tol_1_la = target_1.I
                            Case "Circularitate"
                                tol_1_la = target_2.I
                            Case "Cilindricitate"
                                tol_1_la = target_2.I
                            Case "Pozitia nominala"
                                tol_1_la = target_3.I
                            Case "Coaxialitate"
                                tol_1_la = target_3.I
                            Case "Concentricitate"
                                tol_1_la = target_3.I
                            Case "Simetrie"
                                tol_1_la = target_3.I
                            Case "Paralelism"
                                tol_1_la = target_4.I
                            Case "Perpendicularitate"
                                tol_1_la = target_4.I
                            Case "Inclinare"
                                tol_1_la = target_4.I
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_1_la = target_5.I
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_1_la = target_6.I
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr2.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr2.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_2_la = target_1.I
                            Case "Rectilinitate"
                                tol_2_la = target_1.I
                            Case "Forma profilului"
                                tol_2_la = target_1.I
                            Case "Forma suprafetei"
                                tol_2_la = target_1.I
                            Case "Circularitate"
                                tol_2_la = target_2.I
                            Case "Cilindricitate"
                                tol_2_la = target_2.I
                            Case "Pozitia nominala"
                                tol_2_la = target_3.I
                            Case "Coaxialitate"
                                tol_2_la = target_3.I
                            Case "Concentricitate"
                                tol_2_la = target_3.I
                            Case "Simetrie"
                                tol_2_la = target_3.I
                            Case "Paralelism"
                                tol_2_la = target_4.I
                            Case "Perpendicularitate"
                                tol_2_la = target_4.I
                            Case "Inclinare"
                                tol_2_la = target_4.I
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_2_la = target_5.I
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_2_la = target_6.I
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr3.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr3.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_3_la = target_1.I
                            Case "Rectilinitate"
                                tol_3_la = target_1.I
                            Case "Forma profilului"
                                tol_3_la = target_1.I
                            Case "Forma suprafetei"
                                tol_3_la = target_1.I
                            Case "Circularitate"
                                tol_3_la = target_2.I
                            Case "Cilindricitate"
                                tol_3_la = target_2.I
                            Case "Pozitia nominala"
                                tol_3_la = target_3.I
                            Case "Coaxialitate"
                                tol_3_la = target_3.I
                            Case "Concentricitate"
                                tol_3_la = target_3.I
                            Case "Simetrie"
                                tol_3_la = target_3.I
                            Case "Paralelism"
                                tol_3_la = target_4.I
                            Case "Perpendicularitate"
                                tol_3_la = target_4.I
                            Case "Inclinare"
                                tol_3_la = target_4.I
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_3_la = target_5.I
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_3_la = target_6.I
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr4.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr4.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_4_la = target_1.I
                            Case "Rectilinitate"
                                tol_4_la = target_1.I
                            Case "Forma profilului"
                                tol_4_la = target_1.I
                            Case "Forma suprafetei"
                                tol_4_la = target_1.I
                            Case "Circularitate"
                                tol_4_la = target_2.I
                            Case "Cilindricitate"
                                tol_4_la = target_2.I
                            Case "Pozitia nominala"
                                tol_4_la = target_3.I
                            Case "Coaxialitate"
                                tol_4_la = target_3.I
                            Case "Concentricitate"
                                tol_4_la = target_3.I
                            Case "Simetrie"
                                tol_4_la = target_3.I
                            Case "Paralelism"
                                tol_4_la = target_4.I
                            Case "Perpendicularitate"
                                tol_4_la = target_4.I
                            Case "Inclinare"
                                tol_4_la = target_4.I
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_4_la = target_5.I
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_4_la = target_6.I
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr5.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr5.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_5_la = target_1.I
                            Case "Rectilinitate"
                                tol_5_la = target_1.I
                            Case "Forma profilului"
                                tol_5_la = target_1.I
                            Case "Forma suprafetei"
                                tol_5_la = target_1.I
                            Case "Circularitate"
                                tol_5_la = target_2.I
                            Case "Cilindricitate"
                                tol_5_la = target_2.I
                            Case "Pozitia nominala"
                                tol_5_la = target_3.I
                            Case "Coaxialitate"
                                tol_5_la = target_3.I
                            Case "Concentricitate"
                                tol_5_la = target_3.I
                            Case "Simetrie"
                                tol_5_la = target_3.I
                            Case "Paralelism"
                                tol_5_la = target_4.I
                            Case "Perpendicularitate"
                                tol_5_la = target_4.I
                            Case "Inclinare"
                                tol_5_la = target_4.I
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_5_la = target_5.I
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_5_la = target_6.I
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr6.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr6.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_6_la = target_1.I
                            Case "Rectilinitate"
                                tol_6_la = target_1.I
                            Case "Forma profilului"
                                tol_6_la = target_1.I
                            Case "Forma suprafetei"
                                tol_6_la = target_1.I
                            Case "Circularitate"
                                tol_6_la = target_2.I
                            Case "Cilindricitate"
                                tol_6_la = target_2.I
                            Case "Pozitia nominala"
                                tol_6_la = target_3.I
                            Case "Coaxialitate"
                                tol_6_la = target_3.I
                            Case "Concentricitate"
                                tol_6_la = target_3.I
                            Case "Simetrie"
                                tol_6_la = target_3.I
                            Case "Paralelism"
                                tol_6_la = target_4.I
                            Case "Perpendicularitate"
                                tol_6_la = target_4.I
                            Case "Inclinare"
                                tol_6_la = target_4.I
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_6_la = target_5.I
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_6_la = target_6.I
                        End Select
                    End If
                Case "II"
                    If ComboBox_toleranta_la_nr1.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr1.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_1_la = target_1.II
                            Case "Rectilinitate"
                                tol_1_la = target_1.II
                            Case "Forma profilului"
                                tol_1_la = target_1.II
                            Case "Forma suprafetei"
                                tol_1_la = target_1.II
                            Case "Circularitate"
                                tol_1_la = target_2.II
                            Case "Cilindricitate"
                                tol_1_la = target_2.II
                            Case "Pozitia nominala"
                                tol_1_la = target_3.II
                            Case "Coaxialitate"
                                tol_1_la = target_3.II
                            Case "Concentricitate"
                                tol_1_la = target_3.II
                            Case "Simetrie"
                                tol_1_la = target_3.II
                            Case "Paralelism"
                                tol_1_la = target_4.II
                            Case "Perpendicularitate"
                                tol_1_la = target_4.II
                            Case "Inclinare"
                                tol_1_la = target_4.II
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_1_la = target_5.II
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_1_la = target_6.II
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr2.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr2.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_2_la = target_1.II
                            Case "Rectilinitate"
                                tol_2_la = target_1.II
                            Case "Forma profilului"
                                tol_2_la = target_1.II
                            Case "Forma suprafetei"
                                tol_2_la = target_1.II
                            Case "Circularitate"
                                tol_2_la = target_2.II
                            Case "Cilindricitate"
                                tol_2_la = target_2.II
                            Case "Pozitia nominala"
                                tol_2_la = target_3.II
                            Case "Coaxialitate"
                                tol_2_la = target_3.II
                            Case "Concentricitate"
                                tol_2_la = target_3.II
                            Case "Simetrie"
                                tol_2_la = target_3.II
                            Case "Paralelism"
                                tol_2_la = target_4.II
                            Case "Perpendicularitate"
                                tol_2_la = target_4.II
                            Case "Inclinare"
                                tol_2_la = target_4.II
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_2_la = target_5.II
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_2_la = target_6.II
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr3.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr3.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_3_la = target_1.II
                            Case "Rectilinitate"
                                tol_3_la = target_1.II
                            Case "Forma profilului"
                                tol_3_la = target_1.II
                            Case "Forma suprafetei"
                                tol_3_la = target_1.II
                            Case "Circularitate"
                                tol_3_la = target_2.II
                            Case "Cilindricitate"
                                tol_3_la = target_2.II
                            Case "Pozitia nominala"
                                tol_3_la = target_3.II
                            Case "Coaxialitate"
                                tol_3_la = target_3.II
                            Case "Concentricitate"
                                tol_3_la = target_3.II
                            Case "Simetrie"
                                tol_3_la = target_3.II
                            Case "Paralelism"
                                tol_3_la = target_4.II
                            Case "Perpendicularitate"
                                tol_3_la = target_4.II
                            Case "Inclinare"
                                tol_3_la = target_4.II
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_3_la = target_5.II
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_3_la = target_6.II
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr4.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr4.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_4_la = target_1.II
                            Case "Rectilinitate"
                                tol_4_la = target_1.II
                            Case "Forma profilului"
                                tol_4_la = target_1.II
                            Case "Forma suprafetei"
                                tol_4_la = target_1.II
                            Case "Circularitate"
                                tol_4_la = target_2.II
                            Case "Cilindricitate"
                                tol_4_la = target_2.II
                            Case "Pozitia nominala"
                                tol_4_la = target_3.II
                            Case "Coaxialitate"
                                tol_4_la = target_3.II
                            Case "Concentricitate"
                                tol_4_la = target_3.II
                            Case "Simetrie"
                                tol_4_la = target_3.II
                            Case "Paralelism"
                                tol_4_la = target_4.II
                            Case "Perpendicularitate"
                                tol_4_la = target_4.II
                            Case "Inclinare"
                                tol_4_la = target_4.II
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_4_la = target_5.II
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_4_la = target_6.II
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr5.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr5.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_5_la = target_1.II
                            Case "Rectilinitate"
                                tol_5_la = target_1.II
                            Case "Forma profilului"
                                tol_5_la = target_1.II
                            Case "Forma suprafetei"
                                tol_5_la = target_1.II
                            Case "Circularitate"
                                tol_5_la = target_2.II
                            Case "Cilindricitate"
                                tol_5_la = target_2.II
                            Case "Pozitia nominala"
                                tol_5_la = target_3.II
                            Case "Coaxialitate"
                                tol_5_la = target_3.II
                            Case "Concentricitate"
                                tol_5_la = target_3.II
                            Case "Simetrie"
                                tol_5_la = target_3.II
                            Case "Paralelism"
                                tol_5_la = target_4.II
                            Case "Perpendicularitate"
                                tol_5_la = target_4.II
                            Case "Inclinare"
                                tol_5_la = target_4.II
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_5_la = target_5.II
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_5_la = target_6.II
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr6.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr6.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_6_la = target_1.II
                            Case "Rectilinitate"
                                tol_6_la = target_1.II
                            Case "Forma profilului"
                                tol_6_la = target_1.II
                            Case "Forma suprafetei"
                                tol_6_la = target_1.II
                            Case "Circularitate"
                                tol_6_la = target_2.II
                            Case "Cilindricitate"
                                tol_6_la = target_2.II
                            Case "Pozitia nominala"
                                tol_6_la = target_3.II
                            Case "Coaxialitate"
                                tol_6_la = target_3.II
                            Case "Concentricitate"
                                tol_6_la = target_3.II
                            Case "Simetrie"
                                tol_6_la = target_3.II
                            Case "Paralelism"
                                tol_6_la = target_4.II
                            Case "Perpendicularitate"
                                tol_6_la = target_4.II
                            Case "Inclinare"
                                tol_6_la = target_4.II
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_6_la = target_5.II
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_6_la = target_6.II
                        End Select
                    End If
                Case "III"
                    If ComboBox_toleranta_la_nr1.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr1.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_1_la = target_1.III
                            Case "Rectilinitate"
                                tol_1_la = target_1.III
                            Case "Forma profilului"
                                tol_1_la = target_1.III
                            Case "Forma suprafetei"
                                tol_1_la = target_1.III
                            Case "Circularitate"
                                tol_1_la = target_2.III
                            Case "Cilindricitate"
                                tol_1_la = target_2.III
                            Case "Pozitia nominala"
                                tol_1_la = target_3.III
                            Case "Coaxialitate"
                                tol_1_la = target_3.III
                            Case "Concentricitate"
                                tol_1_la = target_3.III
                            Case "Simetrie"
                                tol_1_la = target_3.III
                            Case "Paralelism"
                                tol_1_la = target_4.III
                            Case "Perpendicularitate"
                                tol_1_la = target_4.III
                            Case "Inclinare"
                                tol_1_la = target_4.III
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_1_la = target_5.III
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_1_la = target_6.III
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr2.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr2.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_2_la = target_1.III
                            Case "Rectilinitate"
                                tol_2_la = target_1.III
                            Case "Forma profilului"
                                tol_2_la = target_1.III
                            Case "Forma suprafetei"
                                tol_2_la = target_1.III
                            Case "Circularitate"
                                tol_2_la = target_2.III
                            Case "Cilindricitate"
                                tol_2_la = target_2.III
                            Case "Pozitia nominala"
                                tol_2_la = target_3.III
                            Case "Coaxialitate"
                                tol_2_la = target_3.III
                            Case "Concentricitate"
                                tol_2_la = target_3.III
                            Case "Simetrie"
                                tol_2_la = target_3.III
                            Case "Paralelism"
                                tol_2_la = target_4.III
                            Case "Perpendicularitate"
                                tol_2_la = target_4.III
                            Case "Inclinare"
                                tol_2_la = target_4.III
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_2_la = target_5.III
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_2_la = target_6.III
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr3.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr3.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_3_la = target_1.III
                            Case "Rectilinitate"
                                tol_3_la = target_1.III
                            Case "Forma profilului"
                                tol_3_la = target_1.III
                            Case "Forma suprafetei"
                                tol_3_la = target_1.III
                            Case "Circularitate"
                                tol_3_la = target_2.III
                            Case "Cilindricitate"
                                tol_3_la = target_2.III
                            Case "Pozitia nominala"
                                tol_3_la = target_3.III
                            Case "Coaxialitate"
                                tol_3_la = target_3.III
                            Case "Concentricitate"
                                tol_3_la = target_3.III
                            Case "Simetrie"
                                tol_3_la = target_3.III
                            Case "Paralelism"
                                tol_3_la = target_4.III
                            Case "Perpendicularitate"
                                tol_3_la = target_4.III
                            Case "Inclinare"
                                tol_3_la = target_4.III
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_3_la = target_5.III
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_3_la = target_6.III
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr4.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr4.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_4_la = target_1.III
                            Case "Rectilinitate"
                                tol_4_la = target_1.III
                            Case "Forma profilului"
                                tol_4_la = target_1.III
                            Case "Forma suprafetei"
                                tol_4_la = target_1.III
                            Case "Circularitate"
                                tol_4_la = target_2.III
                            Case "Cilindricitate"
                                tol_4_la = target_2.III
                            Case "Pozitia nominala"
                                tol_4_la = target_3.III
                            Case "Coaxialitate"
                                tol_4_la = target_3.III
                            Case "Concentricitate"
                                tol_4_la = target_3.III
                            Case "Simetrie"
                                tol_4_la = target_3.III
                            Case "Paralelism"
                                tol_4_la = target_4.III
                            Case "Perpendicularitate"
                                tol_4_la = target_4.III
                            Case "Inclinare"
                                tol_4_la = target_4.III
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_4_la = target_5.III
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_4_la = target_6.III
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr5.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr5.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_5_la = target_1.III
                            Case "Rectilinitate"
                                tol_5_la = target_1.III
                            Case "Forma profilului"
                                tol_5_la = target_1.III
                            Case "Forma suprafetei"
                                tol_5_la = target_1.III
                            Case "Circularitate"
                                tol_5_la = target_2.III
                            Case "Cilindricitate"
                                tol_5_la = target_2.III
                            Case "Pozitia nominala"
                                tol_5_la = target_3.III
                            Case "Coaxialitate"
                                tol_5_la = target_3.III
                            Case "Concentricitate"
                                tol_5_la = target_3.III
                            Case "Simetrie"
                                tol_5_la = target_3.III
                            Case "Paralelism"
                                tol_5_la = target_4.III
                            Case "Perpendicularitate"
                                tol_5_la = target_4.III
                            Case "Inclinare"
                                tol_5_la = target_4.III
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_5_la = target_5.III
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_5_la = target_6.III
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr6.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr6.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_6_la = target_1.III
                            Case "Rectilinitate"
                                tol_6_la = target_1.III
                            Case "Forma profilului"
                                tol_6_la = target_1.III
                            Case "Forma suprafetei"
                                tol_6_la = target_1.III
                            Case "Circularitate"
                                tol_6_la = target_2.III
                            Case "Cilindricitate"
                                tol_6_la = target_2.III
                            Case "Pozitia nominala"
                                tol_6_la = target_3.III
                            Case "Coaxialitate"
                                tol_6_la = target_3.III
                            Case "Concentricitate"
                                tol_6_la = target_3.III
                            Case "Simetrie"
                                tol_6_la = target_3.III
                            Case "Paralelism"
                                tol_6_la = target_4.III
                            Case "Perpendicularitate"
                                tol_6_la = target_4.III
                            Case "Inclinare"
                                tol_6_la = target_4.III
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_6_la = target_5.III
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_6_la = target_6.III
                        End Select
                    End If
                Case "IV"
                    If ComboBox_toleranta_la_nr1.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr1.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_1_la = target_1.IV
                            Case "Rectilinitate"
                                tol_1_la = target_1.IV
                            Case "Forma profilului"
                                tol_1_la = target_1.IV
                            Case "Forma suprafetei"
                                tol_1_la = target_1.IV
                            Case "Circularitate"
                                tol_1_la = target_2.IV
                            Case "Cilindricitate"
                                tol_1_la = target_2.IV
                            Case "Pozitia nominala"
                                tol_1_la = target_3.IV
                            Case "Coaxialitate"
                                tol_1_la = target_3.IV
                            Case "Concentricitate"
                                tol_1_la = target_3.IV
                            Case "Simetrie"
                                tol_1_la = target_3.IV
                            Case "Paralelism"
                                tol_1_la = target_4.IV
                            Case "Perpendicularitate"
                                tol_1_la = target_4.IV
                            Case "Inclinare"
                                tol_1_la = target_4.IV
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_1_la = target_5.IV
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_1_la = target_6.IV
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr2.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr2.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_2_la = target_1.IV
                            Case "Rectilinitate"
                                tol_2_la = target_1.IV
                            Case "Forma profilului"
                                tol_2_la = target_1.IV
                            Case "Forma suprafetei"
                                tol_2_la = target_1.IV
                            Case "Circularitate"
                                tol_2_la = target_2.IV
                            Case "Cilindricitate"
                                tol_2_la = target_2.IV
                            Case "Pozitia nominala"
                                tol_2_la = target_3.IV
                            Case "Coaxialitate"
                                tol_2_la = target_3.IV
                            Case "Concentricitate"
                                tol_2_la = target_3.IV
                            Case "Simetrie"
                                tol_2_la = target_3.IV
                            Case "Paralelism"
                                tol_2_la = target_4.IV
                            Case "Perpendicularitate"
                                tol_2_la = target_4.IV
                            Case "Inclinare"
                                tol_2_la = target_4.IV
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_2_la = target_5.IV
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_2_la = target_6.IV
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr3.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr3.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_3_la = target_1.IV
                            Case "Rectilinitate"
                                tol_3_la = target_1.IV
                            Case "Forma profilului"
                                tol_3_la = target_1.IV
                            Case "Forma suprafetei"
                                tol_3_la = target_1.IV
                            Case "Circularitate"
                                tol_3_la = target_2.IV
                            Case "Cilindricitate"
                                tol_3_la = target_2.IV
                            Case "Pozitia nominala"
                                tol_3_la = target_3.IV
                            Case "Coaxialitate"
                                tol_3_la = target_3.IV
                            Case "Concentricitate"
                                tol_3_la = target_3.IV
                            Case "Simetrie"
                                tol_3_la = target_3.IV
                            Case "Paralelism"
                                tol_3_la = target_4.IV
                            Case "Perpendicularitate"
                                tol_3_la = target_4.IV
                            Case "Inclinare"
                                tol_3_la = target_4.IV
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_3_la = target_5.IV
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_3_la = target_6.IV
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr4.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr4.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_4_la = target_1.IV
                            Case "Rectilinitate"
                                tol_4_la = target_1.IV
                            Case "Forma profilului"
                                tol_4_la = target_1.IV
                            Case "Forma suprafetei"
                                tol_4_la = target_1.IV
                            Case "Circularitate"
                                tol_4_la = target_2.IV
                            Case "Cilindricitate"
                                tol_4_la = target_2.IV
                            Case "Pozitia nominala"
                                tol_4_la = target_3.IV
                            Case "Coaxialitate"
                                tol_4_la = target_3.IV
                            Case "Concentricitate"
                                tol_4_la = target_3.IV
                            Case "Simetrie"
                                tol_4_la = target_3.IV
                            Case "Paralelism"
                                tol_4_la = target_4.IV
                            Case "Perpendicularitate"
                                tol_4_la = target_4.IV
                            Case "Inclinare"
                                tol_4_la = target_4.IV
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_4_la = target_5.IV
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_4_la = target_6.IV
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr5.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr5.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_5_la = target_1.IV
                            Case "Rectilinitate"
                                tol_5_la = target_1.IV
                            Case "Forma profilului"
                                tol_5_la = target_1.IV
                            Case "Forma suprafetei"
                                tol_5_la = target_1.IV
                            Case "Circularitate"
                                tol_5_la = target_2.IV
                            Case "Cilindricitate"
                                tol_5_la = target_2.IV
                            Case "Pozitia nominala"
                                tol_5_la = target_3.IV
                            Case "Coaxialitate"
                                tol_5_la = target_3.IV
                            Case "Concentricitate"
                                tol_5_la = target_3.IV
                            Case "Simetrie"
                                tol_5_la = target_3.IV
                            Case "Paralelism"
                                tol_5_la = target_4.IV
                            Case "Perpendicularitate"
                                tol_5_la = target_4.IV
                            Case "Inclinare"
                                tol_5_la = target_4.IV
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_5_la = target_5.IV
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_5_la = target_6.IV
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr6.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr6.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_6_la = target_1.IV
                            Case "Rectilinitate"
                                tol_6_la = target_1.IV
                            Case "Forma profilului"
                                tol_6_la = target_1.IV
                            Case "Forma suprafetei"
                                tol_6_la = target_1.IV
                            Case "Circularitate"
                                tol_6_la = target_2.IV
                            Case "Cilindricitate"
                                tol_6_la = target_2.IV
                            Case "Pozitia nominala"
                                tol_6_la = target_3.IV
                            Case "Coaxialitate"
                                tol_6_la = target_3.IV
                            Case "Concentricitate"
                                tol_6_la = target_3.IV
                            Case "Simetrie"
                                tol_6_la = target_3.IV
                            Case "Paralelism"
                                tol_6_la = target_4.IV
                            Case "Perpendicularitate"
                                tol_6_la = target_4.IV
                            Case "Inclinare"
                                tol_6_la = target_4.IV
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_6_la = target_5.IV
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_6_la = target_6.IV
                        End Select
                    End If
                Case "V"
                    If ComboBox_toleranta_la_nr1.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr1.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_1_la = target_1.V
                            Case "Rectilinitate"
                                tol_1_la = target_1.V
                            Case "Forma profilului"
                                tol_1_la = target_1.V
                            Case "Forma suprafetei"
                                tol_1_la = target_1.V
                            Case "Circularitate"
                                tol_1_la = target_2.V
                            Case "Cilindricitate"
                                tol_1_la = target_2.V
                            Case "Pozitia nominala"
                                tol_1_la = target_3.V
                            Case "Coaxialitate"
                                tol_1_la = target_3.V
                            Case "Concentricitate"
                                tol_1_la = target_3.V
                            Case "Simetrie"
                                tol_1_la = target_3.V
                            Case "Paralelism"
                                tol_1_la = target_4.V
                            Case "Perpendicularitate"
                                tol_1_la = target_4.V
                            Case "Inclinare"
                                tol_1_la = target_4.V
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_1_la = target_5.V
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_1_la = target_6.V
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr2.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr2.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_2_la = target_1.V
                            Case "Rectilinitate"
                                tol_2_la = target_1.V
                            Case "Forma profilului"
                                tol_2_la = target_1.V
                            Case "Forma suprafetei"
                                tol_2_la = target_1.V
                            Case "Circularitate"
                                tol_2_la = target_2.V
                            Case "Cilindricitate"
                                tol_2_la = target_2.V
                            Case "Pozitia nominala"
                                tol_2_la = target_3.V
                            Case "Coaxialitate"
                                tol_2_la = target_3.V
                            Case "Concentricitate"
                                tol_2_la = target_3.V
                            Case "Simetrie"
                                tol_2_la = target_3.V
                            Case "Paralelism"
                                tol_2_la = target_4.V
                            Case "Perpendicularitate"
                                tol_2_la = target_4.V
                            Case "Inclinare"
                                tol_2_la = target_4.V
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_2_la = target_5.V
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_2_la = target_6.V
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr3.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr3.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_3_la = target_1.V
                            Case "Rectilinitate"
                                tol_3_la = target_1.V
                            Case "Forma profilului"
                                tol_3_la = target_1.V
                            Case "Forma suprafetei"
                                tol_3_la = target_1.V
                            Case "Circularitate"
                                tol_3_la = target_2.V
                            Case "Cilindricitate"
                                tol_3_la = target_2.V
                            Case "Pozitia nominala"
                                tol_3_la = target_3.V
                            Case "Coaxialitate"
                                tol_3_la = target_3.V
                            Case "Concentricitate"
                                tol_3_la = target_3.V
                            Case "Simetrie"
                                tol_3_la = target_3.V
                            Case "Paralelism"
                                tol_3_la = target_4.V
                            Case "Perpendicularitate"
                                tol_3_la = target_4.V
                            Case "Inclinare"
                                tol_3_la = target_4.V
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_3_la = target_5.V
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_3_la = target_6.V
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr4.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr4.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_4_la = target_1.V
                            Case "Rectilinitate"
                                tol_4_la = target_1.V
                            Case "Forma profilului"
                                tol_4_la = target_1.V
                            Case "Forma suprafetei"
                                tol_4_la = target_1.V
                            Case "Circularitate"
                                tol_4_la = target_2.V
                            Case "Cilindricitate"
                                tol_4_la = target_2.V
                            Case "Pozitia nominala"
                                tol_4_la = target_3.V
                            Case "Coaxialitate"
                                tol_4_la = target_3.V
                            Case "Concentricitate"
                                tol_4_la = target_3.V
                            Case "Simetrie"
                                tol_4_la = target_3.V
                            Case "Paralelism"
                                tol_4_la = target_4.V
                            Case "Perpendicularitate"
                                tol_4_la = target_4.V
                            Case "Inclinare"
                                tol_4_la = target_4.V
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_4_la = target_5.V
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_4_la = target_6.V
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr5.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr5.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_5_la = target_1.V
                            Case "Rectilinitate"
                                tol_5_la = target_1.V
                            Case "Forma profilului"
                                tol_5_la = target_1.V
                            Case "Forma suprafetei"
                                tol_5_la = target_1.V
                            Case "Circularitate"
                                tol_5_la = target_2.V
                            Case "Cilindricitate"
                                tol_5_la = target_2.V
                            Case "Pozitia nominala"
                                tol_5_la = target_3.V
                            Case "Coaxialitate"
                                tol_5_la = target_3.V
                            Case "Concentricitate"
                                tol_5_la = target_3.V
                            Case "Simetrie"
                                tol_5_la = target_3.V
                            Case "Paralelism"
                                tol_5_la = target_4.V
                            Case "Perpendicularitate"
                                tol_5_la = target_4.V
                            Case "Inclinare"
                                tol_5_la = target_4.V
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_5_la = target_5.V
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_5_la = target_6.V
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr6.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr6.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_6_la = target_1.V
                            Case "Rectilinitate"
                                tol_6_la = target_1.V
                            Case "Forma profilului"
                                tol_6_la = target_1.V
                            Case "Forma suprafetei"
                                tol_6_la = target_1.V
                            Case "Circularitate"
                                tol_6_la = target_2.V
                            Case "Cilindricitate"
                                tol_6_la = target_2.V
                            Case "Pozitia nominala"
                                tol_6_la = target_3.V
                            Case "Coaxialitate"
                                tol_6_la = target_3.V
                            Case "Concentricitate"
                                tol_6_la = target_3.V
                            Case "Simetrie"
                                tol_6_la = target_3.V
                            Case "Paralelism"
                                tol_6_la = target_4.V
                            Case "Perpendicularitate"
                                tol_6_la = target_4.V
                            Case "Inclinare"
                                tol_6_la = target_4.V
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_6_la = target_5.V
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_6_la = target_6.V
                        End Select
                    End If
                Case "VI"
                    If ComboBox_toleranta_la_nr1.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr1.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_1_la = target_1.VI
                            Case "Rectilinitate"
                                tol_1_la = target_1.VI
                            Case "Forma profilului"
                                tol_1_la = target_1.VI
                            Case "Forma suprafetei"
                                tol_1_la = target_1.VI
                            Case "Circularitate"
                                tol_1_la = target_2.VI
                            Case "Cilindricitate"
                                tol_1_la = target_2.VI
                            Case "Pozitia nominala"
                                tol_1_la = target_3.VI
                            Case "Coaxialitate"
                                tol_1_la = target_3.VI
                            Case "Concentricitate"
                                tol_1_la = target_3.VI
                            Case "Simetrie"
                                tol_1_la = target_3.VI
                            Case "Paralelism"
                                tol_1_la = target_4.VI
                            Case "Perpendicularitate"
                                tol_1_la = target_4.VI
                            Case "Inclinare"
                                tol_1_la = target_4.VI
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_1_la = target_5.VI
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_1_la = target_6.VI
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr2.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr2.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_2_la = target_1.VI
                            Case "Rectilinitate"
                                tol_2_la = target_1.VI
                            Case "Forma profilului"
                                tol_2_la = target_1.VI
                            Case "Forma suprafetei"
                                tol_2_la = target_1.VI
                            Case "Circularitate"
                                tol_2_la = target_2.VI
                            Case "Cilindricitate"
                                tol_2_la = target_2.VI
                            Case "Pozitia nominala"
                                tol_2_la = target_3.VI
                            Case "Coaxialitate"
                                tol_2_la = target_3.VI
                            Case "Concentricitate"
                                tol_2_la = target_3.VI
                            Case "Simetrie"
                                tol_2_la = target_3.VI
                            Case "Paralelism"
                                tol_2_la = target_4.VI
                            Case "Perpendicularitate"
                                tol_2_la = target_4.VI
                            Case "Inclinare"
                                tol_2_la = target_4.VI
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_2_la = target_5.VI
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_2_la = target_6.VI
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr3.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr3.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_3_la = target_1.VI
                            Case "Rectilinitate"
                                tol_3_la = target_1.VI
                            Case "Forma profilului"
                                tol_3_la = target_1.VI
                            Case "Forma suprafetei"
                                tol_3_la = target_1.VI
                            Case "Circularitate"
                                tol_3_la = target_2.VI
                            Case "Cilindricitate"
                                tol_3_la = target_2.VI
                            Case "Pozitia nominala"
                                tol_3_la = target_3.VI
                            Case "Coaxialitate"
                                tol_3_la = target_3.VI
                            Case "Concentricitate"
                                tol_3_la = target_3.VI
                            Case "Simetrie"
                                tol_3_la = target_3.VI
                            Case "Paralelism"
                                tol_3_la = target_4.VI
                            Case "Perpendicularitate"
                                tol_3_la = target_4.VI
                            Case "Inclinare"
                                tol_3_la = target_4.VI
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_3_la = target_5.VI
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_3_la = target_6.VI
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr4.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr4.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_4_la = target_1.VI
                            Case "Rectilinitate"
                                tol_4_la = target_1.VI
                            Case "Forma profilului"
                                tol_4_la = target_1.VI
                            Case "Forma suprafetei"
                                tol_4_la = target_1.VI
                            Case "Circularitate"
                                tol_4_la = target_2.VI
                            Case "Cilindricitate"
                                tol_4_la = target_2.VI
                            Case "Pozitia nominala"
                                tol_4_la = target_3.VI
                            Case "Coaxialitate"
                                tol_4_la = target_3.VI
                            Case "Concentricitate"
                                tol_4_la = target_3.VI
                            Case "Simetrie"
                                tol_4_la = target_3.VI
                            Case "Paralelism"
                                tol_4_la = target_4.VI
                            Case "Perpendicularitate"
                                tol_4_la = target_4.VI
                            Case "Inclinare"
                                tol_4_la = target_4.VI
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_4_la = target_5.VI
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_4_la = target_6.VI
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr5.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr5.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_5_la = target_1.VI
                            Case "Rectilinitate"
                                tol_5_la = target_1.VI
                            Case "Forma profilului"
                                tol_5_la = target_1.VI
                            Case "Forma suprafetei"
                                tol_5_la = target_1.VI
                            Case "Circularitate"
                                tol_5_la = target_2.VI
                            Case "Cilindricitate"
                                tol_5_la = target_2.VI
                            Case "Pozitia nominala"
                                tol_5_la = target_3.VI
                            Case "Coaxialitate"
                                tol_5_la = target_3.VI
                            Case "Concentricitate"
                                tol_5_la = target_3.VI
                            Case "Simetrie"
                                tol_5_la = target_3.VI
                            Case "Paralelism"
                                tol_5_la = target_4.VI
                            Case "Perpendicularitate"
                                tol_5_la = target_4.VI
                            Case "Inclinare"
                                tol_5_la = target_4.VI
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_5_la = target_5.VI
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_5_la = target_6.VI
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr6.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr6.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_6_la = target_1.VI
                            Case "Rectilinitate"
                                tol_6_la = target_1.VI
                            Case "Forma profilului"
                                tol_6_la = target_1.VI
                            Case "Forma suprafetei"
                                tol_6_la = target_1.VI
                            Case "Circularitate"
                                tol_6_la = target_2.VI
                            Case "Cilindricitate"
                                tol_6_la = target_2.VI
                            Case "Pozitia nominala"
                                tol_6_la = target_3.VI
                            Case "Coaxialitate"
                                tol_6_la = target_3.VI
                            Case "Concentricitate"
                                tol_6_la = target_3.VI
                            Case "Simetrie"
                                tol_6_la = target_3.VI
                            Case "Paralelism"
                                tol_6_la = target_4.VI
                            Case "Perpendicularitate"
                                tol_6_la = target_4.VI
                            Case "Inclinare"
                                tol_6_la = target_4.VI
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_6_la = target_5.VI
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_6_la = target_6.VI
                        End Select
                    End If
                Case "VII"
                    If ComboBox_toleranta_la_nr1.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr1.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_1_la = target_1.VII
                            Case "Rectilinitate"
                                tol_1_la = target_1.VII
                            Case "Forma profilului"
                                tol_1_la = target_1.VII
                            Case "Forma suprafetei"
                                tol_1_la = target_1.VII
                            Case "Circularitate"
                                tol_1_la = target_2.VII
                            Case "Cilindricitate"
                                tol_1_la = target_2.VII
                            Case "Pozitia nominala"
                                tol_1_la = target_3.VII
                            Case "Coaxialitate"
                                tol_1_la = target_3.VII
                            Case "Concentricitate"
                                tol_1_la = target_3.VII
                            Case "Simetrie"
                                tol_1_la = target_3.VII
                            Case "Paralelism"
                                tol_1_la = target_4.VII
                            Case "Perpendicularitate"
                                tol_1_la = target_4.VII
                            Case "Inclinare"
                                tol_1_la = target_4.VII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_1_la = target_5.VII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_1_la = target_6.VII
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr2.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr2.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_2_la = target_1.VII
                            Case "Rectilinitate"
                                tol_2_la = target_1.VII
                            Case "Forma profilului"
                                tol_2_la = target_1.VII
                            Case "Forma suprafetei"
                                tol_2_la = target_1.VII
                            Case "Circularitate"
                                tol_2_la = target_2.VII
                            Case "Cilindricitate"
                                tol_2_la = target_2.VII
                            Case "Pozitia nominala"
                                tol_2_la = target_3.VII
                            Case "Coaxialitate"
                                tol_2_la = target_3.VII
                            Case "Concentricitate"
                                tol_2_la = target_3.VII
                            Case "Simetrie"
                                tol_2_la = target_3.VII
                            Case "Paralelism"
                                tol_2_la = target_4.VII
                            Case "Perpendicularitate"
                                tol_2_la = target_4.VII
                            Case "Inclinare"
                                tol_2_la = target_4.VII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_2_la = target_5.VII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_2_la = target_6.VII
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr3.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr3.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_3_la = target_1.VII
                            Case "Rectilinitate"
                                tol_3_la = target_1.VII
                            Case "Forma profilului"
                                tol_3_la = target_1.VII
                            Case "Forma suprafetei"
                                tol_3_la = target_1.VII
                            Case "Circularitate"
                                tol_3_la = target_2.VII
                            Case "Cilindricitate"
                                tol_3_la = target_2.VII
                            Case "Pozitia nominala"
                                tol_3_la = target_3.VII
                            Case "Coaxialitate"
                                tol_3_la = target_3.VII
                            Case "Concentricitate"
                                tol_3_la = target_3.VII
                            Case "Simetrie"
                                tol_3_la = target_3.VII
                            Case "Paralelism"
                                tol_3_la = target_4.VII
                            Case "Perpendicularitate"
                                tol_3_la = target_4.VII
                            Case "Inclinare"
                                tol_3_la = target_4.VII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_3_la = target_5.VII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_3_la = target_6.VII
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr4.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr4.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_4_la = target_1.VII
                            Case "Rectilinitate"
                                tol_4_la = target_1.VII
                            Case "Forma profilului"
                                tol_4_la = target_1.VII
                            Case "Forma suprafetei"
                                tol_4_la = target_1.VII
                            Case "Circularitate"
                                tol_4_la = target_2.VII
                            Case "Cilindricitate"
                                tol_4_la = target_2.VII
                            Case "Pozitia nominala"
                                tol_4_la = target_3.VII
                            Case "Coaxialitate"
                                tol_4_la = target_3.VII
                            Case "Concentricitate"
                                tol_4_la = target_3.VII
                            Case "Simetrie"
                                tol_4_la = target_3.VII
                            Case "Paralelism"
                                tol_4_la = target_4.VII
                            Case "Perpendicularitate"
                                tol_4_la = target_4.VII
                            Case "Inclinare"
                                tol_4_la = target_4.VII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_4_la = target_5.VII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_4_la = target_6.VII
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr5.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr5.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_5_la = target_1.VII
                            Case "Rectilinitate"
                                tol_5_la = target_1.VII
                            Case "Forma profilului"
                                tol_5_la = target_1.VII
                            Case "Forma suprafetei"
                                tol_5_la = target_1.VII
                            Case "Circularitate"
                                tol_5_la = target_2.VII
                            Case "Cilindricitate"
                                tol_5_la = target_2.VII
                            Case "Pozitia nominala"
                                tol_5_la = target_3.VII
                            Case "Coaxialitate"
                                tol_5_la = target_3.VII
                            Case "Concentricitate"
                                tol_5_la = target_3.VII
                            Case "Simetrie"
                                tol_5_la = target_3.VII
                            Case "Paralelism"
                                tol_5_la = target_4.VII
                            Case "Perpendicularitate"
                                tol_5_la = target_4.VII
                            Case "Inclinare"
                                tol_5_la = target_4.VII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_5_la = target_5.VII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_5_la = target_6.VII
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr6.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr6.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_6_la = target_1.VII
                            Case "Rectilinitate"
                                tol_6_la = target_1.VII
                            Case "Forma profilului"
                                tol_6_la = target_1.VII
                            Case "Forma suprafetei"
                                tol_6_la = target_1.VII
                            Case "Circularitate"
                                tol_6_la = target_2.VII
                            Case "Cilindricitate"
                                tol_6_la = target_2.VII
                            Case "Pozitia nominala"
                                tol_6_la = target_3.VII
                            Case "Coaxialitate"
                                tol_6_la = target_3.VII
                            Case "Concentricitate"
                                tol_6_la = target_3.VII
                            Case "Simetrie"
                                tol_6_la = target_3.VII
                            Case "Paralelism"
                                tol_6_la = target_4.VII
                            Case "Perpendicularitate"
                                tol_6_la = target_4.VII
                            Case "Inclinare"
                                tol_6_la = target_4.VII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_6_la = target_5.VII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_6_la = target_6.VII
                        End Select
                    End If
                Case "VIII"
                    If ComboBox_toleranta_la_nr1.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr1.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_1_la = target_1.VIII
                            Case "Rectilinitate"
                                tol_1_la = target_1.VIII
                            Case "Forma profilului"
                                tol_1_la = target_1.VIII
                            Case "Forma suprafetei"
                                tol_1_la = target_1.VIII
                            Case "Circularitate"
                                tol_1_la = target_2.VIII
                            Case "Cilindricitate"
                                tol_1_la = target_2.VIII
                            Case "Pozitia nominala"
                                tol_1_la = target_3.VIII
                            Case "Coaxialitate"
                                tol_1_la = target_3.VIII
                            Case "Concentricitate"
                                tol_1_la = target_3.VIII
                            Case "Simetrie"
                                tol_1_la = target_3.VIII
                            Case "Paralelism"
                                tol_1_la = target_4.VIII
                            Case "Perpendicularitate"
                                tol_1_la = target_4.VIII
                            Case "Inclinare"
                                tol_1_la = target_4.VIII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_1_la = target_5.VIII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_1_la = target_6.VIII
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr2.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr2.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_2_la = target_1.VIII
                            Case "Rectilinitate"
                                tol_2_la = target_1.VIII
                            Case "Forma profilului"
                                tol_2_la = target_1.VIII
                            Case "Forma suprafetei"
                                tol_2_la = target_1.VIII
                            Case "Circularitate"
                                tol_2_la = target_2.VIII
                            Case "Cilindricitate"
                                tol_2_la = target_2.VIII
                            Case "Pozitia nominala"
                                tol_2_la = target_3.VIII
                            Case "Coaxialitate"
                                tol_2_la = target_3.VIII
                            Case "Concentricitate"
                                tol_2_la = target_3.VIII
                            Case "Simetrie"
                                tol_2_la = target_3.VIII
                            Case "Paralelism"
                                tol_2_la = target_4.VIII
                            Case "Perpendicularitate"
                                tol_2_la = target_4.VIII
                            Case "Inclinare"
                                tol_2_la = target_4.VIII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_2_la = target_5.VIII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_2_la = target_6.VIII
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr3.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr3.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_3_la = target_1.VIII
                            Case "Rectilinitate"
                                tol_3_la = target_1.VIII
                            Case "Forma profilului"
                                tol_3_la = target_1.VIII
                            Case "Forma suprafetei"
                                tol_3_la = target_1.VIII
                            Case "Circularitate"
                                tol_3_la = target_2.VIII
                            Case "Cilindricitate"
                                tol_3_la = target_2.VIII
                            Case "Pozitia nominala"
                                tol_3_la = target_3.VIII
                            Case "Coaxialitate"
                                tol_3_la = target_3.VIII
                            Case "Concentricitate"
                                tol_3_la = target_3.VIII
                            Case "Simetrie"
                                tol_3_la = target_3.VIII
                            Case "Paralelism"
                                tol_3_la = target_4.VIII
                            Case "Perpendicularitate"
                                tol_3_la = target_4.VIII
                            Case "Inclinare"
                                tol_3_la = target_4.VIII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_3_la = target_5.VIII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_3_la = target_6.VIII
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr4.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr4.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_4_la = target_1.VIII
                            Case "Rectilinitate"
                                tol_4_la = target_1.VIII
                            Case "Forma profilului"
                                tol_4_la = target_1.VIII
                            Case "Forma suprafetei"
                                tol_4_la = target_1.VIII
                            Case "Circularitate"
                                tol_4_la = target_2.VIII
                            Case "Cilindricitate"
                                tol_4_la = target_2.VIII
                            Case "Pozitia nominala"
                                tol_4_la = target_3.VIII
                            Case "Coaxialitate"
                                tol_4_la = target_3.VIII
                            Case "Concentricitate"
                                tol_4_la = target_3.VIII
                            Case "Simetrie"
                                tol_4_la = target_3.VIII
                            Case "Paralelism"
                                tol_4_la = target_4.VIII
                            Case "Perpendicularitate"
                                tol_4_la = target_4.VIII
                            Case "Inclinare"
                                tol_4_la = target_4.VIII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_4_la = target_5.VIII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_4_la = target_6.VIII
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr5.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr5.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_5_la = target_1.VIII
                            Case "Rectilinitate"
                                tol_5_la = target_1.VIII
                            Case "Forma profilului"
                                tol_5_la = target_1.VIII
                            Case "Forma suprafetei"
                                tol_5_la = target_1.VIII
                            Case "Circularitate"
                                tol_5_la = target_2.VIII
                            Case "Cilindricitate"
                                tol_5_la = target_2.VIII
                            Case "Pozitia nominala"
                                tol_5_la = target_3.VIII
                            Case "Coaxialitate"
                                tol_5_la = target_3.VIII
                            Case "Concentricitate"
                                tol_5_la = target_3.VIII
                            Case "Simetrie"
                                tol_5_la = target_3.VIII
                            Case "Paralelism"
                                tol_5_la = target_4.VIII
                            Case "Perpendicularitate"
                                tol_5_la = target_4.VIII
                            Case "Inclinare"
                                tol_5_la = target_4.VIII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_5_la = target_5.VIII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_5_la = target_6.VIII
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr6.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr6.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_6_la = target_1.VIII
                            Case "Rectilinitate"
                                tol_6_la = target_1.VIII
                            Case "Forma profilului"
                                tol_6_la = target_1.VIII
                            Case "Forma suprafetei"
                                tol_6_la = target_1.VIII
                            Case "Circularitate"
                                tol_6_la = target_2.VIII
                            Case "Cilindricitate"
                                tol_6_la = target_2.VIII
                            Case "Pozitia nominala"
                                tol_6_la = target_3.VIII
                            Case "Coaxialitate"
                                tol_6_la = target_3.VIII
                            Case "Concentricitate"
                                tol_6_la = target_3.VIII
                            Case "Simetrie"
                                tol_6_la = target_3.VIII
                            Case "Paralelism"
                                tol_6_la = target_4.VIII
                            Case "Perpendicularitate"
                                tol_6_la = target_4.VIII
                            Case "Inclinare"
                                tol_6_la = target_4.VIII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_6_la = target_5.VIII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_6_la = target_6.VIII
                        End Select
                    End If
                Case "IX"
                    If ComboBox_toleranta_la_nr1.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr1.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_1_la = target_1.IX
                            Case "Rectilinitate"
                                tol_1_la = target_1.IX
                            Case "Forma profilului"
                                tol_1_la = target_1.IX
                            Case "Forma suprafetei"
                                tol_1_la = target_1.IX
                            Case "Circularitate"
                                tol_1_la = target_2.IX
                            Case "Cilindricitate"
                                tol_1_la = target_2.IX
                            Case "Pozitia nominala"
                                tol_1_la = target_3.IX
                            Case "Coaxialitate"
                                tol_1_la = target_3.IX
                            Case "Concentricitate"
                                tol_1_la = target_3.IX
                            Case "Simetrie"
                                tol_1_la = target_3.IX
                            Case "Paralelism"
                                tol_1_la = target_4.IX
                            Case "Perpendicularitate"
                                tol_1_la = target_4.IX
                            Case "Inclinare"
                                tol_1_la = target_4.IX
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_1_la = target_5.IX
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_1_la = target_6.IX
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr2.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr2.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_2_la = target_1.IX
                            Case "Rectilinitate"
                                tol_2_la = target_1.IX
                            Case "Forma profilului"
                                tol_2_la = target_1.IX
                            Case "Forma suprafetei"
                                tol_2_la = target_1.IX
                            Case "Circularitate"
                                tol_2_la = target_2.IX
                            Case "Cilindricitate"
                                tol_2_la = target_2.IX
                            Case "Pozitia nominala"
                                tol_2_la = target_3.IX
                            Case "Coaxialitate"
                                tol_2_la = target_3.IX
                            Case "Concentricitate"
                                tol_2_la = target_3.IX
                            Case "Simetrie"
                                tol_2_la = target_3.IX
                            Case "Paralelism"
                                tol_2_la = target_4.IX
                            Case "Perpendicularitate"
                                tol_2_la = target_4.IX
                            Case "Inclinare"
                                tol_2_la = target_4.IX
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_2_la = target_5.IX
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_2_la = target_6.IX
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr3.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr3.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_3_la = target_1.IX
                            Case "Rectilinitate"
                                tol_3_la = target_1.IX
                            Case "Forma profilului"
                                tol_3_la = target_1.IX
                            Case "Forma suprafetei"
                                tol_3_la = target_1.IX
                            Case "Circularitate"
                                tol_3_la = target_2.IX
                            Case "Cilindricitate"
                                tol_3_la = target_2.IX
                            Case "Pozitia nominala"
                                tol_3_la = target_3.IX
                            Case "Coaxialitate"
                                tol_3_la = target_3.IX
                            Case "Concentricitate"
                                tol_3_la = target_3.IX
                            Case "Simetrie"
                                tol_3_la = target_3.IX
                            Case "Paralelism"
                                tol_3_la = target_4.IX
                            Case "Perpendicularitate"
                                tol_3_la = target_4.IX
                            Case "Inclinare"
                                tol_3_la = target_4.IX
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_3_la = target_5.IX
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_3_la = target_6.IX
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr4.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr4.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_4_la = target_1.IX
                            Case "Rectilinitate"
                                tol_4_la = target_1.IX
                            Case "Forma profilului"
                                tol_4_la = target_1.IX
                            Case "Forma suprafetei"
                                tol_4_la = target_1.IX
                            Case "Circularitate"
                                tol_4_la = target_2.IX
                            Case "Cilindricitate"
                                tol_4_la = target_2.IX
                            Case "Pozitia nominala"
                                tol_4_la = target_3.IX
                            Case "Coaxialitate"
                                tol_4_la = target_3.IX
                            Case "Concentricitate"
                                tol_4_la = target_3.IX
                            Case "Simetrie"
                                tol_4_la = target_3.IX
                            Case "Paralelism"
                                tol_4_la = target_4.IX
                            Case "Perpendicularitate"
                                tol_4_la = target_4.IX
                            Case "Inclinare"
                                tol_4_la = target_4.IX
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_4_la = target_5.IX
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_4_la = target_6.IX
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr5.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr5.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_5_la = target_1.IX
                            Case "Rectilinitate"
                                tol_5_la = target_1.IX
                            Case "Forma profilului"
                                tol_5_la = target_1.IX
                            Case "Forma suprafetei"
                                tol_5_la = target_1.IX
                            Case "Circularitate"
                                tol_5_la = target_2.IX
                            Case "Cilindricitate"
                                tol_5_la = target_2.IX
                            Case "Pozitia nominala"
                                tol_5_la = target_3.IX
                            Case "Coaxialitate"
                                tol_5_la = target_3.IX
                            Case "Concentricitate"
                                tol_5_la = target_3.IX
                            Case "Simetrie"
                                tol_5_la = target_3.IX
                            Case "Paralelism"
                                tol_5_la = target_4.IX
                            Case "Perpendicularitate"
                                tol_5_la = target_4.IX
                            Case "Inclinare"
                                tol_5_la = target_4.IX
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_5_la = target_5.IX
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_5_la = target_6.IX
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr6.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr6.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_6_la = target_1.IX
                            Case "Rectilinitate"
                                tol_6_la = target_1.IX
                            Case "Forma profilului"
                                tol_6_la = target_1.IX
                            Case "Forma suprafetei"
                                tol_6_la = target_1.IX
                            Case "Circularitate"
                                tol_6_la = target_2.IX
                            Case "Cilindricitate"
                                tol_6_la = target_2.IX
                            Case "Pozitia nominala"
                                tol_6_la = target_3.IX
                            Case "Coaxialitate"
                                tol_6_la = target_3.IX
                            Case "Concentricitate"
                                tol_6_la = target_3.IX
                            Case "Simetrie"
                                tol_6_la = target_3.IX
                            Case "Paralelism"
                                tol_6_la = target_4.IX
                            Case "Perpendicularitate"
                                tol_6_la = target_4.IX
                            Case "Inclinare"
                                tol_6_la = target_4.IX
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_6_la = target_5.IX
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_6_la = target_6.IX
                        End Select
                    End If
                Case "X"
                    If ComboBox_toleranta_la_nr1.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr1.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_1_la = target_1.X
                            Case "Rectilinitate"
                                tol_1_la = target_1.X
                            Case "Forma profilului"
                                tol_1_la = target_1.X
                            Case "Forma suprafetei"
                                tol_1_la = target_1.X
                            Case "Circularitate"
                                tol_1_la = target_2.X
                            Case "Cilindricitate"
                                tol_1_la = target_2.X
                            Case "Pozitia nominala"
                                tol_1_la = target_3.X
                            Case "Coaxialitate"
                                tol_1_la = target_3.X
                            Case "Concentricitate"
                                tol_1_la = target_3.X
                            Case "Simetrie"
                                tol_1_la = target_3.X
                            Case "Paralelism"
                                tol_1_la = target_4.X
                            Case "Perpendicularitate"
                                tol_1_la = target_4.X
                            Case "Inclinare"
                                tol_1_la = target_4.X
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_1_la = target_5.X
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_1_la = target_6.X
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr2.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr2.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_2_la = target_1.X
                            Case "Rectilinitate"
                                tol_2_la = target_1.X
                            Case "Forma profilului"
                                tol_2_la = target_1.X
                            Case "Forma suprafetei"
                                tol_2_la = target_1.X
                            Case "Circularitate"
                                tol_2_la = target_2.X
                            Case "Cilindricitate"
                                tol_2_la = target_2.X
                            Case "Pozitia nominala"
                                tol_2_la = target_3.X
                            Case "Coaxialitate"
                                tol_2_la = target_3.X
                            Case "Concentricitate"
                                tol_2_la = target_3.X
                            Case "Simetrie"
                                tol_2_la = target_3.X
                            Case "Paralelism"
                                tol_2_la = target_4.X
                            Case "Perpendicularitate"
                                tol_2_la = target_4.X
                            Case "Inclinare"
                                tol_2_la = target_4.X
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_2_la = target_5.X
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_2_la = target_6.X
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr3.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr3.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_3_la = target_1.X
                            Case "Rectilinitate"
                                tol_3_la = target_1.X
                            Case "Forma profilului"
                                tol_3_la = target_1.X
                            Case "Forma suprafetei"
                                tol_3_la = target_1.X
                            Case "Circularitate"
                                tol_3_la = target_2.X
                            Case "Cilindricitate"
                                tol_3_la = target_2.X
                            Case "Pozitia nominala"
                                tol_3_la = target_3.X
                            Case "Coaxialitate"
                                tol_3_la = target_3.X
                            Case "Concentricitate"
                                tol_3_la = target_3.X
                            Case "Simetrie"
                                tol_3_la = target_3.X
                            Case "Paralelism"
                                tol_3_la = target_4.X
                            Case "Perpendicularitate"
                                tol_3_la = target_4.X
                            Case "Inclinare"
                                tol_3_la = target_4.X
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_3_la = target_5.X
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_3_la = target_6.X
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr4.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr4.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_4_la = target_1.X
                            Case "Rectilinitate"
                                tol_4_la = target_1.X
                            Case "Forma profilului"
                                tol_4_la = target_1.X
                            Case "Forma suprafetei"
                                tol_4_la = target_1.X
                            Case "Circularitate"
                                tol_4_la = target_2.X
                            Case "Cilindricitate"
                                tol_4_la = target_2.X
                            Case "Pozitia nominala"
                                tol_4_la = target_3.X
                            Case "Coaxialitate"
                                tol_4_la = target_3.X
                            Case "Concentricitate"
                                tol_4_la = target_3.X
                            Case "Simetrie"
                                tol_4_la = target_3.X
                            Case "Paralelism"
                                tol_4_la = target_4.X
                            Case "Perpendicularitate"
                                tol_4_la = target_4.X
                            Case "Inclinare"
                                tol_4_la = target_4.X
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_4_la = target_5.X
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_4_la = target_6.X
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr5.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr5.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_5_la = target_1.X
                            Case "Rectilinitate"
                                tol_5_la = target_1.X
                            Case "Forma profilului"
                                tol_5_la = target_1.X
                            Case "Forma suprafetei"
                                tol_5_la = target_1.X
                            Case "Circularitate"
                                tol_5_la = target_2.X
                            Case "Cilindricitate"
                                tol_5_la = target_2.X
                            Case "Pozitia nominala"
                                tol_5_la = target_3.X
                            Case "Coaxialitate"
                                tol_5_la = target_3.X
                            Case "Concentricitate"
                                tol_5_la = target_3.X
                            Case "Simetrie"
                                tol_5_la = target_3.X
                            Case "Paralelism"
                                tol_5_la = target_4.X
                            Case "Perpendicularitate"
                                tol_5_la = target_4.X
                            Case "Inclinare"
                                tol_5_la = target_4.X
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_5_la = target_5.X
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_5_la = target_6.X
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr6.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr6.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_6_la = target_1.X
                            Case "Rectilinitate"
                                tol_6_la = target_1.X
                            Case "Forma profilului"
                                tol_6_la = target_1.X
                            Case "Forma suprafetei"
                                tol_6_la = target_1.X
                            Case "Circularitate"
                                tol_6_la = target_2.X
                            Case "Cilindricitate"
                                tol_6_la = target_2.X
                            Case "Pozitia nominala"
                                tol_6_la = target_3.X
                            Case "Coaxialitate"
                                tol_6_la = target_3.X
                            Case "Concentricitate"
                                tol_6_la = target_3.X
                            Case "Simetrie"
                                tol_6_la = target_3.X
                            Case "Paralelism"
                                tol_6_la = target_4.X
                            Case "Perpendicularitate"
                                tol_6_la = target_4.X
                            Case "Inclinare"
                                tol_6_la = target_4.X
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_6_la = target_5.X
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_6_la = target_6.X
                        End Select
                    End If
                Case "XI"
                    If ComboBox_toleranta_la_nr1.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr1.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_1_la = target_1.XI
                            Case "Rectilinitate"
                                tol_1_la = target_1.XI
                            Case "Forma profilului"
                                tol_1_la = target_1.XI
                            Case "Forma suprafetei"
                                tol_1_la = target_1.XI
                            Case "Circularitate"
                                tol_1_la = target_2.XI
                            Case "Cilindricitate"
                                tol_1_la = target_2.XI
                            Case "Pozitia nominala"
                                tol_1_la = target_3.XI
                            Case "Coaxialitate"
                                tol_1_la = target_3.XI
                            Case "Concentricitate"
                                tol_1_la = target_3.XI
                            Case "Simetrie"
                                tol_1_la = target_3.XI
                            Case "Paralelism"
                                tol_1_la = target_4.XI
                            Case "Perpendicularitate"
                                tol_1_la = target_4.XI
                            Case "Inclinare"
                                tol_1_la = target_4.XI
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_1_la = target_5.XI
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_1_la = target_6.XI
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr2.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr2.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_2_la = target_1.XI
                            Case "Rectilinitate"
                                tol_2_la = target_1.XI
                            Case "Forma profilului"
                                tol_2_la = target_1.XI
                            Case "Forma suprafetei"
                                tol_2_la = target_1.XI
                            Case "Circularitate"
                                tol_2_la = target_2.XI
                            Case "Cilindricitate"
                                tol_2_la = target_2.XI
                            Case "Pozitia nominala"
                                tol_2_la = target_3.XI
                            Case "Coaxialitate"
                                tol_2_la = target_3.XI
                            Case "Concentricitate"
                                tol_2_la = target_3.XI
                            Case "Simetrie"
                                tol_2_la = target_3.XI
                            Case "Paralelism"
                                tol_2_la = target_4.XI
                            Case "Perpendicularitate"
                                tol_2_la = target_4.XI
                            Case "Inclinare"
                                tol_2_la = target_4.XI
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_2_la = target_5.XI
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_2_la = target_6.XI
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr3.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr3.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_3_la = target_1.XI
                            Case "Rectilinitate"
                                tol_3_la = target_1.XI
                            Case "Forma profilului"
                                tol_3_la = target_1.XI
                            Case "Forma suprafetei"
                                tol_3_la = target_1.XI
                            Case "Circularitate"
                                tol_3_la = target_2.XI
                            Case "Cilindricitate"
                                tol_3_la = target_2.XI
                            Case "Pozitia nominala"
                                tol_3_la = target_3.XI
                            Case "Coaxialitate"
                                tol_3_la = target_3.XI
                            Case "Concentricitate"
                                tol_3_la = target_3.XI
                            Case "Simetrie"
                                tol_3_la = target_3.XI
                            Case "Paralelism"
                                tol_3_la = target_4.XI
                            Case "Perpendicularitate"
                                tol_3_la = target_4.XI
                            Case "Inclinare"
                                tol_3_la = target_4.XI
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_3_la = target_5.XI
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_3_la = target_6.XI
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr4.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr4.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_4_la = target_1.XI
                            Case "Rectilinitate"
                                tol_4_la = target_1.XI
                            Case "Forma profilului"
                                tol_4_la = target_1.XI
                            Case "Forma suprafetei"
                                tol_4_la = target_1.XI
                            Case "Circularitate"
                                tol_4_la = target_2.XI
                            Case "Cilindricitate"
                                tol_4_la = target_2.XI
                            Case "Pozitia nominala"
                                tol_4_la = target_3.XI
                            Case "Coaxialitate"
                                tol_4_la = target_3.XI
                            Case "Concentricitate"
                                tol_4_la = target_3.XI
                            Case "Simetrie"
                                tol_4_la = target_3.XI
                            Case "Paralelism"
                                tol_4_la = target_4.XI
                            Case "Perpendicularitate"
                                tol_4_la = target_4.XI
                            Case "Inclinare"
                                tol_4_la = target_4.XI
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_4_la = target_5.XI
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_4_la = target_6.XI
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr5.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr5.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_5_la = target_1.XI
                            Case "Rectilinitate"
                                tol_5_la = target_1.XI
                            Case "Forma profilului"
                                tol_5_la = target_1.XI
                            Case "Forma suprafetei"
                                tol_5_la = target_1.XI
                            Case "Circularitate"
                                tol_5_la = target_2.XI
                            Case "Cilindricitate"
                                tol_5_la = target_2.XI
                            Case "Pozitia nominala"
                                tol_5_la = target_3.XI
                            Case "Coaxialitate"
                                tol_5_la = target_3.XI
                            Case "Concentricitate"
                                tol_5_la = target_3.XI
                            Case "Simetrie"
                                tol_5_la = target_3.XI
                            Case "Paralelism"
                                tol_5_la = target_4.XI
                            Case "Perpendicularitate"
                                tol_5_la = target_4.XI
                            Case "Inclinare"
                                tol_5_la = target_4.XI
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_5_la = target_5.XI
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_5_la = target_6.XI
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr6.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr6.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_6_la = target_1.XI
                            Case "Rectilinitate"
                                tol_6_la = target_1.XI
                            Case "Forma profilului"
                                tol_6_la = target_1.XI
                            Case "Forma suprafetei"
                                tol_6_la = target_1.XI
                            Case "Circularitate"
                                tol_6_la = target_2.XI
                            Case "Cilindricitate"
                                tol_6_la = target_2.XI
                            Case "Pozitia nominala"
                                tol_6_la = target_3.XI
                            Case "Coaxialitate"
                                tol_6_la = target_3.XI
                            Case "Concentricitate"
                                tol_6_la = target_3.XI
                            Case "Simetrie"
                                tol_6_la = target_3.XI
                            Case "Paralelism"
                                tol_6_la = target_4.XI
                            Case "Perpendicularitate"
                                tol_6_la = target_4.XI
                            Case "Inclinare"
                                tol_6_la = target_4.XI
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_6_la = target_5.XI
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_6_la = target_6.XI
                        End Select
                    End If
                Case "XII"
                    If ComboBox_toleranta_la_nr1.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr1.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_1_la = target_1.XII
                            Case "Rectilinitate"
                                tol_1_la = target_1.XII
                            Case "Forma profilului"
                                tol_1_la = target_1.XII
                            Case "Forma suprafetei"
                                tol_1_la = target_1.XII
                            Case "Circularitate"
                                tol_1_la = target_2.XII
                            Case "Cilindricitate"
                                tol_1_la = target_2.XII
                            Case "Pozitia nominala"
                                tol_1_la = target_3.XII
                            Case "Coaxialitate"
                                tol_1_la = target_3.XII
                            Case "Concentricitate"
                                tol_1_la = target_3.XII
                            Case "Simetrie"
                                tol_1_la = target_3.XII
                            Case "Paralelism"
                                tol_1_la = target_4.XII
                            Case "Perpendicularitate"
                                tol_1_la = target_4.XII
                            Case "Inclinare"
                                tol_1_la = target_4.XII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_1_la = target_5.XII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_1_la = target_6.XII
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr2.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr2.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_2_la = target_1.XII
                            Case "Rectilinitate"
                                tol_2_la = target_1.XII
                            Case "Forma profilului"
                                tol_2_la = target_1.XII
                            Case "Forma suprafetei"
                                tol_2_la = target_1.XII
                            Case "Circularitate"
                                tol_2_la = target_2.XII
                            Case "Cilindricitate"
                                tol_2_la = target_2.XII
                            Case "Pozitia nominala"
                                tol_2_la = target_3.XII
                            Case "Coaxialitate"
                                tol_2_la = target_3.XII
                            Case "Concentricitate"
                                tol_2_la = target_3.XII
                            Case "Simetrie"
                                tol_2_la = target_3.XII
                            Case "Paralelism"
                                tol_2_la = target_4.XII
                            Case "Perpendicularitate"
                                tol_2_la = target_4.XII
                            Case "Inclinare"
                                tol_2_la = target_4.XII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_2_la = target_5.XII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_2_la = target_6.XII
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr3.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr3.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_3_la = target_1.XII
                            Case "Rectilinitate"
                                tol_3_la = target_1.XII
                            Case "Forma profilului"
                                tol_3_la = target_1.XII
                            Case "Forma suprafetei"
                                tol_3_la = target_1.XII
                            Case "Circularitate"
                                tol_3_la = target_2.XII
                            Case "Cilindricitate"
                                tol_3_la = target_2.XII
                            Case "Pozitia nominala"
                                tol_3_la = target_3.XII
                            Case "Coaxialitate"
                                tol_3_la = target_3.XII
                            Case "Concentricitate"
                                tol_3_la = target_3.XII
                            Case "Simetrie"
                                tol_3_la = target_3.XII
                            Case "Paralelism"
                                tol_3_la = target_4.XII
                            Case "Perpendicularitate"
                                tol_3_la = target_4.XII
                            Case "Inclinare"
                                tol_3_la = target_4.XII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_3_la = target_5.XII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_3_la = target_6.XII
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr4.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr4.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_4_la = target_1.XII
                            Case "Rectilinitate"
                                tol_4_la = target_1.XII
                            Case "Forma profilului"
                                tol_4_la = target_1.XII
                            Case "Forma suprafetei"
                                tol_4_la = target_1.XII
                            Case "Circularitate"
                                tol_4_la = target_2.XII
                            Case "Cilindricitate"
                                tol_4_la = target_2.XII
                            Case "Pozitia nominala"
                                tol_4_la = target_3.XII
                            Case "Coaxialitate"
                                tol_4_la = target_3.XII
                            Case "Concentricitate"
                                tol_4_la = target_3.XII
                            Case "Simetrie"
                                tol_4_la = target_3.XII
                            Case "Paralelism"
                                tol_4_la = target_4.XII
                            Case "Perpendicularitate"
                                tol_4_la = target_4.XII
                            Case "Inclinare"
                                tol_4_la = target_4.XII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_4_la = target_5.XII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_4_la = target_6.XII
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr5.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr5.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_5_la = target_1.XII
                            Case "Rectilinitate"
                                tol_5_la = target_1.XII
                            Case "Forma profilului"
                                tol_5_la = target_1.XII
                            Case "Forma suprafetei"
                                tol_5_la = target_1.XII
                            Case "Circularitate"
                                tol_5_la = target_2.XII
                            Case "Cilindricitate"
                                tol_5_la = target_2.XII
                            Case "Pozitia nominala"
                                tol_5_la = target_3.XII
                            Case "Coaxialitate"
                                tol_5_la = target_3.XII
                            Case "Concentricitate"
                                tol_5_la = target_3.XII
                            Case "Simetrie"
                                tol_5_la = target_3.XII
                            Case "Paralelism"
                                tol_5_la = target_4.XII
                            Case "Perpendicularitate"
                                tol_5_la = target_4.XII
                            Case "Inclinare"
                                tol_5_la = target_4.XII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_5_la = target_5.XII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_5_la = target_6.XII
                        End Select
                    End If
                    If ComboBox_toleranta_la_nr6.SelectedItem IsNot Nothing Then
                        Dim selectedValue As String = ComboBox_toleranta_la_nr6.SelectedItem.ToString()
                        Select Case selectedValue
                            Case "Planitate"
                                tol_6_la = target_1.XII
                            Case "Rectilinitate"
                                tol_6_la = target_1.XII
                            Case "Forma profilului"
                                tol_6_la = target_1.XII
                            Case "Forma suprafetei"
                                tol_6_la = target_1.XII
                            Case "Circularitate"
                                tol_6_la = target_2.XII
                            Case "Cilindricitate"
                                tol_6_la = target_2.XII
                            Case "Pozitia nominala"
                                tol_6_la = target_3.XII
                            Case "Coaxialitate"
                                tol_6_la = target_3.XII
                            Case "Concentricitate"
                                tol_6_la = target_3.XII
                            Case "Simetrie"
                                tol_6_la = target_3.XII
                            Case "Paralelism"
                                tol_6_la = target_4.XII
                            Case "Perpendicularitate"
                                tol_6_la = target_4.XII
                            Case "Inclinare"
                                tol_6_la = target_4.XII
                            Case "Independente la dimensiune ale bataii radiale"
                                tol_6_la = target_5.XII
                            Case "Independente la dimensiune ale bataii frontale"
                                tol_6_la = target_6.XII
                        End Select
                    End If
            End Select


            'Dim values_tolerante_generale_la_rectilinitate_si_planitate As New List(Of tol_HKL)
            Dim target_hkl_1 As tol_HKL
            'Dim values_generale_la_simetrie As New List(Of tol_HKL)
            Dim target_hkl_2 As tol_HKL
            'Dim values_generale_la_perpendicularitate As New List(Of tol_HKL)
            Dim target_hkl_3 As tol_HKL
            'Dim values_generale_la_vataii_suprafetelor As New List(Of tol_HKL)
            Dim target_hkl_4 As tol_HKL

            'combobox_clasa_toleranta_hkl
            For Each smth As tol_HKL In values_tolerante_generale_la_rectilinitate_si_planitate
                If smth.DimensiuneDeLa <= dimensiune_piesa AndAlso smth.DimensiunePanaLa > dimensiune_piesa Then
                    target_hkl_1 = smth
                    Exit For
                End If
            Next
            For Each smth As tol_HKL In values_generale_la_simetrie
                If smth.DimensiuneDeLa <= dimensiune_piesa AndAlso smth.DimensiunePanaLa > dimensiune_piesa Then
                    target_hkl_2 = smth
                    Exit For
                End If
            Next
            For Each smth As tol_HKL In values_generale_la_perpendicularitate
                If smth.DimensiuneDeLa <= dimensiune_piesa AndAlso smth.DimensiunePanaLa > dimensiune_piesa Then
                    target_hkl_3 = smth
                    Exit For
                End If
            Next
            For Each smth As tol_HKL In values_generale_la_vataii_suprafetelor
                If smth.DimensiuneDeLa <= dimensiune_piesa AndAlso smth.DimensiunePanaLa > dimensiune_piesa Then
                    target_hkl_4 = smth
                    Exit For
                End If
            Next

            If IsNothing(target_hkl_1) Then
                target_hkl_1 = values_tolerante_generale_la_rectilinitate_si_planitate(values_tolerante_generale_la_rectilinitate_si_planitate.Count() - 1)
            End If
            If IsNothing(target_hkl_2) Then
                target_hkl_2 = values_generale_la_simetrie(values_generale_la_simetrie.Count() - 1)
            End If
            If IsNothing(target_hkl_3) Then
                target_hkl_3 = values_generale_la_perpendicularitate(values_generale_la_perpendicularitate.Count() - 1)
            End If
            If IsNothing(target_hkl_4) Then
                target_hkl_4 = values_generale_la_vataii_suprafetelor(values_generale_la_vataii_suprafetelor.Count() - 1)
            End If


            If combobox_clasa_toleranta_hkl.SelectedItem IsNot Nothing Then

                Dim selectedValue As String = combobox_clasa_toleranta_hkl.SelectedItem.ToString()
                Select Case selectedValue
                    Case "H"
                        tol_hkl_1 = target_hkl_1.H
                        tol_hkl_2 = target_hkl_2.H
                        tol_hkl_3 = target_hkl_3.H
                        tol_hkl_4 = target_hkl_4.H
                    Case "K"
                        tol_hkl_1 = target_hkl_1.K
                        tol_hkl_2 = target_hkl_2.K
                        tol_hkl_3 = target_hkl_3.K
                        tol_hkl_4 = target_hkl_4.K
                    Case "L"
                        tol_hkl_1 = target_hkl_1.L
                        tol_hkl_2 = target_hkl_2.L
                        tol_hkl_3 = target_hkl_3.L
                        tol_hkl_4 = target_hkl_4.L
                End Select


            End If

        End If



        If toleranta_fundamentala > 1000 Then
            toleranta_fundamentala = toleranta_fundamentala / 1000
            marime_toleranta_fundamentala = "mm"
        End If
        If abatere_fundamentala_arbore_es > 1000 OrElse abatere_fundamentala_arbore_es < -1000 Then
            abatere_fundamentala_arbore_es = abatere_fundamentala_arbore_es / 1000
            marimea_abatere_fundamentala_arbore_es = "mm"
        End If
        If abatere_fundamentala_arbore_ei > 1000 OrElse abatere_fundamentala_arbore_ei < -1000 Then
            abatere_fundamentala_arbore_ei = abatere_fundamentala_arbore_ei / 1000
            marimea_abatere_fundamentala_arbore_ei = "mm"
        End If
        If abatere_fundamentala_special_js > 1000 OrElse abatere_fundamentala_special_js < -1000 Then
            abatere_fundamentala_special_js = abatere_fundamentala_special_js / 1000
            marimea_abatere_fundamentala_special_js = "mm"
        End If
        If abatere_fundamentala_alezaj_EI > 1000 OrElse abatere_fundamentala_alezaj_EI < -1000 Then
            abatere_fundamentala_alezaj_EI = abatere_fundamentala_alezaj_EI / 1000
            marimea_batere_fundamentala_alezaj_EI = "mm"
        End If
        If abatere_fundamentala_alezaj_ES > 1000 OrElse abatere_fundamentala_alezaj_ES < -1000 Then
            abatere_fundamentala_alezaj_ES = abatere_fundamentala_alezaj_ES / 1000
            marimea_abatere_fundamentala_alezaj_ES = "mm"
        End If



        Dim text As String
        If combobox_treapta_toleranta_fundamentala.SelectedItem IsNot Nothing Then
            text = "Toleranța fundamentală " & combobox_treapta_toleranta_fundamentala.SelectedItem.ToString() & ": " & toleranta_fundamentala & marime_toleranta_fundamentala
        End If



        If combobox_clasa_toleranta.SelectedItem IsNot Nothing Then
            Dim text_add_abatere_limita As String
            If checkbox_este_tesitura.Checked Then
                text_add_abatere_limita = "cu excepția teșiturilor"
            Else
                text_add_abatere_limita = "ale teșiturilor"
            End If
            text = text & vbCrLf &
                "Abaterea limită generală pentru dimensiune liniară " & text_add_abatere_limita &
                " de tip " & combobox_clasa_toleranta.SelectedItem.ToString() & ": " &
                abaterea_limita_generala & "mm"
        End If

        If combobox_tipul_piesei.SelectedItem IsNot Nothing Then
            Dim selectedValue As String = combobox_tipul_piesei.SelectedItem.ToString()
            Select Case selectedValue
                Case "Arbore"
                    If checkbox_arbore_es.SelectedItem IsNot Nothing Then
                        text = text & vbCrLf &
                            "Abaterea superioară es " & checkbox_arbore_es.SelectedItem.ToString() & ": " & abatere_fundamentala_arbore_es & marimea_abatere_fundamentala_arbore_es
                        If checkbox_arbore_es.SelectedItem.ToString().Equals("js") Then
                            text = text & vbCrLf &
                            "Abaterea inferioară ei " & checkbox_arbore_es.SelectedItem.ToString() & ": " & abatere_fundamentala_special_js & marimea_abatere_fundamentala_special_js &
                            " (rezultată din es treapta js)"
                        End If
                    End If
                    If checkbox_arbore_ei.SelectedItem IsNot Nothing Then
                        text = text & vbCrLf &
                            "Abaterea inferioară ei " & checkbox_arbore_ei.SelectedItem.ToString() & ": " & abatere_fundamentala_arbore_ei & marimea_abatere_fundamentala_arbore_ei
                    End If
                Case "Alezaj"
                    If checkbox_alezaj_EI.SelectedItem IsNot Nothing Then
                        text = text & vbCrLf &
                            "Abaterea inferioară EI " & checkbox_alezaj_EI.SelectedItem.ToString() & ": " & abatere_fundamentala_alezaj_EI & marimea_batere_fundamentala_alezaj_EI
                        If checkbox_alezaj_EI.SelectedItem.ToString().Equals("JS") Then
                            text = text & vbCrLf &
                            "Abaterea superioară ES " & checkbox_alezaj_EI.SelectedItem.ToString() & ": " & abatere_fundamentala_special_js & marimea_abatere_fundamentala_special_js &
                            " (rezultată din EI treapta JS)"

                        End If
                    End If
                    If checkbox_alezaj_ES.SelectedItem IsNot Nothing Then
                        text = text & vbCrLf &
                            "Abaterea superioară ES " & checkbox_alezaj_ES.SelectedItem.ToString() & ": " & abatere_fundamentala_alezaj_ES & marimea_abatere_fundamentala_alezaj_ES

                    End If
            End Select
        End If

        If combobox_clasa_precizie.SelectedItem IsNot Nothing Then
            Dim clasa_Selectata As String = combobox_clasa_precizie.SelectedItem.ToString()
            If ComboBox_toleranta_la_nr1.SelectedItem IsNot Nothing Then
                If Not String.IsNullOrEmpty(text) Then
                    text = text & vbCrLf
                End If
                Dim selectedValueIIXXII As String = ComboBox_toleranta_la_nr1.SelectedItem.ToString()
                text = text & "Toleranță la " & selectedValueIIXXII & " " & clasa_Selectata & ": " & tol_1_la & "µm"
            End If
            If ComboBox_toleranta_la_nr2.SelectedItem IsNot Nothing Then
                If Not String.IsNullOrEmpty(text) Then
                    text = text & vbCrLf
                End If
                Dim selectedValueIIXXII As String = ComboBox_toleranta_la_nr2.SelectedItem.ToString()
                text = text & "Toleranță la " & selectedValueIIXXII & " " & clasa_Selectata & ": " & tol_2_la & "µm"
            End If
            If ComboBox_toleranta_la_nr3.SelectedItem IsNot Nothing Then
                If Not String.IsNullOrEmpty(text) Then
                    text = text & vbCrLf
                End If
                Dim selectedValueIIXXII As String = ComboBox_toleranta_la_nr3.SelectedItem.ToString()
                text = text & "Toleranță la " & selectedValueIIXXII & " " & clasa_Selectata & ": " & tol_3_la & "µm"
            End If
            If ComboBox_toleranta_la_nr4.SelectedItem IsNot Nothing Then
                If Not String.IsNullOrEmpty(text) Then
                    text = text & vbCrLf
                End If
                Dim selectedValueIIXXII As String = ComboBox_toleranta_la_nr4.SelectedItem.ToString()
                text = text & "Toleranță la " & selectedValueIIXXII & " " & clasa_Selectata & ": " & tol_4_la & "µm"
            End If
            If ComboBox_toleranta_la_nr5.SelectedItem IsNot Nothing Then
                If Not String.IsNullOrEmpty(text) Then
                    text = text & vbCrLf
                End If
                Dim selectedValueIIXXII As String = ComboBox_toleranta_la_nr5.SelectedItem.ToString()
                text = text & "Toleranță la " & selectedValueIIXXII & " " & clasa_Selectata & ": " & tol_5_la & "µm"
            End If
            If ComboBox_toleranta_la_nr6.SelectedItem IsNot Nothing Then
                If Not String.IsNullOrEmpty(text) Then
                    text = text & vbCrLf
                End If
                Dim selectedValueIIXXII As String = ComboBox_toleranta_la_nr6.SelectedItem.ToString()
                text = text & "Toleranță la " & selectedValueIIXXII & " " & clasa_Selectata & ": " & tol_6_la & "µm"
            End If


        End If



        If combobox_clasa_toleranta_hkl.SelectedItem IsNot Nothing Then
            Dim ce_clasa_hkl As String = "" ' combobox_clasa_toleranta_hkl.SelectedItem.ToString()
            Dim tolla_1 As String = "" 'ComboBox_toleranta_la_nr1.SelectedItem.ToString()
            Dim tolla_2 As String = "" ' ComboBox_toleranta_la_nr2.SelectedItem.ToString()
            Dim tolla_3 As String = "" ' ComboBox_toleranta_la_nr3.SelectedItem.ToString()
            Dim tolla_4 As String = "" ' ComboBox_toleranta_la_nr4.SelectedItem.ToString()
            Dim tolla_5 As String = "" ' ComboBox_toleranta_la_nr5.SelectedItem.ToString()
            Dim tolla_6 As String = "" ' ComboBox_toleranta_la_nr6.SelectedItem.ToString()

            If combobox_clasa_toleranta_hkl.SelectedItem IsNot Nothing Then
                ce_clasa_hkl = combobox_clasa_toleranta_hkl.SelectedItem.ToString()
            End If

            If ComboBox_toleranta_la_nr1.SelectedItem IsNot Nothing Then
                tolla_1 = ComboBox_toleranta_la_nr1.SelectedItem.ToString()
            End If
            If ComboBox_toleranta_la_nr2.SelectedItem IsNot Nothing Then
                tolla_2 = ComboBox_toleranta_la_nr2.SelectedItem.ToString()
            End If
            If ComboBox_toleranta_la_nr3.SelectedItem IsNot Nothing Then
                tolla_3 = ComboBox_toleranta_la_nr3.SelectedItem.ToString()
            End If
            If ComboBox_toleranta_la_nr4.SelectedItem IsNot Nothing Then
                tolla_4 = ComboBox_toleranta_la_nr4.SelectedItem.ToString()
            End If
            If ComboBox_toleranta_la_nr5.SelectedItem IsNot Nothing Then
                tolla_5 = ComboBox_toleranta_la_nr5.SelectedItem.ToString()
            End If
            If ComboBox_toleranta_la_nr6.SelectedItem IsNot Nothing Then
                tolla_6 = ComboBox_toleranta_la_nr6.SelectedItem.ToString()
            End If


            'rectilinitate e 1
            'planitate e 2
            'simetrie e 3
            'perpendicularitate e 4
            'bataii suprafetelor e 5
            Dim afisare_1_adv As Boolean = False
            Dim afisare_2_adv As Boolean = False
            Dim afisare_3_adv As Boolean = False
            Dim afisare_4_adv As Boolean = False
            Dim afisare_5_adv As Boolean = False

            Select Case tolla_1
                Case "Planitate"
                    afisare_1_adv = True
                Case "Rectilinitate"
                    afisare_2_adv = True
                Case "Simetrie"
                    afisare_3_adv = True
                Case "Perpendicularitate"
                    afisare_4_adv = True
                Case "Independente la dimensiune ale bataii radiale"
                    afisare_5_adv = True
                Case "Independente la dimensiune ale bataii frontale"
                    afisare_5_adv = True
            End Select
            Select Case tolla_2
                Case "Planitate"
                    afisare_1_adv = True
                Case "Rectilinitate"
                    afisare_2_adv = True
                Case "Simetrie"
                    afisare_3_adv = True
                Case "Perpendicularitate"
                    afisare_4_adv = True
                Case "Independente la dimensiune ale bataii radiale"
                    afisare_5_adv = True
                Case "Independente la dimensiune ale bataii frontale"
                    afisare_5_adv = True
            End Select
            Select Case tolla_3
                Case "Planitate"
                    afisare_1_adv = True
                Case "Rectilinitate"
                    afisare_2_adv = True
                Case "Simetrie"
                    afisare_3_adv = True
                Case "Perpendicularitate"
                    afisare_4_adv = True
                Case "Independente la dimensiune ale bataii radiale"
                    afisare_5_adv = True
                Case "Independente la dimensiune ale bataii frontale"
                    afisare_5_adv = True
            End Select
            Select Case tolla_4
                Case "Planitate"
                    afisare_1_adv = True
                Case "Rectilinitate"
                    afisare_2_adv = True
                Case "Simetrie"
                    afisare_3_adv = True
                Case "Perpendicularitate"
                    afisare_4_adv = True
                Case "Independente la dimensiune ale bataii radiale"
                    afisare_5_adv = True
                Case "Independente la dimensiune ale bataii frontale"
                    afisare_5_adv = True
            End Select
            Select Case tolla_5
                Case "Planitate"
                    afisare_1_adv = True
                Case "Rectilinitate"
                    afisare_2_adv = True
                Case "Simetrie"
                    afisare_3_adv = True
                Case "Perpendicularitate"
                    afisare_4_adv = True
                Case "Independente la dimensiune ale bataii radiale"
                    afisare_5_adv = True
                Case "Independente la dimensiune ale bataii frontale"
                    afisare_5_adv = True
            End Select
            Select Case tolla_6
                Case "Planitate"
                    afisare_1_adv = True
                Case "Rectilinitate"
                    afisare_2_adv = True
                Case "Simetrie"
                    afisare_3_adv = True
                Case "Perpendicularitate"
                    afisare_4_adv = True
                Case "Independente la dimensiune ale bataii radiale"
                    afisare_5_adv = True
                Case "Independente la dimensiune ale bataii frontale"
                    afisare_5_adv = True
            End Select

            If afisare_1_adv = True Then
                If Not String.IsNullOrEmpty(text) Then
                    text = text & vbCrLf
                End If
                text = text & "Toleranță generală la rectilinitate " & ce_clasa_hkl & ": " & tol_hkl_1 & "mm"
            End If
            If afisare_2_adv = True Then
                If Not String.IsNullOrEmpty(text) Then
                    text = text & vbCrLf
                End If
                text = text & "Toleranță generală la planitate " & ce_clasa_hkl & ": " & tol_hkl_1 & "mm"
            End If

            If afisare_3_adv = True Then
                If Not String.IsNullOrEmpty(text) Then
                    text = text & vbCrLf
                End If
                text = text & "Toleranță generală la simetrie " & ce_clasa_hkl & ": " & tol_hkl_2 & "mm"
            End If
            If afisare_4_adv = True Then
                If Not String.IsNullOrEmpty(text) Then
                    text = text & vbCrLf
                End If
                text = text & "Toleranță generală la perpendicularitate " & ce_clasa_hkl & ": " & tol_hkl_3 & "mm"
            End If

            If afisare_5_adv = True = True Then
                If Not String.IsNullOrEmpty(text) Then
                    text = text & vbCrLf
                End If
                text = text & "Toleranță generală ale bătăii suprafețelor " & ce_clasa_hkl & ": " & tol_hkl_4 & "mm"
            End If
        End If
        If combobox_rugozitate.SelectedItem IsNot Nothing Then
            Dim selectie_ra As String = combobox_rugozitate.SelectedItem.ToString()
            Dim selectie_clasa As String = ""
            If cmb_iso_stas.SelectedItem IsNot Nothing Then
                selectie_clasa = cmb_iso_stas.SelectedItem.ToString()
            Else
                MessageBox.Show("Selecteaza clasa de rugozitate!")
            End If
            Dim val As String = String.Empty

            For Each value As rugozitate In values_rugozitate
                If value.ISO.Equals(selectie_clasa) OrElse value.STAS.Equals(selectie_clasa) Then
                    Select Case selectie_ra
                        Case "Ra"
                            val = value.Ra.ToString() & "µm"
                        Case "Rz"
                            val = value.Rz.ToString() & "µm"
                        Case "Ry"
                            val = value.Ry.ToString() & "µm"
                        Case "l"
                            val = value.l.ToString() & "mm"
                    End Select
                End If
            Next

            If Not String.IsNullOrEmpty(text) Then
                text = text & vbCrLf
            End If

            text = text & "Parametrul de rugozitate " & selectie_ra & " " & selectie_clasa & ": " & val.ToString()
        End If

        text_afisare.Text = text

    End Sub



    Private Sub loadObjectsMenu()
        combobox_treapta_toleranta_fundamentala.Items.Clear()
        combobox_treapta_toleranta_fundamentala.Items.Add("IT01")
        For i As Integer = 0 To 18
            combobox_treapta_toleranta_fundamentala.Items.Add("IT" & i)
        Next


        combobox_clasa_toleranta.Items.Clear()
        combobox_clasa_toleranta.Items.Add("Fină (f)")
        combobox_clasa_toleranta.Items.Add("Mijlocie (m)")
        combobox_clasa_toleranta.Items.Add("Grosieră (c)")
        combobox_clasa_toleranta.Items.Add("Grosolană (v)")

        combobox_tipul_piesei.Items.Add("Arbore")
        combobox_tipul_piesei.Items.Add("Alezaj")
        label_alezaj_ES.Visible = False
        checkbox_alezaj_ES.Visible = False
        label_alezaj_EI.Visible = False
        checkbox_alezaj_EI.Visible = False
        label_arbore_es.Visible = False
        checkbox_arbore_es.Visible = False
        label_arbore_ei.Visible = False
        checkbox_arbore_ei.Visible = False


        checkbox_arbore_es.Items.Clear()
        checkbox_arbore_es.Items.Add("a")
        checkbox_arbore_es.Items.Add("b")
        checkbox_arbore_es.Items.Add("c")
        checkbox_arbore_es.Items.Add("cd")
        checkbox_arbore_es.Items.Add("d")
        checkbox_arbore_es.Items.Add("e")
        checkbox_arbore_es.Items.Add("ef")
        checkbox_arbore_es.Items.Add("f")
        checkbox_arbore_es.Items.Add("fg")
        checkbox_arbore_es.Items.Add("g")
        checkbox_arbore_es.Items.Add("h")
        checkbox_arbore_es.Items.Add("js")

        checkbox_arbore_ei.Items.Clear()
        checkbox_arbore_ei.Items.Add("j")
        checkbox_arbore_ei.Items.Add("k")
        checkbox_arbore_ei.Items.Add("m")
        checkbox_arbore_ei.Items.Add("n")
        checkbox_arbore_ei.Items.Add("p")
        checkbox_arbore_ei.Items.Add("r")
        checkbox_arbore_ei.Items.Add("s")
        checkbox_arbore_ei.Items.Add("t")
        checkbox_arbore_ei.Items.Add("u")
        checkbox_arbore_ei.Items.Add("v")
        checkbox_arbore_ei.Items.Add("x")
        checkbox_arbore_ei.Items.Add("y")
        checkbox_arbore_ei.Items.Add("z")
        checkbox_arbore_ei.Items.Add("za")
        checkbox_arbore_ei.Items.Add("zb")
        checkbox_arbore_ei.Items.Add("zc")

        checkbox_alezaj_EI.Items.Clear()
        checkbox_alezaj_EI.Items.Add("A")
        checkbox_alezaj_EI.Items.Add("B")
        checkbox_alezaj_EI.Items.Add("C")
        checkbox_alezaj_EI.Items.Add("CD")
        checkbox_alezaj_EI.Items.Add("D")
        checkbox_alezaj_EI.Items.Add("E")
        checkbox_alezaj_EI.Items.Add("EF")
        checkbox_alezaj_EI.Items.Add("F")
        checkbox_alezaj_EI.Items.Add("FG")
        checkbox_alezaj_EI.Items.Add("G")
        checkbox_alezaj_EI.Items.Add("H")
        checkbox_alezaj_EI.Items.Add("JS")


        checkbox_alezaj_ES.Items.Clear()
        checkbox_alezaj_ES.Items.Add("J")
        checkbox_alezaj_ES.Items.Add("K")
        checkbox_alezaj_ES.Items.Add("M")
        checkbox_alezaj_ES.Items.Add("N")
        checkbox_alezaj_ES.Items.Add("P")
        checkbox_alezaj_ES.Items.Add("R")
        checkbox_alezaj_ES.Items.Add("S")
        checkbox_alezaj_ES.Items.Add("T")
        checkbox_alezaj_ES.Items.Add("U")
        checkbox_alezaj_ES.Items.Add("V")
        checkbox_alezaj_ES.Items.Add("X")
        checkbox_alezaj_ES.Items.Add("Y")
        checkbox_alezaj_ES.Items.Add("Z")
        checkbox_alezaj_ES.Items.Add("ZA")
        checkbox_alezaj_ES.Items.Add("ZB")
        checkbox_alezaj_ES.Items.Add("ZC")


        ComboBox_toleranta_la_nr1.Items.Add("Planitate")
        ComboBox_toleranta_la_nr1.Items.Add("Rectilinitate")
        ComboBox_toleranta_la_nr1.Items.Add("Pozitia nominala")
        ComboBox_toleranta_la_nr1.Items.Add("Forma profilului")
        ComboBox_toleranta_la_nr1.Items.Add("Forma suprafetei")
        ComboBox_toleranta_la_nr1.Items.Add("Circularitate")
        ComboBox_toleranta_la_nr1.Items.Add("Cilindricitate")
        ComboBox_toleranta_la_nr1.Items.Add("Coaxialitate")
        ComboBox_toleranta_la_nr1.Items.Add("Concentricitate")
        ComboBox_toleranta_la_nr1.Items.Add("Simetrie")
        ComboBox_toleranta_la_nr1.Items.Add("Paralelism")
        ComboBox_toleranta_la_nr1.Items.Add("Perpendicularitate")
        ComboBox_toleranta_la_nr1.Items.Add("Inclinare")
        ComboBox_toleranta_la_nr1.Items.Add("Independente la dimensiune ale bataii radiale")
        ComboBox_toleranta_la_nr1.Items.Add("Independente la dimensiune ale bataii frontale")


        ComboBox_toleranta_la_nr2.Items.Add("Planitate")
        ComboBox_toleranta_la_nr2.Items.Add("Rectilinitate")
        ComboBox_toleranta_la_nr2.Items.Add("Pozitia nominala")
        ComboBox_toleranta_la_nr2.Items.Add("Forma profilului")
        ComboBox_toleranta_la_nr2.Items.Add("Forma suprafetei")
        ComboBox_toleranta_la_nr2.Items.Add("Circularitate")
        ComboBox_toleranta_la_nr2.Items.Add("Cilindricitate")
        ComboBox_toleranta_la_nr2.Items.Add("Coaxialitate")
        ComboBox_toleranta_la_nr2.Items.Add("Concentricitate")
        ComboBox_toleranta_la_nr2.Items.Add("Simetrie")
        ComboBox_toleranta_la_nr2.Items.Add("Paralelism")
        ComboBox_toleranta_la_nr2.Items.Add("Perpendicularitate")
        ComboBox_toleranta_la_nr2.Items.Add("Inclinare")
        ComboBox_toleranta_la_nr2.Items.Add("Independente la dimensiune ale bataii radiale")
        ComboBox_toleranta_la_nr2.Items.Add("Independente la dimensiune ale bataii frontale")



        ComboBox_toleranta_la_nr3.Items.Add("Planitate")
        ComboBox_toleranta_la_nr3.Items.Add("Rectilinitate")
        ComboBox_toleranta_la_nr3.Items.Add("Pozitia nominala")
        ComboBox_toleranta_la_nr3.Items.Add("Forma profilului")
        ComboBox_toleranta_la_nr3.Items.Add("Forma suprafetei")
        ComboBox_toleranta_la_nr3.Items.Add("Circularitate")
        ComboBox_toleranta_la_nr3.Items.Add("Cilindricitate")
        ComboBox_toleranta_la_nr3.Items.Add("Coaxialitate")
        ComboBox_toleranta_la_nr3.Items.Add("Concentricitate")
        ComboBox_toleranta_la_nr3.Items.Add("Simetrie")
        ComboBox_toleranta_la_nr3.Items.Add("Paralelism")
        ComboBox_toleranta_la_nr3.Items.Add("Perpendicularitate")
        ComboBox_toleranta_la_nr3.Items.Add("Inclinare")
        ComboBox_toleranta_la_nr3.Items.Add("Independente la dimensiune ale bataii radiale")
        ComboBox_toleranta_la_nr3.Items.Add("Independente la dimensiune ale bataii frontale")

        ComboBox_toleranta_la_nr4.Items.Add("Planitate")
        ComboBox_toleranta_la_nr4.Items.Add("Rectilinitate")
        ComboBox_toleranta_la_nr4.Items.Add("Pozitia nominala")
        ComboBox_toleranta_la_nr4.Items.Add("Forma profilului")
        ComboBox_toleranta_la_nr4.Items.Add("Forma suprafetei")
        ComboBox_toleranta_la_nr4.Items.Add("Circularitate")
        ComboBox_toleranta_la_nr4.Items.Add("Cilindricitate")
        ComboBox_toleranta_la_nr4.Items.Add("Coaxialitate")
        ComboBox_toleranta_la_nr4.Items.Add("Concentricitate")
        ComboBox_toleranta_la_nr4.Items.Add("Simetrie")
        ComboBox_toleranta_la_nr4.Items.Add("Paralelism")
        ComboBox_toleranta_la_nr4.Items.Add("Perpendicularitate")
        ComboBox_toleranta_la_nr4.Items.Add("Inclinare")
        ComboBox_toleranta_la_nr4.Items.Add("Independente la dimensiune ale bataii radiale")
        ComboBox_toleranta_la_nr4.Items.Add("Independente la dimensiune ale bataii frontale")

        ComboBox_toleranta_la_nr5.Items.Add("Planitate")
        ComboBox_toleranta_la_nr5.Items.Add("Rectilinitate")
        ComboBox_toleranta_la_nr5.Items.Add("Pozitia nominala")
        ComboBox_toleranta_la_nr5.Items.Add("Forma profilului")
        ComboBox_toleranta_la_nr5.Items.Add("Forma suprafetei")
        ComboBox_toleranta_la_nr5.Items.Add("Circularitate")
        ComboBox_toleranta_la_nr5.Items.Add("Cilindricitate")
        ComboBox_toleranta_la_nr5.Items.Add("Coaxialitate")
        ComboBox_toleranta_la_nr5.Items.Add("Concentricitate")
        ComboBox_toleranta_la_nr5.Items.Add("Simetrie")
        ComboBox_toleranta_la_nr5.Items.Add("Paralelism")
        ComboBox_toleranta_la_nr5.Items.Add("Perpendicularitate")
        ComboBox_toleranta_la_nr5.Items.Add("Inclinare")
        ComboBox_toleranta_la_nr5.Items.Add("Independente la dimensiune ale bataii radiale")
        ComboBox_toleranta_la_nr5.Items.Add("Independente la dimensiune ale bataii frontale")

        ComboBox_toleranta_la_nr6.Items.Add("Planitate")
        ComboBox_toleranta_la_nr6.Items.Add("Rectilinitate")
        ComboBox_toleranta_la_nr6.Items.Add("Pozitia nominala")
        ComboBox_toleranta_la_nr6.Items.Add("Forma profilului")
        ComboBox_toleranta_la_nr6.Items.Add("Forma suprafetei")
        ComboBox_toleranta_la_nr6.Items.Add("Circularitate")
        ComboBox_toleranta_la_nr6.Items.Add("Cilindricitate")
        ComboBox_toleranta_la_nr6.Items.Add("Coaxialitate")
        ComboBox_toleranta_la_nr6.Items.Add("Concentricitate")
        ComboBox_toleranta_la_nr6.Items.Add("Simetrie")
        ComboBox_toleranta_la_nr6.Items.Add("Paralelism")
        ComboBox_toleranta_la_nr6.Items.Add("Perpendicularitate")
        ComboBox_toleranta_la_nr6.Items.Add("Inclinare")
        ComboBox_toleranta_la_nr6.Items.Add("Independente la dimensiune ale bataii radiale")
        ComboBox_toleranta_la_nr6.Items.Add("Independente la dimensiune ale bataii frontale")

        combobox_clasa_precizie.Items.Add("I")
        combobox_clasa_precizie.Items.Add("II")
        combobox_clasa_precizie.Items.Add("III")
        combobox_clasa_precizie.Items.Add("IV")
        combobox_clasa_precizie.Items.Add("V")
        combobox_clasa_precizie.Items.Add("VI")
        combobox_clasa_precizie.Items.Add("VII")
        combobox_clasa_precizie.Items.Add("VIII")
        combobox_clasa_precizie.Items.Add("IX")
        combobox_clasa_precizie.Items.Add("X")
        combobox_clasa_precizie.Items.Add("XI")
        combobox_clasa_precizie.Items.Add("XII")


        combobox_clasa_toleranta_hkl.Items.Add("H")
        combobox_clasa_toleranta_hkl.Items.Add("K")
        combobox_clasa_toleranta_hkl.Items.Add("L")

        cmb_iso_stas.Items.Add("IT4")
        cmb_iso_stas.Items.Add("IT5")
        cmb_iso_stas.Items.Add("IT6")
        cmb_iso_stas.Items.Add("IT7")
        cmb_iso_stas.Items.Add("IT8")
        cmb_iso_stas.Items.Add("IT9")
        cmb_iso_stas.Items.Add("IT10")
        cmb_iso_stas.Items.Add("IT11")
        cmb_iso_stas.Items.Add("IT12")
        cmb_iso_stas.Items.Add("IT13")
        cmb_iso_stas.Items.Add("IT14")
        cmb_iso_stas.Items.Add("IT15")

        combobox_rugozitate.Items.Add("Ra")
        combobox_rugozitate.Items.Add("Rz")
        combobox_rugozitate.Items.Add("Ry")
        combobox_rugozitate.Items.Add("l")


    End Sub



    Private Sub switch_stas_CheckedChanged(sender As Object, e As EventArgs) Handles switch_stas.CheckedChanged
        cmb_iso_stas.ResetText()
        cmb_iso_stas.Items.Clear()
        If switch_stas.Checked Then
            cmb_iso_stas.Items.Add("N0")
            cmb_iso_stas.Items.Add("N1")
            cmb_iso_stas.Items.Add("N2")
            cmb_iso_stas.Items.Add("N3")
            cmb_iso_stas.Items.Add("N4")
            cmb_iso_stas.Items.Add("N5")
            cmb_iso_stas.Items.Add("N6")
            cmb_iso_stas.Items.Add("N7")
            cmb_iso_stas.Items.Add("N8")
            cmb_iso_stas.Items.Add("N9")
            cmb_iso_stas.Items.Add("N10")
            cmb_iso_stas.Items.Add("N11")
            cmb_iso_stas.Items.Add("N12")
            cmb_iso_stas.Items.Add("N13")
        Else
            cmb_iso_stas.Items.Add("IT4")
            cmb_iso_stas.Items.Add("IT5")
            cmb_iso_stas.Items.Add("IT6")
            cmb_iso_stas.Items.Add("IT7")
            cmb_iso_stas.Items.Add("IT8")
            cmb_iso_stas.Items.Add("IT9")
            cmb_iso_stas.Items.Add("IT10")
            cmb_iso_stas.Items.Add("IT11")
            cmb_iso_stas.Items.Add("IT12")
            cmb_iso_stas.Items.Add("IT13")
            cmb_iso_stas.Items.Add("IT14")
            cmb_iso_stas.Items.Add("IT15")
        End If
    End Sub
    Private Sub ToleranteFundamentaleLiniareToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToleranteFundamentaleLiniareToolStripMenuItem.Click

        Dim window As New tabel_tolerante_fundamentale_liniare()
        window.Show()
    End Sub

    Private Sub AbaterileLimitaGeneraleLiniareToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbaterileLimitaGeneraleLiniareToolStripMenuItem.Click
        Dim window As New tabel_abateri_limita_generale_liniare()
        window.Show()
    End Sub
    Private Sub ArboriToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArboriToolStripMenuItem.Click
        Dim window As New tabel_abateri_fundamentale_arbori()
        window.Show()
    End Sub
    Private Sub AlezajeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlezajeToolStripMenuItem.Click
        Dim window As New tabel_abateri_fundamentale_alezaje()
        window.Show()
    End Sub
    Private Sub DeltaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeltaToolStripMenuItem.Click
        Dim window As New tabel_abateri_fundamentale_alezaje_delta()
        window.Show()
    End Sub
    Private Sub ToleranțeIndividualeLaRectilinitatePlanitateFormaDatăAProfiluluiȘiFormaDatăASuprafețeiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToleranțeIndividualeLaRectilinitatePlanitateFormaDatăAProfiluluiȘiFormaDatăASuprafețeiToolStripMenuItem.Click
        Dim window As New tabel_clase_I_XII()
        window.valori() = values_ToleranteRectilinePlanitateFormaProfiluluiSuprafetei
        window.nume_fereastra = "Valorile toleranțelor individuale la circularitate și la cilindricitate"
        window.Show()
    End Sub
    Private Sub ValorileToleranțelorIndividualeLaCircularitateȘiLaCilindricitateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ValorileToleranțelorIndividualeLaCircularitateȘiLaCilindricitateToolStripMenuItem.Click
        Dim window As New tabel_clase_I_XII()
        window.valori() = values_ToleranteCircularitateCilindritate
        window.nume_fereastra = "Valorile toleranțelor individuale la circularitate și la cilindricitate"
        window.Show()
    End Sub
    Private Sub ToleranteleLaPozițiaNominalăLaCoaxialitateȘiConcentricitateȘiLaSimetrieToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToleranteleLaPozițiaNominalăLaCoaxialitateȘiConcentricitateȘiLaSimetrieToolStripMenuItem.Click
        Dim window As New tabel_clase_I_XII()
        window.valori() = values_TolerantePozitiaNominalaCoaxialitateConcentritateSimetri
        window.nume_fereastra = "Tolerantele la poziția nominală, la coaxialitate și concentricitate și la simetrie"
        window.Show()
    End Sub
    Private Sub ToleranteleIndividualeLaParalelismPerpendicularitateȘiÎnclinareToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToleranteleIndividualeLaParalelismPerpendicularitateȘiÎnclinareToolStripMenuItem.Click
        Dim window As New tabel_clase_I_XII()
        window.valori() = values_ToleranteParalelismPerpendicularitateInclinare
        window.nume_fereastra = "Tolerantele individuale la paralelism, perpendicularitate și înclinare"
        window.Show()
    End Sub

    Private Sub ToleranteleIndividualeIndependenteDeDimensiunealeBiitiiiiRadialeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToleranteleIndividualeIndependenteDeDimensiunealeBiitiiiiRadialeToolStripMenuItem.Click
        Dim window As New tabel_clase_I_XII()
        window.valori() = values_ToleranteindependenteDeDimensiuniAleBataiiRadiale
        window.nume_fereastra = "Tolerantele individuale independente de dimensiuneale bătăii radiale"
        window.Show()
    End Sub

    Private Sub ToleranțeleIndividualeIndependenteDeDimensiuneAleBătăiiFrontaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToleranțeleIndividualeIndependenteDeDimensiuneAleBătăiiFrontaleToolStripMenuItem.Click
        Dim window As New tabel_clase_I_XII()
        window.valori = values_ToleranteindependenteDeDimensiuniAleBataiiFrontale
        window.nume_fereastra = "Toleranțele individuale independente de dimensiune ale bătăii frontale"
        window.Show()
    End Sub


    Private Sub ToleranțeGeneraleLaSimetrieToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToleranțeGeneraleLaSimetrieToolStripMenuItem.Click
        Dim window As New tabel_tol_HKL()
        window.valori = values_tolerante_generale_la_rectilinitate_si_planitate
        window.nume_fereastra = "Toleranțe generale la rectilinitate și planitate"
        window.Show()
    End Sub

    Private Sub ToleranțeGeneraleLaPerpendicularitateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToleranțeGeneraleLaPerpendicularitateToolStripMenuItem.Click
        Dim window As New tabel_tol_HKL()
        window.valori = values_generale_la_simetrie
        window.nume_fereastra = "Toleranțe generale la simetrie"
        window.Show()
    End Sub

    Private Sub ToleranțeGeneraleLaRectilinitateȘiPlanitateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToleranțeGeneraleLaRectilinitateȘiPlanitateToolStripMenuItem.Click
        Dim window As New tabel_tol_HKL()
        window.valori = values_generale_la_perpendicularitate
        window.nume_fereastra = "Toleranțe generale la perpendicularitate"
        window.Show()
    End Sub

    Private Sub ToleranțeGeneraleAleBătăiiSuprafețelorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToleranțeGeneraleAleBătăiiSuprafețelorToolStripMenuItem.Click
        Dim window As New tabel_tol_HKL()
        window.valori = values_generale_la_vataii_suprafetelor
        window.nume_fereastra = "Toleranțe generale ale bătăii suprafețelor"
        window.Show()
    End Sub

    Private Sub ClaseleDeRugozitateȘiParametriiAsociațiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClaseleDeRugozitateȘiParametriiAsociațiToolStripMenuItem.Click
        Dim window As New tabel_rugozitate With {
            .date_valori = values_rugozitate,
            .nume_fereastra = "Clasele de rugozitate și parametrii asociați"
        }
        window.Show()
    End Sub


    Private Sub CalculAjustajToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculAjustajToolStripMenuItem.Click
        Dim window As New calcul_ajustaj()
        window.Show()
    End Sub


    Private Sub readClase_I_XII(filePath As String, list As List(Of claseI_XII))
        Using parser As New TextFieldParser(filePath)
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",")

            parser.ReadLine()
            While Not parser.EndOfData
                Dim fields As String() = parser.ReadFields()

                Dim dimensiuneDeLa As Double = If(fields(0) = "-", 0, If(Double.TryParse(fields(0), CultureInfo.InvariantCulture, dimensiuneDeLa), dimensiuneDeLa, 0))
                Dim dimensiunePanaLa As Double = If(fields(1) = "-", 0, If(Double.TryParse(fields(1), CultureInfo.InvariantCulture, dimensiunePanaLa), dimensiunePanaLa, 0))
                Dim I As Double = If(fields(2) = "-", 0, If(Double.TryParse(fields(2), CultureInfo.InvariantCulture, I), I, 0))
                Dim II As Double = If(fields(3) = "-", 0, If(Double.TryParse(fields(3), CultureInfo.InvariantCulture, II), II, 0))
                Dim III As Double = If(fields(4) = "-", 0, If(Double.TryParse(fields(4), CultureInfo.InvariantCulture, III), III, 0))
                Dim IV As Double = If(fields(5) = "-", 0, If(Double.TryParse(fields(5), CultureInfo.InvariantCulture, IV), IV, 0))
                Dim V As Double = If(fields(5) = "-", 0, If(Double.TryParse(fields(6), CultureInfo.InvariantCulture, V), V, 0))
                Dim VI As Double = If(fields(5) = "-", 0, If(Double.TryParse(fields(7), CultureInfo.InvariantCulture, VI), VI, 0))
                Dim VII As Double = If(fields(5) = "-", 0, If(Double.TryParse(fields(8), CultureInfo.InvariantCulture, VII), VII, 0))
                Dim VIII As Double = If(fields(5) = "-", 0, If(Double.TryParse(fields(9), CultureInfo.InvariantCulture, VIII), VIII, 0))
                Dim IX As Double = If(fields(5) = "-", 0, If(Double.TryParse(fields(10), CultureInfo.InvariantCulture, IX), IX, 0))
                Dim X As Double = If(fields(5) = "-", 0, If(Double.TryParse(fields(11), CultureInfo.InvariantCulture, X), X, 0))
                Dim XI As Double = If(fields(5) = "-", 0, If(Double.TryParse(fields(12), CultureInfo.InvariantCulture, XI), XI, 0))
                Dim XII As Double = If(fields(5) = "-", 0, If(Double.TryParse(fields(13), CultureInfo.InvariantCulture, XII), XII, 0))

                Dim newObj As New claseI_XII(dimensiuneDeLa, dimensiunePanaLa, I, II, III, IV, V, VI, VII, VIII, IX, X, XII, XII)
                list.Add(newObj)
            End While
        End Using
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
    Private Sub readHKL(filePath As String, list As List(Of tol_HKL))
        Using parser As New TextFieldParser(filePath)
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",")

            parser.ReadLine()
            While Not parser.EndOfData
                Dim fields As String() = parser.ReadFields()

                Dim dimensiuneDeLa As Double = If(fields(0) = "-", 0, If(Double.TryParse(fields(0), CultureInfo.InvariantCulture, dimensiuneDeLa), dimensiuneDeLa, 0))
                Dim dimensiunePanaLa As Double = If(fields(1) = "-", 0, If(Double.TryParse(fields(1), CultureInfo.InvariantCulture, dimensiunePanaLa), dimensiunePanaLa, 0))
                Dim H As Double = If(fields(2) = "-", 0, If(Double.TryParse(fields(2), CultureInfo.InvariantCulture, H), H, 0))
                Dim K As Double = If(fields(3) = "-", 0, If(Double.TryParse(fields(3), CultureInfo.InvariantCulture, K), K, 0))
                Dim L As Double = If(fields(4) = "-", 0, If(Double.TryParse(fields(4), CultureInfo.InvariantCulture, L), L, 0))

                Dim newObj As New tol_HKL(dimensiuneDeLa, dimensiunePanaLa, H, K, L)
                list.Add(newObj)
            End While
        End Using
    End Sub
    Private Sub readRugozitate(filePath As String, list As List(Of rugozitate))
        Using parser As New TextFieldParser(filePath)
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",")

            parser.ReadLine()
            While Not parser.EndOfData
                Dim fields As String() = parser.ReadFields()

                Dim iso As String = fields(0)
                Dim stas As String = fields(1)
                Dim ra As Double = If(fields(2) = "-", 0, If(Double.TryParse(fields(2), CultureInfo.InvariantCulture, ra), ra, 0))
                Dim rz As Double = If(fields(3) = "-", 0, If(Double.TryParse(fields(3), CultureInfo.InvariantCulture, rz), rz, 0))
                Dim ry As Double = If(fields(4) = "-", 0, If(Double.TryParse(fields(4), CultureInfo.InvariantCulture, ry), ry, 0))
                Dim l As Double = If(fields(5) = "-", 0, If(Double.TryParse(fields(5), CultureInfo.InvariantCulture, l), l, 0))
                Debug.WriteLine(iso)
                Dim newObj As New rugozitate(iso, stas, ra, rz, ry, l)
                values_rugozitate.Add(newObj)
            End While
        End Using
    End Sub
    Private Sub readDataAbateriFundamentaleAlezaje(filePath As String, list As List(Of abateri_fundamentale_alezaje))

        Using parser As New TextFieldParser(filePath)
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",")

            parser.ReadLine()
            parser.ReadLine()
            parser.ReadLine()

            While Not parser.EndOfData
                Dim fields As String() = parser.ReadFields()
                Dim dimensiuneDeLa As Double = If(fields(0) = "-", 0, If(Double.TryParse(fields(0), dimensiuneDeLa), dimensiuneDeLa, 0))
                Dim dimensiunePanaLa As Double = If(fields(1) = "-", 0, If(Double.TryParse(fields(1), dimensiunePanaLa), dimensiunePanaLa, 0))
                Dim A_citit As New clasa
                Dim B_citit As New clasa
                Dim C_citit As New clasa
                Dim CD_citit As New clasa
                Dim D_citit As New clasa
                Dim E_citit As New clasa
                Dim EF_citit As New clasa
                Dim F_citit As New clasa
                Dim FG_citit As New clasa
                Dim G_citit As New clasa
                Dim H_citit As New clasa
                Dim JS_citit As New clasa
                Dim J6_citit As New clasa
                Dim J7_citit As New clasa
                Dim J8_citit As New clasa
                Dim K8_citit As New clasa
                Dim Kpeste8_citit As New clasa
                Dim M8_citit As New clasa
                Dim Mpeste8_citit As New clasa
                Dim N8_citit As New clasa
                Dim Npeste8_citit As New clasa
                Dim P8_citit As New clasa
                Dim R8_citit As New clasa
                Dim S8_citit As New clasa
                Dim T8_citit As New clasa
                Dim U8_citit As New clasa
                Dim V8_citit As New clasa
                Dim X8_citit As New clasa
                Dim Y8_citit As New clasa
                Dim Z8_citit As New clasa
                Dim ZA8_citit As New clasa
                Dim ZB8_citit As New clasa
                Dim ZC8_citit As New clasa
                Dim Ppeste8_citit As New clasa
                Dim Rpeste8_citit As New clasa
                Dim Speste8_citit As New clasa
                Dim Tpeste8_citit As New clasa
                Dim Upeste8_citit As New clasa
                Dim Vpeste8_citit As New clasa
                Dim Xpeste8_citit As New clasa
                Dim Ypeste8_citit As New clasa
                Dim Zpeste8_citit As New clasa
                Dim ZApeste8_citit As New clasa
                Dim ZBpeste8_citit As New clasa
                Dim ZCpeste8_citit As New clasa

                ReadClasaFieldValue(A_citit, fields(2))
                ReadClasaFieldValue(B_citit, fields(3))
                ReadClasaFieldValue(C_citit, fields(4))
                ReadClasaFieldValue(CD_citit, fields(5))
                ReadClasaFieldValue(D_citit, fields(6))
                ReadClasaFieldValue(E_citit, fields(7))
                ReadClasaFieldValue(EF_citit, fields(8))
                ReadClasaFieldValue(F_citit, fields(9))
                ReadClasaFieldValue(FG_citit, fields(10))
                ReadClasaFieldValue(G_citit, fields(11))
                ReadClasaFieldValue(H_citit, fields(12))
                ReadClasaFieldValue(JS_citit, fields(13))
                ReadClasaFieldValue(J6_citit, fields(14))
                ReadClasaFieldValue(J7_citit, fields(15))
                ReadClasaFieldValue(J8_citit, fields(16))
                ReadClasaFieldValue(K8_citit, fields(17))
                ReadClasaFieldValue(Kpeste8_citit, fields(18))
                ReadClasaFieldValue(M8_citit, fields(19))
                ReadClasaFieldValue(Mpeste8_citit, fields(20))
                ReadClasaFieldValue(N8_citit, fields(21))
                ReadClasaFieldValue(Npeste8_citit, fields(22))

                ReadClasaFieldValue(Ppeste8_citit, fields(23))
                ReadClasaFieldValue(Rpeste8_citit, fields(24))
                ReadClasaFieldValue(Speste8_citit, fields(25))
                ReadClasaFieldValue(Tpeste8_citit, fields(26))
                ReadClasaFieldValue(Upeste8_citit, fields(27))
                ReadClasaFieldValue(Vpeste8_citit, fields(28))
                ReadClasaFieldValue(Xpeste8_citit, fields(29))
                ReadClasaFieldValue(Ypeste8_citit, fields(30))
                ReadClasaFieldValue(Zpeste8_citit, fields(31))
                ReadClasaFieldValue(ZApeste8_citit, fields(32))
                ReadClasaFieldValue(ZBpeste8_citit, fields(33))
                ReadClasaFieldValue(ZCpeste8_citit, fields(34))

                P8_citit = copyValue(Ppeste8_citit)
                R8_citit = copyValue(Rpeste8_citit)
                S8_citit = copyValue(Speste8_citit)
                T8_citit = copyValue(Tpeste8_citit)
                U8_citit = copyValue(Upeste8_citit)
                V8_citit = copyValue(Vpeste8_citit)
                X8_citit = copyValue(Xpeste8_citit)
                Y8_citit = copyValue(Ypeste8_citit)
                Z8_citit = copyValue(Zpeste8_citit)
                ZA8_citit = copyValue(ZApeste8_citit)
                ZB8_citit = copyValue(ZBpeste8_citit)
                ZC8_citit = copyValue(ZCpeste8_citit)


                Dim newObj As New abateri_fundamentale_alezaje(dimensiuneDeLa, dimensiunePanaLa, A_citit, B_citit, C_citit, CD_citit, D_citit, E_citit, EF_citit, F_citit, FG_citit, G_citit, H_citit, JS_citit, J6_citit, J7_citit, J8_citit, K8_citit, Kpeste8_citit, M8_citit, Mpeste8_citit, N8_citit, Npeste8_citit, P8_citit, R8_citit, S8_citit, T8_citit, U8_citit, V8_citit, X8_citit, Y8_citit, Z8_citit, ZA8_citit, ZB8_citit, ZC8_citit, Ppeste8_citit, Rpeste8_citit, Speste8_citit, Tpeste8_citit, Upeste8_citit, Vpeste8_citit, Xpeste8_citit, Ypeste8_citit, Zpeste8_citit, ZApeste8_citit, ZBpeste8_citit, ZCpeste8_citit)
                newObj.load()
                list.Add(newObj)

            End While
        End Using
    End Sub
    Private Function copyValue(ByRef object_from As clasa) As clasa
        If object_from Is Nothing Then
            Return New clasa()
        End If

        Dim obj_to As New clasa
        obj_to.value = object_from.value
        obj_to.hasDelta = True
        Return obj_to
    End Function
    Private Sub ReadClasaFieldValue(ByRef obj As clasa, fields As String)
        If obj Is Nothing Then
            obj = New clasa()
        End If

        Dim field As String = fields
        field = field.Replace(" ", "")
        If field.ToLower().Contains("+delta") Then
            obj.hasDelta = True
            field = field.Replace("+delta", "")
            Double.TryParse(field, obj.value)
        ElseIf field.Equals("delta + IT7") Then
            obj.hasDelta = True
            obj.value = 0
        ElseIf field.Equals("-") Then
            obj.value = 0
        ElseIf Double.TryParse(field, obj.value) Then
            obj.value = field
        Else
            obj.value = 0

        End If
    End Sub
    Private Sub readDataAbateriFundamentaleArbori(filePath As String, list As List(Of abateri_fundamentale_arbori))

        Using parser As New TextFieldParser(filePath)
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",")

            parser.ReadLine()
            parser.ReadLine()
            parser.ReadLine()

            While Not parser.EndOfData
                Dim fields As String() = parser.ReadFields()
                Dim dimensiuneDeLa As Double = If(fields(0) = "-", 0, If(Double.TryParse(fields(0), dimensiuneDeLa), dimensiuneDeLa, 0))
                Dim dimensiunePanaLa As Double = If(fields(1) = "-", 0, If(Double.TryParse(fields(1), dimensiunePanaLa), dimensiunePanaLa, 0))
                Dim a_citit As clasa = ReadClasaFieldValue(2, fields)
                Dim b_citit As clasa = ReadClasaFieldValue(3, fields)
                Dim c_citit As clasa = ReadClasaFieldValue(4, fields)
                Dim cd_citit As clasa = ReadClasaFieldValue(5, fields)
                Dim d_citit As clasa = ReadClasaFieldValue(6, fields)
                Dim e_citit As clasa = ReadClasaFieldValue(7, fields)
                Dim ef_citit As clasa = ReadClasaFieldValue(8, fields)
                Dim f_citit As clasa = ReadClasaFieldValue(9, fields)
                Dim fg_citit As clasa = ReadClasaFieldValue(10, fields)
                Dim g_citit As clasa = ReadClasaFieldValue(11, fields)
                Dim h_citit As clasa = ReadClasaFieldValue(12, fields)
                Dim js_citit As clasa = ReadClasaFieldValue(13, fields)
                Dim j56_citit As clasa = ReadClasaFieldValue(14, fields)
                Dim j7_citit As clasa = ReadClasaFieldValue(15, fields)
                Dim j8_citit As clasa = ReadClasaFieldValue(16, fields)
                Dim k4567_citit As clasa = ReadClasaFieldValue(17, fields)
                Dim kfara4567_citit As clasa = ReadClasaFieldValue(18, fields)
                Dim m_citit As clasa = ReadClasaFieldValue(19, fields)
                Dim n_citit As clasa = ReadClasaFieldValue(20, fields)
                Dim p_citit As clasa = ReadClasaFieldValue(21, fields)
                Dim r_citit As clasa = ReadClasaFieldValue(22, fields)
                Dim s_citit As clasa = ReadClasaFieldValue(23, fields)
                Dim t_citit As clasa = ReadClasaFieldValue(24, fields)
                Dim u_citit As clasa = ReadClasaFieldValue(25, fields)
                Dim v_citit As clasa = ReadClasaFieldValue(26, fields)
                Dim x_citit As clasa = ReadClasaFieldValue(27, fields)
                Dim y_citit As clasa = ReadClasaFieldValue(28, fields)
                Dim z_citit As clasa = ReadClasaFieldValue(29, fields)
                Dim za_citit As clasa = ReadClasaFieldValue(30, fields)
                Dim zb_citit As clasa = ReadClasaFieldValue(31, fields)
                Dim zc_citit As clasa = ReadClasaFieldValue(32, fields)


                Dim newObj As New abateri_fundamentale_arbori(dimensiuneDeLa, dimensiunePanaLa, a_citit, b_citit, c_citit, cd_citit, d_citit, e_citit, ef_citit, f_citit, fg_citit, g_citit, h_citit, js_citit, j56_citit, j7_citit, j8_citit, k4567_citit, kfara4567_citit, m_citit, n_citit, p_citit, r_citit, s_citit, t_citit, u_citit, v_citit, x_citit, y_citit, z_citit, za_citit, zb_citit, zc_citit)
                newObj.load()
                list.Add(newObj)
            End While
        End Using
    End Sub
    Private Function ReadClasaFieldValue(fieldIndex As Integer, fields As String()) As clasa
        Dim clasaValue As clasa = New clasa()

        ' Check if the fields array has enough elements
        If fieldIndex >= 0 AndAlso fieldIndex < fields.Length Then
            clasaValue.value = If(fields(fieldIndex) = "-", 0, If(Double.TryParse(fields(fieldIndex), clasaValue.value), clasaValue.value, 0))
        Else
            ' Handle the case where the index is out of bounds
            clasaValue.value = 0
        End If

        Return clasaValue
    End Function
    Private Sub readDataAbateriLimita(filePath As String, list As List(Of abateri_limita_generale))

        Using parser As New TextFieldParser(filePath)
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",")

            parser.ReadLine()
            parser.ReadLine()
            While Not parser.EndOfData
                Dim fields As String() = parser.ReadFields()

                Dim dimensiuneDeLa As Double = If(fields(0) = "-", 0, If(Double.TryParse(fields(0), CultureInfo.InvariantCulture, dimensiuneDeLa), dimensiuneDeLa, 0))
                Dim dimensiunePanaLa As Double = If(fields(1) = "-", 0, If(Double.TryParse(fields(1), CultureInfo.InvariantCulture, dimensiunePanaLa), dimensiunePanaLa, 0))
                Dim f As Double = If(fields(2) = "-", 0, If(Double.TryParse(fields(2), CultureInfo.InvariantCulture, f), f, 0))
                Dim m As Double = If(fields(3) = "-", 0, If(Double.TryParse(fields(3), CultureInfo.InvariantCulture, m), m, 0))
                Dim c As Double = If(fields(4) = "-", 0, If(Double.TryParse(fields(4), CultureInfo.InvariantCulture, c), c, 0))
                Dim v As Double = If(fields(5) = "-", 0, If(Double.TryParse(fields(5), CultureInfo.InvariantCulture, v), v, 0))

                Dim newObj As New abateri_limita_generale(dimensiuneDeLa, dimensiunePanaLa, f, m, c, v)
                list.Add(newObj)
            End While
        End Using
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
    Private Sub combobox_tipul_piesei_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combobox_tipul_piesei.SelectedIndexChanged


        Dim selectedValue As String = ""
        If combobox_tipul_piesei.SelectedItem IsNot Nothing Then
            selectedValue = combobox_tipul_piesei.SelectedItem.ToString()
        End If
        Select Case selectedValue
            Case "Arbore"
                label_arbore_es.Visible = True
                checkbox_arbore_es.Visible = True
                label_arbore_ei.Visible = True
                checkbox_arbore_ei.Visible = True

                label_alezaj_ES.Visible = False
                checkbox_alezaj_ES.Visible = False
                label_alezaj_EI.Visible = False
                checkbox_alezaj_EI.Visible = False
            Case "Alezaj"
                label_alezaj_ES.Visible = True
                checkbox_alezaj_ES.Visible = True
                label_alezaj_EI.Visible = True
                checkbox_alezaj_EI.Visible = True

                label_arbore_es.Visible = False
                checkbox_arbore_es.Visible = False
                label_arbore_ei.Visible = False
                checkbox_arbore_ei.Visible = False
        End Select
    End Sub

    Private Sub btn_reset_Click(sender As Object, e As EventArgs) Handles btn_reset.Click
        text_dimensiune.Text = ""
        combobox_treapta_toleranta_fundamentala.SelectedIndex = -1
        combobox_clasa_toleranta.SelectedIndex = -1
        checkbox_este_tesitura.Checked = False
        combobox_tipul_piesei.SelectedIndex = -1
        checkbox_alezaj_ES.SelectedIndex = -1
        checkbox_alezaj_EI.SelectedIndex = -1
        checkbox_arbore_ei.SelectedIndex = -1
        checkbox_arbore_es.SelectedIndex = -1
        switch_stas.Checked = False
        cmb_iso_stas.SelectedIndex = -1
        combobox_rugozitate.SelectedIndex = -1
        combobox_clasa_precizie.SelectedIndex = -1
        combobox_clasa_toleranta_hkl.SelectedIndex = -1
        ComboBox_toleranta_la_nr1.SelectedIndex = -1
        ComboBox_toleranta_la_nr2.SelectedIndex = -1
        ComboBox_toleranta_la_nr3.SelectedIndex = -1
        ComboBox_toleranta_la_nr4.SelectedIndex = -1
        ComboBox_toleranta_la_nr5.SelectedIndex = -1
        ComboBox_toleranta_la_nr6.SelectedIndex = -1
        text_afisare.Text = String.Empty

        checkbox_alezaj_ES.Visible = False
        checkbox_alezaj_EI.Visible = False
        checkbox_arbore_ei.Visible = False
        checkbox_arbore_es.Visible = False
        label_alezaj_EI.Visible = False
        label_alezaj_ES.Visible = False
        label_arbore_ei.Visible = False
        label_arbore_es.Visible = False
    End Sub

    Private Sub InformațiiGeneraleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InformațiiGeneraleToolStripMenuItem.Click
        MessageBox.Show("Această aplicație a fost dezvoltată de Trandafir Andrei - Alexandru, student la UNSTPB, anul II, FIIR - SIA. Datele de intrare pentru această aplicație au fost furnizate din suportul de curs al materiei Procese Industriale 1,Prof. Dr. Ing. Nicolae Ionescu.")

    End Sub

    Private Sub VeziMesajDeÎnceputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VeziMesajDeÎnceputToolStripMenuItem.Click
        MessageBox.Show("Pentru a folosi această interfață nu este nevoie ca toate datele să fie introduse! În cazul în care lipsesc date importante, în momentul calculării valorilor va apărea o eroare.", "Atenție!", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class

