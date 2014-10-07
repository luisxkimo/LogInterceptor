using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInterceptor
{
    public interface IAuto
    {
        void Run(int velocity, Direction direction);
        void AddVelocity(int moreVelocity);
    }
}
