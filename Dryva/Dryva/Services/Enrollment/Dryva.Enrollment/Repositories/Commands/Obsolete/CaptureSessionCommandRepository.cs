using AutoMapper;
using Dryva.Enrollment.DTOs.CaptureSession;
using Dryva.Enrollment.Models;
using Dryva.Utitlties.Sql;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Commands
{
    public class CaptureSessionCommandRepository : ICaptureSessionCommandRepository
    {
        private readonly EnrollmentDbContext context;
        private readonly IMapper mapper;
        private readonly string connectionString;

        public CaptureSessionCommandRepository(EnrollmentDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            connectionString = Startup.ConnectionString;
        }

        public async Task<int> Insert(CaptureSessionDTO captureSessionDTO)
        {
            var deleteSql = context.Delete<CaptureSession, CaptureSessionDTO>()
                .Where(d => d.Id == captureSessionDTO.Id && d.CreatedBy == captureSessionDTO.CreatedBy);

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand(deleteSql.Query, connection);
                command.Parameters.AddWithValue(nameof(captureSessionDTO.Id), deleteSql.Parameters.Id);
                command.Parameters.AddWithValue(nameof(captureSessionDTO.CreatedBy), deleteSql.Parameters.CreatedBy);

                command.ExecuteNonQuery();
            }

            var captureSession = mapper.Map<CaptureSession>(captureSessionDTO);
            context.CaptureSessions.Add(captureSession);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Update(UpdatePhotographSessionDTO captureSessionDTO)
        {
            var captureSession = new CaptureSession { Id = captureSessionDTO.Id };

            context.Attach(captureSession);
            captureSession.Photograph = captureSessionDTO.Photograph;
            return await context.SaveChangesAsync();
        }

        public async Task<int> Update(UpdateFingerprintsSessionDTO updateFingerprintsDTO)
        {
            var captureSession = new CaptureSession { Id = updateFingerprintsDTO.Id };

            context.Attach(captureSession);
            mapper.Map(updateFingerprintsDTO, captureSession);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid id)
        {
            var captureSession = new CaptureSession { Id = id };

            context.Attach(captureSession);
            context.Remove(captureSession);
            return await context.SaveChangesAsync();
        }
    }
}
