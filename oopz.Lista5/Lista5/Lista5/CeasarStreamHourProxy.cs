using System;
using System.IO;

namespace Lista5
{
    public class CeasarStreamHourProxy : CeasarStreamProxy
    {
        public CeasarStreamHourProxy(Stream str, byte offset) : base(str, offset)
        {
        }

        public bool CanUse()
        {
            return DateTime.Now.Hour < 23 && DateTime.Now.Hour >= 8;
        }

        public override void OnUse()
        {
            if (!CanUse())
            {
                throw new FieldAccessException("You can access this proxy only between 8 AM and 22 PM");
            }
        }
    }
}
