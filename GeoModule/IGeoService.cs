using System;
using System.Collections.Generic;

namespace GeoModule
{
    public interface IGeoService
    {
        IEnumerable<String> GetZipCodes();
        IEnumerable<String> GetCitiesByZip();
    }
}
