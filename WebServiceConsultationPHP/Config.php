<?php

    class Config {

        // BDD
        static $host = 'localhost';
        static $port = '3306';

        // VOLS
        static $dbVol = 'vols';
        static $userVol = 'vols';
        static $passwordVol = 'vols2014';
        static function sqlVol($idFrom, $idTo, $dateStart) {
           return 'SELECT * from `vols` 
           WHERE `id_destination_from` = "' . $idFrom . '" 
           AND `id_destination_to` = "' . $idTo . '" 
           AND `dateStart` <= "' . $dateStart . '"  
           AND `dateStart` >= "' . date('Y-m-d HH:mm:ss') . '" 
           ORDER BY `price`;';
        }
        static function sqlVolById($id) {
           return 'SELECT * from `vols` WHERE `id` = "' . $id . '";';
        }

        // HOTELS
        static $dbHotel = 'hotels';
        static $userHotel = 'hotels';
        static $passwordHotel = 'hotels2014';
        static function sqlHotel($idCity) {
           return 'SELECT * from `hotels` WHERE `id_destination` = "' . $idCity . '" ORDER BY `price`;';
        }
        static function sqlHotelById($id) {
           return 'SELECT * from `hotels` WHERE `id` = "' . $id . '";';
        }

        // DESTINATIONS
        static $dbDestination = 'destinations';
        static function sqlDestination() {
           return 'SELECT * from `destination` ORDER BY `country`, `city`;';
        }

    }