## Sobre o Projeto
O desenvolvimento desse projeto buscou aprimorar os conhecimentos na criação de uma API Rest e aprofundar os conhecimentos nas tecnologias usadas.

O Projeto conta com 5 Endpoints, todos documentados através do swagger:

![alt text](image.png)

## Tecnologias Usadas
* .Net 6.0 | C# | ASP.NET
* Entity Framework
* SQL Server

## Tabelas do Banco de Dados

### Relacionamento das tabelas
#### O relacionamento entre as tabelas foi feito seguindo essa linha de lógica e raciocinio: 

Uma **pessoa** possui apenas um cartão, e um **cartão** só pertence a uma **pessoa específica**;

Um **cartão** só possui uma **conta corrente**, e uma **conta corrente** só pertence a uma **pessoa específica**.

Uma **conta corrente** só possui um **saldo**, e um **saldo** só pertence a uma **conta corrente específica**.



## Instalação
1. Clone o repositório usando o comando:
```
$ git clone https://github.com/Bruno0M/SistemaBancarioWebAPI.git
````

2. Acesse a pasta do seu projeto e então abra em sua IDE de preferência:
```
$ cd SistemaBancarioWebAPI
```