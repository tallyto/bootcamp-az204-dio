```bash
# Define o nome do Key Vault
myKeyVault=az204vault-tsousa-dio

# Define a localização para os recursos do Azure
myLocation=esatus

# Cria um Resource Group no Azure com o nome especificado e na localização definida
az group create --name az204-vault-tsousa --location $myLocation

# Cria um Key Vault associado ao Resource Group criado anteriormente
az keyvault create --name $myKeyVault --resource-group az204-vault-tsousa --location $myLocation

# Armazena um segredo chamado "ExemplePass" com o valor "sousa-dio" no Key Vault
az keyvault secret set --vault-name $myKeyVault --name "ExemplePass" --value "sousa-dio"

# Recupera e exibe o segredo "ExemplePass" armazenado no Key Vault
az keyvault secret show --name "ExemplePass" --vault-name $myKeyVault

```