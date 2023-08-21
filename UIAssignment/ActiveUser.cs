﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAssignment
{
    public static class ActiveUser
    {
        /// <summary>
        /// has the basic information and is used to avoid duplication in specific cases
        /// </summary>
        public static User User { get; set; } = null;
        /// <summary>
        /// has the additional information if the user is an employee. If the user is a customer then this must be null.
        /// </summary>
        public static Employee Employee { get; set; } = null;
        /// <summary>
        /// has the additional information if the user is an customer. If the user is an employee then this must be null.
        /// </summary>
        public static Customer Customer { get; set; } = null;
    }
}