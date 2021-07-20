﻿using LumberManagerWebEdition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LumberManagerWebEdition.Data
{
    public static class UserDB
    {
        /// <summary>
        /// Gets the current user
        /// </summary>
        /// <param name="id">The user id</param>
        public static User GetUser(ApplicationDbContext _context, string id)
        {

            User user = (from u in _context.Customers
                               where u.UserID == id
                               select u).SingleOrDefault();
            return user;
        }

        /// <summary>
        /// Adds user to the database for orders
        /// </summary>
        /// <param name="u">The user to be added</param>
        public static async Task AddUserAsync(ApplicationDbContext _context, User u)
        {
            // Adds user to database
            _context.Customers.Add(u);
            await _context.SaveChangesAsync();
        }
    }
}
