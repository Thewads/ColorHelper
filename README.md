# ColorHelper [![build and test](https://github.com/Thewads/ColorHelper/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/Thewads/ColorHelper/actions/workflows/build-and-test.yml)

<!-- ABOUT THE PROJECT -->
## About The Project

The project was designed to help out miniature model painters to find paints which will help them in their designs.
The first iteration is to allow the user to find paints which closely match the given paint.

### Built With
* [Blazor WASM](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)
* [MudBlazor](https://mudblazor.com/)

<!-- GETTING STARTED -->
## Getting Started

To get the project up and running locally, follow the steps below

### Prerequisites

* [NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

### Installation
1. Clone the repo
2. Open command line to the ColorHelper folder
3. Restore packages
```sh
   dotnet restore
   ```
3. Build solution
```sh
   dotnet build --configuration Release --no-restore
   ```
4. Run the application
```sh
   dotnet run --configuration release --no-build --project ColorHelperUi/ColorHelperUi.csproj
   ```
5. Run [website in browser](https://localhost:7155)

## Roadmap

- [x] Add Basic Searching of Citadel paints
- [ ] Support for other paint brands
- [ ] Filtering out of specific types of paint
    - [ ] Paint brands
    - [ ] Metallics
