using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Infrastructure.Configuration
{
    public record MongoSettings(string ConnectionString, string DatabaseName, string CollectionName);
}
