SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for file_0
-- ----------------------------
DROP TABLE IF EXISTS `file_0`;
CREATE TABLE `file_0`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_0_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 24 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_1
-- ----------------------------
DROP TABLE IF EXISTS `file_1`;
CREATE TABLE `file_1`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_1_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 26 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_10
-- ----------------------------
DROP TABLE IF EXISTS `file_10`;
CREATE TABLE `file_10`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_10_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 23 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_11
-- ----------------------------
DROP TABLE IF EXISTS `file_11`;
CREATE TABLE `file_11`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_11_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 24 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_12
-- ----------------------------
DROP TABLE IF EXISTS `file_12`;
CREATE TABLE `file_12`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_12_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 29 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_13
-- ----------------------------
DROP TABLE IF EXISTS `file_13`;
CREATE TABLE `file_13`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_13_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 31 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_14
-- ----------------------------
DROP TABLE IF EXISTS `file_14`;
CREATE TABLE `file_14`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_14_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 22 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_15
-- ----------------------------
DROP TABLE IF EXISTS `file_15`;
CREATE TABLE `file_15`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_15_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 30 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_16
-- ----------------------------
DROP TABLE IF EXISTS `file_16`;
CREATE TABLE `file_16`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_16_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 22 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_17
-- ----------------------------
DROP TABLE IF EXISTS `file_17`;
CREATE TABLE `file_17`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_17_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 31 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_18
-- ----------------------------
DROP TABLE IF EXISTS `file_18`;
CREATE TABLE `file_18`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_18_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 38 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_19
-- ----------------------------
DROP TABLE IF EXISTS `file_19`;
CREATE TABLE `file_19`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_19_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 20 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_2
-- ----------------------------
DROP TABLE IF EXISTS `file_2`;
CREATE TABLE `file_2`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_2_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 31 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_20
-- ----------------------------
DROP TABLE IF EXISTS `file_20`;
CREATE TABLE `file_20`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_20_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 37 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_21
-- ----------------------------
DROP TABLE IF EXISTS `file_21`;
CREATE TABLE `file_21`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_21_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 27 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_22
-- ----------------------------
DROP TABLE IF EXISTS `file_22`;
CREATE TABLE `file_22`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_22_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 27 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_23
-- ----------------------------
DROP TABLE IF EXISTS `file_23`;
CREATE TABLE `file_23`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_23_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 20 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_24
-- ----------------------------
DROP TABLE IF EXISTS `file_24`;
CREATE TABLE `file_24`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_24_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 23 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_25
-- ----------------------------
DROP TABLE IF EXISTS `file_25`;
CREATE TABLE `file_25`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_25_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 30 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_26
-- ----------------------------
DROP TABLE IF EXISTS `file_26`;
CREATE TABLE `file_26`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_26_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 33 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_27
-- ----------------------------
DROP TABLE IF EXISTS `file_27`;
CREATE TABLE `file_27`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_27_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 38 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_28
-- ----------------------------
DROP TABLE IF EXISTS `file_28`;
CREATE TABLE `file_28`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_28_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 29 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_29
-- ----------------------------
DROP TABLE IF EXISTS `file_29`;
CREATE TABLE `file_29`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_29_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 25 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_3
-- ----------------------------
DROP TABLE IF EXISTS `file_3`;
CREATE TABLE `file_3`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_3_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 36 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_30
-- ----------------------------
DROP TABLE IF EXISTS `file_30`;
CREATE TABLE `file_30`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_30_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 31 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_31
-- ----------------------------
DROP TABLE IF EXISTS `file_31`;
CREATE TABLE `file_31`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_31_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 32 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_32
-- ----------------------------
DROP TABLE IF EXISTS `file_32`;
CREATE TABLE `file_32`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_32_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 27 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_33
-- ----------------------------
DROP TABLE IF EXISTS `file_33`;
CREATE TABLE `file_33`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_33_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 24 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_34
-- ----------------------------
DROP TABLE IF EXISTS `file_34`;
CREATE TABLE `file_34`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_34_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 25 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_35
-- ----------------------------
DROP TABLE IF EXISTS `file_35`;
CREATE TABLE `file_35`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_35_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 28 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_36
-- ----------------------------
DROP TABLE IF EXISTS `file_36`;
CREATE TABLE `file_36`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_36_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 30 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_37
-- ----------------------------
DROP TABLE IF EXISTS `file_37`;
CREATE TABLE `file_37`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_37_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 27 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_38
-- ----------------------------
DROP TABLE IF EXISTS `file_38`;
CREATE TABLE `file_38`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_38_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 29 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_39
-- ----------------------------
DROP TABLE IF EXISTS `file_39`;
CREATE TABLE `file_39`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_39_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 35 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_4
-- ----------------------------
DROP TABLE IF EXISTS `file_4`;
CREATE TABLE `file_4`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_4_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 23 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_40
-- ----------------------------
DROP TABLE IF EXISTS `file_40`;
CREATE TABLE `file_40`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_40_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 31 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_41
-- ----------------------------
DROP TABLE IF EXISTS `file_41`;
CREATE TABLE `file_41`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_41_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 28 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_42
-- ----------------------------
DROP TABLE IF EXISTS `file_42`;
CREATE TABLE `file_42`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_42_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 36 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_43
-- ----------------------------
DROP TABLE IF EXISTS `file_43`;
CREATE TABLE `file_43`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_43_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 26 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_44
-- ----------------------------
DROP TABLE IF EXISTS `file_44`;
CREATE TABLE `file_44`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_44_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 25 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_45
-- ----------------------------
DROP TABLE IF EXISTS `file_45`;
CREATE TABLE `file_45`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_45_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 25 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_46
-- ----------------------------
DROP TABLE IF EXISTS `file_46`;
CREATE TABLE `file_46`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_46_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 35 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_47
-- ----------------------------
DROP TABLE IF EXISTS `file_47`;
CREATE TABLE `file_47`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_47_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 45 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_48
-- ----------------------------
DROP TABLE IF EXISTS `file_48`;
CREATE TABLE `file_48`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_48_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 20 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_49
-- ----------------------------
DROP TABLE IF EXISTS `file_49`;
CREATE TABLE `file_49`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_49_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 28 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_5
-- ----------------------------
DROP TABLE IF EXISTS `file_5`;
CREATE TABLE `file_5`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_5_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 25 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_50
-- ----------------------------
DROP TABLE IF EXISTS `file_50`;
CREATE TABLE `file_50`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_50_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 31 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_51
-- ----------------------------
DROP TABLE IF EXISTS `file_51`;
CREATE TABLE `file_51`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_51_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 29 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_52
-- ----------------------------
DROP TABLE IF EXISTS `file_52`;
CREATE TABLE `file_52`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_52_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 33 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_53
-- ----------------------------
DROP TABLE IF EXISTS `file_53`;
CREATE TABLE `file_53`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_53_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 38 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_54
-- ----------------------------
DROP TABLE IF EXISTS `file_54`;
CREATE TABLE `file_54`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_54_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 28 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_55
-- ----------------------------
DROP TABLE IF EXISTS `file_55`;
CREATE TABLE `file_55`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_55_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 25 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_56
-- ----------------------------
DROP TABLE IF EXISTS `file_56`;
CREATE TABLE `file_56`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_56_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 33 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_57
-- ----------------------------
DROP TABLE IF EXISTS `file_57`;
CREATE TABLE `file_57`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_57_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 31 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_58
-- ----------------------------
DROP TABLE IF EXISTS `file_58`;
CREATE TABLE `file_58`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_58_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 29 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_59
-- ----------------------------
DROP TABLE IF EXISTS `file_59`;
CREATE TABLE `file_59`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_59_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 22 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_6
-- ----------------------------
DROP TABLE IF EXISTS `file_6`;
CREATE TABLE `file_6`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_6_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 28 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_60
-- ----------------------------
DROP TABLE IF EXISTS `file_60`;
CREATE TABLE `file_60`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_60_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 24 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_61
-- ----------------------------
DROP TABLE IF EXISTS `file_61`;
CREATE TABLE `file_61`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_61_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 25 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_62
-- ----------------------------
DROP TABLE IF EXISTS `file_62`;
CREATE TABLE `file_62`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_62_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 28 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_63
-- ----------------------------
DROP TABLE IF EXISTS `file_63`;
CREATE TABLE `file_63`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_63_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 34 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_7
-- ----------------------------
DROP TABLE IF EXISTS `file_7`;
CREATE TABLE `file_7`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_7_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 30 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_8
-- ----------------------------
DROP TABLE IF EXISTS `file_8`;
CREATE TABLE `file_8`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_8_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 34 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for file_9
-- ----------------------------
DROP TABLE IF EXISTS `file_9`;
CREATE TABLE `file_9`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Length` int(11) NOT NULL,
  `ServerId` bit(1) NOT NULL,
  `MimeId` int(11) NOT NULL,
  `Sha1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ExtInfo` varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_File_9_Sha1`(`Sha1`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 35 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_0
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_0`;
CREATE TABLE `fileowner_0`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_0_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_0_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_0_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 67 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_1
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_1`;
CREATE TABLE `fileowner_1`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_1_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_1_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_1_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 44 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_10
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_10`;
CREATE TABLE `fileowner_10`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_10_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_10_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_10_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 82 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_11
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_11`;
CREATE TABLE `fileowner_11`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_11_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_11_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_11_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 63 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_12
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_12`;
CREATE TABLE `fileowner_12`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_12_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_12_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_12_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 84 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_13
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_13`;
CREATE TABLE `fileowner_13`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_13_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_13_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_13_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 56 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_14
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_14`;
CREATE TABLE `fileowner_14`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_14_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_14_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_14_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 40 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_15
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_15`;
CREATE TABLE `fileowner_15`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_15_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_15_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_15_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 97 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_16
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_16`;
CREATE TABLE `fileowner_16`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_16_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_16_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_16_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 71 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_17
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_17`;
CREATE TABLE `fileowner_17`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_17_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_17_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_17_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 181 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_18
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_18`;
CREATE TABLE `fileowner_18`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_18_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_18_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_18_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 70 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_19
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_19`;
CREATE TABLE `fileowner_19`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_19_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_19_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_19_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 57 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_2
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_2`;
CREATE TABLE `fileowner_2`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_2_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_2_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_2_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 92 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_20
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_20`;
CREATE TABLE `fileowner_20`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_20_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_20_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_20_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 54 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_21
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_21`;
CREATE TABLE `fileowner_21`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_21_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_21_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_21_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 57 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_22
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_22`;
CREATE TABLE `fileowner_22`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_22_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_22_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_22_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 87 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_23
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_23`;
CREATE TABLE `fileowner_23`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_23_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_23_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_23_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 27 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_24
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_24`;
CREATE TABLE `fileowner_24`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_24_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_24_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_24_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 36 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_25
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_25`;
CREATE TABLE `fileowner_25`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_25_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_25_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_25_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 42 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_26
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_26`;
CREATE TABLE `fileowner_26`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_26_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_26_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_26_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 43 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_27
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_27`;
CREATE TABLE `fileowner_27`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_27_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_27_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_27_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 95 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_28
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_28`;
CREATE TABLE `fileowner_28`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_28_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_28_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_28_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 52 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_29
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_29`;
CREATE TABLE `fileowner_29`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_29_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_29_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_29_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 33 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_3
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_3`;
CREATE TABLE `fileowner_3`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_3_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_3_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_3_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 96 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_30
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_30`;
CREATE TABLE `fileowner_30`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_30_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_30_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_30_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 74 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_31
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_31`;
CREATE TABLE `fileowner_31`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_31_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_31_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_31_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 151 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_32
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_32`;
CREATE TABLE `fileowner_32`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_32_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_32_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_32_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 71 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_33
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_33`;
CREATE TABLE `fileowner_33`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_33_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_33_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_33_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 117 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_34
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_34`;
CREATE TABLE `fileowner_34`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_34_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_34_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_34_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 122 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_35
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_35`;
CREATE TABLE `fileowner_35`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_35_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_35_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_35_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 83 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_36
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_36`;
CREATE TABLE `fileowner_36`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_36_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_36_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_36_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 46 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_37
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_37`;
CREATE TABLE `fileowner_37`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_37_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_37_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_37_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 34 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_38
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_38`;
CREATE TABLE `fileowner_38`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_38_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_38_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_38_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 68 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_39
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_39`;
CREATE TABLE `fileowner_39`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_39_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_39_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_39_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 108 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_4
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_4`;
CREATE TABLE `fileowner_4`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_4_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_4_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_4_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 148 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_40
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_40`;
CREATE TABLE `fileowner_40`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_40_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_40_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_40_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 59 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_41
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_41`;
CREATE TABLE `fileowner_41`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_41_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_41_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_41_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 112 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_42
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_42`;
CREATE TABLE `fileowner_42`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_42_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_42_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_42_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 101 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_43
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_43`;
CREATE TABLE `fileowner_43`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_43_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_43_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_43_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 126 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_44
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_44`;
CREATE TABLE `fileowner_44`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_44_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_44_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_44_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 44 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_45
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_45`;
CREATE TABLE `fileowner_45`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_45_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_45_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_45_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 80 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_46
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_46`;
CREATE TABLE `fileowner_46`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_46_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_46_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_46_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 111 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_47
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_47`;
CREATE TABLE `fileowner_47`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_47_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_47_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_47_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 104 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_48
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_48`;
CREATE TABLE `fileowner_48`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_48_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_48_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_48_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 70 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_49
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_49`;
CREATE TABLE `fileowner_49`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_49_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_49_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_49_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 93 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_5
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_5`;
CREATE TABLE `fileowner_5`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_5_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_5_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_5_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 458 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_50
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_50`;
CREATE TABLE `fileowner_50`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_50_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_50_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_50_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 97 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_51
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_51`;
CREATE TABLE `fileowner_51`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_51_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_51_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_51_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 79 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_52
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_52`;
CREATE TABLE `fileowner_52`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_52_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_52_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_52_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 52 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_53
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_53`;
CREATE TABLE `fileowner_53`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_53_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_53_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_53_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 73 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_54
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_54`;
CREATE TABLE `fileowner_54`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_54_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_54_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_54_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 83 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_55
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_55`;
CREATE TABLE `fileowner_55`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_55_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_55_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_55_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 69 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_56
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_56`;
CREATE TABLE `fileowner_56`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_56_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_56_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_56_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 93 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_57
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_57`;
CREATE TABLE `fileowner_57`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_57_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_57_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_57_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 117 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_58
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_58`;
CREATE TABLE `fileowner_58`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_58_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_58_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_58_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 47 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_59
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_59`;
CREATE TABLE `fileowner_59`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_59_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_59_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_59_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 41 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_6
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_6`;
CREATE TABLE `fileowner_6`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_6_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_6_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_6_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 51 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_60
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_60`;
CREATE TABLE `fileowner_60`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_60_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_60_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_60_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 92 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_61
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_61`;
CREATE TABLE `fileowner_61`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_61_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_61_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_61_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 263 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_62
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_62`;
CREATE TABLE `fileowner_62`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_62_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_62_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_62_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 493 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_63
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_63`;
CREATE TABLE `fileowner_63`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_63_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_63_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_63_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 138 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_7
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_7`;
CREATE TABLE `fileowner_7`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_7_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_7_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_7_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 77 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_8
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_8`;
CREATE TABLE `fileowner_8`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_8_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_8_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_8_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 97 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for fileowner_9
-- ----------------------------
DROP TABLE IF EXISTS `fileowner_9`;
CREATE TABLE `fileowner_9`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileId` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CreateTime` datetime(0) NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_FileOwner_9_FileId`(`FileId`) USING BTREE,
  INDEX `IX_FileOwner_9_OwnerType`(`OwnerType`) USING BTREE,
  INDEX `IX_FileOwner_9_OwnerId`(`OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 76 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for ownerquota
-- ----------------------------
DROP TABLE IF EXISTS `ownerquota`;
CREATE TABLE `ownerquota`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `OwnerType` int(11) NOT NULL,
  `OwnerId` bigint(20) NOT NULL,
  `Used` bigint(20) NOT NULL,
  `Max` bigint(20) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_OwnerQuota_OwnerType_OwnerId`(`OwnerType`, `OwnerId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 293 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
