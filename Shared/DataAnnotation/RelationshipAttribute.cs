using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Shared.DataAnnotation
{

    public enum RelationshipType
    {
        OneToZero,
        ManyToZero,
        OneToOne,
        OneToMany,
        ManyToMany,
        ManyToOne
    }
    public class RelationshipAttribute : Attribute
    {
        public RelationshipType Relation { get; set; }
        public string  ForeignKey { get; set; }
        public RelationshipAttribute(RelationshipType relation)
        {
            Relation = relation;
        }

        public RelationshipAttribute(RelationshipType relation, string foreignKey) : this(relation)
        {
            ForeignKey = foreignKey;
        }
    }
}
