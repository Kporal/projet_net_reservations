<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="IHM_Reservation._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Bootstrap-->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <!-- /Bootstrap-->
    <title></title>
</head>
<body>

    <div class="container">

        <div class="jumbotron">
            <h1>Réservez votre voyage</h1>
            <p>Pour effectuer une réservation, vous devez : </p>
            <ul>
                <li>Sélectionner des informations générales sur le voyage que vous souhaitez effectuer (Partie réservation)</li>
                <li>Choisir un vol correspondant à votre voyage (partie Vol(s) Disponible(s))</li>
                <li>Choisir un hôtel (partie Hôtel(s))</li>
                <li>Entrer vos informations personnelles (partie Coordonnées)</li>
            </ul>
        </div>

        <div class="well">
            <form id="formReservation" runat="server">

                <!-- ----------- -->
                <!-- Réservation -->
                <!-- ----------- -->
                <div>
                    <h2>Réservation : </h2>
                    <div class="row">
                        <br />
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Ville de départ :</label>
                                <asp:DropDownList ID="dpdl_villeDep" runat="server">
                                </asp:DropDownList>
                            </div>
                            <br />
                            <div class="form-group">
                                <label>Ville d&#39;arrivée :</label>
                                <asp:DropDownList ID="dpdl_villeArr" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Date de départ :</label>
                                <asp:Calendar ID="cal_dateStart" runat="server" BackColor="White" BorderColor="#3366CC" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest">
                                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#009999" ForeColor="#CCFF99" Font-Bold="True" />
                                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                    <TitleStyle BackColor="#003399" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" BorderColor="#3366CC" BorderWidth="1px" Height="25px" />
                                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                    <WeekendDayStyle BackColor="#CCCCFF" />
                                </asp:Calendar>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Date de fin :</label>
                                <asp:Calendar ID="cal_dateEnd" runat="server" BackColor="White" BorderColor="#3366CC" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest">
                                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#009999" ForeColor="#CCFF99" Font-Bold="True" />
                                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                    <TitleStyle BackColor="#003399" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" BorderColor="#3366CC" BorderWidth="1px" Height="25px" />
                                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                    <WeekendDayStyle BackColor="#CCCCFF" />
                                </asp:Calendar>
                            </div>
                        </div>
                    </div>

                    <asp:Label ID="lbl_erreurWS" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Text="Label" Visible="False"></asp:Label>

                    <br />
                    <asp:Button ID="btn_rechercher" runat="server" Text="Rechercher" OnClick="btn_rechercher_Click" />
                    <br />
                    <br />
                </div>

                <!-- --- -->
                <!-- SELECTION RESERVATION -->
                <!-- --- -->

                <asp:Panel ID="panelReservation" runat="server" Visible="False">

                    <!-- --- -->
                    <!-- Vol -->
                    <!-- --- -->
                    <div>
                        <h3>Vol(s) disponible(s) :</h3>
                        <br />
                        <div class="form-group">
                            <label>Choix de votre vol :</label>
                            <asp:DropDownList ID="dpdl_volDispo" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <!-- ----- -->
                    <!-- Hôtel -->
                    <!-- ----- -->
                    <div>
                        <h3>Hotel(s) :</h3>
                        <br />

                        <div class="form-group">
                            <label>Choix de votre hôtel :</label>
                            <asp:DropDownList ID="dpdl_hotelDispo" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div>
                        <h3>Coordonnées :</h3>
                        <br />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Nom :</label>
                                    <asp:TextBox class="form-control" ID="txt_clientName" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Téléphone :</label>
                                    <asp:TextBox class="form-control" ID="txt_clientPhone" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Adresse :</label>
                                    <asp:TextBox class="form-control" ID="txt_clientAddress" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Ville :</label>
                                    <asp:TextBox class="form-control" ID="txt_clientCity" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Prénom :</label>
                                    <asp:TextBox class="form-control" ID="txt_clientFirstname" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>E-Mail :</label>
                                    <asp:TextBox class="form-control" ID="txt_clientMail" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Code Postal :</label>
                                    <asp:TextBox class="form-control" ID="txt_clientPostalCode" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Pays :</label>
                                    <asp:TextBox class="form-control" ID="txt_clientPays" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:Label ID="lbl_validation_voyage" runat="server" ForeColor="#00CC00" Text="Label" Visible="False"></asp:Label>
                    <br />
                    <asp:Button ID="btn_valider_voyage" runat="server" OnClick="btn_valider_voyage_Click" Text="Valider Voyage" Enabled="False" />
                </asp:Panel>

                <!-- --------- -->
                <!-- Validator -->
                <!-- --------- -->

                <br />
                <!-- NomClient-->
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_clientName" Display="dynamic" ErrorMessage="Veuillez saisir le nom du client" />
                <asp:CompareValidator runat="server" ControlToValidate="txt_clientName" Type="String" Operator="DataTypeCheck"
                    ErrorMessage="Veuillez saisir le nom du client" Display="Dynamic" />
                <br />
                <!-- PrenomClient-->
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_clientFirstname" Display="dynamic" ErrorMessage="Veuillez saisir le prénom du client" />
                <asp:CompareValidator runat="server" ControlToValidate="txt_clientFirstname" Type="String" Operator="DataTypeCheck"
                    ErrorMessage="Veuillez saisir le prénom du client" Display="Dynamic" />
                <br />
                <!-- CodePostalClient-->
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_clientPostalCode" Display="dynamic" ErrorMessage="Veuillez saisir un code postal pour le client" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="txt_clientPostalCode" ErrorMessage="Le code postal saisi n'est pas correct" Display="dynamic"
                    ValidationExpression="([0-9]{5})" />
                <br />
                <!-- VilleClient-->
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_clientCity" Display="dynamic" ErrorMessage="Veuillez saisir la ville de résidence du client" />
                <asp:CompareValidator runat="server" ControlToValidate="txt_clientCity" Type="String" Operator="DataTypeCheck"
                    ErrorMessage="Veuillez saisir la ville de résidence du client" Display="Dynamic" />
                <br />
                <!-- PaysClient-->
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_clientPays" Display="dynamic" ErrorMessage="Veuillez saisir le pays de résidence du client" />
                <asp:CompareValidator runat="server" ControlToValidate="txt_clientPays" Type="String" Operator="DataTypeCheck"
                    ErrorMessage="Veuillez saisir le pays de résidence du client" Display="Dynamic" />
            </form>
        </div>
    </div>
    <!-- /container -->
</body>
</html>
