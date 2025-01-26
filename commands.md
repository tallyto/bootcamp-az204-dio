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
