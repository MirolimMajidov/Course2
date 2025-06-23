using MyFirstApp.Models;

var collector = new ProviderCollector();


using (var provider = new DatabaseProvider(collector))
{
    var tablesCount = provider.GetTablesCount();
    Console.WriteLine(tablesCount);
}

Console.WriteLine("Press any key to exit...");;
