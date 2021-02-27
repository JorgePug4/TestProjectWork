using BTP.Test.JBP.BackEnd.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BTP.Test.JBP.BackEnd.Entities
{
    public class StudentAssignments : BaseEntity
    {
        [ForeignKey("Assignments")]
        public int IDAssignments { get; set; }
        public Assignments Assignments { get; set; }
        [ForeignKey("Students")]
        public int IDStudent { get; set; }
        public Students Students { get; set; }

    }
}
