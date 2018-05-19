
''' <summary>
''' Camera object representing current viewport on screen
''' </summary>
Public Class Camera

#Region "Members"
    Private instance As Camera

    Private _zoomLevel As Decimal
    Public Property zoomLevel() As Decimal
        Get
            Return _zoomLevel
        End Get
        Set(ByVal value As Decimal)
            _zoomLevel = value
        End Set
    End Property

    Private xPos As Integer
    Public Property x() As Integer
        Get
            Return xPos
        End Get
        Set(ByVal value As Integer)
            xPos = value
        End Set
    End Property

    Private yPos As Integer
    Public Property y() As Integer
        Get
            Return yPos
        End Get
        Set(ByVal value As Integer)
            yPos = value
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

#End Region

    Public Sub New(zoomLevel As Decimal, x As Integer, y As Integer, viewPortWidth As Integer, viewPortHeight As Integer)
        Me.zoomLevel = zoomLevel
        Me.x = x
        Me.y = y
        Me.viewPortWidth = viewPortWidth
        Me.viewPortHeight = viewPortHeight
    End Sub

    ''' <summary>
    ''' Moves the camera by xAmount and yAmount
    ''' </summary>
    ''' <param name="xAmount"></param>
    ''' <param name="yAmount"></param>
    Public Sub translate(ByVal xAmount As Integer, ByVal yAmount As Integer)
        Me.xPos += xAmount
        Me.yPos += yAmount
    End Sub

End Class
