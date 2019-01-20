using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TorontoWasteLookup.Models;

namespace TorontoWasteLookup.ViewModel
{
    public class WasteInfoViewModel
    {
        public List<WasteInfo> wasteInfoList { get; set; }
        public List<WasteInfo> favouriteList { get; set; }

        public WasteInfoViewModel()
        {
            wasteInfoList = new List<WasteInfo>();
            favouriteList = new List<WasteInfo>();
        }
    }
}