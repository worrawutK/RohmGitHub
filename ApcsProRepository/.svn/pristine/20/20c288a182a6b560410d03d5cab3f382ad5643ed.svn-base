Imports System.Web

Public Class FormSetupReport

    Private m_SetupRecord As DBxDataSet.FTSetupReportRow

    Public Sub ViewSetupReportOfMachine(ByVal mcNo As String)

        Dim record As DBxDataSet.FTSetupReportRow = Nothing

        Using adaptor As DBxDataSetTableAdapters.FTSetupReportTableAdapter = New DBxDataSetTableAdapters.FTSetupReportTableAdapter()
            Using dt As DBxDataSet.FTSetupReportDataTable = adaptor.GetDataByMCNo(mcNo)

                If dt.Rows.Count = 0 Then
                    Exit Sub
                Else
                    record = CType(dt.Rows(0), DBxDataSet.FTSetupReportRow)
                End If

                m_SetupRecord = record

                LabelMCNo.Text = record.MCNo

                If record.IsSetupStartDateNull() Then
                    LabelSetupStartTime.Text = ""
                Else
                    LabelSetupStartTime.Text = record.SetupStartDate.ToString("MMM/dd HH:mm")
                End If
                If record.IsSetupEndDateNull() Then
                    LabelSetupEndTime.Text = ""
                Else
                    LabelSetupEndTime.Text = record.SetupEndDate.ToString("MMM/dd HH:mm")
                End If
                If record.IsSetupConfirmDateNull() Then
                    LabelSetupConfirmedTime.Text = ""
                Else
                    LabelSetupConfirmedTime.Text = record.SetupConfirmDate.ToString("MMM/dd HH:mm")
                End If
                LabelSetupStatus.Text = record.SetupStatus

                If record.IsTestFlowNull() Then
                    LabelTestFlow.Text = Nothing
                Else
                    LabelTestFlow.Text = record.TestFlow
                End If

                If record.IsDeviceNameNull() Then
                    LabelFTDevice.Text = Nothing
                Else
                    LabelFTDevice.Text = record.DeviceName
                End If

                If record.IsPackageNameNull() Then
                    LabelPackage.Text = Nothing
                Else
                    LabelPackage.Text = record.PackageName
                End If

                If record.IsLotNoNull() Then
                    LabelLotNo.Text = Nothing
                Else
                    LabelLotNo.Text = record.LotNo
                End If

                If record.IsTesterTypeNull() Then
                    LabelTesterType.Text = Nothing
                Else
                    LabelTesterType.Text = record.TesterType
                End If

                If record.IsTesterNoANull() Then
                    LabelTesterNoChA.Text = Nothing
                Else
                    LabelTesterNoChA.Text = record.TesterNoA
                End If

                If record.IsTesterNoBNull() Then
                    LabelTesterNoChB.Text = Nothing
                Else
                    LabelTesterNoChB.Text = record.TesterNoB
                End If

                If record.IsChannelAFTBNull() Then
                    LabelFtbChA.Text = Nothing
                Else
                    LabelFtbChA.Text = record.ChannelAFTB
                End If

                If record.IsChannelBFTBNull() Then
                    LabelFtbChB.Text = Nothing
                Else
                    LabelFtbChB.Text = record.ChannelBFTB
                End If

                If record.IsTestBoxANull() Then
                    LabelTestBoxOrBoardChA.Text = Nothing
                Else
                    LabelTestBoxOrBoardChA.Text = record.TestBoxA
                End If

                If record.IsTestBoxBNull() Then
                    LabelTestBoxOrBoardChB.Text = Nothing
                Else
                    LabelTestBoxOrBoardChB.Text = record.TestBoxB
                End If

                If record.IsAdaptorANull() Then
                    LabelAdaptorChA.Text = Nothing
                Else
                    LabelAdaptorChA.Text = record.AdaptorA
                End If

                If record.IsAdaptorBNull() Then
                    LabelAdaptorChB.Text = Nothing
                Else
                    LabelAdaptorChB.Text = record.AdaptorB
                End If

                If record.IsBridgecableANull() Then
                    LabelBridgeCableChA.Text = Nothing
                Else
                    LabelBridgeCableChA.Text = record.BridgecableA
                End If

                If record.IsBridgecableBNull() Then
                    LabelBridgeCableChB.Text = Nothing
                Else
                    LabelBridgeCableChB.Text = record.BridgecableB
                End If

                If record.IsDutcardANull() Then
                    LabelDutcardChA.Text = Nothing
                Else
                    LabelDutcardChA.Text = record.DutcardA
                End If

                If record.IsDutcardBNull() Then
                    LabelDutcardChB.Text = Nothing
                Else
                    LabelDutcardChB.Text = record.DutcardB
                End If

                If record.IsOptionName1Null() Then
                    LabelOption1.Text = Nothing
                Else
                    LabelOption1.Text = record.OptionName1
                End If

                If record.IsOptionName2Null() Then
                    LabelOption2.Text = Nothing
                Else
                    LabelOption2.Text = record.OptionName2
                End If

                If record.IsOptionName3Null() Then
                    LabelOption3.Text = Nothing
                Else
                    LabelOption3.Text = record.OptionName3
                End If

                If record.IsOptionName4Null() Then
                    LabelOption4.Text = Nothing
                Else
                    LabelOption4.Text = record.OptionName4
                End If

                If record.IsOptionName5Null() Then
                    LabelOption5.Text = Nothing
                Else
                    LabelOption5.Text = record.OptionName5
                End If

                If record.IsOptionName6Null() Then
                    LabelOption6.Text = Nothing
                Else
                    LabelOption6.Text = record.OptionName6
                End If

                If record.IsOptionName7Null() Then
                    LabelOption7.Text = Nothing
                Else
                    LabelOption7.Text = record.OptionName7
                End If

                If record.IsProgramNameNull() Then
                    TestProgramLabel.Text = Nothing
                Else
                    TestProgramLabel.Text = record.ProgramName
                End If

            End Using
        End Using

        'show information from EQP
        Using adap0 As DBxDataSetTableAdapters.FTPCTypeTableAdapter = New DBxDataSetTableAdapters.FTPCTypeTableAdapter()
            Using tbl0 As DBxDataSet.FTPCTypeDataTable = adap0.GetPCType(mcNo)

                If tbl0.Rows.Count > 0 Then
                    Dim row0 As DBxDataSet.FTPCTypeRow = CType(tbl0.Rows(0), DBxDataSet.FTPCTypeRow)
                    AdditionPartLabel.Text = row0.PCType
                    BaseHandlerLabel.Text = row0.PCMain
                Else
                    'in case of not found
                    AdditionPartLabel.Text = Nothing
                    BaseHandlerLabel.Text = Nothing
                End If

            End Using
        End Using

    End Sub

    Private Sub CLButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
    End Sub

    Private Sub OpenBomByDeviceButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenBomByDeviceButton.Click
        'http://webserv.thematrix.net/bom/Default.aspx?Device=
        IE.OpenUrl(My.Settings.BomWebsiteUrl & "?Device=" & HttpUtility.UrlEncode(m_SetupRecord.DeviceName))
    End Sub
End Class