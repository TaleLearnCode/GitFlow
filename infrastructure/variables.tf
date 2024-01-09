variable "resource_group_location" {
	type        = string
	default     = "eastus"
	description = "Location of the resource group."
}

variable "resource_group_name_prefix" {
	type        = string
	default     = "rg"
	description = "Prefix of the resource group name that's combined with a random ID so name is unique in your Azure subscription."
}

variable "azure_subscription_id" {
	type = string
	description = "The subscription ID to use for the Azure account."
}

variable "azure_client_id" {
	type = string
	description = "The client ID to use for the Azure account."
}

variable "azure_tenant_id" {
	type = string
	description = "The tenant ID to use for the Azure account."
}

variable "azure_client_secret" {
	type = string
	description = "The client secret to use for the Azure account."
}