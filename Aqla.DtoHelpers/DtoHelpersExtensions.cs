namespace Aqla.DtoHelpers
{
    public static class DtoHelpersExtensions
    {
        public static Ref<T> CloneAndMakeRef<T>(this T value) where T : struct
        {
            return new Ref<T>(value);
        }
    }
}