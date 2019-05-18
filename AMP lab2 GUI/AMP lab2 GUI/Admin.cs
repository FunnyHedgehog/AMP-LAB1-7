using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AMP_lab2_GUI
{
    class Admin: Man
    {
        public string Surname { get; set; }
        public string Position { get; set; }
        private int Salary { get; set; }
        public int number;
        public void ConfirmOrder(Order order)
        {
            order.Status = "Payed";
            TourContext db = new TourContext();
            db.Orders.Add(order);
            db.SaveChanges();

        }
        delegate void Do(Order order);//3.2
        public Admin()
        {
            Do smth = ConfirmOrder;
            Order order = new Order();
            smth(order);
        }
        public string this[int index]
        {
            get { return Surname; }
            set { Surname = value; }
        }
        public void AddTourToDB(Tour tour)//4-5.6 - create
        {
            using (TourContext db = new TourContext())
            {
                db.Tours.Add(tour);
                db.SaveChanges();
            }
        }
        public void UpdateTourPrice(string country, int price)//4-5.6 - update
        {
            using (TourContext db = new TourContext())
            {
                Tour t1 = db.Tours.FirstOrDefault(t => t.Сountry == country);//5-6.10

                t1.Price = price;
                db.SaveChanges();   // сохраняем изменения
            }
        }
        public void DeleteTour(string country)//4-5.6 - delete
        {
            using (TourContext db = new TourContext())
            {
                Tour p1 = db.Tours.FirstOrDefault(t => t.Сountry == country);
                if (p1 != null)
                {
                    db.Tours.Remove(p1);
                    db.SaveChanges();
                }
            }
        }
    }
}
