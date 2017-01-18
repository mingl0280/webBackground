Imports System.Web.Http
Imports System.Web.Optimization
Imports System.Web.Security
Imports System.Web.SessionState

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

    End Sub
    Protected Overloads Sub Application_BeginRequest(sender As Object, e As EventArgs)
        If (Context.Request.FilePath = "/") Then
            Context.RewritePath("index.aspx")
        End If
    End Sub
End Class
