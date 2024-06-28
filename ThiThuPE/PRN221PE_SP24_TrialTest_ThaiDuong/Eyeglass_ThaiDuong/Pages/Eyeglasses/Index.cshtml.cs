using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BO;
using Repo;

namespace Eyeglass_ThaiDuong.Pages.Eyeglasses
{
    public class IndexModel : PageModel
    {
        private readonly IEyeglassesRepo _eyeglassesRepo;
        private readonly ILenTypeRepo _lenTypeRepo;

        public IndexModel(IEyeglassesRepo eyeglassesRepo, ILenTypeRepo lenTypeRepo)
        {
            _eyeglassesRepo = eyeglassesRepo;
            _lenTypeRepo = lenTypeRepo;
        }

        public IList<Eyeglass> Eyeglass { get; set; } = default!;

        //Seach
        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }

        //Paging
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 4;

        public int TotalPage => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public async Task OnGetAsync()
        {

            if (_eyeglassesRepo.GetAll() != null)
            {
                Eyeglass = _eyeglassesRepo.GetPaginate(CurrentPage, PageSize, SearchValue);
                if (string.IsNullOrEmpty(SearchValue))
                {
                    Count = _eyeglassesRepo.GetAll().Count();
                }
                else
                {
                    Count = _eyeglassesRepo.Seach(SearchValue).Count();
                }
            }
        }

        public async Task OnPostAsync()
        {
            Eyeglass = _eyeglassesRepo.GetPaginate(CurrentPage, PageSize, SearchValue);
            if (string.IsNullOrEmpty(SearchValue))
            {
                Count = _eyeglassesRepo.GetAll().Count();
            }
            else
            {
                Count = _eyeglassesRepo.Seach(SearchValue).Count();
            }
        }
    }
}
