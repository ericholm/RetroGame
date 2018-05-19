''' <summary>
''' Represents an on screen game object
''' </summary>
Public MustInherit Class Entity

    'TODO: Look at using width and height of textures, implementing scaling

#Region "Member Variables"
    Private _pos As Vector2f
    Public Property pos() As Vector2f
        Get
            Return _pos
        End Get
        Set(ByVal value As Vector2f)
            _pos = value
        End Set
    End Property

    Private _texture As Texture
    Public Property texture() As Texture
        Get
            Return _texture
        End Get
        Set(ByVal value As Texture)
            _texture = value
        End Set
    End Property

#End Region

    Public MustOverride Function tick(delta As Decimal)
    Public MustOverride Function render()

End Class
