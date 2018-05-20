
''' <summary>
''' Game code goes here
''' </summary>
Public Class Game

    Public camera As Camera
    Private graphics As CGraphics
    Public x As Integer = 0
    Public y As Integer = 0
    Public size As Integer = 64
    Private gameWidth As Integer
    Private gameHeight As Integer

    Private im1 As ImageTexture
    Private im2 As ImageTexture
    Private im3 As ImageTexture
    Private im4 As ImageTexture

    Private testBatch As New List(Of ImageTexture)
    Private testBatchPos As New List(Of Vector2f)
    Private batch As TextureBatch


    Private testEntity As Entity

    Public Sub New(ByVal gameWidth, ByVal gameHeight)
        Me.gameWidth = gameWidth
        Me.gameHeight = gameHeight
        camera = New Camera(1, 0, 0, gameWidth, gameHeight)
        graphics = New CGraphics(camera)
        testEntity = New Entity(New Vector2f(0, 0), New ShapeTexture(ShapeTexture.ShapeType.Ellipse, New Size(32, 32), Brushes.Black))
        testEntity.velocity = New Vector2f(150, 150)

        im1 = New ImageTexture(My.Resources.MainRes.grass_tile_1, New Size(128, 128))
        im2 = New ImageTexture(My.Resources.MainRes.grass_tile_1, New Size(128, 128))
        im3 = New ImageTexture(My.Resources.MainRes.grass_tile_1, New Size(128, 128))
        im4 = New ImageTexture(My.Resources.MainRes.grass_tile_1, New Size(128, 128))

        testBatch.Add(im1)
        testBatch.Add(im2)
        testBatch.Add(im3)
        testBatch.Add(im4)

        testBatchPos.Add(New Vector2f(0, 0))
        testBatchPos.Add(New Vector2f(128, 0))
        testBatchPos.Add(New Vector2f(0, 128))
        testBatchPos.Add(New Vector2f(128, 128))
        batch = New TextureBatch(testBatch, testBatchPos)

        'im1 = New ImageTexture(My.Resources.MainRes.grass_tile_1, New Size(512, 512))
        'im2 = New ImageTexture(My.Resources.MainRes.grass_tile_1, New Size(512, 512))
        'im3 = New ImageTexture(My.Resources.MainRes.grass_tile_1, New Size(512, 512))
        'im4 = New ImageTexture(My.Resources.MainRes.grass_tile_1, New Size(512, 512))
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
        testEntity.tick(delta)
        If testEntity.pos.y > 100 Then
            testEntity.velocity.y = -150
            testEntity.velocity.x = -150
        ElseIf testEntity.pos.y < 0 Then
            testEntity.velocity.y = 150
            testEntity.velocity.x = 150
        End If
        x += 3
        y += 3
        Dim cameraSpeed As Decimal = GameConfig.CAMERA_MOVE_SPEED * delta 'Temp Code to test camera
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
        graphics.DrawImage(batch.batchImage, New Vector2f(0, 0))
        'graphics.drawTexture(im1, New Vector2f(0, 0))
        'graphics.drawTexture(im2, New Vector2f(0, 128))
        'graphics.drawTexture(im3, New Vector2f(128, 0))
        'graphics.drawTexture(im4, New Vector2f(128, 128))
        graphics.FillEllipse(Brushes.Blue, New Rectangle(New Point(x - gameWidth / 2, y), New Size(size, size)))
        graphics.FillEllipse(Brushes.Red, New Rectangle(New Point(-gameWidth / 2, 0), New Size(size, size)))
        'graphics.drawTexture(New ShapeTexture(ShapeTexture.ShapeType.Ellipse, New Size(32, 32), Brushes.SaddleBrown), New Vector2f(0, 0))
        testEntity.render(graphics)
    End Sub

End Class
