using System;
using System.Collections.Generic;
using System.Text;

namespace TMDProject
{
    public abstract class BaseUser
    {
        protected Context _context;

        public BaseUser(Context context)
        {
            _context = context;
        }

        public abstract BaseUser Menu();
    }
}
