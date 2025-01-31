from azure.cosmos import CosmosClient, PartitionKey, exceptions
from dotenv import load_dotenv
import os
load_dotenv()

URL = os.getenv("COSMOS_URL")
KEY = os.getenv("COSMOS_KEY")
DATABASE_NAME = os.getenv("COSMOS_DATABASE")
CONTAINER_NAME = os.getenv("COSMOS_CONTAINER")


client = CosmosClient(URL, KEY)

#Criar banco de dados
def create_database():
    try:
        database = client.create_database(DATABASE_NAME)
        print(f"Database {DATABASE_NAME} created")
    except exceptions.CosmosResourceExistsError:
        database = client.get_database_client(DATABASE_NAME)
        print(f"Database {DATABASE_NAME} already exists")
    return database

database = create_database()

def create_container(database):
    try:
        print(f"Creating container {CONTAINER_NAME}")
        container = database.create_container(id=CONTAINER_NAME, partition_key=PartitionKey(path="/produto"))
        print(f"Container {CONTAINER_NAME} created")
    except exceptions.CosmosResourceExistsError:
        container = database.get_container_client(CONTAINER_NAME)
        print(f"Container {CONTAINER_NAME} already exists")
    return container

container = create_container(database)

#criar item no container
def create_item(container, item):
    container.create_item(body=item)
    print("Item criado")

#atualiza item no container
def update_item(container, item):
    item["quantidade"] = 20
    container.upsert_item(body=item)
    print("Item atualizado")

#deletar item no container
def delete_item(container, item):
    container.delete_item(item["id"], partition_key=item["produto"])
    print("Item deletado")

def read_item(container, item):
    item = container.read_item(item["id"], partition_key=item["produto"])
    print(item)

def read_items(container):
    items = container.read_all_items()
    for item in items:
        print(item)


  
item = {
    "id": "2",
    "produto": "Notebook",
    "quantidade": 10,
    "preco": 3000
}

# create_item(container, item)
# update_item(container, item)
# delete_item(container, item)
# read_item(container, item)
read_items(container)