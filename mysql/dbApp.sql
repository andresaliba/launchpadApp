

SET SQL_MODE = `NO_AUTO_VALUE_ON_ZERO`;
SET time_zone = `+00:00`;

-- --------------------------------------------------------
--
-- Table structure for table `tblCategory`
--
CREATE TABLE IF NOT EXISTS `tblCategory` (
  `categoryID` int(10) NOT NULL AUTO_INCREMENT,
  `categoryName` varchar(50) NOT NULL,
  PRIMARY KEY (`categoryID`)
) ENGINE=InooDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1;


--
-- Dumping data for table `tblCategory`
--
INSERT INTO `tblCategory` (`categoryID`, `categoryName`) VALUES
(1, "Technology"),
(2, "School"),
(3, "Play"),
(4, "Data");

-- --------------------------------------------------------
--
-- Table structure for table `tblLink`
--
CREATE TABLE IF NOT EXISTS `tblLink` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `categoryID` int(10) NOT NULL,
  `linkName` varchar(100) NOT NULL,
  `url` varchar(100) NOT NULL,
  `pinned` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `categoryID` (`categoryID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1;

--
-- Dumping data for table `tblLink`
--
INSERT INTO `tblLink` (`id`, `categoryID`, `linkName`, `url`, `pinned`) VALUES
(1, 1, "Github", "https://github.com", 1),
(2, 1, "AngularJS", "https://angularjs.org", 1),
(3, 1, "Linkedin", "https://linkedin.com", 1),
(4, 2, "NSCC", "https://nscc.ca", 1),
(5, 2, "Trello", "https://trello.com", 1),
(6, 2, "AWS Educate Console", "https://labs.vocareum.com", 0),
(7, 2, "VitalSource", "https://vitalsource.com", 0),
(8, 2, "Google Analytics", "https://analytics.google.com", 0),
(9, 3, "Facebook", "https://facebook.com", 1),
(10, 3, "Youtube", "https://youtube.com", 1),
(11, 4, "Tangerine Bank", "https://tangerine.ca", 0),
(12, 4, "Google Maps", "https://google.com", 0);

-- --------------------------------------------------------
--
-- Table structure for table `tblLogin`
--
CREATE TABLE IF NOT EXISTS `tblLogin` (
  `username` varchar(45) NOT NULL PRIMARY KEY,
  `password` varchar(200) NOT NULL,
  `salt` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


--
-- Dumping data for table `tblLogin`
--
INSERT INTO `tblLogin` (`username`, `password`, `salt`) VALUES
("andre", "yntNoUWlExu9J0gtYLDiqaD7YvgbdMnsmCjr0q/0qMg=", "F8fjFvSL3J+j0B7tnw3pcA==");

-- --------------------------------------------------------
-- Constraints for table `tblLink`
--
ALTER TABLE `tblLink`
  ADD CONSTRAINT `tblLink_ibfk_1` FOREIGN KEY (`categoryID`) REFERENCES `tblCategory` (`categoryID`);