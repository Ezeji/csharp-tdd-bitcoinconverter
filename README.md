# C# TDD Bitcoin Converter

## Background
The following repo contains source code developed using TDD (Test Driven Development) practices. The sample project implements a .Net Core 3.1 C# library which interacts with the [Bitcoin Price Index](https://www.coindesk.com/coindesk-api) api.

## Notes

This branch (step7) updates the GitHub Action workflow to automatically produce a release for the built DLL artifact on tag events only:

```
name: bitcoinconverter.build

on: push

jobs:
  build:

    runs-on: ubuntu-latest

    steps:
    - uses: actions/checkout@v2

    - name: Setup .NET Core
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: 3.1.402

    - name: Install Dependencies
      run: dotnet restore

    - name: Build
      run: dotnet build --configuration Release --no-restore

    - name: Test
      run: dotnet test --no-restore --verbosity normal

    - name: Upload Artifact
      uses: actions/upload-artifact@v1.0.0
      with:
        name: BitcoinConverter.Code.dll
        path: BitcoinConverter.Code/bin/Release/netcoreapp3.1/BitcoinConverter.Code.dll

    - name: Make Release
      uses: softprops/action-gh-release@v0.1.5
      if: startsWith(github.ref, 'refs/tags/')
      with:
        files:
          BitcoinConverter.Code/bin/Release/netcoreapp3.1/BitcoinConverter.Code.dll
      env:
        GITHUB_TOKEN: ${{ secrets.GITHUB_TOKEN }}
```

Commands to compile and test the Dotnet Solution

```
dotnet build
```

```
dotnet test
```

```
DOTNET_USE_POLLING_FILE_WATCHER=1 dotnet watch -p BitcoinConverter.sln test
```