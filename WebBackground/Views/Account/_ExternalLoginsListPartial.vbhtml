@ModelType ExternalLoginListViewModel
@Imports Microsoft.Owin.Security
@Code
    Dim loginProviders = Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes()
End Code
<h4>使用其他服务登录。</h4>
<hr />
@If loginProviders.Count() = 0 Then
    @<div>
          <p>
              没有配置外部身份验证服务。有关设置此 ASP.NET 应用程序
              以支持通过外部服务登录的详细信息，请参阅<a href="http://go.microsoft.com/fwlink/?LinkId=403804">此文</a>。
          </p>
    </div>
Else
    @Using Html.BeginForm("ExternalLogin", "Account", New With {.ReturnUrl = Model.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
        @Html.AntiForgeryToken()
        @<div id="socialLoginList">
           <p>
               @For Each p As AuthenticationDescription In loginProviders
                   @<button type="submit" class="btn btn-default" id="@p.AuthenticationType" name="provider" value="@p.AuthenticationType" title="使用你的 @p.Caption 帐户登录">@p.AuthenticationType</button>
               Next
           </p>
        </div>
    End Using
End If
