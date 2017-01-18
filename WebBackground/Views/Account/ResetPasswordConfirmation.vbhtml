@Code
    ViewBag.Title = "重置密码确认"
End Code

<hgroup class="title">
    <h1>@ViewBag.Title。</h1>
</hgroup>
<div>
    <p>
        你的密码已重置。请 @Html.ActionLink("单击此处登录", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {Key .id = "loginLink"})
    </p>
</div>
