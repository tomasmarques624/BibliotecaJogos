﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditGame.aspx.cs" Inherits="BibliotecaJogos.Site.EditGame" MasterPageFile="~/Games/SiteGames.Master" %>

<asp:content id="Content1"  ContentPlaceHolderID="head" runat="server"></asp:content>

<asp:content id="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="content-page">
            <h4>Edição do Jogo</h4>
        </div>
        <div>
            <table>
                <tr>
                    <td>Titulo</td>
                     <td>
                        <asp:TextBox CssClass="form-control"  id="tbxTitulo" runat="server" />
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário um titulo" Text="*" ControlToValidate="tbxTitulo" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Capa</td>
                    <td>
                        <asp:Image Width="200px" Height="300px" CssClass="img-thumbnail" id="imgCapa" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Nova Capa</td>
                    <td>
                        <asp:FileUpload  CssClass="form-control-file"  runat="server" ID="fluCapa"/>
                    </td>
                </tr>
                <tr>
                    <td>Valor Pago</td>
                    <td>
                        <asp:TextBox  CssClass="form-control"  runat="server" ID="tbxValorPago" />
                    </td>
                </tr>
                <tr>
                    <td>Data da Compra</td>
                    <td>
                        <asp:TextBox  CssClass="form-control"  runat="server" ID="tbxDataCompra" TextMode="Date" />  
                    </td>
                </tr>
                <tr>
                    <td>Editor</td>
                    <td>
                        <asp:DropDownList ID="ddlEditor" runat="server"  CssClass="form-control" >
                        </asp:DropDownList>
                         <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário um editor" Text="*" ControlToValidate="ddlEditor" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Género</td>
                    <td>
                        <asp:DropDownList ID="ddlGenero" runat="server"  CssClass="form-control" >
                        </asp:DropDownList>
                         <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário um género" Text="*" ControlToValidate="ddlGenero" ForeColor="Red"></asp:RequiredFieldValidator>
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
                        <asp:HyperLink ID="hlCatalogo" runat="server" NavigateUrl="~/Games/GameLibraryPL/GameLibrary.aspx">Clique aqui para aceder ao catálogo</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button CssClass="btn btn-primary" id="btSalvar" Text="Salvar" runat="server" OnClick="btSalvar_Click" />
                         <asp:Button id="btCancelar" cssclass="btn btn-secondary" Text="Cancelar" CausesValidation="false" runat="server" OnClick="btCancelar_Click" />
                    </td>
                </tr>
            </table>
        </div>
</asp:content>