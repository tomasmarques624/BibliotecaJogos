<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewGenre.aspx.cs" Inherits="BibliotecaJogos.Site.Games.GenrePL.NewGenre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/CustomStyles/LibraryStyles/custom_style.css" rel="stylesheet" />
    <link href="../../Content/CustomStyles/LoginRegisterStyles/loginregister.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
            <div class="jumbotron">
                <h2>Novo Género</h2>
            </div>
            <div>
            <table>
                <tr>
                    <td>Descrição :</td>
                    <td> 
                        <asp:TextBox CssClass="form-control" id="tbxDescri" runat="server" />
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário uma discrição" Text="*" ControlToValidate="tbxDescri" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ValidationSummary HeaderText="<div class='validationheader'>&nbsp;Erros: </div>" ForeColor="Red" runat="server" displaymode="BulletList" CssClass="validationsummary"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="" ID="lbMensagem" runat="server" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button id="btInserir" CssClass="btn btn-primary" Text="Inserir" runat="server" OnClick="btInserir_Click" />
                        <asp:Button id="btCancelar" CssClass="btn btn-secondary" Text="Cancelar" CausesValidation="false" runat="server" OnClick="btCancelar_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <script src="../../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
</body>
</html>
