<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EquipesView.aspx.cs" Inherits="CRUD.EquipesView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <% foreach (var item in LsEquipe)
           { %>
        <div class="col-4 p-2">
            <div class="card text-center border-primary mb-3">
                <div class="card-header">
                    <h1 class="card-title">
                        <% =item.Nom %>
                    </h1>
                </div>
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">
                            <% =item.Joueur1.Nom %>
                            <% =item.Joueur1.Prenom %></h5>
                        <h6 class="card-subtitle mb-2 text-muted">
                            <% =item.Joueur1.Sexe?"Home":"Femme" %></h6> 
                    </div>
                </div>
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">
                            <% =item.Joueur2.Nom %>
                            <% =item.Joueur2.Prenom %></h5>
                        <h6 class="card-subtitle mb-2 text-muted">
                            <% =item.Joueur2.Sexe?"Home":"Femme" %></h6> 
                    </div>
                </div>
                <div class="card-footer text-muted">
                    <a href="Equipe.aspx?id=<%=item.Id %>">Details</a>
                </div>
            </div>
        </div>
        <%} %>
    </div>
</asp:Content>
