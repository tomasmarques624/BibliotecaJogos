<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailsGame.aspx.cs" Inherits="BibliotecaJogos.Site.Games.GamePL.DetailsGame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Detalhes do Jogo</title>
     <link href="../../Content/CustomStyles/LibraryStyles/custom_style.css" rel="stylesheet" />
    <link href="../../Content/CustomStyles/LoginRegisterStyles/loginregister.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
            <h2>Detalhes do Jogo</h2>
        </div>
        <div>
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
                        <asp:Image style="width: 150px; height: 200px"  runat="server" id="imageCapa" CssClass="img-thumbnail"/>
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
            <asp:Button id="btCatalogo" Text="Voltar ao Catálogo" runat="server" OnClick="btCatalogo_Click" cssclass="btn btn-primary"/>
        </div>
    </form>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <script src="../../Scripts/jquery-3.4.1.min.js"></script>
</body>
</html>
