using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace AMP_lab2_GUI
{
    public partial class Form2 : MaterialForm
    {
        //Tour[] tours2 = new Tour[6];
        public Form2()
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

        private void Form2_Load(object sender, EventArgs e)
        {
            //System.IO.StreamReader file = new System.IO.StreamReader(@"E:\Choose.txt") ;
            //string choose_tour;
            //choose_tour = file.ReadLine();
            //file.Close();
            //Tour tour = new Tour();
            TourContext db = new TourContext();
            var tours2 = db.Tours.Where(t=>t.Status == "Reserved");
            //tour.ReadFromFile(tours2);
            foreach (Tour tour2 in tours2)
            {
                //if(tour2.country == choose_tour)
                //{
                    materialSingleLineTextField1.Text = Convert.ToString(tour2.Сountry);
                    materialSingleLineTextField2.Text = Convert.ToString(tour2.Rate);
                    materialSingleLineTextField3.Text = Convert.ToString(tour2.lenght);
                    materialSingleLineTextField4.Text = Convert.ToString(tour2.Price);
                    materialSingleLineTextField5.Text = Convert.ToString(tour2.Hotel);
                    materialSingleLineTextField6.Text = Convert.ToString(tour2.RoomType);
                    materialSingleLineTextField7.Text = Convert.ToString(tour2.Transport);
                    materialSingleLineTextField8.Text = Convert.ToString(tour2.DepartureDate);
                    break;
                //}
                
            }
            
            
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
            this.Close();
        }

       
    }
}
