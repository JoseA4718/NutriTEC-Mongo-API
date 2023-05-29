using Proyecto2Mongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Proyecto2Mongo.Services;

public class MongoDBService{

    private readonly IMongoCollection<Feedback> _feedbackCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings){
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _feedbackCollection = database.GetCollection<Feedback>(mongoDBSettings.Value.CollectionName);
    }

    public async Task CreateFeedback(Feedback feedback){
        await _feedbackCollection.InsertOneAsync(feedback);
        return;
    }

    public async Task<List<Feedback>> GetFeedback(){
        return await _feedbackCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task UpdateFeedback(string id, string message){
        FilterDefinition<Feedback> filter = Builders<Feedback>.Filter.Eq("Id",id);
        UpdateDefinition<Feedback> update = Builders<Feedback>.Update.AddToSet<string>("message",message);
        await _feedbackCollection.UpdateOneAsync(filter,update);
        return;
    }

    public async Task DeleteFeedback(string id){
        FilterDefinition<Feedback> filter = Builders<Feedback>.Filter.Eq("Id",id);
        await _feedbackCollection.DeleteOneAsync(filter);
        return;
    }

    public async Task<List<Feedback>> GetSpecifiedFeedback(string email){
        FilterDefinition<Feedback> email_filter = Builders<Feedback>.Filter.Eq("client",email);
        return await _feedbackCollection.Find(new BsonDocument { { "client", email } }).ToListAsync();
 
    }
}