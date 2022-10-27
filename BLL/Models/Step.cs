using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Step
    {
        public int Id { get; set; }
        public int IdProject { get; set; }
        public int Amount { get; set; }
        public string Reward { get; set; }
    }
}
