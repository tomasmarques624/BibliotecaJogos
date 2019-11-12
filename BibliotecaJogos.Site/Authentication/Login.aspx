<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BibliotecaJogos.Site.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/CustomStyles/LoginRegisterStyles/loginregister.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="sidenav">
         <div class="login-main-text">
            <h2>Application<br/> Login Page</h2>
            <p>Login or register from here to access.</p>
         </div>
      </div>
      <div class="main">
         <div class="col-md-6 col-sm-12">
            <div class="login-form">
               <form>
                  <div class="form-group">
                     <label>User Name</label>
                     <asp:TextBox ID="tbxUsername" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário o username" Text="*" ControlToValidate="tbxUsername" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group">
                     <label>Password</label>
                     <asp:TextBox ID="tbxPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário a password" Text="*" ControlToValidate="tbxPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div>
                   <asp:ValidationSummary HeaderText="Erros" ForeColor="Red" runat="server" />
                   <asp:Label Text="" ID="lbMensagem"  runat="server" ForeColor="Red" />
                  <asp:Button id="btLogin" Text="Login" runat="server" CssClass="btn btn-black" OnClick="btLogin_Click" />
                  <asp:HyperLink ID="hlRegisto" runat="server" CssClass="" NavigateUrl="~/Registration/Register.aspx">Registar</asp:HyperLink>
               </form>
            </div>
         </div>
      </div>
</body>
</html>
