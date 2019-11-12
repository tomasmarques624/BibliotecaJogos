<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BibliotecaJogos.Site.Registo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Registo</h2>
             <table>

                <tr>
                    <td>Username: </td>
                    <td>
                        <asp:TextBox ID="tbxUsername" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário o username" Text="*" ControlToValidate="tbxUsername" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Password: </td>
                    <td>
                        <asp:TextBox ID="tbxPassword" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário a password" Text="*" ControlToValidate="tbxPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Confirme a password: </td>
                    <td>
                        <asp:TextBox ID="tbxConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário confirmar a password" Text="*" ControlToValidate="tbxConfirmPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ErrorMessage="As passwords não são iguais!" ControlToValidate="tbxConfirmPassword" 
                         ControlToCompare="tbxPassword" operator="Equal" text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ValidationSummary HeaderText="Erros" ForeColor="Red" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="" ID="lbMensagem" runat="server" ForeColor="Red" />
                    </td>
                </tr>
                  <tr>
                    <td>
                        <asp:HyperLink ID="hlLogin" runat="server" NavigateUrl="~/Authentication/Login.aspx">Clique aqui para login</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button Text="Registar" ID="btRegistar" runat="server" OnClick="btRegistar_Click" />
                        <asp:Button Text="Cancelar" ID="btCancelar" runat="server" CausesValidation="false" />
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
