Public Class Centre_Banner
    Dim toclose As Boolean
    Private Sub Centre_Banner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox1.Image = My.Resources.Амиго_Заставка
        Me.Left = MousePosition.X - 400
        Me.Top = MousePosition.Y - 300
    End Sub
    Private Sub PictureBox1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            PictureBox1.Cursor = Cursors.UpArrow
            toclose = True
        End If
    End Sub
    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If toclose = False Then
            If e.Button <> MouseButtons.Left Then
                Me.Left = MousePosition.X - 400
                Me.Top = MousePosition.Y - 300
            End If
        Else
            If e.Y < 40 Then
                toclose = False
                Me.Close()
            ElseIf e.Y > 500 Then
                toclose = False
                Me.Left = MousePosition.X - 400
                Me.Top = MousePosition.Y - 300
                PictureBox1.Cursor = Cursors.SizeAll
            ElseIf e.X < 100 Then
                toclose = False
                Me.Left = MousePosition.X - 400
                Me.Top = MousePosition.Y - 300
                PictureBox1.Cursor = Cursors.SizeAll
            ElseIf e.X > 700 Then
                toclose = False
                Me.Left = MousePosition.X - 400
                Me.Top = MousePosition.Y - 300
                PictureBox1.Cursor = Cursors.SizeAll
            End If
        End If
    End Sub
    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If e.Button = MouseButtons.Left Then
            PictureBox1.Cursor = Cursors.Default
        End If
        toclose = False
    End Sub
    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        If toclose = False Then
            PictureBox1.Cursor = Cursors.SizeAll
        End If
    End Sub
    Private Sub Centre_Banner_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Activate()
    End Sub
End Class
