<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="YeniUye.aspx.cs" Inherits="E_Ticaret.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="UrunlerBolgesi" runat="server">
    <br />
    <br />
    <table>
        <tr>
            <td>Adınız</td><td align="right">:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" required=""></asp:TextBox>*
            </td>
            
        </tr>
        <tr>
            <td>Soyadınız</td><td align="right">:</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" required="" ></asp:TextBox>*
            </td>
        </tr>
        <tr>
            <td>E-mail</td><td align="right">:</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" required=""></asp:TextBox>*
            </td>
        </tr>
        <tr>
            <td>Şifre</td><td align="right">:</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" required="" TextMode="Password"></asp:TextBox>*
            </td>
        </tr>
        <tr>
            <td>Telefon</td><td align="right">:</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" required=""></asp:TextBox>*
            </td>
        </tr>
        <tr>
            <td>Adres</td><td align="right">:</td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" TextMode="MultiLine" Width="300px" Height="100px" required=""></asp:TextBox>*
            </td>
        </tr>
        <tr>
            <td align="right" colspan="3">
                <asp:Button ID="Button1" runat="server" Text="Kaydol" onclick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
