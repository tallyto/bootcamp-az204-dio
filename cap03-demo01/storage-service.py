from azure.storage.blob import BlobClient, ContainerClient, BlobServiceClient, PublicAccess

from dotenv import load_dotenv

import os

load_dotenv()

connection_string = os.getenv('AZURE_STORAGE_CONNECTION_STRING')

def upload_file_blob_client(container_name: str):
    blob_client = BlobClient.from_connection_string(connection_string, container_name, 'arquivo.txt')
    # Upload de um arquivo para o blob
    with open('arquivo.txt', 'rb') as data:
        blob_client.upload_blob(data)
        print('Arquivo enviado com sucesso!')

    # Download de um arquivo do blob
    with open('arquivo-baixado.txt', 'wb') as download_file:
        download_file.write(blob_client.download_blob().readall())
        print('Arquivo baixado com sucesso!')

def admin_containers(operation: str, container_name: str):
    # conexão com o container
    container_client = BlobServiceClient.from_connection_string(connection_string)

    match operation:
        case "list":
        # listar todos os blobs no container
            print("Blobs no container:")
            for blob in container_client.list_blobs():
                print(blob.name)
        case "create":
        # criar um novo container
            container_client.create_container(container_name)
            print("Container criado com sucesso!")
        case "delete":
        # deletar um container
            container_client.delete_container()
            print("Container deletado com sucesso!")

def service_blob(container_name: str):
    blob_service_client = BlobServiceClient.from_connection_string(connection_string)

    container_client = blob_service_client.get_container_client(container_name)

    properties = container_client.get_container_properties()

    print(f"Nivel de acesso atual: {properties['public_access']}")

    # Alterar o nível de acesso do container
    container_client.set_container_access_policy(public_access=PublicAccess.CONTAINER, signed_identifiers={})

    print(f"O nível de acesso do container {container_name} foi alterado para Blob")



# admin_containers("create", "tsousa-container")
# upload_file_blob_client("tsousa-container")
service_blob("tsousa-container")
