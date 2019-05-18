using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMP_lab2_GUI
{
    interface IUserInfo
    {
        string Surname
        {
            get;
            set;
        }

        string this[int index]
        {
            get;
            set;
        }
    }
}
