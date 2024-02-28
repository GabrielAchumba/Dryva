using Dapper;
using Dryva.Enrollment.DTOs.Driver;
using Dryva.Enrollment.Helpers;
using Dryva.Enrollment.Models;
using Dryva.Enrollment.Repositories.Commands;
using Dryva.Utitlties.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Queries
{
    /// <summary>
    /// Class DriverQueryRepository.
    /// Implements the <see cref="Dryva.Enrollment.Repositories.Queries.IDriverQueryRepository" />
    /// </summary>
    /// <seealso cref="Dryva.Enrollment.Repositories.Queries.IDriverQueryRepository" />
    public class DriverQueryRepository : IDriverQueryRepository
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string connectionString;
        /// <summary>
        /// The context
        /// </summary>
        private readonly EnrollmentDbContext context;
        /// <summary>
        /// Initializes a new instance of the <see cref="DriverQueryRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public DriverQueryRepository(EnrollmentDbContext context)
        {
            connectionString = Startup.ConnectionString;
            this.context = context;
        }

        /// <summary>
        /// Gets the drivers.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IEnumerable&lt;DriverDetailDTO&gt;&gt;.</returns>
        public async Task<IEnumerable<DriverDetailDTO>> GetDrivers(int pageIndex = 1, int pageSize = 100)
        {
            int startRow = (pageIndex - 1) * pageSize;
            if (startRow < 0)
                startRow = 0;

            int rowCount = pageSize;
            string paginationQuery = $" Order by [CreatedBy] OFFSET {startRow} ROWS FETCH NEXT {rowCount} ROWS ONLY";


            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Driver, DriverDetailDTO>(d => new
                {
                    d.Id,
                    d.Title,
                    d.Surname,
                    d.FirstName,
                    d.OtherName,
                    d.Address,
                    d.PhoneNumber,
                    d.Email,
                    d.BirthDate,
                    d.Csn,
                    d.Gender,
                    d.Photograph
                });
                var model = await connection.QueryAsync<DriverDetailDTO>($"{builder.Query} {paginationQuery}");
                return model;
            }
        }

        /// <summary>
        /// Gets the driver by identifier.
        /// </summary>
        /// <param name="id">The driver identifier.</param>
        /// <returns>Task&lt;DriverDataDTO&gt;.</returns>
        public async Task<DriverDataDTO> GetDriverById(Guid id)
        {
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Driver, DriverDataDTO>(d => new
                {
                    d.Id,
                    d.Address,
                    d.BirthDate,
                    d.BloodGroup,
                    d.Country,
                    d.Csn,
                    d.Email,
                    d.FirstName,
                    d.Gender,
                    d.Genotype,
                    d.LeftIndexImage,
                    d.LeftIndexMinutia,
                    d.LeftThumbImage,
                    d.LeftThumbMinutia,
                    d.LGAOfOrigin,
                    d.MaritalStatus,
                    d.OtherName,
                    d.PhoneNumber,
                    d.Photograph,
                    d.ResidentialCity,
                    d.ResidentialState,
                    d.RightIndexImage,
                    d.RightIndexMinutia,
                    d.RightThumbImage,
                    d.RightThumbMinutia,
                    d.Signature,
                    d.StateOfOrigin,
                    d.Surname,
                    d.Title,
                    d.IsOwner,
                    d.OwnerAddress,
                    d.OwnerEmail,
                    d.OwnerFirstName,
                    d.OwnerPhoneNumber,
                    d.OwnerSurname,
                    d.NOKAddress,
                    d.NOKNames,
                    d.NOKPhoneNumber,
                    d.NOKRelationship,
                    d.MakeAndModel,
                    d.ChassisNumber,
                    d.EngineNumber,
                    d.PlateNumber
                }).Where(d => d.Id == id);
                var model = await connection.QuerySingleOrDefaultAsync<DriverDataDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }



        /// <summary>
        /// Gets the Driver by phone number.
        /// </summary>
        /// <param name="phoneNumber">The Driver phone number.</param>
        /// <returns>Task&lt;DriverDataDTO&gt;.</returns>
        public async Task<DriverDataDTO> GetDriverByPhoneNumber(string phoneNumber)
        {
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Driver, DriverDataDTO>(d => new
                {
                    d.Id,
                    d.Address,
                    d.BirthDate,
                    d.BloodGroup,
                    d.Country,
                    d.Csn,
                    d.Email,
                    d.FirstName,
                    d.Gender,
                    d.Genotype,
                    d.LeftIndexImage,
                    d.LeftIndexMinutia,
                    d.LeftThumbImage,
                    d.LeftThumbMinutia,
                    d.LGAOfOrigin,
                    d.MaritalStatus,
                    d.OtherName,
                    d.PhoneNumber,
                    d.Photograph,
                    d.ResidentialCity,
                    d.ResidentialState,
                    d.RightIndexImage,
                    d.RightIndexMinutia,
                    d.RightThumbImage,
                    d.RightThumbMinutia,
                    d.Signature,
                    d.StateOfOrigin,
                    d.Surname,
                    d.Title,
                    d.IsOwner,
                    d.OwnerAddress,
                    d.OwnerEmail,
                    d.OwnerFirstName,
                    d.OwnerPhoneNumber,
                    d.OwnerSurname,
                    d.NOKAddress,
                    d.NOKNames,
                    d.NOKPhoneNumber,
                    d.NOKRelationship,
                    d.MakeAndModel,
                    d.ChassisNumber,
                    d.EngineNumber,
                    d.PlateNumber
                }).Where(d => d.PhoneNumber == phoneNumber);
                var model = await connection.QuerySingleOrDefaultAsync<DriverDataDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }



        /// <summary>
        /// Gets the Driver by plate number.
        /// </summary>
        /// <param name="plateNumber">The Driver plate number.</param>
        /// <returns>Task&lt;DriverDataDTO&gt;.</returns>
        public async Task<DriverDataDTO> GetDriverByPlateNumber(string plateNumber)
        {
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Driver, DriverDataDTO>(d => new
                {
                    d.Id,
                    d.Address,
                    d.BirthDate,
                    d.BloodGroup,
                    d.Country,
                    d.Csn,
                    d.Email,
                    d.FirstName,
                    d.Gender,
                    d.Genotype,
                    d.LeftIndexImage,
                    d.LeftIndexMinutia,
                    d.LeftThumbImage,
                    d.LeftThumbMinutia,
                    d.LGAOfOrigin,
                    d.MaritalStatus,
                    d.OtherName,
                    d.PhoneNumber,
                    d.Photograph,
                    d.ResidentialCity,
                    d.ResidentialState,
                    d.RightIndexImage,
                    d.RightIndexMinutia,
                    d.RightThumbImage,
                    d.RightThumbMinutia,
                    d.Signature,
                    d.StateOfOrigin,
                    d.Surname,
                    d.Title,
                    d.IsOwner,
                    d.OwnerAddress,
                    d.OwnerEmail,
                    d.OwnerFirstName,
                    d.OwnerPhoneNumber,
                    d.OwnerSurname,
                    d.NOKAddress,
                    d.NOKNames,
                    d.NOKPhoneNumber,
                    d.NOKRelationship,
                    d.MakeAndModel,
                    d.ChassisNumber,
                    d.EngineNumber,
                    d.PlateNumber
                }).Where(d => d.PlateNumber == plateNumber);
                var model = await connection.QuerySingleOrDefaultAsync<DriverDataDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }



        /// <summary>
        /// Gets the Driver registration by phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Task&lt;DriverRegistrationDTO&gt;.</returns>
        public async Task<DriverRegistrationDTO> GetDriverRegistrationByPhoneNumber(string phoneNumber)
        {
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Driver, DriverRegistrationDTO>(d => new
                {
                    d.Id,
                    d.Csn,
                    d.FirstName,
                    d.Gender,
                    d.OtherName,
                    d.PhoneNumber,
                    d.Surname,
                    d.Title
                }).Where(d => d.PhoneNumber == phoneNumber);
                var model = await connection.QuerySingleOrDefaultAsync<DriverRegistrationDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }


    }
}
