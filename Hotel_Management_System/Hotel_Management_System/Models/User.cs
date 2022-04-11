using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.ComponentModel;
namespace Hotel_Management_System.Models
{
    public class User
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public int UserId { get; set; }
        [DataMember]   
        public string WorkDomain { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataMember]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}