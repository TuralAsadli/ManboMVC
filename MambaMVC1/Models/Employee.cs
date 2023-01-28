using MambaMVC1.Models.Base;

namespace MambaMVC1.Models
{
    public class Employee :BaseItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FaceBook { get; set; }
        public string Twitter { get; set; }
        public string LinkedIn { get; set; }
        public string Instagram { get; set; }
        public string ImgName { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
