''' <summary>
''' Contains useful math based functions
''' </summary>
Public Class MathUtil

    Public Shared Function VectorToPoint(vector As Vector2f) As Point
        Return New Point(vector.x, vector.y)
    End Function

    Public Shared Sub scaleRect(ByRef rect As Rectangle, scale As Decimal)
        Dim scaledWidth As Decimal = rect.Width * scale
        Dim scaledHeight As Decimal = rect.Height * scale
        Dim x As Decimal = (rect.X - (MainForm.ClientSize.Width / 2)) * scale + (MainForm.ClientSize.Width / 2)
        Dim y As Decimal = (rect.Y - (MainForm.ClientSize.Height / 2)) * scale + (MainForm.ClientSize.Height / 2)

        rect = New Rectangle(x, y,
            scaledWidth, scaledHeight) 'Sets rectangle to new scaled sizes and modifies position so that relative positions are the same
    End Sub

End Class
