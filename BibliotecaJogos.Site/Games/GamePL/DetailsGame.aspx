<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailsGame.aspx.cs" Inherits="BibliotecaJogos.Site.Games.GamePL.DetailsGame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Detalhes do Jogo</h2>
            <table>
                <tr>
                    <td>Título</td>
                    <td>
                        <asp:Label id="lbTitle" Text="" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>Capa</td>
                    <td>
                        <asp:Image style="width: 150px; height: 200px"  runat="server" id="imageCapa"/>
                    </td>
                </tr>

                <tr>
                    <td>Valor Pago</td>
                    <td>
                        <asp:Label id="lbAmountPaid" Text="" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>Data da Compra</td>
                    <td>
                        <asp:Label id="lbPurchaseDate" Text="" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>Editora</td>
                    <td>
                        <asp:Label id="lbPublisher" Text="" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>Género</td>
                    <td>
                        <asp:Label id="lbGenre" Text="" runat="server" />
                    </td>
                </tr>
            </table>
            <asp:Button id="btCatalogo" Text="Voltar ao Catálogo" runat="server" OnClick="btCatalogo_Click" />
        </div>
    </form>
</body>
</html>
