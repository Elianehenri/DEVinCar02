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


### Pré-requisitos
Para rodar o projeto em sua máquina, você vai precisar ter instalado as seguintes ferramentas:
[Git](https://git-scm.com) e [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
Além disto é importante ter um editor para trabalhar com o código, como [VisualStudio](https://visualstudio.microsoft.com/) e um sistema gerenciador de Banco de dados relacional, como o [SQLServer](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads).


#### Como executar
<ol start="1">
<li>Clone o projeto </li>

```bash
$ git clone https://github.com/Elianehenri/DEVinCar02
  ```

  <li> No arquivo <b style="color:#7b9eeb">appsettings.json</b> e adicione a ConnectionString, seguindo o modelo abaixo: <br>
    
    ```bash
    "ConnectionStrings": {
  "ServerConnection": "Server=YOURSERVER\\SQLEXPRESS;Database=BD_CONDOMINIODEVAPI;Trusted_Connection=True;"
  }
    ```
<li>Após o comando executado, atualize o Banco de Dados</li>

```bash
dotnet ef database update
```
<li>Pronto, sua aplicação está pronta para rodar</li>

```bash
dotnet watch run
```
## Autor
  Eliane Henriqueta

## Como ele foi feito

<li> A aplicação foi desenvolvida individual.Cada funcionalidade foi desenvolvida em uma branch separada da Main. Além disso também foi utilizado a metodologia Kanban utilizando o Trello como quadro. </li>

