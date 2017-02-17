using Aqla.DtoHelpers;

namespace DtoHelpers.Example
{
    class Container
    {
        // structs read-only controlled via get-set
        public DtoExamplePlayerStruct StructWritable { get; set; } = new DtoExamplePlayerStruct();
        public DtoExamplePlayerStruct StructReadOnly { get; } = new DtoExamplePlayerStruct();

        // these are controlled by type so get-only

        public DtoExamplePlayerClass ClassWritable { get; } = new DtoExamplePlayerClass();
        // should be different type with copy-pasted members but get only
        public DtoExamplePlayerClass ClassReadOnly { get; } = new DtoExamplePlayerClass();

        public Ref<DtoExamplePlayerNew> NewWritable { get; } = new Ref<DtoExamplePlayerNew>();
        public Getter<DtoExamplePlayerNew> NewReadOnly { get; } = new Getter<DtoExamplePlayerNew>();
    }
}