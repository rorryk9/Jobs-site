using Jobssait.Models;
using Jobssait.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobssait.Services
{
    public class ApplyenceService
    {
        private UserDBContext dbContext;

        public ApplyenceService(UserDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ApplyenceDTO> GetAll()
        {

            return dbContext.Applyence
                .Include(a => a.User)
                .Select(a => ToDto(a))
                .ToList();
        }

        private static ApplyenceDTO ToDto(Applyence a)
        {
            ApplyenceDTO applyence = new ApplyenceDTO();

            applyence.Id = a.Id;
            applyence.Name = a.Name;
            applyence.Content = a.Content;
            applyence.CreatedBy = $"{a.User.Userusername}";
            applyence.UserEmail = a.User.Email;

            return applyence;
        }
    }
}
