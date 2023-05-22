using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLibrary
{
    public enum AccountState
    {
        Safe,
        InOD,
        ODLimit,
        NotAllowed,
        None
    }
}
