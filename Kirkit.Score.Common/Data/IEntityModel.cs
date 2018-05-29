using Microsoft.EntityFrameworkCore;

namespace Kirkit.Score.Common.Data
{
    public interface IEntityModel
    {
        void BuildModel(ModelBuilder modelBuilder);
    }
}