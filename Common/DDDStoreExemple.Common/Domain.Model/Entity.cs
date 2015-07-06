using System;

namespace DDDStoreExemple.Common.Domain.Model
{
	public abstract class Entity
	{
		public Guid Id { get; private set; }
		
		public Entity()
		{
			this.Id = Guid.NewGuid();
		}
	}
}