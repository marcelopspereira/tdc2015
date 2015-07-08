using System;

namespace Store.Common.Domain.Model
{
	public abstract class Entity
	{
		public Guid Id { get; protected set; }
		
		public Entity(Guid id)
		{
			this.Id = id;
		}
	}
}