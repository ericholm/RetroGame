Public Class MathUtil

    Public Shared Function VectorToPoint(vector As Vector2f) As Point
        Return New Point(vector.x, vector.y)
    End Function

    Public Shared Sub scaleRect(ByRef rect As Rectangle, scale As Decimal)
        rect = New Rectangle(rect.Location.X, rect.Location.Y,
            System.Convert.ToDecimal(rect.Width * scale), System.Convert.ToDecimal(rect.Height * scale))
    End Sub

End Class
