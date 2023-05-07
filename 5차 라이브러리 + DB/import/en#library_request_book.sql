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
-- Table structure for table `request_book`
--

DROP TABLE IF EXISTS `request_book`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `request_book` (
  `title` varchar(100) NOT NULL,
  `author` varchar(30) DEFAULT NULL,
  `publisher` varchar(30) DEFAULT NULL,
  `price` int DEFAULT NULL,
  `publishdate` varchar(50) DEFAULT NULL,
  `isbn` varchar(50) DEFAULT NULL,
  `information` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request_book`
--

LOCK TABLES `request_book` WRITE;
/*!40000 ALTER TABLE `request_book` DISABLE KEYS */;
INSERT INTO `request_book` VALUES ('야구 잘하는 50가지 비밀 (진짜 진짜 야구 잘하고 싶은 어린이만 보는 책!)','구보 요이치','라이카미',13260,'2016-06-30','9791186073995','“야구를 잘하고 싶니? 그럼 이 책을 열어 봐!\n너를 최고로 만들어 줄 거야!”\n야구를 진짜 진짜 좋아하고 진짜 진짜 잘하고 싶어 하는 \n어린이에게 꼭 필요한 특별한 야구 책!\n\n야구는 아이들에게도 인기가 매우 높은 스포츠예요. 프로야구의 인기와 세계무대에서 활약하는 멋진 선수들 덕분에, 주말마다 엄마 아빠와 함께 야구장을 찾거나 어릴 때부터 야구선수를 꿈꾸는 친구들이 아주 많아졌지요. \n그런데 야구는 공 하나만 있으면 친구들과 우당탕탕 뛰놀며 즐길 수 있는 축구와 다르게, 알아야 할 것도 배워야 할 것도 많은 어려운 스포츠예요. 규칙도 복잡하고, 투수와 포수, 내야수와 외야수 등 각자의 포지션에 맞는 역할이 따로 있거든요. 또 공을 쥐는 법부터 시작해서 바른 투구 폼과 타격 폼, 상황에 따라 다른 포구 방법 같은 기본기를 제대로 익히지 않으면, 아무리 연습해도 실력이 늘지 않지 않아요.'),('날개','양진희','그림과책',10800,'2023-02-21','9791190411837','제2시집에 이어 제3시집의 작품을 선보이는 양진희 시인. 일곱 빛깔 무지개처럼 많은 이들에게 기쁨을 선사하고 싶다고 하는 시인이다. 일상생활에서의 마음을 전달해 주는 3시집 〈날개〉.'),('날개 (무라야마 유카 장편소설)','무라야마 유카','예문사',12600,'2016-04-15','9788927417002','진정한 \"나\"를 찾아 떠나는 여정!\n\n《별을 담은 배》로 제129회 나오키상을 수상한 무라야마 유카의 장편소설 『날개』 . 뉴욕에서 루트 66, 애리조나까지 광활하게 펼쳐진 아메리카 대륙을 배경으로 아버지의 자살, 어머니의 학대, 학교에서의 따돌림 등 자신을 옭죄고 있던 온갖 굴레로부터 벗어나 진정한 자유와 행복을 찾기까지, 등장인물들의 지난한 여정을 담고 있다. 무라야마 유카는 이 작품을 통해 아동 학대, 인종 차별, 총기 사고, 사이비 종교 등 현대의 다양한 고질적 사회문제도 함께 다루며 전 세계 독자의 감동과 공감을 불러일으킨다.\n\n아버지의 자살, 어머니의 학대, 학교에서의 따돌림으로 가슴속 깊이 상처를 안고 미국으로 도망치듯 떠나 온 시노자키 마후유의 인생은 한 줄기 빛과 같은 연인 랠리의 등장으로 구원받는다. 오랫동안 찾아 해맨 행복을 거머쥔 바로 그때, 또 한차례 가혹한 운명이 그녀를 덮치는데…. 계속되는 시력에 상처 입은 영혼은 다시 날개를 펼칠 수 있을까.'),('날개','이상','이가서',8550,'2004-06-22','9788990365941','나는 나를 박제가 되어 버린 천재라고 생각한다. 나는 아내와 함께 33번지의 7번째 방에 살고 있다. 나 대신 돈을 버는 아내는 33번지의 여자들 중에서 가장 아름답다. 나와 아내는 장지문을 사이에 두고 각 방을 사용한다. 난 아내가 외출을 하면 아내의 방으로 달려가서 돋보기와 화장지로 불장난도 하고, 손거울 장난도 하고, 화장품 냄새도 맡는다. 난 옷이 한 벌인데 아내는 아름다운 옷들이 여러 벌 있다. 그래도 난 불평하지 않는다. 아내는 항상 외출을 하며, 아내의 손님은 집으로 찾아오기도 한다. 아내의 직업은 무엇일까? 난 행복한가? 아니면 불행한가?\n\n소설 만화책. 1936년 [조선일보]의 〈조광〉에 발표된 이상의 단편 소설 〈날개〉를 만화로 재구성하였다. 단편 소설 〈날개〉는 1인칭 주인공 시점이며, 일제강점기의 서울을 배경으로 삼고 있고 있다. 또한 한국 현대 문학의 최초 심리주의 소설이라고 할 수 있으며, 초현실적 기법으로 인간의 정신 세계를 치말하게 묘사하고 있다.');
/*!40000 ALTER TABLE `request_book` ENABLE KEYS */;
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
