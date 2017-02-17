using Aqla.DtoHelpers;

namespace DtoHelpers.Example
{
    struct DtoExamplePlayerNew
    {
        public string Nickname { get; set; }
        public Ref<DtoExampleCharacterNew> Character { get; } // = new Ref<DtoExampleCharacterNew>(); can't initialize here!
        // so have to handle null or use extension method!
    }

    struct DtoExampleCharacterNew
    {
        public int Level { get; set; }
    }

    struct DtoExamplePlayerStruct
    {
        public string Nickname { get; set; }
        public DtoExampleCharacterStruct Character { get; set; }
    }

    struct DtoExampleCharacterStruct
    {
        public int Level { get; set; }
    }

    // this is only read-write version!
    class DtoExamplePlayerClass
    {
        public string Nickname { get; set; }
        public DtoExampleCharacterClass Character { get; set; }

        public DtoExamplePlayerClass Clone()
        {
            var c = Character.Clone();
            var me = (DtoExamplePlayerClass)MemberwiseClone();
            me.Character = c;
            return me;
        }
    }

    class DtoExampleCharacterClass
    {
        public int Level { get; set; }

        public DtoExampleCharacterClass Clone()
        {
            return (DtoExampleCharacterClass)MemberwiseClone();
        }
    }

    // and here we have to copy-paste for read-only version of class
}