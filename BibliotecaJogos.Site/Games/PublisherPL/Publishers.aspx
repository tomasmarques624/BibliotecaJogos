<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Publishers.aspx.cs" Inherits="BibliotecaJogos.Site.Games.PublisherPL.Publishers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editoras</title>
    <link href="../../Content/CustomStyles/LibraryStyles/custom_style.css" rel="stylesheet" />
    <link href="../../Content/CustomStyles/LoginRegisterStyles/loginregister.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
            <h2>Editoras</h2>
        </div>
        <div>
             <asp:GridView ID="gvPublisherList" AutoGenerateColumns="false" EmptyDataText="Sem registos" runat="server" ViewStateMode="Enabled"
                   OnRowDeleting="gvPublisherList_RowDeleting"
                   OnRowEditing="gvPublisherList_RowEditing"
                   OnRowUpdating="gvPublisherList_RowUpdating"
                   OnRowCancelingEdit="gvPublisherList_RowCancelingEdit" CssClass="mydatagrid" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" >
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
        </div>
        <div>
            <br />
            <asp:Label id="lbMensagem" Text="" runat="server" />
            <br />
            <br />
        </div>
        <div>
            <asp:Button id="btNovaEditora" CssClass="btn btn-primary" Text="Nova Editora" runat="server"  OnClick="btNovaEditora_Click" />
            <asp:Button id="btVerCatalogo" CssClass="btn btn-secondary" Text="Ver Catálogo dos Jogos" runat="server" onclick="btVerCatalogo_Click"/>
        </div>
    </form>
    <script src="../../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
</body>
</html>
