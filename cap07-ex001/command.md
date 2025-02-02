myLocation=eastus2

myNameSpaceName=az204svcbustallyto

az group create --name az204-svc-rg --location $myLocation

az servicebus namespace create --resource-group az204-svc-rg --name $myNameSpaceName --location $myLocation

az servicebus queue create --resource-group az204-svc-rg --namespace-name $myNameSpaceName --name az204-queue