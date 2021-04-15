using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    interface IEqutable<Card>
    {
        bool Equals(Card card);
    }
}
