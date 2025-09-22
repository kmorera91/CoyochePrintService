# PdfPrintService

## Overview
PdfPrintService is a Windows service designed to receive PDF documents via HTTP and print them using the default printer of the host machine. This service is built using .NET SDK 9 and follows a modular architecture, separating concerns into services and controllers.

## Project Structure
The project is organized as follows:

```
PdfPrintService
├── src
│   ├── PdfPrintService.csproj        # Project file for the .NET SDK application
│   ├── Program.cs                     # Entry point of the Windows service
│   ├── Services
│   │   └── PrintService.cs           # Service for handling PDF printing
│   ├── Controllers
│   │   └── PrintController.cs         # Controller for handling HTTP requests
│   └── README.md                      # Documentation for the PdfPrintService project
├── tests
│   └── PdfPrintService.Tests.csproj   # Project file for unit tests
├── .gitignore                         # Files and directories to ignore by Git
└── README.md                          # General documentation for the project
```

## Setup Instructions
1. Clone the repository to your local machine.
2. Navigate to the `src` directory.
3. Restore the project dependencies using the command:
   ```
   dotnet restore
   ```
4. Build the project using:
   ```
   dotnet build
   ```
5. To run the service, use:
   ```
   dotnet run
   ```

## Usage
- The service listens for HTTP POST requests at the specified endpoint (to be defined in the `PrintController`).
- Send a PDF document in the body of the request to print it using the default printer.

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.