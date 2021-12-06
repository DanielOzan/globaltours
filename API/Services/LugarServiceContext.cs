using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class LugarServiceContext
    {
        private readonly ILugarService _ilugarServ;
        public LugarServiceContext(ILugarService ilugarServ)
        {
            _ilugarServ = ilugarServ;
        }

        public string getReferenceOFService()
        {
          return  _ilugarServ.getReferenceOFService();

        }
    }
}