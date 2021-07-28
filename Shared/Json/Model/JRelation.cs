using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Server.Plugin.JSON
{
    public class JRelation
    {
        /// <summary>
        /// When can we provide the prop ? <br/>
        /// Create:<br/>
        /// - <b>One to One, One to Many and One to Zero</b>: 
        /// Pass GUID to Link, ModelCreateRequest to create relation. <br/>
        /// - <b>Many to One, Many to Many, Many to Zero</b>: Pass list GUID to Link, List of ModelCreateRequest to create relations <br/><br/>
        /// Update:<br/>
        /// - <b>One to One, One to Many and One to Zero</b>: 
        /// Pass GUID to Link or Unlink, ModelUpdateRequest to update relation object. <br/>
        /// - <b>Many to One, Many to Many, Many to Zero</b>: 
        /// Pass list GUID to Link/Unlink, List of ModelUpdateRequest to update relations <br/><br/>
        /// Fetch: During fetch, prop can be passed to search for an entry.
        /// </summary>
        public List<string> ArgumentOf { get; set; }
    }
}
