﻿using net._6_WebApp1.Models;

namespace net._6_WebApp1.Interfaces
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> GetAll();
        Task<Race> GetByIdAsyncNoTracking(int id);
        Task<Race> GetByIdAsync(int id);
        Task<IEnumerable<Race>> GetAllRacesByCity(string city);
        bool Add(Race race);
        bool Update(Race race);
        bool Delete(Race race);
        bool Save();
    }
}
