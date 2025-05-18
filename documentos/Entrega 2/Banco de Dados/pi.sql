-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 18/05/2025 às 17:02
-- Versão do servidor: 10.4.32-MariaDB
-- Versão do PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `pi`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `acao_programada`
--

CREATE TABLE `acao_programada` (
  `ID_Acao` int(11) NOT NULL,
  `Tipo_Acao` varchar(50) DEFAULT NULL,
  `Condicao` varchar(100) DEFAULT NULL,
  `Horario_Agendado` time DEFAULT NULL,
  `ID_Dispositivo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Despejando dados para a tabela `acao_programada`
--

INSERT INTO `acao_programada` (`ID_Acao`, `Tipo_Acao`, `Condicao`, `Horario_Agendado`, `ID_Dispositivo`) VALUES
(1, 'Ligar', 'Temperatura > 28', NULL, 2),
(2, 'Desligar', NULL, '23:00:00', 1);

-- --------------------------------------------------------

--
-- Estrutura para tabela `ambiente`
--

CREATE TABLE `ambiente` (
  `ID_Ambiente` int(11) NOT NULL,
  `Nome` varchar(100) NOT NULL,
  `Consumo_Medio_KWh` decimal(10,2) DEFAULT NULL,
  `ID_Casa` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Despejando dados para a tabela `ambiente`
--

INSERT INTO `ambiente` (`ID_Ambiente`, `Nome`, `Consumo_Medio_KWh`, `ID_Casa`) VALUES
(1, 'Quarto1', 1.50, 1),
(2, 'Quarto2', 1.50, 1),
(3, 'Sala', 0.05, 1),
(4, 'Cozinha', 3.00, 1),
(5, 'Piscina', 7.00, 1);

-- --------------------------------------------------------

--
-- Estrutura para tabela `casa`
--

CREATE TABLE `casa` (
  `ID_Casa` int(11) NOT NULL,
  `Endereco` varchar(255) NOT NULL,
  `Quantidade_Comodos` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Despejando dados para a tabela `casa`
--

INSERT INTO `casa` (`ID_Casa`, `Endereco`, `Quantidade_Comodos`) VALUES
(1, 'Rua Exemplo, 123 - São Paulo', 5);

-- --------------------------------------------------------

--
-- Estrutura para tabela `dispositivo`
--

CREATE TABLE `dispositivo` (
  `ID_Dispositivo` int(11) NOT NULL,
  `Nome` varchar(100) DEFAULT NULL,
  `Estado` varchar(20) DEFAULT NULL,
  `ID_Tipo_Dispositivo` int(11) NOT NULL,
  `ID_Ambiente` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Despejando dados para a tabela `dispositivo`
--

INSERT INTO `dispositivo` (`ID_Dispositivo`, `Nome`, `Estado`, `ID_Tipo_Dispositivo`, `ID_Ambiente`) VALUES
(1, 'Lâmpada do Quarto1', 'Desligada', 1, 1),
(2, 'Ar-Condicionado do Quarto2', 'Ligado', 2, 2),
(3, 'Tranca da Porta', 'Fechada', 3, 3);

-- --------------------------------------------------------

--
-- Estrutura para tabela `moradores`
--

CREATE TABLE `moradores` (
  `ID_Morador` int(11) NOT NULL,
  `Nome` varchar(100) NOT NULL,
  `ID_Casa` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Despejando dados para a tabela `moradores`
--

INSERT INTO `moradores` (`ID_Morador`, `Nome`, `ID_Casa`) VALUES
(1, 'MORADOR1', 1),
(2, 'MORADOR2', 1);

-- --------------------------------------------------------

--
-- Estrutura para tabela `notificacao`
--

CREATE TABLE `notificacao` (
  `ID_Notificacao` int(11) NOT NULL,
  `Mensagem` text NOT NULL,
  `Data_Hora` datetime NOT NULL,
  `Nivel` varchar(20) DEFAULT NULL,
  `ID_Morador` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Despejando dados para a tabela `notificacao`
--

INSERT INTO `notificacao` (`ID_Notificacao`, `Mensagem`, `Data_Hora`, `Nivel`, `ID_Morador`) VALUES
(1, 'Temperatura alta no Quarto2', '2025-05-16 14:00:00', 'Alerta', 2),
(2, 'Luz do Quarto1 desligada automaticamente', '2025-05-16 23:01:00', 'Informação', 1);

-- --------------------------------------------------------

--
-- Estrutura para tabela `registro_evento`
--

CREATE TABLE `registro_evento` (
  `ID_Registro_Evento` int(11) NOT NULL,
  `Origem_Acao` varchar(100) DEFAULT NULL,
  `Data_Hora_Acao` datetime NOT NULL,
  `Tipo_Acao` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Estrutura para tabela `sensor`
--

CREATE TABLE `sensor` (
  `ID_Sensor` int(11) NOT NULL,
  `ID_Tipo_Sensor` int(11) NOT NULL,
  `ID_Ambiente` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Despejando dados para a tabela `sensor`
--

INSERT INTO `sensor` (`ID_Sensor`, `ID_Tipo_Sensor`, `ID_Ambiente`) VALUES
(1, 1, 1),
(2, 2, 1),
(3, 3, 3);

-- --------------------------------------------------------

--
-- Estrutura para tabela `sensor_evento`
--

CREATE TABLE `sensor_evento` (
  `ID_Evento` int(11) NOT NULL,
  `TimeStamp` datetime NOT NULL,
  `Valor_Temperatura` decimal(5,2) DEFAULT NULL,
  `Valor_Umidade` decimal(5,2) DEFAULT NULL,
  `Movimento` tinyint(1) DEFAULT NULL,
  `ID_Sensor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Estrutura para tabela `tipo_dispositivo`
--

CREATE TABLE `tipo_dispositivo` (
  `ID_Tipo_Dispositivo` int(11) NOT NULL,
  `Nome_Tipo` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Despejando dados para a tabela `tipo_dispositivo`
--

INSERT INTO `tipo_dispositivo` (`ID_Tipo_Dispositivo`, `Nome_Tipo`) VALUES
(1, 'Lâmpada'),
(2, 'Ar-Condicionado'),
(3, 'Tranca');

-- --------------------------------------------------------

--
-- Estrutura para tabela `tipo_sensor`
--

CREATE TABLE `tipo_sensor` (
  `ID_Tipo_Sensor` int(11) NOT NULL,
  `Nome_Tipo` varchar(50) NOT NULL,
  `Unidade_Medida` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Despejando dados para a tabela `tipo_sensor`
--

INSERT INTO `tipo_sensor` (`ID_Tipo_Sensor`, `Nome_Tipo`, `Unidade_Medida`) VALUES
(1, 'Temperatura', '°C'),
(2, 'Umidade', '%'),
(3, 'Movimento', 'Booleano');

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `acao_programada`
--
ALTER TABLE `acao_programada`
  ADD PRIMARY KEY (`ID_Acao`),
  ADD KEY `ID_Dispositivo` (`ID_Dispositivo`);

--
-- Índices de tabela `ambiente`
--
ALTER TABLE `ambiente`
  ADD PRIMARY KEY (`ID_Ambiente`),
  ADD KEY `ID_Casa` (`ID_Casa`);

--
-- Índices de tabela `casa`
--
ALTER TABLE `casa`
  ADD PRIMARY KEY (`ID_Casa`);

--
-- Índices de tabela `dispositivo`
--
ALTER TABLE `dispositivo`
  ADD PRIMARY KEY (`ID_Dispositivo`),
  ADD KEY `ID_Tipo_Dispositivo` (`ID_Tipo_Dispositivo`),
  ADD KEY `ID_Ambiente` (`ID_Ambiente`);

--
-- Índices de tabela `moradores`
--
ALTER TABLE `moradores`
  ADD PRIMARY KEY (`ID_Morador`),
  ADD KEY `ID_Casa` (`ID_Casa`);

--
-- Índices de tabela `notificacao`
--
ALTER TABLE `notificacao`
  ADD PRIMARY KEY (`ID_Notificacao`),
  ADD KEY `ID_Morador` (`ID_Morador`);

--
-- Índices de tabela `registro_evento`
--
ALTER TABLE `registro_evento`
  ADD PRIMARY KEY (`ID_Registro_Evento`);

--
-- Índices de tabela `sensor`
--
ALTER TABLE `sensor`
  ADD PRIMARY KEY (`ID_Sensor`),
  ADD KEY `ID_Ambiente` (`ID_Ambiente`),
  ADD KEY `ID_Tipo_Sensor` (`ID_Tipo_Sensor`);

--
-- Índices de tabela `sensor_evento`
--
ALTER TABLE `sensor_evento`
  ADD PRIMARY KEY (`ID_Evento`),
  ADD KEY `ID_Sensor` (`ID_Sensor`);

--
-- Índices de tabela `tipo_dispositivo`
--
ALTER TABLE `tipo_dispositivo`
  ADD PRIMARY KEY (`ID_Tipo_Dispositivo`);

--
-- Índices de tabela `tipo_sensor`
--
ALTER TABLE `tipo_sensor`
  ADD PRIMARY KEY (`ID_Tipo_Sensor`);

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `acao_programada`
--
ALTER TABLE `acao_programada`
  ADD CONSTRAINT `acao_programada_ibfk_1` FOREIGN KEY (`ID_Dispositivo`) REFERENCES `dispositivo` (`ID_Dispositivo`);

--
-- Restrições para tabelas `ambiente`
--
ALTER TABLE `ambiente`
  ADD CONSTRAINT `ambiente_ibfk_1` FOREIGN KEY (`ID_Casa`) REFERENCES `casa` (`ID_Casa`);

--
-- Restrições para tabelas `dispositivo`
--
ALTER TABLE `dispositivo`
  ADD CONSTRAINT `dispositivo_ibfk_1` FOREIGN KEY (`ID_Tipo_Dispositivo`) REFERENCES `tipo_dispositivo` (`ID_Tipo_Dispositivo`),
  ADD CONSTRAINT `dispositivo_ibfk_2` FOREIGN KEY (`ID_Ambiente`) REFERENCES `ambiente` (`ID_Ambiente`);

--
-- Restrições para tabelas `moradores`
--
ALTER TABLE `moradores`
  ADD CONSTRAINT `moradores_ibfk_1` FOREIGN KEY (`ID_Casa`) REFERENCES `casa` (`ID_Casa`);

--
-- Restrições para tabelas `notificacao`
--
ALTER TABLE `notificacao`
  ADD CONSTRAINT `notificacao_ibfk_1` FOREIGN KEY (`ID_Morador`) REFERENCES `moradores` (`ID_Morador`);

--
-- Restrições para tabelas `sensor`
--
ALTER TABLE `sensor`
  ADD CONSTRAINT `sensor_ibfk_1` FOREIGN KEY (`ID_Ambiente`) REFERENCES `ambiente` (`ID_Ambiente`),
  ADD CONSTRAINT `sensor_ibfk_2` FOREIGN KEY (`ID_Tipo_Sensor`) REFERENCES `tipo_sensor` (`ID_Tipo_Sensor`);

--
-- Restrições para tabelas `sensor_evento`
--
ALTER TABLE `sensor_evento`
  ADD CONSTRAINT `sensor_evento_ibfk_1` FOREIGN KEY (`ID_Sensor`) REFERENCES `sensor` (`ID_Sensor`),
  ADD CONSTRAINT `sensor_evento_ibfk_2` FOREIGN KEY (`ID_Evento`) REFERENCES `registro_evento` (`ID_Registro_Evento`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
