Imports System.IO

Module ReadWrite

    Public Function adxplay()
        Dim comillas As String = """"
        Dim infile As String = comillas & Application.StartupPath & "\temp\temp.adx" & comillas
        Dim outfile As String = comillas & Application.StartupPath & "\temp\temp.wav" & comillas

        Dim adxdecoder As New ProcessStartInfo(Application.StartupPath & "\temp\ADX2WAV.EXE")
        adxdecoder.WindowStyle = ProcessWindowStyle.Hidden
        adxdecoder.Arguments = infile & " " & outfile
        Dim proc = Process.Start(adxdecoder)
        proc.WaitForExit()
        If File.Exists(Application.StartupPath & "\temp\temp.wav") Then My.Computer.Audio.Play(Application.StartupPath & "\temp\temp.wav", AudioPlayMode.Background)

        Return False
    End Function
    Public Function adx_extract(ByVal afs_patch As String, ByVal Callnamesunknow As String)
        'Selección de X_sound
        If File.Exists(afs_patch) Then

            Dim fs As New FileStream(afs_patch, FileMode.Open)
            Dim br As New BinaryReader(fs)

            Dim Calcularinicio As Integer = (Callnamesunknow * 8) + 8


            fs.Position = Calcularinicio
            Dim Inicio As Integer = br.ReadInt32()

            fs.Position = Calcularinicio + 4
            Dim Longitud As Integer = br.ReadInt32()

            Dim adxbytes(Longitud) As Byte

            fs.Seek(Inicio, SeekOrigin.Begin)
            adxbytes = br.ReadBytes(Longitud)

            fs.Close()
            br.Close()

            Dim out As New FileStream(Application.StartupPath & "\temp\temp.adx", FileMode.Create)
            Dim bw As New BinaryWriter(out)
            out.Position = 0
            bw.Write(adxbytes, 0, adxbytes.Length)
            out.Close()
            bw.Close()

        End If
        Return False
    End Function
End Module
