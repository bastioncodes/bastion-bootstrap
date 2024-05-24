using System;

namespace Bastion.Core
{
    public class GuidRepository<TModel> : Repository<Guid, TModel> where TModel : class
    {
        public Guid Add(TModel model)
        {
            var id = Guid.NewGuid();
            
            base.Add(id, model);

            return id;
        }
    }
}