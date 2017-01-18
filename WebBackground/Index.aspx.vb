Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.XPath
Imports System
Imports Microsoft.VisualBasic.Logging
Imports System.Net.WebSockets

Partial Class Index
    Inherits System.Web.UI.Page

    Private plugins As New List(Of Plugin)

    Private Class Plugin
        Public Property Name As String
        Public Property Description As String
        Public Property HeaderContents As New List(Of String)
        Public Property BodyContents As New List(Of String)
        Public Property EndingContents As New List(Of String)
        Public Sub New(ByVal n As String, Optional d As String = "")
            Name = n
            If d = "" Or d.Trim() = "" Then
                d = "No Description"
            End If
        End Sub
    End Class



    Protected Function GenerateHeaders() As String
        Dim Ret As String = ""
        For Each P As Plugin In plugins
            For Each HC In P.HeaderContents
                Ret += vbCrLf + "    " + HC
            Next
        Next
        Return Ret

    End Function

    Protected Function GenerateBody() As String
        Dim ret As String = ""
        For Each P In plugins
            For Each bElem In P.BodyContents
                ret += vbCrLf + bElem
            Next
        Next
        Return ret
    End Function

    Protected Function GenerateEnding() As String
        Dim ret As String = ""
        For Each P In plugins
            For Each eElem In P.EndingContents
                ret += vbCrLf + eElem
            Next
        Next
        Return ret
    End Function

    Protected Sub InitGadgets()
        Dim cfgFiles = Directory.GetFiles(Server.MapPath("~/Plugins/enabled"), "*.cfg", SearchOption.AllDirectories)
        For Each cfgFile In cfgFiles
            Dim xmldoc As New XmlDocument
            xmldoc.Load(cfgFile)
            Dim root = xmldoc.DocumentElement
            Dim NameNode = root.SelectSingleNode("/document/name")
            Dim DescNode = root.SelectSingleNode("/document/description")
            Dim HeadNode = root.SelectSingleNode("/document/head")
            Dim BodyNode = root.SelectSingleNode("/document/body")
            Dim EndingNode = root.SelectSingleNode("/document/ending")
            Try
                Dim P As New Plugin(NameNode.InnerText, DescNode.InnerText)

                For Each elem As XmlNode In HeadNode.ChildNodes
                    Select Case elem.Name
                        Case "css"
                            P.HeaderContents.Add("<link rel=""stylesheet"" href=""" + elem.InnerText + """ type=""text/css"" />")
                            Exit Select
                        Case "js"
                            P.HeaderContents.Add("<script type=""text/javascript"" src=""" + elem.InnerText + """></script>")
                            Exit Select
                        Case Else
                            P.HeaderContents.Add(elem.InnerText)
                            Exit Select
                    End Select
                Next
                If BodyNode.ChildNodes.Count > 0 Then
                    For Each elem As XmlNode In BodyNode.ChildNodes
                        Dim TR As TextReader = New StreamReader(Server.MapPath("~/" + elem.InnerText))
                        P.BodyContents.Add(TR.ReadToEnd)
                    Next
                Else
                    P.BodyContents = New List(Of String)
                End If
                If EndingNode.ChildNodes.Count > 0 Then
                    For Each elem As XmlNode In EndingNode.ChildNodes
                        Select Case elem.Name
                            Case "js"
                                P.EndingContents.Add("<script type=""text/javascript"" src=""" + elem.InnerText + """></script>")
                                Exit Select
                            Case Else
                                P.EndingContents.Add(elem.InnerText)
                                Exit Select
                        End Select
                    Next
                Else
                    P.EndingContents = New List(Of String)
                End If
                plugins.Add(P)
            Catch ex As Exception
                Dim ALog As New AspLog()
                ALog.WriteEntry("Invalid plugin config file:" + cfgFile)
            End Try
        Next
    End Sub

    Private Sub Index_Init(sender As Object, e As EventArgs) Handles Me.Init
        InitGadgets()
    End Sub
End Class
