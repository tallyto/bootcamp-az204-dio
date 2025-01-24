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