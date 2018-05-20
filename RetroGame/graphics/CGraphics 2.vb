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

    Public Sub FillEllipse(brush As Brush, rect As Rectangle)
        rect.Offset(camera.pos)
        graphics.FillEllipse(brush, rect)
    End Sub

End Class
