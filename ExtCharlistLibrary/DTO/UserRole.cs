using System;
using System.Collections.Generic;
using System.Text;

namespace ExtCharlistLibrary.DTO
{
    public class UserRole
    {
        private string v;

        public UserRole(string v)
        {
            this.v = v;
        }
        public UserRole() { }

        public string? Name { get; set; }
    }
}
