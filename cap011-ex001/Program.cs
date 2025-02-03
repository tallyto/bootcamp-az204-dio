using StackExchange.Redis;

string connectionString = "";

using (var chace = ConnectionMultiplexer.Connect(connectionString))
{
    var db = chace.GetDatabase();
    var result = await db.ExecuteAsync("PING");
    Console.WriteLine(result);

    bool setValue = await db.StringSetAsync("name", "Dio Tallyto");
    Console.WriteLine(setValue);

    string? getValue = await db.StringGetAsync("name");

    Console.WriteLine(getValue);
}