CREATE DATABASE  IF NOT EXISTS `deti` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `deti`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: deti
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
-- Table structure for table `discipline`
--

DROP TABLE IF EXISTS `discipline`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `discipline` (
  `Kod_Discipline` int NOT NULL AUTO_INCREMENT,
  `Name_dist` varchar(100) DEFAULT NULL,
  `Number_of_hours_per_week` int DEFAULT NULL,
  PRIMARY KEY (`Kod_Discipline`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `discipline`
--

LOCK TABLES `discipline` WRITE;
/*!40000 ALTER TABLE `discipline` DISABLE KEYS */;
INSERT INTO `discipline` VALUES (1,'Социально-коммуникативное развитие',2),(2,'Познавательное развитие',2),(3,'Речевое развитие',1),(4,'Художественно-эстетическое развитие',4),(5,'Физическое развитие',5),(7,'Дисциплина',5);
/*!40000 ALTER TABLE `discipline` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `group_kid`
--

DROP TABLE IF EXISTS `group_kid`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `group_kid` (
  `Kod_Group` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Kod_typegroup` int DEFAULT NULL,
  `Nomber_office` int DEFAULT NULL,
  PRIMARY KEY (`Kod_Group`),
  KEY `typegroup_idx` (`Kod_typegroup`),
  CONSTRAINT `typegrop` FOREIGN KEY (`Kod_typegroup`) REFERENCES `types_of_group` (`Kod_typegroup`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `group_kid`
--

LOCK TABLES `group_kid` WRITE;
/*!40000 ALTER TABLE `group_kid` DISABLE KEYS */;
INSERT INTO `group_kid` VALUES (1,'Солнышко',2,120),(2,'Радуга',4,100),(3,'Пчела',1,105),(4,'Утки',5,99),(5,'Утконосы',1,123),(6,'Лучики',3,121),(7,'Луна',6,101);
/*!40000 ALTER TABLE `group_kid` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `health_group`
--

DROP TABLE IF EXISTS `health_group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `health_group` (
  `Kod_health_group` int NOT NULL AUTO_INCREMENT,
  `Group` int DEFAULT NULL,
  PRIMARY KEY (`Kod_health_group`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `health_group`
--

LOCK TABLES `health_group` WRITE;
/*!40000 ALTER TABLE `health_group` DISABLE KEYS */;
INSERT INTO `health_group` VALUES (1,1),(2,2),(3,3),(4,4),(5,5);
/*!40000 ALTER TABLE `health_group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kid`
--

DROP TABLE IF EXISTS `kid`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kid` (
  `Birth_certificate_nomber` varchar(15) NOT NULL,
  `Surname` varchar(45) DEFAULT NULL,
  `Name` varchar(45) DEFAULT NULL,
  `Patronymic` varchar(45) DEFAULT NULL,
  `Place_of_residence` varchar(100) DEFAULT NULL,
  `Kod_p` varchar(10) DEFAULT NULL,
  `Kod_Group` int DEFAULT NULL,
  `Date_of_birth` date DEFAULT NULL,
  PRIMARY KEY (`Birth_certificate_nomber`),
  KEY `group_idx` (`Kod_Group`),
  KEY `parents_idx` (`Kod_p`),
  CONSTRAINT `group` FOREIGN KEY (`Kod_Group`) REFERENCES `group_kid` (`Kod_Group`),
  CONSTRAINT `parents` FOREIGN KEY (`Kod_p`) REFERENCES `parents` (`Kod_p`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kid`
--

LOCK TABLES `kid` WRITE;
/*!40000 ALTER TABLE `kid` DISABLE KEYS */;
INSERT INTO `kid` VALUES ('111233','Лисицын','Вениамин','Григорьевич','Россия, г. Электросталь, Новая ул., д. 20 кв.81','4228755190',3,'2022-01-11'),('121212','Кольцева','Пелагея','Тарасовна','Россия, г. Железногорск, Школьный пер., д. 1 кв.135','6782349584',3,'2021-05-02'),('123122','Яицкина','Рада','Николаевна','Россия, г. Домодедово, Железнодорожная ул., д. 20 кв.22','4391379471',2,'2019-05-02'),('123123','Кулактин','Даниил','Арсеньевич','Россия, г. Волжский, Гагарина ул., д. 9 кв.152','2314572489',5,'2021-05-03'),('123231','Лисицына','Жанна','Георгьевна','Россия, г. Иваново, Юбилейная ул., д. 13 кв.183','4228755190',1,'2020-05-12'),('212334','Бранта','Марина','Степановна','Россия, г. Октябрьский, Солнечная ул., д. 4 кв.188','1100666784',3,'2021-02-10'),('234333','Кабаев','Федор','Ипполитович','Россия, г. Липецк, Октябрьская ул., д. 20 кв.18','5342456767',3,'2022-11-21'),('270934','Гурова','Милана','Тюрина','Россия, г. Орёл, Солнечная ул., д. 11 кв.88','2009631123',6,'2020-10-12'),('280364','Олейников','Игнатий','Филиппович','Россия, г. Вологда, Майская ул., д. 5 кв.31','9921029383',7,'2016-10-08'),('345634','Кулактина','Анфиса','Лукьяновна','Россия, г. Королёв, Первомайский пер., д. 11 кв.39','2314572489',3,'2021-09-20'),('809732','Спиридонова','Анжела','Павловна','Россия, г. Смоленск, Дружбы ул., д. 8 кв.97','8349056128',4,'2018-12-20'),('899990','Зуев','Артем','Арсеньевич','Россия, г. Ковров, Речная ул., д. 15 кв.86','1211231231',3,'2021-11-20');
/*!40000 ALTER TABLE `kid` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lessons`
--

DROP TABLE IF EXISTS `lessons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lessons` (
  `Kod_Lessons` int NOT NULL AUTO_INCREMENT,
  `Kod_Group` int DEFAULT NULL,
  `Kod_staff` int DEFAULT NULL,
  `Kod_Discipline` int DEFAULT NULL,
  `Date_lesson` date DEFAULT NULL,
  `Hlong_hour` int DEFAULT NULL,
  PRIMARY KEY (`Kod_Lessons`),
  KEY `gr_idx` (`Kod_Group`),
  KEY `staff_idx` (`Kod_staff`),
  KEY `ds_idx` (`Kod_Discipline`),
  CONSTRAINT `ds` FOREIGN KEY (`Kod_Discipline`) REFERENCES `discipline` (`Kod_Discipline`),
  CONSTRAINT `gr` FOREIGN KEY (`Kod_Group`) REFERENCES `group_kid` (`Kod_Group`),
  CONSTRAINT `staff` FOREIGN KEY (`Kod_staff`) REFERENCES `staff` (`Kod_staff`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lessons`
--

LOCK TABLES `lessons` WRITE;
/*!40000 ALTER TABLE `lessons` DISABLE KEYS */;
INSERT INTO `lessons` VALUES (1,5,2,1,'2024-02-20',1),(8,2,3,5,'2024-04-28',2),(17,1,4,2,'2024-04-26',1),(19,4,1,3,'2024-05-11',1),(20,3,4,4,'2024-05-09',2),(21,6,2,7,'2024-05-08',2),(22,7,1,1,'2024-05-12',2);
/*!40000 ALTER TABLE `lessons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medical_card`
--

DROP TABLE IF EXISTS `medical_card`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `medical_card` (
  `Kod_medical_card` int NOT NULL AUTO_INCREMENT,
  `Birth_certificate_nomber` varchar(15) DEFAULT NULL,
  `Height` int DEFAULT NULL,
  `Weight` int DEFAULT NULL,
  `Kod_health_group` int DEFAULT NULL,
  `Chronic_diseases` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Kod_medical_card`),
  KEY `certificate_nomber_idx` (`Birth_certificate_nomber`),
  KEY `heargroup_idx` (`Kod_health_group`),
  CONSTRAINT `certificate_nomber` FOREIGN KEY (`Birth_certificate_nomber`) REFERENCES `kid` (`Birth_certificate_nomber`),
  CONSTRAINT `heargroup` FOREIGN KEY (`Kod_health_group`) REFERENCES `health_group` (`Kod_health_group`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medical_card`
--

LOCK TABLES `medical_card` WRITE;
/*!40000 ALTER TABLE `medical_card` DISABLE KEYS */;
INSERT INTO `medical_card` VALUES (2,'809732',78,10,1,'нету'),(7,'121212',50,25,3,'гипертония'),(8,'280364',40,23,3,'Диабет 1 типа'),(9,'123123',40,20,2,'нет'),(10,'123122',60,21,1,'нет'),(11,'270934',70,26,3,'Астма '),(12,'123231',41,27,3,'Атопический дерматит'),(13,'111233',45,10,3,'Диабет 1 типа'),(14,'345634',50,20,2,'нет'),(15,'212334',40,30,3,'Хроническая болезнь почек'),(16,'234333',50,24,3,'Атопический дерматит'),(17,'899990',50,40,3,'Ожирение');
/*!40000 ALTER TABLE `medical_card` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `parents`
--

DROP TABLE IF EXISTS `parents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `parents` (
  `Kod_p` varchar(10) NOT NULL,
  `Surname_mom` varchar(45) DEFAULT NULL,
  `Name_mom` varchar(45) DEFAULT NULL,
  `Patronymic_mom` varchar(45) DEFAULT NULL,
  `Surname_dad` varchar(45) DEFAULT NULL,
  `Name_dad` varchar(45) DEFAULT NULL,
  `Patronymic_dad` varchar(45) DEFAULT NULL,
  `Telephone_mom` varchar(20) DEFAULT NULL,
  `Telephone_dad` varchar(20) DEFAULT NULL,
  `Place_of_work_mom` varchar(100) DEFAULT NULL,
  `Place_of_work_dad` varchar(100) DEFAULT NULL,
  `Number_of_parents` int DEFAULT NULL,
  PRIMARY KEY (`Kod_p`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parents`
--

LOCK TABLES `parents` WRITE;
/*!40000 ALTER TABLE `parents` DISABLE KEYS */;
INSERT INTO `parents` VALUES ('1100666784','Бранта','Марьяна','Саввановна',NULL,NULL,NULL,'8(953)8028153',NULL,'Россия, г. Химки, Зеленая ул., д. 22 кв.100',NULL,1),('1211231231','Зуева','Ольга','Кирилловна',NULL,NULL,NULL,'8(907)5064027',NULL,'Россия, г. Ростов-на-Дону, Совхозная ул., д. 21 кв.43',NULL,1),('2009631123',NULL,NULL,NULL,'Гуров','Филипп','Макарович',NULL,'8(984)3783284','','Россия, г. Новочебоксарск, Минская ул., д. 11 кв.20',1),('2314572489','Кулактина','Мила','Федоровна','','','','8(950)3058694','8(912)3975881','Россия, г. Пушкино, Мирная ул., д. 11 кв.132','нет',1),('4228755190','Лисицына','Вера','Ефимовна','Лисицын','Егор','Валентинович','8(969)6784219','8(947)8569566','Россия, г. Владивосток, Рабочая ул., д. 14 кв.5','Россия, г. Кемерово, Юбилейная ул., д. 13 кв.170',2),('4391379471','','','','Яицкий','Даниил','Егорович','','8(920)4995698','','Россия, г. Смоленск, Цветочная ул., д. 7 кв.210',1),('5342456767','Кабаева','Полина','Венедиктовна','Кабаев','Вениамин','Георгиевич','8(934)8394830','8(995)6042077','Россия, г. Иваново, Коммунистическая ул., д. 5 кв.186','Россия, г. Находка, Пушкина ул., д. 4 кв.50',2),('6782349584','Кольцева','Настасья','Нифонтовна','Кольцев','Петр','Константинович','8(961)3086051','8(906)7608523','Россия, г. Тамбов, Социалистическая ул., д. 18 кв.161','Россия, г. Волжский, Песчаная ул., д. 19 кв.148',2),('8349056128','Спиридонова','Оксана','Артемова','Спиридонов','Герасим','Иннокентиевич','8(907)8301686','8(987)7491658','Россия, г. Северск, Железнодорожная ул., д. 24 кв.26','Россия, г. Люберцы, Дружбы ул., д. 19 кв.143',2),('9921029383','Олейникова','Арина','Гермоновна','Олейников','Трофим','Ильич','8(920)2044362','8(906)2453578','Россия, г. Невинномысск, Колхозная ул., д. 4 кв.107','нет',1);
/*!40000 ALTER TABLE `parents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `post`
--

DROP TABLE IF EXISTS `post`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `post` (
  `Kod_post` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Kod_post`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `post`
--

LOCK TABLES `post` WRITE;
/*!40000 ALTER TABLE `post` DISABLE KEYS */;
INSERT INTO `post` VALUES (1,'Воспитатель'),(2,'Психолог'),(3,'Логопед'),(4,'Заведующая'),(5,'Медсестра');
/*!40000 ALTER TABLE `post` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staff`
--

DROP TABLE IF EXISTS `staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `staff` (
  `Kod_staff` int NOT NULL AUTO_INCREMENT,
  `FIO` varchar(45) DEFAULT NULL,
  `Telephone` varchar(20) DEFAULT NULL,
  `Kod_post` int DEFAULT NULL,
  `Login` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Kod_staff`),
  KEY `post_idx` (`Kod_post`),
  CONSTRAINT `post` FOREIGN KEY (`Kod_post`) REFERENCES `post` (`Kod_post`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` VALUES (1,'Самойлов Л.Л.','8(909)4498757',1,'staff1','ccfb0d5392de3381728c7fffd8857fde'),(2,'Забродина К.С.','8(989)8848428',4,'admin','c4ca4238a0b923820dcc509a6f75849b'),(3,'Данилова А.А.','8(914)3129476',2,'log2','c4ca4238a0b923820dcc509a6f75849b'),(4,'Салагина В.Е.','8(961)5117166',3,'sdas','c4ca4238a0b923820dcc509a6f75849b'),(5,'Цельнера М. К.','8(823)7483742',5,'lll','c4ca4238a0b923820dcc509a6f75849b'),(6,'Хватов С.К.','8(929)6578119',5,'med','c4ca4238a0b923820dcc509a6f75849b');
/*!40000 ALTER TABLE `staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `types_of_group`
--

DROP TABLE IF EXISTS `types_of_group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `types_of_group` (
  `Kod_typegroup` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Age_from` int DEFAULT NULL,
  `Age_up_to` int DEFAULT NULL,
  `Count_kid` int DEFAULT NULL,
  PRIMARY KEY (`Kod_typegroup`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `types_of_group`
--

LOCK TABLES `types_of_group` WRITE;
/*!40000 ALTER TABLE `types_of_group` DISABLE KEYS */;
INSERT INTO `types_of_group` VALUES (1,'Ясельная группа',1,2,15),(2,'1-ая младшая группа',2,3,20),(3,'2-ая младшая группа',3,4,20),(4,'Средняя группа',4,5,20),(5,'Старшая группа',5,6,20),(6,'Подготовительная группа',6,7,20);
/*!40000 ALTER TABLE `types_of_group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vaccination_data`
--

DROP TABLE IF EXISTS `vaccination_data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vaccination_data` (
  `Kod_vaccination_data` int NOT NULL AUTO_INCREMENT,
  `Kod_vaccination` int DEFAULT NULL,
  `Date_of_vaccination` date DEFAULT NULL,
  `Birth_certificate_nomber` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`Kod_vaccination_data`),
  KEY `kid_idx` (`Birth_certificate_nomber`),
  KEY `vac_idx` (`Kod_vaccination`),
  CONSTRAINT `kid` FOREIGN KEY (`Birth_certificate_nomber`) REFERENCES `kid` (`Birth_certificate_nomber`),
  CONSTRAINT `vac` FOREIGN KEY (`Kod_vaccination`) REFERENCES `vaccinations` (`Kod_vaccination`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vaccination_data`
--

LOCK TABLES `vaccination_data` WRITE;
/*!40000 ALTER TABLE `vaccination_data` DISABLE KEYS */;
INSERT INTO `vaccination_data` VALUES (1,1,'2016-11-20','280364'),(2,2,'2020-05-20','809732'),(3,3,'2022-04-27','280364'),(4,4,'2022-04-20','123123'),(5,5,'2022-04-20','270934'),(6,2,'2023-08-20','809732'),(7,3,'2021-03-20','121212'),(8,6,'2020-06-20','123122');
/*!40000 ALTER TABLE `vaccination_data` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vaccinations`
--

DROP TABLE IF EXISTS `vaccinations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vaccinations` (
  `Kod_vaccination` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Kod_vaccination`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vaccinations`
--

LOCK TABLES `vaccinations` WRITE;
/*!40000 ALTER TABLE `vaccinations` DISABLE KEYS */;
INSERT INTO `vaccinations` VALUES (1,'Вакцинация против вирусного гепатита В'),(2,'Вакцинация БЦЖ'),(3,'Вакцинация против дифтерии,коклюша, столбняка,полиомелита'),(4,'Вакцинация против кори, краснухи, эпидемического паротита'),(5,'Вакцинация против туберкулеза'),(6,'Вакцинация против полиомиелита');
/*!40000 ALTER TABLE `vaccinations` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-03 14:49:51
