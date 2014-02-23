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
-- Base de données: `hotels`
--

-- --------------------------------------------------------

--
-- Structure de la table `hotels`
--

CREATE TABLE IF NOT EXISTS `hotels` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `stars` int(1) NOT NULL,
  `price` float(10,2) NOT NULL,
  `id_destination` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Contenu de la table `hotels`
--

INSERT INTO `hotels` (`id`, `name`, `stars`, `price`, `id_destination`) VALUES
(1, 'B&B Nantes Centre', 2, 375.00, 1),
(2, 'Le Ritz', 5, 655.00, 2),
(3, 'Strand Palace Hotel', 5, 43.00, 3),
(4, 'The Westin Grand', 3, 170.00, 4),
(5, 'Ellington Hotel', 2, 345.00, 4),
(6, 'The Milestone Hotel', 3, 254.00, 3);
