<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JoueurAdmin.aspx.cs" Inherits="CRUD.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" 
        onrowdeleting="GridView1_RowDeleting" Width="593px">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                ShowSelectButton="True" />
            <asp:BoundField DataField="Id" ReadOnly="True" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" />
            <asp:BoundField DataField="Prenom" HeaderText="Prenom" 
                SortExpression="Prenom" />
            <asp:TemplateField HeaderText="Sexe" SortExpression="Sexe">
                <EditItemTemplate>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                        RepeatDirection="Horizontal" SelectedValue='<%# Bind("Sexe") %>' Width="246px">
                        <asp:ListItem Value="True">Home</asp:ListItem>
                        <asp:ListItem Value="False">Femme</asp:ListItem>
                    </asp:RadioButtonList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                        RepeatDirection="Horizontal" SelectedValue='<%# Bind("Sexe") %>' 
                        Width="100px" Enabled="False">
                        <asp:ListItem  Value="True">M</asp:ListItem>
                        <asp:ListItem  Value="False">F</asp:ListItem>
                    </asp:RadioButtonList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Equipe" SortExpression="EquipeId">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1"  runat="server" AutoPostBack="True" 
                        DataSourceID="ObjectDataSource1" DataTextField="Nom" DataValueField="Id" 
                        Height="29px" SelectedValue='<%# Bind("EquipeId", "{0}") %>' Width="312px">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                        SelectMethod="getAllEquipe" TypeName="DAL.DALEquipe"></asp:ObjectDataSource>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                        DataSourceID="ObjectDataSource2" DataTextField="Nom" DataValueField="Id" 
                        Height="33px" SelectedValue='<%# Bind("EquipeId", "{0}") %>' Width="309px" 
                        Enabled="False">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                        SelectMethod="getAllEquipe" TypeName="DAL.DALEquipe"></asp:ObjectDataSource>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="PROP.PROPJoueur" DeleteMethod="DeleteJoueur" 
        InsertMethod="CreateJoueur" SelectMethod="getAllJoueur" 
        TypeName="DAL.DALJoueur" UpdateMethod="UpdateJoueur">
        <DeleteParameters>
            <asp:Parameter Name="JoueurID" Type="Int32" />

        </DeleteParameters>
    </asp:ObjectDataSource>
    
    
    </asp:Content>
