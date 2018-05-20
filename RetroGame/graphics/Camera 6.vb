
Imports RetroGame
''' <summary>
''' Camera object representing current viewport on screen
''' </summary>
Public Class Camera : Implements MouseListener

#Region "Member Variables"

    Private _zoomLevel As Decimal
    Public Property zoomLevel() As Decimal
        Get
            Return _zoomLevel
        End Get
        Set(ByVal value As Decimal)
            _zoomLevel = value
        End Set
    End Property

    Private _viewPortWidth As Integer
    Public Property viewPortWidth() As Integer
        Get
            Return _viewPortWidth
        End Get
        Set(ByVal value As Integer)
            _viewPortWidth = value
        End Set
    End Property

    Private _viewPortHeight As Integer
    Public Property viewPortHeight() As Integer
        Get
            Return _viewPortHeight
        End Get
        Set(ByVal value As Integer)
            _viewPortHeight = value
        End Set
    End Property

    Private _pos As Vector2f
    Public Property pos() As Vector2f
        Get
            Return _pos
        End Get
        Set(ByVal value As Vector2f)
            _pos = value
        End Set
    End Property

#End Region

    Public Sub New(zoomLevel As Decimal, x As Integer, y As Integer, viewPortWidth As Integer, viewPortHeight As Integer)
        Me.zoomLevel = zoomLevel
        Me.pos = New Vector2f(x, y)
        Me.viewPortWidth = viewPortWidth
        Me.viewPortHeight = viewPortHeight
        InputHandler.mouseListeners.Add(Me)
    End Sub

    ''' <summary>
    ''' Moves the camera by xAmount and yAmount
    ''' </summary>
    ''' <param name="xAmount"></param>
    ''' <param name="yAmount"></param>
    Public Sub translate(ByVal xAmount As Decimal, ByVal yAmount As Decimal)
        Me.pos.x += xAmount
        Me.pos.y += yAmount
    End Sub

    Public Sub MouseScroll(e As MouseEventArgs) Implements MouseListener.MouseScroll
        Me.zoomLevel += (e.Delta / 500)
        Debug.WriteLine(zoomLevel)
    End Sub

End Class
