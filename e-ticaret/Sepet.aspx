<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Sepet.aspx.cs" Inherits="E_Ticaret.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="UrunlerBolgesi" runat="server">
    <br />
    <table>
        <tr>
            <td style="width:100px">
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            </td>
            <td style="width:100px">
                <asp:Label ID="Label5" runat="server" Text="Ürün Adı"></asp:Label>
            </td>
            <td style="width:100px">
                <asp:Label ID="Label6" runat="server" Text="Fiyat"></asp:Label>
            </td>
            <td style="width:100px">
                <asp:Label ID="Label7" runat="server" Text="Kaç Adet"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:DataList ID="DataList1" runat="server">
      <ItemTemplate>
      <asp:Label runat="server" Visible="false" ID="silinecekUrun" Text='<%# Eval("BoxID") %>'></asp:Label>
         <table id="SepetTablosu" runat="server">
            <tr>
                <td style="width:100px">
                    <asp:CheckBox ID="c" runat="server" /> <asp:Label ID="l" runat="server" Text=""></asp:Label>
                </td>
                <td style="width:100px">
                    <asp:Label runat="server"  ID="Label1" Text='<%# Eval("ProductName") %>'></asp:Label>
                </td>
                <td style="width:100px">
                    <asp:Label runat="server"  ID="Label2" Text='<%# Eval("ProductCost") %>'></asp:Label>
                </td>
                <td style="width:100px">
                    <asp:Label runat="server"  ID="Label3" Text='<%# Eval("Count") %>'></asp:Label>
                </td>
            </tr>
         </table>
        
         
      </ItemTemplate>
    </asp:DataList>
    <br />
 
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Seçilenleri Sil" />
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Anasayfa" />
    <asp:Button ID="satinAl" runat="server" onclick="SatinAL_Click" Text="Seçilenleri Satın Al" />
    <br />
    <br />
    <asp:Label ID="bilgilendirme" runat="server" Text=""></asp:Label>
</asp:Content>
