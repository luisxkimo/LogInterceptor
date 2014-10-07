using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInterceptor
{
    public enum Location
    {
        MoreLeft = 2,
        MoreRight = 3

    }
    public class Car : IAuto
    {
        public string CarName { get; set; }
        public int ActualVelocity { get; private set; }

        public Location MyLocation { get; private set; }

        public void Run(int velocity, Direction direction)
        {
            ActualVelocity = velocity;

            MyLocation = direction == Direction.Left ? Location.MoreLeft : Location.MoreRight;

        }

        public void AddVelocity(int moreVelocity)
        {
            ActualVelocity *= moreVelocity;
        }

        public override string ToString()
        {
            return string.Format("CarName: {0}, ActualVelocity: {1}, MyLocation: {2}", CarName, ActualVelocity, MyLocation);
        }
    }
}
