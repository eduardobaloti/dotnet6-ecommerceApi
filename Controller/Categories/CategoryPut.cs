using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using udemy_dotnet.models.Domains;
using udemy_dotnet.services.Data;

namespace udemy_dotnet.Controller.Categories
{
    public class CategoryPut
    {
        public static string Template => "/categories/{id:guid}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString()};
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute]Guid id, CategoryRequest categoryRequest, ApplicationDbContext context)
        {
            var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();
            category.Name = categoryRequest.Name;
            category.Active = categoryRequest.Active;
            context.SaveChanges();
            return Results.Ok();
        }
    }
}