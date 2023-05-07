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
-- Table structure for table `log`
--

DROP TABLE IF EXISTS `log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `log` (
  `id` int NOT NULL AUTO_INCREMENT,
  `time` varchar(45) DEFAULT NULL,
  `user` varchar(45) DEFAULT NULL,
  `information` varchar(45) DEFAULT NULL,
  `action` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=68 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log`
--

LOCK TABLES `log` WRITE;
/*!40000 ALTER TABLE `log` DISABLE KEYS */;
INSERT INTO `log` VALUES (54,'2023-05-08 오전 4:34:28','관리자','로그','로그 초기화'),(55,'2023-05-08 오전 4:34:41','관리자','네이버 검색','아이'),(56,'2023-05-08 오전 4:35:36','관리자','네이버 검색','아이'),(57,'2023-05-08 오전 4:36:26','관리자','managerid12','로그인'),(58,'2023-05-08 오전 4:36:35','관리자','네이버 검색','흰색'),(59,'2023-05-08 오전 4:39:10','관리자','managerid12','로그인'),(60,'2023-05-08 오전 4:40:21','관리자','managerid12','로그인'),(61,'2023-05-08 오전 4:40:45','유저','userid12','로그인'),(62,'2023-05-08 오전 4:40:49','유저','userid12','책 요청 내역'),(63,'2023-05-08 오전 4:41:00','userid12','네이버 검색','흰'),(64,'2023-05-08 오전 4:41:12','userid12','네이버 검색','날개'),(65,'2023-05-08 오전 4:41:25','userid12','책 요청 내역','날개'),(66,'2023-05-08 오전 4:41:25','userid12','책 요청 내역','날개 (무라야마 유카 장편소설)'),(67,'2023-05-08 오전 4:41:25','userid12','책 요청 내역','날개');
/*!40000 ALTER TABLE `log` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-08  5:20:51
