using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ZeroSlope.Infrastructure.BaseModels;

namespace ZeroSlope.Domain.Entities
{
	[Table("SampleEntity")]
	public class SampleEntity : BaseEntityModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
