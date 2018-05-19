''' <summary>
''' Represents a point in 2d space using decimals
''' </summary>
Public Class Vector2f

    Private _x As Decimal
    Public Property x() As Decimal
        Get
            Return _x
        End Get
        Set(ByVal value As Decimal)
            _x = value
        End Set
    End Property

    Private _y As Decimal
    Public Property y() As Decimal
        Get
            Return _y
        End Get
        Set(ByVal value As Decimal)
            _y = value
        End Set
    End Property

    Public Sub New(x As Decimal, y As Decimal)
        Me.x = x
        Me.y = y
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("Vector({0}, {1})", x, y)
    End Function
End Class
