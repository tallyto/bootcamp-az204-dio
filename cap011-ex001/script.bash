# Define the location for the resource group and Redis instance
myLocation=eastus2

# Create a resource group in the specified location
az group create --name az204-redis-dio-tallyto-rg --location $myLocation

# Define the name for the Redis instance
redizName=az204-redis-dio-tallyto-name

# Create a Redis instance with the specified parameters
az rediz create --location $myLocation --name $redizName --resource-group az204-redis-dio-tallyto-rg --sku Basic --vm-size C0

# Delete the resource group and all resources within it
az group delete --name az204-redis-dio-tallyto-rg --yes --no-wait