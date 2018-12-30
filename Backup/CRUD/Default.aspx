<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="CRUD._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <% 
     
            foreach (var item in ListRandEquipeGrade1)
            {  %>
        <div class="col-3 text-center bgr">
            <%=item.EquipeANom%>
            VS
            <%=item.EquipeBNom%>
        </div>
        <% } %>
    </div>
    <br />
    <div class="row">
        <% 
            foreach (var item in ListRandEquipeGrade2)
            {  %>
        <div class="col-3 push-3 text-center bgr ">
            <%=item .EquipeANom%>
            VS
            <%=item .EquipeBNom%>
        </div>
        <% } %>
    </div>
    <br />
    <div class="row">
        <% 
      
            foreach (var item in ListRandEquipeGrade3)
            { 
        %>
        <div class="col-4 push-4 text-center bgr ">
            <%=item.EquipeANom%>
            VS
            <%=item.EquipeBNom%>
        </div>
        <% } %>
    </div>
    <br />
    <div class="row">
        <% 
      
            foreach (var item in ListRandEquipeGrade4)
            { 
        %>
        <div class="col-2 push-5 text-center bgr ">
            <%=item.EquipeANom%>
        </div>
        <% } %>
    </div>
</asp:Content>
