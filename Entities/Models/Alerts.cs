using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Alerts")]
    public class Alerts
    {
        [Key]
        public int AlertId { get; set; }
        public string AlertName { get; set; } = string.Empty;
        public string AlertType {  get; set; } = string.Empty;

        public int RiskScore { get; set; }

        public DateTime AlertTriggeredOn { get; set; }

    }
}
