CREATE DATABASE  IF NOT EXISTS `promoit` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `promoit`;
-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: promoit
-- ------------------------------------------------------
-- Server version	8.0.27

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
-- Table structure for table `campaigns`
--

DROP TABLE IF EXISTS `campaigns`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `campaigns` (
  `name` varchar(45) NOT NULL,
  `hashtag` varchar(45) NOT NULL,
  `webpage` varchar(45) NOT NULL,
  `non_profit_user_name` varchar(45) NOT NULL,
  PRIMARY KEY (`hashtag`),
  KEY `hjk` (`hashtag`),
  KEY `bjmgh_idx` (`non_profit_user_name`),
  CONSTRAINT `bjmgh` FOREIGN KEY (`non_profit_user_name`) REFERENCES `users` (`user_name`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `campaigns`
--

LOCK TABLES `campaigns` WRITE;
/*!40000 ALTER TABLE `campaigns` DISABLE KEYS */;
INSERT INTO `campaigns` VALUES ('Sdot Yam Big Revolution','ClaenSdotYam','sdot-yam.co.il/campaign','Alma'),('For A Better Summer','CleanSummer','sea-clean-campaign.co.il','seaAdmin'),('No More Dogs Trades','DogAdopt1','dog-adopt.co.il/adoption','DogLover'),('Golden Lion Tamarin Monkey','GoldMonkey1','greentumble.com/golden-monkey-campaign','GreenINC'),('nisayonCampaign','nisayon','walla.co.il','n'),('No More Dodos','NMD','nomoredodos.org','NWF'),('The Ocean Is Ours!','OceanClean','ocean-clean.com/campaign','seaAdmin'),('Preserve Marine Animals','PMA','pma-green.co.il/about','seaAdmin'),('Protecting The Earth’s Lungs','ProtectEarthNow','greentumble.com/rainforest-deforestation','NWF'),('Rainforest Deforestation','SaveRainForest','rainforestsave.com','GreenINC'),('Alma Makes Tel-Aviv Green','TLVGreen','alma-green.co.il/tel-aviv-campaign','Alma');
/*!40000 ALTER TABLE `campaigns` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products_donated`
--

DROP TABLE IF EXISTS `products_donated`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products_donated` (
  `id2` int NOT NULL AUTO_INCREMENT,
  `product_in_campaign_id` int NOT NULL,
  `activist_user_name` varchar(45) NOT NULL,
  `quantity` int NOT NULL DEFAULT '0',
  `shipped` varchar(45) NOT NULL DEFAULT 'not_shipped',
  PRIMARY KEY (`id2`),
  KEY `m_idx` (`product_in_campaign_id`),
  KEY `dfgd` (`quantity`),
  KEY `gfhfg_idx` (`shipped`),
  KEY `hj_idx` (`activist_user_name`),
  CONSTRAINT `gfhfg` FOREIGN KEY (`shipped`) REFERENCES `z_shipped_status` (`shipped`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `hj` FOREIGN KEY (`activist_user_name`) REFERENCES `users` (`user_name`) ON UPDATE CASCADE,
  CONSTRAINT `m` FOREIGN KEY (`product_in_campaign_id`) REFERENCES `products_in_campaign` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=112 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products_donated`
--

LOCK TABLES `products_donated` WRITE;
/*!40000 ALTER TABLE `products_donated` DISABLE KEYS */;
INSERT INTO `products_donated` VALUES (70,25,'a',1,'not_shipped'),(71,25,'a',1,'not_shipped'),(86,29,'a',1,'not_shipped'),(87,29,'a',1,'not_shipped'),(88,29,'a',1,'not_shipped'),(89,31,'a',1,'not_shipped'),(90,115,'a',1,'not_shipped'),(91,26,'a',1,'not_shipped'),(109,26,'a',1,'not_shipped'),(110,26,'a',1,'not_shipped'),(111,26,'a',1,'not_shipped');
/*!40000 ALTER TABLE `products_donated` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products_in_campaign`
--

DROP TABLE IF EXISTS `products_in_campaign`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products_in_campaign` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `quantity` int NOT NULL DEFAULT '0',
  `price` decimal(10,2) NOT NULL DEFAULT '0.00',
  `business_user_name` varchar(45) NOT NULL,
  `campaign_hashtag` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `hgfhj` (`price`) /*!80000 INVISIBLE */,
  KEY `fghfgh` (`quantity`),
  KEY `fghfghf` (`name`),
  KEY `ht_idx` (`campaign_hashtag`),
  KEY `dg_idx` (`business_user_name`),
  CONSTRAINT `dg` FOREIGN KEY (`business_user_name`) REFERENCES `users` (`user_name`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `ht` FOREIGN KEY (`campaign_hashtag`) REFERENCES `campaigns` (`hashtag`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=168 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products_in_campaign`
--

LOCK TABLES `products_in_campaign` WRITE;
/*!40000 ALTER TABLE `products_in_campaign` DISABLE KEYS */;
INSERT INTO `products_in_campaign` VALUES (25,'Product a',198,20.00,'b','nisayon'),(26,'Ice Generation Unisex Analog Watch',23,85.00,'Pets-IL','ClaenSdotYam'),(27,'Ice Generation Unisex Analog Watch Green',25,85.00,'Pets-IL','ProtectEarthNow'),(28,'SWOO Smartwatch Fitness Watch - Black',49,130.00,'Pets-IL','ClaenSdotYam'),(29,'Smartwatch Fitness Tracker Watch - Blue',20,130.00,'Pets-IL','CleanSummer'),(30,'DriftFish Floating Neoprene Boat Keychain Key',15,10.00,'Pets-IL','ClaenSdotYam'),(31,'DriftFish Floating Neoprene Boat Keychain',19,10.00,'Pets-IL','CleanSummer'),(32,'Honbay Rhinestone Keychain Bumble Bee',30,25.00,'Pets-IL','ClaenSdotYam'),(33,'Honbay Keychain Bumble Bee',15,30.00,'Pets-IL','CleanSummer'),(34,'Portable Retro Video Game Console',10,250.00,'Pets-IL','TLVGreen'),(35,'Colored Pencil Set - 24 PC',40,55.00,'Pets-IL','OceanClean'),(36,'Bearington Swings Soft Plush Monkey',100,45.00,'Pets-IL','GoldMonkey1'),(37,'Wild Republic Squirrel Monkey Plush',20,70.00,'Pets-IL','GoldMonkey1'),(38,'IKASA Large Monkey Stuffed',38,115.00,'Pets-IL','GoldMonkey1'),(39,'Coca-Cola Classic 8oz Glass Bottles',10,25.00,'Coca-Cola','ClaenSdotYam'),(40,'Coca-Cola Classic 8oz Glass Bottles',20,20.00,'Coca-Cola','PMA'),(41,'Coca-Cola Classic 8oz Glass Bottles',45,20.00,'Coca-Cola','TLVGreen'),(42,'Coca-Cola Classic 8oz Glass Bottles',12,20.00,'Coca-Cola','NMD'),(43,'Yepzoer Coca Cola Metal Tin Sign',15,35.00,'Coca-Cola','DogAdopt1'),(44,'Yepzoer Coca Cola Metal Tin Sign',10,35.00,'Coca-Cola','OceanClean'),(45,'Yepzoer Coca Cola Metal Tin Sign',70,35.00,'Coca-Cola','SaveRainForest'),(46,'The Tin Box Coca-Cola',28,80.00,'Coca-Cola','ProtectEarthNow'),(48,'Funko Pop! AD Icons: Coca-Cola - Polar Bear',20,100.00,'Coca-Cola','CleanSummer'),(49,'Funko Pop! AD Icons: Coca-Cola - Polar Bear',10,100.00,'Coca-Cola','TLVGreen'),(50,'Funko Pop! AD Icons: Coca-Cola - Polar Bear',50,100.00,'Coca-Cola','NMD'),(51,'Funko Pop! AD Icons: Coca-Cola - Polar Bear',20,100.00,'Coca-Cola','CleanSummer'),(52,'Funko Pop! AD Icons: Coca-Cola - Polar Bear',10,100.00,'Coca-Cola','SaveRainForest'),(54,'Coca-Cola 1/43 1962 Volkswagen Cargo Van',30,45.00,'Coca-Cola','PMA'),(55,'Coca-Cola 1/43 1962 Volkswagen Cargo Van',23,45.00,'Coca-Cola','TLVGreen'),(56,'Coca-Cola 1/43 1962 Volkswagen Cargo Van',18,45.00,'Coca-Cola','ProtectEarthNow'),(57,'Coca-Cola 1/43 1962 Volkswagen Cargo Van',39,45.00,'Coca-Cola','ClaenSdotYam'),(58,'Ladies Coca Cola Fashion Shirt',23,15.00,'Coca-Cola','SaveRainForest'),(59,'Ladies Coca Cola Fashion Shirt',40,15.00,'Coca-Cola','GoldMonkey1'),(60,'Ladies Coca Cola Fashion Shirt',23,15.00,'Coca-Cola','PMA'),(62,'Fox Home Gift Card - 200ILS',100,400.00,'Tnuva','GoldMonkey1'),(63,'Fox Home Gift Card - 200ILS',50,400.00,'Tnuva','DogAdopt1'),(64,'Fox Home Gift Card - 200ILS',50,400.00,'Tnuva','TLVGreen'),(65,'Fox Home Gift Card - 200ILS',100,400.00,'Tnuva','NMD'),(66,'Adidas Voucher - 50ILS',34,150.00,'Tnuva','NMD'),(67,'Adidas Voucher - 50ILS',49,150.00,'Tnuva','ClaenSdotYam'),(68,'Adidas Voucher - 50ILS',67,150.00,'Tnuva','ProtectEarthNow'),(69,'Adidas Voucher - 50ILS',130,150.00,'Tnuva','DogAdopt1'),(70,'Disney Mickey Mouse Clubhouse - Smartpad',35,240.00,'Tnuva','OceanClean'),(71,'Disney Mickey Mouse Clubhouse - Smartpad',21,240.00,'Tnuva','SaveRainForest'),(73,'Disney Mickey Mouse Clubhouse - Smartpad',103,240.00,'Tnuva','DogAdopt1'),(74,'NUBWO Gaming headsets N7 Stereo',25,300.00,'K.S.P','PMA'),(75,'NUBWO Gaming headsets N7 Stereo',87,300.00,'K.S.P','TLVGreen'),(76,'NUBWO Gaming headsets N7 Stereo',100,300.00,'K.S.P','DogAdopt1'),(78,'Nintendo Switch (Neon Red/Neon blue)',15,1900.00,'K.S.P','CleanSummer'),(79,'Nintendo Switch (Neon Red/Neon blue)',45,1900.00,'K.S.P','SaveRainForest'),(80,'Nintendo Switch (Neon Red/Neon blue)',87,1900.00,'K.S.P','GoldMonkey1'),(81,'Nintendo Switch (Neon Red/Neon blue)',41,1900.00,'K.S.P','ProtectEarthNow'),(82,'Nintendo Switch (Neon Red/Neon blue)',26,1900.00,'K.S.P','OceanClean'),(83,'Nintendo Switch (Neon Red/Neon blue)',15,1900.00,'K.S.P','PMA'),(84,'Redragon S101 Wired Gaming Keyboard and Mouse',34,800.00,'K.S.P','ClaenSdotYam'),(85,'Redragon S101 Wired Gaming Keyboard and Mouse',34,800.00,'K.S.P','NMD'),(86,'Redragon S101 Wired Gaming Keyboard and Mouse',56,800.00,'K.S.P','TLVGreen'),(88,'Billabong Walled Adjustable Trucker Hat',14,55.00,'FOX','ClaenSdotYam'),(89,'Billabong Walled Adjustable Trucker Hat',34,55.00,'FOX','SaveRainForest'),(90,'Billabong Walled Adjustable Trucker Hat',65,55.00,'FOX','CleanSummer'),(91,'Billabong Walled Adjustable Trucker Hat',31,55.00,'FOX','NMD'),(92,'Billabong Walled Adjustable Trucker Hat',44,55.00,'FOX','ProtectEarthNow'),(93,'Billabong Walled Adjustable Trucker Hat',93,55.00,'FOX','TLVGreen'),(94,'Miniature Sailing Boat Model',100,35.00,'FOX','ClaenSdotYam'),(96,'Miniature Sailing Boat Model',134,35.00,'FOX','PMA'),(97,'Miniature Sailing Boat Model',76,35.00,'FOX','GoldMonkey1'),(98,'Miniature Sailing Boat Model',400,35.00,'FOX','OceanClean'),(99,'Miniature Sailing Boat Model',243,35.00,'FOX','ProtectEarthNow'),(100,'Miniature Sailing Boat Model',67,35.00,'FOX','DogAdopt1'),(101,'ROSTIVO Turtle Necklace',15,450.00,'FOX','ClaenSdotYam'),(102,'ROSTIVO Turtle Necklace',89,450.00,'FOX','CleanSummer'),(103,'ROSTIVO Turtle Necklace',31,450.00,'FOX','DogAdopt1'),(104,'ROSTIVO Turtle Necklace',43,450.00,'FOX','OceanClean'),(105,'ROSTIVO Turtle Necklace',12,450.00,'FOX','ProtectEarthNow'),(106,'ROSTIVO Turtle Necklace',77,450.00,'FOX','TLVGreen'),(107,'ROSTIVO Turtle Necklace',11,450.00,'FOX','SaveRainForest'),(108,'ROSTIVO Turtle Necklace',45,450.00,'FOX','PMA'),(109,'ROSTIVO Turtle Necklace',88,450.00,'FOX','NMD'),(111,'KSMA Sandglass Timer 30 Minute Hourglass',77,100.00,'FOX','GoldMonkey1'),(112,'KSMA Sandglass Timer 30 Minute Hourglass',89,100.00,'FOX','OceanClean'),(113,'Xiaomi Mi Smart Band AMOLED Touch Screen',12,3100.00,'IsraelElectric','CleanSummer'),(114,'Xiaomi Mi Smart Band AMOLED Touch Screen',55,3100.00,'IsraelElectric','DogAdopt1'),(115,'Xiaomi Mi Smart Band AMOLED Touch Screen',41,3100.00,'IsraelElectric','GoldMonkey1'),(116,'Xiaomi Mi Smart Band AMOLED Touch Screen',67,3100.00,'IsraelElectric','NMD'),(117,'Xiaomi Mi Smart Band AMOLED Touch Screen',21,3100.00,'IsraelElectric','ProtectEarthNow'),(118,'Xiaomi Mi Smart Band AMOLED Touch Screen',42,3100.00,'IsraelElectric','SaveRainForest'),(119,'Xiaomi Mi Smart Band AMOLED Touch Screen',18,3100.00,'IsraelElectric','TLVGreen'),(120,'Xiaomi Mi Robot Vacuum',8,4700.00,'IsraelElectric','ClaenSdotYam'),(121,'Xiaomi Mi Robot Vacuum',41,4700.00,'IsraelElectric','OceanClean'),(122,'Xiaomi Mi Robot Vacuum',31,4700.00,'IsraelElectric','PMA'),(124,'Redmi Buds 3 Pro Airdots',41,2400.00,'IsraelElectric','TLVGreen'),(125,'Redmi Buds 3 Pro Airdots',21,2400.00,'IsraelElectric','SaveRainForest'),(126,'Redmi Buds 3 Pro Airdots',48,2400.00,'IsraelElectric','ProtectEarthNow'),(127,'Redmi Buds 3 Pro Airdots',34,2400.00,'IsraelElectric','PMA'),(129,'Redmi Buds 3 Pro Airdots',55,2400.00,'IsraelElectric','NMD'),(130,'Redmi Buds 3 Pro Airdots',11,2400.00,'IsraelElectric','CleanSummer'),(131,'Intelligent BMI Data Analysis Weighing',30,650.00,'IsraelElectric','CleanSummer'),(132,'Intelligent BMI Data Analysis Weighing',33,650.00,'IsraelElectric','DogAdopt1'),(133,'Intelligent BMI Data Analysis Weighing',14,650.00,'IsraelElectric','GoldMonkey1'),(134,'Intelligent BMI Data Analysis Weighing',43,650.00,'IsraelElectric','NMD'),(135,'Intelligent BMI Data Analysis Weighing',8,650.00,'IsraelElectric','PMA'),(136,'Puccy 3 Pack Tempered Glass Screen',13,210.00,'IsraelElectric','DogAdopt1'),(138,'Puccy 3 Pack Tempered Glass Screen',66,210.00,'IsraelElectric','OceanClean'),(139,'Puccy 3 Pack Tempered Glass Screen',62,210.00,'IsraelElectric','ProtectEarthNow'),(140,'Willy and Friends - Matryoshka Dolls',41,180.00,'Green-Shore','CleanSummer'),(141,'Willy and Friends - Matryoshka Dolls',11,180.00,'Green-Shore','GoldMonkey1'),(142,'Willy and Friends - Matryoshka Dolls',33,180.00,'Green-Shore','DogAdopt1'),(143,'Willy and Friends - Matryoshka Dolls',12,180.00,'Green-Shore','SaveRainForest'),(144,'Willy and Friends - Matryoshka Dolls',54,180.00,'Green-Shore','PMA'),(145,'Willy and Friends - Matryoshka Dolls',67,180.00,'Green-Shore','OceanClean'),(146,'Willy and Friends - Matryoshka Dolls',98,180.00,'Green-Shore','NMD'),(147,'Houwsbaby LED Glowing Plush Dolphin Toy',11,390.00,'Green-Shore','DogAdopt1'),(148,'Houwsbaby LED Glowing Plush Dolphin Toy',16,390.00,'Green-Shore','OceanClean'),(149,'Houwsbaby LED Glowing Plush Dolphin Toy',21,390.00,'Green-Shore','TLVGreen'),(150,'Houwsbaby LED Glowing Plush Dolphin Toy',7,390.00,'Green-Shore','ProtectEarthNow'),(151,'Houwsbaby LED Glowing Plush Dolphin Toy',84,390.00,'Green-Shore','SaveRainForest'),(167,'_fhdfgdfg',99,99.00,'b','ClaenSdotYam');
/*!40000 ALTER TABLE `products_in_campaign` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tweets`
--

DROP TABLE IF EXISTS `tweets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tweets` (
  `id` bigint NOT NULL,
  `campaign_hashtag` varchar(45) NOT NULL,
  `activist_user_name` varchar(45) NOT NULL,
  `cash` decimal(10,2) NOT NULL,
  `retweets` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `ghfh_idx` (`activist_user_name`),
  KEY `fg_idx` (`campaign_hashtag`),
  CONSTRAINT `fg` FOREIGN KEY (`campaign_hashtag`) REFERENCES `campaigns` (`hashtag`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `ghfh` FOREIGN KEY (`activist_user_name`) REFERENCES `users` (`user_name`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tweets`
--

LOCK TABLES `tweets` WRITE;
/*!40000 ALTER TABLE `tweets` DISABLE KEYS */;
/*!40000 ALTER TABLE `tweets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_name` varchar(45) NOT NULL,
  `user_password` varchar(45) NOT NULL,
  `user_type` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`user_name`),
  KEY `dsg_idx` (`user_type`),
  CONSTRAINT `dsg` FOREIGN KEY (`user_type`) REFERENCES `z_users_type` (`type`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('a','123','activist','Activist'),('ad','123','admin','ad'),('admin','123','admin','adminName'),('Alma','12345','non-profit','Alma Creates Green'),('ArielHillel','12345','activist','Ariel Hillel'),('b','123','business','businessName'),('Coca-Cola','12345','business','Coca-Cola'),('DogLover','12345','non-profit','Dog Deserve A Chance'),('ERTTER','TER','business','TREESRT'),('FOX','12345','business','Fox Group'),('Green-Shore','12345','business','Green Shore House'),('GreenINC','12345','non-profit','GreenPad'),('IsraelElectric','12345','business','Israel Electric'),('JaronMel','12345','activist','John Benson'),('K.S.P','12345','business','K.S.P'),('legopart','123','activist','LegopartN'),('n','123','non-profit','non-profitName'),('NWF','12345','non-profit','National Wildlife Federation'),('Pets-IL','12345','business','Pets-IL Inc'),('RTYRTY','RTYRT','non-profit','TRYRT'),('seaAdmin','12345','non-profit','Sea Cleaners '),('someUserNameForTest','somePasswordForTest','activist','someNameForTest'),('Tnuva','12345','business','Tnuva International'),('w3arthur','123','activist','Arthur Zarankin'),('yaRon202Ad','12345','activist','Yaron');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users_activists`
--

DROP TABLE IF EXISTS `users_activists`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users_activists` (
  `user_name` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `address` varchar(45) NOT NULL,
  `phone_number` varchar(45) NOT NULL,
  `cash` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`user_name`),
  KEY `index2` (`email`) /*!80000 INVISIBLE */,
  KEY `fghfg` (`address`) /*!80000 INVISIBLE */,
  CONSTRAINT `gfhj` FOREIGN KEY (`user_name`) REFERENCES `users` (`user_name`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users_activists`
--

LOCK TABLES `users_activists` WRITE;
/*!40000 ALTER TABLE `users_activists` DISABLE KEYS */;
INSERT INTO `users_activists` VALUES ('a','activist@gmail.com','simpleActivist','54645645',10000.00),('ArielHillel','arielhillel@gmail.com','Koresh 19/1, Pardes Hanna - Karkur','050-3210094',10000.00),('JaronMel','johnben@gmail.com','Melrose Ave, 455th, California ','054-33221100',10000.00),('legopart','legopart@gmail.com','My Address','08436346',10000.00),('someUserNameForTest','Email@some.com','someAddress','4656456654',10000.00),('w3arthur','w3arthur@gmail.com','home','08954654',10000.00),('yaRon202Ad','yaron@gmail.com','Geula 86/11, Pardes Hanna','054-333494941',10000.00);
/*!40000 ALTER TABLE `users_activists` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users_admins`
--

DROP TABLE IF EXISTS `users_admins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users_admins` (
  `user_name` varchar(45) NOT NULL,
  PRIMARY KEY (`user_name`),
  CONSTRAINT `hjh` FOREIGN KEY (`user_name`) REFERENCES `users` (`user_name`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users_admins`
--

LOCK TABLES `users_admins` WRITE;
/*!40000 ALTER TABLE `users_admins` DISABLE KEYS */;
INSERT INTO `users_admins` VALUES ('ad'),('admin');
/*!40000 ALTER TABLE `users_admins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users_businesses`
--

DROP TABLE IF EXISTS `users_businesses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users_businesses` (
  `username` varchar(45) NOT NULL,
  PRIMARY KEY (`username`),
  CONSTRAINT `jhk` FOREIGN KEY (`username`) REFERENCES `users` (`user_name`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users_businesses`
--

LOCK TABLES `users_businesses` WRITE;
/*!40000 ALTER TABLE `users_businesses` DISABLE KEYS */;
INSERT INTO `users_businesses` VALUES ('b'),('Coca-Cola'),('ERTTER'),('FOX'),('Green-Shore'),('IsraelElectric'),('K.S.P'),('Pets-IL'),('Tnuva');
/*!40000 ALTER TABLE `users_businesses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users_non_profits`
--

DROP TABLE IF EXISTS `users_non_profits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users_non_profits` (
  `user_name` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `website` varchar(45) NOT NULL,
  PRIMARY KEY (`user_name`),
  KEY `index2` (`email`) /*!80000 INVISIBLE */,
  KEY `ghjgh` (`website`),
  CONSTRAINT `jgh` FOREIGN KEY (`user_name`) REFERENCES `users` (`user_name`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users_non_profits`
--

LOCK TABLES `users_non_profits` WRITE;
/*!40000 ALTER TABLE `users_non_profits` DISABLE KEYS */;
INSERT INTO `users_non_profits` VALUES ('Alma','www.alma-green.co.il/about','admin@alma-green.co.il'),('DogLover','www.dogdeserve.co.il/about','dogadmin@dogdeserve.co.il'),('GreenINC','www.greenpad.co.il/save-the-streets','admin@greenpad.co.il'),('n','www.np.com','e@c.com'),('seaAdmin','www.clean-the-sea.co.il/about','clean@clean-the-sea.co.il');
/*!40000 ALTER TABLE `users_non_profits` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `z_shipped_status`
--

DROP TABLE IF EXISTS `z_shipped_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `z_shipped_status` (
  `shipped` varchar(45) NOT NULL,
  PRIMARY KEY (`shipped`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `z_shipped_status`
--

LOCK TABLES `z_shipped_status` WRITE;
/*!40000 ALTER TABLE `z_shipped_status` DISABLE KEYS */;
INSERT INTO `z_shipped_status` VALUES ('not_shipped'),('shipped');
/*!40000 ALTER TABLE `z_shipped_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `z_users_type`
--

DROP TABLE IF EXISTS `z_users_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `z_users_type` (
  `type` varchar(45) NOT NULL,
  PRIMARY KEY (`type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `z_users_type`
--

LOCK TABLES `z_users_type` WRITE;
/*!40000 ALTER TABLE `z_users_type` DISABLE KEYS */;
INSERT INTO `z_users_type` VALUES ('activist'),('admin'),('business'),('non-profit');
/*!40000 ALTER TABLE `z_users_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'promoit'
--
/*!50003 DROP PROCEDURE IF EXISTS `add_campaign` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `add_campaign`(
_name varchar(45),
_hashtag varchar(45),
_webpage varchar(250),
_non_profit_user_name varchar(45)
)
BEGIN
INSERT INTO promoit.campaigns (name, hashtag, webpage, non_profit_user_name) VALUES (_name, _hashtag, _webpage, _non_profit_user_name);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `add_tweet` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `add_tweet`(
_tweeter_id bigint(255),
_campaign_hashtag varchar(45),
_activist_user_name varchar(45),
_added_cash decimal,
_tweeter_retweets int
)
BEGIN
IF EXISTS( SELECT id FROM promoit.tweets where id= _tweeter_id) Then
	SET @current_retweets = (SELECT retweets FROM promoit.tweets where id= _tweeter_id );
    SET @added_retweets = _tweeter_retweets - @current_retweets;
	IF @added_retweets > 0 THEN
		UPDATE `promoit`.`users_activists` SET `cash` = cash + (@added_retweets * _added_cash) WHERE (`user_name` = _activist_user_name);
		UPDATE `promoit`.`tweets` SET `cash` = cash  + (@added_retweets * _added_cash), `retweets` = _tweeter_retweets WHERE (`id` = _tweeter_id );
	else
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'No updates for this tweet';
	end if;
else
	INSERT INTO `promoit`.`tweets` (`id`, `campaign_hashtag`, `activist_user_name`, `cash`, `retweets`) VALUES (_tweeter_id, _campaign_hashtag , _activist_user_name, _added_cash + _added_cash * _tweeter_retweets, _tweeter_retweets);
	UPDATE `promoit`.`users_activists` SET `cash` = cash + _added_cash + _added_cash * _tweeter_retweets WHERE (`user_name` = _activist_user_name);
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `buy_a_product` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `buy_a_product`(
_product_id int,
_quantity int,
_activist_user_name varchar(45),
_shipping varchar(45)
)
BEGIN
SET @item_price = (SELECT  Price FROM products_in_campaign Where id = _product_id);
SET @remain_quantity =  (SELECT  Quantity FROM products_in_campaign Where id = _product_id) - _quantity;
SET @remain_cash =  (SELECT cash FROM users_activists where user_name=_activist_user_name) - @item_price;

IF @remain_cash < 0 THEN
	SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Cash is not enough';
elseif @remain_quantity < 0 THEN 
	SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Item actual quantity lower then required';
else
	INSERT INTO `promoit`.`products_donated` (`product_in_campaign_id`, `activist_user_name`, `quantity`, `shipped`) VALUES( _product_id, _activist_user_name, _quantity, _shipping);
	UPDATE `promoit`.`products_in_campaign` SET `quantity` = `quantity` - _quantity WHERE(`id` = _product_id);
    UPDATE `promoit`.`users_activists` SET `cash` = `cash` - @item_price  WHERE (`user_name` = _activist_user_name);
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `delete_campaign` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_campaign`(_hashtag varchar(45))
BEGIN
DELETE FROM campaigns WHERE hashtag = _hashtag;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `new_procedure` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `new_procedure`(
_hashtag varchar(45),
_non_profit varchar(45),
_webpage varchar(45)
)
BEGIN
INSERT INTO `promoit`.`campaigns` (`hashtag`, `non_profit_user_name`, `webpage`) VALUES (_hashtag, _non_profit, _webpage);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `npo_display_search` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `npo_display_search`(_non_profit_user_name varchar (45))
BEGIN
SELECT * FROM campaigns WHERE non_profit_user_name = _non_profit_user_name;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `register_activist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `register_activist`( 
_username varchar(45),
_password varchar(45),
_name varchar(45),
_email varchar(45),
_address varchar(45),
_phone varchar(45),
_cash decimal(10,2)
)
BEGIN
INSERT INTO `promoit`.`users` (`user_name`, `user_password`, `user_type`, `name`) VALUES (_username, _password, 'activist', _name);
INSERT INTO `promoit`.`users_activists` (`user_name`, `email`, `address`, `phone_number`, `cash`) VALUES (_username, _email, _address, _phone, _cash);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `register_admin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `register_admin`( 
_username varchar(45),
_password varchar(45),
_name varchar(45)
)
BEGIN
INSERT INTO `promoit`.`users` (`user_name`, `user_password`, `user_type`, `name`) VALUES (_username, _password, 'admin', _name);
INSERT INTO `promoit`.`users_admins` (`user_name`) VALUES (_username);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `register_business` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `register_business`( 
_username varchar(45),
_password varchar(45),
_name varchar(45)
)
BEGIN
INSERT INTO `promoit`.`users` (`user_name`, `user_password`, `user_type`, `name`) VALUES (_username, _password, 'business', _name);
INSERT INTO `promoit`.`users_businesses` (`username`) VALUES (_username);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `register_non_profit` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `register_non_profit`( 
_username varchar(45),
_password varchar(45),
_name varchar(45),
_email varchar(45),
_website varchar(45)
)
BEGIN
INSERT INTO `promoit`.`users` (`user_name`, `user_password`, `user_type`, `name`) VALUES (_username, _password, 'non-profit', _name);
INSERT INTO `promoit`.`users_non_profits` (`user_name`, `email`, `website`) VALUES (_username, _email, _website);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-01-30  4:27:07
