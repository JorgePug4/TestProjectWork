using BTP.Test.JBP.BackEnd.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BTP.Test.JBP.BackEnd.Entities.Bases
{
    public class BaseEntity : IEntity
    {
        public int ID { get; set; }
    }
}
