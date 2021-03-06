﻿using Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Interface
{
     public  interface IStaff
    {
        public List<StaffDetails> GetInStaffs();
        public Result AddStaff(StaffDetails inStaff);
        public Result UpdateStaff(StaffDetails inStaff);
        public Result DeleteStaff(string Id);
    }
}
