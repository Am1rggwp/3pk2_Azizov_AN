namespace PZ_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store(){AllPurshares = ""};
            Client amir = new Client(){AllPurchases = 12000,Name = "Amir"};
            Client Sergey = new Client(){AllPurchases = 3600, Name = "Sergey"};
            Client Marina = new Client(){AllPurchases = 90000, Name = "Marina"};

            CPU cpu = new CPU() 
            {
                Name ="Ryzen 3 1200", 
                Core = 4, 
                Frequency = 3.14,
                Price = 3756
            };
            Graphics_card graphics_Card = new Graphics_card()
            {
                Name = "GTX 1650 Super",
                RAM = 4,
                DDR = 5,
                Price = 20432
            };
            Motherboard motherboard = new Motherboard()
            {
                Name = "Gigabyte a320m-s2h v2",
                Size = "normal",
                Socket = "AM4",
                Price = 3300
            };

            store.SaveOrder(amir, new Product[1] {graphics_Card});
            store.SaveOrder(Sergey, new Product[2] {cpu, motherboard});
            store.SaveOrder(Marina, new Product[5] {cpu, motherboard, graphics_Card, graphics_Card, cpu });

            Console.WriteLine(store.AllPurshares);
            



        }
    }
}
