using System;

namespace DDDStoreExemple.Common.Domain.Model
{
    public class Address : ValueObject
    {
        public Guid Id { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public bool IsDeliveryAddress { get; private set; }

        public Address(string zipcode, string street, string city, string state)
        {
            this.Id = Guid.NewGuid();
            this.Street = street;
            this.City = city;
            this.State = state;
        }

        public void FlagAsDeliveryAddress()
        {
            this.IsDeliveryAddress = true;
        }

        public void UnFlagAsDeliveryAddress()
        {
            this.IsDeliveryAddress = false;
        }
    }
}