

SET SQL_MODE = `NO_AUTO_VALUE_ON_ZERO`;
SET time_zone = `+00:00`;


-- Category TABLE
CREATE TABLE IF NOT EXISTS `tblCategory` (
  `categoryID` int(10) NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(50) NOT NULL
) ENGINE=InooDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1;

INSERT INTO `tblCategory` (`categoryID`, `name`) VALUES
(1, "Technology"),
(2, "School"),
(3, "Play"),
(4, "Data");

-- Link TABLE
CREATE TABLE IF NOT EXISTS `tblLink` (
  `id` int(10) NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `categoryID` int(10) NOT NULL,
  `name` varchar(100) NOT NULL,
  `url` varchar(100) NOT NULL,
  `pinned` boolean NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1;

INSERT INTO `tblLink` (`id`, `categoryID`, `name`, `url`, `pinned`) VALUES
(1, 1, "AngularJS", "https://angularjs.org", 1),
(2, 1, "Github", "https://github.com", 1),
(3, 1, "Linkedin", "https://linkedin.com", 1),
(4, 2, "NSCC", "https://nscc.ca", 1),
(5, 2, "Trello", "https://trello.com", 1),
(6, 3, "Facebook", "https://facebook.com", 1),
(7, 3, "Youtube", "https://youtube.com", 1),
(8, 4, "Tangerine Bank", "https://tangerine.ca", 1),
(9, 4, "Google Maps", "https://google.com", 1);

-- Login TABLE
CREATE TABLE IF NOT EXISTS `tblLogin` (
  `username` varchar(45) NOT NULL PRIMARY KEY,
  `password` varchar(200) NOT NULL,
  `salt` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `tblLogin` (`username`, `password`, `salt`) VALUES
("andre", "yntNoUWlExu9J0gtYLDiqaD7YvgbdMnsmCjr0q/0qMg=", "F8fjFvSL3J+j0B7tnw3pcA==");