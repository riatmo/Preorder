-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.4.11-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             10.2.0.5599
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for preorder
CREATE DATABASE IF NOT EXISTS `preorder` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `preorder`;

-- Dumping structure for table preorder.admin
CREATE TABLE IF NOT EXISTS `admin` (
  `kd_admin` char(50) NOT NULL DEFAULT '',
  `pwd` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `hp` varchar(50) NOT NULL,
  `jabatan` varchar(50) NOT NULL,
  PRIMARY KEY (`kd_admin`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table preorder.admin: ~1 rows (approximately)
/*!40000 ALTER TABLE `admin` DISABLE KEYS */;
REPLACE INTO `admin` (`kd_admin`, `pwd`, `username`, `nama`, `email`, `hp`, `jabatan`) VALUES
	('AD001', 'root', 'root', '', '', '', '');
/*!40000 ALTER TABLE `admin` ENABLE KEYS */;

-- Dumping structure for table preorder.barang
CREATE TABLE IF NOT EXISTS `barang` (
  `kd_barang` char(10) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `kuantitas` int(11) DEFAULT NULL,
  `harga` int(20) NOT NULL DEFAULT 0,
  `warna` char(50) NOT NULL DEFAULT '',
  `ukuran` char(50) NOT NULL DEFAULT '',
  `gambar` blob DEFAULT NULL,
  PRIMARY KEY (`kd_barang`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table preorder.barang: ~6 rows (approximately)
/*!40000 ALTER TABLE `barang` DISABLE KEYS */;
REPLACE INTO `barang` (`kd_barang`, `nama`, `kuantitas`, `harga`, `warna`, `ukuran`, `gambar`) VALUES
	('23', '23', NULL, 23, '23', '23', NULL),
	('2323', '232', NULL, 450000, '23', '23', NULL),
	('34', '34', NULL, 3400000, '34', '34', NULL),
	('A0012', 'Tas', NULL, 35000, 'Biru', '34x40x44', NULL),
	('a454', 'we', NULL, 343, '44', '343', NULL),
	('AD0001', 'Alat Dapur', NULL, 5000, 'pink', '4x10', NULL);
/*!40000 ALTER TABLE `barang` ENABLE KEYS */;

-- Dumping structure for table preorder.detail_pesanan
CREATE TABLE IF NOT EXISTS `detail_pesanan` (
  `kd_detail` char(10) NOT NULL,
  `kd_barang` char(10) NOT NULL,
  `Qty` int(11) NOT NULL,
  `Subtotal` int(11) NOT NULL,
  `kd_pesanan` char(10) NOT NULL,
  PRIMARY KEY (`kd_detail`),
  KEY `FK_detail_pesanan_barang` (`kd_barang`),
  KEY `FK_detail_pesanan_pesanan` (`kd_pesanan`),
  CONSTRAINT `FK_detail_pesanan_barang` FOREIGN KEY (`kd_barang`) REFERENCES `barang` (`kd_barang`),
  CONSTRAINT `FK_detail_pesanan_pesanan` FOREIGN KEY (`kd_pesanan`) REFERENCES `pesanan` (`kd_pesanan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table preorder.detail_pesanan: ~0 rows (approximately)
/*!40000 ALTER TABLE `detail_pesanan` DISABLE KEYS */;
/*!40000 ALTER TABLE `detail_pesanan` ENABLE KEYS */;

-- Dumping structure for table preorder.pembeli
CREATE TABLE IF NOT EXISTS `pembeli` (
  `kd_pembeli` char(10) NOT NULL,
  `nama_pembeli` varchar(50) NOT NULL,
  `telp_pembeli` char(50) NOT NULL,
  `alamat_pembeli` tinytext NOT NULL,
  `kecamatan` tinytext NOT NULL,
  `kabupaten` tinytext NOT NULL,
  `provinsi` tinytext NOT NULL,
  `kode_pos` char(50) NOT NULL,
  PRIMARY KEY (`kd_pembeli`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table preorder.pembeli: ~0 rows (approximately)
/*!40000 ALTER TABLE `pembeli` DISABLE KEYS */;
/*!40000 ALTER TABLE `pembeli` ENABLE KEYS */;

-- Dumping structure for table preorder.pembelian
CREATE TABLE IF NOT EXISTS `pembelian` (
  `kd_pembelian` char(10) NOT NULL,
  `tgl_pembelian` datetime NOT NULL,
  `nama_barang` varchar(100) NOT NULL,
  `jumlah_barang` int(11) NOT NULL,
  `harga_beli` int(11) NOT NULL,
  `kd_produsen` char(10) NOT NULL,
  `kd_barang` char(10) NOT NULL,
  `kd_pesanan` char(10) NOT NULL,
  `kd_admin` char(10) NOT NULL,
  PRIMARY KEY (`kd_pembelian`),
  KEY `FK_pembelian_produsen` (`kd_produsen`),
  KEY `FK_pembelian_barang` (`kd_barang`),
  KEY `FK_pembelian_pesanan` (`kd_pesanan`),
  KEY `FK_pembelian_admin` (`kd_admin`),
  CONSTRAINT `FK_pembelian_admin` FOREIGN KEY (`kd_admin`) REFERENCES `admin` (`kd_admin`),
  CONSTRAINT `FK_pembelian_barang` FOREIGN KEY (`kd_barang`) REFERENCES `barang` (`kd_barang`),
  CONSTRAINT `FK_pembelian_pesanan` FOREIGN KEY (`kd_pesanan`) REFERENCES `pesanan` (`kd_pesanan`),
  CONSTRAINT `FK_pembelian_produsen` FOREIGN KEY (`kd_produsen`) REFERENCES `produsen` (`kd_produsen`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table preorder.pembelian: ~0 rows (approximately)
/*!40000 ALTER TABLE `pembelian` DISABLE KEYS */;
/*!40000 ALTER TABLE `pembelian` ENABLE KEYS */;

-- Dumping structure for table preorder.pesanan
CREATE TABLE IF NOT EXISTS `pesanan` (
  `kd_pesanan` char(10) NOT NULL,
  `tgl_pesanan` datetime NOT NULL,
  `cara_bayar` char(50) NOT NULL DEFAULT '',
  `jatuh_tempo` datetime NOT NULL,
  `kd_pembeli` char(50) NOT NULL DEFAULT '',
  `catatan` varchar(50) DEFAULT NULL,
  `uang_muka` int(11) NOT NULL,
  `sisa_bayar` int(11) NOT NULL,
  `kd_admin` char(10) NOT NULL,
  PRIMARY KEY (`kd_pesanan`),
  KEY `FK_pesanan_admin` (`kd_admin`),
  KEY `FK_pesanan_pembeli` (`kd_pembeli`),
  CONSTRAINT `FK_pesanan_admin` FOREIGN KEY (`kd_admin`) REFERENCES `admin` (`kd_admin`),
  CONSTRAINT `FK_pesanan_pembeli` FOREIGN KEY (`kd_pembeli`) REFERENCES `pembeli` (`kd_pembeli`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table preorder.pesanan: ~0 rows (approximately)
/*!40000 ALTER TABLE `pesanan` DISABLE KEYS */;
/*!40000 ALTER TABLE `pesanan` ENABLE KEYS */;

-- Dumping structure for table preorder.produsen
CREATE TABLE IF NOT EXISTS `produsen` (
  `kd_produsen` char(50) NOT NULL,
  `nama_produsen` varchar(50) NOT NULL,
  `alamat_produsen` varchar(50) NOT NULL,
  `telp_produsen` varchar(50) NOT NULL,
  PRIMARY KEY (`kd_produsen`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table preorder.produsen: ~0 rows (approximately)
/*!40000 ALTER TABLE `produsen` DISABLE KEYS */;
/*!40000 ALTER TABLE `produsen` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
