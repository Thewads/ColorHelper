# ColorHelper [![build, test and deploy](https://github.com/Thewads/ColorHelper/actions/workflows/main.yml/badge.svg)](https://github.com/Thewads/ColorHelper/actions/workflows/main.yml)

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
4. Build solution
```sh
   dotnet build --configuration Release --no-restore
   ```
5. Run the application
```sh
   dotnet run --configuration release --no-build --project ColorHelperUi/ColorHelperUi.csproj
   ```
6. Run [website in browser](https://localhost:7155)

## Roadmap

- [x] Add Basic Searching of Citadel paints
- [ ] Support for other paint brands
    - [x] Vallejo Color
    - [x] Vallejo Model
    - [ ] Army Painter
    - [ ] Scale 75
    - [ ] Pro Acryl
- [ ] Filtering out of specific types of paint
    - [ ] Paint brands
    - [ ] Metallics
