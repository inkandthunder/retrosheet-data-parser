using System;
using CsvHelper.Configuration;

namespace retrosheet_wldata_builder
{
    public class Team
    {
        public string TeamAbbreviation{ get; set; }
        public string League { get; set; }
        public string City { get; set; }
        public string Nickname { get; set; }
        public string FirstYearOfCombo { get; set; }
        public string LastYearOfCombo { get; set; }
    }


    public sealed class TeamDataMap : ClassMap<Team>
    {
        public TeamDataMap()
        {
            Map(m => m.TeamAbbreviation).Index(0);
            Map(m => m.League).Index(1);
            Map(m => m.City).Index(2);
            Map(m => m.Nickname).Index(3);
            Map(m => m.FirstYearOfCombo).Index(4);
            Map(m => m.LastYearOfCombo).Index(5);
        }
    }

}
