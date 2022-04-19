using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using udemy_dotnet.models.Domains;
using udemy_dotnet.services.Data;

namespace udemy_dotnet.Controller.Categories
{
    public class CategoryDelete
    {
       public static string Template => "/categories/{id}";
       public static string[] Methods => new string[] { HttpMethod.Delete.ToString()};
       public static Delegate Handle => Action;

       public static IResult Action([FromRoute]Guid id, ApplicationDbContext context)
       {
           var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();
           context.Categories.Remove(category);
           context.SaveChanges();
           return Results.Ok();
       }
    }
}