<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPublisher.aspx.cs" Inherits="BibliotecaJogos.Site.Games.PublisherPL.EditPublisher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Editar Editora</h2>
            <table>
                <tr>
                    <td>Nome :</td>
                    <td> 
                        <asp:TextBox id="tbxNome" runat="server" />
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário um nome" Text="*" ControlToValidate="tbxNome" ForeColor="Red"></asp:RequiredFieldValidator>
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
                        <asp:HyperLink ID="hlCatalogo" runat="server" Visible="false" NavigateUrl="~/Games/PublisherPL/Publishers.aspx">Clique aqui para aceder à lista</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button id="btSalvar" Text="Salvar" runat="server" OnClick="btInserir_Click" />
                        <asp:Button id="btCancelar" Text="Cancelar" CausesValidation="false" runat="server" onclick="btCancelar_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
