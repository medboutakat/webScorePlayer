<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Joueurs.aspx.cs" Inherits="CRUD._Joueurs" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tr>
            <th>
                Nom
            </th>
            <th>
                Prenom
            </th>
            <th>
                Sexe
            </th>
            <th>Equipe
            </th>
        </tr>
        <tr>
            <th>
                
                <asp:TextBox ID="txtJoueurName" runat="server"></asp:TextBox>
            </th>
            <th>
                
                <asp:TextBox ID="txtJoueurPrenom" runat="server"></asp:TextBox>
            </th>
            <th>
                
                <asp:RadioButton ID="rdSexe1" GroupName="sexeg" runat="server" Text="H" />
                
                <asp:RadioButton ID="RadioButton2" GroupName="sexeg" runat="server" Text="F" />
            </th>
            <th>
                <asp:DropDownList ID="ddlEquipe" runat="server" AutoPostBack="True" Height="32px"
                    Width="180px">
                </asp:DropDownList>
            </th>
            <th>
                <asp:Button ID="btnCreate" runat="server" Text="Enregistrer" OnClick="btnCreate_Click"
                    Width="181px" />
            </th>
        </tr>
    </table>
    <br />
     <hr />
    <div style="font-weight: bold">
        chercher Joueur</div>
    <span style="height: 20px; vertical-align: top">Joueur :</span>
    <asp:TextBox ID="txtSearchName" runat="server" Width="643px"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
    <asp:GridView ID="gvJoueurList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataSourceID="ObjectDataSource1" OnRowDeleting="GridView1_RowDeleting" Width="593px">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="Id" ReadOnly="True" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" />
            <asp:BoundField DataField="Prenom" HeaderText="Prenom" SortExpression="Prenom" />
            <asp:TemplateField HeaderText="Sexe" SortExpression="Sexe">
                <EditItemTemplate>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                        SelectedValue='<%# Bind("Sexe") %>' Width="246px">
                        <asp:ListItem Value="True">Home</asp:ListItem>
                        <asp:ListItem Value="False">Femme</asp:ListItem>
                    </asp:RadioButtonList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                        SelectedValue='<%# Bind("Sexe") %>' Width="100px" Enabled="False">
                        <asp:ListItem Value="True">M</asp:ListItem>
                        <asp:ListItem Value="False">F</asp:ListItem>
                    </asp:RadioButtonList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Equipe" SortExpression="EquipeId">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
                        DataTextField="Nom" DataValueField="Id" Height="29px" SelectedValue='<%# Bind("EquipeId", "{0}") %>'
                        Width="312px">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getAllEquipe"
                        TypeName="DAL.DALEquipe"></asp:ObjectDataSource>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource2"
                        DataTextField="Nom" DataValueField="Id" Height="33px" SelectedValue='<%# Bind("EquipeId", "{0}") %>'
                        Width="309px" Enabled="False">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getAllEquipe"
                        TypeName="DAL.DALEquipe"></asp:ObjectDataSource>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="PROP.PROPJoueur"
        DeleteMethod="DeleteJoueur" InsertMethod="CreateJoueur" SelectMethod="getAllJoueur"
        TypeName="DAL.DALJoueur" UpdateMethod="UpdateJoueur">
        <DeleteParameters>
            <asp:Parameter Name="JoueurID" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
    <hr />
    <hr />
    <div style="font-weight: bold">
    </div>
</asp:Content>
