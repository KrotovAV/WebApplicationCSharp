﻿namespace WebApplication02HW.Models
{
    public class Group : BaseModel
    {

        public virtual List<Product> Products{get; set;} = new List<Product> ();


    }
}
