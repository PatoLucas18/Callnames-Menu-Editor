Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Globalization
Imports System.ComponentModel

Public Class Form1

    Private Sub BtnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorrar.Click
        'Dim item As New ListViewItem(TextBox1.Text)
        'item.SubItems.Add(TextBox1.Text)
        'ListView1.Items.Add(item)
        'DataGridView1.Rows.Add("Darth", "Vader", True)

        'Dim index As Integer = 1
        'Dim variable As String = DataGridView1.Item(index, DataGridView1.CurrentRow.Index).Value
        'TextBox1.Text = variable

        ' DataGridView1.Rows.Remove

        'MsgBox(DataGridView1.CurrentRow.Index)
        'NumericUpDown1.Value = 2807 / 15

        DataGridView1.Rows.Remove(DataGridView1.CurrentRow)

    End Sub


    ' abrir el Archivo
    Private Sub AbrirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirToolStripMenuItem.Click
        Me.OFD.Title = "Seleccionar archivo"
        '' abrir el diálogo 
        If OFD.ShowDialog = Windows.Forms.DialogResult.OK Then

            Me.Text = OFD.FileName & " - Callnames Menú editor"
            GuardarToolStripMenuItem.Enabled = True
            GuardarComoToolStripMenuItem.Enabled = True
            GroupBox1.Enabled = True
            GroupBox3.Enabled = True
            GroupBox4.Enabled = True
            DataGridView1.Enabled = True
            BtnBorrar.Enabled = True
            BtnBorrartodo.Enabled = True
            DataGridView1.Rows.Clear()
            Dim fs As New FileStream(OFD.FileName, FileMode.Open)
            Dim br As New BinaryReader(fs)

            ' Offset donde inicia los nombres(los nombres empizan en el offset48,  

            fs.Position = 32 ' Cantidad de Callnames
            Dim Numeroscall As Integer = br.ReadInt16()
            For NCall = 1 To Numeroscall

                fs.Seek(NCall * 48, SeekOrigin.Begin)
                Dim bytes() As Byte = br.ReadBytes(26)

                'Buscar bytes seguidos en cero para determinar la longitud de las letras
                Dim find As Byte = 0
                Dim index As Integer = 0
                index = System.Array.IndexOf(Of Byte)(bytes, find, index)
                If index > 1 Then ' Asegurar la longitud sea mayor a 1 (por si hay fuente con mas de 40 bytes, como creditos )
                    Dim value As String = Encoding.UTF8.GetString(bytes, 0, index)
                    fs.Position = (NCall * 48) - 8 ' Resta 8 para ir a la posicion del unknow
                    Dim callnameN As Integer = br.ReadInt16()
                    DataGridView1.Rows.Add(NCall, value, callnameN, True)
                End If

            Next
            br.Close()
            fs.Close()

            MsgBox("Cargado")
        End If
    End Sub
    ' Guardar el Archivo
    Private Sub GuardarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarToolStripMenuItem.Click
        Guardar(OFD.FileName)
    End Sub
    ' Guardar Como el Archivo
    Private Sub GuardarComoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarComoToolStripMenuItem.Click
        If SFD.ShowDialog = Windows.Forms.DialogResult.OK Then
            ' Comprobar si existe el archivo abierto(para guardar como desde CSV)
            If File.Exists(OFD.FileName) Then
                My.Computer.FileSystem.CopyFile(OFD.FileName, SFD.FileName, overwrite:=True)
            Else
                ' Creamos una archivo bin base tipo pes6 (funciona en we9)
                Dim b(304331) As Byte
                File.WriteAllBytes(SFD.FileName, b)

                Dim fs As New FileStream(SFD.FileName, FileMode.Open)
                Dim bw As New BinaryWriter(fs)

                'Cantidad de callnames
                fs.Position = 4
                bw.Write(Int32.Parse(&H4A4AC))
                fs.Position = 8
                bw.Write(Int32.Parse(&H4A4AC))
                fs.Position = 36
                bw.Write(Int32.Parse(&H1A0001))

                bw.Close()
                fs.Close()

            End If

            GuardarToolStripMenuItem.Enabled = True
            OFD.FileName = SFD.FileName
            Guardar(OFD.FileName)
        End If
    End Sub
    Private Sub Guardar(ByVal filename As String)
        Dim fs As New FileStream(filename, FileMode.OpenOrCreate)
        Dim bw As New BinaryWriter(fs)
        Me.Text = OFD.FileName & " - Callnames Menú editor"
        DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)


        'Escribir bytes en cero 
        Dim limpiar As Integer = fs.Length - 90
        Dim writeBytes(limpiar) As Byte
        writeBytes(0) = 0
        fs.Position = 40
        fs.Write(writeBytes, 0, writeBytes.Count)

        'Cantidad de callnames
        fs.Position = 32
        bw.Write(Int16.Parse(DataGridView1.Rows.Count))



        Dim Ncallnames As Double = (DataGridView1.Rows.Count) / 15 'DataGridView1.Rows.Count - 1
        Dim Ncallnames2 As Integer = (DataGridView1.Rows.Count) / 15

        Dim Resultado As Integer
        Resultado = Ncallnames2
        If Resultado < Ncallnames Then 'Normal
            fs.Position = 34
            bw.Write(Int16.Parse(Resultado + 1))
        ElseIf Resultado >= Ncallnames Then 'Invertir
            fs.Position = 34
            bw.Write(Int16.Parse(Resultado))
        End If

        For i = 1 To DataGridView1.Rows.Count
            'Calcular Nombre callnames, sumará 48 hasta llegar al jugador final
            'Extraer datos dg
            Dim nombrejugador As String = DataGridView1.Item(1, i - 1).Value
            Dim unknow As Integer = DataGridView1.Item(2, i - 1).Value


            'Escribir nombre de Jugador
            Dim bytes2(39) As Byte
            bytes2(0) = 0
            bytes2 = Encoding.UTF8.GetBytes(nombrejugador)
            bw.Seek(i * 48, SeekOrigin.Begin)
            bw.Write(bytes2, 0, bytes2.Length)


            'Asignar archivo AFS
            fs.Position = (i * 48) - 2 ' valor 2 asigna al x_sound.afs
            bw.Write(Byte.Parse("2"))
            fs.Position = (i * 48) - 6 ' valor 2 asigna al x_sound.afs
            bw.Write(Byte.Parse("2"))

            'Unknow callname
            Dim callname As Integer = (i * 48) - 8
            fs.Position = callname
            bw.Write(Int16.Parse(unknow)) 'Escribe en N° de unknow
            fs.Position = callname + 4
            bw.Write(Int16.Parse(unknow)) 'Escribe en N° de unknow
        Next

        'ORDENAR LETRA
        'fs.Length es para calcular  el tamaño del archivo, restamos para calular offse del 
        Dim TEMPORALVALOR As Integer

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("b") Or obtvalor.StartsWith("B") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 50
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("c") Or obtvalor.StartsWith("C") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 48
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("d") Or obtvalor.StartsWith("D") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 46
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("e") Or obtvalor.StartsWith("E") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 44
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("f") Or obtvalor.StartsWith("F") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 42
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("g") Or obtvalor.StartsWith("G") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 40
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("h") Or obtvalor.StartsWith("H") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 38
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("i") Or obtvalor.StartsWith("I") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 36
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("j") Or obtvalor.StartsWith("J") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 34
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("k") Or obtvalor.StartsWith("K") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 32
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("l") Or obtvalor.StartsWith("L") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 30
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("m") Or obtvalor.StartsWith("M") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 28
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("n") Or obtvalor.StartsWith("N") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 26
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("o") Or obtvalor.StartsWith("O") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 24
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("p") Or obtvalor.StartsWith("P") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 22
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("q") Or obtvalor.StartsWith("Q") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 20
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("r") Or obtvalor.StartsWith("R") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 18
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("s") Or obtvalor.StartsWith("S") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 16
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("t") Or obtvalor.StartsWith("T") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 14
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("u") Or obtvalor.StartsWith("U") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 12
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("v") Or obtvalor.StartsWith("V") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 10
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("w") Or obtvalor.StartsWith("W") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 8
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("x") Or obtvalor.StartsWith("X") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 6
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("y") Or obtvalor.StartsWith("Y") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 4
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("z") Or obtvalor.StartsWith("Z") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
        fs.Position = fs.Length - 2
        bw.Write(Int16.Parse(TEMPORALVALOR))

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith("a") Or obtvalor.StartsWith("A") Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TEMPORALVALOR = DataGridView1.CurrentRow.Index
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next


        ' offet 32 numeros de callmes osea num. de items
        ' offset 34 numer pagin.
        bw.Close()
        fs.Close()
        MsgBox("Guardado", MsgBoxStyle.Information)

    End Sub
    ' Agregar Callnames
    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        'DataGridView1.Rows.Clear()
        'DataGridView1.Rows.Insert(2, 1)
        Dim idnuevo As String = DataGridView1.Rows.Count
        DataGridView1.Rows.Add(idnuevo, TBNombre.Text, NUDCallname.Value)


        DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = DataGridView1.Rows(i).Cells(1).Value.ToString 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).
            If obtvalor.StartsWith(TBNombre.Text) Or obtvalor.StartsWith(TBNombre.Text) Then
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            End If
        Next
    End Sub
    ' Borrar todo callnames
    Private Sub BtnBorrartodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorrartodo.Click
        DataGridView1.Rows.Clear()

        'Dim Ids As Integer = Ids + 1
        'DataGridView1.Rows.Insert(Ids)

        'Dim codart As String = Me.DataGridView1.CurrentCell.Value.ToString
        'Dim codart As String = Me.DataGridView1.CurrentRow.Cells(2).Value.ToString
        'MsgBox(codart)

        'If DataGridView1.SelectedCells.Count.ToString <> 0 Then
        '    Dim codart As String = Me.DataGridView1.SelectedCells(1).Value.ToString
        'End If

    End Sub
    ' Buscar Nombre
    Private Sub TextBoxBuscar_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxBuscar.KeyUp
        'Quito si tiene alguna selección.
        DataGridView1.ClearSelection()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 'Número de columnas totales.
            Dim obtvalor As String
            obtvalor = LCase(DataGridView1.Rows(i).Cells(1).Value.ToString) 'Se supone que las columnas son estáticas. 0 es la columna en la que deseo ralizar la búsqueda (Columna --> Nombre).

            Dim palabra1 As String = LCase(TextBoxBuscar.Text)  'convierto a minuscula para comparar

            If (obtvalor.StartsWith(palabra1)) Then 'Aqui compara minusculas
                DataGridView1.Rows(i).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                TextBoxBuscar.ForeColor = Color.Green
                Exit For 'Sale para que no busque más palabras. Se puede quitar y te selecciona todas.
            Else
                TextBoxBuscar.ForeColor = Color.Red
            End If
        Next
    End Sub
