﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelAdvisor.Models
{
    public class HotelDetailsViewModel
    {
        public int HotelId { get; set; }

        public string HotelName { get; set; }

        [Display(Name = "Average rating")]
        public decimal AverageRating { get; set; }

        public string Image { get; set; }

        [Display(Name = "Total reviews")]
        public int TotalReveiws { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Description { get; set; }

        public List<Comment> Comments { get; set; }
    }
}