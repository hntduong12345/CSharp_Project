﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ITCenterBO.Models;
using System.Text.Json.Serialization;

namespace ITCenterBO.DTOs.Response.Order
{
    public class GetOrderResponse
    {
        public int OrderId { get; set; }
        public int AccountId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
