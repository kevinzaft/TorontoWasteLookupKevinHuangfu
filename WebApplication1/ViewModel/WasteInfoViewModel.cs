using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
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