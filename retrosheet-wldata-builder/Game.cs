using System;

namespace retrosheet_wldata_builder
{
    public class Game
    {
        public string Id { get; set; }
        public string Year { get; set; }
        public int GameNumber { get; set; }
        public string Team { get; set; }
        public string Date { get; set; }
        public int ChartIndex { get; set; }
        public string EventTitleText { get; set; }
        public string ResultText { get; set; }
        public string Manager { get; set; }
        public string RunningTotalWins { get; set; }
        public string RunningTotalLosses { get; set; }
    }
}
