Public Class calcul_ajustaj

    Private Sub Calculeaza_Click(sender As Object, e As EventArgs) Handles Calculeaza.Click

        If String.IsNullOrEmpty(b_Dmax.Text) OrElse String.IsNullOrEmpty(b_Dmin.Text) OrElse String.IsNullOrEmpty(b_ddmax.Text) OrElse String.IsNullOrEmpty(b_ddmin.Text) Then
            MessageBox.Show("Ai nevoie de dimensiuni pentru a continua!")
            Return
        End If
        Dim Dmax As Double = b_Dmax.Text
        Dim Dmin As Double = b_Dmin.Text
        Dim ddmax As Double = b_ddmax.Text
        Dim ddmin As Double = b_ddmin.Text
        Dim ES As Double = 0
        Dim EI As Double = 0
        Dim ees As Double = 0
        Dim eei As Double = 0
        If Not String.IsNullOrEmpty(b_ES.Text) Then
            ES = b_ES.Text
        End If

        If Not String.IsNullOrEmpty(b_EI.Text) Then
            EI = b_EI.Text
        End If

        If Not String.IsNullOrEmpty(b_ees.Text) Then
            ees = b_ees.Text
        End If

        If Not String.IsNullOrEmpty(b_eei.Text) Then
            eei = b_eei.Text
        End If


        Dim Tol As Double = ES - EI
        tg_es.Text = Tol.ToString()

        If Dmax > ddmin Then
            'ajustaj cu joc
            Dim jmax As Double = Dmax - ddmin
            Dim jmaxES As Double = ES - eei

            Dim jmin As Double = Dmin - ddmax
            Dim jminEs As Double = EI - ees

            Dim TJ As Double = jmax - jmin

            Label12.Text = "Toleranta joc:"
            tip_d.Text = "Ajustaj cu joc"
            jmax_d.Text = jmax.ToString()
            jmin_d.Text = jmin.ToString()
            tj_d.Text = TJ.ToString()

            jmax_es.Text = jmaxES.ToString()
            jmin_es.Text = jminEs.ToString()

        Else
            'ajustaj cu strangere
            Dim Smax As Double = ddmax - Dmin
            Dim SmaxES As Double = ees - EI

            Dim Smin As Double = ddmin - Dmax
            Dim SminES As Double = eei - ES

            Dim TS As Double = Smax - Smin


            Label12.Text = "Toleranta strangere:"
            tip_d.Text = "Ajustaj cu strangere"
            jmax_d.Text = Smax.ToString()
            jmin_d.Text = Smin.ToString()
            tj_d.Text = TS.ToString()

            jmax_es.Text = SmaxES.ToString()
            jmin_es.Text = SminES.ToString()
        End If

    End Sub


End Class