﻿using MongoDB.Bson;
using MongoDB.Driver;

namespace POC_Mongo.Src.Repositories.MongoDB
{
    public class MongoDBRepository
    {
        private static MongoClient? client = null;
        public static MongoClient connect()
        {
            if (client != null)
            {
                return client;
            }

            const string connectionUri = "mongodb+srv://your_connection_string";

            var settings = MongoClientSettings.FromConnectionString(connectionUri);

            // Set the ServerApi field of the settings object to set the version of the Stable API on the client
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            // Create a new client and connect to the server
           client = new MongoClient(settings);

            // Send a ping to confirm a successful connection
            try
            {
                var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");

                return client;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
    }
}
