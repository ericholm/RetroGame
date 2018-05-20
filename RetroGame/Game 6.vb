
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
        camera = New Camera(1, 0, 0, gameWidth, gameHeight)
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
        If InputHandler.isKeyPressed(Keys.D) Then
            camera.translate(cameraSpeed, 0)
        End If
        If InputHandler.isKeyPressed(Keys.A) Then
            camera.translate(-cameraSpeed, 0)
        End If
        If InputHandler.isKeyPressed(Keys.W) Then
            camera.translate(0, -cameraSpeed)
        End If
        If InputHandler.isKeyPressed(Keys.S) Then
            camera.translate(0, cameraSpeed)
        End If
    End Sub

    ''' <summary>
    ''' Draw events occur in this function
    ''' </summary>
    Public Sub render(g As Graphics)
        graphics.update(g)
        graphics.FillEllipse(Brushes.Blue, New Rectangle(New Point(x - gameWidth / 2, 0), New Size(size, size)))
        graphics.FillEllipse(Brushes.Red, New Rectangle(New Point(-gameWidth / 2, 0), New Size(size, size)))
        graphics.drawTexture(New ShapeTexture(ShapeTexture.ShapeType.Ellipse, New Size(32, 32), Brushes.SaddleBrown), New Vector2f(0, 0))
    End Sub

End Class
