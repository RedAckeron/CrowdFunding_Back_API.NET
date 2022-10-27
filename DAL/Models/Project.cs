using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Project
    {
	public int Id { get; set; }
	public int IdOwner { get; set; }
	public string Title { get; set; }
	public string Description { get; set; } = string.Empty;
	public int Goal { get; set; }
	public DateTime BeginDate { get; set; }
	public DateTime EndDate { get; set; }
	//public int IdUser { get; set; }
	public bool IsValidate { get; set; }
    }
}
