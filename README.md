# Smart Calculator and Unit Converter

A C# console application that provides basic arithmetic operations and common unit conversions. The application also supports converting Ghanaian Cedis (GHS) to United States Dollars (USD) using an exchange rate supplied by the user.

## Features

### Calculator
- Addition
- Subtraction
- Multiplication
- Division
- Division-by-zero handling
- Overflow handling

### Unit Converter
- Kilometres to miles
- Miles to kilometres
- Celsius to Fahrenheit
- Fahrenheit to Celsius
- Ghanaian Cedis (GHS) to US Dollars (USD)

### Input Validation and Reliability
- Validates numerical input.
- Rejects invalid menu selections.
- Prevents invalid or non-positive exchange rates.
- Handles division by zero without terminating the application.
- Handles calculation and conversion overflow with friendly error messages.
- Handles end-of-input gracefully instead of entering an infinite input loop.
- Allows users to return to previous menus or exit the application.

### Result Formatting
- General calculation and unit conversion results display up to four decimal places.
- Currency conversion results display two decimal places.
- Distance conversions use a shared conversion factor for consistency.

## Technologies Used

- C#
- .NET 9
- xUnit
- Git and GitHub

## Prerequisites

Before running the application, ensure you have:

- .NET 9 SDK installed.
- Git installed.
- A terminal or code editor such as Visual Studio Code.

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/jacobOpintan/CalculatorApp.git
```

### 2. Navigate into the project directory

```bash
cd CalculatorApp
```

### 3. Build the application

```bash
dotnet build
```

### 4. Run the application

```bash
dotnet run --project src/CalculatorApp
```

## Running the Tests

The project uses xUnit for automated testing.

To execute the test suite, run:

```bash
dotnet test
```

The test suite currently contains **31 automated tests**, covering:

- Arithmetic operations and edge cases.
- Division by zero.
- Decimal calculations and overflow.
- Unit and currency conversions.
- Exchange-rate validation.
- Invalid and out-of-range input.
- End-of-input handling.
- Menu navigation and application flow.
- Numeric result formatting.
- Distance conversion consistency.

## Project Structure

```text
CalculatorApp/
├── src/
│   └── CalculatorApp/
│       ├── Application/
│       │   └── CalculatorApplication.cs
│       ├── Services/
│       │   ├── CalculatorService.cs
│       │   └── ConversionService.cs
│       ├── Utilities/
│       │   └── InputHelper.cs
│       └── Program.cs
│
├── tests/
│   └── CalculatorApp.Tests/
│       ├── CalculatorServiceTests.cs
│       ├── ConversionServiceTests.cs
│       ├── InputHelperTests.cs
│       └── CalculatorApplicationTests.cs
│
├── CalculatorApp.sln
└── README.md
```

## Architecture and Design Decisions

The application separates its responsibilities into different components:

- **Program.cs:** Entry point of the application. It supplies the console input and output streams to the application.
- **CalculatorApplication.cs:** Coordinates the application flow, displays menus, receives user choices, and invokes the appropriate services.
- **CalculatorService.cs:** Contains the business logic for arithmetic operations.
- **ConversionService.cs:** Contains the logic for unit and currency conversions.
- **InputHelper.cs:** Provides reusable methods for validating and reading user input.
- **CalculatorApp.Tests:** Contains automated tests for arithmetic operations, conversions, input validation, and application interaction.

The application uses `TextReader` and `TextWriter` abstractions to separate console interaction from application logic. This makes it possible to simulate user input and capture application output during automated testing.

This separation makes the application easier to understand, test, maintain, and extend.

## Currency Conversion Assumption

The application does not retrieve exchange rates from an external API.

Instead, the user supplies the exchange rate, defined as the amount of Ghanaian Cedis equivalent to one US Dollar.

For example:

- Exchange rate: 1 USD = 12.50 GHS
- Amount: 125 GHS
- Result: 10.00 USD

The calculation is:

```text
USD = GHS Amount / Exchange Rate
```

The exchange rate must be greater than zero.

## Assumptions and Limitations

- The application is a console-based application.
- Currency exchange rates are entered manually by the user.
- No live exchange-rate API is integrated.
- The application does not store calculation or conversion history.
- Numerical input uses a dot (`.`) as the decimal separator.
- Currency conversion results are displayed to two decimal places.
- General calculation and unit conversion results are displayed to a maximum of four decimal places.
- Arithmetic operations use the `decimal` data type, which has a finite range. Values outside that range are handled through overflow exceptions.

## Future Improvements

Possible improvements include:

- Integrating a live currency exchange-rate API.
- Adding support for more currencies and measurement units.
- Introducing a graphical user interface.
- Saving calculation and conversion history.

