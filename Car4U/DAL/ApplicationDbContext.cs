using Car4U.CarModels;
using Car4U.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Car4U.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<MomentReturn> MomentTypes { get; set; }
        public DbSet<MomentDelivery> Moments { get; set; }
        public DbSet<MeetingPoint> MeetingPoints { get; set; }
        public DbSet<ExtraModelType> ExtraTypes { get; set; }
        public DbSet<ExtraItem> Extras { get; set; }
        public DbSet<ExtraModel> ExtraModels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<FuelType> Fuels { get; set; }
        public DbSet<Promotion> Promotions { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Car4U.Models.Status> Unavailabilities { get; set; }
    }
}