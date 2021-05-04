# Debuggning av Azure Functions

<img src="image/function.png" alt="drawing" width="96" height="96"/>

### Förberedelser

Följ intruktionerna nedan för det operativsystem du använder.


<details><summary><strong>Windows</strong></summary>
<p>

1. Ladda ned .NET Core 3.1 SDK här [64-bitars-installationsfil](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-3.1.408-windows-x64-installer)
2. Installera VS Code (Visual Studio Code) [länk](https://code.visualstudio.com/Download#)
3. Installera Azure Functions Core Tools [64-bitars-installationsfil](https://go.microsoft.com/fwlink/?linkid=2135274)

</p>
</details>

<details><summary><strong>macOS</strong></summary>
<p>

1. Ladda ned .NET Core 3.1 SDK här [installationsfil](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-3.1.408-macos-x64-installer)
2. Installera VS Code (Visual Studio Code) [länk](https://code.visualstudio.com/Download#)
3. Installera Azure Functions Core Tools [länk-till-dokumentation](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=macos%2Ccsharp%2Cbash#install-the-azure-functions-core-tools)

</p>
</details>

<details><summary><strong>Linux</strong></summary>
<p>

1. Följ denna [guide](https://docs.microsoft.com/sv-se/dotnet/core/install/linux) för att ladda ned .NET Core 3.1 SDK 
2. Installera VS Code (Visual Studio Code) [länk](https://code.visualstudio.com/Download#)
3. Installera Azure Functions Core Tools [länk-till-dokumentation](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=linux%2Ccsharp%2Cbash#install-the-azure-functions-core-tools)

</p>
</details>

### Kommandon:

Se till att ha dotnet 3.0 eller över installerat
```
dotnet --version
```

Kolla också att det gick bra att installera Azure Functions Core Tools
```
func --version
```

```
cd .\Functions\
```

```
func init --docker
```

```
code .
```

```
func new
```

Välj `HttpTrigger` i listan och namnge triggern vad du vill


Ändra `Route=null` i in-parametern till funktionen till `names`

Tryck `F1` på tangentbordet i VSCode och copy-paste:a in `Debug: Start Debugging`
    *hint:* nästa gång kommer `F5` vara mappat till debuggern som man kan trycka på då

Om man vill köra funktionen utan degugern på, testa köra:
```
func host start
```

Öppna föslagsvis upp ett nytt kommandofönster och gör en post request till din precis skapta HttpTrigger!

##### Till exempel 

```
curl.exe --request POST http://localhost:7071/api/names --data "{'name':'Azure Rocks'}"
```

### Fastnat?

Pinga i chatten eller ställ din fråga direkt i mötet.

