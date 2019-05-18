using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace AMP_lab2_GUI
{
    class TourContext : DbContext
    {
        public TourContext()
            : base("DBSasha")
        { }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
    sealed class Tour//2.7
    {
        [Key]
        public int Id { get; set; }
        public string Сountry { get; set; }
        public int lenght { get; set; }
        public int Rate { get; set; }

        

        private string hotel;
        public string Hotel
        {
            get { return hotel; }
            set { hotel = value; }
        }
        private string room_type;
        public string RoomType
        {
            get { return room_type; }
            set { room_type = value; }
        }
        private string transport;
        public string Transport
        {
            get { return transport; }
            set { transport = value; }
        }
        private int price;
        public int Price
        { get; set; }
        private int departure_date;
        public int DepartureDate
        {
            get { return departure_date; }
            set { departure_date = value; }
        }
        public string Status
        {
            get;set;
        }
        public int? RegionId { get; set; }// 4-5.7
        public Region Region { get; set; }// навігаційна властивість 4-5.7
        public ICollection<Tourist> Tourists { get; set; }//4-5.10
        public Tour() {
            Tourists = new List<Tourist>();
        }
        public Tour(string country, int lenght, int rate, string hotel, string room_type, string transport, int price, int departure_date){
	    this.Сountry = country;
	    this.lenght = lenght;
	    this.Rate = rate;
	    this.hotel = hotel;
	    this.room_type = room_type;
	    this.transport = transport;
	    this.Price = price;
	    this.departure_date = departure_date;
        Status = "Available";
        Tourists = new List<Tourist>();
        }
        
        }
     };

