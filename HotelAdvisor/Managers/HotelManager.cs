using HotelAdvisor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace HotelAdvisor.Managers
{
    public class HotelManager
    {
        public void Create(Hotel hotel)
        {
            using (var context = new HotelAdvisorContext())
            {
                context.Hotels.Add(hotel);
                context.SaveChanges();
            }
        }

        public HotelDetailsViewModel GetHotelDetails(int hotelId)
        {
            HotelDetailsViewModel hotelDetails = new HotelDetailsViewModel();

            using (var context = new HotelAdvisorContext())
            {
                hotelDetails = context.Hotels.Where(h => h.Id == hotelId).Include(h => h.Comments).Select(
                    s => new HotelDetailsViewModel()
                    {
                        HotelId = s.Id,
                        HotelName = s.Name,
                        City = s.City,
                        Description = s.Description,
                        Address = s.Address,
                        Image = s.Image,
                        TotalReveiws = s.Comments.Count(),
                        AverageRating = (s.Comments.Count() == 0) ? 0 : s.Comments.Average(c => c.Rating),
                        Comments = s.Comments.ToList()
                    }).FirstOrDefault();
            }

            return hotelDetails;
        }


    }
}