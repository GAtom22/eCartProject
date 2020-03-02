using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Cart.Areas.Panel
{
    public class PanelAreaRegistration:AreaRegistration
    {

        public override string AreaName => "Panel";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Panel_default",
                "Panel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}
