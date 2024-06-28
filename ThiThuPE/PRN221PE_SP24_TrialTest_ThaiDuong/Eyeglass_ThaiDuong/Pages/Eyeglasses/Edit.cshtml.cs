using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BO;
using Repo;

namespace Eyeglass_ThaiDuong.Pages.Eyeglasses
{
    public class EditModel : PageModel
    {
        private readonly IEyeglassesRepo _eyeglassesRepo;
        private readonly ILenTypeRepo _lenTypeRepo;

        public EditModel(IEyeglassesRepo eyeglassesRepo, ILenTypeRepo lenTypeRepo)
        {
            _eyeglassesRepo = eyeglassesRepo;
            _lenTypeRepo = lenTypeRepo;
        }

        [BindProperty]
        public Eyeglass Eyeglass { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _eyeglassesRepo.GetAll() == null)
            {
                return NotFound();
            }

            var eyeglass =  _eyeglassesRepo.GetById((int)id);
            if (eyeglass == null)
            {
                return NotFound();
            }
            Eyeglass = eyeglass;
           ViewData["LensTypeId"] = new SelectList(_lenTypeRepo.GetAllLens(), "LensTypeId", "LensTypeName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _eyeglassesRepo.Update(Eyeglass);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EyeglassExists(Eyeglass.EyeglassesId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EyeglassExists(int id)
        {
          return _eyeglassesRepo.GetById((int)id) != null;
        }
    }
}
