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
-- Table structure for table `book_list`
--

DROP TABLE IF EXISTS `book_list`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `book_list` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(100) NOT NULL,
  `author` varchar(30) NOT NULL,
  `publisher` varchar(30) NOT NULL,
  `amount` int NOT NULL,
  `price` int NOT NULL,
  `publishdate` varchar(50) NOT NULL,
  `ISBN` varchar(50) NOT NULL,
  `information` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `book_list`
--

LOCK TABLES `book_list` WRITE;
/*!40000 ALTER TABLE `book_list` DISABLE KEYS */;
INSERT INTO `book_list` VALUES (3,'신경 끄기의 기술','마크 맨슨','갤리온',0,15000,'2020-05-10 00:00:00','978-89-01-32994-3','자기계발'),(4,'퇴사 준비생의 런던','이동진','백투더퓨처',0,15000,'2018-09-18 00:00:00','979-11-960827-2-7-03320','에세이'),(6,'스마트경영학','최진남, 성선영','생능출판사',10,27000,'2019-07-12','979-11-86689-26-4','경영학원론 교재'),(7,'실전 C프로그래밍','세종대 교수','21세기사',5,30000,'2020-10-12','978-89-8468-826-1','C프로그래밍 교재'),(8,'DO IT 웹 표준의 정석','고경희','이지퍼블리싱',8,30000,'2021-01-22','979-11-6303-221-2','웹프로그래밍 기초'),(9,'살면서 쉬웠던 날은 단 하루도 없었다','박광수','에담',2,13000,'2000-05-23','978-89-5913-947-7','자전적 수필'),(10,'젊은작가상 수상작품집 2011년 제2','김애란 외 6인','문학동네',4,11000,'2011-04-25','978-89-546-1465-8','소설'),(11,'데미안','헤르만 헤세','문학동네',6,8000,'2013-01-01','978-89-546-2014-7','노벨문학상'),(12,'호밀밭의 파수꾼','J.D. 샐린저','문예출판사',1,8000,'1985-03-15','89-310-0352-8','현대문학'),(13,'한의원의 인류학','김태우','돌베개',2,14000,'2021-02-26','978-89-7199-441-2','인류학'),(14,'뜻밖의 바닐라','이혜미','문학과지성사',7,9000,'2016-10-20','978-89-320-2912-2','시집'),(15,'COLLEGE ENGLISH	','오재환','와이비엠넷',50,12000,'2022-03-10','979-11-5899-452-5','대학영어 교재'),(16,'나혼자 C언어','이창현','디지털북스',4,25000,'2000-10-04','978-89-6088-381-9','프로그래밍'),(17,'차라투스트라는 이렇게 말했다','프리드리히 니체','민음사',2,12000,'2004-01-02','978-893-746-094-4','고전'),(22,'동행','우유수염','단비어린이',3,11550,'2022-07-22','9788963010328','동행, 그 아름다운 것들에 대하여\n\n'),(23,'우유의 독 (내 몸을 망치는 11가지 이유)','프랭크 오스키','이지북',2,10260,'2013-01-05','9788956244013','영양가 높은 식품으로 알려졌던 우유를'),(24,'엔 스페인 En SPAIN(딸기우유핑크 에디션) (30 Days in Barcelona)','도은진','오브바이포',10,16250,'2018-07-18','9791196205522','휴식의 순간을 함께 하는 스페인의 풍'),(25,'불이 꺼지면','우유수염','내인생의책',6,11120,'2019-09-16','9791157234929','“불이 꺼지면 무슨 일이 벌어질까요?'),(26,'우유는 안 마셔','노인경','문학동네',7,9900,'2022-10-31','9788954689335','세상에 대한 호기심, 자기 주장과 의'),(27,'야구장 가는 날','김영진','길벗어린이',1,11120,'2020-03-02','9788955825459','★ 김영진 그림책 열한 번째 이야기 ★\n야구보다 치킨이 더 좋은 그린이랑 \n열혈 야구팬 아빠가 야구장에 떴다!\n\n유니폼을 입고, 맛있는 치킨도 먹고, 신나는 파도타기 응원까지!\n오늘은 아빠와 아들이 함께 야구장 가는 날!\n\n그린이는 야구를 싫어했어요. 야구광인 아빠는 야구 중계를 볼 때면 항상 소리를 지르고 화를 냈거든요. 그런데 우연히 친구들과 야구를 해 본 다음부터 그린이는 야구에 재미를 느끼게 됐어요. 그린이가 야구에 관심을 갖자 신난 아빠는 어느 때보다 열정적으로 그린이에게 야구를 가르쳐 주며 그날로 야구 티켓을 사 오지요. \n맙소사, 경기만 보면 목이 터져라 소리 지르는 아빠와 야구장이라니! 아빠가 화를 내는 모습이 떠오른 그린이는 안 가겠다고 거절했지만 아빠는 그린이를 설득할 비장의 무기를 꺼내들어요. 그건 바로 세상에서 제일 맛있는 야구장 치킨이었어요! 치킨을 먹으러 야구장에 간 그린이와 열혈 야구팬 아빠. 과연 두 사람에게는 어떤 일이 벌어질까요?\n\n대한민국 대표 ‘아빠 작가’ 김영진이 이번에는 뜨거운 열기가 가득한 야구장 이야기를 전합니다. 아빠는 오랫동안 좋아해 온 야구를 아들과 함께 보면서 말로 표현할 수 없는 감동과 흥분을 느낍니다. 함께 맛있는 것도 먹고 신나게 응원하면서 어느새 이기고 지는 것은 더 이상 중요하지 않다는 것을 깨닫게 됩니다. 가끔 티격태격 다투기도 하지만 더없이 다정한 그린이와 아빠의 이야기는 독자들에게 유쾌한 웃음과 따뜻한 감동을 선사할 것입니다.');
/*!40000 ALTER TABLE `book_list` ENABLE KEYS */;
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
