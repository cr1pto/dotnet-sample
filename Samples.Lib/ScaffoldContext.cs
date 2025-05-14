using Microsoft.EntityFrameworkCore;
using Samples.Lib.Entities;

namespace Samples.Lib;

public class ScaffoldContext : SampleDbContext
{
    public ScaffoldContext() : base("User ID=postgres;Password=ItIsAS3cretToEverybody;Host=localhost;Port=5432;Database=SampleDb;Pooling=true;Connection Lifetime=0;")
    {
    }
}