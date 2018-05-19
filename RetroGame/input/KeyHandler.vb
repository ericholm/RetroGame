''' <summary>
''' Keyboard input wrapper to deal with hold key delay present in windows form by default
''' Instead this keeps track and stores key press values to get around that issue
''' </summary>
Public Class KeyHandler

    Private Shared keys_down As New Dictionary(Of Integer, Boolean)
    Public Shared keyListeners As New List(Of KeyListener)

    Public Shared Sub KeyDown(e As KeyEventArgs)
        Dim keyCode As Integer = e.KeyCode
        Dim hasToggled As Boolean = False
        If keys_down.ContainsKey(keyCode) Then
            If keys_down.Item(keyCode) <> True Then
                hasToggled = True
                keys_down.Item(keyCode) = True
            End If
        Else
            keys_down.Add(keyCode, True)
            hasToggled = True
        End If
        If hasToggled Then
            For Each listener As KeyListener In keyListeners
                listener.KeyDown(e)
            Next
        End If
    End Sub

    Public Shared Sub KeyUp(e As KeyEventArgs)
        Dim keyCode As Integer = e.KeyCode
        Dim hasToggled As Boolean = False
        If keys_down.ContainsKey(keyCode) Then
            If keys_down.Item(keyCode) <> False Then
                hasToggled = True
                keys_down.Item(keyCode) = False
            End If
        Else
            keys_down.Add(keyCode, False)
            hasToggled = True
        End If
        If hasToggled Then
            For Each listener As KeyListener In keyListeners
                listener.KeyUp(e)
            Next
        End If
    End Sub

    ''' <summary>
    ''' Returns pressed state of key
    ''' </summary>
    ''' <param name="key">Key code representing key</param>
    ''' <returns></returns>
    Public Shared Function isKeyPressed(key As Integer)
        If keys_down.ContainsKey(key) Then
            Return keys_down.Item(key)
        End If
        Return False
    End Function


End Class
