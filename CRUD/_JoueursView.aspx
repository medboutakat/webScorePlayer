<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="_JoueursView.aspx.cs" Inherits="CRUD._JoueursView" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="font-weight:bold">Create Joueur</div>
    <span style="height:20px; vertical-align:top">Nom :</span> 
    <asp:TextBox ID="txtJoueurName" runat="server"></asp:TextBox>

    <span style="height:20px; vertical-align:top">Prenom :</span> 
    <asp:TextBox ID="txtJoueurPrenom" runat="server"></asp:TextBox>

     <span style="height:20px; vertical-align:top">Sexe :</span> 
     <asp:RadioButton ID="rdSexe1"  GroupName="sexeg" runat="server" Text="Homme" />
     <asp:RadioButton ID="rdSexe2"   GroupName="sexeg"  runat="server" 
        Text="Femme" />
     
     <span style="height:20px; vertical-align:top">Equipe :</span> 
     <asp:DropDownList ID="ddlEquipe" runat="server" AutoPostBack="True">    
</asp:DropDownList>  

    <asp:Button ID="btnCreate" runat="server" Text="Enregistrer" 
    onclick="btnCreate_Click" />
    <hr />

    <hr />

    <div style="font-weight:bold">Search Joueur</div>
    <span style="height:20px; vertical-align:top">Joueur Name :</span>
    <asp:TextBox ID="txtSearchName" runat="server" Width="387px"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" 
        onclick="btnSearch_Click" />
  
    <hr />

   


         <div class="row">
        <% foreach (var item in ListJoueurs)
           { %>
        <div class="col-md-4">
            <div class="card card-outline-primary mb-3 text-center">
                <div class="card-block">
                    <h3 class="card-title card-header">
                     <a href="Default.aspx"> <% =item.Nom+" "+item.Prenom %> </a>  </h3>
                    <div class="row card-footer">
                        <div class="col-12">
                            Joueur 1:
                            <% =item.EquipeId %> 
                        </div>
                        <div class=" col-12 "> 
                             <% =item.Sexe %>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%} %>
    </div> 
<div style="font-weight:bold"></div>
</asp:Content>
