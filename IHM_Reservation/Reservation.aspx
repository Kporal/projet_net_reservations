<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="IHM_Reservation._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>Réservation : </h1>
        Ville de départ :<br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" >
            <asp:ListItem>Paris, France</asp:ListItem>
            <asp:ListItem>London, UK</asp:ListItem>
            <asp:ListItem>Berlin, Allemagne</asp:ListItem>
            <asp:ListItem>Rome, Italie</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Ville d&#39;arrivée :<br />
        <br />
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem>Paris, France</asp:ListItem>
            <asp:ListItem>London, UK</asp:ListItem>
            <asp:ListItem>Berlin, Allemagne</asp:ListItem>
            <asp:ListItem>Rome, Italie</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Date de départ :<br />
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
            <DayStyle Width="14%" />
            <NextPrevStyle Font-Size="8pt" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
            <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
            <TodayDayStyle BackColor="#CCCC99" />
        </asp:Calendar>
        <br />
        Durée :<br />
        <asp:DropDownList ID="DropDownList3" runat="server">
            <asp:ListItem>1 jour</asp:ListItem>
            <asp:ListItem>2 jours</asp:ListItem>
            <asp:ListItem>3 jours</asp:ListItem>
            <asp:ListItem>4 jours</asp:ListItem>
            <asp:ListItem>5 jours</asp:ListItem>
            <asp:ListItem>6 jours</asp:ListItem>
            <asp:ListItem>7 jours</asp:ListItem>
            <asp:ListItem>8 jours</asp:ListItem>
            <asp:ListItem>9 jours</asp:ListItem>
            <asp:ListItem>10 jours</asp:ListItem>
            <asp:ListItem>+ de 10 jours</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_rechercher" runat="server" Text="Rechercher" />
        <br />
        </div>
        <div>
            <h1> Vol(s) disponible(s) :</h1>
            <br />
            <asp:DropDownList ID="DropDownList4" runat="server">
                <asp:ListItem>Vol Air France AZ345 : Paris - Londres</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Prix :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:Label ID="lbl_vol_price" runat="server" Text="Label"></asp:Label>
            <br />
            De :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbl_vol_from" runat="server" Text="Label"></asp:Label>
            <br />
            Vers :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; <asp:Label ID="lbl_vol_to" runat="server" Text="Label"></asp:Label>
            <br />
            Categorie :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbl_vol_category" runat="server" Text="Label"></asp:Label>
            <br />
            Date Départ :&nbsp;&nbsp; <asp:Label ID="lbl_vol_dateStart" runat="server" Text="Label"></asp:Label>
            <br />
            Date Arrivée :&nbsp; <asp:Label ID="lbl_vol_dateEnd" runat="server" Text="Label"></asp:Label>
             <br />
        </div>
        <div>
            <h1>Hotel(s) :</h1>
            <asp:DropDownList ID="DropDownList5" runat="server">
                <asp:ListItem>Hotel 3 étoiles Le Fritz</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Localisation :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_hotel_city" runat="server" Text="City"></asp:Label>
            ,
            <asp:Label ID="lbl_hotel_country" runat="server" Text="Country"></asp:Label>
            <br />
            Prix :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_hotel_price" runat="server" Text="Price"></asp:Label>
            <br />
            Etoile(s) :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:Label ID="lbl_hotel_stars" runat="server" Text="Etoile"></asp:Label>
            <br />
            Date Arrivée :&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_hotel_dateStart" runat="server" Text="DateStart"></asp:Label>
            <br />
            Date Départ :&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_hotel_dateEnd" runat="server" Text="DateEnd"></asp:Label>
            <br />
        </div>
        <br />
        <asp:Button ID="btn_valider_voyage" runat="server" OnClick="btn_valider_voyage_Click" Text="Valider Voyage" />
    </form>
</body>
</html>
