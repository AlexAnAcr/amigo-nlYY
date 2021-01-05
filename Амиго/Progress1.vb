Public Class Progress1
    Dim number As UShort = 0
    Public Property Value As UShort
        Get
            Return number
        End Get
        Set(ByVal value As UShort)
            If value <= 100 Then
                number = value
                Dim image As New Bitmap(200, 30, Imaging.PixelFormat.Format32bppArgb)
                Dim gr As Graphics = Graphics.FromImage(image)
                gr.CompositingQuality = Drawing2D.CompositingQuality.HighSpeed
                Dim br As New TextureBrush(My.Resources.ProgressFill)
                gr.FillRectangle(br, 0, 0, CInt(number * 2), 30)
                PictureBox1.Image = image
            End If
        End Set
    End Property
End Class
