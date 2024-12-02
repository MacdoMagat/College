--
-- Database: `pos`
--
CREATE DATABASE IF NOT EXISTS `pos` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `pos`;

-- --------------------------------------------------------

--
-- Table structure for table `logstbl`
--

CREATE TABLE `logstbl` (
  `id` int(11) NOT NULL,
  `username` varchar(50) DEFAULT NULL,
  `process` varchar(50) DEFAULT NULL,
  `description` text,
  `dateandtime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `logstbl`
--

INSERT INTO `logstbl` (`id`, `username`, `process`, `description`, `dateandtime`) VALUES
(133, 'admin', 'Login', 'Logged In', '2017-05-10 20:39:25'),
(134, 'admin', 'Open Logs', 'Opened Logs', '2017-05-10 20:39:26'),
(135, 'admin', 'Open Reports', 'Opened Reports', '2017-05-10 20:39:47'),
(136, 'admin', 'Open POS', 'Opened POS', '2017-05-10 20:39:52'),
(137, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-10 20:39:57'),
(138, 'admin', 'Inventory - Delete Category', 'Deleted category (Wire)', '2017-05-10 20:41:26'),
(139, 'admin', 'Inventory - Delete Category', 'Deleted category (Paint)', '2017-05-10 20:41:31'),
(140, 'admin', 'Inventory - Delete Category', 'Deleted category (Nail)', '2017-05-10 20:41:34'),
(141, 'admin', 'Inventory - Delete Category', 'Deleted category (Hammer)', '2017-05-10 20:41:37'),
(142, 'admin', 'Inventory - Delete Category', 'Deleted category (Product Category 1)', '2017-05-10 20:41:40'),
(143, 'admin', 'Inventory - Delete Category', 'Deleted category (Product Category 2)', '2017-05-10 20:41:42'),
(144, 'admin', 'Inventory - Delete Category', 'Deleted category (Product Category 4)', '2017-05-10 20:41:49'),
(145, 'admin', 'Open POS', 'Opened POS', '2017-05-10 20:41:59'),
(146, 'admin', 'Open Logs', 'Opened Logs', '2017-05-10 20:42:05'),
(147, 'admin', 'Open POS', 'Opened POS', '2017-05-10 20:42:08'),
(148, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-10 20:42:11'),
(149, 'admin', 'Inventory - New Category', 'New category added (Paint)', '2017-05-10 20:43:42'),
(150, 'admin', 'Inventory - New Product', 'Added new product (1L Paint (Red))', '2017-05-10 20:44:02'),
(151, 'admin', 'Inventory - Delete Category', 'Deleted category (Product Category 3)', '2017-05-10 20:44:07'),
(152, 'admin', 'Inventory - New Product', 'Added new product (1L Paint (Green))', '2017-05-10 20:44:45'),
(153, 'admin', 'Inventory - New Product', 'Added new product (1L Paint Blue)', '2017-05-10 20:44:55'),
(154, 'admin', 'Inventory - New Product', 'Added new product (1L Paint (Black))', '2017-05-10 20:45:17'),
(155, 'admin', 'Inventory - New Product', 'Added new product (1L Paint (White))', '2017-05-10 20:45:55'),
(156, 'admin', 'Inventory - Edit Product', 'Edit Product (1L Paint (Blue))', '2017-05-10 20:46:09'),
(157, 'admin', 'Inventory - New Product', 'Added new product (1L Paint (Yellow))', '2017-05-10 20:46:58'),
(158, 'admin', 'Inventory - New Product', 'Added new product (2L Paint (Red))', '2017-05-10 20:47:15'),
(159, 'admin', 'Inventory - New Product', 'Added new product (2L Paint (Green))', '2017-05-10 20:47:29'),
(160, 'admin', 'Inventory - New Product', 'Added new product (2L Paint (Blue))', '2017-05-10 20:47:47'),
(161, 'admin', 'Inventory - New Product', 'Added new product (2L Paint (Black))', '2017-05-10 20:47:59'),
(162, 'admin', 'Inventory - New Product', 'Added new product (2L Paint (White))', '2017-05-10 20:48:28'),
(163, 'admin', 'Inventory - New Product', 'Added new product (2L Paint (Yellow))', '2017-05-10 20:48:38'),
(164, 'admin', 'Open Logs', 'Opened Logs', '2017-05-10 20:50:03'),
(165, 'admin', 'Open POS', 'Opened POS', '2017-05-10 20:50:07'),
(166, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-10 20:50:17'),
(167, 'admin', 'Open Reports', 'Opened Reports', '2017-05-10 20:51:20'),
(168, 'admin', 'Open Logs', 'Opened Logs', '2017-05-10 20:51:24'),
(169, 'admin', 'Open POS', 'Opened POS', '2017-05-10 20:51:35'),
(170, 'admin', 'POS - Sold Items', 'Sold items with a total value of 1000', '2017-05-10 20:51:54'),
(171, 'admin', 'Open Reports', 'Opened Reports', '2017-05-10 20:51:57'),
(172, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-10 20:52:18'),
(173, 'admin', 'Open Logs', 'Opened Logs', '2017-05-10 20:53:50'),
(174, 'admin', 'Open POS', 'Opened POS', '2017-05-10 20:54:16'),
(175, 'admin', 'Open Logs', 'Opened Logs', '2017-05-10 20:54:23'),
(176, 'admin', 'Open Reports', 'Opened Reports', '2017-05-10 20:54:29'),
(177, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-10 20:54:32'),
(178, 'admin', 'Open Reports', 'Opened Reports', '2017-05-10 20:54:36'),
(179, 'admin', 'Open Reports', 'Opened Reports', '2017-05-10 20:57:54'),
(180, 'admin', 'Open POS', 'Opened POS', '2017-05-10 20:58:06'),
(181, 'admin', 'POS - Sold Items', 'Sold items with a total value of 1000', '2017-05-10 20:58:16'),
(182, 'admin', 'POS - Sold Items', 'Sold items with a total value of 1000', '2017-05-10 20:58:30'),
(183, 'admin', 'POS - Sold Items', 'Sold items with a total value of 1000', '2017-05-10 20:58:41'),
(184, 'admin', 'POS - Sold Items', 'Sold items with a total value of 1000', '2017-05-10 20:58:50'),
(185, 'admin', 'POS - Sold Items', 'Sold items with a total value of 1000', '2017-05-10 20:59:00'),
(186, 'admin', 'POS - Sold Items', 'Sold items with a total value of 500', '2017-05-10 20:59:10'),
(187, 'admin', 'Open Logs', 'Opened Logs', '2017-05-10 20:59:44'),
(188, 'admin', 'Open Reports', 'Opened Reports', '2017-05-10 20:59:49'),
(189, 'admin', 'Logout', 'Logout', '2017-05-10 20:59:54'),
(190, 'admin', 'Login', 'Logged In', '2017-05-10 21:02:09'),
(191, 'admin', 'Open Reports', 'Opened Reports', '2017-05-10 21:02:11'),
(192, 'admin', 'Open POS', 'Opened POS', '2017-05-10 21:02:23'),
(193, 'admin', 'POS - Sold Items', 'Sold items with a total value of 500', '2017-05-10 21:02:36'),
(194, 'admin', 'Open Reports', 'Opened Reports', '2017-05-10 21:02:38'),
(195, 'admin', 'Open POS', 'Opened POS', '2017-05-10 21:02:58'),
(196, 'admin', 'Open Logs', 'Opened Logs', '2017-05-10 21:03:06'),
(197, 'admin', 'Open Admin', 'Opened Admin', '2017-05-10 21:03:08'),
(198, 'admin', 'Logout', 'Logout', '2017-05-10 21:03:16'),
(199, 'admin', 'Login', 'Logged In', '2017-05-10 21:09:55'),
(200, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-10 21:09:56'),
(201, 'admin', 'Inventory - Edit Product', 'Edit Product (2L Paint (Black))', '2017-05-10 21:10:12'),
(202, 'admin', 'Logout', 'Logout', '2017-05-10 21:10:18'),
(203, 'admin', 'Login', 'Logged In', '2017-05-10 21:16:49'),
(204, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-10 21:16:51'),
(205, 'admin', 'Inventory - New Category', 'New category added (paint)', '2017-05-10 21:17:07'),
(206, 'admin', 'Inventory - Delete Category', 'Deleted category (paint)', '2017-05-10 21:17:10'),
(207, 'admin', 'Inventory - New Category', 'New category added ()', '2017-05-10 21:17:15'),
(208, 'admin', 'Inventory - Delete Category', 'Deleted category ()', '2017-05-10 21:17:18'),
(209, 'admin', 'Logout', 'Logout', '2017-05-10 21:17:26'),
(210, 'admin', 'Login', 'Logged In', '2017-05-10 21:21:24'),
(211, 'admin', 'Open Reports', 'Opened Reports', '2017-05-10 21:21:26'),
(212, 'admin', 'Open Logs', 'Opened Logs', '2017-05-10 21:21:47'),
(213, 'admin', 'Open POS', 'Opened POS', '2017-05-10 21:22:52'),
(214, 'admin', 'POS - Sold Items', 'Sold items with a total value of 500', '2017-05-10 21:23:17'),
(215, 'admin', 'Open Reports', 'Opened Reports', '2017-05-10 21:23:21'),
(216, 'admin', 'Logout', 'Logout', '2017-05-10 21:23:25'),
(217, 'admin', 'Login', 'Logged In', '2017-05-10 22:39:14'),
(218, 'admin', 'Open Reports', 'Opened Reports', '2017-05-10 22:39:17'),
(219, 'admin', 'Logout', 'Logout', '2017-05-10 22:39:37'),
(220, 'admin', 'Login', 'Logged In', '2017-05-10 23:03:44'),
(221, 'admin', 'Open Reports', 'Opened Reports', '2017-05-10 23:03:58'),
(222, 'admin', 'Open Logs', 'Opened Logs', '2017-05-10 23:04:39'),
(223, 'admin', 'Logout', 'Logout', '2017-05-10 23:04:59'),
(224, 'caellach', 'Login', 'Logged in', '2017-05-10 23:05:04'),
(225, 'caellach', 'Open POS', 'Opened POS', '2017-05-10 23:05:05'),
(226, 'caellach', 'POS - Sold Items', 'Sold items with a total value of 3000', '2017-05-10 23:05:30'),
(227, 'caellach', 'Logout', 'Logout', '2017-05-10 23:05:35'),
(228, 'admin', 'Login', 'Logged In', '2017-05-10 23:05:40'),
(229, 'admin', 'Open Reports', 'Opened Reports', '2017-05-10 23:05:42'),
(230, 'admin', 'Logout', 'Logout', '2017-05-10 23:06:15'),
(231, 'admin', 'Login', 'Logged In', '2017-05-10 23:07:55'),
(232, 'admin', 'Open Reports', 'Opened Reports', '2017-05-10 23:07:57'),
(233, 'admin', 'Open Logs', 'Opened Logs', '2017-05-10 23:08:19'),
(234, 'admin', 'Open POS', 'Opened POS', '2017-05-10 23:08:22'),
(235, 'admin', 'Open Logs', 'Opened Logs', '2017-05-10 23:08:29'),
(236, 'admin', 'Logout', 'Logout', '2017-05-10 23:08:33'),
(237, 'admin', 'Login', 'Logged In', '2017-05-11 09:27:30'),
(238, 'admin', 'Open POS', 'Opened POS', '2017-05-11 09:27:32'),
(239, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-11 09:28:35'),
(240, 'admin', 'Open Logs', 'Opened Logs', '2017-05-11 09:29:02'),
(241, 'admin', 'Open POS', 'Opened POS', '2017-05-11 09:29:16'),
(242, 'admin', 'POS - Sold Items', 'Sold items with a total value of 500', '2017-05-11 09:29:46'),
(243, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-11 09:30:10'),
(244, 'admin', 'Open Logs', 'Opened Logs', '2017-05-11 09:30:16'),
(245, 'admin', 'Open Reports', 'Opened Reports', '2017-05-11 09:30:33'),
(246, 'admin', 'Open Admin', 'Opened Admin', '2017-05-11 09:31:01'),
(247, 'admin', 'Logout', 'Logout', '2017-05-11 09:31:18'),
(248, 'caellach', 'Login', 'Logged in', '2017-05-11 13:23:46'),
(249, 'caellach', 'Logout', 'Logout', '2017-05-11 13:23:51'),
(250, 'admin', 'Login', 'Logged In', '2017-05-11 13:23:55'),
(251, 'admin', 'Open Logs', 'Opened Logs', '2017-05-11 13:23:57'),
(252, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-11 13:24:21'),
(253, 'admin', 'Inventory - New Category', 'New category added (Door Know)', '2017-05-11 13:24:37'),
(254, 'admin', 'Inventory - Edit Category', 'Edited category (Door Know)', '2017-05-11 13:24:48'),
(255, 'admin', 'Inventory - Delete Category', 'Deleted category (Door Knob)', '2017-05-11 13:24:52'),
(256, 'admin', 'Open Logs', 'Opened Logs', '2017-05-11 13:24:56'),
(257, 'admin', 'Open Reports', 'Opened Reports', '2017-05-11 13:25:17'),
(258, 'admin', 'Logout', 'Logout', '2017-05-11 13:25:58'),
(259, 'admin', 'Login', 'Logged In', '2017-05-11 20:26:17'),
(260, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-11 20:26:19'),
(261, 'admin', 'Inventory - New Category', 'New category added (Nail)', '2017-05-11 20:26:30'),
(262, 'admin', 'Inventory - New Product', 'Added new product (1 Inch Nail)', '2017-05-11 20:26:55'),
(263, 'admin', 'Logout', 'Logout', '2017-05-11 20:27:00'),
(264, 'admin', 'Login', 'Logged In', '2017-05-12 08:54:36'),
(265, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-12 08:54:38'),
(266, 'admin', 'Inventory - New Category', 'New category added (Hammer)', '2017-05-12 08:56:07'),
(267, 'admin', 'Open Logs', 'Opened Logs', '2017-05-12 09:04:13'),
(268, 'admin', 'Open Reports', 'Opened Reports', '2017-05-12 09:04:27'),
(269, 'admin', 'Open Admin', 'Opened Admin', '2017-05-12 09:05:00'),
(270, 'admin', 'Logout', 'Logout', '2017-05-12 09:05:20'),
(271, 'admin', 'Login', 'Logged In', '2017-05-14 18:42:53'),
(272, 'admin', 'Open POS', 'Opened POS', '2017-05-14 18:42:58'),
(273, 'admin', 'Open POS', 'Opened POS', '2017-05-14 18:44:42'),
(274, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-14 18:46:48'),
(275, 'admin', 'Inventory - New Product', 'Added new product (Hammer of Justice)', '2017-05-14 18:48:04'),
(276, 'admin', 'Open POS', 'Opened POS', '2017-05-14 18:48:13'),
(277, 'admin', 'Open Logs', 'Opened Logs', '2017-05-14 18:48:32'),
(278, 'admin', 'Open Reports', 'Opened Reports', '2017-05-14 18:48:42'),
(279, 'admin', 'Open Reports', 'Opened Reports', '2017-05-14 18:49:46'),
(280, 'admin', 'Open POS', 'Opened POS', '2017-05-14 18:50:22'),
(281, 'admin', 'POS - Sold Items', 'Sold items with a total value of 440', '2017-05-14 18:52:02'),
(282, 'admin', 'Open Logs', 'Opened Logs', '2017-05-14 18:52:09'),
(283, 'admin', 'Open Admin', 'Opened Admin', '2017-05-14 18:52:31'),
(284, 'admin', 'Logout', 'Logout', '2017-05-14 18:52:40'),
(285, 'admin', 'Login', 'Logged In', '2017-05-14 19:57:04'),
(286, 'admin', 'Open POS', 'Opened POS', '2017-05-14 19:57:07'),
(287, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-14 19:57:13'),
(288, 'admin', 'Open POS', 'Opened POS', '2017-05-14 19:57:19'),
(289, 'admin', 'Logout', 'Logout', '2017-05-14 19:57:40'),
(290, 'admin', 'Login', 'Logged In', '2017-05-14 21:29:54'),
(291, 'admin', 'Open POS', 'Opened POS', '2017-05-14 21:29:56'),
(292, 'admin', 'Open POS', 'Opened POS', '2017-05-14 21:30:09'),
(293, 'admin', 'Open Logs', 'Opened Logs', '2017-05-14 21:30:15'),
(294, 'admin', 'Open Reports', 'Opened Reports', '2017-05-14 21:30:41'),
(295, 'admin', 'Open Admin', 'Opened Admin', '2017-05-14 21:30:59'),
(296, 'admin', 'Open POS', 'Opened POS', '2017-05-14 21:31:04'),
(297, 'admin', 'Logout', 'Logout', '2017-05-14 21:31:11'),
(298, 'admin', 'Login', 'Logged In', '2017-05-15 10:55:44'),
(299, 'admin', 'Open Admin', 'Opened Admin', '2017-05-15 10:55:47'),
(300, 'admin', 'Admin - New Account', 'New account added (username is caellach2)', '2017-05-15 10:56:16'),
(301, 'admin', 'Admin - Delete Account', 'Deleted account (caellach2)', '2017-05-15 10:56:23'),
(302, 'admin', 'Open Logs', 'Opened Logs', '2017-05-15 10:56:26'),
(303, 'admin', 'Logout', 'Logout', '2017-05-15 10:56:35'),
(304, 'caellach', 'Login', 'Logged in', '2017-05-15 15:00:23'),
(305, 'caellach', 'Logout', 'Logout', '2017-05-15 15:00:35'),
(306, 'admin', 'Login', 'Logged In', '2017-05-15 15:00:40'),
(307, 'admin', 'Open Logs', 'Opened Logs', '2017-05-15 15:00:41'),
(308, 'admin', 'Open POS', 'Opened POS', '2017-05-15 15:00:54'),
(309, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-15 15:00:58'),
(310, 'admin', 'Open Logs', 'Opened Logs', '2017-05-15 15:01:04'),
(311, 'admin', 'Open Reports', 'Opened Reports', '2017-05-15 15:01:18'),
(312, 'admin', 'Open POS', 'Opened POS', '2017-05-15 15:01:24'),
(313, 'admin', 'POS - Sold Items', 'Sold items with a total value of 3004', '2017-05-15 15:02:24'),
(314, 'admin', 'POS - Sold Items', 'Sold items with a total value of 5202', '2017-05-15 15:02:55'),
(315, 'admin', 'Login', 'Logged In', '2017-05-15 15:03:32'),
(316, 'admin', 'Open POS', 'Opened POS', '2017-05-15 15:03:34'),
(317, 'admin', 'POS - Sold Items', 'Sold items with a total value of 2000', '2017-05-15 15:04:08'),
(318, 'admin', 'Open Logs', 'Opened Logs', '2017-05-15 15:04:15'),
(319, 'admin', 'Logout', 'Logout', '2017-05-15 15:04:35'),
(320, 'admin', 'Login', 'Logged In', '2017-05-15 15:07:06'),
(321, 'admin', 'Open Admin', 'Opened Admin', '2017-05-15 15:07:09'),
(322, 'admin', 'Open Reports', 'Opened Reports', '2017-05-15 15:07:12'),
(323, 'admin', 'Logout', 'Logout', '2017-05-15 15:07:20'),
(324, 'admin', 'Login', 'Logged In', '2017-05-15 15:09:30'),
(325, 'admin', 'Open POS', 'Opened POS', '2017-05-15 15:09:34'),
(326, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-15 15:09:39'),
(327, 'admin', 'Open Logs', 'Opened Logs', '2017-05-15 15:09:43'),
(328, 'admin', 'Open Reports', 'Opened Reports', '2017-05-15 15:09:48'),
(329, 'admin', 'Open Admin', 'Opened Admin', '2017-05-15 15:10:09'),
(330, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-15 15:10:17'),
(331, 'admin', 'Open POS', 'Opened POS', '2017-05-15 15:10:24'),
(332, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-15 15:10:28'),
(333, 'admin', 'Logout', 'Logout', '2017-05-15 15:11:24'),
(334, 'admin', 'Login', 'Logged In', '2017-05-15 15:13:48'),
(335, 'admin', 'Open POS', 'Opened POS', '2017-05-15 15:13:52'),
(336, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-15 15:13:55'),
(337, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-15 15:14:03'),
(338, 'admin', 'Inventory - Add Quantity', 'Quantity (2) added to Product (2L Paint (Red))', '2017-05-15 15:14:13'),
(339, 'admin', 'Inventory - Add Quantity', 'Quantity (2) added to Product (2L Paint (Red))', '2017-05-15 15:14:26'),
(340, 'admin', 'Open Logs', 'Opened Logs', '2017-05-15 15:14:32'),
(341, 'admin', 'Open POS', 'Opened POS', '2017-05-15 15:14:41'),
(342, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-15 15:14:44'),
(343, 'admin', 'Inventory - New Product', 'Added new product (2 Inches Nail)', '2017-05-15 15:15:10'),
(344, 'admin', 'Inventory - New Product', 'Added new product (Ace Hammer)', '2017-05-15 15:16:13'),
(345, 'admin', 'Inventory - Delete Product', 'Delete product (Hammer of Justice)', '2017-05-15 15:16:43'),
(346, 'admin', 'Open Logs', 'Opened Logs', '2017-05-15 15:16:52'),
(347, 'admin', 'Open POS', 'Opened POS', '2017-05-15 15:16:56'),
(348, 'admin', 'POS - Sold Items', 'Sold items with a total value of 3336', '2017-05-15 15:18:11'),
(349, 'admin', 'Logout', 'Logout', '2017-05-15 15:18:32'),
(350, 'admin', 'Login', 'Logged In', '2017-05-16 06:44:14'),
(351, 'admin', 'Open Reports', 'Opened Reports', '2017-05-16 06:44:18'),
(352, 'admin', 'Open POS', 'Opened POS', '2017-05-16 06:45:52'),
(353, 'admin', 'POS - Sold Items', 'Sold items with a total value of 9178', '2017-05-16 06:46:53'),
(354, 'admin', 'Logout', 'Logout', '2017-05-16 06:47:55'),
(355, 'admin', 'Login', 'Logged In', '2017-05-16 09:47:37'),
(356, 'admin', 'Logout', 'Logout', '2017-05-16 09:48:00'),
(357, 'admin', 'Login', 'Logged In', '2017-05-16 10:49:17'),
(358, 'admin', 'Open Logs', 'Opened Logs', '2017-05-16 10:49:48'),
(359, 'admin', 'Open Logs', 'Opened Logs', '2017-05-16 10:50:04'),
(360, 'admin', 'Open Inventory', 'Opened Inventory', '2017-05-16 10:50:07'),
(361, 'admin', 'Open POS', 'Opened POS', '2017-05-16 10:50:17'),
(362, 'admin', 'Open Reports', 'Opened Reports', '2017-05-16 10:50:33'),
(363, 'admin', 'Logout', 'Logout', '2017-05-16 10:50:55'),
(364, 'admin', 'Login', 'Logged In', '2017-09-04 12:28:14'),
(365, 'admin', 'Open Logs', 'Opened Logs', '2017-09-04 12:28:19'),
(366, 'admin', 'Open Inventory', 'Opened Inventory', '2017-09-04 12:28:27'),
(367, 'admin', 'Open POS', 'Opened POS', '2017-09-04 12:28:39'),
(368, 'admin', 'Open Inventory', 'Opened Inventory', '2017-09-04 12:28:57'),
(369, 'admin', 'Open Logs', 'Opened Logs', '2017-09-04 12:29:08'),
(370, 'admin', 'Open Reports', 'Opened Reports', '2017-09-04 12:29:11'),
(371, 'admin', 'Open Admin', 'Opened Admin', '2017-09-04 12:29:38'),
(372, 'admin', 'Logout', 'Logout', '2017-09-04 12:29:47'),
(373, 'admin', 'Login', 'Logged In', '2017-09-09 10:32:42'),
(374, 'admin', 'Open POS', 'Opened POS', '2017-09-09 10:32:44'),
(375, 'admin', 'Open Inventory', 'Opened Inventory', '2017-09-09 10:32:59'),
(376, 'admin', 'Logout', 'Logout', '2017-09-09 10:33:08'),
(377, 'admin', 'Login', 'Logged In', '2017-09-11 08:54:59'),
(378, 'admin', 'Open Inventory', 'Opened Inventory', '2017-09-11 08:55:01'),
(379, 'admin', 'Logout', 'Logout', '2017-09-11 08:55:06'),
(380, 'admin', 'Login', 'Logged In', '2017-10-09 13:52:42'),
(381, 'admin', 'Open POS', 'Opened POS', '2017-10-09 13:52:44'),
(382, 'admin', 'Open Inventory', 'Opened Inventory', '2017-10-09 13:52:52'),
(383, 'admin', 'Open Logs', 'Opened Logs', '2017-10-09 13:53:18'),
(384, 'admin', 'Open Reports', 'Opened Reports', '2017-10-09 13:53:22'),
(385, 'admin', 'Open Admin', 'Opened Admin', '2017-10-09 13:53:43'),
(386, 'admin', 'Logout', 'Logout', '2017-10-09 13:54:00'),
(387, 'admin', 'Login', 'Logged In', '2017-10-10 13:46:43'),
(388, 'admin', 'Open Reports', 'Opened Reports', '2017-10-10 13:46:45'),
(389, 'admin', 'Logout', 'Logout', '2017-10-10 13:47:32'),
(390, 'admin', 'Login', 'Logged In', '2017-10-10 13:49:09'),
(391, 'admin', 'Open Reports', 'Opened Reports', '2017-10-10 13:49:11'),
(392, 'admin', 'Logout', 'Logout', '2017-10-10 13:49:20'),
(393, 'admin', 'Login', 'Logged In', '2018-05-17 22:04:31'),
(394, 'admin', 'Open POS', 'Opened POS', '2018-05-17 22:04:36'),
(395, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-17 22:05:11'),
(396, 'admin', 'Open Logs', 'Opened Logs', '2018-05-17 22:05:18'),
(397, 'admin', 'Open Admin', 'Opened Admin', '2018-05-17 22:05:30'),
(398, 'admin', 'Open Reports', 'Opened Reports', '2018-05-17 22:05:34'),
(399, 'admin', 'Open POS', 'Opened POS', '2018-05-17 22:05:40'),
(400, 'admin', 'Open Reports', 'Opened Reports', '2018-05-17 22:06:13'),
(401, 'admin', 'Open Logs', 'Opened Logs', '2018-05-17 22:06:18'),
(402, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-17 22:06:21'),
(403, 'admin', 'Logout', 'Logout', '2018-05-17 22:06:35'),
(404, 'admin', 'Login', 'Logged In', '2018-05-19 16:34:21'),
(405, 'admin', 'Open Reports', 'Opened Reports', '2018-05-19 16:34:34'),
(406, 'admin', 'Open POS', 'Opened POS', '2018-05-19 16:35:27'),
(407, 'admin', 'Open Logs', 'Opened Logs', '2018-05-19 16:35:53'),
(408, 'admin', 'Open Reports', 'Opened Reports', '2018-05-19 16:35:58'),
(409, 'admin', 'Open POS', 'Opened POS', '2018-05-19 16:36:11'),
(410, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-19 16:36:36'),
(411, 'admin', 'Open Logs', 'Opened Logs', '2018-05-19 16:36:46'),
(412, 'admin', 'Open Reports', 'Opened Reports', '2018-05-19 16:36:53'),
(413, 'admin', 'Open Admin', 'Opened Admin', '2018-05-19 16:36:56'),
(414, 'admin', 'Logout', 'Logout', '2018-05-19 16:37:47'),
(415, 'admin', 'Login', 'Logged In', '2018-05-19 16:40:31'),
(416, 'admin', 'Open POS', 'Opened POS', '2018-05-19 16:40:33'),
(417, 'admin', 'Open Reports', 'Opened Reports', '2018-05-19 16:40:47'),
(418, 'admin', 'Logout', 'Logout', '2018-05-19 16:41:21'),
(419, 'admin', 'Login', 'Logged In', '2018-05-19 16:47:50'),
(420, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-19 16:47:56'),
(421, 'admin', 'Open Logs', 'Opened Logs', '2018-05-19 16:48:10'),
(422, 'admin', 'Login', 'Logged In', '2018-05-19 16:52:21'),
(423, 'admin', 'Open POS', 'Opened POS', '2018-05-19 16:52:23'),
(424, 'admin', 'Open POS', 'Opened POS', '2018-05-19 16:52:38'),
(425, 'admin', 'Logout', 'Logout', '2018-05-19 16:53:20'),
(426, 'admin', 'Login', 'Logged In', '2018-05-19 17:03:26'),
(427, 'admin', 'Open POS', 'Opened POS', '2018-05-19 17:03:29'),
(428, 'admin', 'POS - Sold Items', 'Sold items with a total value of 1503', '2018-05-19 17:03:46'),
(429, 'admin', 'Open Reports', 'Opened Reports', '2018-05-19 17:04:01'),
(430, 'admin', 'Open POS', 'Opened POS', '2018-05-19 17:04:16'),
(431, 'admin', 'Open Reports', 'Opened Reports', '2018-05-19 17:04:30'),
(432, 'admin', 'Open POS', 'Opened POS', '2018-05-18 17:05:50'),
(433, 'admin', 'POS - Sold Items', 'Sold items with a total value of 3000', '2018-05-18 17:06:00'),
(434, 'admin', 'Open Reports', 'Opened Reports', '2018-05-18 17:06:13'),
(435, 'admin', 'Open POS', 'Opened POS', '2018-05-18 17:06:45'),
(436, 'admin', 'POS - Sold Items', 'Sold items with a total value of 501', '2018-05-18 17:06:52'),
(437, 'admin', 'Open Reports', 'Opened Reports', '2018-05-18 17:06:56'),
(438, 'admin', 'Open Logs', 'Opened Logs', '2018-05-19 17:08:22'),
(439, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-19 17:08:42'),
(440, 'admin', 'Inventory - New Product', 'Added new product (3 Inches Nail)', '2018-05-19 17:09:47'),
(441, 'admin', 'Open POS', 'Opened POS', '2018-05-19 17:09:53'),
(442, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-19 17:09:59'),
(443, 'admin', 'Open Reports', 'Opened Reports', '2018-05-19 17:10:04'),
(444, 'admin', 'Open Admin', 'Opened Admin', '2018-05-19 17:10:08'),
(445, 'admin', 'Logout', 'Logout', '2018-05-19 17:10:34'),
(446, 'admin', 'Login', 'Logged In', '2018-05-19 19:42:09'),
(447, 'admin', 'Login', 'Logged In', '2018-05-19 20:09:21'),
(448, 'admin', 'Login', 'Logged In', '2018-05-19 20:12:26'),
(449, 'admin', 'Login', 'Logged In', '2018-05-19 20:54:19'),
(450, 'admin', 'Login', 'Logged In', '2018-05-19 21:34:55'),
(451, 'admin', 'Login', 'Logged In', '2018-05-19 23:02:49'),
(452, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-19 23:03:08'),
(453, 'admin', 'Open Reports', 'Opened Reports', '2018-05-19 23:03:17'),
(454, 'admin', 'Login', 'Logged In', '2018-05-19 23:46:20'),
(455, 'admin', 'Open POS', 'Opened POS', '2018-05-19 23:46:23'),
(456, 'admin', 'POS - Sold Items', 'Sold items with a total value of 2001', '2018-05-19 23:47:09'),
(457, 'admin', 'Open Logs', 'Opened Logs', '2018-05-19 23:48:17'),
(458, 'admin', 'Login', 'Logged In', '2018-05-19 23:53:29'),
(459, 'admin', 'Open Logs', 'Opened Logs', '2018-05-19 23:53:41'),
(460, 'admin', 'Open Logs', 'Opened Logs', '2018-05-19 23:53:55'),
(461, 'admin', 'Login', 'Logged In', '2018-05-19 23:58:24'),
(462, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-19 23:58:30'),
(463, 'admin', 'Open Logs', 'Opened Logs', '2018-05-19 23:58:48'),
(464, 'admin', 'Open Reports', 'Opened Reports', '2018-05-19 23:58:53'),
(465, 'admin', 'Open Admin', 'Opened Admin', '2018-05-19 23:58:56'),
(466, 'admin', 'Logout', 'Logout', '2018-05-19 23:59:03'),
(467, 'admin', 'Login', 'Logged In', '2018-05-20 00:39:28'),
(468, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 00:39:35'),
(469, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 00:39:39'),
(470, 'admin', 'Login', 'Logged In', '2018-05-20 00:40:52'),
(471, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 00:40:54'),
(472, 'admin', 'Logout', 'Logout', '2018-05-20 00:41:05'),
(473, 'admin', 'Logout', 'Logout', '2018-05-20 00:41:05'),
(474, 'admin', 'Login', 'Logged In', '2018-05-20 00:46:51'),
(475, 'admin', 'Open POS', 'Opened POS', '2018-05-20 00:46:52'),
(476, 'admin', 'Open POS', 'Opened POS', '2018-05-20 00:46:58'),
(477, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 00:47:01'),
(478, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 00:47:05'),
(479, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 00:47:08'),
(480, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 00:47:10'),
(481, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 00:47:14'),
(482, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 00:47:16'),
(483, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 00:47:17'),
(484, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 00:47:19'),
(485, 'admin', 'Open POS', 'Opened POS', '2018-05-20 00:47:22'),
(486, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 00:47:25'),
(487, 'admin', 'Open POS', 'Opened POS', '2018-05-20 00:47:54'),
(488, 'admin', 'Login', 'Logged In', '2018-05-20 00:48:17'),
(489, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 00:48:19'),
(490, 'admin', 'Login', 'Logged In', '2018-05-20 00:48:36'),
(491, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 00:48:37'),
(492, 'admin', 'Logout', 'Logout', '2018-05-20 00:48:48'),
(493, 'admin', 'Logout', 'Logout', '2018-05-20 00:48:49'),
(494, 'admin', 'Login', 'Logged In', '2018-05-20 01:14:32'),
(495, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 01:14:33'),
(496, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 01:14:41'),
(497, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 01:14:43'),
(498, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 01:14:52'),
(499, 'admin', 'Logout', 'Logout', '2018-05-20 01:15:06'),
(500, 'admin', 'Logout', 'Logout', '2018-05-20 01:15:07'),
(501, 'admin', 'Login', 'Logged In', '2018-05-20 01:16:40'),
(502, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 01:16:41'),
(503, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 01:16:43'),
(504, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 01:16:45'),
(505, 'admin', 'Logout', 'Logout', '2018-05-20 01:17:02'),
(506, 'admin', 'Login', 'Logged In', '2018-05-20 01:26:48'),
(507, 'admin', 'Logout', 'Logout', '2018-05-20 01:26:56'),
(508, 'admin', 'Login', 'Logged In', '2018-05-20 01:27:05'),
(509, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 01:27:13'),
(510, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 01:32:26'),
(511, 'admin', 'Logout', 'Logout', '2018-05-20 01:32:36'),
(512, 'admin', 'Login', 'Logged In', '2018-05-20 01:32:41'),
(513, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 01:32:42'),
(514, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 01:32:46'),
(515, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 01:32:49'),
(516, 'admin', 'Open POS', 'Opened POS', '2018-05-20 01:32:57'),
(517, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 01:33:01'),
(518, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 01:33:03'),
(519, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 01:33:06'),
(520, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 01:33:08'),
(521, 'admin', 'Logout', 'Logout', '2018-05-20 01:33:14'),
(522, 'admin', 'Login', 'Logged In', '2018-05-20 01:44:36'),
(523, 'admin', 'Open POS', 'Opened POS', '2018-05-20 01:44:50'),
(524, 'admin', 'Logout', 'Logout', '2018-05-20 01:45:16'),
(525, 'admin', 'Login', 'Logged In', '2018-05-20 01:46:13'),
(526, 'admin', 'Open POS', 'Opened POS', '2018-05-20 01:46:14'),
(527, 'admin', 'POS - Sold Items', 'Sold items with a total value of 4043', '2018-05-20 01:46:30'),
(528, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 01:46:38'),
(529, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 01:46:44'),
(530, 'admin', 'Open POS', 'Opened POS', '2018-05-20 01:46:52'),
(531, 'admin', 'Logout', 'Logout', '2018-05-20 01:47:01'),
(532, 'admin', 'Logout', 'Logout', '2018-05-20 01:47:01'),
(533, 'admin', 'Login', 'Logged In', '2018-05-20 02:00:30'),
(534, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 02:00:33'),
(535, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 02:00:56'),
(536, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 02:00:58'),
(537, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 02:01:01'),
(538, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 02:01:03'),
(539, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 02:01:07'),
(540, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 02:01:09'),
(541, 'admin', 'Open POS', 'Opened POS', '2018-05-20 02:01:12'),
(542, 'admin', 'Logout', 'Logout', '2018-05-20 02:03:20'),
(543, 'admin', 'Logout', 'Logout', '2018-05-20 02:03:20'),
(544, 'admin', 'Login', 'Logged In', '2018-05-20 02:04:37'),
(545, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 02:05:25'),
(546, 'admin', 'Admin - New Account', 'New account added (username is yorn)', '2018-05-20 02:05:56'),
(547, 'yorn', 'Login', 'Logged In', '2018-05-20 02:06:11'),
(548, 'yorn', 'Open POS', 'Opened POS', '2018-05-20 02:06:15'),
(549, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 02:06:21'),
(550, 'admin', 'Inventory - New Product', 'Added new product (4 Inches Nail)', '2018-05-20 02:06:39'),
(551, 'yorn', 'Open POS', 'Opened POS', '2018-05-20 02:06:52'),
(552, 'yorn', 'Open Inventory', 'Opened Inventory', '2018-05-20 02:06:56'),
(553, 'yorn', 'Open POS', 'Opened POS', '2018-05-20 02:07:04'),
(554, 'yorn', 'Open Inventory', 'Opened Inventory', '2018-05-20 02:07:07'),
(555, 'yorn', 'Open Logs', 'Opened Logs', '2018-05-20 02:07:17'),
(556, 'admin', 'Logout', 'Logout', '2018-05-20 02:07:28'),
(557, 'admin', 'Login', 'Logged In', '2018-05-20 12:06:45'),
(558, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 12:06:47'),
(559, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 12:08:06'),
(560, 'admin', 'Open POS', 'Opened POS', '2018-05-20 12:08:34'),
(561, 'admin', 'POS - Sold Items', 'Sold items with a total value of 17000', '2018-05-20 12:08:49'),
(562, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 12:09:04'),
(563, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 12:09:18'),
(564, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:09:20'),
(565, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 12:09:24'),
(566, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 12:09:26'),
(567, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:09:30'),
(568, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 12:09:35'),
(569, 'admin', 'Inventory - Add Quantity', 'Quantity (22) added to Product (1L Paint (Red))', '2018-05-20 12:09:51'),
(570, 'admin', 'Logout', 'Logout', '2018-05-20 12:10:09'),
(571, 'admin', 'Logout', 'Logout', '2018-05-20 12:10:09'),
(572, 'admin', 'Login', 'Logged In', '2018-05-20 12:18:35'),
(573, 'admin', 'Logout', 'Logout', '2018-05-20 12:18:45'),
(574, 'admin', 'Login', 'Logged In', '2018-05-20 12:18:48'),
(575, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 12:18:50'),
(576, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:18:57'),
(577, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:19:55'),
(578, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 12:19:57'),
(579, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 12:20:08'),
(580, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 12:20:11'),
(581, 'admin', 'Open POS', 'Opened POS', '2018-05-20 12:20:25'),
(582, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:20:31'),
(583, 'admin', 'Logout', 'Logout', '2018-05-20 12:20:35'),
(584, 'admin', 'Logout', 'Logout', '2018-05-20 12:20:36'),
(585, 'admin', 'Login', 'Logged In', '2018-05-20 12:29:27'),
(586, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 12:29:29'),
(587, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:29:31'),
(588, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 12:29:46'),
(589, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 12:29:51'),
(590, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 12:29:55'),
(591, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:29:59'),
(592, 'admin', 'Login', 'Logged In', '2018-05-20 12:34:51'),
(593, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:35:00'),
(594, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:35:03'),
(595, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:35:05'),
(596, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:35:07'),
(597, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:35:10'),
(598, 'admin', 'Logout', 'Logout', '2018-05-20 12:35:15'),
(599, 'admin', 'Login', 'Logged In', '2018-05-20 12:35:51'),
(600, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:35:52'),
(601, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:35:56'),
(602, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:35:58'),
(603, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:36:00'),
(604, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:36:02'),
(605, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:36:05'),
(606, 'admin', 'Logout', 'Logout', '2018-05-20 12:36:07'),
(607, 'admin', 'Login', 'Logged In', '2018-05-20 12:37:59'),
(608, 'admin', 'Open POS', 'Opened POS', '2018-05-20 12:38:00'),
(609, 'admin', 'Open POS', 'Opened POS', '2018-05-20 12:38:05'),
(610, 'admin', 'Open POS', 'Opened POS', '2018-05-20 12:38:09'),
(611, 'admin', 'Open POS', 'Opened POS', '2018-05-20 12:38:19'),
(612, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 12:38:25'),
(613, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 12:38:29'),
(614, 'admin', 'Login', 'Logged In', '2018-05-20 12:40:13'),
(615, 'admin', 'Logout', 'Logout', '2018-05-20 12:40:34'),
(616, 'admin', 'Login', 'Logged In', '2018-05-20 12:53:43'),
(617, 'admin', 'Open POS', 'Opened POS', '2018-05-20 12:53:48'),
(618, 'admin', 'Open POS', 'Opened POS', '2018-05-20 12:53:52'),
(619, 'admin', 'Open POS', 'Opened POS', '2018-05-20 12:53:54'),
(620, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 12:53:56'),
(621, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 12:53:59'),
(622, 'admin', 'Inventory - New Product', 'Added new product (5 Inches Nail)', '2018-05-20 12:54:17'),
(623, 'admin', 'Open POS', 'Opened POS', '2018-05-20 12:54:19'),
(624, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 12:54:35'),
(625, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 12:54:58'),
(626, 'admin', 'Inventory - New Category', 'New category added (asd)', '2018-05-20 12:55:04'),
(627, 'admin', 'Inventory - New Product', 'Added new product (qwe)', '2018-05-20 12:55:13'),
(628, 'admin', 'Inventory - New Product', 'Added new product (ee)', '2018-05-20 12:55:20'),
(629, 'admin', 'Inventory - Delete Category', 'Deleted category (asd)', '2018-05-20 12:55:27'),
(630, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:55:33'),
(631, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:55:36'),
(632, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:55:39'),
(633, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:55:44'),
(634, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 12:55:46'),
(635, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 12:55:48'),
(636, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 12:55:56'),
(637, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 12:55:58'),
(638, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 12:56:03'),
(639, 'admin', 'Logout', 'Logout', '2018-05-20 12:56:08'),
(640, 'admin', 'Login', 'Logged In', '2018-05-20 12:56:14'),
(641, 'admin', 'Open POS', 'Opened POS', '2018-05-20 12:56:15'),
(642, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 12:56:20'),
(643, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 12:56:28'),
(644, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 12:56:32'),
(645, 'admin', 'Logout', 'Logout', '2018-05-20 12:56:35'),
(646, 'admin', 'Login', 'Logged In', '2018-05-20 12:59:09'),
(647, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 12:59:12'),
(648, 'admin', 'Logout', 'Logout', '2018-05-20 12:59:33'),
(649, 'admin', 'Login', 'Logged In', '2018-05-20 13:00:51'),
(650, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 13:00:54'),
(651, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 13:01:07'),
(652, 'admin', 'Login', 'Logged In', '2018-05-20 13:02:08'),
(653, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 13:02:09'),
(654, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 13:02:17'),
(655, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 13:02:21'),
(656, 'admin', 'Open POS', 'Opened POS', '2018-05-20 13:02:49'),
(657, 'admin', 'POS - Sold Items', 'Sold items with a total value of 1001', '2018-05-20 13:02:58'),
(658, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 13:03:02'),
(659, 'admin', 'Logout', 'Logout', '2018-05-20 13:03:18'),
(660, 'admin', 'Logout', 'Logout', '2018-05-20 13:03:18'),
(661, 'admin', 'Login', 'Logged In', '2018-05-20 13:41:41'),
(662, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 13:42:00'),
(663, 'admin', 'Login', 'Logged In', '2018-05-20 15:08:07'),
(664, 'admin', 'Open POS', 'Opened POS', '2018-05-20 15:08:18'),
(665, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 15:08:55'),
(666, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 15:09:04'),
(667, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 15:09:14'),
(668, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 15:09:37'),
(669, 'admin', 'Logout', 'Logout', '2018-05-20 15:09:47'),
(670, 'admin', 'Logout', 'Logout', '2018-05-20 15:09:47'),
(671, 'admin', 'Login', 'Logged In', '2018-05-20 23:15:56'),
(672, 'admin', 'Open POS', 'Opened POS', '2018-05-20 23:15:59'),
(673, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 23:16:04'),
(674, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 23:16:15'),
(675, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 23:16:36'),
(676, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 23:16:51'),
(677, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 23:17:23'),
(678, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 23:17:27'),
(679, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 23:17:31'),
(680, 'admin', 'Open POS', 'Opened POS', '2018-05-20 23:17:36'),
(681, 'admin', 'POS - Sold Items', 'Sold items with a total value of 12521', '2018-05-20 23:18:10'),
(682, 'admin', 'Open Admin', 'Opened Admin', '2018-05-20 23:18:31'),
(683, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 23:18:46'),
(684, 'admin', 'Inventory - New Category', 'New category added (sd)', '2018-05-20 23:19:05'),
(685, 'admin', 'Inventory - Delete Category', 'Deleted category (sd)', '2018-05-20 23:19:41'),
(686, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 23:19:46'),
(687, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 23:20:04'),
(688, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 23:20:12'),
(689, 'admin', 'Open POS', 'Opened POS', '2018-05-20 23:20:23'),
(690, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 23:20:44'),
(691, 'admin', 'Logout', 'Logout', '2018-05-20 23:21:08'),
(692, 'admin', 'Logout', 'Logout', '2018-05-20 23:21:08'),
(693, 'employee', 'Login', 'Logged in', '2018-05-20 23:24:38'),
(694, 'employee', 'Open POS', 'Opened POS', '2018-05-20 23:24:49'),
(695, 'employee', 'Logout', 'Logout', '2018-05-20 23:25:17'),
(696, 'admin', 'Login', 'Logged In', '2018-05-20 23:25:20'),
(697, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 23:25:23'),
(698, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 23:25:28'),
(699, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 23:25:42'),
(700, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 23:26:38'),
(701, 'admin', 'Open Logs', 'Opened Logs', '2018-05-20 23:26:42'),
(702, 'admin', 'Open Inventory', 'Opened Inventory', '2018-05-20 23:26:48'),
(703, 'admin', 'Open Reports', 'Opened Reports', '2018-05-20 23:26:55'),
(704, 'admin', 'Logout', 'Logout', '2018-05-20 23:57:46'),
(705, 'admin', 'Logout', 'Logout', '2018-05-20 23:57:46'),
(706, 'employee', 'Login', 'Logged in', '2018-05-21 17:09:21'),
(707, 'admin', 'Login', 'Logged in', '2018-05-21 19:37:43'),
(708, 'admin', 'Login', 'Logged in', '2018-05-21 20:10:57'),
(709, 'admin', 'Login', 'Logged In', '2018-08-22 11:58:59'),
(710, 'admin', 'Open POS', 'Opened POS', '2018-08-22 11:59:06'),
(711, 'admin', 'POS - Sold Items', 'Sold items with a total value of 11616', '2018-08-22 11:59:38'),
(712, 'admin', 'Open Inventory', 'Opened Inventory', '2018-08-22 12:00:14'),
(713, 'admin', 'Open Logs', 'Opened Logs', '2018-08-22 12:00:41'),
(714, 'admin', 'Open Reports', 'Opened Reports', '2018-08-22 12:00:47'),
(715, 'admin', 'Open POS', 'Opened POS', '2018-08-22 12:01:10'),
(716, 'admin', 'Open Reports', 'Opened Reports', '2018-08-22 12:01:14'),
(717, 'admin', 'Open Reports', 'Opened Reports', '2018-08-22 12:01:39'),
(718, 'admin', 'Open Admin', 'Opened Admin', '2018-08-22 12:01:42'),
(719, 'admin', 'Logout', 'Logout', '2018-08-22 12:01:51');

-- --------------------------------------------------------

--
-- Table structure for table `phptemptbl`
--

CREATE TABLE `phptemptbl` (
  `productname` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `productcategorytbl`
--

CREATE TABLE `productcategorytbl` (
  `productcategoryid` int(11) NOT NULL,
  `productcategoryname` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `productcategorytbl`
--

INSERT INTO `productcategorytbl` (`productcategoryid`, `productcategoryname`) VALUES
(19, 'Paint'),
(21, 'Nail'),
(22, 'Hammer');

-- --------------------------------------------------------

--
-- Table structure for table `productpurchasestbl`
--

CREATE TABLE `productpurchasestbl` (
  `id` int(11) NOT NULL,
  `productname` varchar(50) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `datepurchased` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `productpurchasestbl`
--

INSERT INTO `productpurchasestbl` (`id`, `productname`, `quantity`, `datepurchased`) VALUES
(23, '1L Paint (Red)', 1, '2016-05-10 20:51:54'),
(24, '1L Paint (Red)', 1, '2014-05-10 20:58:15'),
(25, '1L Paint (Red)', 1, '2017-03-10 20:58:30'),
(26, '2L Paint (Blue)', 1, '2017-05-10 20:58:41'),
(27, '2L Paint (Green)', 1, '2017-05-10 20:58:50'),
(28, '1L Paint (Red)', 1, '2017-05-10 20:59:00'),
(29, '1L Paint (Yellow)', 1, '2017-05-10 20:59:10'),
(30, '1L Paint (Red)', 1, '2017-05-09 21:02:36'),
(31, '1L Paint (Red)', 1, '2017-05-10 21:23:17'),
(32, '2L Paint (Red)', 3, '2017-05-10 23:05:30'),
(33, '1L Paint (Yellow)', 1, '2017-05-11 09:29:45'),
(34, 'Hammer of Justice', 2, '2017-05-14 18:52:01'),
(35, '1 Inch Nail', 20, '2017-05-14 18:52:02'),
(36, '2L Paint (Yellow)', 1, '2017-05-15 15:02:23'),
(37, '1 Inch Nail', 2, '2017-05-15 15:02:23'),
(38, '2L Paint (Red)', 2, '2017-05-15 15:02:23'),
(39, '2L Paint (Yellow)', 2, '2017-05-15 15:02:54'),
(40, '1 Inch Nail', 1, '2017-05-15 15:02:54'),
(41, 'Hammer of Justice', 1, '2017-05-15 15:02:54'),
(42, '2L Paint (Blue)', 1, '2017-05-15 15:02:55'),
(43, '2L Paint (Green)', 1, '2017-05-15 15:02:55'),
(44, '2L Paint (Red)', 1, '2017-05-15 15:02:55'),
(45, '2L Paint (Red)', 1, '2017-05-15 15:04:07'),
(46, '2L Paint (Green)', 1, '2017-05-15 15:04:08'),
(47, '2 Inches Nail', 7, '2017-05-15 15:18:09'),
(48, '1 Inch Nail', 6, '2017-05-15 15:18:09'),
(49, '1L Paint (Red)', 1, '2017-05-15 15:18:10'),
(50, '1L Paint (Green)', 1, '2017-05-15 15:18:10'),
(51, '1L Paint (Blue)', 1, '2017-05-15 15:18:10'),
(52, '1L Paint (Black)', 1, '2017-05-15 15:18:10'),
(53, '1L Paint (White)', 1, '2017-05-15 15:18:10'),
(54, '1L Paint (Yellow)', 1, '2017-05-15 15:18:10'),
(55, 'Ace Hammer', 2, '2017-05-15 15:18:10'),
(56, '1L Paint (Red)', 1, '2017-05-16 06:46:52'),
(57, '1L Paint (Green)', 1, '2017-05-16 06:46:52'),
(58, '1L Paint (Blue)', 1, '2017-05-16 06:46:52'),
(59, '1L Paint (Black)', 1, '2017-05-16 06:46:52'),
(60, '1L Paint (White)', 1, '2017-05-16 06:46:52'),
(61, '2L Paint (Black)', 1, '2017-05-16 06:46:52'),
(62, '2L Paint (Blue)', 1, '2017-05-16 06:46:53'),
(63, '2L Paint (Green)', 1, '2017-05-16 06:46:53'),
(64, '2L Paint (Red)', 1, '2017-05-16 06:46:53'),
(65, '1L Paint (Yellow)', 1, '2017-05-16 06:46:53'),
(66, '2L Paint (White)', 1, '2017-05-16 06:46:53'),
(67, '2L Paint (Yellow)', 1, '2017-05-16 06:46:53'),
(68, '1 Inch Nail', 5, '2017-05-16 06:46:53'),
(69, '2 Inches Nail', 5, '2017-05-16 06:46:53'),
(70, 'Ace Hammer', 1, '2017-05-16 06:46:53'),
(71, '1L Paint (Red)', 3, '2018-05-19 17:03:46'),
(72, '1L Paint (Green)', 6, '2018-05-18 17:06:00'),
(73, '1L Paint (Red)', 1, '2018-05-18 17:06:52'),
(74, '1L Paint (Red)', 1, '2018-05-19 23:47:08'),
(75, '1L Paint (Green)', 3, '2018-05-19 23:47:08'),
(76, '2L Paint (Red)', 1, '2018-05-20 01:46:30'),
(77, '2L Paint (White)', 3, '2018-05-20 01:46:30'),
(78, '3 Inches Nail', 1, '2018-05-20 01:46:30'),
(79, '2L Paint (Blue)', 17, '2018-05-20 12:08:49'),
(80, '1L Paint (Red)', 1, '2018-05-20 13:02:58'),
(81, '1L Paint (Green)', 1, '2018-05-20 13:02:58'),
(82, '2L Paint (Yellow)', 2, '2018-05-20 23:18:10'),
(83, '1L Paint (Red)', 21, '2018-05-20 23:18:10'),
(84, '1L Paint (Red)', 1, '2018-05-21 17:21:43'),
(85, '1L Paint (Green)', 1, '2018-05-21 17:21:43'),
(86, '1L Paint (Green)', 1, '2018-05-21 17:21:44'),
(87, '1L Paint (Green)', 1, '2018-05-21 17:21:44'),
(88, '4 Inches Nail', 1, '2018-05-21 17:22:11'),
(89, '4 Inches Nail', 1, '2018-05-21 17:22:11'),
(90, '4 Inches Nail', 1, '2018-05-21 17:22:58'),
(91, '5 Inches Nail', 1, '2018-05-21 17:22:58'),
(92, '5 Inches Nail', 1, '2018-05-21 17:22:58'),
(93, '5 Inches Nail', 1, '2018-05-21 17:24:11'),
(94, '5 Inches Nail', 1, '2018-05-21 17:25:24'),
(95, '5 Inches Nail', 1, '2018-05-21 17:27:03'),
(96, '2L Paint (Red)', 1, '2018-08-22 11:59:36'),
(97, '2L Paint (Yellow)', 10, '2018-08-22 11:59:37'),
(98, '5 Inches Nail', 1, '2018-08-22 11:59:37'),
(99, '4 Inches Nail', 6, '2018-08-22 11:59:37');

-- --------------------------------------------------------

--
-- Table structure for table `producttbl`
--

CREATE TABLE `producttbl` (
  `productid` int(11) NOT NULL,
  `productname` varchar(200) DEFAULT NULL,
  `productcategoryid` int(11) DEFAULT NULL,
  `productquantity` int(11) DEFAULT NULL,
  `productprice` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `producttbl`
--

INSERT INTO `producttbl` (`productid`, `productname`, `productcategoryid`, `productquantity`, `productprice`) VALUES
(45, '1L Paint (Red)', 19, -1, 501),
(46, '1L Paint (Green)', 19, 3, 500),
(47, '1L Paint (Blue)', 19, 18, 500),
(48, '1L Paint (Black)', 19, 18, 500),
(49, '1L Paint (White)', 19, 18, 502),
(50, '1L Paint (Yellow)', 19, 16, 500),
(51, '2L Paint (Red)', 19, 13, 1000),
(52, '2L Paint (Green)', 19, 16, 1000),
(53, '2L Paint (Blue)', 19, 0, 1000),
(54, '2L Paint (Black)', 19, 18, 1000),
(55, '2L Paint (White)', 19, 13, 1000),
(56, '2L Paint (Yellow)', 19, 1, 1000),
(57, '1 Inch Nail', 21, 166, 2),
(59, '2 Inches Nail', 21, 188, 3),
(60, 'Ace Hammer', 22, 7, 150),
(61, '3 Inches Nail', 21, 2, 43),
(62, '4 Inches Nail', 21, 0, 99),
(63, '5 Inches Nail', 21, 4, 22);

-- --------------------------------------------------------

--
-- Table structure for table `salestbl`
--

CREATE TABLE `salestbl` (
  `id` int(11) NOT NULL,
  `sold` int(11) DEFAULT NULL,
  `dateandtime` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `salestbl`
--

INSERT INTO `salestbl` (`id`, `sold`, `dateandtime`) VALUES
(27, 1000, '2017-05-04'),
(28, 1000, '2017-05-05'),
(29, 1000, '2017-05-06'),
(30, 1000, '2017-05-08'),
(31, 1000, '2017-05-09'),
(32, 1000, '2017-05-10'),
(33, 500, '2017-05-07'),
(34, 500, '2017-05-10'),
(35, 500, '2017-05-10'),
(36, 3000, '2017-05-10'),
(37, 500, '2017-05-11'),
(38, 440, '2017-05-14'),
(39, 3004, '2017-05-15'),
(40, 5202, '2017-05-15'),
(41, 2000, '2017-05-15'),
(42, 3336, '2017-05-15'),
(43, 9178, '2017-05-16'),
(44, 1503, '2018-05-19'),
(45, 3000, '2018-05-18'),
(46, 501, '2018-05-18'),
(47, 2001, '2018-05-19'),
(48, 4043, '2018-05-20'),
(49, 17000, '2018-05-20'),
(50, 1001, '2018-05-20'),
(51, 12521, '2018-05-20'),
(52, 22, '2018-05-21'),
(53, 11616, '2018-08-22');

-- --------------------------------------------------------

--
-- Table structure for table `usertbl`
--

CREATE TABLE `usertbl` (
  `id` int(11) NOT NULL,
  `username` varchar(50) DEFAULT NULL,
  `userpassword` varchar(50) DEFAULT NULL,
  `usertype` varchar(50) DEFAULT NULL,
  `name` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `usertbl`
--

INSERT INTO `usertbl` (`id`, `username`, `userpassword`, `usertype`, `name`) VALUES
(1, 'admin', 'admin', 'Administrator', 'Administrator'),
(2, 'employee', 'employee', 'Employee', 'Employee'),
(3, 'shauna', 'vayne', 'Employee', 'Shauna Vayne'),
(4, 'caellach', 'caellach', 'Employee', 'Caellach'),
(5, 'garen', 'garen', 'Employee', 'Garen Crownguard'),
(10, 'troll', 'troll', 'Employee', 'Troll'),
(11, 'yorn', 'yorn', 'Administrator', 'Yorn');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `logstbl`
--
ALTER TABLE `logstbl`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `productcategorytbl`
--
ALTER TABLE `productcategorytbl`
  ADD PRIMARY KEY (`productcategoryid`);

--
-- Indexes for table `productpurchasestbl`
--
ALTER TABLE `productpurchasestbl`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `producttbl`
--
ALTER TABLE `producttbl`
  ADD PRIMARY KEY (`productid`);

--
-- Indexes for table `salestbl`
--
ALTER TABLE `salestbl`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `usertbl`
--
ALTER TABLE `usertbl`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `logstbl`
--
ALTER TABLE `logstbl`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=720;
--
-- AUTO_INCREMENT for table `productcategorytbl`
--
ALTER TABLE `productcategorytbl`
  MODIFY `productcategoryid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;
--
-- AUTO_INCREMENT for table `productpurchasestbl`
--
ALTER TABLE `productpurchasestbl`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=100;
--
-- AUTO_INCREMENT for table `producttbl`
--
ALTER TABLE `producttbl`
  MODIFY `productid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=64;
--
-- AUTO_INCREMENT for table `salestbl`
--
ALTER TABLE `salestbl`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=54;
--
-- AUTO_INCREMENT for table `usertbl`
--
ALTER TABLE `usertbl`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;