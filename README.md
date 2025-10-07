# My First .NET API

Este é uma api REST simples, que implementa o CRUD de um model de registro de temperatura.

Ela imprementa o OpenAPI para documentação automática utilizando o Scalar como UI.

### How to run?

Tenha o SDK do dotnet instalado.

clone o repositório:
```shell
git clone  https://github.com/leandrosantino/MyFirstDotNETApi.git
```

Acesse o diretório do projeto:
```shell
cd MyFirstDotNETApi
```

Instale o dotnet Entity Framework tool (dotnet-ef):
```shell
dotnet tool install --global dotnet-ef
```

Atualize o banco de dados:
```shell
dotnet-ef database update
```

E por fim inicialize a aplicação.
```shell
dotnet watch run
```

A api estara acessivel em:
`http://localhost:5182`

Para visualizar a interface da documentação acesse:
`http://localhost:5182/scalar`


