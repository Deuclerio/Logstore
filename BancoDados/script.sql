USE [logStore]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 05/12/2020 18:21:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[NomeCliente] [nvarchar](150) NULL,
	[Telefone] [nvarchar](11) NULL,
	[Ativo] [bit] NULL,
	[EnderecoId] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Endereco]    Script Date: 05/12/2020 18:21:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Endereco](
	[EnderecoId] [int] IDENTITY(1,1) NOT NULL,
	[Logradouro] [nvarchar](50) NULL,
	[Cep] [nvarchar](8) NULL,
	[Numero] [nvarchar](4) NULL,
	[Complemento] [nvarchar](150) NULL,
	[Bairro] [nvarchar](50) NULL,
	[Cidade] [nvarchar](50) NULL,
	[Estado] [nvarchar](2) NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[EnderecoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 05/12/2020 18:21:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[PedidoId] [int] IDENTITY(1,1) NOT NULL,
	[ValorTotalPedido] [decimal](18, 2) NULL,
	[DataRegistro] [datetime] NULL,
	[ClienteId] [int] NULL,
	[EnderecoId] [int] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[PedidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PedidoItem]    Script Date: 05/12/2020 18:21:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoItem](
	[PedidoItemId] [int] IDENTITY(1,1) NOT NULL,
	[Referencia] [int] NULL,
	[ValorUnitario] [decimal](18, 2) NULL,
	[Quantidade] [int] NULL,
	[ProdutoId] [int] NULL,
	[PedidoId] [int] NULL,
 CONSTRAINT [PK_PedidoItem] PRIMARY KEY CLUSTERED 
(
	[PedidoItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Produto]    Script Date: 05/12/2020 18:21:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[ProdutoId] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](150) NULL,
	[ValorUnitario] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[ProdutoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([ClienteId], [NomeCliente], [Telefone], [Ativo], [EnderecoId]) VALUES (1, N'TESTE', N'12', 1, 1)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
SET IDENTITY_INSERT [dbo].[Endereco] ON 

INSERT [dbo].[Endereco] ([EnderecoId], [Logradouro], [Cep], [Numero], [Complemento], [Bairro], [Cidade], [Estado]) VALUES (1, N'LOGRADOURO', N'CEP', N'1', N'COMPLEMENTO', N'BAIRRO', N'CIDADE', N'ES')
INSERT [dbo].[Endereco] ([EnderecoId], [Logradouro], [Cep], [Numero], [Complemento], [Bairro], [Cidade], [Estado]) VALUES (6, N'test', N'tes', N'tes', N'tes', N'te', N'tes', N'te')
INSERT [dbo].[Endereco] ([EnderecoId], [Logradouro], [Cep], [Numero], [Complemento], [Bairro], [Cidade], [Estado]) VALUES (7, N'teste', N'tes', N'tes', N'tes', N'tes', N'te2', N'2')
INSERT [dbo].[Endereco] ([EnderecoId], [Logradouro], [Cep], [Numero], [Complemento], [Bairro], [Cidade], [Estado]) VALUES (8, N'teste', N'tes', N'tes', N'tes', N'tes', N'te2', N'2')
INSERT [dbo].[Endereco] ([EnderecoId], [Logradouro], [Cep], [Numero], [Complemento], [Bairro], [Cidade], [Estado]) VALUES (9, N'Logradouro', N'29149408', N'10', N'Complemento', N'Bairro', N'Cidade', N'ES')
SET IDENTITY_INSERT [dbo].[Endereco] OFF
SET IDENTITY_INSERT [dbo].[Pedido] ON 

INSERT [dbo].[Pedido] ([PedidoId], [ValorTotalPedido], [DataRegistro], [ClienteId], [EnderecoId]) VALUES (7, CAST(1.03 AS Decimal(18, 2)), CAST(N'2020-12-05 13:29:39.997' AS DateTime), 1, 1)
INSERT [dbo].[Pedido] ([PedidoId], [ValorTotalPedido], [DataRegistro], [ClienteId], [EnderecoId]) VALUES (8, CAST(2.00 AS Decimal(18, 2)), CAST(N'2020-12-05 13:29:39.997' AS DateTime), 1, 1)
INSERT [dbo].[Pedido] ([PedidoId], [ValorTotalPedido], [DataRegistro], [ClienteId], [EnderecoId]) VALUES (11, CAST(3.00 AS Decimal(18, 2)), CAST(N'2020-12-05 13:29:39.997' AS DateTime), NULL, 6)
INSERT [dbo].[Pedido] ([PedidoId], [ValorTotalPedido], [DataRegistro], [ClienteId], [EnderecoId]) VALUES (12, CAST(4.00 AS Decimal(18, 2)), CAST(N'2020-12-05 13:31:32.343' AS DateTime), NULL, 7)
INSERT [dbo].[Pedido] ([PedidoId], [ValorTotalPedido], [DataRegistro], [ClienteId], [EnderecoId]) VALUES (13, CAST(5.00 AS Decimal(18, 2)), CAST(N'2020-12-05 13:32:08.317' AS DateTime), NULL, 8)
INSERT [dbo].[Pedido] ([PedidoId], [ValorTotalPedido], [DataRegistro], [ClienteId], [EnderecoId]) VALUES (14, CAST(0.00 AS Decimal(18, 2)), CAST(N'2020-12-05 18:12:51.150' AS DateTime), 1, 1)
INSERT [dbo].[Pedido] ([PedidoId], [ValorTotalPedido], [DataRegistro], [ClienteId], [EnderecoId]) VALUES (15, CAST(0.00 AS Decimal(18, 2)), CAST(N'2020-12-05 18:13:15.353' AS DateTime), NULL, 9)
SET IDENTITY_INSERT [dbo].[Pedido] OFF
SET IDENTITY_INSERT [dbo].[PedidoItem] ON 

INSERT [dbo].[PedidoItem] ([PedidoItemId], [Referencia], [ValorUnitario], [Quantidade], [ProdutoId], [PedidoId]) VALUES (1, 0, CAST(0.00 AS Decimal(18, 2)), 0, 1, 7)
INSERT [dbo].[PedidoItem] ([PedidoItemId], [Referencia], [ValorUnitario], [Quantidade], [ProdutoId], [PedidoId]) VALUES (2, 0, CAST(10.00 AS Decimal(18, 2)), 1, 1, 8)
INSERT [dbo].[PedidoItem] ([PedidoItemId], [Referencia], [ValorUnitario], [Quantidade], [ProdutoId], [PedidoId]) VALUES (3, 0, CAST(1.00 AS Decimal(18, 2)), 1, 1, 11)
INSERT [dbo].[PedidoItem] ([PedidoItemId], [Referencia], [ValorUnitario], [Quantidade], [ProdutoId], [PedidoId]) VALUES (4, 1, CAST(10.00 AS Decimal(18, 2)), 2, 1, 12)
INSERT [dbo].[PedidoItem] ([PedidoItemId], [Referencia], [ValorUnitario], [Quantidade], [ProdutoId], [PedidoId]) VALUES (5, 1, CAST(10.00 AS Decimal(18, 2)), 1, 1, 13)
INSERT [dbo].[PedidoItem] ([PedidoItemId], [Referencia], [ValorUnitario], [Quantidade], [ProdutoId], [PedidoId]) VALUES (6, 1, CAST(30.00 AS Decimal(18, 2)), 1, 1, 13)
INSERT [dbo].[PedidoItem] ([PedidoItemId], [Referencia], [ValorUnitario], [Quantidade], [ProdutoId], [PedidoId]) VALUES (7, NULL, CAST(14.20 AS Decimal(18, 2)), 1, 1, 14)
INSERT [dbo].[PedidoItem] ([PedidoItemId], [Referencia], [ValorUnitario], [Quantidade], [ProdutoId], [PedidoId]) VALUES (8, NULL, CAST(14.20 AS Decimal(18, 2)), 1, 1, 15)
SET IDENTITY_INSERT [dbo].[PedidoItem] OFF
SET IDENTITY_INSERT [dbo].[Produto] ON 

INSERT [dbo].[Produto] ([ProdutoId], [Descricao], [ValorUnitario]) VALUES (1, N'Banana', CAST(14.20 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Produto] OFF
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Endereco] FOREIGN KEY([EnderecoId])
REFERENCES [dbo].[Endereco] ([EnderecoId])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Endereco]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Endereco] FOREIGN KEY([EnderecoId])
REFERENCES [dbo].[Endereco] ([EnderecoId])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Endereco]
GO
ALTER TABLE [dbo].[PedidoItem]  WITH CHECK ADD  CONSTRAINT [FK_PedidoItem_Pedido] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedido] ([PedidoId])
GO
ALTER TABLE [dbo].[PedidoItem] CHECK CONSTRAINT [FK_PedidoItem_Pedido]
GO
ALTER TABLE [dbo].[PedidoItem]  WITH CHECK ADD  CONSTRAINT [FK_PedidoItem_Produto] FOREIGN KEY([ProdutoId])
REFERENCES [dbo].[Produto] ([ProdutoId])
GO
ALTER TABLE [dbo].[PedidoItem] CHECK CONSTRAINT [FK_PedidoItem_Produto]
GO
