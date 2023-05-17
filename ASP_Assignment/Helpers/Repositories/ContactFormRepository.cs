using ASP_Assignment.Models.Contexts;
using ASP_Assignment.Models.Entities;

namespace ASP_Assignment.Helpers.Repositories
{
    public class ContactFormRepository : Repository<CommentEntity>
    {
        public ContactFormRepository(IdentityContext context) : base(context)
        {
        }
    }
}