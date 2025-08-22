# .NET DuckDB Data Processing Demo

This project is a .NET console application that demonstrates how to use DuckDB to read, process, and query data from various file formats, including CSV and complex JSON.

## Features

- **In-Memory Database**: Utilizes DuckDB's fast in-memory database for processing.
- **Multiple File Formats**: Reads data directly from `.csv` and `.json` files.
- **JSON Flattening**: Demonstrates powerful SQL queries to flatten nested JSON objects and arrays into a tabular format.
- **DuckDB JSON Extension**: Shows how to install and use the `json` extension within a .NET application.

## Project Structure

- `Program.cs`: The main application entry point containing all the C# and DuckDB query logic.
- `DuckDbDemo.csproj`: The .NET project file, which includes the `DuckDB.NET.Data` dependency.
- `DBData/`: A directory containing the sample data files:
  - `data.csv`: A simple CSV file.
  - `data.json`: A simple JSON file.
  - `complex.json`: A more complex JSON file with nested objects and arrays.

## How to Run the Project

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later.

### Steps

1.  Open a terminal or command prompt.
2.  Navigate to the root directory of the project:
    ```sh
    cd /path/to/DuckDbDemo
    ```
3.  Run the application using the .NET CLI:
    ```sh
    dotnet run
    ```

The application will execute, connect to DuckDB, process the files in the `DBData` directory, and print the query results to the console.
