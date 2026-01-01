output "bucket_name" {
  description = "Name of the S3 bucket"
  value       = aws_s3_bucket.app_bucket.bucket
}

output "instance_id" {
  description = "ID of the EC2 instance"
  value       = aws_instance.app_server.id
}

output "db_endpoint" {
  description = "RDS endpoint"
  value       = aws_db_instance.app_db.address
}