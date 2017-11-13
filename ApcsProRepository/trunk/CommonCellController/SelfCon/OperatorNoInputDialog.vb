Public Class OperatorNoInputDialog

    Private Shared m_Instance As OperatorNoInputDialog

    Public Shared Function GetInstance() As OperatorNoInputDialog
        If m_Instance Is Nothing OrElse m_Instance.IsDisposed Then
            m_Instance = New OperatorNoInputDialog()
        End If
        Return m_Instance
    End Function

    Private Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public ReadOnly Property OPNo() As String
        Get
            Return OPNoTextBox.Text
        End Get
    End Property

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        If Not String.IsNullOrEmpty(OPNoTextBox.Text) Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub CLButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub OPNoTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OPNoTextBox.KeyPress
        If e.KeyChar = Chr(13) Then
            OKButton_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FormAuthentication_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        OPNoTextBox.Text = Nothing
        OPNoTextBox.Focus()
    End Sub

End Class