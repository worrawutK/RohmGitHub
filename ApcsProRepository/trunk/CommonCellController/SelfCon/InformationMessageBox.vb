Public Class InformationMessageBox

    Private Shared m_Instance As InformationMessageBox

    Public Shared Sub Inform(ByVal message As String)

        If m_Instance Is Nothing OrElse m_Instance.IsDisposed Then
            m_Instance = New InformationMessageBox()
        End If

        m_Instance.MessageLabel.Text = message
        m_Instance.ShowDialog()

    End Sub

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub DismissButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DismissButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub MessageLabel_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessageLabel.SizeChanged
        Me.Width = MessageLabel.Width + 92 '197 - 105
        Me.Height = MessageLabel.Height + 167 '199 - 32
        DismissButton.Left = CInt((Me.Width - DismissButton.Width) / 2)
        DismissButton.Top = Me.Height - (DismissButton.Height + 37)
    End Sub
End Class