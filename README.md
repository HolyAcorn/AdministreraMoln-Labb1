# AdministreraMoln-Labb1

This is a tool for keeping track of Projects and Competencies that can be displayed on a CV website. Contains full CRUD.

## Schema

### Competencies

```bash
{
id	integer($int32) (Uses identity)
name	string
nullable: true
yearsOfExperience	integer($int32)
competencyLevel	string
nullable: true
}

```

### Project

```bash
{
id	integer($int32) (Uses Identity)
name	string
nullable: true
type	string
nullable: true
description	string
nullable: true
url	string
nullable: true
startYear	integer($int32)
endYear	integer($int32)
completed	boolean
}
```

## Getting Started

### 1. Clone Repo

```bash
git clone https://github.com/HolyAcorn/AdministreraMoln-Labb1
cd CvWebApi
```

### 2. Build & Run with Docker Compose

```bash
docker-compose up --build
```


## Frameworks used

- Entity Framework Core
- ASP .Net
- Swagger
