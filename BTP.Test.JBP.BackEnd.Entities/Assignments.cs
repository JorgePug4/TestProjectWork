using BTP.Test.JBP.BackEnd.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace BTP.Test.JBP.BackEnd.Entities
{
    [DataContract]
    public class Assignments : BaseEntity
    {
        [DataMember]
        [MaxLength(60), Required]
        public string Name { get; set; }
        public ICollection<StudentAssignments> StudentAssignments { get; set; }
    }
}
