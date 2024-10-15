
# API de Consumers

Esta é uma API desenvolvida para gerenciar consumidores, utilizando os padrões Mediator e CQRS (Command Query Responsibility Segregation). A API permite a realização de operações CRUD (Create, Read, Update, Delete) em consumidores de forma eficiente e organizada.

## Tecnologias Utilizadas

- .NET 7
- C#
- Mediator Pattern
- CQRS
- Entity Framework Core (opcional)
- Swagger para documentação (opcional)

## Estrutura do Projeto

```
/src
    /YourProjectName
        /Controllers
        /Commands
        /Queries
        /Models
        /Data
        /Handlers
```

- **Controllers**: Contém os controladores da API que expõem as rotas.
- **Commands**: Contém as classes que representam os comandos para operações de escrita.
- **Queries**: Contém as classes que representam as consultas para operações de leitura.
- **Models**: Contém os modelos de dados utilizados na API.
- **Data**: Contém o contexto do banco de dados e as configurações necessárias.
- **Handlers**: Contém os manipuladores para os comandos e consultas.

## Controller

Aqui está um exemplo de como a API processa a criação de um consumidor:

```csharp
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Commands.Requests;
using Shop.Domain.Commands.Responses;
using Shop.Domain.Handlers;

namespace Shop.Controllers
{
    [Route("v1/consumers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost]  
        public Task<CreateCustomerResponse> Create([FromServices] IMediator mediator, [FromBody] CreateCustomerRequest command)
        {
            return mediator.Send(command);
        }
    }
}
```

### Explicação do Código Controller

1. **Imports**: As primeiras linhas importam os namespaces necessários, incluindo `MediatR` para o padrão Mediator e `Microsoft.AspNetCore.Mvc` para as funcionalidades da API.

2. **Namespace e Classe**: A classe `CustomerController` é definida dentro do namespace `Shop.Controllers`. Esta classe herda de `ControllerBase`, que fornece funcionalidades básicas para controladores de API.

3. **Roteamento**: O atributo `[Route("v1/consumers")]` define a rota base para todas as ações do controlador. Isso significa que todas as requisições para esta classe começarão com `v1/consumers`.

4. **Atributo ApiController**: O atributo `[ApiController]` indica que este controlador é uma API e permite que o ASP.NET Core realize a validação de modelo e o tratamento de erros automaticamente.

5. **Método Create**:
   - O método `Create` é um manipulador de requisições POST.
   - Ele recebe um comando `CreateCustomerRequest`, que contém os dados necessários para criar um novo consumidor, e utiliza o MediatR para enviar este comando.
   - O `mediator.Send(command)` envia o comando para o manipulador apropriado que executará a lógica de criação do consumidor. O resultado é retornado como um `Task<CreateCustomerResponse>`, que representa a resposta da criação do consumidor.


## Mediator

Aqui está uma explicação detalhada do código para o manipulador de criação de consumidores (`CreateCustomerHandler`):

```csharp
using MediatR;
using Shop.Domain.Commands.Requests;
using Shop.Domain.Commands.Responses;

namespace Shop.Domain.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        public Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateCustomerResponse
            {
                Id = Guid.NewGuid(),
                Name = "Diego Lins",
                Email = "diegolins@ibm.com",
                Date = DateTime.Now
            };

            return Task.FromResult(result);
        }
    }
}
```

### Explicação do Código

1. **Imports**:
   - `using MediatR;`: Importa a biblioteca MediatR, que implementa o padrão Mediator, facilitando a comunicação entre diferentes partes da aplicação.
   - `using Shop.Domain.Commands.Requests;`: Importa a classe `CreateCustomerRequest`, que contém os dados necessários para criar um novo consumidor.
   - `using Shop.Domain.Commands.Responses;`: Importa a classe `CreateCustomerResponse`, que representa a resposta após a criação de um consumidor.

2. **Namespace e Classe**:
   - O código está dentro do namespace `Shop.Domain.Handlers`, que agrupa os manipuladores relacionados à lógica de negócios.
   - A classe `CreateCustomerHandler` implementa a interface `IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>`. Isso significa que esta classe é responsável por lidar com requisições do tipo `CreateCustomerRequest` e retornar um `CreateCustomerResponse`.

3. **Método Handle**:
   - O método `Handle` é a implementação da lógica que será executada quando um comando `CreateCustomerRequest` for enviado pelo MediatR.
   - **Parâmetros**:
     - `CreateCustomerRequest request`: Representa o comando que contém os dados necessários para criar um novo consumidor. Este objeto é passado quando o comando é enviado.
     - `CancellationToken cancellationToken`: Um token que pode ser utilizado para cancelar a operação caso necessário.

4. **Criação da Resposta**:
   - Dentro do método, um novo objeto `CreateCustomerResponse` é criado e preenchido com dados fictícios:
     - `Id`: Um novo GUID é gerado para o consumidor.
     - `Name`: O nome do consumidor é definido como "Diego Lins".
     - `Email`: O e-mail é definido como "diegolins@ibm.com".
     - `Date`: A data atual é armazenada, representando o momento em que o consumidor foi criado.

5. **Retorno**:
   - `Task.FromResult(result)`: O resultado (neste caso, um objeto `CreateCustomerResponse`) é retornado como uma tarefa (`Task`), permitindo que a chamada seja assíncrona. Isso é importante em aplicações web para não bloquear o thread principal enquanto a operação é executada.

### Resumo

O `CreateCustomerHandler` é um manipulador que implementa a lógica para processar um comando de criação de consumidor. Ele gera um novo ID, define valores fictícios para o nome e e-mail, e retorna essas informações em um objeto de resposta. Esse padrão ajuda a separar as preocupações, permitindo que a lógica de manipulação de comandos fique isolada em uma classe específica, o que é uma prática recomendada no desenvolvimento de software usando CQRS e Mediator.  

## Instalação

1. Clone o repositório:

   ```bash
   git clone https://github.com/seuusuario/seurepositorio.git
   ```

2. Navegue até o diretório do projeto:

   ```bash
   cd seurepositorio/src/YourProjectName
   ```

3. Restaure as dependências:

   ```bash
   dotnet restore
   ```

4. Compile o projeto:

   ```bash
   dotnet build
   ```

5. Execute a aplicação:

   ```bash
   dotnet run
   ```

## Endpoints

A API oferece os seguintes endpoints:

### Consumers

- **GET /api/consumers**: Obtém a lista de todos os consumidores.
- **GET /api/consumers/{id}**: Obtém um consumidor específico pelo ID.
- **POST /api/consumers**: Cria um novo consumidor.
- **PUT /api/consumers/{id}**: Atualiza um consumidor existente.
- **DELETE /api/consumers/{id}**: Remove um consumidor.

## Documentação

A API é documentada utilizando Swagger. Após iniciar a aplicação, acesse a seguinte URL para visualizar a documentação:

```
http://localhost:5000/swagger
```

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
```

Esse README agora inclui a explicação do código que você forneceu, destacando como a API utiliza o MediatR para gerenciar a criação de consumidores. Sinta-se à vontade para ajustar qualquer parte conforme necessário!
