# Project 1: S3 + EC2 + RDS Architecture

## Overview

Project 1 implements a **traditional three-tier web application** on AWS, using managed services where appropriate and a Windows EC2 instance for the API layer.

**Architecture:**

- **Frontend:** React Single Page Application (SPA) hosted on **Amazon S3 Static Website Hosting**
- **Backend:** **ASP.NET Core Web API** running on **Windows Server EC2**
- **Database:** **MySQL 8.0** on **Amazon RDS**

This pattern is ideal for **learning, low-to-medium traffic workloads**, and scenarios where you want **direct control over the VM** hosting the backend.

---

Key Features
Simple, traditional deployment model
Single EC2 instance running the ASP.NET Core Web API

React frontend built locally and synced to S3
Managed database
Amazon RDS MySQL handles backups, patching, and availability within a single AZ

Direct server control
Full RDP access to the Windows EC2 instance
Useful for learning Windows Server administration and IIS/.NET hosting

Cost-conscious for small workloads
Suitable for low traffic or demo environments

Tech Stack
Frontend:
React, Vite
Deployed as static assets to S3 Static Website Hosting

Backend:
C#, ASP.NET Core Web API

Entity Framework Core for data access
Hosted on Windows Server EC2

Database:
Amazon RDS MySQL 8.0

AWS Services:
Amazon S3 (static website hosting)

Amazon EC2 (Windows)

Amazon RDS (MySQL)

VPC, Security Groups, IAM (for network and access control)

Access (Demo Environment)
Frontend:
http://nealb03-frontend-bucket-unique-2887.s3-website-us-east-1.amazonaws.com/

Backend API:
http://34.192.116.54:5001

These are demo endpoints and may be stopped or changed outside of active demo periods.

Quick Start (Local Build & Deploy)
1. Frontend → S3 Static Website
cd Project1-S3-EC2-RDS

# Frontend
cd Frontend
npm install
npm run build

# Deploy static files to S3 (replace bucket name if needed)
aws s3 sync dist/ s3://nealb03-frontend-bucket-unique-2887 --delete
Copy
2. Backend → Windows EC2
On the EC2 instance (RDP in, then):

cd C:\path\to\Backend

dotnet restore
dotnet run --urls "http://0.0.0.0:5001"
Copy
Ensure:

Security Group allows inbound traffic on the API port (e.g. 5001) from the necessary sources.

The frontend is configured to call the correct backend API URL.

Learning Focus
This project is designed to highlight:

Traditional VM-based deployment on AWS

Manual infrastructure management (EC2, RDP, app hosting)

Windows Server + ASP.NET Core administration

How a React SPA on S3 can talk to a backend API on EC2

Basic integration with Amazon RDS MySQL in a three-tier architecture