#Region "Idiomas"

    Private Sub English()
        ChangeLanguage("en")
        Column1.HeaderText = "Name"
        AbrirToolStripMenuItem.Text = "Open"
        GuardarToolStripMenuItem.Text = "Save"
        GuardarComoToolStripMenuItem.Text = "Save as"
    End Sub
    Private Sub Español()
        ChangeLanguage("es")
        Column1.HeaderText = "Nombre"
        AbrirToolStripMenuItem.Text = "Abrir"
        GuardarToolStripMenuItem.Text = "Guardar"
        GuardarComoToolStripMenuItem.Text = "Guardar como"
    End Sub
    Private Sub ChangeLanguage(ByVal Language As String) 'Localizable form
        For Each c As Control In Me.Controls
            Dim crmLang As ComponentResourceManager = New ComponentResourceManager(GetType(Form1))
            crmLang.ApplyResources(c, c.Name, New CultureInfo(Language)) 'Set desired language
            For Each c2 As Control In c.Controls
                Dim crmLang2 As ComponentResourceManager = New ComponentResourceManager(GetType(Form1))
                crmLang2.ApplyResources(c2, c2.Name, New CultureInfo(Language)) 'Set desired language
            Next
        Next
    End Sub
    Private Sub EspañolToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EspañolToolStripMenuItem.Click
        Español()
        EspañolToolStripMenuItem.CheckState = CheckState.Checked
        EnglishToolStripMenuItem.CheckState = CheckState.Unchecked
    End Sub
    Private Sub EnglishToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishToolStripMenuItem.Click
        English()
        EnglishToolStripMenuItem.CheckState = CheckState.Checked
        EspañolToolStripMenuItem.CheckState = CheckState.Unchecked
    End Sub

