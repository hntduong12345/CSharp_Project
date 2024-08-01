using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.Models
{
    [DataContract]
    public class Blog
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public int BlogCategoryId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string DocUrl { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}