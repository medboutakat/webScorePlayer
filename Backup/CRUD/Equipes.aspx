<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Equipes.aspx.cs" Inherits="CRUD._Equipes" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style6
        {
            width: 687px;
        }
        .style12
        {
            width: 221px;
        }
        .style13
        {
            width: 120px;
        }
        
        #Content
        { 
            text-align: center;
            margin: 0 auto;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="Content">
        <table class="style6">
            <tr>
                <th class="style13">
                    Nom
                </th>
                <th class="style12">
                    <asp:TextBox ID="txtEquipeName" runat="server" Width="230px"></asp:TextBox>
                </th>
                <th class="style12">
                    <asp:Button ID="btnCreate" runat="server" Text="Enregistrer" OnClick="btnCreate_Click"
                        Width="147px" />
                </th>
            </tr>
        </table>
        &nbsp;<hr />
        <div style="font-weight: bold ; margin: 0 auto; text-align:center;">
            <asp:GridView ID="gvJoueurList" runat="server" Width="100%" AutoGenerateColumns="False"
                DataSourceID="ObjectDataSource1" 
                onselectedindexchanged="gvJoueurList_SelectedIndexChanged1" 
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                CommandArgument='<%# Eval("Id") %>' CommandName="Delete" Text="Supprimer" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Id" ReadOnly="true" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="PROP.PROPEquipe"
                InsertMethod="CreateEquipe" SelectMethod="getAllEquipe" DeleteMethod="DeleteEquipe"
                TypeName="DAL.DALEquipe" UpdateMethod="UpdateEquipe">
                <DeleteParameters>
                    <asp:Parameter Name="EquipeID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="EquipeName" Type="String" />
                </InsertParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
