## GoodReads

### Escopo
Desenvolver uma API de gerenciamento de avaliação de livros que realiza uma integração com uma API externa de livros.
Ele deve permitir o cadastro validado de livros, avaliações e usuário.

### Entidades

#### Livro

- ID (GUID)
- Título (string)
- Descrição (string)
- ISBN (string)
- Autor (string)
- Editora (string)
- Genero (Enum)
- AnoPublicacao (int)
- Paginas (int)
- DataRegistro (DateTime)
- NotaMedia (decimal)
- CapaLivro (bytes)
- Avaliacoes (List<Avaliacao>)

#### Avaliação
- ID (GUID)
- Nota (int)
- Descricao (string)
- IdUsuario (int)
- IdLivro (int)
- DataRegistro (DateTime)

#### Usuario
- ID (GUID)
- Email (string)
- Nome (string)
- Avaliacoes (List<string>)

### Regras de negócio

- [ ] Data de início não pode ser maior que o fim de leitura, ao cadastrar a avaliação;
- [x] ISBN deve ser único ao cadastrar livro;
- [x] Nota deve ser de 1 a 5 ao cadastrar avaliação;
- [x] A nota média do livro deve ser recalculada a cada cadastro de avaliação;
- [ ] O usuário pode cadastrar apenas uma avaliação por livro;
- [x] O sistema deve gerar um relatório sobre a quantidade de livros lidos naquele ano (+);
- [x] O sistema deve permitir o usuário subir um arquivo com a capa do livro (+);
    - [x] Salvar em memória
- [x] O sistema deve permitir o usuário baixar um arquivo com a capa do livro (+);
    - [x] Baixar da memória
- [x] O sistema deve permitir consulta de livros em uma fonte externa (+);
    - [x] Configurar por meio de uma classe de opções;
    - [x] Criar o client com base no Google APIs;
- [x] O sistema deve realizar a autenticação e autorização do usuário (+);
  - [ ] Pedir autorização na camada de consulta externa;
  - [ ] Cadastrar avaliações de livros (reader ou admin);
  - [ ] Cadastrar um livro (apenas admin);

### Conceitos aplicados

- [ ] Utilizar documentação com o Swagger;
- [ ] Utilizar validação com o FluentValidation na camada de aplicação;
- [x] Utilizar camadas da arquitetura limpa;
- [x] Utilizar ORM EfCore com SQL Server nas entidades; 
- [x] Utilizar o padrão CQRS no projeto de acordo com as regras de negócio;
- [x] Utilizar o padrão Repository nas entidades do projeto;
- [x] Utilizar o padrão de resultados na camada de domínio;