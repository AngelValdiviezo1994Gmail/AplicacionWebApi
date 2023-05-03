using Microsoft.EntityFrameworkCore;

namespace AplicacionWebApiAngelValdiviezo
{
    public class ApplicationBdContext : DbContext
    {
        public ApplicationBdContext(DbContextOptions options) : base (options)
        {

        }
    }
}
