Imports System.Drawing
Imports System.Windows.Forms
Imports Network


Public Class Main

    Public Shared Sub Main()
        Dim Main As New Main()
        Main.Show()
        Application.Run()
    End Sub

    Private Sub Main_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        FormBorderStyle = FormBorderStyle.None

    End Sub

End Class