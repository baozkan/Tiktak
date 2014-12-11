using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Data.Memory
{
    public class MemoryContext
    {
     // static holder for instance, need to use lambda to construct since constructor private
       private static readonly Lazy<MemoryContext> instance
           = new Lazy<MemoryContext>(() => new MemoryContext());

       private readonly IDictionary<string, object> dataSources = new Dictionary<string, object>();
    
       // private to prevent direct instantiation.
       private MemoryContext() { }
    
       // accessor for instance
       public static MemoryContext Default
       {
           get { return instance.Value;  }
       }

       public ICollection<TModel> GetSet<TModel>()
       { 
           var key = typeof(TModel).Name;
           if (!this.dataSources.ContainsKey(key))
           {
               var collection = new HashSet<TModel>();
               this.dataSources.Add(key,collection);
           }

           return this.dataSources[key] as ICollection<TModel>;
       }


    }
}
