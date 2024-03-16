# API C# na Prática Rocketseat
API em C# para realizar o uplodad de fotos no Google Drive

## Especificações
- Linguagem: C#
- Framework: NET

## Observações Antes de Rodar
Necessário configurar um arquivo .env para rodar com as seguintes configurações:
```bash
Name="" # Name of email Google Drive
Email="" # Email Google Drive
RefreshToken="" # Refresh token of Oauth client Google
AccessToken="" # Access token of Oauth client Google
ClientId="" # Client ID of Google App created
ClientSecret="" # Client secret of Google App created
```

## Como usar o projeto
- Ter o Visual Studio 2022
- Abrir o SLN
- Executar o HTTP
- No Program.Cs do API, mudar em DataStore para o nome do seu correto
- No GoogleDriveStorageService.cs do Infra, mudar em ApplicationName para o nome do seu correto
- Rodar no Swagger a rota: /api/Storage