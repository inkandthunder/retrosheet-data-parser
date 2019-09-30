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
            var input = "data/GL2018.TXT";
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
                            Console.WriteLine();
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


        public static string FriendlyDateFormat(string date)
        {
            DateTime dt = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
            return dt.ToString("MM/dd/yyyy");
        }

        public static List<Team> GetTeams(string data)
        {
            if (File.Exists(data))
            {
                using var reader = new StreamReader(data);
                using var csv = new CsvReader(reader);
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
        }

        public static string LeagueLongFormatter(string league)
        {
            var longLeague = league switch
            {
                "NA" => "National Association",
                "NL" => "National League",
                "AA" => "American Association",
                "AL" => "American League",
                _ => league,
            };
            return longLeague;
        }

        public static string GameInformationFormatter(string game)
        {
            var gameInformation = game switch
            {
                "0" => "Single Game",
                "1" => "First game of a double (or triple) header",
                "2" => "Second game of a double (or triple) header",
                "3" => "Third game of a triple header",
                "A" => "First game of a double-header involving 3 teams",
                "B" => "Second game of a double-header involving 3 teams",
                _ => "",
            };
            return gameInformation;
        }

        public static string ForfeitFormatter(string forfeit)
        {
            var forfeitInformation = forfeit switch
            {
                "V" => "Forfeited to the Visiting Team",
                "H" => "Forfeited to the Home Team",
                "T" => "No Decision",
                _ => "",
            };
            return forfeitInformation;
        }

        public static string ProtestFormatter(string protest)
        {
            var protestInformation = protest switch
            {
                "P" => "Protested by an unidentified team",
                "V" => "Disallowed protest made by visiting team",
                "H" => "Disallowed protest made by home team",
                "X" => "Upheld protest made by visiting team",
                "Y" => "Uphead protest made by home team",
                _ => "",
            };
            return protestInformation;
        }

        public static string AcquisitionFormatter(string acquisition)
        {
            var acquisitionInformation = acquisition switch
            {
                "Y" => "Complete game information unavailable",
                "N" => "No portion of the game available",
                "D" => "Game information derived from box score and game story",
                "P" => "Partial game information available, but may be missing complete innings",
                _ => "",
            };
            return acquisitionInformation;
        }

        //public static LineScore LineScoreParser(string linescore)
        //{

        //}

    }

}
