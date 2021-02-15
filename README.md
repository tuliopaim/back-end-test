# Teste vaga de Back-end da STYME
Este é o teste que nós aqui da STYME usamos para avaliar os candidatos para a vagas de back-end.


## Nossa Empresa
A Styme é uma empresa focada na gestão e automação de restaurantes e bares. Somos responsáveis por atender mais de 200 mil pessoas mensalmente. Entre nossos produtos, podemos destacar:

- **Styme Menu** é um Menu Inteligente que proporciona uma experiência completa, passando por todos os pontos primordiais em um restaurante, da escolha do prato até o pagamento da conta pela própria plataforma de maneira integrada e prática. 

- **Styme Host** Administre a sua fila de espera e reserva, mantenha o cliente informado sobre o tempo estimado de aguardo além de permitir acesso a fila de espera remota a seus clientes.

## O Desafio
Criar uma api (RESTful) que disponibiliza os ações para administração dos restaurantes.

- Você deve criar uma api capaz de;
  - CRUD de restaurantes (**R**ead com filtros)
  - CRUD de produtos do restaurante (**R**ead com filtros);

A estrutura do CRUD deve seguir o modelo do JSON a seguir:

Estrutura Restaurante
```
 // restaurant
    {
      "id": 1,
      "name": "Restaurante do Japonês",
      "address": "Rua do japonês, 123",
      "category": "Comida Japonesa",
      "location":"São Paulo",
      "imageUri":"https://st.depositphotos.com/1042799/1690/i/950/depositphotos_16905015-stock-photo-sushi-roll.jpg"
    }
```

Estrutura Menu
```
 // menu
 {
      "id": 1,
      "restaurantId": 1,
      "description": "Guioza",
      "price": 10,
      "imageUri": "https://st4.depositphotos.com/4366637/22798/i/1600/depositphotos_227984618-stock-photo-gyoza-pasta-stuffing-beef-beef.jpg",
      "category": "Pratos"
    }
```

## Pré-requisitos
Faça um fork desse repositório e evolua o desafio em cima dele.

Use o README para criar as instruções de como rodar o projeto.


## O que esperamos
Que você use dotnet core e swagger para a documentação dos endpoints, já o banco de dados fica a sua escolha =]

## O que vamos avaliar
- Se os objetivos do desafio foram alcançados;  =]
- Clareza  e organização do código;
- Principios de qualidade como SOLID, DRY, KISS e YAGNI
- A documentação do projeto (swagger);
- Performance;
- Histórico de commits do git;
- Testes (o que você achar necessário)
