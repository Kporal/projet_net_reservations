-- phpMyAdmin SQL Dump
-- version 3.3.7deb7
-- http://www.phpmyadmin.net
--
-- Serveur: localhost
-- Généré le : Ven 14 Février 2014 à 17:15
-- Version du serveur: 5.1.73
-- Version de PHP: 5.3.3-7+squeeze18

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données: `vols`
--

-- --------------------------------------------------------

--
-- Structure de la table `vols`
--

CREATE TABLE IF NOT EXISTS `vols` (
  `id` int(5) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `price` float(10,2) NOT NULL,
  `category` varchar(20) NOT NULL,
  `dateStart` datetime NOT NULL,
  `dateEnd` datetime NOT NULL,
  `id_destination_from` int(11) NOT NULL,
  `id_destination_to` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=11 ;

--
-- Contenu de la table `vols`
--

INSERT INTO `vols` (`id`, `name`, `price`, `category`, `dateStart`, `dateEnd`, `id_destination_from`, `id_destination_to`) VALUES
(1, 'AIR FRANCE', 75.00, '1ere classe', '2014-02-23 00:00:00', '2014-02-23 00:00:00', 1, 3),
(2, 'RYAN AIR', 1300.00, '2eme classe', '2014-02-25 00:00:00', '2014-02-27 00:00:00', 2, 3),
(8, 'KLM', 346.34, 'Economique', '2014-02-20 00:00:00', '2014-02-25 00:00:00', 4, 3),
(7, 'KLM', 985.45, 'Economique', '2014-03-13 00:00:00', '2014-04-15 00:00:00', 1, 4),
(5, 'CORS''AIR', 200.23, 'Affaire', '2014-02-26 00:00:00', '2014-02-27 00:00:00', 7, 3),
(6, 'AIR CANADA', 845.34, 'Economique', '2014-02-28 00:00:00', '2014-03-05 00:00:00', 1, 8),
(9, 'AMERICAN AIRLINES', 1234.23, 'Economique', '2014-02-27 00:00:00', '2014-02-28 00:00:00', 2, 3),
(10, 'AMERICAN AIRLINES', 1600.00, 'Affaire', '2014-02-27 00:00:00', '2014-02-27 00:00:00', 1, 2);
