terraform {
  required_version = ">= 1.0"
  required_providers {
    random = {
      source  = "hashicorp/random"
      version = "~> 3.5"
    }
    aws = {
      source  = "hashicorp/aws"
      version = "~> 5.0"
    }
  }
  backend "local" {}
}

provider "aws" {
  region = var.aws_region
}

# Random deployment ID
resource "random_string" "suffix" {
  length  = 8
  special = false
  upper   = false
}

# Read AWS account info (no permissions needed)
data "aws_caller_identity" "current" {}
data "aws_region" "current" {}

# Successful deployment simulation
resource "null_resource" "deployment" {
  triggers = {
    deployment_id = random_string.suffix.result
    timestamp     = timestamp()
  }
  
  provisioner "local-exec" {
    command = "echo ========================================== && echo Terraform Deployment Successful && echo Deployment ID: ${random_string.suffix.result} && echo Account: ${data.aws_caller_identity.current.account_id} && echo Region: ${data.aws_region.current.name} && echo =========================================="
  }
}