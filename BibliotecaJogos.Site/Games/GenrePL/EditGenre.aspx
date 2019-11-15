<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditGenre.aspx.cs" Inherits="BibliotecaJogos.Site.Games.GenrePL.EditGenre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Editar Género</h2>
            <table>
                <tr>
                    <td>Descrição :</td>
                    <td> 
                        <asp:TextBox id="tbxDescri" runat="server" />
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário uma discrição" Text="*" ControlToValidate="tbxDescri" ForeColor="Red"></asp:RequiredFieldValidator>
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
                        <asp:Button id="btSalvar" Text="Inserir" runat="server" onclick="btSalvar_Click" />
                        <asp:Button id="btCancelar" Text="Cancelar" CausesValidation="false" runat="server" OnClick="btCancelar_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
