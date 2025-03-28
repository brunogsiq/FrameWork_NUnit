Instale o .Net

    https://dotnet.microsoft.com/en-us/download/dotnet

Instale as dependências:

    code --install-extension formulahendry.dotnet
    code --install-extension formulahendry.dotnet-test-explorer
    code —-install-extension jmrog.vscode-nuget-package-manager
    code —-install-extension ms-dotnettools.csharp

Criando uma solução:

    dotnet new sln -o nomeSolucao

Criando Projeto

    dotnet new nunit -o nomeProjeto

Vinculando Solução + Projeto

    dotnet sln add ./ProjetoNUnit/ProjetoNUnit.csproj

Restaurando Pacote

    dotnet restore

Construindo Projeto

    dotnet build

Executando Testes

    dotnet test

Gerenciando os Testes

    É preciso uma configuração extra para habilitar a descoberta dos testes no Gerenciador de Testes do VSCode em máquinas Windows que tenham língua padrão o português brasileiro (PT-BR):

    1. Acessar o diretório do instalador do SDK .NetCore:
        C:\Program Files\dotnet\sdk\”sua_versão”

    2. Apagar a pasta PT-BR

    3. Abrir a linha de comando e executar:
        set DOTNET_CLI_UI_LANGUAGE=en