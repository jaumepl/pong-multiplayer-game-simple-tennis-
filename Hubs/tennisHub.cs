using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using tennis1;
using tennis1.Models;

namespace personal.Hubs
{
    public class tennisHub : Hub
    {
        public tennisHub()
        {

        }

        public void palaAbaixEsq(int id)
        {
            Program.SharedObj[id].palaEsquerra += 10;
        }        
        public void palaAbaixDreta(int id)
        {
            Program.SharedObj[id].palaDreta += 10;
        }
        public void palaAmuntEsq(int id)
        {
            Program.SharedObj[id].palaEsquerra -= 10;
        }         
        public void palaAmuntDreta(int id)
        {
            Program.SharedObj[id].palaDreta -= 10;
        }       
    }
}