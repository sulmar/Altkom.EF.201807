namespace Altkom.EF.Shop.Models
{

    // Complex Type (ponieważ nie ma ID)
    public class Address : Base
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string BuildingNumber { get; set; }
    }
}
