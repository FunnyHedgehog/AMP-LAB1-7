using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMP_lab2_GUI
{
    interface IAccountInfo: IAccount, IUserInfo
    {
        int Account_number { get; set; }
    }
}
