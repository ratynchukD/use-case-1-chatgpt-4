# Country Information API

The Country Information API provides comprehensive details about different countries across the world. By querying the /Countries endpoint, users can retrieve a myriad of information about a country, such as its name (both official and common), its population, region, and various other attributes. You can filter results based on specific criteria like partial country name, population threshold, sorting direction, and limit the number of returned countries.

Each country's object encapsulates intricate details, from general data such as top-level domains and area size to cultural aspects like official languages and demonyms. Moreover, the API caters to those looking for multimedia components, offering URLs to a country's flags and coat of arms in various formats. Additionally, users can access maps and details about the country's capital, time zones, currencies, and even driving-side conventions. This makes the API a holistic solution for those seeking extensive country-related data.

## How to Run Locally

### 1. **Prerequisites:**

1.1. Install **.NET 6 SDK**. You can download the necessary SDK from [the official .NET website]([Download .NET 6.0 (Linux, macOS, and Windows) (microsoft.com)](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)).

1.2. (Optional) Install an IDE. While not strictly required (you can use any text editor and the command line), tools like Visual Studio, Visual Studio Code, or JetBrains Rider provide integrated development environments (IDEs) which simplify the development process.

### 2. **Clone or Download the Repository (if using version control):**

2.1. If the project is stored in a version control system like Git, you can clone the repository:

```
git clone https://github.com/ratynchukD/use-case-1-chatgpt-4.git
```

2.2. Navigate to the project's directory:

```
cd [YOUR_PROJECT_DIRECTORY]
```

### 3. **Restore Dependencies:**

3.1. Once inside the project directory, run the following command to restore any NuGet packages or dependencies the project relies on:

```
dotnet restore use-case-1-chatgpt-4\use-case-1-chatgpt-4.csproj
```

### 4. **Build the Application:**

4.1. Compile the application to check for any build errors:

```
dotnet build use-case-1-chatgpt-4\use-case-1-chatgpt-4.csproj
```

### 5. **Run the Application:**

5.1. For a standard .NET application, run:

```
dotnet run --project use-case-1-chatgpt-4\use-case-1-chatgpt-4.csproj
```

5.2. The above command will start a local web server, and you'll typically see an output indicating the local URL you can use to access the app, e.g., `https://localhost:5001`.

### 6. **Navigate to the Application (for web projects):**

6.1. Open your preferred web browser and go to the provided local URL (e.g., `https://localhost:5001`). You should see the Swagger UI page.

### 7. **Stop the Application:**

7.1. If you want to stop the application from running, go back to the terminal and press `Ctrl + C`.

## How to Use the API

Below you can see the API use cases examples with the curl utility.

1. **Get all countries without any filter or sort**:

```
curl -X GET "https://[API-URL]/Countries"
```

2. **Get countries with a name containing 'can'**:

```

curl -X GET "https://[API-URL]/Countries?name=can"
```

3. **Get countries with a population under 10 million**:

```
curl -X GET "https://[API-URL]/Countries?population=10"
```

4. **Get countries with a name containing 'ger' and population under 100 million**:

```

curl -X GET "https://[API-URL]/Countries?name=ger&population=100"
```

5. **Get the first 5 countries sorted by their common name in ascending order**:

```

curl -X GET "https://[API-URL]/Countries?sortDirection=ascend&takeFirst=5"
```

6. **Get the first 3 countries sorted by their common name in descending order**:

```

curl -X GET "https://[API-URL]/Countries?sortDirection=descend&takeFirst=3"
```

7. **Get countries with a name containing 'rus', sorted by their common name in ascending order**:

```

curl -X GET "https://[API-URL]/Countries?name=rus&sortDirection=ascend"
```

8. **Get countries with a population under 50 million, sorted by their common name in descending order and only retrieve the first 10**:

```

curl -X GET "https://[API-URL]/Countries?population=50&sortDirection=descend&takeFirst=10"
```

9. **Get the first 20 countries without any other filter**:

```

curl -X GET "https://[API-URL]/Countries?takeFirst=20"
```

10. **Get countries with a name containing 'fran' and only retrieve the first 2**:

```

curl -X GET "https://[API-URL]/Countries?name=fran&takeFirst=2"
```

Make sure to replace `[API-URL]` with the actual base URL or IP address of the API. Also, ensure that the parameters' values provided in these examples are applicable to your actual data and use case.