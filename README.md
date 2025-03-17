# 📄 Sistema de Cadastro de Currículos - ASP.NET MVC

## 📑 Descrição do Projeto
Este projeto ASP.NET MVC permite o cadastro, listagem e exibição de currículos em formato profissional. O sistema coleta informações pessoais, formação acadêmica, experiências profissionais e idiomas, apresentando tudo em uma interface amigável e organizada.

## 🚀 Como Usar: Executar o Projeto Localmente
**Pré-requisitos:** Ter o **Visual Studio 2022** ou superior instalado e o **SQL Server** configurado.

### 🔧 Passos para Rodar o Sistema
1. Clone o repositório: `git clone https://github.com/seu-usuario/sistema-curriculo-mvc.git`.
2. Abra o projeto no Visual Studio.
3. Configure a string de conexão no `HelperDAO` ou no `appsettings.json`.
4. Crie o banco de dados no SQL Server e execute o script de criação da tabela.
5. Execute o projeto (`Ctrl + F5`) e acesse: `http://localhost:5000/Curriculo/Index`.

### 🖥️ Funcionalidades
- **Cadastro de Currículos** com dados pessoais, formação, experiência e idiomas.
- **Listagem de Currículos** ordenados por ID.
- **Visualização detalhada** do currículo no estilo de um currículo profissional.
- **Estilização com Bootstrap + CSS customizado** para uma aparência elegante.

## 🗄️ Estrutura da Tabela SQL
```sql
CREATE TABLE Curriculos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    CPF VARCHAR(14) NOT NULL,
    Endereco VARCHAR(200),
    Telefone VARCHAR(20),
    Email VARCHAR(100) NOT NULL,
    PretensaoSalarial DECIMAL(10,2),
    CargoPretendido VARCHAR(100),
    DataNascimento DATE,

    -- Formação Acadêmica
    Formacao1 VARCHAR(100),
    Formacao2 VARCHAR(100),
    Formacao3 VARCHAR(100),
    Formacao4 VARCHAR(100),
    Formacao5 VARCHAR(100),

    -- Experiência Profissional
    Experiencia1 VARCHAR(100),
    Experiencia2 VARCHAR(100),
    Experiencia3 VARCHAR(100),

    -- Idiomas
    Idioma1 VARCHAR(50),
    Idioma2 VARCHAR(50),
    Idioma3 VARCHAR(50)
);
