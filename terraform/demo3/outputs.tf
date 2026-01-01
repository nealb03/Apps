output "deployment_id" {
  description = "Unique deployment identifier"
  value       = random_string.suffix.result
}

output "aws_account_id" {
  description = "AWS Account ID"
  value       = data.aws_caller_identity.current.account_id
}

output "aws_region" {
  description = "AWS Region"
  value       = data.aws_region.current.name
}

output "iam_user_arn" {
  description = "IAM User ARN"
  value       = data.aws_caller_identity.current.arn
}

output "deployment_timestamp" {
  description = "Deployment timestamp"
  value       = timestamp()
}

output "status" {
  description = "Deployment status"
  value       = "✅ Deployment completed successfully"
}