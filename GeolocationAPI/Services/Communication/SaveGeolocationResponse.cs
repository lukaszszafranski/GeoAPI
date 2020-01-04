using GeolocationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolocationAPI.Services.Communication
{
    public class GeolocationResponse : BaseResponse 
    {
        public GeolocationData GeolocationData { get; private set; }

        private GeolocationResponse(bool success, string message, GeolocationData geolocationData) : base(success, message)
        {
            GeolocationData = geolocationData;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="geolocationData">Saved category.</param>
        /// <returns>Response.</returns>
        public GeolocationResponse(GeolocationData geolocationData) : this(true, string.Empty, geolocationData)
        {

        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public GeolocationResponse(string message) : this(false, message, null)
        {

        }
    }
}
