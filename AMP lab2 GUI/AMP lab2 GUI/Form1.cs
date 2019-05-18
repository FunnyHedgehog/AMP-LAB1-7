using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using MaterialSkin;
using MaterialSkin.Controls;

namespace AMP_lab2_GUI
{
    public partial class Form1 : MaterialForm
    {
        Tour[] tours = new Tour[6];
        public Form1()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TopMost = true;
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey800, Accent.LightGreen400,
                TextShade.WHITE
                );
           
        }
        private Tour[] Eager_loading()//завантаження даних(жадна загрузка) 4-5.7
        {
            using (TourContext db = new TourContext())
            {
                var Tours = db.Tours.Include(t => t.Region).ToList();
                Tour[] tours = new Tour[Tours.Count];
                foreach (Tour t in Tours)
                {
                    MessageBox.Show(t.Region.Name);
                }
                return tours;
            }
        }
        private void Group_By_Status()//5-6.11
        {
            using (TourContext db = new TourContext())
            {
                int count = db.Tours.Count();//5-6.15
                var groups = from t in db.Tours
                group t by t.Status;
                foreach (var g in groups)
                {
                    Console.WriteLine(g.Key);
                    foreach (var t in g)
                        Console.WriteLine("{0} - {1}", t.Сountry, t.Price);
                    Console.WriteLine();
                }
            }
        }
        private void Join()//5-6.12
        {
            using (TourContext db = new TourContext())
            {
                var tours = db.Tourists.Join(db.Orders, // второй набор // 5-6.13 5-6.17
                    t => t.Id, // свойство-селектор объекта из первого набора
                    o => o.TouristId, // свойство-селектор объекта из второго набора
                    (t, o) => new // результат
                    {
                        Name = t.Name,
                        Email = o.Email,
                        Price = o.Price,
                        Status = o.Status

                    });
                foreach (var t in tours)
                    Console.WriteLine("{0} ({1}) - {2}", t.Name, t.Email, t.Status);
            }
        }
        private void Union()//5-6.18
        {
            using (TourContext db = new TourContext())
            {
                var tours = db.Tours.Where(t => t.Price < 2500)
                    .Union(db.Tours.Where(t => t.Rate > 4));
                //foreach (var item in tours)
                    //Console.WriteLine(item.Name);
            }
        }
        private void Intersect()//5-6.18
        {
            using (TourContext db = new TourContext())
            {
                var tours = db.Tours.Where(t => t.Price < 2500)
                    .Intersect(db.Tours.Where(t => t.Rate > 4));
                //foreach (var item in tours)
                //Console.WriteLine(item.Name);
            }
        }
        private void Except()//5-6.18
        {
            using (TourContext db = new TourContext())
            {
                var selector1 = db.Tours.Where(t => t.Price < 2500); 
                var selector2 = db.Tours.Where(t => t.Сountry.Contains("Italy")); 
                var phones = selector1.Except(selector2);

                //foreach (var item in phones)
                //    Console.WriteLine(item.Name);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Tourist Vova = new Tourist();
            var Tours = Eager_loading();//4-5.7
            //Admin admin = new Admin();
            //Tour france = new Tour("France", 20, 3, "HF", "A", "bus", 2000, 24);
            //Tour mexico = new Tour("Mexico", 10, 5, "HM", "C", "plane", 1500, 12);
            //Tour italy = new Tour("Italy", 7, 4, "HI", "B", "bus", 1000, 03);
            //Tour oslo = new Tour("Norvay", 12, 5, "HO", "B", "train", 1200, 13);
            //Tour china = new Tour("China", 14, 3, "HC", "C", "plane", 2200, 30);
            //Tour berlin = new Tour("Germany", 17, 4, "HB", "A", "bus", 1500, 28);
            //Tour uk = new Tour("UK", 12, 3, "HU", "A", "plane", 1500, 12);
            //Tour poland = new Tour("Poland", 10, 5, "HP", "A", "bus", 700, 7);
            //Tour[] tours = new Tour[8];
            //tours[0] = france;
            //tours[1] = mexico;
            //tours[2] = italy;
            //tours[3] = oslo;
            //tours[4] = china;
            //tours[5] = berlin;
            //tours[6] = uk;
            //tours[7] = poland;
            //foreach (Tour tour in tours)
            //{
            //    admin.AddTourToDB(tour);
            //}

        }
        public void ChoosenTour(string choosen_tour)
        {
            TourContext db = new TourContext();
            Tour tour = db.Tours.FirstOrDefault(t => t.Сountry == choosen_tour);
            tour.Status = "Reserved";
            db.SaveChanges();
            Form2 f2 = new Form2();
                this.Hide();
                f2.Show();

        }
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            ChoosenTour("France");
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            ChoosenTour("Mexico");
        }

        private void materialRaisedButton3_Click_1(object sender, EventArgs e)
        {
            ChoosenTour("Italy");
        }

        private void materialRaisedButton4_Click_1(object sender, EventArgs e)
        {
            ChoosenTour("Oslo");
        }

        private void materialRaisedButton5_Click_1(object sender, EventArgs e)
        {
            ChoosenTour("China");
        }

        private void materialRaisedButton6_Click_1(object sender, EventArgs e)
        {
            ChoosenTour("Berlin");
        }
    }
}
