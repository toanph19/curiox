using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Curiox.Data.Repositories
{
    public class BaseRepo
    {
        protected string connString = "Server=localhost;Port=5432;Username=postgres;Password=1;Database=QLKHDB";
    }
}
