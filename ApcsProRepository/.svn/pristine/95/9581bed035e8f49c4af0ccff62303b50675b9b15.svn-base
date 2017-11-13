Imports System.ComponentModel

Public Class FTMachinePanel
    Inherits Panel

    Private m_ActiveFTMachine As FTMachine
    <Browsable(False)> _
    Public Property ActiveFTMachine() As FTMachine
        Get
            Return m_ActiveFTMachine
        End Get
        Set(ByVal value As FTMachine)
            m_ActiveFTMachine = value
        End Set
    End Property

    Sub New()
        m_OrderRectList = New List(Of Rectangle)

    End Sub

    Friend Sub GrabOrderPosition(ByVal mc As FTMachine)
        Dim f As Boolean = False

        Dim mouseP As Point = Me.PointToClient(MousePosition)

        'dummy rect contain mouse point
        For Each rect As Rectangle In m_OrderRectList
            If rect.Contains(mouseP) Then
                mc.Location = rect.Location
                f = True
                Exit For
            End If
        Next

        'intersect with dummy rect
        If Not f Then
            For Each rect As Rectangle In m_OrderRectList
                If rect.IntersectsWith(New Rectangle(mc.Location, mc.Size)) Then
                    mc.Location = rect.Location
                    f = True
                    Exit For
                End If
            Next
        End If

        If Not f OrElse IsIntersectToAnotherMachine(mc) Then
            mc.Location = mc.BeforeDragLocation
        End If

    End Sub

    Private Function IsIntersectToAnotherMachine(ByVal mc As FTMachine) As Boolean
        Dim ret As Boolean = False
        Dim mcRect As Rectangle = New Rectangle(mc.Location, mc.Size)
        For Each ctrl As Control In Controls
            If TypeOf ctrl Is FTMachine Then
                If Not ReferenceEquals(ctrl, mc) Then
                    Dim rect As Rectangle = New Rectangle(ctrl.Location, ctrl.Size)
                    If rect.IntersectsWith(mcRect) Then
                        ret = True
                        Exit For
                    End If
                End If
            End If
        Next
        Return ret
    End Function

    Private m_OrderRectList As List(Of Rectangle)

    Private m_ShowGrid As Boolean
    Public Property ShowGrid() As Boolean
        Get
            Return m_ShowGrid
        End Get
        Set(ByVal value As Boolean)
            m_ShowGrid = value
            IndicateBackgroundImageDraw()
        End Set
    End Property

    Private m_BgImage As Bitmap

    Private Sub IndicateBackgroundImageDraw()
        If m_ShowGrid Then

            If m_BgImage IsNot Nothing Then
                m_BgImage.Dispose()
            End If

            m_BgImage = New Bitmap(Me.Width, Me.Height)

            Using g As Graphics = Graphics.FromImage(m_BgImage)
                g.Clear(Me.BackColor)
                For Each rt As Rectangle In m_OrderRectList
                    g.DrawRectangle(Pens.Black, rt)
                Next
            End Using

            Me.BackgroundImage = m_BgImage
        Else
            Me.BackgroundImage = Nothing
        End If
    End Sub


    Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
        MyBase.OnSizeChanged(e)

        IndicateBackgroundImageDraw()

        'FORMULAR : 30 + ( 80 * c ) + (10 * (c - 1)) <= Width
        'c := maximum FTMachine count in column
        'FORMULAR : n <= (Width - 20) / 90

        m_OrderRectList.Clear()

        Dim c As Integer = CInt(Math.Floor((Me.Width - 20) / 90))
        Dim r As Integer = CInt(Math.Floor((Me.Height - 20) / 90))

        Dim rect As Rectangle
        For i As Integer = 1 To c
            For j As Integer = 1 To r
                rect = New Rectangle(15 + ((i - 1) * 90), 15 + ((j - 1) * 90), 80, 80)
                m_OrderRectList.Add(rect)
            Next
        Next
        'Debug.Print("OnSizeChanged")

    End Sub


End Class
