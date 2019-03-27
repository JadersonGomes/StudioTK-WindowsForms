﻿CREATE TABLE [dbo].[Agendamento] (
    [Id] [int] NOT NULL IDENTITY,
    [NomeCliente] [nvarchar](50) NOT NULL,
    [Data] [datetime] NOT NULL,
    [Horario] [nvarchar](max) NOT NULL,
    [FuncionarioId] [int] NOT NULL,
    [ServicoId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Agendamento] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_FuncionarioId] ON [dbo].[Agendamento]([FuncionarioId])
CREATE INDEX [IX_ServicoId] ON [dbo].[Agendamento]([ServicoId])
CREATE TABLE [dbo].[Funcionario] (
    [Id] [int] NOT NULL IDENTITY,
    [Nome] [nvarchar](30),
    [Telefone] [nvarchar](max),
    [Comissao] [float] NOT NULL,
    [EnderecoId] [int] NOT NULL,
    [UsuarioId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Funcionario] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_EnderecoId] ON [dbo].[Funcionario]([EnderecoId])
CREATE INDEX [IX_UsuarioId] ON [dbo].[Funcionario]([UsuarioId])
CREATE TABLE [dbo].[Caixa] (
    [Id] [int] NOT NULL IDENTITY,
    [Status] [nvarchar](15),
    [dataAbertura] [datetime] NOT NULL,
    [dataFechamento] [datetime] NOT NULL,
    [FuncionarioId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Caixa] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_FuncionarioId] ON [dbo].[Caixa]([FuncionarioId])
CREATE TABLE [dbo].[Movimentacao] (
    [Id] [int] NOT NULL IDENTITY,
    [Data] [datetime] NOT NULL,
    [Valor] [float] NOT NULL,
    [Descricao] [nvarchar](240),
    [FormaPagMovimentacao] [nvarchar](max),
    [TipoMovimentacaoId] [int] NOT NULL,
    [CaixaId] [int] NOT NULL,
    [Funcionario_Id] [int],
    CONSTRAINT [PK_dbo.Movimentacao] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_TipoMovimentacaoId] ON [dbo].[Movimentacao]([TipoMovimentacaoId])
CREATE INDEX [IX_CaixaId] ON [dbo].[Movimentacao]([CaixaId])
CREATE INDEX [IX_Funcionario_Id] ON [dbo].[Movimentacao]([Funcionario_Id])
CREATE TABLE [dbo].[TipoMovimentacao] (
    [Id] [int] NOT NULL IDENTITY,
    [Nome] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.TipoMovimentacao] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Endereco] (
    [Id] [int] NOT NULL IDENTITY,
    [Cep] [nvarchar](max) NOT NULL,
    [Estado] [nvarchar](30),
    [Cidade] [nvarchar](100),
    [Bairro] [nvarchar](70),
    [Logradouro] [nvarchar](120),
    [Numero] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Endereco] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Faturamento] (
    [Id] [int] NOT NULL IDENTITY,
    [Data] [datetime] NOT NULL,
    [ValorTotal] [float] NOT NULL,
    [FuncionarioId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Faturamento] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_FuncionarioId] ON [dbo].[Faturamento]([FuncionarioId])
CREATE TABLE [dbo].[FuncionarioServicoes] (
    [FuncionarioId] [int] NOT NULL,
    [ServicoId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.FuncionarioServicoes] PRIMARY KEY ([FuncionarioId], [ServicoId])
)
CREATE INDEX [IX_FuncionarioId] ON [dbo].[FuncionarioServicoes]([FuncionarioId])
CREATE INDEX [IX_ServicoId] ON [dbo].[FuncionarioServicoes]([ServicoId])
CREATE TABLE [dbo].[Servico] (
    [Id] [int] NOT NULL IDENTITY,
    [Nome] [nvarchar](max) NOT NULL,
    [Valor] [float] NOT NULL,
    [VendaId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Servico] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_VendaId] ON [dbo].[Servico]([VendaId])
