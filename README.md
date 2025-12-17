# RCPSystem

## Project Description
This C# project is a console application for processing CSV files containing employee time tracking records  
It supports data from two different companies, each with its own CSV format.

## Architecture and Approach
- The project uses a parser/factory pattern: each parser (`Company1Parser`, `Company2Parser`) handles its own CSV format.  
- Separation of parsers allows easy addition of new companies in the future without modifying existing code.  
- Parsers implement a common `IRcpParser` interface, and `RcpProcessor` manages selecting the right parser for each file.  
- This results in modular, maintainable, and easily testable code.

## CSV Handling
- **Company1Parser** – handles 5-column CSV: `EmployeeCode;Date;ArrivalTime;DepartureTime;WorkMinutes`  
- **Company2Parser** – handles 4-column CSV: `EmployeeCode;Date;Time;Type (WE/WY)`  
- The program combines entries and exits into a complete `WorkDay` only if both are present (WE and WY). Incomplete records are ignored.

## Validation and Safety
- Data is validated on reading: correct dates, times, and number of columns.  
- Focus is on optimal validation to avoid errors when CSV rows are incomplete or malformed.  
- Additional validations can be added easily in the parsers.

## Running the Program
The program accepts a folder path containing CSV files as a command-line argument:  
```bash
   dotnet run -- "path/to/csv/folder"
 ```

It will process all CSV files in the given folder.

Output is displayed in the console as:
  ```bash
Code   | Date       | Arrival | Departure
001    | 2025-12-17 | 08:00   | 16:00
  ```
## Tests

Unit tests are included using xUnit.

Tests are in a separate test project: RPCSystem.Tests.

##  Installation and Dependencies

The project uses .NET 8 and NuGet for package management.

### Packages used:

CsvHelper – convenient CSV parsing.

xUnit – unit testing framework.

## How to run:

  ```bash
dotnet restore
dotnet build
dotnet run -- "path/to/csv/folder"
```

##  Extensibility

Thanks to the parser factory, new CSV formats can be added easily by creating a parser that implements IRcpParser.

The project can handle any number of CSV files in the given folder.

Additional validation or data-merging logic can be added in parsers.

