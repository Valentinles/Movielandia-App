using Movielandia.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movielandia.Services.Implementations
{
    public class DataService
    {
        protected readonly MovielandiaDbContext context;

        public DataService(MovielandiaDbContext context)
        {
            this.context = context;
        }
    }
}
