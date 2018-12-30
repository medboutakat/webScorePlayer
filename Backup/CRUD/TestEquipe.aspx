<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestEquipe.aspx.cs" Inherits="CRUD.TestEquipe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <table>
        <tr>
            <th class="style1">
                Nom
            </th>
            <th>
                Prenom
            </th>
            <th>
                Sexe
            </th>
        </tr>
        <tr>
            <th class="style1">
                <asp:TextBox ID="TextBox1" runat="server" Width="230px"></asp:TextBox>
            </th>
            <th>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </th>
            <th>
                <asp:RadioButton ID="RadioButton1" GroupName="sexeg" runat="server" Text="H" />
                <asp:RadioButton ID="RadioButton3" GroupName="sexeg" runat="server" Text="F" />
            </th>
            <th class="style2">
            </th>
            <th>
            </th>
        </tr>
        <tr>
            <th class="style1">
                Nom
            </th>
            <th>
                Prenom
            </th>
            <th>
                Sexe
            </th>
        </tr>
        <tr>
            <th class="style1">
                <asp:TextBox ID="txtJoueurName" runat="server" Width="233px"></asp:TextBox>
            </th>
            <th>
                <asp:TextBox ID="txtJoueurPrenom" runat="server"></asp:TextBox>
            </th>
            <th>
                <asp:RadioButton ID="rdSexe1" GroupName="sexeg" runat="server" Text="H" />
                <asp:RadioButton ID="RadioButton2" GroupName="sexeg" runat="server" Text="F" />
            </th>
        </tr>
        <tr> <th style="text-align:center;" colspan="3">---------------------------</th></tr>
        <tr>
            <th colspan="3">
                <asp:DropDownList ID="ddlEquipe" runat="server" AutoPostBack="True" Height="32px"
                    Width="499px">
                </asp:DropDownList>
            </th>
            <th class="style2">
            </th>
        </tr>
          <tr> <th style="text-align:center;" colspan="3">---------------------------</th></tr>
       
        <tr>
            <th class="style1" colspan="3">
                <asp:Button ID="btnCreate" runat="server" Text="Enregistrer" OnClick="btnCreate_Click"
                    Width="500px" />
            </th>
        </tr>
    </table>
 
    </div>
    </form>
</body>
</html>
