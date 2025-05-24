# Projeto de Gestão de Motos e Clientes

📌 Nota: Projeto desenvolvido para fins acadêmicos na disciplina de Advanced Business Development with .NET

Este projeto é uma aplicação simples ASP.NET Core MVC que gerencia registros de uso de motos por usuários.
Inclui funcionalidades de cadastro, listagem, edição, exclusão e busca por CPF.

## Funcionalidades

- Cadastro de usuários e motos
- Criação de registro atrelando o cliente com a moto, que inclui datas de retirada e devolução
- Dropdowns dinâmicos que possibilitam visualizar os clientes e motos ja existentes no sistema
- Busca específica de cliente via CPF
- Integração com banco Oracle utilizando Entity Framework Core
- Documentação da API via Swagger UI

## Interface

Tela Inicial (Bem minimalista - até demais)

![Tela inicial](/img/tela-home.png)

Tela de Cadastro (Registro de Uso)

![Cadastro de Registro](/img/cadastro-registro.png)

Listagem de Motos

![Lista de Motos](/img/lista-moto.png)

## Configuração do Ambiente

### 1. Requisitos

- .NET SDK 8.0 ou superior instalado (https://dotnet.microsoft.com/en-us/download)
- Oracle XE local ou acesso ao banco da sua instituição
- IDE: Visual Studio ou Rider (ou VS Code)

### 2. String de Conexão

No arquivo `appsettings.json`, configure sua conexão Oracle:

```
"ConnectionStrings": {
    "OracleConnection": "User Id=seu_usuario;Password=sua_senha;Data Source=localhost:1521/xe;"
}
```

### 3. Executando o Projeto

1. Restaure os pacotes

```
# Terminal
dotnet restore
```

2. Rode as migrations (importante rodar após configurar a conexão)

```
# Terminal
dotnet ef database update
```

3. Inicie o servidor

```
#Terminal
dotnet run
```

ou clique no play na parte superior da IDE

4. Caso não abra uma aba web automaticamente, acesse o link: http://localhost:5192

### 4. Testando o programa

Assim que o programa for iniciado, o Swagger irá ser aberto de início.

![Swagger UI](/img/print-swagger.png)

Para avançar para a página web inicial, basta mudar a URL para: http://localhost:5192/Home

Agora, podemos começar a testar as funcionalidades!

É necessário criar ao menos um cliente e uma moto para que seja possível criar depois o registro.

Todo o processo de acesso a cada categoria pode ser feito diretamente pela barra de menu superior.

1. Clicando no botão "Adicionar Moto/Cliente", seremos redirecionados ao formulário

![Formulario Moto](/img/forms-moto.png)

2. Após clicar em Concluir, seremos redirecionados para a página inicial da categoria com a lista atualizada

![Lista Atualizada Moto](/img/lista2-moto.png)

3. Caso queira editar alguma informação, basta clicar no botão "Editar", e assim você será redirecionado novamente para o formulário

4. Caso queira apagar, assim que clicar no botão "Excluir", seremos redirecionados para uma tela de confirmação, em que as informações serão mostradas novamente com uma mensagem de confirmação

![Tela Exluir Dado](/img/confirmacao-excluir.png)

5. Agora basta repetir o mesmo cadastro para a sessão de Clientes

6. Agora sim iremos para a categoria de Registros. Basta seguir o mesmo processo que iremos para a tela de cadastro

7. Selecione o dado desejado dos dropdowns, em que eles respectivamente mostram o Nome do Cliente e a Placa da Moto

8. A data de retirada por padrão estará definida com a data e hora atual, mas é possível mudar para qualquer outra data caso queira.
(A data pode ser alterada tanto digitando quanto clicando no calendário)

**Easter Egg**

É possível pesquisar clientes pelo CPF utilizando o macete de alterar a URL!! UHUUU!!

Para isso, vamos voltar para a página dos Clientes. Na URL, ja vai estar como o URL padrão juntamente com Usuario

Do lado, coloque ```/cpf/``` e depois da barra, é so inserir o número do CPF!

Caso a informação desse cliente exista, uma telinha minimalista irá mostrar as informações pra você!

![Retorno CPF encontrado](/img/retorno-cpf-encontrado.png)

( Testa colocar um que não existe também, por favor :D )

