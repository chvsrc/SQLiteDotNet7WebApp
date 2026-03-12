variable "resourcegroupname" {
  description = "The name of the resource group in which to create the resources."
  type        = string
  default     = "mysqlitewebapp-rg"
}

variable "location" {
  description = "location"
  type        = string
  default     = "canadacentral"
}

variable "appservice_planname" {
  description = "The name of the App Service Plan to create."
  type        = string
  default     = "mysqlitewebapp-plan"
}

variable "webappname" {
  description = "The name of the Web App to create."
  type        = string
  default     = "mysqlitewebapp-12321"
}
