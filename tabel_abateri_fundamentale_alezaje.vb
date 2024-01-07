Imports Microsoft.VisualBasic.FileIO

Public Class tabel_abateri_fundamentale_alezaje
    Private Sub tabel_abateri_fundamentale_alezaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim list As New List(Of abateri_fundamentale_alezaje)

        readDataAbateriFundamentaleAlezaje("tabel311.csv", list)

        For i As Integer = 0 To 35
            DataGridView1.Columns.Add("", "")
        Next
        DataGridView1.Rows.Add("", "", "EI", "EI", "EI", "EI", "EI", "EI", "EI", "EI", "EI", "EI", "EI", "EI", "ES", "ES", "ES", "ES", "ES", "ES", "ES", "ES", "ES", "ES", "ES", "ES", "ES", "ES", "ES", "ES", "ES", "ES", "ES", "ES", "ES", "ES")
        DataGridView1.Rows.Add("Dimensiunea", "Nominala", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "ITn", "IT6", "IT7", "IT8", "<=IT8", ">IT8", "<=IT8", ">IT8", "<=IT8", ">IT8", "<=IT8", ">IT8", ">IT8", ">IT8", ">IT8", ">IT8", ">IT8", ">IT8", ">IT8", ">IT8", ">IT8", ">IT8", ">IT8")
        DataGridView1.Rows.Add("De la", "Pana la", "A", "B", "C", "CD", "D", "E", "EF", "F", "FG", "G", "H", "JS", "J", "J", "J", "K", "K", "M", "M", "N", "N", "P-ZC", "P", "R", "S", "T", "Y", "V", "X", "Y", "Z", "ZA", "ZB", "ZC")
        DataGridView1.RowTemplate.Height = 19


        For Each obj As abateri_fundamentale_alezaje In list
            Dim aVal As String = obj.A.value()
            If obj.A.hasDelta Then
                aVal = aVal & " +Δ"
            End If

            Dim bVal As String = obj.B.value()
            If obj.B.hasDelta Then
                bVal = bVal & " +Δ"
            End If

            Dim cVal As String = obj.C.value()
            If obj.C.hasDelta Then
                cVal = cVal & " +Δ"
            End If

            Dim cdVal As String = obj.CD.value()
            If obj.CD.hasDelta Then
                cdVal = cdVal & " +Δ"
            End If

            Dim dVal As String = obj.D.value()
            If obj.D.hasDelta Then
                dVal = dVal & " +Δ"
            End If

            Dim eVal As String = obj.E.value()
            If obj.E.hasDelta Then
                eVal = eVal & " +Δ"
            End If

            Dim efVal As String = obj.EF.value()
            If obj.EF.hasDelta Then
                efVal = efVal & " +Δ"
            End If

            Dim fVal As String = obj.F.value()
            If obj.F.hasDelta Then
                fVal = fVal & " +Δ"
            End If

            Dim fgVal As String = obj.FG.value()
            If obj.FG.hasDelta Then
                fgVal = fgVal & " +Δ"
            End If

            Dim gVal As String = obj.G.value()
            If obj.G.hasDelta Then
                gVal = gVal & " +Δ"
            End If

            Dim hVal As String = obj.H.value()
            If obj.H.hasDelta Then
                hVal = hVal & " +Δ"
            End If

            Dim jsVal As String = obj.JS.value()
            If obj.JS.hasDelta Then
                jsVal = jsVal & " +Δ"
            End If

            Dim j6Val As String = obj.J6.value()
            If obj.J6.hasDelta Then
                j6Val = j6Val & " +Δ"
            End If

            Dim j7Val As String = obj.J7.value()
            If obj.J7.hasDelta Then
                j7Val = j7Val & " +Δ"
            End If

            Dim j8Val As String = obj.J8.value()
            If obj.J8.hasDelta Then
                j8Val = j8Val & " +Δ"
            End If

            Dim k8Val As String = obj.K8.value()
            If obj.K8.hasDelta Then
                k8Val = k8Val & " +Δ"
            End If

            Dim kpeste8Val As String = obj.Kpeste8.value()
            If obj.Kpeste8.hasDelta Then
                kpeste8Val = kpeste8Val & " +Δ"
            End If

            Dim m8Val As String = obj.M8.value()
            If obj.M8.hasDelta Then
                m8Val = m8Val & " +Δ"
            End If

            Dim mpeste8Val As String = obj.Mpeste8.value()
            If obj.Mpeste8.hasDelta Then
                mpeste8Val = mpeste8Val & " +Δ"
            End If

            Dim n8Val As String = obj.N8.value()
            If obj.N8.hasDelta Then
                n8Val = n8Val & " +Δ"
            End If

            Dim npeste8Val As String = obj.Npeste8.value()
            If obj.Npeste8.hasDelta Then
                npeste8Val = npeste8Val & " +Δ"
            End If

            Dim p8Val As String = obj.P8.value()
            If obj.P8.hasDelta Then
                p8Val = p8Val & " +Δ"
            End If

            Dim r8Val As String = obj.R8.value()
            If obj.R8.hasDelta Then
                r8Val = r8Val & " +Δ"
            End If

            Dim s8Val As String = obj.S8.value()
            If obj.S8.hasDelta Then
                s8Val = s8Val & " +Δ"
            End If

            Dim t8Val As String = obj.T8.value()
            If obj.T8.hasDelta Then
                t8Val = t8Val & " +Δ"
            End If

            Dim u8Val As String = obj.U8.value()
            If obj.U8.hasDelta Then
                u8Val = u8Val & " +Δ"
            End If

            Dim v8Val As String = obj.V8.value()
            If obj.V8.hasDelta Then
                v8Val = v8Val & " +Δ"
            End If

            Dim x8Val As String = obj.X8.value()
            If obj.X8.hasDelta Then
                x8Val = x8Val & " +Δ"
            End If

            Dim y8Val As String = obj.Y8.value()
            If obj.Y8.hasDelta Then
                y8Val = y8Val & " +Δ"
            End If

            Dim z8Val As String = obj.Z8.value()
            If obj.Z8.hasDelta Then
                z8Val = z8Val & " +Δ"
            End If

            Dim za8Val As String = obj.ZA8.value()
            If obj.ZA8.hasDelta Then
                za8Val = za8Val & " +Δ"
            End If

            Dim zb8Val As String = obj.ZB8.value()
            If obj.ZB8.hasDelta Then
                zb8Val = zb8Val & " +Δ"
            End If

            Dim zc8Val As String = obj.ZC8.value()
            If obj.ZC8.hasDelta Then
                zc8Val = zc8Val & " +Δ"
            End If

            Dim ppeste8Val As String = obj.Ppeste8.value()
            If obj.Ppeste8.hasDelta Then
                ppeste8Val = ppeste8Val & " +Δ"
            End If

            Dim rpeste8Val As String = obj.Rpeste8.value()
            If obj.Rpeste8.hasDelta Then
                rpeste8Val = rpeste8Val & " +Δ"
            End If

            Dim speste8Val As String = obj.Speste8.value()
            If obj.Speste8.hasDelta Then
                speste8Val = speste8Val & " +Δ"
            End If

            Dim tpeste8Val As String = obj.Tpeste8.value()
            If obj.Tpeste8.hasDelta Then
                tpeste8Val = tpeste8Val & " +Δ"
            End If

            Dim upeste8Val As String = obj.Upeste8.value()
            If obj.Upeste8.hasDelta Then
                upeste8Val = upeste8Val & " +Δ"
            End If

            Dim vpeste8Val As String = obj.Vpeste8.value()
            If obj.Vpeste8.hasDelta Then
                vpeste8Val = vpeste8Val & " +Δ"
            End If

            Dim xpeste8Val As String = obj.Xpeste8.value()
            If obj.Xpeste8.hasDelta Then
                xpeste8Val = xpeste8Val & " +Δ"
            End If

            Dim ypeste8Val As String = obj.Ypeste8.value()
            If obj.Ypeste8.hasDelta Then
                ypeste8Val = ypeste8Val & " +Δ"
            End If

            Dim zpeste8Val As String = obj.Zpeste8.value()
            If obj.Zpeste8.hasDelta Then
                zpeste8Val = zpeste8Val & " +Δ"
            End If

            Dim zapeste8Val As String = obj.ZApeste8.value()
            If obj.ZApeste8.hasDelta Then
                zapeste8Val = zapeste8Val & " +Δ"
            End If

            Dim zbpeste8Val As String = obj.ZBpeste8.value()
            If obj.ZBpeste8.hasDelta Then
                zbpeste8Val = zbpeste8Val & " +Δ"
            End If

            Dim zcpeste8Val As String = obj.ZCpeste8.value()
            If obj.ZCpeste8.hasDelta Then
                zcpeste8Val = zcpeste8Val & " +Δ"
            End If
            DataGridView1.Rows.Add(obj.DimensiuneDeLa, obj.DimensiunePanaLa, aVal, bVal, cVal, cdVal, dVal, eVal, efVal, fVal, fgVal, gVal, hVal, jsVal, j6Val, j7Val, j8Val, k8Val, kpeste8Val, m8Val, mpeste8Val, n8Val, npeste8Val, ">IT8 value +Δ", ppeste8Val, rpeste8Val, speste8Val, tpeste8Val, upeste8Val, vpeste8Val, xpeste8Val, ypeste8Val, zpeste8Val, zapeste8Val, zbpeste8Val, zcpeste8Val)

        Next


        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.Size = New Size(DataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 50,
                                      DataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + DataGridView1.ColumnHeadersHeight + 10)

        ' Set window size based on column widths
        Me.Size = New Size(DataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 100,
                                      DataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + DataGridView1.ColumnHeadersHeight + 100)





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



End Class