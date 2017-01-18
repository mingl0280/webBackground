Imports System.Web.Optimization

Public Module BundleConfig
    ' 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                    "~/js/jquery-{version}.js"))


    End Sub
End Module

