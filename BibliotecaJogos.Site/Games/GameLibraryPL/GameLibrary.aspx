<%@ Page Title="" Language="C#" MasterPageFile="~/Games/SiteGames.Master" AutoEventWireup="true"
    CodeBehind="GameLibrary.aspx.cs" Inherits="BibliotecaJogos.Site.Games.GameLibraryPL.GameLibrary" %>

    <asp:content id="Content1"  ContentPlaceHolderID="head" runat="server"></asp:content>

    <asp:content id="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-page">
        <h4>Catálogo dos Jogos</h4>
        <div>
            <asp:Button ID="btNovoJogo" Text="Novo Jogo" runat="server" CssClass="btn btn-primary" onclick="btNovoJogo_Click"/>
            <hr />
         </div>
         <asp:Repeater ID="repeaterGameLibrary" runat="server" >
            <ItemTemplate>
                <div class="jogo-area" onclick="go(<%# DataBinder.Eval(Container.DataItem,"id_game")%>, '<%=Session["role"].ToString()%>')">
                    <div>
                        <img style="width: 150px; height: 200px" src="../../Content/CoverImages/<%# DataBinder.Eval(Container.DataItem, "cover_image")%>"
                            alt="<%# DataBinder.Eval(Container.DataItem, "title" )%>"/>
                    </div>
                    <div>
                        <%# DataBinder.Eval(Container.DataItem,"title")%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <script>
        function go(id_game, role) {
            if (role = "A") {
                top.location.href = "../../Games/GamePL/EditGame.aspx?id_game=" + id_game;
            } else if (role = "U") {
                top.location.href = "../../Games/GamePL/DetailsGame.aspx?id_game=" + id_game;
            } else {
                top.location.href = "../../Games/GamePL/DetailsGame.aspx?id_game=" + id_game;
            }
        }
    </script>
    </asp:content>