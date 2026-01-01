variable "aws_region" {
  description = "AWS region"
  type        = string
  default     = "us-east-1"
}

variable "environment" {
  description = "Environment name"
  type        = string
  default     = "demo"
}

variable "project_name" {
  description = "Project name"
  type        = string
  default     = "terraform-cicd-demo"
}

variable "github_repository" {
  description = "GitHub repository"
  type        = string
  default     = "nealb03/Project2"
}