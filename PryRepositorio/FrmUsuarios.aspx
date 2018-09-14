<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmUsuarios.aspx.cs" Inherits="PryRepositorio.FormUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
        }
        .auto-style2 {
            width: 128px;
        }
        .auto-style3 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <!--Esto es un comentario-->
                <tr>
                    <!--titulo-->
                    <td class="auto-style3" colspan="2"><strong>Ingreso</strong></td>
                </tr>
                <tr>
                    <!--Usuario-->
                    <td class="auto-style1">Usuario</td>
                    <td class="auto-style2"><strong>
                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                        </strong></td>
                </tr>
                <tr>
                    <!--Contraseña-->
                    <td class="auto-style1">Contraseña</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtContrasena" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <!--Boton Enviar-->
                    <td class="auto-style3" colspan="2">
                        <asp:Button ID="btnEnviar" runat="server" OnClick="BtnEnviar_Click" Text="Enviar" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
