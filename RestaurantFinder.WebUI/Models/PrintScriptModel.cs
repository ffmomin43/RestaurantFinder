﻿using System.Collections.Generic;

namespace RestaurantFinder.WebUI.Models
{
    public class PrintScriptModel
    {
        public string PrintButtonId { get; set; }

        public string ContentDivName { get; set; }

        public string Title { get; set; }

        public IEnumerable<string> CssLinkList { get; set; }
    }
}