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
        gmodel = New GameModel()
        netclient = NetworkFactory.CreateClient(New System.Net.IPEndPoint(System.Net.IPAddress.Parse(ipaddress), port), gmodel)
        NetworkFactory.ConnectClient(netclient, location, name)
    End Sub

    Private Sub netclient_PacketReceived(e As IPacket) Handles netclient.PacketReceived
        Dim scr As New Network.Screen(cmodel)
        Dim gfx As Graphics = Screen.CreateGraphics
        Dim b As Ball
        For Each b In (From Ball In gmodel.Balls Where Ball.Screen.Equals(scr))
            gfx.DrawEllipse(New Pen(New SolidBrush(Color.Red), 3), New Rectangle(CInt(b.Location.X * Width), CInt(b.Location.Y * Height), 30, 30))
        Next
        If Not scr.HasMoreLeft Then
            'gfx.DrawRectangle()
        End If

    End Sub

End Class