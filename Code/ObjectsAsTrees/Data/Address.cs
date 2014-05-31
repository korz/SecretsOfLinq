using System.Text;

namespace ObjectsAsTrees.Data
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(this.Street);

            stringBuilder.Append(this.City);
            stringBuilder.Append(", ");
            stringBuilder.Append(this.State);
            stringBuilder.Append(" ");
            stringBuilder.Append(this.Zip);
            stringBuilder.Append(" ");

            return stringBuilder.ToString();
        }
    }
}
