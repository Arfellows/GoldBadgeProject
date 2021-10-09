using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings_Repository
{
    public class OutingsRepo
    {
        private List<Outings> _outings = new List<Outings>();

        //CREATE
        public void AddOuting(Outings outing)
        {
            _outings.Add(outing);
        }

        //READ
        public List<Outings> ViewOutings()
        {
            return _outings;
        }

        //HELPER METHOD
        public Outings ViewOutingByName(string name)
        {
            foreach(Outings outing in _outings)
            {
                if(outing.Name.ToLower() == name.ToLower())
                {
                    return outing;
                }
            }
            return null;
        }
    }
}
