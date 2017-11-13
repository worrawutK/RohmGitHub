Imports System.IO

Public Interface ILotSetupComponent

    Sub Initial()
    Sub InputLot(ByVal ws As WorkingSlip, ByVal o As OIS, ByVal qty As Integer, ByVal opNo As String)

End Interface

Public Class LotSetupMain
    Implements ILotSetupComponent

    Public Sub InputLot(ByVal ws As WorkingSlip, ByVal o As OIS, _
                        ByVal qty As Integer, ByVal opNo As String) Implements ILotSetupComponent.InputLot

    End Sub

    Public Sub Initial() Implements ILotSetupComponent.Initial
       
    End Sub
End Class

Public MustInherit Class LotSetupComponent
    Implements ILotSetupComponent

    Protected c_ParentComponent As ILotSetupComponent

    Protected Sub New(ByVal component As ILotSetupComponent)
        c_ParentComponent = component
    End Sub

    Public MustOverride Sub InputLot(ByVal ws As WorkingSlip, ByVal o As OIS, _
           ByVal qty As Integer, ByVal opNo As String) Implements ILotSetupComponent.InputLot

    Public Sub Initial() Implements ILotSetupComponent.Initial
        Dim frm As SetupResultForm = SetupResultForm.GetInstance()
    End Sub

End Class

Public Class LotSetupLoggingComponent
    Inherits LotSetupComponent

    Public Sub New(ByVal component As ILotSetupComponent)
        MyBase.New(component)
    End Sub

    Private c_FileName As String
    Public Property FileName() As String
        Get
            Return c_FileName
        End Get
        Set(ByVal value As String)
            c_FileName = value
        End Set
    End Property

    Public Overrides Sub InputLot(ByVal ws As WorkingSlip, ByVal o As OIS, ByVal qty As Integer, ByVal opNo As String)

        Using writer As StreamWriter = New StreamWriter(c_FileName, True)
            writer.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss") & ":" & ws.FullCode)
            writer.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss") & ":" & o.FullCode)
            writer.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss") & ":" & qty.ToString())
            writer.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss") & ":" & opNo)
        End Using

        c_ParentComponent.InputLot(ws, o, qty, opNo)

    End Sub
End Class

Public Class LotSetupSaveTransactionDataComponent
    Inherits LotSetupComponent

    Public Sub New(ByVal component As ILotSetupComponent)
        MyBase.New(component)
    End Sub

    Public Overrides Sub InputLot(ByVal ws As WorkingSlip, ByVal o As OIS, _
                                  ByVal qty As Integer, ByVal opNo As String)
        Using adaptor As DBxDataSetTableAdapters.TransactionDataTableAdapter = New DBxDataSetTableAdapters.TransactionDataTableAdapter()
            Using table As DBxDataSet.TransactionDataDataTable = adaptor.GetDataByLotNo(ws.LotNo)

                If table.Rows.Count = 0 Then
                    Dim newRow As DBxDataSet.TransactionDataRow = table.NewTransactionDataRow()
                    newRow.CleamCounterMeasure = ws.CleamCounterMeasure
                    newRow.CodeNo = ws.CodeNo
                    newRow.Device = ws.DeviceName
                    newRow.ETC1 = ws.ForIndication1
                    newRow.ETC2 = ws.ForIndication2
                    newRow.FASetDirection = ws.FarSetDirection
                    newRow.FrameNo = ws.FrameType
                    newRow.FTForm = ws.FTDevice
                    newRow.LotNo = ws.LotNo
                    newRow.MarkNo = ws.MarkNo
                    newRow.MarkTextLine1 = ws.MarkingSpec3
                    newRow.MarkTextLine2 = ws.MarkingSpec2
                    newRow.MarkTextLine3 = ws.MarkingSpec1
                    newRow.MarkType = ws.MarkType
                    newRow.Mask = ws.Mask
                    newRow.MoldType = ws.MoldType
                    newRow.NewFormName = ws.NewPackageName
                    newRow.NumberOfStampStep = ws.MarkingStep
                    newRow.OSFT = ws.OSFTChange
                    newRow.OSProgram = ws.OSProgram
                    newRow.Package = ws.PackageName
                    newRow.PDFree = ws.PDFree
                    newRow.ReelCount = ws.ReelCount
                    newRow.SubRank = ws.SubRank
                    newRow.TapingDirection = ws.TapingDirection
                    newRow.ULMark = ws.ULMark
                    newRow.WaferLotNo = ws.WaferLotNo
                    'add row to datatable
                    table.Rows.Add(newRow)
                    'save to database
                    adaptor.Update(newRow)
                End If
            End Using
        End Using

        c_ParentComponent.InputLot(ws, o, qty, opNo)

    End Sub

End Class

Public Class LotSetupBomValidateComponent
    Inherits LotSetupComponent

    Public Sub New(ByVal component As ILotSetupComponent)
        MyBase.New(component)
    End Sub

    Public Overrides Sub InputLot(ByVal ws As WorkingSlip, ByVal o As OIS, _
                                  ByVal qty As Integer, ByVal opNo As String)


    End Sub
End Class
