using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalcCodingChallenge.Models
{
    public class CalcHistory
    {
        [Key]
        public int CalcHistoryId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string CalcText { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string CalcTextAnswer { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string SourceIPAddress { get; set; }
    }
}
