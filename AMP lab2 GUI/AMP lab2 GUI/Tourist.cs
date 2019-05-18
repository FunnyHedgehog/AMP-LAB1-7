using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMP_lab2_GUI
{
    class Tourist: Man, IAccount
    {
        new public string Name { get; set; }//2.5
        public string Surname { get; set; }
        public int our_client_since;
        
	    private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private int id;
        public int Id
         {
            get { return id; }
            set { id = value; }
        }
        private int card_number;
        public int Card_number
        {
            get { return card_number; }
            set { card_number = value; }
        }
        private int insurance;
        public int Insurance
        {
            get { return insurance; }
            set { insurance = value; }
        }
        private int money;
        public int Money
        {
            get { return money; }
            set { money = value; }
        }
        public ICollection<Order> Orders { get; set; }//4-5.9 4-5.7
        public ICollection<Tour> Tours { get; set; }//4-5.10
        public Tourist()//4-5.9
        {
            Orders = new List<Order>();//4-5.9 4-5.7
            Tours = new List<Tour>();//4-5.10
        }

        public Tourist(string name, string surname, int our_client_since, int age, int id, int card_number, int insurance, int money)
        {
            this.Name = name;
            this.Surname = surname;
            this.our_client_since = our_client_since;
            this.age = age;
            this.id = id;
            this.card_number = card_number;
            this.insurance = insurance;
            this.money = money;
            base.Work();
            Orders = new List<Order>();
            Tours = new List<Tour>();
        }
        // interface IAccount
        private int _sum;
        public int CurrentSum { get; }
        public void Put(int sum)
        {
            this._sum += sum;
        }
        delegate int Incrementor(int number);//3.5
        public void Withdraw(int sum)
        {
            Incrementor func = delegate (int number)//3.5 анонімна
            {
                number++;
                return number;
            };
            if (_sum >= sum)
            {
                _sum -= sum;
            }
        }
        // end IAccount
        // IUserInfo
       
        //end IUserInfo
        void MakeOrder(Tour tour)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\Order.txt", true))
            {
                file.WriteLine(tour.Сountry);
                file.WriteLine(tour.lenght);
                file.WriteLine(tour.Rate);
                file.WriteLine(tour.Hotel);
                file.WriteLine(tour.RoomType);
                file.WriteLine(tour.Transport);
                file.WriteLine(tour.Price);
                file.WriteLine(tour.DepartureDate);

            }
        }
       delegate void Operation(int price);
       public bool PayForTour(int price)
        {
            if (this.money >= price)
            {
                Operation op = (tourprice) => this.money -= tourprice;//3.5 lambda
                
                op(price);
                return true;
            }
            else { 
                return false;
            }
               
        }
     
        public override void Relax(ref string place, out int happiness, int day = 5)
        {
            base.Relax(ref place, out happiness, day = 5);
        }
    }
}
