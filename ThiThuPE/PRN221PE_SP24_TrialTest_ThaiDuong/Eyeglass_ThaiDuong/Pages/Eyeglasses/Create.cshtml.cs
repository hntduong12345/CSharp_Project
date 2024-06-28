using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BO;
using Repo;

namespace Eyeglass_ThaiDuong.Pages.Eyeglasses
{
    public class CreateModel : PageModel
    {
        private readonly IEyeglassesRepo _eyeglassesRepo;
        private readonly ILenTypeRepo _lenTypeRepo;

        public CreateModel(IEyeglassesRepo eyeglassesRepo, ILenTypeRepo lenTypeRepo)
        {
            _eyeglassesRepo = eyeglassesRepo;
            _lenTypeRepo = lenTypeRepo;
        }

        public IActionResult OnGet()
        {
            ViewData["LensTypeId"] = new SelectList(_lenTypeRepo.GetAllLens(), "LensTypeId", "LensTypeName");
            return Page();
        }

        [BindProperty]
        public Eyeglass Eyeglass { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _eyeglassesRepo.GetAll() == null || Eyeglass == null)
            {
                return Page();
            }
            Eyeglass.CreatedDate = DateTime.Now;

            _eyeglassesRepo.Add(Eyeglass);

            return RedirectToPage("./Index");
        }
    }
}
