﻿Public Class ShapeTexture : Inherits Texture

#Region "Member Variables"
    Enum ShapeType
        Rectangle
        Ellipse
    End Enum

    Private _brush As Brush
    Public Property brush() As Brush
        Get
            Return _brush
        End Get
        Set(ByVal value As Brush)
            _brush = value
        End Set
    End Property

    Private _shape As ShapeType
    Public Property shape() As ShapeType
        Get
            Return _shape
        End Get
        Set(ByVal value As ShapeType)
            _shape = value
        End Set
    End Property
#End Region

    Public Sub New(shape As ShapeType, size As Size, brush As Brush)
        Me.shape = shape
        Me.width = size.Width
        Me.height = size.Height
        Me.brush = brush
    End Sub

End Class
