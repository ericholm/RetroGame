''' <summary>
''' Object for a group of connected textures
''' </summary>
Public Class TextureBatch

    Private _batchImage As Bitmap
    Public ReadOnly Property batchImage() As Image
        Get
            Return _batchImage
        End Get
    End Property

    Public Sub New(textures As List(Of ImageTexture), positions As List(Of Vector2f))
        Dim totalWidth As Integer = 0
        Dim totalHeight As Integer = 0

        For i = 0 To textures.Count - 1
            totalWidth = Math.Max(totalWidth, textures(i).width + positions(i).x)
            totalHeight = Math.Max(totalHeight, textures(i).height + positions(i).y)
        Next
        _batchImage = New Bitmap(totalWidth, totalHeight)
        Dim g As Graphics = Graphics.FromImage(_batchImage)
        For i = 0 To textures.Count - 1
            g.DrawImage(textures(i).image, MathUtil.VectorToPoint(positions(i)))
        Next

    End Sub

End Class
