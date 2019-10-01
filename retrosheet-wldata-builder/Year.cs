using System;
using System.Collections.Generic;

namespace retrosheet_wldata_builder
{
    public class Year
    {
        public string Id { get; set; }
        public string Team { get; set; }
        public string Subtitle { get; set; }
        public string Title { get; set; }
        public List<Game> Games { get; set; }
    }
}
