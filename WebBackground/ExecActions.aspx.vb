Imports System.Net
Imports System.Net.Sockets
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Text.Encoding

Partial Class _ExecActions
    Inherits System.Web.UI.Page

    <DllImport("shell32.dll")>
    Private Shared Function ShellExecute(hwnd As IntPtr, lpOperation As String, lpFile As String, lpParam As String, lpDirectory As String, nShowCmd As Integer) As IntPtr

    End Function

    Private Sub _ExecActions_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Prog = Request.Form("Program")
        Dim Param = Request.Form("Args")
        'ShellExecute(IntPtr.Zero, "open", Prog, Param, Nothing, 1)
        Dim tClient As New TcpClient(IPAddress.Loopback.ToString, 20082)
        Dim NS As NetworkStream = tClient.GetStream()
        Dim buf() As Byte = UTF8.GetBytes(Prog + "###" + Param)
        NS.Write(buf, 0, buf.Length)
        NS.Close()
        tClient.Close()
    End Sub
End Class
