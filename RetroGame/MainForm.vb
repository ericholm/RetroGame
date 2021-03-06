﻿Imports System.Drawing.Drawing2D


''' <summary>
''' Main Form to which the game is drawn to
''' </summary>
Public Class MainForm

    Private game As Game
    Private FPS As Integer = 0

    Private stopwatch As New Stopwatch()
    Private lastTime As Integer = 0
    Private debugDelay = 1000
    Private averageUp = 0
    Private frameCount = 0
    Private sinceLastDebug = 0

    'Updates FPS overlay
    Private Sub updateFps()
        Dim elapsed = stopwatch.ElapsedMilliseconds
        frameCount += 1
        averageUp += elapsed - lastTime
        If elapsed - sinceLastDebug >= debugDelay Then
            FPS = 1000 / (averageUp / frameCount)
            averageUp = 0
            frameCount = 0
            sinceLastDebug = elapsed
        End If
        lastTime = elapsed
    End Sub

    Private Sub GameTimer_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick
        updateFps()
        game.tick(System.Convert.ToDecimal(GameTimer.Interval) / 1000)
        Me.Refresh()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        game = New Game(ClientSize.Width, ClientSize.Height)
        GameTimer.Interval = (1000 / GameConfig.FPS) 'Set Frame Rate
        GameTimer.Start()
        stopwatch.Start()
    End Sub

    Private Sub MainForm_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias 'Sets the draw mode
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality
        e.Graphics.DrawString(String.Format("FPS: {0}", FPS), New Font(FontFamily.GenericMonospace, 20), Brushes.Red, 0, 0)
        game.render(e.Graphics)
    End Sub

#Region "Input Events"

    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        InputHandler.KeyDown(e)
    End Sub

    Private Sub MainForm_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        InputHandler.KeyUp(e)
    End Sub

    Private Sub MainForm_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        InputHandler.MouseScroll(e)
    End Sub

#End Region

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