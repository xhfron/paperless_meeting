using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pm_client.util
{
    public interface INavigator
    {
        void Push(System.Windows.Controls.UserControl newView);
    }
}
