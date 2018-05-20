Public Class ImageTexture : Inherits Texture

    Private _image As Image
    Public Property image() As Image
        Get
            Return _image
        End Get
        Set(ByVal value As Image)
            _image = value
        End Set
    End Property

    Public Sub New(image As Image, size As Size)
        Me.image = image
        Me.width = size.Width
        Me.height = size.Height
    End Sub

End Class
