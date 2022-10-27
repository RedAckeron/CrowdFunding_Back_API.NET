using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ToolBox.utils;

namespace BLL.Models
{
    public class Project
    {
		public int Id { get; set; }
		public int IdOwner { get; set; }
		public string Title { get; set; }
		public string Description { get; set; } = string.Empty;
		public int Goal { get; set; }
		//[JsonConverter(typeof(DateOnlyJsonConverter))]
		public DateTime BeginDate { get; set; }
		//[JsonConverter(typeof(DateOnlyJsonConverter))]
		public DateTime EndDate { get; set; }
		//public int IdUser { get; set; }
		public bool IsValidate { get; set; }
		public IEnumerable<Step> Steps { get; set; }
	}
}
