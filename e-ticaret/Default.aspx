<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="E_Ticaret.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="UrunlerBolgesi" runat="server">
    <table style="height:100%;width:100%" cellpadding="0" cellspacing="0">
        <tr>
            <td><!-- Dropbox Urun Kategori -->
                <div class="Filtreleme">
                     <asp:DropDownList ID="Categories" runat="server">
                        </asp:DropDownList>
                     <asp:Button ID="Button2" runat="server" Text="Uygula" onclick="Button2_Click" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table><!-- Urunler Listesi -->
                    <tr>
                        <td>
                            <asp:DataList ID="DataList1" runat="server" RepeatColumns="1">
                                <ItemTemplate>
                                    <div class="dvUrun" style="height:150px;width:150px">
                                        <%#Eval("ProductName") %> <br /><br />
                                        <a href="UrunDetay.aspx?uid=<%#Eval("ProductID") %>"><asp:Image ID="Image1" 
                                           runat="server" ImageUrl='<%#Eval("ProductAdress") %>' 
                                           style="max-width:100px; min-height:100px"/></a><br /><br />
                                        <%#Eval("ProductCost") %> TL
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
