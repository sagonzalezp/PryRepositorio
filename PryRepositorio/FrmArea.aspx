﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmArea.aspx.cs" Inherits="PryRepositorio.FrmArea1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 228px;
        }
        .auto-style2 {
            width: 228px;
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
        }
        .auto-style4 {
            margin-left: 0px;
        }
        .auto-style5 {
            height: 23px;
            width: 436px;
        }
        .auto-style6 {
            width: 436px;
        }
        .auto-style7 {
            width: 83%;
        }
        .auto-style9 {
            width: 166px;
            height: 30px;
        }
        .auto-style10 {
            width: 181px;
            height: 30px;
        }
        .auto-style11 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style7">
            <tr>
                <td class="auto-style3" colspan="2" style="text-align: center">AREAS</td>
            </tr>
            <tr>
                <td class="auto-style2">ID AREA</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtArea" runat="server" CssClass="auto-style4" Width="525px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">NOMBRE</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtNombre" runat="server" Width="525px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">FK ID AREA</td>
                <td class="auto-style6">
                <asp:DropDownList ID="dropFkarea" runat="server" DataSourceID="SqlDataSource1" DataTextField="nombre" DataValueField="idArea">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [nombre], [idArea] FROM [AREA]"></asp:SqlDataSource>   
				</td>
            </tr>
        </table>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style11">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    </td>
                    <td class="auto-style10">
                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" style="margin-left: 0px" OnClick="btnConsultar_Click" />
                    </td>
                        <td class="auto-style9">
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                    </td>
                <td class="auto-style11">
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                             
                    </td>
            </tr>
            </table>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
