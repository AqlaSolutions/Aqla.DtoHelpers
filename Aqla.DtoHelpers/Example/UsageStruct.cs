namespace DtoHelpers.Example
{
    class UsageStruct
    {
        void Usage(Container container)
        {
            // hard writing
            var v = container.StructWritable;
            v.Nickname = "test";
            var c = v.Character;
            c.Level = 1;
            v.Character = c;
            container.StructWritable = v;
            //example.StructReadOnly = v; // NOT ALLOWED
            
            {
                // it's NOT obvious that it's a struct (can still use variable naming like "something_")
                var something = container.StructWritable;
                var something2 = container.StructReadOnly;
                something2 = something; // NOT obvious value copy
            }

            {
                var something = container.StructWritable;
                var something2 = something; // NOT obvious value copy
                something2.Nickname = "test"; // CAN'T ASSIGN TO SOURCE BY REF
            }

            {
                var something = container.StructReadOnly;
                something.Nickname = "test"; // ALLOWED - NOT OBVIOUS THAT IT WON'T CHANGE container.StructReadOnly
            }

            container.StructWritable = new DtoExamplePlayerStruct(); // allowed
            container.StructWritable = new DtoExamplePlayerStruct() { Nickname = "test" }; // can reassign all fields easily
        }
    }
}