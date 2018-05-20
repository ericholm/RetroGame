''' <summary>
''' Represents an on screen game object
''' </summary>
Public Class Entity

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

    Private _velocity As Vector2f
    Public Property velocity() As Vector2f
        Get
            Return _velocity
        End Get
        Set(ByVal value As Vector2f)
            _velocity = value
        End Set
    End Property

#End Region

    Public Sub New(pos As Vector2f, texture As Texture)
        Me.pos = pos
        Me.texture = texture
        Me.velocity = New Vector2f(0, 0)
    End Sub

    ''' <summary>
    ''' Default entity tick implementation
    ''' </summary>
    ''' <param name="delta">Time since last tick in seconds</param>
    Public Sub tick(delta As Decimal)
        'Update position based on current velocity
        pos.x += velocity.x * delta
        pos.y += velocity.y * delta
    End Sub

    ''' <summary>
    ''' Default entity render implementation
    ''' </summary>
    ''' <param name="g">Graphics object</param>
    Public Sub render(g As CGraphics)
        g.drawEntity(Me)
    End Sub

End Class
