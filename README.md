# AMP Take-Home Challenge

## Overview
This is a fullstack project that implements a background worker system with:
- .NET 7 backend (API)
- React frontend dashboard

## Backend (C# .NET)
- Located in `/BackgroundJobCodingChallenge`
- Exposes API endpoints to trigger workers
- Swagger documentation at `http://localhost:5000/swagger`
- Mock services simulate database and queueing

## Frontend (React.js)
- Located in `/background-workerdashboard`
- Displays worker statuses
- Allows manual triggering (if expanded)

## Instructions
- Backend: 
  - `cd BackgroundJobCodingChallenge`
  - `dotnet build`
  - `dotnet run`
- Frontend:
  - `cd background-workerdashboard`
  - `npm install`
  - `npm start`
  
---

Developed by Bhumik Patel
