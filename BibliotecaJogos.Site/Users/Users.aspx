<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="BibliotecaJogos.Site.Users.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CustomStyles/LibraryStyles/custom_style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
         <h2>Utilizadores</h2>
        </div>
        <div>
        <asp:GridView ID="gvUsers" DataKeyNames="id_user" AutoGenerateColumns="false" EmptyDataText="Sem registos" runat="server" ViewStateMode="Enabled" OnRowDataBound="gvUsers_RowDataBound">
                <Columns>
                    <asp:BoundField DataField ="id_user" ReadOnly="true" HeaderText="ID" />
                </Columns>

                <Columns>
                    <asp:BoundField DataField ="username" HeaderText="Nome do Utilizador" />
                </Columns>

                <Columns>      
                    <asp:TemplateField HeaderText="Privilégios de Administrador">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" id="chbxAdmin" Text="Administrador"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            <Columns>
                    <asp:TemplateField HeaderText="Eliminar Utilizador">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" id="chbxEliminar" Text="Eliminar"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <asp:Button ID="btSalvar" Text="Salvar as alterações" runat="server" OnClick="btSalvar_Click" CssClass="btn btn-primary" />
    </form>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../Scripts/popper.min.js"></script>
</body>
</html>
