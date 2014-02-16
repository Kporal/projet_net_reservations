<?php
	
	// turn off the WSDL cache
	ini_set('soap.wsdl_cache_enabled', '0');

    try { 
        // lier le client au fichier WSDL
        $clientSOAP = new SoapClient('wsConsultationWSDL.wsdl');

        // executer la methode
        $param = new RequestHotel();
        print_r($clientSOAP->GetListHotels($param));

        echo '<br><br>';

        $param = new RequestVol();
        print_r($clientSOAP->GetListVols($param));

        echo '<br><br>';

        print_r($clientSOAP->GetListDestinations());

        echo '<br><br>';

        $param = new RequestVolHotel();
        print_r($clientSOAP->GetHotelById($param));

        echo '<br><br>';

        print_r($clientSOAP->GetVolById($param));

        echo '<br><br>';
        
        require_once 'WebServiceConsultation.php';
        $ws = new WebServiceConsultation();
        print_r($ws->GetVolById($param));

    } catch (SoapFault $e) { 
        echo $e->faultstring; 
    }

    class RequestVolHotel {
        public $id = 1;
    }

    class RequestHotel {
        public $idCity = 1;
    }

    class RequestVol {
        public $idFrom = 1;
        public $idTo = 2;
        public $dateStart = "2014-03-01";
    }