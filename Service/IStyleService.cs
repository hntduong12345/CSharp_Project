using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IStyleService
    {
        public Task<List<Style>> GetAllStyles();
    }
}
