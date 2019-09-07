namespace hachathon.Database
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext context;

        protected BaseRepository(AppDbContext context)
        {
            this.context = context;
        }
    }
}