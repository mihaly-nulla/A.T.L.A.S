using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.T.L.A.S.Factory.Universe.CreationModule.components
{
    public interface UniverseResourceInterface<TEntity, TSystem>
        where TEntity : class
        where TSystem : class, new()
    {
        Dictionary<string, TEntity> UniverseResourcesDatabase { get; set; }

        TEntity GetResourceById(string resourceId);

    }
}
