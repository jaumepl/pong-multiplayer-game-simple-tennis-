using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using tennis1;

namespace personal.Hubs
{
    public class tennisHub : Hub
    {
        public tennisHub()
        {
        }

        public void palaAbaix()
        {
            Program.SharedObj.palaEsquerra += 10;
        }
        public void palaAmunt()
        {
            Program.SharedObj.palaEsquerra -= 10;
        }
    }
}