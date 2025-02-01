registryName=conregistry$RANDOM

az acr check-name --name $registryName

az acr create --resource-group AZ-204-LAB005 --name $registryName --sku Basic

az acr list --resource-group AZ-204-LAB005

az acr list --resource-group AZ-204-LAB005 --query "max_by([], &creationDate).name" --output tsv

acrName=$(az acr list --resource-group AZ-204-LAB005 --query "max_by([], &creationDate).name" --output tsv)

echo $acrName

az acr build --registry $acrName --image ipcheck:latest .

az acr update -n conregistry30085 --admin-enabled true
