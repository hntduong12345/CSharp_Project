using BO.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net;
using System.Numerics;

namespace MilkData.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Role { get; set; } = null!;

    public int Point { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public Account(int accountId, string fullName, string email, string password, string phone, string address, string role, int point, bool isActive)
    {
        AccountId = accountId;
        FullName = fullName;
        Email = email;
        Password = password;
        Phone = phone;
        Address = address;
        Role = role;
        Point = point;
        IsActive = isActive;
    }
}
