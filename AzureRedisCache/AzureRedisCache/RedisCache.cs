using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace AzureRedisCache
{
    public class RedisCache
    {
        public string HostName { get; set; }
        public string ConnectionString { get; set; }
        public int PortNoSSL { get; set; }

        /// <summary>
        /// The constructor of RedisCache Class has the connection string necessary to set connections with the Azure Cache Redis from Microsoft Azure.
        /// </summary>
        public RedisCache()
        {
            this.ConnectionString = 
            //"myserverazurerediscache.redis.cache.windows.net,abortConnect=false,password=wU7KEJJy4v3iEH6e0M/Pe74MJSUIbTXyk9SXRMt18vM=";
            "myrediserver.redis.cache.windows.net:6380,password=PKk1DRtF3PeESjv0+30wfP5M4NVy837s6OWBuyIOT1Q=,ssl=True,abortConnect=False";

            this.HostName =
            "myrediserver.redis.cache.windows.net";
            
            this.PortNoSSL = 6379;
        }
        /// <summary>
        /// This method search data by one  key in the Azure Redis Cache DataBase
        /// </summary>
        /// <param name="Value">Data to search</param>
        /// <returns>False if the data not exist, True if the data exist</returns>
        public string SearchData(string Key)
        {
            try
            {               
                ConnectionMultiplexer Connection = ConnectionMultiplexer.Connect(this.ConnectionString);

                var DataBase = Connection.GetDatabase();
                var Data = DataBase.StringGet(Key);

                return Data.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Thie method save data in the Azure Redis Cache DataBase by one Key.
        /// </summary>
        /// <param name="Key">Name of key</param>
        /// <param name="Value">Value for the key</param>
        /// 
        public bool SaveData(string Key, string Value)
        {
            try
            {
                ConnectionMultiplexer Connection = ConnectionMultiplexer.Connect(this.ConnectionString);
                var DataBase = Connection.GetDatabase();

                return DataBase.StringSet(Key, Value);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// This method update an existing string by key
        /// </summary>
        /// <param name="Key">One existing key</param>
        /// <param name="NewValue">New value to update</param>
        /// <returns>True if exist the key, false if not exist the key</returns>
        public bool UpdateData(string Key, string NewValue)
        {
            try
            {
                ConnectionMultiplexer Connection = ConnectionMultiplexer.Connect(this.ConnectionString);

                var DataBase = Connection.GetDatabase();
                var Data = DataBase.StringGet(Key);

                if (Data.HasValue == true)
                    return DataBase.StringSet(Key, NewValue);

                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// This method delete data in the Azure Redis Cache DataBase by one Key
        /// </summary>
        /// <param name="Key">One existing key</param>
        /// <returns>True if exist key, false if not exist the key</returns>
        public bool DeleteData(string Key)
        {
            try
            {
                ConnectionMultiplexer Connection = ConnectionMultiplexer.Connect(this.ConnectionString);
                var DataBase = Connection.GetDatabase();

                return DataBase.KeyDelete(Key);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// This method return all the strings existing in the Azure Redis Cache
        /// </summary>
        /// <returns>A list of objects type RedisObject</returns>
        public List<RedisObject> ListKeys()
        {
            try
            {
                List<RedisObject> KeyList = new List<RedisObject>();

                ConnectionMultiplexer Connection = ConnectionMultiplexer.Connect(this.ConnectionString);

                var Server = Connection.GetServer(this.HostName + ":" + this.PortNoSSL);

                var DataBase = Connection.GetDatabase();

                foreach (var Key in Server.Keys())
                {
                    KeyList.Add(new RedisObject()
                    {
                        Key = Key,
                        Value = DataBase.StringGet(Key),
                    });
                }

                return KeyList;
            }
            catch (Exception)
            {
                
                throw;
            }
        }     
    }
}
