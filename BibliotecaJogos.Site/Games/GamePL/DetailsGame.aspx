<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="DetailsGame.aspx.cs" Inherits="BibliotecaJogos.Site.Games.GamePL.DetailsGame" 
     MasterPageFile="~/Games/SiteGames.Master" %>

<asp:content id="Content1"  ContentPlaceHolderID="head" runat="server"></asp:content>

<asp:content id="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="content-page">
            <h4>Detalhes do Jogo</h4>
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
   </asp:content>
