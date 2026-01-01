# Project 2: ECS Fargate Architecture

Project 2 demonstrates a **modern, containerized serverless architecture** on AWS using **ECS Fargate** for both frontend and backend services, backed by **Amazon RDS MySQL** and fronted by an **Application Load Balancer (ALB)**.

---

## 🏗 Architecture Overview

- **Frontend:** React SPA running in a Docker container on ECS Fargate
- **Backend:** API service running in a Docker container on ECS Fargate
- **Networking:** Application Load Balancer routing traffic to ECS services
- **Data:** Amazon RDS MySQL (multi‑AZ) for persistence
- **Orchestration:** Amazon ECS with Fargate (no EC2 management)
- **CI/CD & IaC:** GitHub Actions + CloudFormation/Terraform

This pattern is suitable for **production‑grade**, **auto‑scaling**, and **highly available** workloads.

---

## 🧰 Technology Stack

### Frontend

- React single-page application (SPA)
- Dockerized and pushed to **Amazon ECR**
- Deployed as an **ECS Fargate service**
- Fronted by an **Application Load Balancer**
- Auto-scaling based on CPU/Memory utilization

### Backend

- Containerized API service (language-agnostic; any containerized API works)
- Docker image stored in **Amazon ECR**
- Deployed as an **ECS Fargate service**
- Behind the same or a dedicated **ALB** target group
- Auto-scaling policies driven by CPU/Memory or request load

### Database

- **Amazon RDS MySQL**
- Multi-AZ deployment for high availability
- Security groups restricting access to the backend service only

---

## ✨ Key Features

- **Auto-scaling:**  
  ECS Service Auto Scaling adjusts the number of Fargate tasks based on CPU/Memory or custom CloudWatch metrics.

- **High Availability:**  
  - Multi-AZ RDS deployment  
  - ECS tasks distributed across multiple AZs behind an ALB  
  - Health checks at the ALB and ECS service levels

- **CI/CD:**  
  - **GitHub Actions** build and push Docker images to ECR  
  - CI jobs can update ECS task definitions and trigger new deployments  
  - Supports rolling updates with minimal downtime

- **Infrastructure as Code:**  
  - CloudFormation and/or Terraform templates define ECS services, ALB, target groups, listeners, and RDS
  - Enables repeatable, version-controlled infrastructure changes

- **Container Orchestration:**  
  - AWS ECS with Fargate handles scheduling, scaling, and health management  
  - No need to manage EC2 instances or container hosts

---

## 🚀 Deployment Overview

A typical deployment flow for this project:

1. **Build & Package**
   - Frontend and backend are built as Docker images.
   - Images are tagged (e.g., with commit SHA) and pushed to **Amazon ECR**.

2. **CI/CD (GitHub Actions)**
   - On push/merge to main:
     - Run unit/build tests
     - Build Docker images
     - Push images to ECR
     - Update ECS task definitions with new image tags
     - Deploy updated task definitions to ECS Fargate services

3. **Runtime**
   - ALB receives incoming HTTP/HTTPS traffic.
   - Routes requests to the appropriate ECS Fargate service.
   - ECS handles task placement, scaling, and replacement of unhealthy tasks.

> For Terraform-specific details and the GitHub Actions workflows that can operate on multiple Terraform apps (including this Fargate app), see the [terraform/README.md](../terraform/README.md) at the repository root.

---

## 💰 Cost Optimization

- **Pay-per-use compute:**  
  Fargate charges per vCPU and memory used by running tasks; no EC2 instances to manage or pay for when idle.

- **Right-sized services:**  
  Task sizes (CPU/Memory) and auto-scaling policies can be tuned to match actual load.

- **No EC2 management overhead:**  
  Reduced operational cost and complexity (no patching, no instance fleets).

- **Production-friendly:**  
  This model is especially effective for applications with **variable or spiky traffic** where elasticity and managed infrastructure provide strong ROI.
