Imports System.ComponentModel.DataAnnotations

Public Class ExternalLoginConfirmationViewModel
    <Required>
    <Display(Name:="电子邮件")>
    Public Property Email As String
End Class

Public Class ExternalLoginListViewModel
    Public Property ReturnUrl As String
End Class

Public Class SendCodeViewModel
    Public Property SelectedProvider As String
    Public Property Providers As ICollection(Of System.Web.Mvc.SelectListItem)
    Public Property ReturnUrl As String
    Public Property RememberMe As Boolean
End Class

Public Class VerifyCodeViewModel
    <Required>
    Public Property Provider As String
    
    <Required>
    <Display(Name:="代码")>
    Public Property Code As String
    
    Public Property ReturnUrl As String
    
    <Display(Name:="记住此浏览器?")>
    Public Property RememberBrowser As Boolean

    Public Property RememberMe As Boolean
End Class

Public Class ForgotViewModel
    <Required>
    <Display(Name:="电子邮件")>
    Public Property Email As String
End Class

Public Class LoginViewModel
    <Required>
    <Display(Name:="电子邮件")>
    <EmailAddress>
    Public Property Email As String

    <Required>
    <DataType(DataType.Password)>
    <Display(Name:="密码")>
    Public Property Password As String

    <Display(Name:="记住我?")>
    Public Property RememberMe As Boolean
End Class

Public Class RegisterViewModel
    <Required>
    <EmailAddress>
    <Display(Name:="电子邮件")>
    Public Property Email As String

    <Required>
    <StringLength(100, ErrorMessage:="{0} 必须至少包含 {2} 个字符。", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="密码")>
    Public Property Password As String

    <DataType(DataType.Password)>
    <Display(Name:="确认密码")>
    <Compare("Password", ErrorMessage:="密码和确认密码不匹配。")>
    Public Property ConfirmPassword As String
End Class

Public Class ResetPasswordViewModel
    <Required>
    <EmailAddress>
    <Display(Name:="电子邮件")>
    Public Property Email() As String

    <Required>
    <StringLength(100, ErrorMessage:="{0} 必须至少包含 {2} 个字符。", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="密码")>
    Public Property Password() As String

    <DataType(DataType.Password)>
    <Display(Name:="确认密码")>
    <Compare("Password", ErrorMessage:="密码和确认密码不匹配。")>
    Public Property ConfirmPassword() As String

    Public Property Code() As String
End Class

Public Class ForgotPasswordViewModel
    <Required>
    <EmailAddress>
    <Display(Name:="电子邮件")>
    Public Property Email() As String
End Class
