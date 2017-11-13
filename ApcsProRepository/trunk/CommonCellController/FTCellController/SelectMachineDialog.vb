Imports Rohm.Common.CellController

Public Class SelectMachineDialog

    Public Property Datasource() As Object
        Get
            Return BindingSourceMachine.DataSource
        End Get
        Set(ByVal value As Object)
            BindingSourceMachine.DataSource = value
        End Set
    End Property

    Private c_SelectedMachine As Machine
    Public Property SelectedMachine() As Machine
        Get
            Return c_SelectedMachine
        End Get
        Set(ByVal value As Machine)
            c_SelectedMachine = value
        End Set
    End Property

    Private Sub ButtonSelectMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSelectMachine.Click
        c_SelectedMachine = CType(BindingSourceMachine.Current, Machine)
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

End Class