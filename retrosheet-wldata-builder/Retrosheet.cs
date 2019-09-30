using System;
using CsvHelper.Configuration;

namespace retrosheet_wldata_builder
{

    public class RetrosheetGame
    {
        public string Date { get; set; }
        public string GameType { get; set; }
        public string DayOfWeek { get; set; }
        public string VisitingTeamName { get; set; }
        public string VisitingTeamLeague { get; set; }
        public string VisitingTeamGameNumber { get; set; }
        public string HomeTeamName { get; set; }
        public string HomeTeamLeague { get; set; }
        public string HomeTeamGameNumber { get; set; }
        public string VisitingTeamScore { get; set; }
        public string HomeTeamScore { get; set; }
        public string LengthOfGameInOuts { get; set; }
        public string DayNightIndicator { get; set; }
        public string CompletionInformation { get; set; }
        public string ForfeitInformation { get; set; }
        public string ProtestInformation { get; set; }
        public string ParkId { get; set; }
        public string Attendance { get; set; }
        public string TimeOfGameInMinutes { get; set; }
        public string VisitingLineScore { get; set; }
        public string HomeLineScore { get; set; }
        public string VisitingOffenseAtBats { get; set; }
        public string VisitingOffenseHits { get; set; }
        public string VisitingOffenseDoubles { get; set; }
        public string VisitingOffenseTriples { get; set; }
        public string VisitingOffenseHomeRuns { get; set; }
        public string VisitingOffenseRBI { get; set; }
        public string VisitingOffenseSacHits { get; set; }
        public string VisitingOffenseSacFlies { get; set; }
        public string VisitingOffenseHitByPitch { get; set; }
        public string VisitingOffenseWalks { get; set; }
        public string VisitingOffenseIntentionalWalks { get; set; }
        public string VisitingOffenseStrikeouts { get; set; }
        public string VisitingOffenseStolenBases { get; set; }
        public string VisitingOffenseCaughtStealing { get; set; }
        public string VisitingOffenseGroundedIntoDP { get; set; }
        public string VisitingOffenseCatcherInteference { get; set; }
        public string VisitingOffenseLeftOnBase { get; set; }
        public string VisitingPitchingPitchersUsed { get; set; }
        public string VisitingPitchingIndividualEarnedRuns { get; set; }
        public string VisitingPitchingTeamEarnedRuns { get; set; }
        public string VisitingPitchingWildPitches { get; set; }
        public string VisitingPitchingBalks { get; set; }
        public string VisitingDefensePutouts { get; set; }
        public string VisitingDefenseAssists { get; set; }
        public string VisitingDefenseErrors { get; set; }
        public string VisitingDefensePassedBalls { get; set; }
        public string VisitingDefenseDoublePlays { get; set; }
        public string VisitingDefenseTriplePlays { get; set; }
        public string HomeOffenseAtBats { get; set; }
        public string HomeOffenseHits { get; set; }
        public string HomeOffenseDoubles { get; set; }
        public string HomeOffenseTriples { get; set; }
        public string HomeOffenseHomeRuns { get; set; }
        public string HomeOffenseRBI { get; set; }
        public string HomeOffenseSacHits { get; set; }
        public string HomeOffenseSacFlies { get; set; }
        public string HomeOffenseHitByPitch { get; set; }
        public string HomeOffenseWalks { get; set; }
        public string HomeOffenseIntentionalWalks { get; set; }
        public string HomeOffenseStrikeouts { get; set; }
        public string HomeOffenseStolenBases { get; set; }
        public string HomeOffenseCaughtStealing { get; set; }
        public string HomeOffenseGroundedIntoDP { get; set; }
        public string HomeOffenseCatcherInteference { get; set; }
        public string HomeOffenseLeftOnBase { get; set; }
        public string HomePitchingPitchersUsed { get; set; }
        public string HomePitchingIndividualEarnedRuns { get; set; }
        public string HomePitchingTeamEarnedRuns { get; set; }
        public string HomePitchingWildPitches { get; set; }
        public string HomePitchingBalks { get; set; }
        public string HomeDefensePutouts { get; set; }
        public string HomeDefenseAssists { get; set; }
        public string HomeDefenseErrors { get; set; }
        public string HomeDefensePassedBalls { get; set; }
        public string HomeDefenseDoublePlays { get; set; }
        public string HomeDefenseTriplePlays { get; set; }
        public string UmpireHomeId { get; set; }
        public string UmpireHomeName { get; set; }
        public string Umpire1BId { get; set; }
        public string Umpire1BName { get; set; }
        public string Umpire2BId { get; set; }
        public string Umpire2BName { get; set; }
        public string Umpire3BId { get; set; }
        public string Umpire3BName { get; set; }
        public string UmpireLFId { get; set; }
        public string UmpireLFName { get; set; }
        public string UmpireRFId { get; set; }
        public string UmpireRFName { get; set; }
        public string VisitingManagerId { get; set; }
        public string VisitingManagerName { get; set; }
        public string HomeManagerId { get; set; }
        public string HomeManagerName { get; set; }
        public string WinningPitcherId { get; set; }
        public string WinningPitcherName { get; set; }
        public string LosingPitcherId { get; set; }
        public string LosingPitcherName { get; set; }
        public string SavingPitcherId { get; set; }
        public string SavingPitcherName { get; set; }
        public string GameWinRBIBatterId { get; set; }
        public string GameWinRBIBatterName { get; set; }
        public string VisitingStartingPitcherId { get; set; }
        public string VisitingStartingPitcherName { get; set; }
        public string HomeStartingPitcherId { get; set; }
        public string HomeStartingPitcherName { get; set; }
        public string VisitingStartingPlayer1Id { get; set; }
        public string VisitingStartingPlayer1Name { get; set; }
        public string VisitingStartingPlayer1Pos { get; set; }
        public string VisitingStartingPlayer2Id { get; set; }
        public string VisitingStartingPlayer2Name { get; set; }
        public string VisitingStartingPlayer2Pos { get; set; }
        public string VisitingStartingPlayer3Id { get; set; }
        public string VisitingStartingPlayer3Name { get; set; }
        public string VisitingStartingPlayer3Pos { get; set; }
        public string VisitingStartingPlayer4Id { get; set; }
        public string VisitingStartingPlayer4Name { get; set; }
        public string VisitingStartingPlayer4Pos { get; set; }
        public string VisitingStartingPlayer5Id { get; set; }
        public string VisitingStartingPlayer5Name { get; set; }
        public string VisitingStartingPlayer5Pos { get; set; }
        public string VisitingStartingPlayer6Id { get; set; }
        public string VisitingStartingPlayer6Name { get; set; }
        public string VisitingStartingPlayer6Pos { get; set; }
        public string VisitingStartingPlayer7Id { get; set; }
        public string VisitingStartingPlayer7Name { get; set; }
        public string VisitingStartingPlayer7Pos { get; set; }
        public string VisitingStartingPlayer8Id { get; set; }
        public string VisitingStartingPlayer8Name { get; set; }
        public string VisitingStartingPlayer8Pos { get; set; }
        public string VisitingStartingPlayer9Id { get; set; }
        public string VisitingStartingPlayer9Name { get; set; }
        public string VisitingStartingPlayer9Pos { get; set; }
        public string HomeStartingPlayer1Id { get; set; }
        public string HomeStartingPlayer1Name { get; set; }
        public string HomeStartingPlayer1Pos { get; set; }
        public string HomeStartingPlayer2Id { get; set; }
        public string HomeStartingPlayer2Name { get; set; }
        public string HomeStartingPlayer2Pos { get; set; }
        public string HomeStartingPlayer3Id { get; set; }
        public string HomeStartingPlayer3Name { get; set; }
        public string HomeStartingPlayer3Pos { get; set; }
        public string HomeStartingPlayer4Id { get; set; }
        public string HomeStartingPlayer4Name { get; set; }
        public string HomeStartingPlayer4Pos { get; set; }
        public string HomeStartingPlayer5Id { get; set; }
        public string HomeStartingPlayer5Name { get; set; }
        public string HomeStartingPlayer5Pos { get; set; }
        public string HomeStartingPlayer6Id { get; set; }
        public string HomeStartingPlayer6Name { get; set; }
        public string HomeStartingPlayer6Pos { get; set; }
        public string HomeStartingPlayer7Id { get; set; }
        public string HomeStartingPlayer7Name { get; set; }
        public string HomeStartingPlayer7Pos { get; set; }
        public string HomeStartingPlayer8Id { get; set; }
        public string HomeStartingPlayer8Name { get; set; }
        public string HomeStartingPlayer8Pos { get; set; }
        public string HomeStartingPlayer9Id { get; set; }
        public string HomeStartingPlayer9Name { get; set; }
        public string HomeStartingPlayer9Pos { get; set; }
        public string AdditionalInformation { get; set; }
        public string AcquisitionInformation { get; set; }

    }


