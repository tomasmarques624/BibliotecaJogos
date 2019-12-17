<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BibliotecaJogos.Site.Registo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/CustomStyles/LoginRegisterStyles/loginregister.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
        <div class="sidenav" runat="server">
         <div class="login-main-text">
            <h2>Bliblioteca de Jogos</h2>
            <p>Faça Login ou efetue o registo para aceder à aplicação.</p>
         </div>
      </div>
      <div class="main" runat="server">
         <div class="col-md-6 col-sm-12">
            <div class="login-form">
               <form runat="server">
                  <div class="form-group">
                     <label>Username</label>
                     <asp:TextBox ID="tbxUsername" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário o username" Text="*" ControlToValidate="tbxUsername" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div>
                   <div class="form-group">
                     <label>Email</label>
                     <asp:TextBox ID="tbxEmail" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário o email" Text="*" ControlToValidate="tbxEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group">
                     <label>Password</label>
                     <asp:TextBox ID="tbxPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário a password" Text="*" ControlToValidate="tbxPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div>
                   <div class="form-group">
                       <label>Confirme a password</label>
                     <asp:TextBox ID="tbxConfirmPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário confirmar a password" Text="*" ControlToValidate="tbxConfirmPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ErrorMessage="As passwords não são iguais!" ControlToValidate="tbxConfirmPassword" 
                         ControlToCompare="tbxPassword" operator="Equal" text="*" runat="server" ForeColor="Red"/>
                  </div>
                   <asp:ValidationSummary HeaderText="Erros" ForeColor="Red" runat="server" />
                   <asp:Label Text="" ID="lbMensagem" runat="server" ForeColor="Red" />
                   <br />
                   <asp:Button Text="Registar" ID="btRegistar" CssClass="btn btn-primary" runat="server" OnClick="btRegistar_Click" />
                   <asp:Button Text="Cancelar" ID="btCancelar" CssClass="btn btn-secondary" runat="server" CausesValidation="false" OnClick="btCancelar_Click" />
                   <asp:HyperLink ID="hlLogin" runat="server" Visible="false" NavigateUrl="~/Authentication/Login.aspx">Clique aqui para fazer login</asp:HyperLink>
               </form>
            </div>
         </div>
      </div>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
</body>
</html>
