########################################
# Core environment / app configuration #
########################################

variable "environment" {
  description = "Deployment environment name (e.g. sandbox, dev, qa, prod)"
  type        = string
  default     = "sandbox"
}

variable "app_name" {
  description = "Logical name of the application"
  type        = string
  default     = "app1-s3-ec2-rds"
}

variable "aws_region" {
  description = "AWS region"
  type        = string
  default     = "us-east-1"
}

########################################
# Infra tuning for the app_stack module #
########################################

variable "instance_type" {
  description = "EC2 instance type used by the app_stack module"
  type        = string
  default     = "t3.micro"
}

variable "db_engine" {
  description = "Database engine used by the app_stack module"
  type        = string
  default     = "postgres"
}

##########################
# Demo / metadata fields #
##########################

variable "github_repository" {
  description = "Full GitHub repository slug (owner/repo) where this Terraform code lives (demo/logging only)"
  type        = string
  default     = "nealb03/Apps"
}

# These are kept as plain strings for demo/logging purposes.
# They are NOT used to actually authenticate or call AWS.

variable "aws_account_id" {
  description = "AWS account ID (demo string only, not used to call AWS)"
  type        = string
  default     = "288761763536"
}

variable "iam_user_arn" {
  description = "IAM user ARN for GitHub Actions (demo string only, not used to call AWS)"
  type        = string
  default     = "arn:aws:iam::288761763536:user/github-actions-user"
}

##########################################
# Optional, unused demo feature switches #
##########################################

variable "enable_encryption" {
  description = "Demo flag (not used in this sample configuration)"
  type        = bool
  default     = false
}

variable "enable_versioning" {
  description = "Demo flag (not used in this sample configuration)"
  type        = bool
  default     = false
}