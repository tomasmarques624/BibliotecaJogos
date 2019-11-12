<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditGame.aspx.cs" Inherits="BibliotecaJogos.Site.EditGame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Edição do Jogo</h2>
            <table>
                <tr>
                    <td>Titulo</td>
                     <td>
                        <asp:TextBox id="tbxTitulo" runat="server" />
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário um titulo" Text="*" ControlToValidate="tbxTitulo" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Capa</td>
                    <td>
                        <asp:Image id="imgCapa" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Nova Capa</td>
                    <td>
                        <asp:FileUpload runat="server" ID="fluCapa"/>
                         <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário uma capa" Text="*" ControlToValidate="fluCapa" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Valor Pago</td>
                    <td>
                        <asp:TextBox runat="server" ID="tbxValorPago" TextMode="Number" />  
                    </td>
                </tr>
                <tr>
                    <td>Data da Compra</td>
                    <td>
                        <asp:TextBox runat="server" ID="tbxDataCompra" TextMode="Date" />  
                    </td>
                </tr>
                <tr>
                    <td>Editor</td>
                    <td>
                        <asp:DropDownList ID="ddlEditor" runat="server">
                        </asp:DropDownList>
                         <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário um editor" Text="*" ControlToValidate="ddlEditor" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Género</td>
                    <td>
                        <asp:DropDownList ID="ddlGenero" runat="server">
                        </asp:DropDownList>
                         <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário um género" Text="*" ControlToValidate="ddlGenero" ForeColor="Red"></asp:RequiredFieldValidator>
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
                        <asp:Button id="btSalvar" Text="Salvar" runat="server" />
                         <asp:Button id="btCancelar" Text="Cancelar" CausesValidation="false" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
