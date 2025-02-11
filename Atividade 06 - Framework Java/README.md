# Framework Generico de gerenciamento de entidades em Java

## Descrição
Este projeto é um framework Java que permite gerenciar entidades genéricas com operações básicas de CRUD (Create, Read, Update, Delete). Ele possui duas implementações de repositório:

1. **InMemoryRepository** - Armazena os objetos em uma lista na memória.
2. **InFileRepository** - Armazena os objetos em um arquivo CSV.

## Estrutura do Projeto
O projeto contém as seguintes classes:

- **CrudRepository<T>**: Interface genérica que define operações CRUD.
- **InMemoryRepository<T>**: Implementação baseada em lista.
- **InFileRepository<T>**: Implementação baseada em arquivo CSV.
- **Produto**: Classe de exemplo para teste.
- **Main**: Classe principal que demonstra o uso do framework.

## Como Usar
Para testar o projeto basta executar o arquivo main, que nele está implamentado um exemplo da utilização do framwork.
