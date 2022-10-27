using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ProjectContributor
    {
     
    public int IdProject { get; set; }
	public int IdUser { get; set; }
    public int Amount { get; set; }
	}
}
