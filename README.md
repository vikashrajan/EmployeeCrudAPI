

A modern, fully automated **ASP.NET Core (.NET 9)** RESTful API demonstrating clean architecture, persistent SQLite integration, strict Header-based Authorization, automated Azure CI/CD Pipelines, and Azure API Management (APIM) routing.

## 🛠️ Technology Stack
* **Back-End:** C# 12, .NET 9
* **Database:** Entity Framework Core (SQLite)
* **Documentation:** Swashbuckle (Swagger UI)
* **Logging:** Serilog
* **CI/CD:** Azure DevOps YAML Pipelines (Self-Hosted Agent)
* **Cloud Hosting:** Azure App Services (Linux)
* **API Gateway:** Azure API Management (APIM)

## 📋 Features
1. **CRUD Endpoints:** Complete RESTful operations for Employee records (`GET`, `POST`, `PUT`, `DELETE`).
2. **Dynamic Database Routing:** Custom C# startup logic that aggressively detects if the code is running on an Azure Linux App Service and instantly re-routes the SQLite `employee.db` file to the persistent `/home/` drive to bypass ZipDeploy read-only locks.
3. **Custom Security:** Strict `[ApiKeyAuthFilter]` middleware requiring `X-Api-Key` headers on all restricted endpoints.
4. **APIM Gateway Integration:** Endpoints securely masked behind an Azure API Management gateway, shielding the backend password while enforcing consumer Subscription Keys.
5. **Health Checks:** Native `/api/health` configuration.

---

## 🚀 Step-by-Step Deployment Guide

If you want to spin up this exact architecture yourself, follow these steps:

### 1. Provision the Azure Resources
1. Head to the **Azure Portal** and create a new **Web App** (App Service).
2. Choose **Code** publish, specify the **.NET 9 (STS)** runtime, and select the **Linux** operating system.
3. Create a new **API Management** instance natively positioned in front of the App Service using the **Consumption** pricing tier (for instant deployment).

### 2. Connect Your Azure DevOps Pipeline
1. Because Microsoft frequently restricts parallel jobs on free-tier Microsoft Hosted agents (resulting in the `No hosted parallelism` error), you can completely bypass this by hooking your personal computer up as an agent!
2. In Azure DevOps, go to **Project Settings -> Agent Pools -> Default** and download the Windows x64 self-hosted agent.
3. Run `config.cmd` using an Azure **Personal Access Token (PAT)** with *Full Access* scope.
4. Type `.\run.cmd` to spin up the agent in your local PowerShell terminal.

### 3. Deploy the Code
1. The repository root contains an `azure-pipelines.yml` file engineered specifically for this pipeline.
2. In Azure DevOps Pipelines, create a new pipeline reading from GitHub, select the existing YAML file, and change the `variables` at the top to perfectly match your App Service name and Azure Service Connection.
3. Because the YAML `pool` points to `Default`, Azure DevOps will stream the build files to your local laptop, compile the `.NET 9` SDK there, zip it, and push it forcefully out to your Linux Azure Web App in seconds.

### 4. Wire Up The API Gateway
To prevent handing out your backend `SuperSecretApiKey123` to the world, use the APIM instance you created in Step 1 to inject it invisibly:

1. In your APIM Dashboard, click **APIs -> + Add API -> OpenAPI** and paste your backend's live Swagger JSON URL (e.g. `https://your-app-name.azurewebsites.net/swagger/v1/swagger.json`).
2. Click the `</>` icon in the **Inbound processing** section of the Gateway.
3. Paste this exact policy snippet entirely under `<base />`:
```xml
<set-header name="X-Api-Key" exists-action="override">
    <value>SuperSecretApiKey123</value>
</set-header>
```
4. Save the policy. 

**Result:** The Gateway will instantly demand an OCP Subscription Key from public users, seamlessly inject the backend `X-Api-Key` password behind the scenes, securely fetch your SQLite data, and relay the response perfectly!

<img width="1345" height="398" alt="image" src="https://github.com/user-attachments/assets/b3b2fbbc-a1a6-44c8-b268-206b33c138ca" />


<img width="1327" height="665" alt="image" src="https://github.com/user-attachments/assets/7693ac5b-f309-417d-bd3e-f61e08795eb2" />



![Uploading imae.png…]()

<img width="1358" height="429" alt="image" src="https://github.com/user-attachments/assets/4ce22cc3-22ff-4e32-9188-7ed9d9b22e14" /> ## EmployeeCrud API Architecture


<img width="1352" height="601" alt="image" src="https://github.com/user-attachments/assets/d7378bc6-dca6-46e2-bc69-86a03af1879d" />

<img width="1343" height="631" alt="image" src="https://github.com/user-attachments/assets/e195cc42-3e33-4063-9a36-c90c9aa06281" />






