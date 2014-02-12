<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Paiement.aspx.cs" Inherits="IHM_Reservation.Paiement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Content/bootstrap.min.css" rel="stylesheet">
    <script src="Scripts/bootstrap.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Paiement : </h1>
            <br />

            Nom :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txt_name" runat="server">Nom</asp:TextBox>
            <br />
            Prénom :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txt_firstname" runat="server">Prénom</asp:TextBox>
            <br />
            Adresse :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txt_address" runat="server">Adresse</asp:TextBox>
            <br />
            Code Postal :
            <asp:TextBox ID="txt_postalCode" runat="server">Code Postal</asp:TextBox>
            <br />
            Ville :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txt_city" runat="server">Ville</asp:TextBox>
            <br />
            Pays :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txt_Pays" runat="server">Pays</asp:TextBox>

        </div>
        <br />
        <asp:Button ID="btn_paiement" runat="server" Text="Paiement" />
    </form>
</body>
</html>
