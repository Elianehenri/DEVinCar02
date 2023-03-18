# DEVinCar

Projeto avaliativo **DEVinHouse** desenvolvido com ASP.NET 6 com EntityFramework Core 6, em C#, conectando em base SQL Server.

## Sobre

Este projeto é referente ao projeto DEVinCar  desenvolvido no modulo 02 da DevinHouse, por 3 squads. Está armazenado no https://github.com/DEVin-NDD/M2P2-DEVinCar.

## Aprendizado
* Atuar em projeto .Net com Entity Framework em C#, conectando em base SQL Server
* cache
* middleware
* content negotiation
* paginação
* autenticacao jwt




## Como executar

1 - Baixe o projeto para sua máquina clonando o projeto
* `$ git clone https://github.com/Elianehenri/DEVinCar02` 
2 -No Windowns, vá para o arquivo appsettings.json e adicione a ConnectionString, seguindo o modelo abaixo 
"ConnectionStrings": {
  "ServerConnection": "Server=YOURSERVER\\SQLEXPRESS;Database=BD_CONDOMINIODEVAPI;Trusted_Connection=True;"
  }
Aí você terá o SQL Server atualizado e o projeto está pronto para ser executado com `dotnet run`. Por padrão a rota será: `https://localhost:7019/` e para acessar o swaggerUI `https://localhost:7019/swagger/index.html`.

## Como ele foi feito

A aplicação foi desenvolvida individual.Cada funcionalidade foi desenvolvida em uma branch separada da Main. Além disso também foi utilizado a metodologia Kanban utilizando o Trello como quadro. 

