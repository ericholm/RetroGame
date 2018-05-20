
''' <summary>
''' Game code goes here
''' </summary>
Public Class Game

    Public camera As Camera
    Private graphics As CGraphics
    Public x As Integer = 0
    Public size As Integer = 64
    Private gameWidth As Integer
    Private gameHeight As Integer

    Public Sub New(ByVal gameWidth, ByVal gameHeight)
        Me.gameWidth = gameWidth
        Me.gameHeight = gameHeight
        camera = New Camera(1, gameWidth / 2, gameHeight / 2, gameWidth, gameHeight)
        graphics = New CGraphics(camera)
    End Sub

    Public Sub resize(width, height)
        gameWidth = width
        gameHeight = height
        camera.viewPortWidth = width
        camera.viewPortHeight = height
    End Sub

    ''' <summary>
    ''' Logic updates occur in this function
    ''' </summary>
    ''' <param name="delta">Time delta since last execution in seconds</param>
    Public Sub tick(delta As Decimal)
        x += 1
        Dim cameraSpeed As Decimal = 200 * delta 'Temp Code to test camera
        If KeyHandler.isKeyPressed(Keys.D) Then
            camera.translate(cameraSpeed, 0)
        End If
        If KeyHandler.isKeyPressed(Keys.A) Then
            camera.translate(-cameraSpeed, 0)
        End If
        If KeyHandler.isKeyPressed(Keys.W) Then
            camera.translate(0, -cameraSpeed)
        End If
        If KeyHandler.isKeyPressed(Keys.S) Then
            camera.translate(0, cameraSpeed)
        End If
    End Sub

    ''' <summary>
    ''' Draw events occur in this function
    ''' </summary>
    Public Sub render(g As Graphics)
        graphics.update(g)
        graphics.FillEllipse(Brushes.Red, New Rectangle(New Point(-gameWidth / 2, 0), New Size(size, size)))
        graphics.drawTexture(New ShapeTexture(), New Vector2f(10, 10))
    End Sub

End Class
