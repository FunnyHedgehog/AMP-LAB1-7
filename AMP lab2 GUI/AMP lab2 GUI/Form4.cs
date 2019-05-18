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
    public partial class Form4 : MaterialForm
    {
        public Form4()
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

        private void Form4_Load(object sender, EventArgs e)
        {
            //Tourist t = new Tourist();

            //if (t.PayForTour()==true)
            //{
            //    materialLabel1.Text="Оплата пройшла успішно";
            //}
            //else
            //{
            //    materialLabel1.Text = "На рахунку недостатньо коштів";
            //}
        }


       

        private void button1_Click(object sender, EventArgs e)
        {
this.Hide();
             Form1 f11 = new Form1();
             f11.Show();
        }
    }
}
