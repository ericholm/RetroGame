Imports System.Drawing.Drawing2D


''' <summary>
''' Main Form to which the game is drawn to
''' </summary>
Public Class MainForm

    Private game As Game

    Private Sub GameTimer_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick
        game.tick()
        Me.Invalidate()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        game = New Game(ClientSize.Width, ClientSize.Height)
        GameTimer.Interval = (1000 / 60) 'Set Frame Rate
        GameTimer.Start()
    End Sub

    Private Sub MainForm_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias 'Sets the draw mode
        game.render(e.Graphics)
    End Sub

    Private Sub MainForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
    End Sub

    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

End Class