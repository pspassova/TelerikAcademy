using System.Collections.Generic;
using Task1;

namespace Task._8
{
    // By inheriting the Employee entity class create a class which allows employees to access their corresponding territories as property of type EntitySet<T>.
    public partial class EmployeeExtended : Employee
    {
        public override ICollection<Territory> Territories
        {
            get
            {
                return base.Territories;
            }

            set
            {
                base.Territories = new EntitySet<Territory>();
            }
        }
    }
}
