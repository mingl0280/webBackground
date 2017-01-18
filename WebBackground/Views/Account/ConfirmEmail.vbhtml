@Code
    ViewBag.Title = "确认电子邮件"
End Code

<h2>@ViewBag.Title。</h2>
<div>
    <p>
        感谢你确认电子邮件。请 @Html.ActionLink("单击此处登录", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {Key .id = "loginLink"})
    </p>
</div>
