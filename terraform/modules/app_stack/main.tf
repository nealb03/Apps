terraform {
  required_version = ">= 1.5.0"

  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 5.0"
    }
  }
}

provider "aws" {
  region = var.aws_region
}

locals {
  # Consistent naming prefix for all resources in this stack
  name_prefix = "${var.app_name}-${var.environment}"

  # Common tagging strategy, merged with any extra tags passed in
  common_tags = merge(
    {
      Application = var.app_name
      Environment = var.environment
      ManagedBy   = "terraform"
    },
    var.tags
  )
}

# S3 bucket for the application
resource "aws_s3_bucket" "app_bucket" {
  bucket = "${local.name_prefix}-bucket"

  tags = local.common_tags
}

# EC2 instance for the application
resource "aws_instance" "app_server" {
  # NOTE: This AMI is an example Amazon Linux 2 AMI in us-east-1.
  # In a real setup, you’d parameterize or data source this by region.
  ami           = "ami-0c02fb55956c7d316"
  instance_type = var.instance_type

  tags = local.common_tags
}

# RDS instance for the application (demo-level config)
resource "aws_db_instance" "app_db" {
  identifier          = "${local.name_prefix}-db"
  engine              = var.db_engine
  instance_class      = "db.t3.micro"
  allocated_storage   = 20
  username            = "appuser"
  password            = "ChangeMe12345!" # DEMO ONLY – use secrets/SSM in real environments
  skip_final_snapshot = true

  tags = local.common_tags
}