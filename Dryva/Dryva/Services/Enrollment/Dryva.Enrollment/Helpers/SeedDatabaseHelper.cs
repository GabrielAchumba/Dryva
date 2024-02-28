using Dryva.Enrollment.Models;
using Dryva.Enrollment.Repositories.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Helpers
{
    public class SeedDatabaseHelper
    {
        public static void SeedDB(IApplicationBuilder applicationBuilder, IWebHostEnvironment env)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
               .CreateScope())
            {
                EnrollmentDbContext dbContext = serviceScope.ServiceProvider.GetService<EnrollmentDbContext>();
                string relativeFilePath = $"{env.ContentRootPath}\\Files\\State_Lga.txt";
                //////string relativeFilePath = Path.Combine("Files", "State_Lga.txt");

                if (dbContext.States.Any())
                    return;

                Dictionary<string, State> _statesDic = new Dictionary<string, State>();
                using (FileStream _fileStream = new FileStream(relativeFilePath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(_fileStream))
                    {
                        string line = string.Empty;
                        while ((line = reader.ReadLine()) != null)
                        {
                            List<string> data = line.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                            var _lga = data[0].Trim();
                            var _state = data[1].Trim();
                            if (!_statesDic.ContainsKey(_state))
                            {
                                _statesDic.Add(_state, new State() { Name = _state });
                                dbContext.Add(_statesDic[_state]);
                            }
                            var lgaModel = new Lga() { Name = _lga, StateId = _statesDic[_state].Id, StateName = _statesDic[_state].Name };
                            dbContext.Add(lgaModel);
                        }


                    }
                }
                dbContext.SaveChanges();
            }
        }

    }
}
