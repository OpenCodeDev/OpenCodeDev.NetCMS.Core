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

        /// <summary>
        /// Domain area (base namespace)
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Model Relation has targeted.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Type of relationship <br/>
        /// 1-0, 1-1, X-0, X-1 and X-X
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Child can only have one dominant parent. <br/>
        /// if left is deleted it will delete or set null right automatically.
        /// </summary>
        public bool Dominant { get; set; }

        /// <summary>
        /// Cascade: Will delete child relation if parent is deleted (1-1 Only). <br/>
        /// Null (Default): Will set to null child object if parent is deleted (means relation is optional)<br/>
        /// Note: X-0, 1-0 and X-X (Delete the binding agent)
        /// </summary>
        public string DeleteBehavior { get; set; } = null;
    }
}
