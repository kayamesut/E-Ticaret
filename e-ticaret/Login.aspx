<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="E_Ticaret.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="UrunlerBolgesi" runat="server">
    <br />
    <br />
    <table>
        <tr>
            <td>Kullanıcı Adı</td><td align="right">:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Şifre</td><td align="right">:</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="3">
                <asp:Button ID="Button1" runat="server" Text="Giriş" onclick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Yeni Üye" 
                    style="margin-left:20px" onclick="Button2_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
