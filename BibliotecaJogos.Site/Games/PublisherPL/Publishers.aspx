<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Publishers.aspx.cs" Inherits="BibliotecaJogos.Site.Games.PublisherPL.Publishers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Editoras</h2>
             <asp:GridView ID="gvPublisherList" AutoGenerateColumns="false" EmptyDataText="Sem registos" runat="server" ViewStateMode="Enabled"
                   OnRowDeleting="gvPublisherList_RowDeleting"
                    OnRowEditing="gvPublisherList_RowEditing"
                    OnRowUpdating="gvPublisherList_RowUpdating">
                <Columns>
                    <asp:BoundField DataField ="id_publisher" ReadOnly="true" HeaderText="ID" />
                </Columns>
                    <Columns>
                    <asp:BoundField DataField ="name_publisher" HeaderText="Nome da Editora" />
                </Columns>
                <Columns>
                    <asp:CommandField ButtonType="Link" DeleteText="Apagar" ShowDeleteButton="True" />
                    <asp:CommandField ButtonType="Link" EditText="Editar" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
            <asp:Label id="lbMensagem" Text="" runat="server" />
             <br />
            <asp:Button id="btNovaEditora" Text="Nova Editora" runat="server"  OnClick="btNovaEditora_Click" />
            <asp:Button id="btVerCatalogo" Text="Ver Catálogo dos Jogos" runat="server" onclick="btVerCatalogo_Click"/>
        </div>
    </form>
</body>
</html>
