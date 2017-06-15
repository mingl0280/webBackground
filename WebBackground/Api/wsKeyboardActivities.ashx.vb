Imports System.Web
Imports System.Web.Services
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Web.WebSockets


Public Class wsKeyboardActivities
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.AcceptWebSocketRequest(AddressOf KeyboardCallbackHandler)
    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

    Private Async Function KeyboardCallbackHandler(context As AspNetWebSocketContext) As Task

    End Function
End Class