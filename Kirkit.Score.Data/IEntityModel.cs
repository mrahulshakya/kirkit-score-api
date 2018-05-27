using Microsoft.EntityFrameworkCore;

namespace Kirkit.Score.Data
{
    public interface IEntityModel
    {
        void BuildModel(ModelBuilder modelBuilder);
    }
}