<!-- TOC -->

- [Demo Setup](#demo-setup)
    - [Database](#database)
        - [Export Wizard](#export-wizard)
        - [ConnectionString](#connectionstring)
    - [Deploy REST Service](#deploy-rest-service)
- [Data Access - direct <> service](#data-access---direct--service)
    - [direct access local or azure db](#direct-access-local-or-azure-db)
    - [service access azure db](#service-access-azure-db)
    - [reduce payload.](#reduce-payload)
    - [try different serializer/compression settings](#try-different-serializercompression-settings)
- [Streaming](#streaming)

<!-- /TOC -->

# Demo Setup

## Database

* Download a copy of the AdventureWorks DW Sample Database [here](https://www.microsoft.com/en-us/download/details.aspx?id=49502)
* Import the Database to your local SQL Server.
* Delete the **FactResellerSalesXL_CCI** and **FactResellerSalesXL_PageCompressed** table. Those Tables use features that are not supported on SQL Azure.
* Export the Database to SQL Azure

### Export Wizard

![Start Deploy to SQL Azure Wizard](Assets/ManagementStudioDeploy.jpg)

Deploy your local database to SQL Azure.

### ConnectionString
Update the connectionStrings in the [LargeData.UI\App.config](LargeData.UI/App.config) and the [LargeData.Web\appsettings.json](LargeData.Web/appsettings.json).

[LargeData.UI\App.config](LargeData.UI/App.config)
```xml
<connectionStrings>
    <add name="AdventureWorksContext" connectionString="data source={localserver};initial catalog={localdb};integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
    <add name="AzureAdventureWorksContext" connectionString="Data Source={remoteserver};Initial Catalog={remotedb};Persist Security Info=False;User ID={remoteuser};Password={remotepassword};Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;" providerName="System.Data.SqlClient" />
</connectionStrings>
```
 [LargeData.Web\appsettings.json](LargeData.Web/appsettings.json)
```json
{
    "ConnectionStrings": {
        "AzureAdventureWorksContext": "Data Source={remoteserver};Initial Catalog={remotedb};Persist Security Info=False;User ID={remoteuser};Password={remotepassword};Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;"
    }
}
```
> replace `{localserver}`, `{localdb}` with your local SQL Server instance and database name

> replace `{remoteserver}`,`{remotedb}`, `{remoteuser}` and `{remotepassword}` with your SQL Server address and credentials

## Deploy REST Service
Publish the LargeData.Web project as an Azure Web app.

Update the webservice url in the [LargeData.UI/App.xaml.cs](LargeData.UI/App.xaml.cs) file.
```csharp
protected virtual void OnConfigure(IServiceCollection service)
{
    var serviceUrl = "http://yourwebapp.azurewebsites.net";
    ...
}
```
# Data Access - direct <> service
## direct access local or azure db
[LargeData.UI/App.xaml.cs](LargeData.UI/App.xaml.cs)
```csharp
protected virtual void OnConfigure(IServiceCollection service)
{
    var serviceUrl = "http://yourwebapp.azurewebsites.net";

    service.AddScoped<AdventureWorksContext>();

    // Direct access
    // Local Database
    service.AddScoped<AdventureWorksContext>(p => new AdventureWorksContext("name=AdventureWorksContext"));
    // Azure Database
    //service.AddScoped<AdventureWorksContext>(o => new AdventureWorksContext("name=AzureAdventureWorksContext"));
    service.AddScoped<IInternetSalesService, InternetSalesService>();

    // REST Service access
    // ...

    service.AddTransient<LargeDataViewModel>();
}
```
Start the LargeData.UI app with local and the azure db configuration and compare the request times.

Switch to service communication.

## service access azure db
[LargeData.UI/App.xaml.cs](LargeData.UI/App.xaml.cs)
```csharp
protected virtual void OnConfigure(IServiceCollection service)
{
    var serviceUrl = "http://yourwebapp.azurewebsites.net";

    //service.AddScoped<AdventureWorksContext>();

    // Direct access
    // Local Database
    //service.AddScoped<AdventureWorksContext>(p => new AdventureWorksContext("name=AdventureWorksContext"));
    // Azure Database
    //service.AddScoped<AdventureWorksContext>(o => new AdventureWorksContext("name=AzureAdventureWorksContext"));
    //service.AddScoped<IInternetSalesService, InternetSalesService>();

    // REST Service access
    // XML serializer
    service.AddScoped<IInternetSalesService>(p => new RemoteInternetSalesService(serviceUrl, SerializationStrategy.Xml, false));

    // JSON serializer
    //service.AddScoped<IInternetSalesService>(p => new RemoteInternetSalesService(serviceUrl, SerializationStrategy.Json, false));

    // ProtoBuf serializer
    //service.AddScoped<IInternetSalesService>(p => new RemoteInternetSalesService(serviceUrl, SerializationStrategy.ProtoBuf, false));

    // ProtopBuf + content compression
    //service.AddScoped<IInternetSalesService>(p => new RemoteInternetSalesService(serviceUrl, SerializationStrategy.ProtoBuf, true));
    service.AddTransient<LargeDataViewModel>();
}
```

## reduce payload.
Step 2

[LargeData.UI/ViewModel/LargeDataViewModel.cs](LargeData.UI/ViewModel/LargeDataViewModel.cs)
```csharp
protected async Task LoadDataAsync()
{
    using (StartJob("loading..."))
    {
        // Step 1 - eager loaded entity objects
        //var items = await Service.GetInternetSalesAsync(this.From, this.Until);
        //this.Items = new ObservableCollection<InternetSale>(items);

        // Step 2 - mapped object from service
        var items = await Service.GetInternetSaleInfosAsync(this.From, this.Until);
        this.Items = new ObservableCollection<InternetSaleInfo>(items);

        // Step 3 - Streamed requests
        //this.Items = new ObservableCollection<InternetSaleInfo>();
        //var stream = await Service.GetInternetSaleInfoStreamAsync(this.From, this.Until);
        //var dr = new DataStreamReader<InternetSaleInfo>(stream);
        //var processor = new ChunkLoad<InternetSaleInfo>(this.Items, 1000);
        //await dr.ReadDataAsync(processor);
        //processor.Complete();
    }
}
```

[LargeData.UI/View/LargeDataView.xaml](LargeData.UI/View/LargeDataView.xaml)
```xml
<!--Step 1-->
<!--<DataGrid Grid.Row="1" AutoGenerateColumns="False" ItemsSource="{Binding Path=Items}" Name="grid">
    ...
</DataGrid>-->

<!--Step 2 + 3-->
<DataGrid Grid.Row="1" AutoGenerateColumns="False" ItemsSource="{Binding Path=Items}" Name="grid">
    ...
</DataGrid>
```

## try different serializer/compression settings

[LargeData.UI/App.xaml.cs](LargeData.UI/App.xaml.cs)
```csharp
protected virtual void OnConfigure(IServiceCollection service)
{
    var serviceUrl = "http://yourwebapp.azurewebsites.net";

    //service.AddScoped<AdventureWorksContext>();

    // Direct access
    // ...
    
    // REST Service access
    // XML serializer
    //service.AddScoped<IInternetSalesService>(p => new RemoteInternetSalesService//(serviceUrl, SerializationStrategy.Xml, false));

    // JSON serializer
    //service.AddScoped<IInternetSalesService>(p => new RemoteInternetSalesService(serviceUrl, SerializationStrategy.Json, false));

    // ProtoBuf serializer
    service.AddScoped<IInternetSalesService>(p => new RemoteInternetSalesService(serviceUrl, SerializationStrategy.ProtoBuf, false));

    // ProtopBuf + content compression
    //service.AddScoped<IInternetSalesService>(p => new RemoteInternetSalesService(serviceUrl, SerializationStrategy.ProtoBuf, true));
    service.AddTransient<LargeDataViewModel>();
}
```
Depending on your latency and bandwidth you should see a huge difference compared to the direct SQL access.

# Streaming
Step 3

[LargeData.UI/ViewModel/LargeDataViewModel.cs](LargeData.UI/ViewModel/LargeDataViewModel.cs)
```csharp
protected async Task LoadDataAsync()
{
    using (StartJob("loading..."))
    {
        // Step 1 - eager loaded entity objects
        //var items = await Service.GetInternetSalesAsync(this.From, this.Until);
        //this.Items = new ObservableCollection<InternetSale>(items);

        // Step 2 - mapped object from service
        //var items = await Service.GetInternetSaleInfosAsync(this.From, this.Until);
        //this.Items = new ObservableCollection<InternetSaleInfo>(items);

        // Step 3 - Streamed requests
        this.Items = new ObservableCollection<InternetSaleInfo>();
        var stream = await Service.GetInternetSaleInfoStreamAsync(this.From, this.Until);
        var dr = new DataStreamReader<InternetSaleInfo>(stream);
        var processor = new ChunkLoad<InternetSaleInfo>(this.Items, 1000);
        await dr.ReadDataAsync(processor);
        processor.Complete();
    }
}
```