# Cadastro de Pedidos

# Api
A WebApi foi criada utilizando as seguintes tecnologias: 
- .NET Core 6
- Entity Framework Core (InMemory)
- Xunit
- Shouldly
- AutoFixture

Foram criados testes para cada função e método dentro das camadas application e services.
O projeto foi criado baseado em arquitetura limpa, com separação de todas as camadas: 
- Dominio
- Application
- Service
- Repository

# Banco de dados
Um script com a criação das tabelas e relacionamentos também está incluido, para o caso de remover o banco de dados InMemory e começar a salvar os dados no SQL Server e também para análise do modelo de dados que foi criado.

# Web 
O projeto web foi desenvolvido utilizando o Angular v17 e Bootstrap 4

# Instalação 

## Api
Para utilizar a WebApi basta ter a versão 6 do [SDK](https://choosealicense.com/licenses/mit/](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)https://dotnet.microsoft.com/en-us/download/dotnet/6.0) do .NET Core. 
Para verificar se o SDK já está instalado, utilize o comando abaixo, caso a versão 6 apareca no resultado, o SDK já está instalado na sua maquina!
```bash
dotnet --list-sdks
```
Após a instalação do SDK, no CMD dentro da pasta do projeto WebApi executar o comando: 
```bash
dotnet run
```
Após isso a API já estará funcionando! Lembrando que os dados estão sendo salvos em memória, sempre que a API parar de ser executada os dados serão excluídos.
Urls que a api estará disponível: 
- [https://localhost:7189](https://localhost:7189/swagger/index.html)
- [http://localhost:5174](http://localhost:5174/swagger/index.html)

## Web
Verifique se o NodeJS está instalado na sua maquina com o comando 
```bash
node --version
```
A versão mínima do NodeJS para executar o Angular v17 é a ^20.9.0. Caso não tenha o NodeJS instalado ou tenha uma versão mais antiga, será necessário atualiza-lo.
Utilize esse [link](https://nodejs.org/en) oficial para baixar a versão. Recomendo baixar a versão LTS
Após baixar faça a instalação do pacote normalmente.
Depois de instalar com sucesso o NodeJS entre na pasta do projeto web e execute o comando abaixo no cmd: 
```bash
npm install
```
Esse comando irá instalar todos os pacotes necessários para que o projeto execute. Depois da instalação dos pacotes finalizar execute o proximo comando para buildar o projeto web e executa-lo em algum navegador.
```bash
npm start
```
Url que o projeto web estará disponível: 
- http://localhost:4200

## License
[MIT](https://choosealicense.com/licenses/mit/)
