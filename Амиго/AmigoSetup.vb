Public Class AmigoSetup
    Private Sub AmigoSetup_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Setup.Start()
        Me.Cursor = New Cursor(Top_Banner.AmigoCursor2)
        Me.TopMost = True
        Me.Activate()
    End Sub
    Dim toclose As String = False
    Private Sub AmigoSetup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If toclose = False Then
            MsgBox("Автоматическая установка не завершена!")
            e.Cancel = True
        End If
    End Sub
    Dim number As Short = 0
    Private Sub Setup_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Setup.Tick
        If number = 100 Then
            Try
                My.Computer.FileSystem.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/Amigo.exe", My.Resources.AmigoSetup, True)
                Shell("RunDLL32.exe shell32.dll,ShellExec_RunDLL " & Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Amigo.exe")
            Catch
            End Try
            Top_Banner.Amigo_Buttons.Start()
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\AmigoSetup.ls3")
            toclose = True
            Me.Close()
        Else
            Dim r As New Random
            Setup.Interval = r.Next(500, 1500)
            number += 1
            Progress11.Value = number
        End If
        If number = 1 Then
            Me.TopMost = False
        End If
    End Sub
    Dim position As Point
    Private Sub AmigoSetup_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        position.X = e.X
        position.Y = e.Y
    End Sub
    Private Sub AmigoSetup_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left And e.X >= Me.Width - 100 And e.Y <= 50 Then
            Me.Left = Me.Left + e.X - position.X
            Me.Top = Me.Top + e.Y - position.Y
        End If
    End Sub
End Class