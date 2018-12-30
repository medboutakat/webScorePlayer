<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="CRUD._Index" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="font-weight:bold">Create Country</div>
    <span style="height:20px; vertical-align:top">Country Name :</span> 
    <asp:TextBox ID="txtCountryName" runat="server"></asp:TextBox>
    <asp:Button ID="btnCreate" runat="server" Text="Create" 
    onclick="btnCreate_Click" />
    <hr />

    <div style="font-weight:bold">Delete Country By ID</div>
    <span style="height:20px; vertical-align:top">Country ID :</span>
    <asp:TextBox ID="txtDeleteID" runat="server"></asp:TextBox>
    <asp:Button ID="btnDelete" runat="server" Text="Delete" onclick="btnDelete_Click" />
    <hr />

    <div style="font-weight:bold">Search Country</div>
    <span style="height:20px; vertical-align:top">Country Name :</span>
    <asp:TextBox ID="txtSearchName" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" 
        onclick="btnSearch_Click" />
  

  
    <asp:GridView ID="gvCountryList" runat="server" AllowPaging="True" 
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
    <hr />
<div style="font-weight:bold">Edit Country</div>
<span style="height:20px; vertical-align:top">Country ID :</span>
<asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" onselectedindexchanged="ddlCountry_SelectedIndexChanged">    
</asp:DropDownList>        
<br />
<span style="height:20px; vertical-align:top">Country Name :</span>
<asp:TextBox ID="txtEditCountryName" runat="server"></asp:TextBox>
<asp:Button ID="btnEditCountryName" runat="server" Text="UpdateCountry" onclick="btnEditCountryName_Click" />
</asp:Content>
