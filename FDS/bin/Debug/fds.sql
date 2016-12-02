/*
Navicat MySQL Data Transfer

Source Server         : 本地MySQL
Source Server Version : 50529
Source Host           : localhost:3306
Source Database       : fds

Target Server Type    : MYSQL
Target Server Version : 50529
File Encoding         : 65001

Date: 2016-11-30 17:28:21
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for failure_tree
-- ----------------------------
DROP TABLE IF EXISTS `failure_tree`;
CREATE TABLE `failure_tree` (
  `ft_id` int(11) NOT NULL AUTO_INCREMENT COMMENT '故障树id',
  `ft_adduser` int(11) NOT NULL COMMENT '添加用户',
  `ptype_id` int(11) NOT NULL,
  `tpoint_id` int(11) NOT NULL,
  `system_id` int(11) NOT NULL,
  `ft_addtime` datetime NOT NULL COMMENT '添加时间',
  `ft_pic` longblob COMMENT '故障树图片',
  `ft_grid` longblob,
  `ft_keywd` varchar(512) DEFAULT NULL COMMENT '故障关键字',
  `experience` text COMMENT '经验模式数据',
  PRIMARY KEY (`ft_id`),
  KEY `FK_Reference_2` (`ft_adduser`),
  KEY `FK_Reference_6` (`ptype_id`),
  KEY `FK_Reference_7` (`tpoint_id`),
  KEY `FK_Reference_8` (`system_id`),
  CONSTRAINT `FK_Reference_2` FOREIGN KEY (`ft_adduser`) REFERENCES `user_info` (`user_id`),
  CONSTRAINT `FK_Reference_6` FOREIGN KEY (`ptype_id`) REFERENCES `plane_type` (`ptype_id`),
  CONSTRAINT `FK_Reference_7` FOREIGN KEY (`tpoint_id`) REFERENCES `time_point` (`tpoint_id`),
  CONSTRAINT `FK_Reference_8` FOREIGN KEY (`system_id`) REFERENCES `fail_system` (`system_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COMMENT='故障树主表';

-- ----------------------------
-- Table structure for fail_system
-- ----------------------------
DROP TABLE IF EXISTS `fail_system`;
CREATE TABLE `fail_system` (
  `system_id` int(11) NOT NULL AUTO_INCREMENT,
  `system_name` varchar(128) NOT NULL,
  `system_remark` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`system_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='发生位置';

-- ----------------------------
-- Table structure for fault_history
-- ----------------------------
DROP TABLE IF EXISTS `fault_history`;
CREATE TABLE `fault_history` (
  `fh_id` int(11) NOT NULL AUTO_INCREMENT COMMENT '故障id',
  `fh_adduser` int(11) NOT NULL COMMENT '添加用户',
  `ptype_id` int(11) NOT NULL,
  `tpoint_id` int(11) NOT NULL,
  `system_id` int(11) NOT NULL,
  `fh_phenomenon` varchar(2048) DEFAULT NULL COMMENT '故障现象或代码',
  `fh_caseid` varchar(128) DEFAULT NULL COMMENT '目标案例编号',
  `fh_title` varchar(512) DEFAULT NULL COMMENT '目标案例标题',
  `fh_description` varchar(2048) DEFAULT NULL COMMENT '相关描述',
  `fh_cause` varchar(2048) DEFAULT NULL COMMENT '原因',
  `fh_suggest` varchar(2048) DEFAULT NULL COMMENT '修理措施建议',
  `fh_explain` varchar(2048) DEFAULT NULL COMMENT '解释',
  `fh_reference` varchar(2048) DEFAULT NULL COMMENT '参考资料',
  `fh_experience` varchar(2048) DEFAULT NULL COMMENT '经验教训',
  `fh_keywd` varchar(512) DEFAULT NULL COMMENT '故障关键字',
  `fh_addtime` datetime NOT NULL COMMENT '添加时间',
  PRIMARY KEY (`fh_id`),
  KEY `FK_Reference_3` (`ptype_id`) USING BTREE,
  KEY `FK_Reference_4` (`tpoint_id`) USING BTREE,
  KEY `FK_Reference_5` (`system_id`) USING BTREE,
  KEY `FK_Reference_1` (`fh_adduser`) USING BTREE,
  CONSTRAINT `fault_history_ibfk_1` FOREIGN KEY (`fh_adduser`) REFERENCES `user_info` (`user_id`),
  CONSTRAINT `fault_history_ibfk_2` FOREIGN KEY (`ptype_id`) REFERENCES `plane_type` (`ptype_id`),
  CONSTRAINT `fault_history_ibfk_3` FOREIGN KEY (`tpoint_id`) REFERENCES `time_point` (`tpoint_id`),
  CONSTRAINT `fault_history_ibfk_4` FOREIGN KEY (`system_id`) REFERENCES `fail_system` (`system_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='历史故障信息表';

-- ----------------------------
-- Table structure for plane_type
-- ----------------------------
DROP TABLE IF EXISTS `plane_type`;
CREATE TABLE `plane_type` (
  `ptype_id` int(11) NOT NULL AUTO_INCREMENT,
  `ptype_name` varchar(128) NOT NULL,
  `plane_remark` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`ptype_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='飞机型号';

-- ----------------------------
-- Table structure for time_point
-- ----------------------------
DROP TABLE IF EXISTS `time_point`;
CREATE TABLE `time_point` (
  `tpoint_id` int(11) NOT NULL AUTO_INCREMENT,
  `tpoint_value` varchar(128) NOT NULL,
  `tpoint_remark` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`tpoint_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='故障发生时间';

-- ----------------------------
-- Table structure for user_info
-- ----------------------------
DROP TABLE IF EXISTS `user_info`;
CREATE TABLE `user_info` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT COMMENT '用户id',
  `user_name` varchar(32) DEFAULT NULL COMMENT '用户名',
  `user_pwd` varchar(32) DEFAULT NULL COMMENT '用户密码',
  `user_tel` varchar(32) DEFAULT NULL COMMENT '用户电话号码',
  `user_email` varchar(32) DEFAULT NULL COMMENT '用户邮箱',
  `user_remark` varchar(256) DEFAULT NULL COMMENT '备注',
  `user_isadmin` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='用户信息表';

-- ----------------------------
-- View structure for v_failure_tree
-- ----------------------------
DROP VIEW IF EXISTS `v_failure_tree`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY INVOKER  VIEW `v_failure_tree` AS SELECT
failure_tree.ft_id,
failure_tree.ft_adduser,
failure_tree.ptype_id,
failure_tree.tpoint_id,
failure_tree.system_id,
failure_tree.ft_addtime,
failure_tree.ft_pic,
failure_tree.ft_grid,
failure_tree.ft_keywd,
plane_type.ptype_name,
time_point.tpoint_value,
fail_system.system_name,
user_info.user_name,
failure_tree.experience
FROM
failure_tree
LEFT JOIN plane_type ON failure_tree.ptype_id = plane_type.ptype_id
LEFT JOIN time_point ON failure_tree.tpoint_id = time_point.tpoint_id
LEFT JOIN fail_system ON failure_tree.system_id = fail_system.system_id
LEFT JOIN user_info ON failure_tree.ft_adduser = user_info.user_id ;

-- ----------------------------
-- View structure for v_fail_history
-- ----------------------------
DROP VIEW IF EXISTS `v_fail_history`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%`  SQL SECURITY INVOKER VIEW `v_fail_history` AS SELECT
fault_history.fh_id,
fault_history.fh_adduser,
fault_history.ptype_id,
fault_history.tpoint_id,
fault_history.system_id,
fault_history.fh_phenomenon,
fault_history.fh_caseid,
fault_history.fh_title,
fault_history.fh_description,
fault_history.fh_cause,
fault_history.fh_suggest,
fault_history.fh_explain,
fault_history.fh_reference,
fault_history.fh_experience,
fault_history.fh_keywd,
fault_history.fh_addtime,
fail_system.system_name,
plane_type.ptype_name,
time_point.tpoint_value,
user_info.user_name
FROM
fault_history
INNER JOIN fail_system ON fault_history.system_id = fail_system.system_id
INNER JOIN plane_type ON fault_history.ptype_id = plane_type.ptype_id
INNER JOIN time_point ON fault_history.tpoint_id = time_point.tpoint_id
INNER JOIN user_info ON fault_history.fh_adduser = user_info.user_id ;

-- -----------------------------------
-- 重置数据表
-- -----------------------------------
truncate table fault_history;
truncate table fail_system;
truncate table failure_tree;
truncate table time_point;
truncate table plane_type;
truncate table user_info;