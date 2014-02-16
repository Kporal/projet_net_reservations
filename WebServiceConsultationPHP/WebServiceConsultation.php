<?php

require_once 'Config.php';
require_once 'Vol.php';
require_once 'Hotel.php';
require_once 'Destination.php';

class WebServiceConsultation {

    function GetListHotels($param) {
        try {
            // connexion a distance
            $pdo = new PDO (
                'mysql:host=' . Config::$host . ';dbname=' . Config::$dbHotel . ';port=' . Config::$port,
                Config::$userHotel,
                Config::$passwordHotel,
                array(PDO::MYSQL_ATTR_INIT_COMMAND => 'SET NAMES utf8')
            );
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_WARNING);

            // parse du parametre entre
            $tmp = get_object_vars($param);
            $city = $tmp["idCity"];

            // creation des resultats
            $result = array();
            foreach($pdo->query(Config::sqlHotel($city)) as $row) {
                $hotel = new HotelWS();
                $hotel->id             = $row['id'];
                $hotel->name           = $row['name'];
                $hotel->stars          = $row['stars'];
                $hotel->id_destination = $row['id_destination'];
                $hotel->price          = $row['price'];
                $result[] = $hotel;
            }
        } catch (PDOException $e) {
            die($e->getMessage());
        }

        return array('GetListHotelsResult' => $result);
    }

    function GetHotelById($param) {
        try {
            // connexion a distance
            $pdo = new PDO (
                'mysql:host=' . Config::$host . ';dbname=' . Config::$dbHotel . ';port=' . Config::$port,
                Config::$userHotel,
                Config::$passwordHotel,
                array(PDO::MYSQL_ATTR_INIT_COMMAND => 'SET NAMES utf8')
            );
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_WARNING);

            // parse du parametre entre
            $tmp = get_object_vars($param);
            $id = $tmp["id"];

            // creation des resultats
            $result = array();
            foreach($pdo->query(Config::sqlHotelById($id)) as $row) {
                $hotel = new HotelWS();
                $hotel->id             = $row['id'];
                $hotel->name           = $row['name'];
                $hotel->stars          = $row['stars'];
                $hotel->id_destination = $row['id_destination'];
                $hotel->price          = $row['price'];
                $result[] = $hotel;
            }
        } catch (PDOException $e) {
            die($e->getMessage());
        }

        return array('GetHotelByIdResult' => current($result));
    }

    function GetListVols($params) {
        try {
            // connexion a distance
            $pdo = new PDO (
                'mysql:host=' . Config::$host . ';dbname=' . Config::$dbVol . ';port=' . Config::$port,
                Config::$userVol,
                Config::$passwordVol,
                array(PDO::MYSQL_ATTR_INIT_COMMAND => 'SET NAMES utf8')
            );
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_WARNING);

            // parse du parametre entre
            $tmp       = get_object_vars($params);
            $from      = $tmp["idFrom"];
            $to        = $tmp["idTo"];
            $dateStart = $tmp["dateStart"];

            // creation des resultats
            $result = array();
            foreach($pdo->query(Config::sqlVol($from, $to, $dateStart)) as $row) {
                $vol = new VolWS();
                $vol->id                  = $row['id'];
                $vol->name                = $row['name'];
                $vol->id_destination_from = $row['id_destination_from'];
                $vol->id_destination_to   = $row['id_destination_to'];
                $vol->price               = $row['price'];
                $vol->category            = $row['category'];
                $vol->dateStart           = $row['dateStart'];
                $vol->dateEnd             = $row['dateEnd'];

                $result[] = $vol;
            }
        } catch (PDOException $e) {
            die($e->getMessage());
        }

        return array('GetListVolsResult' => $result);
    }

    function GetVolById($params) {
        try {
            // connexion a distance
            $pdo = new PDO (
                'mysql:host=' . Config::$host . ';dbname=' . Config::$dbVol . ';port=' . Config::$port,
                Config::$userVol,
                Config::$passwordVol,
                array(PDO::MYSQL_ATTR_INIT_COMMAND => 'SET NAMES utf8')
            );
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_WARNING);

            // parse du parametre entre
            $tmp = get_object_vars($params);
            $id  = $tmp["id"];

            // creation des resultats
            $result = array();
            foreach($pdo->query(Config::sqlVolById($id)) as $row) {
                $vol = new VolWS();
                $vol->id                  = $row['id'];
                $vol->name                = $row['name'];
                $vol->id_destination_from = $row['id_destination_from'];
                $vol->id_destination_to   = $row['id_destination_to'];
                $vol->price               = $row['price'];
                $vol->category            = $row['category'];
                $vol->dateStart           = $row['dateStart'];
                $vol->dateEnd             = $row['dateEnd'];

                $result[] = $vol;
            }
        } catch (PDOException $e) {
            die($e->getMessage());
        }

        return array('GetVolByIdResult' => current($result));
    }

    function GetListDestinations() {

        try {
            // connexion a distance
            $pdo = new PDO (
                'mysql:host=' . Config::$host . ';dbname=' . Config::$dbDestination . ';port=' . Config::$port,
                Config::$userHotel,
                Config::$passwordHotel,
                array(PDO::MYSQL_ATTR_INIT_COMMAND => 'SET NAMES utf8')
            );
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_WARNING);

            // creation des resultats
            $result = array();
            foreach($pdo->query(Config::sqlDestination()) as $row) {
                $destination = new DestinationWS();
                $destination->id      = $row['id'];
                $destination->city    = $row['city'];
                $destination->country = $row['country'];
                $result[] = $destination;
            }
        } catch (PDOException $e) {
            die($e->getMessage());
        }

        return array('GetListDestinationsResult' => $result);
    }
} 