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
    public partial class Form3 : MaterialForm
    {
        public Form3()
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

        private void Form3_Load(object sender, EventArgs e)
        {
            TourContext db = new TourContext();
            var tour2 = db.Tours.Where(t => t.Status == "Reserved");
            foreach(Tour t in tour2)
            {
                materialLabel3.Text = Convert.ToString(t.Price);
                break;
            }
           

        }
        delegate int Incrementor(int number);//3.5
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Name = materialSingleLineTextField4.Text;
            order.Surname = materialSingleLineTextField5.Text;
            order.PhoneNumber = materialSingleLineTextField6.Text;
            order.Email = materialSingleLineTextField7.Text;
            order.CardNumber = materialSingleLineTextField1.Text;
            order.CardExpireDate = materialSingleLineTextField3.Text;
            order.CVV = Convert.ToInt32(materialSingleLineTextField2.Text);
            Admin admin = new Admin();
            admin.ConfirmOrder(order);
            Incrementor func = delegate (int number)
            {
                number++;
                return number;
            };
            func(admin.number);
            Form4 f4 = new Form4();
            this.Hide();
            f4.Show();
            this.Close();
        }

        
    }
}
