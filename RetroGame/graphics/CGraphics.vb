﻿Imports System.Drawing.Drawing2D
''' <summary>
''' Extension of Graphics to support camera by offsetting drawing so that everything is drawn relative to camera
''' </summary>
Public Class CGraphics

    'TODO: Implement viewport checks so as to only draw within the viewport for performance optimisation

    Private graphics As Graphics
    Private camera As Camera

    Public Sub New(camera)
        Me.camera = camera
    End Sub

    Public Sub update(graphics As Graphics)
        Me.graphics = graphics
    End Sub

    Public Sub drawEntity(entity As Entity)
        drawTexture(entity.texture, entity.pos)
    End Sub

    ''' <summary>
    ''' Draws a base texture object
    ''' </summary>
    ''' <param name="texture">Texture to be drawn</param>
    ''' <param name="pos">Position for texture to be drawn at</param>
    Public Sub drawTexture(texture As Texture, pos As Vector2f)
        If texture.GetType.IsAssignableFrom(GetType(ImageTexture)) Then
            'Draw Image Texture
            Dim boundingRect = New Rectangle(MathUtil.VectorToPoint(pos), New Size(texture.width, texture.height))
            Dim imageTexture As ImageTexture = CType(texture, ImageTexture)
            DrawImage(imageTexture.image, boundingRect)
        ElseIf texture.GetType.IsAssignableFrom(GetType(ShapeTexture)) Then
            'Draw Shape Texture
            Dim boundingRect = New Rectangle(MathUtil.VectorToPoint(pos), New Size(texture.width, texture.height))
            Dim shapeTexture As ShapeTexture = CType(texture, ShapeTexture)
            Select Case shapeTexture.shape
                Case ShapeTexture.ShapeType.Ellipse
                    FillEllipse(shapeTexture.brush, boundingRect)
                Case ShapeTexture.ShapeType.Rectangle
                    FillRect(shapeTexture.brush, boundingRect)
            End Select
        End If
    End Sub

    Public Sub DrawImage(image As Image, pos As Vector2f)
        Dim rect = New Rectangle(MathUtil.VectorToPoint(pos), image.Size)
        Debug.WriteLine(rect.ToString)
        rect.Offset(New Point(camera.pos.x + camera.viewPortWidth / 2, camera.pos.y + camera.viewPortHeight / 2))
        MathUtil.scaleRect(rect, camera.zoomLevel)
        Dim attr As New Imaging.ImageAttributes()
        attr.SetWrapMode(WrapMode.TileFlipXY)
        graphics.DrawImage(image, rect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attr)
    End Sub

    Public Sub DrawImage(image As Image, rect As Rectangle)
        rect.Offset(New Point(camera.pos.x + camera.viewPortWidth / 2, camera.pos.y + camera.viewPortHeight / 2))
        MathUtil.scaleRect(rect, camera.zoomLevel)
        Dim attr As New Imaging.ImageAttributes()
        attr.SetWrapMode(WrapMode.TileFlipXY)
        'graphics.DrawImage(image, rect)
        graphics.DrawImage(image, rect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attr)
    End Sub

    Public Sub FillEllipse(brush As Brush, rect As Rectangle)
        rect.Offset(New Point(camera.pos.x + camera.viewPortWidth / 2, camera.pos.y + camera.viewPortHeight / 2))
        MathUtil.scaleRect(rect, camera.zoomLevel)
        graphics.FillEllipse(brush, rect)
    End Sub

    Public Sub FillRect(brush As Brush, rect As Rectangle)
        rect.Offset(New Point(camera.pos.x + camera.viewPortWidth / 2, camera.pos.y + camera.viewPortHeight / 2))
        MathUtil.scaleRect(rect, camera.zoomLevel)
        graphics.FillRectangle(brush, rect)
    End Sub

End Class
