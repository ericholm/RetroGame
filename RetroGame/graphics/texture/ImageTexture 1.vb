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

End Class
