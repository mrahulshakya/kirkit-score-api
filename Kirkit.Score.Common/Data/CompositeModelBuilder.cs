using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Kirkit.Score.Common.Data
{
    public class CompositeModelBuilder
    {
        private List<IEntityModel> models = new List<IEntityModel>();
        public void Build(ModelBuilder modelBuilder)
        {
            foreach (var model in models)
            {
                model.BuildModel(modelBuilder);
            }

            models = new List<IEntityModel>();
        }

        public void Add(IEntityModel entityModel)
        {
            models.Add(entityModel);
        }

        public void AddRange(IEnumerable<IEntityModel> newModels)
        {
            models.AddRange(newModels);
        }
    }
}
