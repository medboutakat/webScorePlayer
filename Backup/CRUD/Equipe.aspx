<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Equipe.aspx.cs"
 Inherits="CRUD.Equipe" %>
  
 <asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
 
 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 
    <div>
        <asp:Label ID="lblId" runat="server" Text="Label" Visible="false"></asp:Label>
          <h1> <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
              <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
          </h1>
          <h2> <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> 
          
              <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
              </h2>
          <h2> <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
          
              <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></h2> 
          <asp:LinkButton CssClass="btn btn-primary" ID="btnLink" PostBackUrl="~/EquipesView.aspx" runat="server">List des equipe</asp:LinkButton>  
        <asp:Button CssClass="btn btn-secondary" ID="EdBtn" runat="server" 
            Text="Edit" onclick="Button1_Click" /> 
        <asp:Button CssClass="btn btn-secondary" ID="UpdBtn" runat="server" 
            Text="Update" onclick="Button1_Click" /> 
          <button class="btn btn-danger">Delete</button> 
    </div> 
 
</asp:Content>

<asp:Content ID="ftr" ContentPlaceHolderID="footerScript" runat="server">
    <script>

    $(function () {
        alert('Update')
    });
</script>   
</asp:Content>