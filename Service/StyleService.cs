using BO.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class StyleService : IStyleService
    {
        private readonly IStyleRepository _styleRepository;
        public StyleService(IStyleRepository styleRepository)
        {
            _styleRepository = styleRepository;
        }

        public async Task<List<Style>> GetAllStyles()
        {
            return await _styleRepository.GetAllStyles();
        }
    }
}
