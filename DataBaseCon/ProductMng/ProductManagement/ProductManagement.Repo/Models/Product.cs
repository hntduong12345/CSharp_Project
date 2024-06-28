using System;
using System.Collections.Generic;

namespace ProductManagement.Repo.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public int? CatId { get; set; }

    public virtual Category? Cat { get; set; }
}
