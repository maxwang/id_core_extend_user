﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdCore.Models
{
    [Table("Companies")]
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string CompanyName { get; set; }

        [DefaultValue("GETDATE()")]
        [Required]
        //[Column(“BlogDescription", TypeName="ntext")]
        //[Column("CreatedTime")]
        public DateTime CreatedTime { get; set; }

        public string CreatedBy { get; set; }
    }
}
