using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace launchpadApp.Models {

    public class CategoryManager : DbContext {

        // -------------------------------------------------- get/sets
        private DbSet<Category> tblCategory { get; set;}
        private DbSet<Link> tblLink { get; set;}
        
        public List<Category> categories {
            get {
                return tblCategory.OrderBy(c => c.categoryID).ToList();
            }
        }

        public List<Link> links {
            get {
                return tblLink.OrderBy(c => c.categoryID).ToList();
            }
        }
        // -------------------------------------------------- public methods
        // list for dropdown
        public SelectList getSelectList() {
            // get the list of the data in the table
            List<Category> listData = tblCategory.OrderBy(c => c.categoryID).ToList();
            return new SelectList(listData, "customerID", "lastName");
        }

        // -------------------------------------------------- private methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(Connection.CONNECTION_STRING, new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}