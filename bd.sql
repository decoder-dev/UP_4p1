-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: 123
-- ------------------------------------------------------
-- Server version	8.3.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `connectiontypes`
--

DROP TABLE IF EXISTS `connectiontypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `connectiontypes` (
  `ConnectionTypeID` int NOT NULL AUTO_INCREMENT,
  `ConnectionType` varchar(45) NOT NULL,
  PRIMARY KEY (`ConnectionTypeID`),
  UNIQUE KEY `ConnectionType` (`ConnectionType`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `connectiontypes`
--

LOCK TABLES `connectiontypes` WRITE;
/*!40000 ALTER TABLE `connectiontypes` DISABLE KEYS */;
INSERT INTO `connectiontypes` VALUES (1,'Ethernet'),(4,'Fiber Optic'),(3,'Serial'),(2,'Wi-Fi');
/*!40000 ALTER TABLE `connectiontypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `devices`
--

DROP TABLE IF EXISTS `devices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `devices` (
  `DeviceID` int NOT NULL AUTO_INCREMENT,
  `DeviceTypeID` int NOT NULL,
  `ManufacturerID` int NOT NULL,
  `LocationID` int NOT NULL,
  `ConnectionTypeID` int NOT NULL,
  `SegmentID` int NOT NULL,
  `IPAddressID` int NOT NULL,
  `UserID` int DEFAULT NULL,
  `SubnetMask` varchar(15) DEFAULT NULL,
  `Gateway` varchar(15) DEFAULT NULL,
  `OS` varchar(45) DEFAULT NULL,
  `Model` varchar(45) DEFAULT NULL,
  `SerialNumber` varchar(255) DEFAULT NULL,
  `Role` varchar(45) DEFAULT NULL,
  `CreatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `ModifiedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`DeviceID`),
  UNIQUE KEY `SerialNumber` (`SerialNumber`),
  KEY `DeviceTypeID` (`DeviceTypeID`),
  KEY `ManufacturerID` (`ManufacturerID`),
  KEY `LocationID` (`LocationID`),
  KEY `ConnectionTypeID` (`ConnectionTypeID`),
  KEY `SegmentID` (`SegmentID`),
  KEY `IPAddressID` (`IPAddressID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `devices_ibfk_1` FOREIGN KEY (`DeviceTypeID`) REFERENCES `devicetypes` (`DeviceTypeID`),
  CONSTRAINT `devices_ibfk_2` FOREIGN KEY (`ManufacturerID`) REFERENCES `manufacturers` (`ManufacturerID`),
  CONSTRAINT `devices_ibfk_3` FOREIGN KEY (`LocationID`) REFERENCES `locations` (`LocationID`),
  CONSTRAINT `devices_ibfk_4` FOREIGN KEY (`ConnectionTypeID`) REFERENCES `connectiontypes` (`ConnectionTypeID`),
  CONSTRAINT `devices_ibfk_5` FOREIGN KEY (`SegmentID`) REFERENCES `segments` (`SegmentID`),
  CONSTRAINT `devices_ibfk_6` FOREIGN KEY (`IPAddressID`) REFERENCES `ipaddresses` (`IPAddressID`),
  CONSTRAINT `devices_ibfk_7` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `devices`
--

