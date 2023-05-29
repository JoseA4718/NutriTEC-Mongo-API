using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Proyecto2Mongo.Models;

public class Feedback{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get; set;}
    public string client {get;set;} = null!;
    public string nutritionist {get; set;} = null!;
    public string message{get;set;} = null!;
    public string date{get; set;} = null!;




}