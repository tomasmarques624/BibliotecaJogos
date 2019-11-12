<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewPublisher.aspx.cs" Inherits="BibliotecaJogos.Site.Games.PublisherPL.NewPublisher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Novo Editor</h2>
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
                        <asp:HyperLink ID="hlCatalogo" runat="server" NavigateUrl="~/Games/GameLibraryPL/GameLibrary.aspx">Clique aqui para aceder ao catálogo</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button id="btInserir" Text="Inserir" runat="server" OnClick="btInserir_Click"/>
                        <asp:Button id="btCancelar" Text="Cancelar" CausesValidation="false" runat="server" OnClick="btCancelar_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
