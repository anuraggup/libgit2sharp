using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibGit2Sharp.Core.Handles
{
    internal class FilterSafeHandle : NotOwnedSafeHandleBase
    {
        public FilterSafeHandle(IntPtr handle)
        {
            this.SetHandle(handle);
        }

        public FilterSafeHandle()
        {
            this.SetHandle(IntPtr.Zero);
        }
    }
}
