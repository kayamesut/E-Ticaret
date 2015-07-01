<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UrunDetay.aspx.cs" Inherits="E_Ticaret.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="UrunlerBolgesi" runat="server">
            <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" align="center">
                               <h2><asp:Label ID="Label5" runat="server" Text="Label" Width="400px"></asp:Label></h2>
                        </td>
                    </tr>
                    <td style="height: 285px;vertical-align:middle" align="center">
                        <div style="width:244px; height:280px;top:50%;left:50%" >
                            <asp:Image ID="UrunResim" runat="server" style="max-width:200px; min-height:200px"/>
                        </div>
                    </td>
                    <td style="height: 285px">
                        <div style="font-family:Arial;font-size:14px;text-align:justify">
                            <table cellpadding="0" cellspacing="10">
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Fiyatı"></asp:Label>
                                    </td>
                                    <td align="right">:</td>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Label" Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Kategori"></asp:Label>
                                    </td>
                                    <td align="right">:</td>
                                    <td >
                                        <asp:Label ID="Label7" runat="server" Text="Label" Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Açıklama"></asp:Label>
                                    </td>
                                    <td align="right">:</td>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Label" Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:DropDownList ID="DropDownListProductCount" runat="server">
                                        </asp:DropDownList>
                                        <asp:Button ID="Button1" runat="server" Text="Sepete Ekle" 
                                            onclick="SepeteEkle_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Button2" runat="server" Text="Geri Dön" 
                                            onclick="Button2_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="sepetteVar" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    </tr>
            </table>
    
      
</asp:Content>
