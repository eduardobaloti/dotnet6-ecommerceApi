using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using udemy_dotnet.models.Domains;
using udemy_dotnet.services.Data;

namespace udemy_dotnet.Controller.Categories
{
    public class CategoryPost
    {
        public static string Template => "/categories";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString()};
        public static Delegate Handle => Action;

        public static IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context)
        {
            var category = new Category(categoryRequest.Name)
            {
                Name = categoryRequest.Name,
                CreatedBy = "Test",
                CreatedOn = DateTime.Now,
                EditedBy = "Test",
                EditedOn = DateTime.Now, 
            };

            if (!category.IsValid)
                return Results.BadRequest(category.Notifications);

            context.Categories.Add(category);
            context.SaveChanges();

            return Results.Created($"/categories/{category.Id}", category.Id);
        }
    }
}