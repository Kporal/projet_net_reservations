<?php
	
	// turn off the WSDL cache
	ini_set('soap.wsdl_cache_enabled', '0');

    require_once 'WebServiceConsultation.php';

    // on indique au serveur le fichier wsdl
    $serveurSOAP = new SoapServer('wsConsultationWSDL.wsdl');

    // ajouter la classe au serveur
    $serveurSOAP->setClass("WebServiceConsultation");

    // lancer le serveur
    $serveurSOAP->handle();