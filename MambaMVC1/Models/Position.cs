using MambaMVC1.Models.Base;

namespace MambaMVC1.Models
{
    public class Position : BaseItem
    {
        public string PositionName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
