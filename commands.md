```bash
# Lista todos os Resource Groups com seus IDs (nomes)
az group list --query "[].{id:name}"

# Lista todos os Resource Groups em formato TSV (Tab-Separated Values)
az group list --query "[].{id:name}" -o tsv

# Cria um Web App na Azure usando HTML
az webapp up -g AZURE-204 -n lyto-html-app --html

# Lista as configurações dos Web Apps dentro do Resource Group especificado
az webapp list --resource-group az204-lab001

# Faz deploy de um arquivo ZIP para um Web App
az webapp deployment source config-zip --resource-group AZ204-LAB001 --src api.zip --name imgapitsousa001

# Faz deploy de outro arquivo ZIP para um Web App diferente
az webapp deployment source config-zip --resource-group AZ204-LAB001 --src web.zip --name imgwebtsousa001

# Inicializa uma Azure Function com runtime .NET isolado e framework alvo net8.0
func init --worker-runtime dotnet-isolated --target-framework net8.0 --force

# Cria uma função HTTP trigger chamada "Echo"
func new --template "HTTP trigger" --name "Echo"

# Cria uma função Timer Trigger chamada "Echo"
func new --template "TimerTrigger" --name "Echo"

# Adiciona o pacote de extensão do Azure Functions para Storage
 dotnet add package Microsoft.Azure.Functions.Worker.Extensions.Storage --version 6.2.0

# Publica a Azure Function no Azure
func azure functionapp publish lyto-processor-function --dotnet-version 8.0

# Adiciona o pacote para interação com o Azure Blob Storage
 dotnet add package Azure.Storage.Blobs --version 12.18.0

# Cria um Resource Group para o Azure Container Registry (ACR)
az group create --name az204-acr-rc --location eastus

# Cria um Azure Resource Connector (ARC) no Resource Group especificado
az arc create --resource-group az204-acr-rc --name acr-demo01-az2004 --sku Basic

# Cria um Azure Container Registry (ACR)
az acr create --resource-group az204-acr-rc --name acrdemo01az2004tsousa --sku Basic

# Cria um arquivo Dockerfile simples com a imagem hello-world
echo FROM mcr.microsoft.com/mcr/hello-world > Dockerfile

# Constrói uma imagem Docker e faz upload para o ACR
az acr build --image sample/hello-world:v1 --registry acrdemo01az2004tsousa --file Dockerfile .

# Lista todos os repositórios no ACR
az acr repository list --name acrdemo01az2004tsousa

# Lista os repositórios no ACR no formato de tabela
az acr repository list --name acrdemo01az2004tsousa --output table

# Mostra as tags da imagem armazenada no repositório do ACR
az acr repository show-tags --name acrdemo01az2004tsousa --repository sample/hello-world --output table

# Executa uma imagem diretamente do ACR
az acr run --registry acrdemo01az2004tsousa --cmd '$Registry/sample/hello-world:1' /dev/null

# Exclui o Resource Group e seus recursos associados
az group delete --name az204-acr-rc --no-wait
```

