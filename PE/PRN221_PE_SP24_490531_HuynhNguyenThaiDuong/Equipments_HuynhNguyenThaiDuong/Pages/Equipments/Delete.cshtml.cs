using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BO;
using Repo;

namespace Equipments_HuynhNguyenThaiDuong.Pages.Equipments
{
    public class DeleteModel : PageModel
    {
        private readonly IEquipmentRepo _equipmentRepo;

        public DeleteModel(IEquipmentRepo equipmentRepo)
        {
            _equipmentRepo = equipmentRepo;
        }

        [BindProperty]
      public Equipment Equipment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _equipmentRepo.GetAll() == null)
            {
                return NotFound();
            }

            var equipment = _equipmentRepo.GetById((int)id);

            if (equipment == null)
            {
                return NotFound();
            }
            else 
            {
                Equipment = equipment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _equipmentRepo.GetAll() == null)
            {
                return NotFound();
            }
            var equipment = _equipmentRepo.GetById((int)id);

            if (equipment != null)
            {
                Equipment = equipment;
                _equipmentRepo.Delete((int)id);
            }

            return RedirectToPage("./Index");
        }
    }
}
