# MiniEshop 🛒

Microservices-based e-commerce demo built with .NET 8 and Docker.

## 📁 Project Structure
```
MiniEshop/
├── src/
│   ├── Storefront/          # Customer-facing web service
│   ├── Admin/               # Administrative backend service
│   └── AIService/           # AI-powered development assistant
├── docker-compose.yml
└── docker-compose.override.yml
```

## 🧩 Services

| Service | Port | Description |
|---------|------|-------------|
| **Storefront** | 8080 | Customer-facing e-commerce frontend |
| **Admin** | 8081 | Administrative dashboard and backend |
| **AIService** | 8090 | AI service for code generation and error analysis |
| **Ollama** | 11434 | Local AI model runtime (llama3) |

## 🚀 Getting Started

### Prerequisites
- Docker Desktop installed and running
- 8GB+ RAM available for Docker
- Git

### Setup After Cloning
```bash
# Clone the repository
git clone https://github.com/nwczarn/mini-eshop.git
cd mini-eshop

# Build and start all services
docker-compose up --build
```

### Essential Docker Commands

```bash
# Build and start services (most common during development)
docker-compose up --build

# Build without using cache (when you need a clean build)
docker-compose build --no-cache

# Stop and remove all containers
docker-compose down

# Run in background (detached mode)
docker-compose up --build -d

# Stop and remove containers + volumes
docker-compose down -v
```

## 🌐 Access Services
- **Storefront**: http://localhost:8080
- **Admin**: http://localhost:8081 | Health: http://localhost:8081/admin/health
- **AIService**: http://localhost:8090 | Health: http://localhost:8090/health
- **Swagger UIs**: Available at `/swagger` for each service

## 🛠️ Development Workflow

```bash
# View logs from all services
docker-compose logs -f

# View logs from specific service
docker-compose logs -f storefront

# Restart a specific service
docker-compose restart admin

# Rebuild and restart a specific service
docker-compose up --build -d storefront

# Check running containers status
docker-compose ps
```

## 🤖 AI Service Features
- **Generate Endpoint**: Create API endpoints from specifications
- **Analyze Error**: Get AI-powered error analysis and solutions
- Powered by Ollama with llama3 model (auto-downloaded on first run)

## 💡 Tech Stack
- .NET 8
- Docker & Docker Compose
- Ollama AI (llama3)
- Swagger/OpenAPI

## 📝 Testing
Use the `.http` files in each service folder to test endpoints in Visual Studio.

---

**Note**: First startup may take several minutes while Ollama downloads the llama3 model (~4GB).
