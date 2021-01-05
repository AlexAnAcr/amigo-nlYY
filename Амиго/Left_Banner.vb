Public Class Left_Banner
    Private Sub Left_Banner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Width = Int(My.Computer.Screen.Bounds.Width / 6)
        Me.Left = -Me.Width
        Me.Top = Int(My.Computer.Screen.Bounds.Height / 5)
        Me.Height = My.Computer.Screen.Bounds.Height - Me.Top
        Me.Cursor = New Cursor(Top_Banner.AmigoCursor)
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "/AmigoNote.txt", TextBox1.Text, False)
    End Sub
    Private Sub Left_Banner_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "/AmigoNote.txt") = False Then
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "/AmigoNote.txt", "", False)
        Else
            TextBox1.Text = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "/AmigoNote.txt")
        End If
    End Sub
End Class
