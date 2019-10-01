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
        public static List<Team> teams = GetTeams("data/TEAMABR.TXT");
        public static List<Game> games = new List<Game>();

        static void Main(string[] args)
        {
            var input = "data/GL2018.TXT";
            if (File.Exists(input))
            {
                try
                {
                    using (var reader = new StreamReader(input))
                    using (var csv = new CsvReader(reader))
                    {
                        csv.Configuration.HasHeaderRecord = false;
                        csv.Configuration.RegisterClassMap<RetrosheetDataMap>();
                        var records = csv.GetRecords<RetrosheetGame>();

                        foreach (var record in records)
                        {
                            //Home
                            CreateGame(record.Date, record.HomeTeamName, false, int.Parse(record.HomeTeamScore), int.Parse(record.VisitingTeamScore), record.VisitingTeamName, "", record.HomeManagerName);

                            //Visitors
                            CreateGame(record.Date, record.VisitingTeamName, true, int.Parse(record.HomeTeamScore), int.Parse(record.VisitingTeamScore), record.HomeTeamName, "", record.VisitingManagerName);
                        }

                        var grouped = games.OrderBy(x => x.GameNumber).GroupBy(x => x.Team);

                        foreach (var group in grouped)
                        {
                            var groupKey = group.Key;
                            foreach (var subgroup in group)
                            {
                                Console.WriteLine(subgroup.Team + "(" + subgroup.GameNumber + "/" + subgroup.ChartIndex + "): " + subgroup.EventTitleText + " " + subgroup.ResultText);
                            }
                            //Console.WriteLine(group.Key.);
                            //Console.WriteLine(group.Team + "(" + group.GameNumber + "/" + temp.ChartIndex + "): " + temp.EventTitleText + " " + temp.ResultText);
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

            Console.ReadKey();
        }

        public static void CreateGame(string date, string team, bool visiting, int homeScore, int visitorScore, string opponent, string result, string manager)
        {
            var currentGameCount = games.Where(x => x.Team == team).Select(y => y.GameNumber).LastOrDefault();
            var currentIndex = games.Where(x => x.Team == team).Select(y => y.ChartIndex).LastOrDefault();

            int myScore = 0;
            int opponentScore = 0;
            int GameNumber = currentGameCount;
            int RunningIndex = currentIndex;
            Game temp = new Game();
            temp.Year = GetYear(date);
            temp.Date = FriendlyDateFormat(date);
            temp.Team = team;


            if (visiting == true)
            {
                temp.EventTitleText = FriendlyDateFormat(date) + " at " + opponent;//Apr 9 at BAL
                myScore = visitorScore;
                opponentScore = homeScore;
            }
            else if (visiting == false)
            {
                temp.EventTitleText = FriendlyDateFormat(date) + " vs " + opponent;//Apr 9 at BAL
                myScore = homeScore;
                opponentScore = visitorScore;
            }

            if (myScore > opponentScore)
            {
                temp.ResultText = "W " + myScore + "-" + opponentScore;
                temp.ChartIndex = (RunningIndex+1);
            }
            else
            {
                temp.ResultText = "L " + myScore + "-" + opponentScore;
                temp.ChartIndex = (RunningIndex-1);
            }
            
            temp.Manager = manager;
            temp.GameNumber = GameNumber+1;
            games.Add(temp);
            //Console.WriteLine(temp.Team + "(" + temp.GameNumber + "/" + temp.ChartIndex + "): " + temp.EventTitleText + " " + temp.ResultText);
        }


        public static string FriendlyDateFormat(string date)
        {
            DateTime dt = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
            return dt.ToString("MMM dd");
            //return dt.ToString("MM/dd/yyyy");
        }

        public static string GetYear(string date)
        {
            DateTime dt = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
            return dt.ToString("yyyy");
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
