namespace Kirkit.Score.Data
{
    public interface IRepositoryFactory
    {
        dynamic GetRepository(string resource);
    }
}
