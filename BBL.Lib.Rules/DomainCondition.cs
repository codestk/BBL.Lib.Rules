using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BBL.Lib.Rules
{
    public class DomainCondition<T> : StringOperatorCondition<T> where T : RuleContext
    {
        public string DomainStringName { get; set; }

        public string DomainStringValue { get; set; }
        protected override bool Execute(T ruleContext)
        {
           

            Assert.ArgumentNotNull(ruleContext, "ruleContext");

            string myDomainStringName = this.DomainStringName ?? string.Empty;
            string myDomainStringValue = this.DomainStringValue ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(myDomainStringName))
            {
                if (HttpContext.Current != null)
                {
                    // Populated with QueryString coming into current Page
                    string incomingDomainStringValue = HttpContext.Current.Request.UrlReferrer.DnsSafeHost ?? string.Empty;
                    if (string.Equals(incomingDomainStringValue, myDomainStringValue, StringComparison.OrdinalIgnoreCase))
                    {

                        return true;
                    }
                }


               
            }

            return false;
        }
    }
}
