using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Repository.Options
{
    public class RepositoryOptions
    {
        public const string Name = "VehicleRepository";

        public string? ConnectionString { get; set; }
    }
}