LOCK TABLES `devices` WRITE;
/*!40000 ALTER TABLE `devices` DISABLE KEYS */;
INSERT INTO `devices` VALUES (1,1,1,1,1,1,1,1,'255.255.255.0','192.168.1.1','Cisco IOS','Cisco 3850','ABC123','Router','2024-10-31 15:01:35','2024-10-31 15:01:35'),(2,2,2,2,2,2,2,2,'255.255.255.0','192.168.1.2','HP ProCurve','HP 2920','DEF456','Switch','2024-10-31 15:01:35','2024-10-31 15:01:35'),(3,3,3,3,3,3,3,3,'255.255.255.0','192.168.1.3','Dell PowerEdge','Dell R720','GHI789','Server','2024-10-31 15:01:35','2024-10-31 15:01:35'),(4,4,4,4,4,4,4,4,'255.255.255.0','192.168.1.4','Juniper SRX','Juniper SRX300','JKL012','Firewall','2024-10-31 15:01:35','2024-10-31 15:01:35'),(5,5,5,1,1,1,1,1,'255.255.255.0','192.168.1.1','Microsoft Windows','Microsoft Surface','MNO345','Workstation','2024-10-31 15:01:35','2024-10-31 15:01:35');
/*!40000 ALTER TABLE `devices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `devicetypes`
--

DROP TABLE IF EXISTS `devicetypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `devicetypes` (
  `DeviceTypeID` int NOT NULL AUTO_INCREMENT,
  `DeviceType` varchar(45) NOT NULL,
  PRIMARY KEY (`DeviceTypeID`),
  UNIQUE KEY `DeviceType` (`DeviceType`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `devicetypes`
--

LOCK TABLES `devicetypes` WRITE;
/*!40000 ALTER TABLE `devicetypes` DISABLE KEYS */;
INSERT INTO `devicetypes` VALUES (3,'Firewall'),(1,'Router'),(4,'Server'),(2,'Switch'),(5,'Workstation');
/*!40000 ALTER TABLE `devicetypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ipaddresses`
--

DROP TABLE IF EXISTS `ipaddresses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ipaddresses` (
  `IPAddressID` int NOT NULL AUTO_INCREMENT,
  `IPAddress` varchar(15) NOT NULL,
  PRIMARY KEY (`IPAddressID`),
  UNIQUE KEY `IPAddress` (`IPAddress`),
  CONSTRAINT `ipaddresses_chk_1` CHECK (regexp_like(`IPAddress`,_utf8mb4'^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$'))
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ipaddresses`
--

LOCK TABLES `ipaddresses` WRITE;
/*!40000 ALTER TABLE `ipaddresses` DISABLE KEYS */;
INSERT INTO `ipaddresses` VALUES (1,'192.168.1.1'),(2,'192.168.1.2'),(3,'192.168.1.3'),(4,'192.168.1.4');
/*!40000 ALTER TABLE `ipaddresses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `locations`
--

DROP TABLE IF EXISTS `locations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `locations` (
  `LocationID` int NOT NULL AUTO_INCREMENT,
  `LocationName` varchar(45) NOT NULL,
  PRIMARY KEY (`LocationID`),
  UNIQUE KEY `LocationName` (`LocationName`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `locations`
--

LOCK TABLES `locations` WRITE;
/*!40000 ALTER TABLE `locations` DISABLE KEYS */;
INSERT INTO `locations` VALUES (2,'Branch Office'),(3,'Data Center'),(1,'Headquarters'),(4,'Remote Site');
/*!40000 ALTER TABLE `locations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `manufacturers`
--

DROP TABLE IF EXISTS `manufacturers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `manufacturers` (
  `ManufacturerID` int NOT NULL AUTO_INCREMENT,
  `ManufacturerName` varchar(45) NOT NULL,
  PRIMARY KEY (`ManufacturerID`),
  UNIQUE KEY `ManufacturerName` (`ManufacturerName`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manufacturers`
--

LOCK TABLES `manufacturers` WRITE;
/*!40000 ALTER TABLE `manufacturers` DISABLE KEYS */;
INSERT INTO `manufacturers` VALUES (1,'Cisco'),(3,'Dell'),(2,'HP'),(4,'Juniper'),(5,'Microsoft');
/*!40000 ALTER TABLE `manufacturers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permissions`
--

DROP TABLE IF EXISTS `permissions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `permissions` (
  `PermissionID` int NOT NULL AUTO_INCREMENT,
  `PermissionName` varchar(45) NOT NULL,
  PRIMARY KEY (`PermissionID`),
  UNIQUE KEY `PermissionName` (`PermissionName`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permissions`
--

LOCK TABLES `permissions` WRITE;
/*!40000 ALTER TABLE `permissions` DISABLE KEYS */;
INSERT INTO `permissions` VALUES (1,'Create Device'),(4,'Delete Device'),(2,'Read Device'),(3,'Update Device');
/*!40000 ALTER TABLE `permissions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rolepermissions`
--

DROP TABLE IF EXISTS `rolepermissions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rolepermissions` (
  `RolePermissionID` int NOT NULL AUTO_INCREMENT,
  `RoleID` int NOT NULL,
  `PermissionID` int NOT NULL,
  PRIMARY KEY (`RolePermissionID`),
  UNIQUE KEY `RoleID` (`RoleID`,`PermissionID`),
  KEY `PermissionID` (`PermissionID`),
  CONSTRAINT `rolepermissions_ibfk_1` FOREIGN KEY (`RoleID`) REFERENCES `roles` (`RoleID`),
  CONSTRAINT `rolepermissions_ibfk_2` FOREIGN KEY (`PermissionID`) REFERENCES `permissions` (`PermissionID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rolepermissions`
--

LOCK TABLES `rolepermissions` WRITE;
/*!40000 ALTER TABLE `rolepermissions` DISABLE KEYS */;
INSERT INTO `rolepermissions` VALUES (1,1,1),(2,1,2),(3,1,3),(4,1,4),(5,2,2),(6,2,3),(7,3,2);
/*!40000 ALTER TABLE `rolepermissions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `RoleID` int NOT NULL AUTO_INCREMENT,
  `RoleName` varchar(45) NOT NULL,
  PRIMARY KEY (`RoleID`),
  UNIQUE KEY `RoleName` (`RoleName`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Admin'),(2,'User '),(3,'Viewer');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `segments`
--

DROP TABLE IF EXISTS `segments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `segments` (
  `SegmentID` int NOT NULL AUTO_INCREMENT,
  `SegmentName` varchar(45) NOT NULL,
  PRIMARY KEY (`SegmentID`),
  UNIQUE KEY `SegmentName` (`SegmentName`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `segments`
--

LOCK TABLES `segments` WRITE;
/*!40000 ALTER TABLE `segments` DISABLE KEYS */;
INSERT INTO `segments` VALUES (3,'Development'),(1,'Management'),(2,'Production'),(4,'Testing');
/*!40000 ALTER TABLE `segments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `Email` varchar(45) NOT NULL,
  `PasswordHash` varchar(255) NOT NULL,
  `RoleID` int NOT NULL,
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `Email` (`Email`),
  KEY `RoleID` (`RoleID`),
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`RoleID`) REFERENCES `roles` (`RoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'John','Doe','john.doe@example.com','password123',1),(2,'Jane','Doe','jane.doe@example.com','password123',2),(3,'Bob','Smith','bob.smith@example.com','password123',3);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-02  2:47:20
