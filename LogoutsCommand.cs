using System;
using System.Collections.Generic;
using System.Text;

namespace eShopOnContainers.Core.Models.Logouts
{
    public class LogoutsCommand
    {

        public int LogoutNumber { get; }

        public LogoutsCommand(int logoutNumber)
        {
            LogoutNumber = logoutNumber;
        }
    }
}
