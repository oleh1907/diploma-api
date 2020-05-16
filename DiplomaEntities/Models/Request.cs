using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomaEntities.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string PhotoPath { get; set; }
        public DateTime WhenOccured { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int FoodInfoId { get; set; }
        public FoodInfo FoodInfo { get; set; }
    }
}
