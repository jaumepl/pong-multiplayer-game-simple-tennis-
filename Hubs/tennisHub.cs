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

        public void palaAbaixEsq()
        {
            Program.SharedObj.palaEsquerra += 10;
        }        
        public void palaAbaixDreta()
        {
            Program.SharedObj.palaDreta += 10;
        }
        public void palaAmuntEsq()
        {
            Program.SharedObj.palaEsquerra -= 10;
        }         
        public void palaAmuntDreta()
        {
            Program.SharedObj.palaDreta -= 10;
        }       
    }
}