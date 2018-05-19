Imports System.Drawing.Drawing2D

Public Class MainForm

    Private game As New Game()

    Private Sub GameTimer_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick
        Me.Invalidate()
        game.tick()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GameTimer.Interval = 1 'Set Frame Rate
        GameTimer.Start()
    End Sub

    Private Sub MainForm_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        game.render(e.Graphics)
    End Sub

    ''' <summary>
    ''' This reduces screen flickering due to windows forms not being optimised for game development and fast update rates
    ''' Source: https://stackoverflow.com/questions/25872849/to-reduce-flicker-by-double-buffer-setstyle-vs-overriding-createparam
    ''' </summary>
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            Return cp
        End Get
    End Property

    'Private Sub Timer()

End Class