using System;
using System.Collections.Generic;

namespace EntityFrameworkTest1.Models;

public partial class Lop
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
