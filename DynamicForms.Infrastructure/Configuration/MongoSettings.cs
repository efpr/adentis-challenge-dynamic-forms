using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Infrastructure.Configuration
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }  
    }
}
