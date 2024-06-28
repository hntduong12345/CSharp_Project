using System;
using System.Collections.Generic;

namespace BookManagement_HuynhNguyenThaiDuong.Repo.Models
{
    public partial class BookManagementMember
    {
        public int MemberId { get; set; }
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public int MemberRole { get; set; }
    }
}
