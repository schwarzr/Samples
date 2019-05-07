using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionDiary.App
{
    public class AppOptions
    {
        public AppOptions()
        {
            this.ServerUrl = "http://localhost:5001/";
        }

        public string ServerUrl { get; set; }
    }
}