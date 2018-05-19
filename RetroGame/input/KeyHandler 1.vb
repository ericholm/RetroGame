Public Class KeyHandler

    Public Shared keys_down As New Dictionary(Of Integer, Boolean)
    Public Shared keyListeners As New List(Of KeyListener)

    Private Sub MainForm_KeyDown(e As KeyEventArgs)
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
                Debug.Write("p")
                listener.KeyDown(e)
            Next
        End If
    End Sub

End Class
