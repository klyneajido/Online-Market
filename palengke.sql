-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 19, 2023 at 03:14 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `palengke`
--

-- --------------------------------------------------------

--
-- Table structure for table `bought`
--

CREATE TABLE `bought` (
  `ID` int(11) NOT NULL,
  `Name` varchar(250) NOT NULL,
  `Price` int(11) NOT NULL,
  `Seller` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `ID` int(11) NOT NULL,
  `Name` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`ID`, `Name`) VALUES
(64, 'Meat'),
(65, 'Fish'),
(66, 'Vegetable'),
(67, 'Fruit');

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `ID` int(11) NOT NULL,
  `Address` varchar(250) NOT NULL,
  `Username` varchar(250) NOT NULL,
  `Name` varchar(250) NOT NULL,
  `Phone_number` varchar(200) NOT NULL,
  `Age` varchar(200) NOT NULL,
  `Password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`ID`, `Address`, `Username`, `Name`, `Phone_number`, `Age`, `Password`) VALUES
(7, 'Manila ', 'customer1', 'customer1', '123456567', '19', '123'),
(8, 'Pasay', 'customer2', 'customer2', '123456567', '56', '123'),
(9, 'Laguna', 'customer3', 'customer3', '4346567', '43', '123');

-- --------------------------------------------------------

--
-- Table structure for table `logged`
--

CREATE TABLE `logged` (
  `ID` int(11) NOT NULL,
  `Username` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `order`
--

CREATE TABLE `order` (
  `ID` int(11) NOT NULL,
  `Customer` varchar(250) NOT NULL,
  `Address` varchar(250) NOT NULL,
  `Total` int(200) NOT NULL,
  `Date` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `order`
--

INSERT INTO `order` (`ID`, `Customer`, `Address`, `Total`, `Date`) VALUES
(26, 'customer1', 'Manila ', 980, '14/07/2023 9:15:05 pm');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `ID` int(11) NOT NULL,
  `Name` varchar(250) NOT NULL,
  `Price` int(250) NOT NULL,
  `Quantity` int(250) NOT NULL,
  `Category` varchar(200) NOT NULL,
  `Seller` varchar(250) NOT NULL,
  `Seller_username` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`ID`, `Name`, `Price`, `Quantity`, `Category`, `Seller`, `Seller_username`) VALUES
(51, 'Salmon', 200, 34, 'Fish', 'seller1', 'seller1'),
(52, 'Bangus', 140, 10, 'Fish', 'seller1', 'seller1'),
(53, 'Crab', 400, 9, 'Fish', 'seller1', 'seller1'),
(54, 'Shrimp', 200, 31, 'Fish', 'seller1', 'seller1'),
(55, 'Sardines', 100, 39, 'Fish', 'seller1', 'seller1');

-- --------------------------------------------------------

--
-- Table structure for table `registered`
--

CREATE TABLE `registered` (
  `ID` int(11) NOT NULL,
  `Address` varchar(250) NOT NULL,
  `Role` varchar(20) NOT NULL,
  `Username` varchar(250) NOT NULL,
  `Name` varchar(200) NOT NULL,
  `Phone_number` varchar(200) NOT NULL,
  `Age` int(3) NOT NULL,
  `Password` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `registered`
--

INSERT INTO `registered` (`ID`, `Address`, `Role`, `Username`, `Name`, `Phone_number`, `Age`, `Password`) VALUES
(1, 'Philippines', 'Admin', 'Admin', 'Admin', '12345678', 20, '123'),
(107, 'Manila ', 'Customer', 'customer1', 'customer1', '123456567', 19, '123'),
(108, 'Pasay', 'Customer', 'customer2', 'customer2', '123456567', 56, '123'),
(109, 'Laguna', 'Customer', 'customer3', 'customer3', '4346567', 43, '123'),
(110, 'Laguna', 'Seller', 'seller1', 'seller1', '4346512', 20, '456'),
(111, 'Laguna', 'Seller', 'seller2', 'seller2', '232134', 34, '4567'),
(112, 'Laguna', 'Seller', 'seller3', 'seller3', '9784583', 34, '456'),
(113, 'SFC', 'Seller', 'seller4', 'seller4', '97845283', 28, '456');

-- --------------------------------------------------------

--
-- Table structure for table `sellers`
--

CREATE TABLE `sellers` (
  `ID` int(11) NOT NULL,
  `Type` varchar(250) NOT NULL,
  `Address` varchar(250) NOT NULL,
  `Username` varchar(250) NOT NULL,
  `Name` varchar(250) NOT NULL,
  `Phone_number` varchar(250) NOT NULL,
  `Age` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `sellers`
--

INSERT INTO `sellers` (`ID`, `Type`, `Address`, `Username`, `Name`, `Phone_number`, `Age`, `Password`) VALUES
(30, 'Fish', 'Laguna', 'seller1', 'seller1', '4346512', '20', '456'),
(31, 'Fruit', 'Laguna', 'seller2', 'seller2', '232134', '34', '4567'),
(32, 'Meat', 'Laguna', 'seller3', 'seller3', '9784583', '34', '456'),
(33, 'Vegetable', 'SFC', 'seller4', 'seller4', '97845283', '28', '456');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bought`
--
ALTER TABLE `bought`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `logged`
--
ALTER TABLE `logged`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `order`
--
ALTER TABLE `order`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `registered`
--
ALTER TABLE `registered`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `sellers`
--
ALTER TABLE `sellers`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bought`
--
ALTER TABLE `bought`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=70;

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=68;

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `logged`
--
ALTER TABLE `logged`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=106;

--
-- AUTO_INCREMENT for table `order`
--
ALTER TABLE `order`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=56;

--
-- AUTO_INCREMENT for table `registered`
--
ALTER TABLE `registered`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=114;

--
-- AUTO_INCREMENT for table `sellers`
--
ALTER TABLE `sellers`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
