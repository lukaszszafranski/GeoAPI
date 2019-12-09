using GeolocationAPI.Models;
using GeolocationAPI.Repositories;
using GeolocationAPI.Repositories.Domain;
using GeolocationAPI.Resources;
using GeolocationAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolocationAPI.Services
{
    public class GeolocationService : IGeolocationService
    {
        private readonly IGeolocationRepository _geolocationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GeolocationService(IGeolocationRepository geolocationRepository, IUnitOfWork unitOfWork)
        {
            _geolocationRepository = geolocationRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<GeolocationData>> ListAsync()
        {
            return await _geolocationRepository.ListAsync();
        }
        public async Task<GeolocationResponse> SaveAsync(GeolocationData geolocationData)
        {
            try
            {
                await _geolocationRepository.AddAsync(geolocationData);
                await _unitOfWork.CompleteAsync();

                return new GeolocationResponse(geolocationData);
            }
            catch (Exception ex)
            {
                return new GeolocationResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
        public async Task<GeolocationData> FindByIPAsync(string IP)
        {
            return await _geolocationRepository.FindByIPAsync(IP);
        }
        public async Task<GeolocationResponse> DeleteAsync (string IP)
        {
            var existingGeolocationData = await _geolocationRepository.FindByIPAsync(IP);

            if (existingGeolocationData == null)
            {
                return new GeolocationResponse("IP not found");
            }

            try
            {
                _geolocationRepository.Remove(existingGeolocationData);
                await _unitOfWork.CompleteAsync();

                return new GeolocationResponse(existingGeolocationData);
            }
            catch (Exception ex)
            {
                return new GeolocationResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
        public bool IsDbEmpty()
        {
            return _geolocationRepository.IsDbEmpty();
        }
        public bool SpecificGeolocationDataExists(string IP)
        {
            return _geolocationRepository.SpecificGeolocationDataExists(IP);
        }
    }
}
