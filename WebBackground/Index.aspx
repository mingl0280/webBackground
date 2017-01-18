<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Index.aspx.vb" Inherits="Index" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="UTF-8" />
    <title>My Desktop</title>
    <%= GenerateHeaders() %>
</head>
<body runat="server">
    <%= GenerateBody() %>
</body>
</html>
<%=GenerateEnding() %>
