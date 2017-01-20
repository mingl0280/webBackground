Imports System.Net.WebSockets
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Web.WebSockets
Imports System.Management
Imports System.Math
Imports System.Text.Encoding
Imports System.Web.Script.Serialization

Public Class wsCpuStat
    Implements System.Web.IHttpHandler

    Private CpuCounter As New PerformanceCounter("Processor Information", "% Processor Time", "0,_Total")
    Private MemWMIs As New ManagementClass("Win32_OperatingSystem")
    Private FreeMem As Long
    Private PhyMemSize As Long
    Private CPULoad, PMemGB As Single

    Private Class StatusInfo
        Public Property CPUUsage As String
        Public Property MemUsed As Single
        Public Property MemFree As Single
        Public Property MemAll As Single
        Public Sub New(a As String, b As Single, c As Single, d As Single)
            CPUUsage = a
            MemUsed = b
            MemFree = c
            MemAll = d
        End Sub
        Public Sub New()

        End Sub
    End Class

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim th As New Thread(AddressOf StartCounter)
        th.Start()
        context.AcceptWebSocketRequest(AddressOf CpuStatHandler)
    End Sub

    Private Async Function CpuStatHandler(context As AspNetWebSocketContext) As Task
        Dim socket = context.WebSocket
        While True
            Dim nBuf(2048) As Byte
            Dim buffer As New ArraySegment(Of Byte)(nBuf)
            'Dim result = Await (socket.ReceiveAsync(buffer, CancellationToken.None))
            If socket.State = WebSocketState.Open Then
                While True
                    Dim UMem As Long = PhyMemSize - FreeMem * 1024
                    Dim UMemGB As Single = UMem / 1024 / 1024 / 1024
                    'Dim SJson As String = New JavaScriptSerializer().Serialize()
                    Dim JSONList As New Dictionary(Of String, Single)
                    JSONList.Add("Type", 0)
                    JSONList.Add("CPU", Round(CPULoad))
                    JSONList.Add("MemUsed", Round(UMemGB, 1))
                    JSONList.Add("MemFree", Round(FreeMem / 1024 / 1024, 1))
                    JSONList.Add("MemAll", Round(PMemGB, 1))
                    'Dim msg() As Byte = UTF8.GetBytes("CPULoad = " + Round(CPULoad).ToString + " % Memory: " + Round(UMemGB, 1).ToString + " G / " + Round(PMemGB, 1).ToString + " G Used")
                    Dim msg() As Byte = UTF8.GetBytes(New JavaScriptSerializer().Serialize(JSONList))
                    buffer = New ArraySegment(Of Byte)(msg)
                    Await socket.SendAsync(buffer, WebSocketMessageType.Text, True, CancellationToken.None)
                    Thread.Sleep(500)
                End While
            End If
        End While
    End Function

    Private Sub StartCounter()
        CpuCounter.MachineName = "."
        Dim tMemWMIC = New ManagementClass("Win32_ComputerSystem")
        For Each MO In tMemWMIC.GetInstances()
            If MO("TotalPhysicalMemory") IsNot String.Empty Then
                PhyMemSize = Long.Parse(MO("TotalPhysicalMemory").ToString)
                PMemGB = PhyMemSize / 1024 / 1024 / 1024
            End If
        Next
        While True
            CPULoad = CpuCounter.NextValue()
            For Each MO As ManagementObject In MemWMIs.GetInstances()
                If MO("FreePhysicalMemory") IsNot String.Empty Then
                    FreeMem = Long.Parse(MO("FreePhysicalMemory").ToString())
                End If
            Next
            Thread.Sleep(500)
        End While
    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class