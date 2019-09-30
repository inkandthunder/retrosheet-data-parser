using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace retrosheet_wldata_builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "//Users//inkandthunder//Downloads//GL2018.TXT";
            List<Team> teams = GetTeams("data/TEAMABR.TXT");
            //List<Team> teams = new List<Team>();
            if (File.Exists(input))
            {
                try
                {
                    using (var reader = new StreamReader(input))
                    using (var csv = new CsvReader(reader))
                    {
                        csv.Configuration.HeaderValidated = null;
                        csv.Configuration.RegisterClassMap<RetrosheetDataMap>();
                        var records = csv.GetRecords<RetrosheetGame>();

                        foreach (var record in records)
                        {
                            Console.WriteLine(LeagueLongFormatter(record.HomeTeamLeague) + " " + LeagueLongFormatter(record.VisitingTeamLeague));

                            //Console.WriteLine(DateFormatter(record.Date) + " " + TeamNameLongFormatter(record.HomeTeamName, teams) + " (" + record.HomeTeamScore + ") vs. " + TeamNameLongFormatter(record.VisitingTeamName, teams) + " (" + record.VisitingTeamScore+ ")");
                        }
                        Console.WriteLine("Completed");
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
            //foreach (var game in records)
        }


        public static string DateFormatter(string date)
        {
            DateTime dt = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
            return dt.ToString("MM/dd/yyyy");
        }

        public static List<Team> GetTeams(string data)
        {
            if (File.Exists(data))
            {
                using (var reader = new StreamReader(data))
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.HeaderValidated = null;
                    csv.Configuration.RegisterClassMap<TeamDataMap>();
                    var teams = csv.GetRecords<Team>();

                    List<Team> output = new List<Team>();
                    foreach (var team in teams)
                    {
                        output.Add(team);
                    }
                    return output;
                }
            }
            else
            {
                Console.WriteLine("File " + data + " does not exist!");
                return null;
            }
        }

        public static string TeamNameShortFormatter(string team, List<Team> teamData)
        {
            return teamData.Where(x => x.TeamAbbreviation == team).Select(v => v.Nickname).First().ToString();
        }

        public static string TeamNameLongFormatter(string team, List<Team> teamData)
        {
            return teamData.Where(x => x.TeamAbbreviation == team).Select(v => v.City + " " + v.Nickname).First();
            //return "";
        }

        public static string LeagueLongFormatter(string league)
        {
            string longLeague;
            switch (league)
            {
                case "NA":
                    longLeague = "National Association";
                    break;
                case "NL":
                    longLeague = "National League";
                    break;
                case "AA":
                    longLeague = "American Association";
                    break;
                case "AL":
                    longLeague = "American League";
                    break;
                default:
                    longLeague = league;
                    break;
            }

            return longLeague;
        }

        public static string GameInformationFormatter(string game)
        {
            return "";
        }

        public static string ForfeitFormatter(string forfeit)
        {
            return "";
        }

        public static string ProtestFormatter(string protest)
        {
            return "";
        }

        public static string AcquisitionFormatter(string acquisition)
        {
            return "";
        }

        //public static LineScore LineScoreParser(string linescore)
        //{

        //}

    }

}
