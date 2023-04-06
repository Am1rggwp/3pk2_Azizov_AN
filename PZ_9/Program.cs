using PZ_9;

Origin origin = new Origin();
origin.OriginDouble(1.23);
origin.OriginInt(42);
origin.OriginChar('X');

Console.WriteLine();

Client client = new Client();
client.ClientDouble(1.23);
client.ClientInt(42);
client.ClientChar('X');