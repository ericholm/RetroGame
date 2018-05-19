
''' <summary>
''' Object where all the game loops are
''' </summary>
Public Class Game

    Public x As Integer = 0
    Public size As Integer = 64

    Public Sub New()
    End Sub


    ''' <summary>
    ''' Logic updates occur in this function
    ''' </summary>
    Public Sub tick()
        x += 1
    End Sub

    ''' <summary>
    ''' Draw events occur in this function
    ''' </summary>
    Public Sub render(g As Graphics)
        g.FillEllipse(Brushes.Red, New Rectangle(New Point(70, 100), New Size(size, size)))
    End Sub

End Class
