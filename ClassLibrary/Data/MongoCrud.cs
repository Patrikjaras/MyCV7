using ClassLibrary1.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data
{
	public class MongoCrud<T>
	{
		private IMongoDatabase db;

		public MongoCrud(string database)
		{
			var client = new MongoClient("mongodb://localhost:27017");
			db = client.GetDatabase(database);
		}

		//Lägga till
		public async Task<T> AddAsync(string table, T var)
		{
			var collection = db.GetCollection<T>(table);
			await collection.InsertOneAsync(var);
			return var;
		}
		//hämta allt
		public async Task<List<T>> GetAsync(string table)
		{
			var collection = db.GetCollection<T>(table);
			var response = await collection.AsQueryable().ToListAsync();
			return response;
		}			
		
		//Hämta specifik
		public async Task<T> GetByID<T>(string table, string id) where T : class
		{
			var collection = db.GetCollection<T>(table);
			var filter = Builders<T>.Filter.Eq("Id", id); // Assuming your ID field is named "_id"

			var result = await collection.Find(filter).FirstOrDefaultAsync();

			return result;
		}
		//Uppdatera
		public async Task<T> Update<T>(string table, T UpdatedObject, string id) where T : class
		{
			var collection = db.GetCollection<T>(table);
			var filter = Builders<T>.Filter.Eq("Id", id);

			var result = await collection.ReplaceOneAsync(filter, UpdatedObject, new ReplaceOptions { IsUpsert = true });

			if (result.ModifiedCount == 0)
			{
				// Document with the specified ID was not found
				// You might want to handle this case based on your requirements
			}

			return UpdatedObject;
		}
		//Delete
		public async Task<T> Delete<T> (string table, string id) where T : class
		{
			var collection = db.GetCollection<T>(table);
			var filter = Builders<T>.Filter.Eq("Id", id);
			var result = await collection.DeleteOneAsync(filter);

			if (result.DeletedCount == 0) {
				return null;
			}
			return await collection.Find(filter).FirstOrDefaultAsync();

		}


	}
}
