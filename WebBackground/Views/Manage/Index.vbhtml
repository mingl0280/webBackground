@ModelType IndexViewModel
@Code
    ViewBag.Title = "管理"
End Code

<h2>@ViewBag.Title。</h2>

<p class="text-success">@ViewBag.StatusMessage</p>
<div>
    <h4>更改你的帐户设置</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>密码:</dt>
        <dd>
            [
            @If Model.HasPassword Then
                @Html.ActionLink("更改密码", "ChangePassword")
            Else
                @Html.ActionLink("创建", "SetPassword")
            End If
            ]
        </dd>
        <dt>外部登录名:</dt>
        <dd>
            @Model.Logins.Count [
            @Html.ActionLink("管理", "ManageLogins") ]
        </dd>
        @*
            电话号码可以在双因素身份验证系统中用作第二个验证因素。
             
             请参阅<a href="http://go.microsoft.com/fwlink/?LinkId=403804">此文</a>
                了解有关设置此 ASP.NET 应用程序以支持使用 SMS 进行双因素身份验证的详细信息。
             
             在设置了双因素身份验证后，请取消注释以下块
        *@
        @* 
            <dt>电话号码:</dt>
            <dd>
                @(If(Model.PhoneNumber, "None"))
                @If (Model.PhoneNumber <> Nothing) Then
                    @<br />
                    @<text>[&nbsp;&nbsp;@Html.ActionLink("Change", "AddPhoneNumber")&nbsp;&nbsp;]</text>
                    @Using Html.BeginForm("RemovePhoneNumber", "Manage", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                        @Html.AntiForgeryToken
                        @<text>[<input type="submit" value="Remove" class="btn-link" />]</text>
                    End Using
                Else
                    @<text>[&nbsp;&nbsp;@Html.ActionLink("Add", "AddPhoneNumber") &nbsp;&nbsp;]</text>
                End If
            </dd>
        *@
        <dt>双因素身份验证:</dt>
        <dd>
            <p>
                没有配置双因素身份验证提供程序。有关设置此 ASP.NET 应用程序
                以支持双因素身份验证的详细信息，请参阅<a href="http://go.microsoft.com/fwlink/?LinkId=403804">此文</a>。
            </p>
            @*
                @If Model.TwoFactor Then
                    @Using Html.BeginForm("DisableTwoFactorAuthentication", "Manage", FormMethod.Post, New With { .class = "form-horizontal", .role = "form" })
                      @Html.AntiForgeryToken()
                      @<text>
                      已启用
                      <input type="submit" value="禁用" class="btn btn-link" />
                      </text>
                    End Using
                Else
                    @Using Html.BeginForm("EnableTwoFactorAuthentication", "Manage", FormMethod.Post, New With { .class = "form-horizontal", .role = "form" })
                      @Html.AntiForgeryToken()
                      @<text>
                      已禁用
                      <input type="submit" value="启用" class="btn btn-link" />
                      </text>
                    End Using
                End If
	     *@
        </dd>
    </dl>
</div>
