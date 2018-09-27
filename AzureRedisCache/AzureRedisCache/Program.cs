using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureRedisCache
{
    class Program
    {
        /*            
         * Comments:
         * 
         * For run this code without errors, you should to create an Azure Redis Cache Service in Microsoft Azure, and get your
         * own ConnectionString and passwords for the server .
         * Once you have your Azure Redis Cache service, now you need to set the property "SSL Port " no enabled if you don't do
         * this action, you can't run the code correctly.
         * Don't forget to add the reference StackExchange.Redis from Nuget Package also.
         * More references: 
         * 
         * API:
         * https://github.com/StackExchange/StackExchange.Redis/blob/master/StackExchange.Redis/StackExchange/Redis/IDatabase.cs
         * 
         * One tool that you can use for monitoring your redis data base is: Redis Desktop Manager from:
         * http://redisdesktop.com/
         */

        static void Main(string[] args)
        {
            try
            {
                string Value = "", Key = "";
                int Operation = 0;              

                RedisCache ServerAzureRedisCache = new RedisCache();

                do
                {
                    Console.Clear();

                    Console.WriteLine("* * * [ Azure Redis Cache Operations ] * * *");
                    Console.WriteLine();

                    Console.WriteLine(" 1) Save data.");
                    Console.WriteLine(" 2) Search data.");
                    Console.WriteLine(" 3) Update data.");
                    Console.WriteLine(" 4) Delete data.");
                    Console.WriteLine(" 5) List all data");
                    Console.WriteLine(" 0) Exit.");

                    Console.WriteLine();

                    Console.Write("Choose operation: ");
                    Operation = int.Parse(Console.ReadLine().Trim());
                    Console.WriteLine();

                    switch (Operation)
                    {
                        case 1:

                            /*
                             Code for save data in the Azure Redis Cache DataBase
                            */

                            Console.Write("Write one key to the data: ");
                            Key = Console.ReadLine().Trim();

                            Console.Write("Write one value to save: ");
                            Value = Console.ReadLine().Trim();

                            if(ServerAzureRedisCache.SaveData(Key, Value)==true)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Data saved successfully! [ Now press Enter ]");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Unsaved data [ Now press Enter ]");
                                Console.ReadLine();
                            }

                            break;

                        case 2:

                            /*
                              Code for search data in the Azure Redis Cache DataBase
                            */

                            Console.Write("Write the Key to search: ");
                            Key = Console.ReadLine().Trim();

                            string  ValueFound = ServerAzureRedisCache.SearchData(Key);

                            if (ValueFound!=null)
                                Console.WriteLine("The data is: " + ValueFound + " [ Now press Enter ]");
                    
                            else
                                Console.WriteLine("Data not found" + " [ Now press Enter ]");

                            Console.ReadLine();
                            
                            break;

                        case 3:

                            /*
                             Code for update data in the Azure Redis Cache DataBase
                             */

                            Console.Write("Write the Key to search: ");
                            Key = Console.ReadLine().Trim();

                            Console.Write("Write the new value: ");
                            Value = Console.ReadLine().Trim();

                            if (ServerAzureRedisCache.UpdateData(Key, Value) == true)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Data updated successfully! [ Now press Enter ]");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Data was not updated [ Now press Enter ]");
                                Console.ReadLine();
                            }

                            break;

                        case 4:

                            /*
                             Code for delete data in the Azure Redis Cache DataBase
                           */

                            Console.Write("Write the Key to delete: ");
                            Key = Console.ReadLine().Trim();

                            bool ResultDelete = ServerAzureRedisCache.DeleteData(Key);

                            if (ResultDelete == true)
                                Console.WriteLine("The data was deleted successfully!" + " [ Now press Enter ]");

                            else
                                Console.WriteLine("Data not found" + " [ Now press Enter ]");

                            Console.ReadLine();

                            break;

                        case 5:

                            /*
                             Code for list all data in the Azure Redis Cache DataBase
                           */

                            List<RedisObject> RedisObjects = ServerAzureRedisCache.ListKeys();

                            if (RedisObjects.Count()>0)
                            {
                                foreach (RedisObject RedisHash in RedisObjects)
                                {
                                    Console.Write(RedisHash.Key + " : ");
                                    Console.Write(RedisHash.Value);
                                    Console.WriteLine();
                                }

                                Console.WriteLine("");
                                Console.WriteLine("All hashes shown" + " [ Now press Enter ]");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("No information at this time" + " [ Now press Enter ]");
                                Console.ReadLine();
                            }
                           

                            break;

                                           }
            
                } while (Operation!=0);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("An error occurred. Detail: " + ex.Message + " [ Now press Enter ]");

                Console.Read();
            }
        }
    }
}