CREATE TABLE [dbo].[Venda] (
    [Id] [int] NOT NULL IDENTITY,
    [Data] [datetime] NOT NULL,
    [Hora] [nvarchar](max),
    [Desconto] [bit] NOT NULL,
    [ValorDesconto] [float] NOT NULL,
    [ValorTotal] [float] NOT NULL,
    [FuncionarioId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Venda] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_FuncionarioId] ON [dbo].[Venda]([FuncionarioId])
CREATE TABLE [dbo].[Pagamento] (
    [Id] [int] NOT NULL IDENTITY,
    [NomeCliente] [nvarchar](max),
    [FormaPagamento] [nvarchar](max),
    [ValorTotal] [float] NOT NULL,
    [ValorRecebido] [float] NOT NULL,
    [DataPagamento] [datetime] NOT NULL,
    [VendaId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Pagamento] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_VendaId] ON [dbo].[Pagamento]([VendaId])
CREATE TABLE [dbo].[Produto] (
    [Id] [int] NOT NULL IDENTITY,
    [Descricao] [nvarchar](120),
    [QntdEstoque] [int] NOT NULL,
    [Valor] [float] NOT NULL,
    [VendaId] [int] NOT NULL,
    [FornecedorId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Produto] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_VendaId] ON [dbo].[Produto]([VendaId])
CREATE INDEX [IX_FornecedorId] ON [dbo].[Produto]([FornecedorId])
CREATE TABLE [dbo].[Fornecedor] (
    [Id] [int] NOT NULL IDENTITY,
    [Nome] [nvarchar](50),
    [Telefone] [nvarchar](max),
    [Email] [nvarchar](max) NOT NULL,
    [Especialidade] [nvarchar](max),
    [EnderecoId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Fornecedor] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_EnderecoId] ON [dbo].[Fornecedor]([EnderecoId])
