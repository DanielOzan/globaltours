using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{

    public class LugarService : ILugarService
    {
        public string key { get => "Default";}
        

        public string getReferenceOFService()
        {
            return "Solo una prueba";
        }
    }
}