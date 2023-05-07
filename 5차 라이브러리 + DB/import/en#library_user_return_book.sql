-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: en#library
-- ------------------------------------------------------
-- Server version	8.0.33

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
-- Table structure for table `user_return_book`
--

DROP TABLE IF EXISTS `user_return_book`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_return_book` (
  `user_id` varchar(10) NOT NULL,
  `book_id` int NOT NULL,
  `title` varchar(100) NOT NULL,
  `author` varchar(30) NOT NULL,
  `publisher` varchar(30) NOT NULL,
  `amount` int NOT NULL,
  `price` int NOT NULL,
  `publish_date` varchar(50) NOT NULL,
  `ISBN` varchar(50) NOT NULL,
  `information` text NOT NULL,
  `rental_time` varchar(50) NOT NULL,
  `return_time` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_return_book`
--

LOCK TABLES `user_return_book` WRITE;
/*!40000 ALTER TABLE `user_return_book` DISABLE KEYS */;
INSERT INTO `user_return_book` VALUES ('',0,'','','',0,0,'','','','','2023-05-03 오후 11:28:25'),('userid12',3,'신경 끄기의 기술','마크 맨슨','갤리온',1,15000,'2020-05-10 00:00:00','978-89-01-32994-3','자기계발','2023-05-05 오후 10:51:21','2023-05-05 오후 10:55:22'),('userid12',16,'나혼자 C언어','이창현','디지털북스',4,25000,'2000-10-04','978-89-6088-381-9','프로그래밍','2023-05-05 오후 10:55:10','2023-05-05 오후 10:57:24'),('userid12',3,'신경 끄기의 기술','마크 맨슨','갤리온',1,15000,'2020-05-10 00:00:00','978-89-01-32994-3','자기계발','2023-05-06 오전 12:28:54','2023-05-06 오전 12:29:19'),('hyeona10',3,'신경 끄기의 기술','마크 맨슨','갤리온',1,15000,'2020-05-10 00:00:00','978-89-01-32994-3','자기계발','2023-05-06 오전 12:36:40','2023-05-07 오전 6:10:53'),('hyeona10',3,'신경 끄기의 기술','마크 맨슨','갤리온',1,15000,'2020-05-10 00:00:00','978-89-01-32994-3','자기계발','2023-05-06 오전 12:36:40','2023-05-07 오후 1:36:17'),('',0,'','','',0,0,'','','','','2023-05-07 오후 2:07:47'),('',0,'','','',0,0,'','','','','2023-05-07 오후 2:07:49');
/*!40000 ALTER TABLE `user_return_book` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-08  5:20:50
