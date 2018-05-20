
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
        Debug.WriteLine(gameWidth)
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
    ''' <param name="deltaT">Time delta since last execution in seconds</param>
    Public Sub tick(deltaT As Decimal)
        x += 1
        Dim cameraSpeed = 5 * deltaT 'Temp Code to test camera
        If KeyHandler.isKeyPressed(Keys.Right) Then
            camera.translate(cameraSpeed, 0)
        End If
        If KeyHandler.isKeyPressed(Keys.Left) Then
            camera.translate(-cameraSpeed, 0)
        End If
        If KeyHandler.isKeyPressed(Keys.Up) Then
            camera.translate(0, -cameraSpeed)
        End If
        If KeyHandler.isKeyPressed(Keys.Down) Then
            camera.translate(0, cameraSpeed)
        End If
    End Sub

    ''' <summary>
    ''' Draw events occur in this function
    ''' </summary>
    Public Sub render(g As Graphics)
        graphics.update(g)
        graphics.FillEllipse(Brushes.Red, New Rectangle(New Point(-gameWidth / 2, 0), New Size(size, size)))
    End Sub

End Class
