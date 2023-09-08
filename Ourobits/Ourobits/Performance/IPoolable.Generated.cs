using System;
using System.Collections.Generic;
using System.Text;

namespace Ourobits.Performance
{

/// <summary>
/// Quick test
/// </summary>
    public interface IPoolable
    {
        int Index
        {
            get;
            set;
        }



        bool Used
        {
            get;
            set;
        }
    }
}
