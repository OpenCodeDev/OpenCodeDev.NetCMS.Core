using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Shared.Extensions
{
    public class MyExpressionVisitor : ExpressionVisitor
    {
        public ParameterExpression TargetParameterExpression { get; private set; }
        public object TargetParameterValue { get; private set; }
        public MyExpressionVisitor(ParameterExpression targetParameterExpression, object targetParameterValue)
        {
            this.TargetParameterExpression = targetParameterExpression;
            this.TargetParameterValue = targetParameterValue;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == TargetParameterExpression)
                return Expression.Constant(TargetParameterValue);
            return base.VisitParameter(node);
        }
    }

    public class ExpressionParameterReplacer : ExpressionVisitor
    {
        public ExpressionParameterReplacer(IList<ParameterExpression> fromParameters, IList<ParameterExpression> toParameters)
        {
            ParameterReplacements = new Dictionary<ParameterExpression, ParameterExpression>();
            for (int i = 0; i != fromParameters.Count && i != toParameters.Count; i++)
                ParameterReplacements.Add(fromParameters[i], toParameters[i]);
        }

        private IDictionary<ParameterExpression, ParameterExpression> ParameterReplacements { get; set; }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            ParameterExpression replacement;
            if (ParameterReplacements.TryGetValue(node, out replacement))
                node = replacement;
            return base.VisitParameter(node);
        }
    }
}
