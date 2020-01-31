using System;

namespace RestaurantFinder.WebUI.Models
{
    public class DatePickerScriptModel
    {
        public string TextBoxId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}