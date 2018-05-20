Public Class GameConfig

    'Camera Constants
    Public Shared MIN_CAMERA_ZOOM As Decimal = 0.2
    Public Shared MAX_CAMERA_ZOOM As Decimal = 4
    Public Shared CAMERA_MOVE_SPEED As Decimal = 50
    Public Shared CAMERA_ZOOM_RATE_MODIFIER As Integer = 1000 'Inverse where higher means slower

    Public Shared FPS As Integer = 60

    Public Shared Sub loadConfig()

    End Sub

End Class
