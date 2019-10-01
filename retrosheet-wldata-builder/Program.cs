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


        static void Main()
        {
            string[] files = Directory.GetFiles("data/years");
            foreach (string file in files)
            {
                var input = Path.GetFullPath(file);

                if (File.Exists(input))
                {
                try
                {
                    using (var reader = new StreamReader(input))
                    using (var csv = new CsvReader(reader))
                    {
                        csv.Configuration.HasHeaderRecord = false;
                        csv.Configuration.RegisterClassMap<RetrosheetDataMap>();
                        csv.Configuration.MissingFieldFound = null;
                        var records = csv.GetRecords<RetrosheetGame>();

                        foreach (var record in records)
                        {
                            //Home
                            CreateGame(record.Date, record.HomeTeamName, false, int.Parse(record.HomeTeamScore), int.Parse(record.VisitingTeamScore), record.VisitingTeamName, "", record.HomeManagerName);

                            //Visitors
                            CreateGame(record.Date, record.VisitingTeamName, true, int.Parse(record.HomeTeamScore), int.Parse(record.VisitingTeamScore), record.HomeTeamName, "", record.VisitingManagerName);
                        }

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
        }

            var grouped = games.OrderBy(x => x.Team).ThenBy(x => x.Year).ThenBy(x => x.GameNumber).ToList();
            List<string> currentTeams = new List<string>(new string[] { "SEA","WAS","BAL","CLE","ANA","NYN","SDN","TEX","ARI","CHA","HOU","MIL","PHI","SLN","BOS","COL","LAN","NYA","SFN","TOR","ATL","CIN","KCA","MIN","PIT","TBA","CHN","DET","MIA","OAK" });
            string yearIndex = "";
            string teamIndex = "";
            string createText = "";
            foreach (var group in grouped)
            {
                if (teamIndex != group.Team)
                {
                    File.WriteAllText("output/" + teamIndex +".js", createText);
                    createText = "";
                    teamIndex = group.Team;
                    createText += "var " + group.Team + " = [{" + Environment.NewLine;
                    Console.WriteLine("-------------------");
                    Console.WriteLine("Begin " + group.Team);
                }

                if (yearIndex != group.Year)
                {
                    yearIndex = group.Year;
                    createText += "]" + Environment.NewLine;
                    createText += "}," + Environment.NewLine;
                    createText += "{" + Environment.NewLine;
                    createText += "name: \"y" + group.Year + "\"," + Environment.NewLine;
                    createText += "year: \"" + group.Year + "\"," + Environment.NewLine;
                    createText += "subtitle: \"Manager: " + group.Manager + "\",  " + Environment.NewLine;
                    int winStatus;
                    var winTotal = grouped.Where(x => x.Team == group.Team && x.Year == group.Year).Select(y => y.RunningTotalWins).LastOrDefault();
                    var lossTotal = grouped.Where(x => x.Team == group.Team && x.Year == group.Year).Select(y => y.RunningTotalLosses).LastOrDefault();
                    if (winTotal > lossTotal)
                    {
                        winStatus = 1;
                    }
                    else
                    {
                        winStatus = 0;
                    }
                    string yearAverage = (Math.Round((decimal) winTotal / (winTotal + lossTotal), 3)).ToString().TrimStart(new Char[] { '0' });

                    createText += "title: \"" + group.Year + " " + TeamNameShortFormatter(group.Team, teams) + " " + winTotal + " - " + lossTotal + " (" + yearAverage + ")\"," + Environment.NewLine;
                    createText += "won: " + winStatus + "," + Environment.NewLine;
                    createText += "data: [" + Environment.NewLine;
                }
                createText += "{\"x\":" + group.GameNumber + ",\"y\":" + group.ChartIndex + ",\"name\":\"" + group.EventTitleText + "\",\"result\":\"" + group.ResultText + "\"}," + Environment.NewLine;
                //Console.WriteLine("{\"x\":" + group.GameNumber + ",\"y\":" + group.ChartIndex + ",\"name\":\"" + group.EventTitleText + "\",\"result\":\"" + group.ResultText + "\"},");
            }

        }

        public static void CreateGame(string date, string team, bool visiting, int homeScore, int visitorScore, string opponent, string result, string manager)
        {
            var currentGameCount = games.Where(x => x.Team == team && x.Year == GetYear(date)).Select(y => y.GameNumber).LastOrDefault();
            var currentIndex = games.Where(x => x.Team == team && x.Year == GetYear(date)).Select(y => y.ChartIndex).LastOrDefault();
            var currentWins = games.Where(x => x.Team == team && x.Year == GetYear(date)).Select(y => y.RunningTotalWins).LastOrDefault();
            var currentLosses = games.Where(x => x.Team == team && x.Year == GetYear(date)).Select(y => y.RunningTotalLosses).LastOrDefault();
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
                temp.EventTitleText = FriendlyDateFormat(date) + " at " + opponent;
                myScore = visitorScore;
                opponentScore = homeScore;
            }
            else if (visiting == false)
            {
                temp.EventTitleText = FriendlyDateFormat(date) + " vs " + opponent;
                myScore = homeScore;
                opponentScore = visitorScore;
            }

            if (myScore > opponentScore)
            {
                temp.ResultText = "W " + myScore + "-" + opponentScore;
                temp.ChartIndex = (RunningIndex+1);
                temp.RunningTotalWins = (currentWins+1);
                temp.RunningTotalLosses = currentLosses;
            }
            else
            {
                temp.ResultText = "L " + myScore + "-" + opponentScore;
                temp.ChartIndex = (RunningIndex-1);
                temp.RunningTotalLosses = (currentLosses+1);
                temp.RunningTotalWins = currentWins;
            }
            
            temp.Manager = manager;
            temp.GameNumber = GameNumber+1;
            games.Add(temp);
        }


        public static string FriendlyDateFormat(string date)
        {
            DateTime dt = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
            return dt.ToString("MMM dd");
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
                    var teamsLocal = csv.GetRecords<Team>();

                    List<Team> output = new List<Team>();
                    foreach (var team in teamsLocal)
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

    }
}
