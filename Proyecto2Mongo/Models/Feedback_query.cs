using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Proyecto2Mongo.Models;

public class Feedback_query{

    public string client {get;set;} = null!;
    public string date{get; set;} = null!;}