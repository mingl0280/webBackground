Imports System.Management.Instrumentation
Imports System.Management
Imports System.Net.websockets

Partial Class CPUStat
    Inherits System.Web.UI.Page
    Public Function GetCPUUsagePct() As String
        Dim ns As String = "root\cimv2"
        Dim query As String = "SELECT LoadPercentage FROM Win32_Processor"
        Dim wPath = New ManagementPath("\\.\root\cimv2:Win32_Processor")
        Dim wClass = New ManagementClass(wPath)
        Dim wInst = wClass.GetInstances()
        For Each item In wInst
            Return item.GetPropertyValue("LoadPercentage").Value.ToString()
        Next
        Return 0
    End Function


End Class
