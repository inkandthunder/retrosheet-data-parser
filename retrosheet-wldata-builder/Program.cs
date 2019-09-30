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
                            //Console.WriteLine();
                            Console.WriteLine(FriendlyDateFormat(record.Date) + " " + TeamNameLongFormatter(record.HomeTeamName, teams) + " (" + record.HomeTeamScore + ") vs. " + TeamNameLongFormatter(record.VisitingTeamName, teams) + " (" + record.VisitingTeamScore+ ")");
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
                    longLeague = "";
                    break;
            }
            return longLeague;
        }

        public static string GameInformationFormatter(string game)
        {
            string gameInformation;
            switch(game)
            {
                case "0":
                    gameInformation = "Single Game";
                    break;
                case "1":
                    gameInformation = "First game of a double (or triple) header";
                    break;
                case "2":
                    gameInformation = "Second game of a double (or triple) header";
                    break;
                case "3":
                    gameInformation = "Third game of a triple header";
                    break;
                case "A":
                    gameInformation = "First game of a double-header involving 3 teams";
                    break;
                case "B":
                    gameInformation = "Second game of a double-header involving 3 teams";
                    break;
                default:
                    gameInformation = "";
                    break;
            }

            return gameInformation;
        }

        public static string ForfeitFormatter(string forfeit)
        {
            string forfeitInformation;
            switch (forfeit)
            {
                case "V":
                    forfeitInformation = "Forfeited to the Visiting Team";
                    break;
                case "H":
                    forfeitInformation = "Forfeited to the Home Team";
                    break;
                case "T":
                    forfeitInformation = "No Decision";
                    break;
                default:
                    forfeitInformation = "";
                    break;
            }
            return forfeitInformation;
        }

        public static string ProtestFormatter(string protest)
        {
            string protestInformation;
            switch (protest)
            {
                case "P":
                    protestInformation = "Protested by an unidentified team";
                    break;
                case "V":
                    protestInformation = "Disallowed protest made by visiting team";
                    break;
                case "H":
                    protestInformation = "Disallowed protest made by home team";
                    break;
                case "X":
                    protestInformation = "Upheld protest made by visiting team";
                    break;
                case "Y":
                    protestInformation = "Uphead protest made by home team";
                    break;
                default:
                    protestInformation = "";
                    break;
            };
            return protestInformation;
        }

        public static string AcquisitionFormatter(string acquisition)
        {
            string acquisitionInformation;
            switch (acquisition)
            {
                case "Y":
                    acquisitionInformation = "Complete game information unavailable";
                    break;
                case "N":
                    acquisitionInformation = "No portion of the game available";
                    break;
                case "D":
                    acquisitionInformation = "Game information derived from box score and game story";
                    break;
                case "P":
                    acquisitionInformation = "Partial game information available, but may be missing complete innings";
                    break;
                default:
                    acquisitionInformation = "";
                    break;
            }
            return acquisitionInformation;
        }

        //public static LineScore LineScoreParser(string linescore)
        //{

        //}

    }

}
