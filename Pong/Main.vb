Imports System.Drawing
Imports System.Net
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Network
Imports System.Linq


Public Class Main

    Public gmodel As GameModel
    Public cmodel As ClientModel
    Public WithEvents netclient As NetworkClient

    Public Shared Sub Main()
        Dim Main As New Main()
        Main.Show()
        Application.Run()
    End Sub

    Private Sub Main_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        FormBorderStyle = FormBorderStyle.None
        Dim ipaddress As String = InputBox("Enter IP address of server: ")
        Dim port As Integer = CInt(InputBox("Enter the port of the server: "))
        Dim location As Integer = CInt(InputBox("Enter the location of the screen: "))
        Dim name As String = InputBox("Enter a name (Optional): ")
        If name = String.Empty Then
            name = Nothing
        End If
        cmodel = New ClientModel
        cmodel.Location = location
        gmodel = New GameModel
        netclient = NetworkFactory.CreateClient(New System.Net.IPEndPoint(System.Net.IPAddress.Parse(ipaddress), port), gmodel)
        NetworkFactory.ConnectClient(netclient, location, name)
    End Sub

    Private Sub Main_KeyPressed(Sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Dim scr As New Network.Screen(cmodel)
        If Not scr.HasMoreLeft Then
            If e.KeyChar = "w" Then
                gmodel.LeftPaddle.Y -= CDec(0.01)
                netclient.SendPacket(New PaddleMovePacket(gmodel.LeftPaddle))
            ElseIf e.KeyChar = "s" Then
                gmodel.LeftPaddle.Y += CDec(0.01)
                netclient.SendPacket(New PaddleMovePacket(gmodel.LeftPaddle))
            End If
        ElseIf scr.HasMoreRight Then
            If e.KeyChar = "w" Then
                gmodel.RightPaddle.Y -= CDec(0.01)
                netclient.SendPacket(New PaddleMovePacket(gmodel.RightPaddle))
            ElseIf e.KeyChar = "s" Then
                gmodel.RightPaddle.Y += CDec(0.01)
                netclient.SendPacket(New PaddleMovePacket(gmodel.RightPaddle))
            End If
        End If
    End Sub

    Private Sub netclient_PacketReceived(e As IPacket) Handles netclient.PacketReceived
        Dim scr As New Network.Screen(cmodel)
        Dim gfx As Graphics = Screen.CreateGraphics
        Dim p As Pen = New Pen(New SolidBrush(Color.Red), 3)
        Dim b As Ball
        For Each b In (From Ball In gmodel.Balls Where Ball.Screen.Equals(scr))
            gfx.DrawEllipse(p, New Rectangle(CInt(b.Location.X * Width), CInt(b.Location.Y * Height), CInt(b.Size * Width), CInt(b.Size * Height)))
        Next
        If Not scr.HasMoreLeft Then
            gfx.FillRectangle(p.Brush, New Rectangle(0, CInt(gmodel.LeftPaddle.Y * Height), 4, CInt(gmodel.LeftPaddle.Height * Height)))
        ElseIf Not scr.HasMoreRight Then
            gfx.FillRectangle(p.Brush, New Rectangle(0, CInt(gmodel.RightPaddle.Y * Height), 4, CInt(gmodel.RightPaddle.Height * Height)))
        End If

    End Sub

End Class