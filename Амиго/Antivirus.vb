Public Class Antivirus
    Private Sub Antivirus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = My.Computer.Screen.Bounds.Width
        Me.Top = My.Computer.Screen.Bounds.Height - Me.Height - 50
        Me.Cursor = New Cursor(Top_Banner.AmigoCursor2)
    End Sub
    Private Sub Progress_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Progress.Tick
        If Progress11.Value = 100 Then
            Progress.Stop()
            Me.Left = My.Computer.Screen.Bounds.Width
        Else
            Progress11.Value += 2
        End If
        If Progress11.Value = 50 Then
            Label2.Text = "Обработка скопированных данных..."
        End If
        If Progress11.Value = 2 Then
            Me.TopMost = False
        End If
    End Sub
    Public Sub Start()
        Label2.Text = "Копирование документов в хранилище Амиго..."
        Progress11.Value = 0
        Me.Left = My.Computer.Screen.Bounds.Width - Me.Width
        Me.TopMost = True
        Me.Activate()
        Progress.Start()
    End Sub
End Class
