﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernate.Web.Models
{
    public class Student
    {
        public virtual long ID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual int Phone { get; set; }
    }
}