CREATE TABLE [dbo].[Usuario] (
    [Id] [int] NOT NULL IDENTITY,
    [nomeUsuario] [nvarchar](max) NOT NULL,
    [Senha] [nvarchar](max) NOT NULL,
    [email] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.Usuario] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Cliente] (
    [Id] [int] NOT NULL IDENTITY,
    [Nome] [nvarchar](max) NOT NULL,
    [Email] [nvarchar](max) NOT NULL,
    [Telefone] [nvarchar](max),
    CONSTRAINT [PK_dbo.Cliente] PRIMARY KEY ([Id])
)
ALTER TABLE [dbo].[Agendamento] ADD CONSTRAINT [FK_dbo.Agendamento_dbo.Funcionario_FuncionarioId] FOREIGN KEY ([FuncionarioId]) REFERENCES [dbo].[Funcionario] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Agendamento] ADD CONSTRAINT [FK_dbo.Agendamento_dbo.Servico_ServicoId] FOREIGN KEY ([ServicoId]) REFERENCES [dbo].[Servico] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Funcionario] ADD CONSTRAINT [FK_dbo.Funcionario_dbo.Endereco_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [dbo].[Endereco] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Funcionario] ADD CONSTRAINT [FK_dbo.Funcionario_dbo.Usuario_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[Usuario] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Caixa] ADD CONSTRAINT [FK_dbo.Caixa_dbo.Funcionario_FuncionarioId] FOREIGN KEY ([FuncionarioId]) REFERENCES [dbo].[Funcionario] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Movimentacao] ADD CONSTRAINT [FK_dbo.Movimentacao_dbo.Caixa_CaixaId] FOREIGN KEY ([CaixaId]) REFERENCES [dbo].[Caixa] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Movimentacao] ADD CONSTRAINT [FK_dbo.Movimentacao_dbo.TipoMovimentacao_TipoMovimentacaoId] FOREIGN KEY ([TipoMovimentacaoId]) REFERENCES [dbo].[TipoMovimentacao] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Movimentacao] ADD CONSTRAINT [FK_dbo.Movimentacao_dbo.Funcionario_Funcionario_Id] FOREIGN KEY ([Funcionario_Id]) REFERENCES [dbo].[Funcionario] ([Id])
ALTER TABLE [dbo].[Faturamento] ADD CONSTRAINT [FK_dbo.Faturamento_dbo.Funcionario_FuncionarioId] FOREIGN KEY ([FuncionarioId]) REFERENCES [dbo].[Funcionario] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[FuncionarioServicoes] ADD CONSTRAINT [FK_dbo.FuncionarioServicoes_dbo.Funcionario_FuncionarioId] FOREIGN KEY ([FuncionarioId]) REFERENCES [dbo].[Funcionario] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[FuncionarioServicoes] ADD CONSTRAINT [FK_dbo.FuncionarioServicoes_dbo.Servico_ServicoId] FOREIGN KEY ([ServicoId]) REFERENCES [dbo].[Servico] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Servico] ADD CONSTRAINT [FK_dbo.Servico_dbo.Venda_VendaId] FOREIGN KEY ([VendaId]) REFERENCES [dbo].[Venda] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Venda] ADD CONSTRAINT [FK_dbo.Venda_dbo.Funcionario_FuncionarioId] FOREIGN KEY ([FuncionarioId]) REFERENCES [dbo].[Funcionario] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Pagamento] ADD CONSTRAINT [FK_dbo.Pagamento_dbo.Venda_VendaId] FOREIGN KEY ([VendaId]) REFERENCES [dbo].[Venda] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Produto] ADD CONSTRAINT [FK_dbo.Produto_dbo.Fornecedor_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [dbo].[Fornecedor] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Produto] ADD CONSTRAINT [FK_dbo.Produto_dbo.Venda_VendaId] FOREIGN KEY ([VendaId]) REFERENCES [dbo].[Venda] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Fornecedor] ADD CONSTRAINT [FK_dbo.Fornecedor_dbo.Endereco_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [dbo].[Endereco] ([Id]) ON DELETE CASCADE
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201903201719553_BdInicial', N'AcessoBancoDados.Migrations.Configuration',  0x1F8B0800000000000400ED5D5F6FDCB8117F2FD0EFB0D8A7B6C8796DE782BB0BEC2B12C76E835EFE34768CBE19F22E6D0BD54A7B92367050DC27EB433F52BF42A95DFD213933FC2351D26E6AE42516C9E170F8E3909C99E5FCF7DFFF39F9F3E3329A7C61691626F1E9F4E8E0703A61F13C5984F1FDE9749DDF7DF7E3F4CF3FFFFE7727E78BE5E3E4BAAAF7BCA8C75BC6D9E9F421CF572F67B36CFEC0964176B00CE769922577F9C13C59CE8245323B3E3CFC69767434639CC494D39A4C4E3EADE33C5CB2CD1FFCCFB3249EB355BE0EA277C9824559F99D975C6EA84EDE074B96AD82393B9DBE9AB32C4B5E079CC9379C7A76B06D329DBC8AC280B373C9A2BBE92488E3240F72CEECCBCF19BBCCD324BEBF5CF10F4174F575C578BDBB20CA583988974D75DBF11C1E17E399350D2B52F37596274B478247CF4B01CDD4E6ADC43CAD05C84578CE459D7F2D46BD112397E03D8B17C174A276F5F22C4A8B6AA48C0FB62D9F4DD4F267353238808A7FCF2667EB285FA7EC3466EB3C0DA267938FEBDB289CFF8D7DBD4AFEC9E2D3781D45229B9C515E267DE09F3EA6C98AA5F9D74FECAE64FEED623A99C9ED666AC3BA99D0663BB0B771FEFC783A79CF3B0F6E2356A34010C2659EA4EC2F2C666990B3C5C720CF591A1734D8468EA077A5AFF7C9929D4521AFCCAA4E39FAF86A9A4EDE058FBFB0F83E7F389DBEE0CBE7227C648BEA43C9C7E738E46B8FB7C9D33543F8D4F7FD26C883AA53FE7F76C597983391BF26699086898679FEDF3EB8BF58C7733E0145E7E609D393BA64E917CE8A3399F7C197F07E03039AB7E9E4138B3675B28770B5D5370742F9CD76912C390212AE952ED264F92989641A529D9BAB20BD673967353154BC4CD6E9DC81EB520C28C75BC2377595864FB9A4EEB4E24E29AE9817793A99353A47AB8924B1BAAB23A1F9934E32E824CD7A7E6EA78CF47D5CB188DD25B1AE1F5BBDA1EFE82C59865916D40AEA4DC227D15DDB9CC70B96B2163A42A1F3395BB7D258E4A295D5876F5DA3AE66A352B265FB2C081F039CE14DD18DB4D61B4E41215087B086AB1EACE6DA28CEA6222ECAAA5C2BC6BA92AB082F02AE9DB433DF54A0C44954817B0C51CF55B4EF922F6141259827CC0C57A5362E64A99256D2724D5771973B9891EB6AA7A324AEADA9DBDCB1EAAEF22FD58F51F2753D5CE665B156DA551D57395F175A0597F2A688122C2804B2843530F1599F46368AA6CD3964D3F0E904A23B907332EB4C7336387AE1E168B0E0F79F57B7FC03576D9DEF4105B10B367FD82AC9CEE4BADC6E5A5F4B1C775E75F5D37BB3BFEDA1A9112437E50A6C7884A5400920553A6901915E1B6520B67FD2097D5B2BAE8328493B5E05DEB06C9E86F34067F338FEDEC725E9224997C1C7E05EC658CF17A6AB7095881D76BDF16CD6983F1D56AE791FAA41D55F1AED61CB9D2A3C9451B5127DCED5D704BACD50BD939E832373D7752A8D277DD7DE0AE3CBAADA612FF6866375215AC2BE158E9B3BBB3B7EABB64FB8D5E97BB61ADE19709EE57C1AFA365A9E858B60A15B9447873EBA791D8469AA1BCC0F3E7AF925B94FB9CCD6DA9E8E8E7D74F57EBD644D373627007B974063986AE512689A3F2DEA410EDF579CA3A8E3097C94CB71076B2A309319ACAE5D9D63B597AE938FACA432EABA50667A666E21F8725D17D437E251EE6680D6987475F66A1F3E6684BE748AC4CAC11D08ADD4E9E6D36135EDC212DAF5AD65A07B4E0F86A08D3FA197258EDFB75AAD0F753D6B1791938F46E3A2697C65AA7FA62A219C337571A7157BDD3660EDFA295E6DA898B1DEED98859936115C31AF138EB3206EA72954626D35C65E9F801DDDAFAAE6A11DB4B60C7E0CEE75F10E75F14DA9001AEE9422A07DD47257BF3AFF73B126F9DA16225C89059027A9B465309FCE916EA1A5F139044ABC9596AE65DE4653D78D9FB475E7E8623FFAB67256C90EF0DEBAF3A64A37843EB139BB0D175DF57BB13B0211B4B797F83D5FD2873607C5A92A044AB1B6D3085B8DD74A1F6C9B3E69838E8E6B3F06DFBFC7F9E29C4FE1AF6BD6CD8E32DE350D6AB798EB8845927A3C6FD534B5C706B11A3C3B34A5706DC22AFE2E7A96871A8A270FDA42944B0B4367DDFA4967B4B7CE58FE3069477E0B70BE0CC2C8432FCECEC9159B874164F21E7A1A64DB5F2AB48C876F940B1A0E0F8BA18919A9D34933D4D1CBEE6AA16CFAA413347DC55C27D4221E7A315DB2F8C187F1C8B15B3684EAB00F3DAFEE742D82CFB74D9F00BE732E899176A79E765F0ACBAF38E8F866584C13343BCA3F5093D9E65BC3C4F6D76ADB81287E513E248EE770C511CCF9E2579DA98AD40FF11B2E8C9CF1B5B1FD29FE5990CD377BB68A56CE8C3377B57DAFE1AEFA69BDCCD89F407F7CE9F06D312E9E2338E3BB2F5F8C619CC37516F29E5741642926A5BDE54A2D465FF7A496BC612BDE0FEFC55216362C9842006675A7CA1C9984763213B0A88728FC610435FB9A5F4934D35E06279B665D471501D350506F0546720403A0909C937D811F12D94E214517E6DE40450EE4B6C7A1EEF73506788F0F419AF9013048CF8B4DE7F56F2846819F21CE9B028B6DD077031CF81B8341766CDB5F59B45D3FADD06A27BD01906B271D1B46B05F168D0268F437FC36E73968C2B0DA7E752A55FB148040BE31AEEC9A5ED58D60E033A63A3F36DD8BF6B271D048041693883145190B9814A3E31D30697A15624F0E9D86710C014EFD5CEDCB01947E94C346AD19F77D0D880E0F0E8E2CB5A7CF5DBB9D6CB0C86B0BCEB561D8A894EA90E456FB8CF6DD917D59DA56C31976FBD1CCE3BE2C7434C49882943EDEB8011281D69E4EF3FA5F09745B4EADA0AA13D30000D5C9C3A67BF20735034112469D5233AF09416DA6FDDACEE2AAA3BA6FBA921CC100E823E7645F34A21A1B47C1840C946B40224406DAC38F8C5C36407A7CD8119C0F003A622E6C7AAE83C5C6396723C114E4814E1759216826214ACAE1B4A809C9D80FA3043D80210E85F4DCEC854902093D24F593260E51507D5564AF83E2A3A317ADE03D3E06E9110CA103C979B1DA79A570D7513168D876F168532FC8DBBB0D17E37B40A8EDD966ABFC084A7FFE87BF881A120E24370838FBBDCCE2D218EC22A10E7CF75186BDAA6B63CD044FEC7AF534A98FF30AD4EBC8CE5D536F1AFE87B5F3A97363D3BBF0EEFB283054F2375018A19239B887AC9134ED55D6F890C3591F006DF83CEC9EB96E1BE3C9DBE4BC054B2B1E8228488A8FEC314762943F67AC0C53CECAC851153A05D14B964BD82D2D274D54A90248803F9988A4340111A9D440A90C6F0234CAEF86D6B2130A10918B0DB460BC0CA007AB186836577A40AB2932C95A743B43598BA5F6B3562B09DDE4D5950C746962B614CA431F687F6D8546C11408280865262AD5DD06D2A84A4CF215AECF50AE42A1814E7D680044EA12D3AAAA7ED200D75555A2501054120A1825DB8950DD941945D59BF8190A0D3DAF87A5681CA08B2D68563BA540535285EA9E270BC44258C87BEF504A86D867692874F4B33006544F1AC820A2D0A96C7751608F474359980271A5516842718561E894B3891C22157C13729787E96D5F281B97285169609671A2C2204D9B9A0B794486DAFDD25D9468B4A1411DE1D67F526D0007404735046CFE023DF214D04232D4939A88706C82E4E4F118C2E44411D127122B92BD6B273AFECA8023DB35680ED7EA88A811171DFA1EA6566CC6382E6A98BA482E5C80C471D3A583DED187BF3B0825680E1E9286A50D1F12066323226DD08F93E45BC80779170D0AC710C68218790D20422F1A0632BD4305BC240405A10DA890FD30444885C03D7957D21242C4805FDB5AE81DEC390444D9981CFDB202D0B8FAC5A924EF6B466AFDEEF3D84B3608300C4E67D44787B89D4578E0D76013256C99D077E1F6F2A0D708EDFBB4F07EB61440EF6B437D75905292B84BCEC629D7423D02579A79E7E97880AB2D22FAA31BEA2CB27617753CAEA9FE21811C65D071178A9A531ACA43E7B5B0F15BD8594E6CBC159D5051BD8550DBC9EBB293D9E5FC812D83F2C3C98C5799B355BE0EA2ED7B1D55C1BB60B50AE3FBAC69597E995CAE82796133F9EE723A795C4671763A7DC8F3D5CBD92CDB90CE0E96E13C4DB2E42E3F9827CB59B04866C787873FCD8E8E66CB2D8DD95C5A6BAA55BFEE294FD2E09E29A5458AE505BB08D32C2F9E3FBC0D8A8721CE164B504DF20A10C6C0AA2B68F88733569909AB36C5FFCB76C4DB27A5AB00BA514A12177C78456F9B9132001ED89037BD9CF361A5C863256749B45EC6B437886E2DBDDA2992910AECE96DDF6C16096DBFD853281E6CDEAC799148FDD19E8E12D02B5233C4FAD234058797484FE3072BD69932E3C05306E005FC8B3262ADF0AC3FFDBBE35943CF02D4DAD6FD211B42DA8542F35A8D48A5F96A4FA9490C2F526ABEDA533A17C235455AE79A304E9A9A10292012D304108C8667CA02EE8E64949205868976FDA0B7CA4A2CA999F29B3D1539EBB0484B2E71A328A61E56698A65C3E8EA91F028D9107DC05247D0029DFAE6FD80B4FB665FBEB92B92283F3970D13C352CB1D27C7600229A0557C2235AC36153411EA690B6178B872B68EAF5E32DD23E43BDE832DAE2014E351F0BC844D4621199498C7D561969C2348643F789A288594C10DDB49F89D9241895D652F1C1E1B856E60A958E6AE537072ECAD77C2546CA6FF654AA549F2295EA9B3D153195A74849FCEE00FC325BA704FDF2DBCE805F74D97AB94AD1F46CAE52BAD63BBDCF971934C0665F7EFFA68F8B8833D0F3AD9C20EB763927893C5959D069F53997ED27D079D6C6B6ACF838F6D73FB591A850BFBF190D21945BCD1D1F28250B7410ED7675ABD826EC538DBFAE17C20458279AAF8E38C5C929454F5BA1F58A68E2287CAC0A929AC5CAD0B4DD0F6F8B9A070D3354B85BE3FC2254C979060836456E5A8618B652F4CDED2755948597B583D3B2593954CB9E76158F263E295F98484D2AD8EDB38C461F084F2928DA40F3C8C278D7225DFC558BEB1049CEE61AA469BCAB07697F2ECA32238864A8DA7E72B17649C9A764A39754D4B7C3732438D37154EE5826685900996CD90F8AA5144D2219A9C0E5FABFC9BA245FFD379FEC6930886646A1792C877679DCF3811582960556C896BBAAF17CE82977ADD93746E4703ED274A8FE20C7C940A83676F12017418BF4CDD3365F8015A044BAF8CB02022F5DD8245F58688D7B2D6B6749BC0837AF64BCCD8AB45975622BFBC1AB619F104A20FA53AD5203B9FC52FF5D477F9691975248E846284580E74618591905AA86626EAB4C275C025FC2C5260CF36B96B3E54151E1E0F2D768AB6C9A0AEF8238BC6359BECDF0363D3E3CFC713A79158541B68DC92D834C5FAAAF3A58459D1E3D2FA24ED96239539BBBC7AE1654B26C2125A08399F2B0C8CD2192D485854C8D69E81C53B521E9DCE32F413A7F08529095B545E6F28AE682739BB749585E4784CABCFD61193CFED13DE3B26C2A13C40A1E1479CBCF9D8FA7D37F6D5ABE9CBCFDC78DD4F8D9E443CA91FD727238F9AD45BEC9DAC3E1C642DDD0A17BFBDCC7E473C8FB8C6D2DA89F4BA06E935798C4A30DB12630744BEC2E4A82DC3DC72348CE6B0BA7A66527380B61A46EFDD70DFB803396D36C5F815C45846AA07CF4C2157D7268684735ADC6847624378AA2B686167D82DE5B8479D9AB4B7B68176526987A35603FFEDE5971E3F19C1E943816C8E9865748A1933AAEC340DDB8289B75EA5ABDD6B45EB7373423F66981C1BAD5877DEEEDDAC58E3936E7636BB9E1D1987B2BAF4D6CA78FEB4415E1E9F58459057CEAF6FA4367AA5500A886EA0FCE44C558501DBBC7CE94ABD85001059E2E395454E5DEA2D9DFCE5DBAFCBB6CDFBB7D6EC35E6AA1F9FAAD0D404CE965600B32DCD18CAC27738666B2F16789F77595B7DDE37B39A4D7110B6ED35D36EB63B2B1840EFB3AD5DECCA65EAE374DE8E396D86DD8022F720C6527E8FD5F6C5444C0E2DE425AE36468054A35E6D103495FC052621D3BD942E410C7AE47BC9D53DA6870E1DE62DCCE72D5E22E24C52BDA5E88F67BDF4757BC10D7E8A8AE85B6BD5C2BA88C66FB0A65A3DFECC5B87EB33210C88F09478A57F4C1DCB0EE386B94E28982F615A252CCA10F2094A1873E48B1B6F0B4F76D62D17C7B3B97FEEEB61E15430785454DA33E91179D2D027F4F71945CD1EA9B86ADD23875CDD4355CB2A4BDC9286D48A8B193082AD34A083C945FBE05FC508F8FED267C4C3948DC67AD27CC60DE7B24C7552F08B29FD28ED8313C6E04FB231F7E1A043C2E495A343954A4E98485DF3CBC2C9EB51A1F6936AF960D9E0295084F68A6B579765E98D2E6E320D06AB1EF7A0296E6192EEF8072DD6575BFEE1B064736398076F2F8242518123911BF7F0B4729FD335ABB79A0B2CC97D40D588707074760467763331B1822CEFB98F9C767C382C4981D6A375510124F8333D46F02F9A11592CD636CBBA997CCE9B46002ACC1D36AEF1EC05CA6791C700D9BA21B02CB908A6C27D5D735B0605E7F3B064CEA15B9DDD44BDA046EEE53D613604030869A5BBB17E0D8CF6447C8E89E58839D91CF160D73763225BBDBB5EBBF90EB4D547AC2E7FDBFFCEB5E65DAC1BBFF474372C02ED3D79706AA72EF89FAA7FAD6CFB6E536A95D5510F9521DB26F699F3A1B14413BBD690D0E99E1362C07B48CBB5DE99250EE0C521CEE7BFB861497ABD4C8071B53BA4E61C29400A8CD84D5DFBE71AF06FD6CDEE84E0D4D5AB54120A4CB70BA53E69DA163880634E338C40F0D6BBA3997DF0DAB220840BA5575CECAE7E3248855296C91F9DBBE11763A5DDC1600DB46CA69D2E5820E2405027A914AB1AE7419E8D5AECAF815D049F91D235F161908CB7E16405F2EC6BAD1E51E03BDC19009D023AC82F50A6B197A6EAED2A0C7A608EBA92935A141F469423488A5281AC40AF6C0AB95A10E7F7525030CCB7A0CE475041CD0DD6AFBA25248ABE4AF89957B4D2F5C3C59BB4A58B08301E24219D601F9903BECA4BAB9C02EAA12B4033C673D9C7DE1420F675D2844675B2837F4539FD240277509D60395271DA8B4EAB77650A95525A85AC3331398D3CF4BB1CB861CF4749C337DB2ACC7679F795EDEA1C48CDBE084E29C641E46DB22633684E47A1DACB48509496CBB0F15890C45C66A8A1F6DC3ACD406DBD8E063B6DD876B88654486EE12FD280D89DAAFF10495BB201C34E6CEB0DA29FB336A9E1758A78E065D974D9B61132162D8C86DA2C9BCAE7CE46404B207FA9D79E38AB08C7DF22A8611960016B2A3978631C8C72F32C8832C950CB0BB78D0F0124428E63014DC5221F04F303DBA08602004327E43B484571C5C8373107E9C771FAAEAB44706AAF5EBB76153766DA8370E25DB9787F58EB899B1456EF246FBDAF0C0F544CD68E36156A157149B5883EFB41BDBB8034B9C63E23ED77EB83484691F5F7700F73A34C5E944EA21DC2DD579700E5ABBE391A4BE16EB0F2374D61EE05011582633DB0C7E1055ECFAC86875967F2F3BAA8F5B35C85D51979DCCB65689F203FF13E4A838997D5AC7C5FB37DBBFDEB02CBC6F4814C937B84A916CDE759DB7F15D5259DF158EAA2ACA6FC0DFB13CD8BC929DE6E15D30CF7971917E258CEFA793EB205A17BA7C79CB166FE30FEB7CB5CEF990D9F236FA2A0AA330E1EBFA3F99019E4F3EAC8ABF321F43B8DE3C6D91B30FF1EB75182D6ABE2F90D7070812856FA0FCB57F319779F1ABFFFBAF35A5F720950E45A8145FEDD2B862CB55C489651FE2CBE00B6BC3DBE78CFDC2EE83F9D78F65AA119A88792264B19FBC09837B7E85CA4A1A4D7BFE27C7F062F9F8F3FF0060F70F2ABE100100 , N'6.2.0-61023')
