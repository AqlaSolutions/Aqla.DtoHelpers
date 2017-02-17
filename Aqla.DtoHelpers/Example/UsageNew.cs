namespace DtoHelpers.Example
{
    class UsageNew
    {
        void Usage(Container container)
        {
            // easy writing
            container.NewWritable.S.Nickname = "test";
            container.NewWritable.S.CharacterS.Level = 1;
            //example.NewReadOnly.S.Nickname = "test"; // not allowed, well
            //example.NewReadOnly.S = new DtoExamplePlayerNew();  // not allowed, well



            // class takes more GC time but only for writable
            {
                // it's obvious that it's a struct (no need to hover mouse)
                var something = container.NewWritable.S;
                var something2 = container.NewReadOnly.S;
                something2 = something; // obvious value copy
            }

            {
                var something = container.NewWritable;
                var something2 = something; // no .S - no value copy
                something2.S.Nickname = "test"; // so assigning source
            }

            {
                var something = container.NewReadOnly;
                //something.S.Nickname = "test"; // not allowed
            }

            //example.NewWritable = new DtoExamplePlayerNew(); // not allowed - would change ref
            container.NewWritable.S = new DtoExamplePlayerNew() { Nickname = "test" }; // can reassign all fields easily without changing ref
        }
    }
}