#End Region
    ' Cargar Formulario
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        English()
        ''Cargar Idioma
        'EnglishToolStripMenuItem.CheckState = My.Settings.EN
        'If EnglishToolStripMenuItem.CheckState = CheckState.Checked Then
        '    English()
        '    EnglishToolStripMenuItem.CheckState = CheckState.Checked
        '    EspañolToolStripMenuItem.CheckState = CheckState.Unchecked
        'Else
        '    Español()
        '    EspañolToolStripMenuItem.CheckState = CheckState.Checked
        '    EnglishToolStripMenuItem.CheckState = CheckState.Unchecked
        'End If
        My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\temp") ' "Directorio temporal para trabajar con el audio adx c:/temp"
        Dim b() As Byte = My.Resources.ADX2WAV
        File.WriteAllBytes(Application.StartupPath & "\temp\ADX2WAV.EXE", b)
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            My.Computer.FileSystem.DeleteDirectory(Application.StartupPath & "\temp", FileIO.DeleteDirectoryOption.DeleteAllContents)
        Catch ex As Exception

        End Try
        'Guardar idioma elegido
        My.Settings.EN = EnglishToolStripMenuItem.CheckState
        My.Settings.Save()
    End Sub
    'Buscar archivo adx
    Private Sub BtnADX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnADX.Click
        Dim openDlg As New System.Windows.Forms.OpenFileDialog
        openDlg.Filter = "ADX Sound File |*.adx" + "|All Files|*.*"
        If openDlg.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        If Not openDlg.FileName Is Nothing Then
            My.Computer.FileSystem.CopyFile(openDlg.FileName, Application.StartupPath & "\temp\temp.adx", overwrite:=True)
            adxplay()
        End If
    End Sub
    'Detener reproducción
    Private Sub BtnStop2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStop2.Click
        My.Computer.Audio.Stop()
    End Sub
    'Detener reproducción
    Private Sub Btnstop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnstop.Click
        My.Computer.Audio.Stop()
    End Sub


    'Reproducir
    Private Sub Btnplay2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnplay2.Click
        adxplay()
    End Sub
    'play


    'Play
    Private Sub Btnplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnplay.Click
        adx_extract(OFDs_sound.FileName, Me.DataGridView1.CurrentRow.Cells(2).Value.ToString)
        adxplay()


    End Sub
    Private Sub BtnxSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSound.Click
        If OFD.FileName = Nothing Then
            MsgBox("Primero debes abrir el archivo bin")
            Exit Sub
        End If

        If OFDs_sound.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Btnplay.Enabled = True
            Btnstop.Enabled = True
        End If
    End Sub

    'Eliminar Fila con tecla SUPR
    Private Sub DataGridView1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp
        If e.KeyData = Keys.Delete Then
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        End If
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        adx_extract(OFDs_sound.FileName, Me.DataGridView1.CurrentRow.Cells(2).Value.ToString)
        adxplay()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Nada que exportar", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim save_csv As New System.Windows.Forms.SaveFileDialog
        save_csv.Filter = "CSV File |*.csv" + "|All Files|*.*"
        If save_csv.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim QueueHdr = (From header As DataGridViewColumn In DataGridView1.Columns.Cast(Of DataGridViewColumn)()
                            Select header.HeaderText).ToArray

            Dim QueueRows = From row As DataGridViewRow In DataGridView1.Rows.Cast(Of DataGridViewRow)()
                            Where Not row.IsNewRow
                            Select Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell).ToArray, Function(c) If(c.Value IsNot Nothing, c.Value.ToString, ""))

            Using sw As New IO.StreamWriter(save_csv.FileName)

                sw.WriteLine(String.Join(",", QueueHdr))
                For Each r In QueueRows
                    sw.WriteLine(String.Join(",", r))
                Next

            End Using



            MsgBox("OK", MsgBoxStyle.Information)
        End If

    End Sub

    Private Function Find(ByVal StrSearchString As String) As Boolean

        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Dim intcount As Integer = 0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            If DataGridView1.Rows(intcount).Cells(0).Value.ToString = StrSearchString Then
                DataGridView1.Rows(intcount).Selected = True
                Find = True
                Exit Function
            End If
            intcount += 1
        Next Row
        Find = False
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim open_csv As New System.Windows.Forms.OpenFileDialog
        open_csv.Filter = "CSV File |*.csv" + "|All Files|*.*"
        If open_csv.ShowDialog() = Windows.Forms.DialogResult.OK Then

            'GuardarToolStripMenuItem.Enabled = True
            GuardarComoToolStripMenuItem.Enabled = True
            GroupBox1.Enabled = True
            GroupBox3.Enabled = True
            GroupBox4.Enabled = True
            DataGridView1.Enabled = True
            BtnBorrar.Enabled = True
            BtnBorrartodo.Enabled = True
            'DataGridView1.Rows.Clear()

            Using fielRead As New StreamReader(open_csv.FileName)
                Dim line As String = fielRead.ReadLine

                Do While (Not line Is Nothing)
                    Dim partes As String() = line.Split(","c) ' se establece el separador 
                    line = fielRead.ReadLine
                    If Not IsNumeric(partes(0)) Then
                    Else
                        Dim indexrow As Integer = -1
                        ':::Nos permite recorrer las filas del DGTabla
                        For Each Row As DataGridViewRow In DataGridView1.Rows
                            If DataGridView1.Item(0, Row.Index).Value = partes(0) Then
                                indexrow = Row.Index
                                Exit For
                            End If
                        Next
                        If indexrow = -1 Then
                            DataGridView1.Rows.Add(partes(0), partes(1), partes(2), True)
                        Else
                            DataGridView1.Rows(indexrow).Cells(2).Value = partes(2)
                        End If
                    End If
                Loop
            End Using
            MsgBox("OK", MsgBoxStyle.Information)
        End If
    End Sub
End Class
