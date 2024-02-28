using Dapper;
using Dryva.Maps.DTOs;
using Dryva.Maps.Helpers;
using Dryva.Maps.Models;
using Dryva.Maps.Repositories.Commands;
using Dryva.Utitlties.Sql;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Maps.Repositories.Queries
{
    /// <summary>
    /// Class MapQueryRepository.
    /// Implements the <see cref="Dryva.Maps.Repositories.Queries.IMapQueryRepository" />
    /// </summary>
    /// <seealso cref="Dryva.Maps.Repositories.Queries.IMapQueryRepository" />
    public class MapQueryRepository : IMapQueryRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly MapsDbContext dbContext;
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string connectionString;
        /// <summary>
        /// Initializes a new instance of the <see cref="MapQueryRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// 

        private readonly ILogger<MapQueryRepository> _logger;
        public MapQueryRepository(MapsDbContext dbContext, ILogger<MapQueryRepository> logger)
        {
            this.dbContext = dbContext;
            this.connectionString = Startup.ConnectionString;
            _logger = logger;
        }

        /// <summary>
        /// Gets the map axises.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IEnumerable&lt;MapAxisDTO&gt;&gt;.</returns>
        public async Task<IEnumerable<MapAxisDTO>> GetMapAxises(int pageIndex = 1, int pageSize = 100)
        {
            _logger.LogInformation("Called into GetMapAxises Handler");
            int startRow = (pageIndex - 1) * pageSize;
            if (startRow < 0)
                startRow = 0;

            int rowCount = pageSize;
            string paginationQuery = $" Order by [CreatedBy] OFFSET {startRow} ROWS FETCH NEXT {rowCount} ROWS ONLY";
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();
                var builder = dbContext.Select<MapAxis, MapAxisDTO>(d => new
                {
                    d.Id,
                    d.Name,
                    d.ParentCode,
                    d.Description,
                    d.Longitude,
                    d.Latitude,
                    d.Zoom
                });
                var models = await connection.QueryAsync<MapAxisDTO>($"{builder.Query} {paginationQuery}");
                return models;
            }
        }

        public async Task<IEnumerable<MapAxisDTO>> GetAll()
        {
            _logger.LogInformation("Called into GetAll Maps Handler");

            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();
                var builder = dbContext.Select<MapAxis, MapAxisDTO>(d => new
                {
                    d.Id,
                    d.Name,
                    d.ParentCode,
                    d.Description,
                    d.Longitude,
                    d.Latitude,
                    d.Zoom
                });
                var models = await connection.QueryAsync<MapAxisDTO>(builder.Query);
                return models;
            }
        }

        //public IPagedList<Company> GetPages(int pageIndex = 1, int pageSize = 25)
        //{
        //    using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
        //    {
        //        if (db.State == ConnectionState.Closed)
        //            db.Open();
        //        var query = db.QueryMultiple("SELECT COUNT(*) FROM Company;SELECT* FROM Company ORDER BY Id OFFSET ((@PageNumber - 1) * @Rows) ROWS FETCH NEXT @Rows ROWS ONLY", new { PageNumber = pageIndex, Rows = pageSize }, commandType: CommandType.Text);
        //        var row = query.Read<int>().First();
        //        var pageResult = query.Read<Company>().ToList();
        //        return new StaticPagedList<Company>(pageResult, pageIndex, pageSize, row);
        //    }
        //}

        /// <summary>
        /// Gets the map axis by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;MapAxisDTO&gt;.</returns>
        public async Task<MapAxisDTO> GetMapAxisById(Guid id)
        {
            _logger.LogInformation("Called into GetMapAxisById Handler");

            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();
                var builder = dbContext.Select<MapAxis, MapAxisDTO>(d => new
                {
                    d.Id,
                    d.Name,
                    d.ParentCode,
                    d.Description,
                    d.Longitude,
                    d.Latitude,
                    d.Zoom
                }).Where(d => d.Id == id);
                var model = await connection.QuerySingleOrDefaultAsync<MapAxisDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }

        /// <summary>
        /// Gets the closest map axis by location.
        /// </summary>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <returns>Task&lt;MapAxisDTO&gt;.</returns>
        public async Task<MapAxisDTO> GetClosestMapAxisByLocation(float longitude, float latitude)
        {
            _logger.LogInformation("Called into GetClosestMapAxisByLocation Handler");

            MapAxisDTO closestMapAxis = null;
            var maps = await this.GetAll();
            double minDistance = double.PositiveInfinity;
            foreach (var item in maps)
            {
                var dis = await Task.Run(() => this.DistanceTo(longitude, latitude, item.Longitude, item.Latitude));
                if (dis < minDistance)
                {
                    minDistance = dis;
                    closestMapAxis = item;
                }
            }

            return closestMapAxis;
        }

        public double DistanceTo(double customerLongitude, double customerLatitude,
                double mapAxisLongitude, double mapAxisLatitude)
        {
            // Angle in radians along great circle.
            double radians = Math.Acos(
            Math.Sin(ToRadian(customerLatitude)) * Math.Sin(ToRadian(mapAxisLatitude)) +
            Math.Cos(ToRadian(customerLatitude)) * Math.Cos(ToRadian(mapAxisLatitude)) *
            Math.Cos(ToRadian(customerLongitude - mapAxisLongitude)));

            return radians;
        }

        private double ToRadian(double angle)
        {
            return Math.PI * angle / 180;
        }

    }
}
