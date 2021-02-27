using BTP.Test.JBP.BackEnd.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BTP.Test.JBP.BackEnd.Entities
{
    [DataContract]
    public class Students : BaseEntity
    {
        [MaxLength(60), Required]
        [DataMember]
        public string Name { get; set; }
        [Required]
        [DataMember]
        public DateTime BirthDate { get; set; }
        public ICollection<StudentAssignments> StudentAssignments { get; set; }

    }
}
