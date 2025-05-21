# DevContainer: C# 9 + MongoDB + Elasticsearch

This development container uses Docker Compose to provide a ready-to-use environment for C# 9 development with MongoDB and Elasticsearch.

## Features
- .NET 6 SDK (C# 9 compatible)
- MongoDB 6
- Elasticsearch 7.17
- VS Code extensions for C#, MongoDB, and Docker

## Usage
1. Open this folder in VS Code.
2. Reopen in Container when prompted.
3. The app service is available for development in `/workspace`.
4. MongoDB is accessible at `mongodb://mongodb:27017`.
5. Elasticsearch is accessible at `http://elasticsearch:9200`.

## Environment Variables
- `MONGODB_CONNECTION_STRING`: MongoDB connection string
- `ELASTICSEARCH_URL`: Elasticsearch connection string

## Ports
- 5000, 5001: App
- 27017: MongoDB
- 9200, 9300: Elasticsearch
