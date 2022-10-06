# DEVinCar

Projeto avaliativo **DEVinHouse** desenvolvido com ASP.NET 6 com EntityFramework Core 6, em C#, conectando em base SQL Server.

## Sobre

Este projeto é referente ao projeto DEVinCar  desenvolvido no modulo 02 da DevinHouse, por 3 squads. Está armazenado no https://github.com/DEVin-NDD/M2P2-DEVinCar.

Neste projeto  , foi designado a implementar novas features no software, como:
1. Autenticação;
2. Aplicar a resolução dos débitos técnicos, que ficaram pendentes da primeira versão,a separação do projeto em camadas (Controller, Service, Repository), respeitando os conceitos do SOLID.



## Como executar

Baixe o projeto para sua máquina com `git clone https://github.com/Elianehenri/DEVinCar02` então conecte a sua máquina com um SQL Server local e atualize-o rodando no diretório do projeto o comando `dotnet ef database update`. Aí você terá o SQL Server atualizado e o projeto está pronto para ser executado com `dotnet run`. Por padrão a rota será: `https://localhost:7019/` e para acessar o swaggerUI `https://localhost:7019/swagger/index.html`.

## Como ele foi feito

A aplicação foi desenvolvida individual.Cada funcionalidade foi desenvolvida em uma branch separada da Main. Além disso também foi utilizado a metodologia Kanban utilizando o Trello como quadro. 

