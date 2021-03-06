# Debuggning av Azure Functions

<img src="images/function.png" alt="drawing" width="96" height="96"/>

## Förberedelser

Följ intruktionerna nedan för det operativsystem du använder.


<details><summary><strong>Windows</strong></summary>
<p>

1. Ladda ned .NET Core 3.1 SDK här [64-bitars-installationsfil](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-3.1.408-windows-x64-installer)
2. Installera Azure Functions Core Tools [64-bitars-installationsfil](https://go.microsoft.com/fwlink/?linkid=2135274)
3. Installera [VSCode](https://code.visualstudio.com/Download#) (Visual Studio Code)
4. Installera [Azurite Extension](https://marketplace.visualstudio.com/items?itemName=Azurite.azurite) till VSCode

Skapa en mapp i `C:\` eller liknande som heter `azurite`
Ändra location inställningen i Azurite Extension till att peka på din mapp.
Se nedan gif hur du gör det.

<img src="images/azurite.location.setting.gif" alt="drawing" width="500"/>

</p>
</details>

<details><summary><strong>macOS</strong></summary>
<p>

1. Ladda ned .NET Core 3.1 SDK här [installationsfil](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-3.1.408-macos-x64-installer)
2. Installera Azure Functions Core Tools [länk-till-dokumentation](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=macos%2Ccsharp%2Cbash#install-the-azure-functions-core-tools)
3. Installera [VSCode](https://code.visualstudio.com/Download#) (Visual Studio Code)
4. Installera [Azurite Extension](https://marketplace.visualstudio.com/items?itemName=Azurite.azurite) till VSCode

Skapa en mapp i `c/` eller liknande som heter `azurite`
Ändra location inställningen i Azurite Extension till att peka på din mapp.
Se nedan gif hur du gör det.

<img src="images/azurite.location.setting.gif" alt="drawing" width="500"/>

</p>
</details>

<details><summary><strong>Linux</strong></summary>
<p>

1. Följ denna [guide](https://docs.microsoft.com/sv-se/dotnet/core/install/linux) för att ladda ned .NET Core 3.1 SDK 
2. Installera Azure Functions Core Tools [länk-till-dokumentation](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=linux%2Ccsharp%2Cbash#install-the-azure-functions-core-tools)
3. Installera [VSCode](https://code.visualstudio.com/Download#) (Visual Studio Code)
4. Installera [Azurite Extension](https://marketplace.visualstudio.com/items?itemName=Azurite.azurite) till VSCode

Skapa en mapp i `c/` eller liknande som heter `azurite`
Ändra location inställningen i Azurite Extension till att peka på din mapp.
Se nedan gif hur du gör det.

<img src="images/azurite.location.setting.gif" alt="drawing" width="500"/>

</p>
</details>

## Skapa en funktionsapp

<details><summary><strong>Kommandon</strong></summary>
<p>

Se till att ha dotnet 3.0 eller senare installerat
```
$ dotnet --version
```

Kolla också att det gick bra att installera Azure Functions Core Tools
```
$ func --version
```

Skapa en mapp som till exempel heter `Functions`

Navigera till den mappen i din kommandotolk

Till exempel:
```
$ cd c:\Functions\
```

## Här börjar vi skapa funktionsappen 

`Func init` skapar en ny funktionsapp

Välj `dotnet` i listan

### Öppna i VSCode (Visual Studio Code)

*för att debuggern ska fungera kräver det att man öppnar upp mappen i VSCode där functionen ligger* 

`code .` öppnar upp mappen du befinner dig i, i VSCode *(missa inte punkten)*

<details><summary><strong>Kommandon bra att kunna</strong></summary>
<p>

`dotnet build` bygger ditt projekt

`dotnet restore` "synkar" dina nuget paket

`func host start` startar funktionsappen utan debugger
</p>
</details>

### Skapa en Funktion! 

`func new` skapar en ny funktionstrigger

Välj `HttpTrigger` i listan och namnge triggern vad du vill

Ändra `Route = null` i in-parametern till funktionen till `Route = "names"` (*rad 17 typ i din HttpTrigger class*)

Tryck `F5` på tangentbordet när du är i VSCode för att starta funtionsappen i debug-läge.

Öppna förslagsvis upp ett nytt fönster av din kommandotolk och gör en post request till din nyss skapade HttpTrigger!

#### Windows

```
$ curl.exe --request POST http://localhost:7071/api/names --data "{'name':'there!'}"
```

#### Linux och macOS

```
$ curl -X POST -H "Content-Type: application/json" \-d '{"name":"there!"}' \http://localhost:7071/api/names
```

Börja debugga!
</p>
</details>



## Presentation

<details><summary><strong>Slides</strong></summary>
<p>

<br>

<img src="images/Slide1.PNG" alt="drawing" width="640" height="360"/>

<img src="images/Slide2.PNG" alt="drawing" width="640" height="360"/>

<img src="images/Slide3.PNG" alt="drawing" width="640" height="360"/>

<img src="images/Slide4.PNG" alt="drawing" width="640" height="360"/>

<img src="images/Slide5.PNG" alt="drawing" width="640" height="360"/>

<img src="images/Slide6.PNG" alt="drawing" width="640" height="360"/>

<img src="images/Slide7.PNG" alt="drawing" width="640" height="360"/>

<img src="images/Slide8.PNG" alt="drawing" width="640" height="360"/>

<img src="images/Slide9.PNG" alt="drawing" width="640" height="360"/>

<img src="images/Slide10.PNG" alt="drawing" width="640" height="360"/>

<img src="images/Slide11.PNG" alt="drawing" width="640" height="360"/>

<img src="images/Slide12.PNG" alt="drawing" width="640" height="360"/>

<img src="images/Slide13.PNG" alt="drawing" width="640" height="360"/>

<img src="images/Slide14.PNG" alt="drawing" width="640" height="360"/>

</p>
</details>

## Fastnat?

Pinga i chatten eller ställ din fråga direkt i mötet.

