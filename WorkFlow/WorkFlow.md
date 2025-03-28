### **1️⃣ Criando um Workflow no GitHub Actions**
    Para configurar um workflow, crie um arquivo chamado **`ci.yml`** dentro do repositório no caminho:
    ```
    .github/workflows/ci.yml
    ```

    Adicione o seguinte código:

    ```yaml
    name: Build and Test

    on:
    push:
        branches:
        - main
        - develop
    pull_request:
        branches:
        - main
        - develop

    jobs:
    build-and-test:
        runs-on: ubuntu-latest

        steps:
        - name: Checkout código
            uses: actions/checkout@v3

        - name: Configurar .NET
            uses: actions/setup-dotnet@v3
            with:
            dotnet-version: '8.0.x'

        - name: Restaurar pacotes
            run: dotnet restore

        - name: Compilar projeto
            run: dotnet build --configuration Release --no-restore

        - name: Executar testes unitários
            run: dotnet test --configuration Release --no-build --logger trx --results-directory TestResults
```

### **2️⃣ Como Funciona Esse Workflow?**

    1. **Disparo Automático:** Executa o fluxo sempre que houver um **push** ou **pull request** para `main` ou `develop`.
    2. **Ambiente Linux:** O job roda no ambiente `ubuntu-latest`, mas pode ser alterado para `windows-latest` ou `macos-latest`.
    3. **Passo a Passo:**
    - Faz o **checkout** do código.
    - Instala o **.NET SDK** na versão **8.0** (você pode trocar a versão se necessário).
    - Restaura os pacotes do projeto com `dotnet restore`.
    - Compila o projeto em **Release** para garantir uma build otimizada.
    - Executa os **testes unitários** usando `dotnet test`.

---

### **3️⃣ Saída do Workflow**

    Se tudo der certo, o GitHub Actions mostrará os testes passando ✅ ou falhando ❌.  

    Exemplo de saída de testes no **GitHub Actions**:

    ```
    Test run for ProjetoNUnit.dll(.NET 8.0)
    Starting test execution, please wait...
    Passed! - 3 tests passed
    ```

    ---

    ### **4️⃣ Testes Rodando Localmente**
    Antes de enviar para o GitHub, você pode rodar os testes localmente para garantir que tudo está funcionando:
    ```sh
    dotnet test
    ```

    Isso executa todos os testes unitários no seu projeto e exibe os resultados no terminal.

---

### **5️⃣ Melhorias Possíveis**
- Enviar **relatórios de testes** como artefatos no GitHub Actions.
- Integrar com **SonarQube** para análise de qualidade do código.
- Rodar testes em diferentes **plataformas (Windows, Linux, Mac)**.
- Configurar notificações no **Slack ou email** quando os testes falharem.