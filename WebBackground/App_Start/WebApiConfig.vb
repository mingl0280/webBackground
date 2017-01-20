Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Web API 配置和服务

        ' Web API 路由
        config.MapHttpAttributeRoutes()

    End Sub
End Module
