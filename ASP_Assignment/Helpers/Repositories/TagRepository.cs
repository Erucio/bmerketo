using ASP_Assignment.Models.Contexts;
using ASP_Assignment.Models.Entities;

namespace ASP_Assignment.Helpers.Repositories
{
    public class TagRepository : Repository<TagEntity>
    {
        public TagRepository(IdentityContext context) : base(context) 
        {
        }
    }
}
