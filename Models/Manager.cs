using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace launchpadApp.Models {

    public class Manager : DbContext {

        // -------------------------------------------------- get/sets
        private DbSet<Category> tblCategory { get; set;}
        private DbSet<Link> tblLink { get; set;}
        

        // -------------------------------------------------- public methods

        public List<Category> categories {
            get {
                return tblCategory.OrderBy(c => c.categoryID).ToList();
            }
        }

        public List<Link> links {
            get {
                return tblLink.OrderBy(c => c.linkName).ToList();
            }
        }

        public List<Link> unpinnedList {
            get {
                return tblLink.Where(l=>(l.pinned==false)).OrderBy(l => l.linkName).ToList();
            }
        }

        public List<Link> pinnedList {
            get {
                return tblLink.Where(l=>(l.pinned==true)).OrderBy(l => l.linkName).ToList();
            }
        }

        // list for dropdown
        public SelectList getLinksList() {
            // get the list of the data in the table
            List<Link> linkList = tblLink.OrderBy(c => c.categoryID).ToList();
            return new SelectList(linkList, "id", "linkName");
        }

        public SelectList getCategoryList() {
            // get the list of the data in the table
            List<Category> catList = tblCategory.ToList();
            return new SelectList(catList, "categoryID", "categoryName");
        }
        
        public Category getCategoryByID(int categoryID) {
            return tblCategory.Where(c => c.categoryID == categoryID).FirstOrDefault();
        }

        public Link getLinkByID(int linkID) {
            return tblLink.Where(c => c.id == linkID).FirstOrDefault();
        }
        // -------------------------------------------------- private methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(Connection.CONNECTION_STRING, new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}