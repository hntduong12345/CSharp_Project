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
    public class DeleteModel : PageModel
    {
        private readonly IEyeglassesRepo _eyeglassesRepo;

        public DeleteModel(IEyeglassesRepo eyeglassesRepo)
        {
            _eyeglassesRepo = eyeglassesRepo;
        }

        [BindProperty]
      public Eyeglass Eyeglass { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _eyeglassesRepo.GetAll() == null)
            {
                return NotFound();
            }

            var eyeglass = _eyeglassesRepo.GetById((int)id);

            if (eyeglass == null)
            {
                return NotFound();
            }
            else 
            {
                Eyeglass = eyeglass;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _eyeglassesRepo.GetAll() == null)
            {
                return NotFound();
            }
            var eyeglass = _eyeglassesRepo.GetById((int)id);

            if (eyeglass != null)
            {
                _eyeglassesRepo.Delete((int)id);
            }

            return RedirectToPage("./Index");
        }
    }
}
