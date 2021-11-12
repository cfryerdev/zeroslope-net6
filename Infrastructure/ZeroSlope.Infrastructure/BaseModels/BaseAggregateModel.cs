using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZeroSlope.Infrastructure.BaseModels
{
	public abstract class BaseAggregateModel
	{
		public virtual Guid Id { get; set; }
	}
}
