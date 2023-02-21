namespace Mark01.Core.ValueObjects
{
    public class PersonType : ValueObjects
    {
        public PersonType()
        {

        }
        public PersonType(string type)
        {
            Type = type;
        }

        public string Type { get; private set; }
    }
}
