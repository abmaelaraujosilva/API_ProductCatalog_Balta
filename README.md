# API_ProductCatalog_Balta
Projeto API do curso do Balta.io, o projeto API_1976 foi feito enquanto fazia o curso, o projeto ProductCatalog foi feito depois e o arquivo doc "API.doc" documenta aquilo que é feito

1 - Modelagem de Dados

ASP.NET Core Empty

2 - Introdução ao Entity Framework Core

Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer

3 - Mapeamento Objeto Relacional

  3.1 - <ItemGroup>
    		<DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.1" />
	</ItemGroup>
  3.2 - dotnet restore
  3.3 - dotnet ef migrations add initial
  3.3.1 - dotnet ef database update
  3.4 - Erro: Fazer um builder do Projeto

4 - Criando a API

5 - Adicionando MVC

<PackageReference Include="Microsoft.AspNetCore.Mvc" Version="2.1.2" />

6 - Rotas e CRUD

dotnet add package Microsoft.EntityFrameworkCore.Tools
  3.1 - Erro: Tente igualar a versão dos package da Microsoft(para 2.1.3 a 2.1.2 por exemplo)

7 - ViewModels

<PackageReference Include="Flunt" Version="1.0.2" />

8 - Repository Pattern

9 - Queries

10 - Versionamento

11 - Cache

Microsoft.AspNetCore.Mvc.ResponseCacheAttribute

12 - Compressão

dotnet add package Microsoft.AspNetCore.ResponseCompression --version 2.0.1

service.AddResponseCompression();
app.UseResponseCompression();

13 - Documentação

dotnet add package Swashbuckle.AspNetCore

Startup:
	services.AddSwaggerGen(x=>
	{
		x.SwaggerDoc("v1", new Info { Title = "Balta Store", Version = "v1" });
	});

	app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API - v1");
        });
        // Pagina com documentação: '/swagger/index.html'

14 - Publicação

15 - Monitoramento
