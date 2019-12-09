using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeolocationAPI.Models;
using Microsoft.EntityFrameworkCore.Internal;
using GeolocationAPI.Services;
using AutoMapper;
using GeolocationAPI.Resources;
using System.Net;

namespace GeolocationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeolocationController : ControllerBase
    {
        private readonly IGeolocationService _geolocationService;
        private readonly IMapper _mapper;

        public GeolocationController(IGeolocationService geolocationService, IMapper mapper)
        {
            _geolocationService = geolocationService;
            _mapper = mapper;
        }

        // GET: api/Geolocation
        [HttpGet]
        public async Task<IEnumerable<GeolocationResource>> GetGeolocationData()
        {
            var geolocationDatas = await _geolocationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<GeolocationData>, IEnumerable<GeolocationResource>>(geolocationDatas);

            return resources;
        }

        // GET: api/Geolocation/5
        [HttpGet("{ip}")]
        public async Task<IActionResult> GetGeolocationData([FromRoute] string IP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            var geolocationData = await _geolocationService.FindByIPAsync(IP);

            if (!_geolocationService.SpecificGeolocationDataExists(IP))
            {
                return NotFound();
            }

            return Ok(geolocationData);
        }

        // POST: api/Geolocation
        [HttpPost]
        public async Task<IActionResult> PostGeolocationData([FromBody] string IP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            var ipList = IP.Split(new char[] { ',' }).ToList();

            if (ipList.Count == 1)
            {
                var httpClient = new HttpClient();
                var URL = "http://api.ipstack.com/" + IP;
                var accessKey = "?access_key=496ee18883ec1c0ddfd853d6508abea1";

                var response = await httpClient.GetStringAsync(URL + accessKey);
                var geolocationResource = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveGeolocationResource>(response);
                var geolocationData = _mapper.Map<SaveGeolocationResource, GeolocationData>(geolocationResource);

                if (!_geolocationService.SpecificGeolocationDataExists(geolocationData.IP))
                {
                    var result = _geolocationService.SaveAsync(geolocationData);

                    if (!result.Result.Success)
                    {
                        return BadRequest(result.Result.Message);
                    }

                    var finalGeolocationResource = _mapper.Map<GeolocationData, GeolocationResource>(result.Result.GeolocationData);

                    return Ok(finalGeolocationResource);
                }
                else
                {
                    return Content("This IP exists in database");
                }
            }
            else if (ipList.Count > 1)
            {

                var listOfGeolocationData = new List<GeolocationData>();

                foreach (var ip in ipList)
                {
                    if (!_geolocationService.SpecificGeolocationDataExists(ip))
                    {
                        var httpClient = new HttpClient();
                        var URL = "http://api.ipstack.com/" + ip;
                        var accessKey = "?access_key=496ee18883ec1c0ddfd853d6508abea1";

                        var response = await httpClient.GetStringAsync(URL + accessKey);
                        var geolocationResource = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveGeolocationResource>(response);
                        var geolocationData = _mapper.Map<SaveGeolocationResource, GeolocationData>(geolocationResource);

                        listOfGeolocationData.Add(geolocationData);
                    }
                    else
                    {
                        return Content("This IP exist in database");
                    }
                }

                foreach (var geoData in listOfGeolocationData)
                {
                    var result = _geolocationService.SaveAsync(geoData);

                    if (!result.Result.Success)
                    {
                        return BadRequest(result.Result.Message);
                    }

                    var finalGeolocationResource = _mapper.Map<GeolocationData, GeolocationResource>(result.Result.GeolocationData);

                    return Ok(finalGeolocationResource);
                }
            }

            return Ok();
        }

        // DELETE: api/Geolocation/ip
        [HttpDelete("{ip}")]
        public async Task<IActionResult> DeleteGeolocationData([FromRoute] string IP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            var result = await _geolocationService.DeleteAsync(IP);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var geolocationResource = _mapper.Map<GeolocationData, GeolocationResource>(result.GeolocationData);

            return Ok(geolocationResource);
        }
    }
}