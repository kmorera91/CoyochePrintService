# PdfPrintService

## Overview
PdfPrintService is a Windows service built using .NET SDK 9 that allows users to print PDF documents received via HTTP requests. The service utilizes the default printer of the host machine to handle print jobs.

## Setup Instructions

1. **Prerequisites**
   - .NET SDK 9 installed on your machine.
   - A default printer configured on the host machine.

2. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd PdfPrintService
   ```

3. **Build the Project**
   Navigate to the `src` directory and run the following command to build the project:
   ```bash
   dotnet build
   ```

4. **Publish the Project**
   Run the following command to publish the project:
   ```bash
   dotnet publish -c Release -o ./publish
   ```
This will create a `publish` directory inside `src` with all necessary files.

2. **Configure the Service Port**
- Edit the `appsettings.json` file in the `publish` directory to set the desired URL and port:
  ```json
  {
    "Kestrel": {
      "Endpoints": {
        "Http": {
          "Url": "http://0.0.0.0:5000"
        }
      }
    }
  }
  ```
- Change the port as needed (e.g., `"http://0.0.0.0:8080"`).

3. **Install the Service**
- Open a Command Prompt as Administrator.
- Run the following command, replacing `<full-path-to-publish-folder>` with the absolute path to your `publish` directory:
  ```cmd
  sc create PdfPrintService binPath= "<full-path-to-publish-folder>\PdfPrintService.exe"
  ```

4. **Start the Service**
   - In the Command Prompt, run the following command to start the service:
     ```cmd
     sc start PdfPrintService
     ```

## Usage

### HTTP Endpoint
The service exposes an HTTP endpoint to accept PDF documents for printing. You can send a POST request to the endpoint with the PDF document in the body.

**Example using curl:**
```bash
curl -X POST http://localhost:5000/api/print/print -H "Content-Type: application/pdf" --data-binary @path/to/document.pdf
```

**Note:** Change the port in the URL if you modified it in `appsettings.json`.

## Logging

- Any unhandled errors are logged to `Program.log` in the application directory.
- Print errors are logged to `PrintService.log` in the application directory.

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.