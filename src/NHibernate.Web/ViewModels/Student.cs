using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernate.Web.ViewModels
{
    public class Student
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }       
    }
}