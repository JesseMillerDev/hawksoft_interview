﻿using BlazorBoilerplate.Shared.DataInterfaces;
using BlazorBoilerplate.Shared.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Storage
{
    public interface IApplicationDbContext
    {
        public DbSet<ApiLogItem> ApiLogs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        public void SetGlobalQueryForSoftDelete<T>(ModelBuilder builder) where T : class, ISoftDelete;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        int SaveChanges();

    }
}
