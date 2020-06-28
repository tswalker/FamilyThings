
namespace FamilyThings
{
    public class ColorTypeEnum : Enumeration
    {
        public static readonly ColorTypeEnum Red = new ColorTypeEnum(1, "Red", "R");
        public static readonly ColorTypeEnum Yellow = new ColorTypeEnum(2, "Yellow", "Y");
        public static readonly ColorTypeEnum Blue = new ColorTypeEnum(3, "Blue", "B");
        public static readonly ColorTypeEnum Green = new ColorTypeEnum(4, "Green", "G");

        private ColorTypeEnum() { }
        private ColorTypeEnum(int id, string name, string symbol) : base(id, name, symbol) { }

        //can you identify the problem with this?
        public enum ColorEnum
        {
            Red = 1,
            Yellow = 2,
            Blue = 3,
            Green = 4
        }
    }
}
