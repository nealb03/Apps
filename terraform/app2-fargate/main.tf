terraform {
  required_version = ">= 1.5.0"

  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 5.0"
    }
    random = {
      source  = "hashicorp/random"
      version = "~> 3.5"
    }
    null = {
      source  = "hashicorp/null"
      version = "~> 3.2"
    }
  }

  # Demo-only: keep state local on the runner / machine.
  backend "local" {}
}

########################
# AWS Provider (root)  #
########################

provider "aws" {
  region = var.aws_region
}

locals {
  common_tags = {
    Application = var.app_name
    Environment = var.environment
    ManagedBy   = "terraform"
  }
}

###########################################
# Reusable application stack (child module)
###########################################

# For interview purposes, we’ll reuse the same app_stack module
# to show a common pattern across multiple apps.
# In a real-world Fargate app you might have a different module,
# but this cleanly demonstrates module reuse.

module "app_stack" {
  source = "../modules/app_stack"

  environment   = var.environment
  aws_region    = var.aws_region
  app_name      = var.app_name
  instance_type = var.instance_type
  db_engine     = var.db_engine
  tags          = local.common_tags
}

############################
# Random deployment suffix #
############################

resource "random_string" "suffix" {
  length  = 8
  special = false
  upper   = false
}

###################################
# Demo logging of this deployment #
###################################

resource "null_resource" "app2_deployment" {
  triggers = {
    deployment_id = random_string.suffix.result
    timestamp     = timestamp()
  }

  provisioner "local-exec" {
    command = <<-EOT
      echo "=================================================="
      echo "Terraform Demo Deployment - App2-Fargate (root)"
      echo "Deployment ID:      ${random_string.suffix.result}"
      echo "Environment:        ${var.environment}"
      echo "App Name:           ${var.app_name}"
      echo "GitHub Repository:  ${var.github_repository}"
      echo "AWS Account ID:     ${var.aws_account_id}"
      echo "AWS Region:         ${var.aws_region}"
      echo "IAM User ARN:       ${var.iam_user_arn}"
      echo "--------------------------------------------------"
      echo "Module Outputs:"
      echo "  S3 Bucket Name:   ${module.app_stack.bucket_name}"
      echo "  EC2 Instance ID:  ${module.app_stack.instance_id}"
      echo "  RDS Endpoint:     ${module.app_stack.db_endpoint}"
      echo "=================================================="
    EOT
  }
}