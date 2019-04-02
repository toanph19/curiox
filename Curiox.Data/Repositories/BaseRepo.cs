using Curiox.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Curiox.Data.Repositories
{
    public class BaseRepo
    {
        protected CurioxContext Db { get; set; }

        public BaseRepo()
        {
            Db = new CurioxContext();
        }
    }
}
