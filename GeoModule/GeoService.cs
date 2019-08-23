using System;
using System.Collections.Generic;
using System.Text;

namespace GeoModule
{
    public class GeoService : IGeoService
    {
        public IEnumerable<string> GetCitiesByZip()
        {
            return new String[] { "Vourles", "Brignais"};
        }

        public IEnumerable<string> GetZipCodes()
        {
            return new String[] { "01000", "01100" };
        }
    }
}
