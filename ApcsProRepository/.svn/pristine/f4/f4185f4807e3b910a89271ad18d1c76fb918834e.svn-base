Public Class QualityAbnormalObjectLotCardForm


    Private Sub btnQRCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQRCode.Click
        SetQRCodeTextBoxReady()
    End Sub


    Private Sub SetQRCodeTextBoxReady()
        QRCodeTextBox.Text = ""
        QRCodeTextBox.Focus()
        ProgressBar1.Value = 0
    End Sub

    Private Sub QualityAbnormalObjectLotCardForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        QRCodeTextBox.Focus()
        ProgressBar1.Value = 0
    End Sub

    Public ReadOnly Property InputText() As String
        Get
            Return QRCodeTextBox.Text
        End Get
    End Property

    Private Sub QRCodeTextBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles QRCodeTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not String.IsNullOrEmpty(QRCodeTextBox.Text) Then
                ProgressBar1.Value = ProgressBar1.Maximum
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Else
            If ProgressBar1.Value < ProgressBar1.Maximum Then
                ProgressBar1.Value += 1
            End If
        End If
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

End Class