using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BO;
using Repo;

namespace Equipments_HuynhNguyenThaiDuong.Pages.Equipments
{
    public class CreateModel : PageModel
    {
        private readonly IEquipmentRepo _equipmentRepo;
        private readonly IRoomRepo _roomRepo;

        public CreateModel(IEquipmentRepo equipmentRepo, IRoomRepo roomRepo)
        {
            _equipmentRepo = equipmentRepo;
            _roomRepo = roomRepo;
        }

        public IActionResult OnGet()
        {
            ViewData["RoomId"] = new SelectList(_roomRepo.GetAllRooms(), "RoomId", "RoomName");
            return Page();
        }

        [BindProperty]
        public Equipment Equipment { get; set; } = default!;

        public string ErrorMsg = string.Empty;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _equipmentRepo.GetAll() == null || Equipment == null)
            {
                return Page();
            }

            Equipment.CreatedAt = DateTime.Now;
            Equipment.UpdatedAt = DateTime.Now;
            bool result = _equipmentRepo.Create(Equipment);

            return RedirectToPage("./Index");
        }
    }
}
