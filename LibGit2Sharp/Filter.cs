using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibGit2Sharp.Core;
using LibGit2Sharp.Core.Handles;

namespace LibGit2Sharp
{
    /// <summary>
    /// Class to represent libgit2 Filter
    /// </summary>
    public sealed class Filter
    {
        private readonly FilterSafeHandle handle;
        private readonly string name;

        /// <summary>
        /// Constructor for Filter object.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="name"></param>
        public Filter(IntPtr handle, string name)
        {
            this.handle = new FilterSafeHandle(handle);
            this.name = name;
        }

        /// <summary>
        /// Looks up a filter by name
        /// </summary>
        /// <param name="name"></param>
        public Filter(string name)
        {
            this.handle = Proxy.git_filter_lookup(name);

            if (this.handle.IsInvalid)
            {
                throw new ArgumentException("Filter not found.");
            }

            this.name = name;
        }

        /// <summary>
        /// Registers a filter
        /// </summary>
        /// <param name="priority"></param>
        public void Register(int priority = 200)
        {
            var res = Proxy.git_filter_register(name, handle, priority);
            Ensure.ZeroResult(res);
        }

        /// <summary>
        /// Unregisters a filter
        /// </summary>
        public void Unregister()
        {
            var res = Proxy.git_filter_unregister(name);
            Ensure.ZeroResult(res);
        }

        /// <summary>
        /// Name of filter
        /// </summary>
        public string Name
        {
            get { return name; }
        }

    }
}
