namespace DtoHelpers.Example
{
    class UsageClass
    {
        void Usage(Container container)
        {
            // easy writing
            container.ClassWritable.Nickname = "test";
            container.ClassWritable.Character.Level = 1;
            container.ClassReadOnly.Nickname = "test"; // STILL ALLOWED, have to make another class with copy-pasted members




            // class takes more GC time
            {
                
                var something = container.ClassWritable;
                var something2 = container.ClassReadOnly;
                something2 = something.Clone(); // value copy (requires clone implementation)
            }

            {
                var something = container.ClassWritable.Clone(); // value copy  (requires clone implementation)
                var something2 = something; // no .S - no value copy
                something2.Nickname = "test"; // so assigning source
            }

            {
                var something = container.ClassReadOnly;
                something.Nickname = "test"; // STILL ALLOWED, would require another class with get-only
            }

            //example.ClassWritable = new DtoExamplePlayerClass(); // not allowed - would change ref
            // CAN'T REASSIGN ALL FIELDS WITHOUT CHANGING REF (UNLESS ASSIGN IS IMPLEMENTED MANUALLY)
        }
    }
}