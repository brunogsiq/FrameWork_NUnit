
## **1️⃣ Estrutura do Projeto**
Teremos uma estrutura parecida com esta:

```
LoginSystem/
│-- LoginSystem.sln       # Solução do Visual Studio
│
├── LoginSystem/          # Projeto principal (Lógica de Negócio)
│   ├── Models/
│   │   ├── User.cs       # Modelo de usuário
│   ├── Services/
│   │   ├── AuthService.cs # Serviço de autenticação
│   ├── Program.cs        # Ponto de entrada do sistema
│
├── LoginSystem.Tests/    # Projeto de Testes Unitários
│   ├── AuthServiceTests.cs  # Testes do serviço de autenticação
│   ├── LoginSystem.Tests.csproj
│
├── LoginSystem.sln       # Solução do projeto
```

Agora, vamos codificar passo a passo.

---

## **2️⃣ Criando o Projeto**
1️⃣ No terminal ou no Visual Studio, crie a solução:
```sh
dotnet new sln -n LoginSystem
```

2️⃣ Crie o **projeto principal**:
```sh
dotnet new classlib -n LoginSystem
```

3️⃣ Crie o **projeto de testes**:
```sh
dotnet new nunit -n LoginSystem.Tests
```

4️⃣ Adicione os projetos à solução:
```sh
dotnet sln add LoginSystem/LoginSystem.csproj
dotnet sln add LoginSystem.Tests/LoginSystem.Tests.csproj
```

5️⃣ Adicione referência entre os projetos:
```sh
dotnet add LoginSystem.Tests reference LoginSystem
```

---

## **3️⃣ Criando a Lógica do Login**
Agora, implementamos a **lógica de autenticação** no projeto principal.

📌 **Crie o modelo de usuário**
Arquivo: `LoginSystem/Models/User.cs`
```csharp
namespace LoginSystem.Models;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
```

📌 **Crie o serviço de autenticação**
Arquivo: `LoginSystem/Services/AuthService.cs`
```csharp
namespace LoginSystem.Services;
using LoginSystem.Models;

public class AuthService
{
    private readonly List<User> _users;

    public AuthService()
    {
        // Simulação de banco de dados (usuários cadastrados)
        _users = new List<User>
        {
            new User("admin", "1234"),
            new User("user", "senha")
        };
    }

    public bool Login(string username, string password)
    {
        return _users.Any(user => user.Username == username && user.Password == password);
    }
}
```

📌 **Criar um programa para testar**
Arquivo: `LoginSystem/Program.cs`
```csharp
using System;
using LoginSystem.Services;

class Program
{
    static void Main()
    {
        var authService = new AuthService();

        Console.Write("Usuário: ");
        string username = Console.ReadLine();

        Console.Write("Senha: ");
        string password = Console.ReadLine();

        if (authService.Login(username, password))
        {
            Console.WriteLine("Login bem-sucedido!");
        }
        else
        {
            Console.WriteLine("Usuário ou senha incorretos.");
        }
    }
}
```

Agora, se você rodar o projeto:
```sh
dotnet run --project LoginSystem
```
Ele solicitará **usuário e senha**, e verificará se os dados existem no nosso "banco de dados" (lista interna).

---

## **4️⃣ Criando os Testes Unitários**
Agora, testamos a lógica de login com **NUnit**.

📌 **Crie os testes do AuthService**
Arquivo: `LoginSystem.Tests/AuthServiceTests.cs`
```csharp
using NUnit.Framework;
using LoginSystem.Services;

namespace LoginSystem.Tests;

[TestFixture]
public class AuthServiceTests
{
    private AuthService _authService;

    [SetUp]
    public void Setup()
    {
        _authService = new AuthService();
    }

    [Test]
    public void Login_CredenciaisValidas_DeveRetornarVerdadeiro()
    {
        // Arrange
        string username = "admin";
        string password = "1234";

        // Act
        bool resultado = _authService.Login(username, password);

        // Assert
        Assert.That(resultado, Is.True);
    }

    [Test]
    public void Login_CredenciaisInvalidas_DeveRetornarFalso()
    {
        // Arrange
        string username = "admin";
        string password = "senhaErrada";

        // Act
        bool resultado = _authService.Login(username, password);

        // Assert
        Assert.That(resultado, Is.False);
    }

    [Test]
    public void Login_UsuarioInexistente_DeveRetornarFalso()
    {
        // Arrange
        string username = "naoExiste";
        string password = "qualquerCoisa";

        // Act
        bool resultado = _authService.Login(username, password);

        // Assert
        Assert.That(resultado, Is.False);
    }
}
```

---

## **5️⃣ Executando os Testes**
Para rodar os testes unitários:
```sh
dotnet test
```

Saída esperada:
```
Test Run Successful.
Total tests: 3
Passed: 3
```

---

## **6️⃣ Melhorias Finais**
✔ **Usar criptografia de senha** em vez de armazenar diretamente.  
✔ **Testar mais casos** como entradas vazias e caracteres especiais.  
✔ **Separar repositórios e serviços** para facilitar manutenção.  

Agora você tem um **projeto realista** e **testes unitários aplicados na prática!** 🎯

Se precisar de mais detalhes ou quiser adicionar novas funcionalidades, me avise! 🚀