namespace Company.Data.Contexts
{
    public class CompanyContext : DbContext
    {
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<EmployeePosition>().HasKey(ep => new {   
                    ep.EmployeeId,
                    ep.PositionId
                });
        }
    }
}