    public sealed class RetrosheetDataMap : ClassMap<RetrosheetGame>
    {
        public RetrosheetDataMap()
        {
            Map(m => m.Date).Index(0);
            Map(m => m.GameType).Index(1);
            Map(m => m.DayOfWeek).Index(2);
            Map(m => m.VisitingTeamName).Index(3);
            Map(m => m.VisitingTeamLeague).Index(4);
            Map(m => m.VisitingTeamGameNumber).Index(5);
            Map(m => m.HomeTeamName).Index(6);
            Map(m => m.HomeTeamLeague).Index(7);
            Map(m => m.HomeTeamGameNumber).Index(8);
            Map(m => m.VisitingTeamScore).Index(9);
            Map(m => m.HomeTeamScore).Index(10);
            Map(m => m.LengthOfGameInOuts).Index(11);
            Map(m => m.DayNightIndicator).Index(12);
            Map(m => m.CompletionInformation).Index(13);
            Map(m => m.ForfeitInformation).Index(14);
            Map(m => m.ProtestInformation).Index(15);
            Map(m => m.ParkId).Index(16);
            Map(m => m.Attendance).Index(17);
            Map(m => m.TimeOfGameInMinutes).Index(18);
            Map(m => m.VisitingLineScore).Index(19);
            Map(m => m.HomeLineScore).Index(20);
            Map(m => m.VisitingOffenseAtBats).Index(21);
            Map(m => m.VisitingOffenseHits).Index(22);
            Map(m => m.VisitingOffenseDoubles).Index(23);
            Map(m => m.VisitingOffenseTriples).Index(24);
            Map(m => m.VisitingOffenseHomeRuns).Index(25);
            Map(m => m.VisitingOffenseRBI).Index(26);
            Map(m => m.VisitingOffenseSacHits).Index(27);
            Map(m => m.VisitingOffenseSacHits).Index(28);
            Map(m => m.VisitingOffenseHitByPitch).Index(29);
            Map(m => m.VisitingOffenseWalks).Index(30);
            Map(m => m.VisitingOffenseIntentionalWalks).Index(31);
            Map(m => m.VisitingOffenseStrikeouts).Index(32);
            Map(m => m.VisitingOffenseStolenBases).Index(33);
            Map(m => m.VisitingOffenseCaughtStealing).Index(34);
            Map(m => m.VisitingOffenseGroundedIntoDP).Index(35);
            Map(m => m.VisitingOffenseCatcherInteference).Index(36);
            Map(m => m.VisitingOffenseLeftOnBase).Index(37);
            Map(m => m.VisitingPitchingPitchersUsed).Index(38);
            Map(m => m.VisitingPitchingIndividualEarnedRuns).Index(39);
            Map(m => m.VisitingPitchingTeamEarnedRuns).Index(40);
            Map(m => m.VisitingPitchingWildPitches).Index(41);
            Map(m => m.VisitingPitchingBalks).Index(42);
            Map(m => m.VisitingDefensePutouts).Index(43);
            Map(m => m.VisitingDefenseAssists).Index(44);
            Map(m => m.VisitingDefenseErrors).Index(45);
            Map(m => m.VisitingDefensePassedBalls).Index(46);
            Map(m => m.VisitingDefenseDoublePlays).Index(47);
            Map(m => m.VisitingDefenseTriplePlays).Index(48);
            Map(m => m.HomeOffenseAtBats).Index(49);
            Map(m => m.HomeOffenseHits).Index(50);
            Map(m => m.HomeOffenseDoubles).Index(51);
            Map(m => m.HomeOffenseTriples).Index(52);
            Map(m => m.HomeOffenseHomeRuns).Index(53);
            Map(m => m.HomeOffenseRBI).Index(54);
            Map(m => m.HomeOffenseSacHits).Index(55);
            Map(m => m.HomeOffenseSacFlies).Index(56);
            Map(m => m.HomeOffenseHitByPitch).Index(57);
            Map(m => m.HomeOffenseWalks).Index(58);
            Map(m => m.HomeOffenseIntentionalWalks).Index(59);
            Map(m => m.HomeOffenseStrikeouts).Index(60);
            Map(m => m.HomeOffenseStolenBases).Index(61);
            Map(m => m.HomeOffenseCaughtStealing).Index(62);
            Map(m => m.HomeOffenseGroundedIntoDP).Index(63);
            Map(m => m.HomeOffenseCatcherInteference).Index(64);
            Map(m => m.HomeOffenseLeftOnBase).Index(65);
            Map(m => m.HomePitchingPitchersUsed).Index(66);
            Map(m => m.HomePitchingIndividualEarnedRuns).Index(67);
            Map(m => m.HomePitchingTeamEarnedRuns).Index(68);
            Map(m => m.HomePitchingWildPitches).Index(69);
            Map(m => m.HomePitchingBalks).Index(70);
            Map(m => m.HomeDefensePutouts).Index(71);
            Map(m => m.HomeDefenseAssists).Index(72);
            Map(m => m.HomeDefenseErrors).Index(73);
            Map(m => m.HomeDefensePassedBalls).Index(74);
            Map(m => m.HomeDefenseDoublePlays).Index(75);
            Map(m => m.HomeDefenseTriplePlays).Index(76);
            Map(m => m.UmpireHomeId).Index(77);
            Map(m => m.UmpireHomeName).Index(78);
            Map(m => m.Umpire1BId).Index(79);
            Map(m => m.Umpire1BName).Index(80);
            Map(m => m.Umpire2BId).Index(81);
            Map(m => m.Umpire2BName).Index(82);
            Map(m => m.Umpire3BId).Index(83);
            Map(m => m.Umpire3BName).Index(84);
            Map(m => m.UmpireLFId).Index(85);
            Map(m => m.UmpireLFName).Index(86);
            Map(m => m.UmpireRFId).Index(87);
            Map(m => m.UmpireRFName).Index(88);
            Map(m => m.VisitingManagerId).Index(89);
            Map(m => m.VisitingManagerName).Index(90);
            Map(m => m.HomeManagerId).Index(91);
            Map(m => m.HomeManagerName).Index(92);
            Map(m => m.WinningPitcherId).Index(93);
            Map(m => m.WinningPitcherName).Index(94);
            Map(m => m.LosingPitcherId).Index(95);
            Map(m => m.LosingPitcherName).Index(96);
            Map(m => m.SavingPitcherId).Index(97);
            Map(m => m.SavingPitcherName).Index(98);
            Map(m => m.GameWinRBIBatterId).Index(99);
            Map(m => m.GameWinRBIBatterName).Index(100);
            Map(m => m.VisitingStartingPitcherId).Index(101);
            Map(m => m.VisitingStartingPitcherName).Index(102);
            Map(m => m.HomeStartingPitcherId).Index(103);
            Map(m => m.HomeStartingPitcherName).Index(104);
            Map(m => m.VisitingStartingPlayer1Id).Index(105);
            Map(m => m.VisitingStartingPlayer1Name).Index(106);
            Map(m => m.VisitingStartingPlayer1Pos).Index(107);
            Map(m => m.VisitingStartingPlayer2Id).Index(108);
            Map(m => m.VisitingStartingPlayer2Name).Index(109);
            Map(m => m.VisitingStartingPlayer2Pos).Index(110);
            Map(m => m.VisitingStartingPlayer3Id).Index(111);
            Map(m => m.VisitingStartingPlayer3Name).Index(112);
            Map(m => m.VisitingStartingPlayer3Pos).Index(113);
            Map(m => m.VisitingStartingPlayer4Id).Index(114);
            Map(m => m.VisitingStartingPlayer4Name).Index(115);
            Map(m => m.VisitingStartingPlayer4Pos).Index(116);
            Map(m => m.VisitingStartingPlayer5Id).Index(117);
            Map(m => m.VisitingStartingPlayer5Name).Index(118);
            Map(m => m.VisitingStartingPlayer5Pos).Index(119);
            Map(m => m.VisitingStartingPlayer6Id).Index(120);
            Map(m => m.VisitingStartingPlayer6Name).Index(121);
            Map(m => m.VisitingStartingPlayer6Pos).Index(122);
            Map(m => m.VisitingStartingPlayer7Id).Index(123);
            Map(m => m.VisitingStartingPlayer7Name).Index(124);
            Map(m => m.VisitingStartingPlayer7Pos).Index(125);
            Map(m => m.VisitingStartingPlayer8Id).Index(126);
            Map(m => m.VisitingStartingPlayer8Name).Index(127);
            Map(m => m.VisitingStartingPlayer8Pos).Index(128);
            Map(m => m.VisitingStartingPlayer9Id).Index(129);
            Map(m => m.VisitingStartingPlayer9Name).Index(130);
            Map(m => m.VisitingStartingPlayer9Pos).Index(131);
            Map(m => m.HomeStartingPlayer1Id).Index(132);
            Map(m => m.HomeStartingPlayer1Name).Index(133);
            Map(m => m.HomeStartingPlayer1Pos).Index(134);
            Map(m => m.HomeStartingPlayer2Id).Index(135);
            Map(m => m.HomeStartingPlayer2Name).Index(136);
            Map(m => m.HomeStartingPlayer2Pos).Index(137);
            Map(m => m.HomeStartingPlayer3Id).Index(138);
            Map(m => m.HomeStartingPlayer3Name).Index(139);
            Map(m => m.HomeStartingPlayer3Pos).Index(140);
            Map(m => m.HomeStartingPlayer4Id).Index(141);
            Map(m => m.HomeStartingPlayer4Name).Index(142);
            Map(m => m.HomeStartingPlayer4Pos).Index(143);
            Map(m => m.HomeStartingPlayer5Id).Index(144);
            Map(m => m.HomeStartingPlayer5Name).Index(145);
            Map(m => m.HomeStartingPlayer5Pos).Index(146);
            Map(m => m.HomeStartingPlayer6Id).Index(147);
            Map(m => m.HomeStartingPlayer6Name).Index(148);
            Map(m => m.HomeStartingPlayer6Pos).Index(149);
            Map(m => m.HomeStartingPlayer7Id).Index(150);
            Map(m => m.HomeStartingPlayer7Name).Index(151);
            Map(m => m.HomeStartingPlayer7Pos).Index(152);
            Map(m => m.HomeStartingPlayer8Id).Index(153);
            Map(m => m.HomeStartingPlayer8Name).Index(154);
            Map(m => m.HomeStartingPlayer8Pos).Index(155);
            Map(m => m.HomeStartingPlayer9Id).Index(156);
            Map(m => m.HomeStartingPlayer9Name).Index(157);
            Map(m => m.HomeStartingPlayer9Pos).Index(158);
            Map(m => m.AdditionalInformation).Index(159);
            Map(m => m.AcquisitionInformation).Index(160);
        }
    }

   // public class Retrosheet
   // {

  //      public string Id { get; set; }
   //     public string Something { get; set; }
        //public Retrosheet()
        //{

        //}
   // }
}
