using System;
using Microsoft.AspNetCore.Mvc;
using Proyecto2Mongo.Services;
using Proyecto2Mongo.Models;
using System.Data;

namespace Proyecto2Mongo.Controllers;

[Controller]
[Route("api/[Controller]")]
public class FeedbackController : Controller{

    private readonly MongoDBService _mongoDBService;

    public FeedbackController(MongoDBService mongoDBService){
        _mongoDBService = mongoDBService;
    } 

    [HttpGet("get_all_feedback")]
    public async Task<List<Feedback>> GetFeedbacks(){
        return await _mongoDBService.GetFeedback();
    }   



    [HttpPost("add_feedback")]
    public async Task<IActionResult> PostFeedbacks([FromBody] Feedback feedback){
        await _mongoDBService.CreateFeedback(feedback);
        return CreatedAtAction(nameof(GetFeedbacks), new {id = feedback.id}, feedback);
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFeedback(string id, [FromBody] string message){
        await _mongoDBService.UpdateFeedback(id, message);
        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFeedback(string id){
        await _mongoDBService.DeleteFeedback(id);
        return NoContent();
    }
    [HttpPost("get_feedback")]
    public async Task<List<Feedback>> GetSpecifiedFeedbacks([FromBody] Feedback_query feedback)
    {
        return await _mongoDBService.GetSpecifiedFeedback(feedback.client);
    }


}
