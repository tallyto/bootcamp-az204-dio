# Comandos Azure CLI

## Listar resource groups

```bash
az group list --query "[].{id:name}"
```

```bash
az group list --query "[].{id:name} -o tsv"
```

## Cria um web app na azure

```bash
az webapp up -g AZURE-204 -n lyto-html-app --html
```

## Lista as configurações do webapp dentro do resource group

```bash
az webapp list --resource-group az204-lab001
```

## Faz deploy de um arquivo zip para o web app

```bash
az webapp deployment source config-zip --resource-group AZ204-LAB001 --src api.zip --name imgapitsousa001
```

```bash
az webapp deployment source config-zip --resource-group AZ204-LAB001 --src web.zip --name imgwebtsousa001
```

## Cria uma azure function

```bash
func init --worker-runtime dotnet-isolated --target-framework net8.0 --force
```

### Cria uma função http

```bash
 func new --template "HTTP trigger" --name "Echo"
```

### Cria uma função trigger

```bash
 func new --template "TimerTrigger" --name "Echo"
```

## Adiciona o pacote a aplicação

```bash
dotnet add package Microsoft.Azure.Functions.Worker.Extensions.Storage --version 6.2.0

```

## Publica a function

```bash
func azure functionapp publish lyto-processor-function --dotnet-version 8.0
```
