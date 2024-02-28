using Dapper;
using Dryva.Enrollment.DTOs.CaptureSession;
using Dryva.Enrollment.Models;
using Dryva.Enrollment.Repositories.Commands;
using Dryva.Utitlties.Sql;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Queries
{
    public class CaptureSessionQueryRepository : ICaptureSessionQueryRepository
    {
        private readonly string connectionString;
        private readonly EnrollmentDbContext context;

        public CaptureSessionQueryRepository(EnrollmentDbContext context)
        {
            connectionString = Startup.ConnectionString;
            this.context = context;
        }

        public async Task<IEnumerable<CaptureSessionDTO>> GetCaptureSessions()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<CaptureSession, CaptureSessionDTO>(d => new
                {
                    d.Id,
                    d.CreatedBy,
                    d.CreatedOn,
                    d.DataType
                });

                var model = await connection.QueryAsync<CaptureSessionDTO>(builder.Query);
                return model;
            }
        }

        public async Task<CaptureSessionDTO> GetCaptureSession(Guid id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<CaptureSession, CaptureSessionDTO>(d => new
                {
                    d.Id,
                    d.CreatedBy,
                    d.CreatedOn,
                    d.DataType
                }).Where(d => d.Id == id);

                var model = await connection.QuerySingleOrDefaultAsync<CaptureSessionDTO>(builder.Query);
                return model;
            }
        }
    }
}
