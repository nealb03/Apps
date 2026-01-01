################################
# Demo / metadata-style outputs #
################################

output "aws_account_id" {
  description = "AWS account ID (demo value from variable, not from AWS)"
  value       = var.aws_account_id
}

output "aws_region" {
  description = "AWS region (demo value from variable, not from AWS)"
  value       = var.aws_region
}

output "iam_user_arn" {
  description = "IAM user ARN for GitHub Actions (demo value from variable, not from AWS)"
  value       = var.iam_user_arn
}

output "deployment_id" {
  description = "Random deployment ID used in this demo"
  value       = random_string.suffix.result
}

output "deployment_timestamp" {
  description = "Timestamp from the null_resource triggers"
  value       = null_resource.app1_deployment.triggers.timestamp
}

output "status" {
  description = "Human-readable status message for this demo deployment"
  value       = "✅ Demo deployment simulation completed successfully"
}

######################################
# Real infra outputs from app_stack  #
######################################

output "bucket_name" {
  description = "App1 S3 bucket name (from app_stack module)"
  value       = module.app_stack.bucket_name
}

output "instance_id" {
  description = "App1 EC2 instance ID (from app_stack module)"
  value       = module.app_stack.instance_id
}

output "db_endpoint" {
  description = "App1 RDS endpoint (from app_stack module)"
  value       = module.app_stack.db_endpoint
}