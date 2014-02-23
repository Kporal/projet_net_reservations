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
-- Base de données: `destinations`
--

-- --------------------------------------------------------

--
-- Structure de la table `destination`
--

CREATE TABLE IF NOT EXISTS `destination` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `city` varchar(45) NOT NULL,
  `country` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

--
-- Contenu de la table `destination`
--

INSERT INTO `destination` (`id`, `city`, `country`) VALUES
(1, 'Nantes', 'France'),
(2, 'Paris', 'France'),
(3, 'Londres', 'Angleterre'),
(4, 'Berlin', 'Allemagne'),
(5, 'Rome', 'Italie'),
(6, 'Madrid', 'Espagne'),
(7, 'Cardiff', 'Pays-De-Galle'),
(8, 'Dublin', 'Irlande');
