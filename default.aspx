<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="FirstStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!--Comment-->
    <h1>Birthday Calculator</h1>
        <hr/>
        <p>Choose your birthday</p>
        <asp:Calendar ID="Calendar1" runat="server">

        </asp:Calendar>
