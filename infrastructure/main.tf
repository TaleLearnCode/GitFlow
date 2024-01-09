resource "azurerm_resource_group" "resource-group" {
	name     = "rg-HelloWorld"
	location = "East US"
}

resource "azurerm_storage_account" "storage-account" {
		name                     = "sthelloworldusedev"
		resource_group_name      = azurerm_resource_group.resource-group.name
		location                 = azurerm_resource_group.resource-group.location
		account_tier             = "Standard"
		account_replication_type = "LRS"
}

resource "azurerm_service_plan" "service-plan" {
	name                = "asp-helloworld-use-dev"
	resource_group_name = azurerm_resource_group.resource-group.name
	location            = azurerm_resource_group.resource-group.location
	os_type             = "Linux"
	sku_name            = "Y1"
}

resource "azurerm_linux_function_app" "function-app" {
	name                = "func-helloworld-use-dev"
	resource_group_name = azurerm_resource_group.resource-group.name
	location            = azurerm_resource_group.resource-group.location

	storage_account_name       = azurerm_storage_account.storage-account.name
	storage_account_access_key = azurerm_storage_account.storage-account.primary_access_key
	service_plan_id            = azurerm_service_plan.service-plan.id

	site_config {
		application_stack {
			dotnet_version              = "8.0"
			use_dotnet_isolated_runtime = "true"
		}
	}
	app_settings = {
		EnvironmentName = "Terraform-Dev"
		SCM_DO_BUILD_DURING_DEPLOYMENT = "0"
		WEBSITE_USE_PLACEHOLDER_DOTNETISOLATED = "1"
	}

	tags = {
		environment = "terraform-dev"
	}

}

resource "azurerm_linux_function_app_slot" "function-app-slot" {
	name = "staging"
	function_app_id = azurerm_linux_function_app.function-app.id
	storage_account_name = azurerm_storage_account.storage-account.name

	site_config {
		application_stack {
			dotnet_version              = "8.0"
			use_dotnet_isolated_runtime = "true"
		}
	}
	app_settings = {
		EnvironmentName = "Terraform-DevStaging"
		SCM_DO_BUILD_DURING_DEPLOYMENT = "0"
		WEBSITE_USE_PLACEHOLDER_DOTNETISOLATED = "1"
	}

}