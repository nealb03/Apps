# AWS Cloud Architecture Projects Portfolio

This repository demonstrates two different AWS cloud architecture patterns for full-stack web applications, plus Terraform-based CI workflows using GitHub Actions.

---

## 📁 Projects

### [Project 1: S3 + EC2 + RDS (Traditional Three-Tier)](./Project1-S3-EC2-RDS/)

**Architecture:** Traditional three-tier with managed services

**Components:**
- **Frontend:** React SPA on S3 Static Website Hosting
- **Backend:** ASP.NET Core Web API on Windows EC2
- **Database:** MySQL on Amazon RDS

**Key Features:**
- Cost-effective for low-to-medium traffic
- Simple deployment model
- Direct control over EC2 instance
- Traditional VM-based architecture

**Tech Stack:** React, Vite, C#, ASP.NET Core, Entity Framework Core, MySQL

**Access:**
- Frontend: http://nealb03-frontend-bucket-unique-2887.s3-website-us-east-1.amazonaws.com/
- Backend API: http://34.192.116.54:5001

[📖 View Project 1 Documentation →](./Project1-S3-EC2-RDS/README.md)

---

### [Project 2: ECS Fargate (Containerized Serverless)](./Project2-Fargate/)

**Architecture:** Fully containerized serverless architecture

**Components:**
- **Frontend:** React container on ECS Fargate
- **Backend:** API container on ECS Fargate
- **Database:** Amazon RDS MySQL
- **Load Balancer:** Application Load Balancer

**Key Features:**
- Auto-scaling based on demand
- High availability with multi-AZ deployment
- Infrastructure as Code (CloudFormation/Terraform)
- CI/CD with GitHub Actions
- Container orchestration with ECS

**Tech Stack:** Docker, ECS Fargate, ECR, ALB, RDS

[📖 View Project 2 Documentation →](./Project2-Fargate/README.md)

---

## 🛠 Terraform Workflows (Multi-App)

In addition to the two application projects, this repo includes **Terraform CI workflows** that run against multiple Terraform “apps” under the `terraform/` folder.

Terraform apps live under:

```text
terraform/
  app1-s3-ec2-rds/
  app2-fargate/
  demo3/              # (reserved for future examples)


Terraform App (Demo)
Workflow file: .github/workflows/terraform-app.yml

Name: Terraform App (Demo)

Purpose: Safe, read‑only demo for interviews

Behavior:
Manual trigger (workflow_dispatch)

Inputs: app, environment, aws_region

Steps: terraform init → terraform validate → terraform plan

No apply step and no aws provider in the demo apps
→ can be run without AWS credentials and without creating resources.


Use this workflow in interviews to demonstrate CI + Terraform without any risk.


Terraform Deploy (Plan + Apply – Multi-App, Real Changes)
Workflow file: .github/workflows/terraform-deploy.yml

Name: Terraform Deploy (Plan + Apply - Multi-App, Real Changes)

Purpose: Real deployment workflow that can perform terraform apply

Behavior:
Manual trigger with inputs: app, environment, aws_region, confirm_apply

Uses TF_WORKDIR=terraform/${app} so the same workflow works for:
app1-s3-ec2-rds

app2-fargate

any future app under terraform/


Runs init → validate → plan

Runs apply only if confirm_apply is set to "APPLY"


This demonstrates how a single pipeline can deploy multiple Terraform apps with guardrails around real infrastructure changes.
