using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLLM = BLL.Models;
using DALM = DAL.Models;

namespace BLL.Mappers
{
    public static class PaliersMapper
    {
        //Mapper des paliers
        public static DALM.Paliers toDalPallier(this BLLM.Paliers paliers)
        {
            return new DALM.Paliers
            {
                Id = paliers.Id,
                Title = paliers.Title,
                Montant = paliers.Montant,
                Description = paliers.Description,
                IdProject = paliers.IdProject

            };

        }

        public static BLLM.Paliers toBllPallier(this DALM.Paliers paliers)
        {
            return new BLLM.Paliers
            {
                Id = paliers.Id,
                Title = paliers.Title,
                Montant = paliers.Montant,
                Description = paliers.Description,
                IdProject = paliers.IdProject

            };

        }

    }
}
