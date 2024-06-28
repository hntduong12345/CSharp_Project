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

namespace Equipments_HuynhNguyenThaiDuong.Pages.Equipments
{
    public class EditModel : PageModel
    {
        private readonly IEquipmentRepo _equipmentRepo;
        private readonly IRoomRepo _roomRepo;

        public EditModel(IEquipmentRepo equipmentRepo, IRoomRepo roomRepo)
        {
            _equipmentRepo = equipmentRepo;
            _roomRepo = roomRepo;   
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
            Equipment = equipment;
           ViewData["RoomId"] = new SelectList(_roomRepo.GetAllRooms(), "RoomId", "RoomName");
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
                Equipment.UpdatedAt = DateTime.Now;
               _equipmentRepo.Equals(Equipment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentExists(Equipment.EqId))
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

        private bool EquipmentExists(int id)
        {
          return _equipmentRepo.GetById((int) id) != null;
        }
    }
}
