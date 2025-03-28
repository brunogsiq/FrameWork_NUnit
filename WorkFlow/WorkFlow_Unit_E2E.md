## **1️⃣ Estrutura do Workflow**
    Aqui está um exemplo de **GitHub Actions** que roda **testes unitários** de **C# com NUnit** e **testes de automação frontend com Cypress**.

    Crie um arquivo **`ci.yml`** dentro do repositório no caminho:
    ```
    .github/workflows/ci.yml
    ```
    E adicione o seguinte código:

    ```yaml
    name: Build, Test and Cypress

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
    unit-tests:
        name: Testes Unitários .NET
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

    frontend-tests:
        name: Testes Frontend com Cypress
        runs-on: ubuntu-latest
        needs: unit-tests
        steps:
        - name: Checkout código
            uses: actions/checkout@v3

        - name: Instalar dependências do frontend
            run: npm install

        - name: Rodar testes E2E no Cypress
            run: npx cypress run
```

---

## **2️⃣ Como Esse Workflow Funciona?**

    1. **Trigger Automático:** Roda sempre que houver um **push** ou **pull request** para `main` ou `develop`.
    2. **Dois Jobs Separados:**
    - `unit-tests`: Executa os **testes unitários** no **.NET 8.0**.
    - `frontend-tests`: Executa os **testes E2E com Cypress**. Esse job só roda se os testes unitários passarem (`needs: unit-tests`).
    1. **Execução:**
    - Primeiro, os **testes unitários** são executados.
    - Se todos passarem, os **testes E2E** com Cypress começam.

---

## **3️⃣ Rodando Cypress Localmente**
    Antes de enviar para o GitHub, você pode rodar os testes localmente para garantir que está tudo certo:

    1. **Rodar NUnit (Testes Unitários)**
    ```sh
    dotnet test
    ```

    2. **Rodar Cypress (Testes Frontend)**
    ```sh
    npx cypress run
    ```

    Se quiser abrir o Cypress com interface gráfica:
    ```sh
    npx cypress open
    ```

## **4️⃣ Melhorias Possíveis**
- **Rodar em múltiplos navegadores** no Cypress (`chrome`, `firefox`, `edge`).
- **Gerar relatórios de testes** (JUnit, Allure, Mocha Reports).
- **Executar os testes frontend em paralelo** para maior velocidade.
- **Publicar resultados** no Slack ou email se houver falha.