using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BO;
using Repo;

namespace Equipments_HuynhNguyenThaiDuong.Pages.Equipments
{
    public class IndexModel : PageModel
    {
        private readonly IEquipmentRepo _equipmentRepo;

        public IndexModel(IEquipmentRepo equipmentRepo)
        {
            _equipmentRepo = equipmentRepo;
        }

        public IList<Equipment> Equipment { get; set; } = default!;

        //Search
        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }

        //Paginate
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 5;

        public int TotalPage => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public async Task OnGetAsync()
        {
            if (_equipmentRepo.GetAll != null)
            {
                Equipment = _equipmentRepo.GetPaginate(CurrentPage, PageSize, SearchValue);
                if (string.IsNullOrEmpty(SearchValue))
                {
                    Count = _equipmentRepo.GetAll().Count;
                }
                else
                {
                    Count = _equipmentRepo.Seach(SearchValue).Count;
                }
            }
        }
                
        public async Task OnPostAsync()
        {
            Equipment = _equipmentRepo.GetPaginate(CurrentPage, PageSize, SearchValue);
            if (string.IsNullOrEmpty(SearchValue))
            {
                Count = _equipmentRepo.GetAll().Count;
            }
            else
            {
                Count = _equipmentRepo.Seach(SearchValue).Count;
            }
        }
    }
}
