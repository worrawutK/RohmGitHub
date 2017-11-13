Public Class ConfirmationDialog

    Private Shared m_Instance As ConfirmationDialog

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Shared Function AskForConfirmation(ByVal askingMessage As String) As DialogResult

        If m_Instance Is Nothing OrElse m_Instance.IsDisposed Then
            m_Instance = New ConfirmationDialog()
        End If

        m_Instance.AskingMessageLabel.Text = askingMessage
        Return m_Instance.ShowDialog()
    End Function

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub CLButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class