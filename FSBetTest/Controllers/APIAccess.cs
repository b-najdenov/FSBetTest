using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace FSBetTest.Controllers
{
    public class APIAccess
    {

        public static async Task<RootObject> fetchApi()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.fifa.com/api/v1/calendar/matches");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            RootObject rootObject = null;
            HttpResponseMessage response = client.GetAsync($"?idseason=254645&idcompetition=17&language=en-GB&count=3").Result;

            if (response.IsSuccessStatusCode)
            {
                rootObject = response.Content.ReadAsAsync<RootObject>().Result;
            }

            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return rootObject;
        }
    }

    public class TypeLocalized
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class Weather
    {
        public string Humidity { get; set; }
        public string Temperature { get; set; }
        public string WindSpeed { get; set; }
        public int Type { get; set; }
        public List<TypeLocalized> TypeLocalized { get; set; }
    }

    public class StageName
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class GroupName
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class CompetitionName
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class TeamName
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class Home
    {
        public int Score { get; set; }
        public object Side { get; set; }
        public string IdTeam { get; set; }
        public string PictureUrl { get; set; }
        public string IdCountry { get; set; }
        public string Tactics { get; set; }
        public int TeamType { get; set; }
        public int AgeType { get; set; }
        public List<TeamName> TeamName { get; set; }
        public int FootballType { get; set; }
        public int Gender { get; set; }
    }

    public class TeamName2
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class Away
    {
        public int Score { get; set; }
        public object Side { get; set; }
        public string IdTeam { get; set; }
        public string PictureUrl { get; set; }
        public string IdCountry { get; set; }
        public string Tactics { get; set; }
        public int TeamType { get; set; }
        public int AgeType { get; set; }
        public List<TeamName2> TeamName { get; set; }
        public int FootballType { get; set; }
        public int Gender { get; set; }
    }

    public class Name
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class CityName
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class Properties
    {
        public string IdCBS { get; set; }
        public string IdIFES { get; set; }
    }

    public class Stadium
    {
        public string IdStadium { get; set; }
        public List<Name> Name { get; set; }
        public object Capacity { get; set; }
        public object WebAddress { get; set; }
        public object Built { get; set; }
        public bool Roof { get; set; }
        public object Turf { get; set; }
        public string IdCity { get; set; }
        public List<CityName> CityName { get; set; }
        public string IdCountry { get; set; }
        public object PostalCode { get; set; }
        public object Street { get; set; }
        public object Email { get; set; }
        public object Fax { get; set; }
        public object Phone { get; set; }
        public object AffiliationCountry { get; set; }
        public object AffiliationRegion { get; set; }
        public object Latitude { get; set; }
        public object Longitude { get; set; }
        public object Length { get; set; }
        public object Width { get; set; }
        public Properties Properties { get; set; }
        public object IsUpdateable { get; set; }
    }

    public class BallPossession
    {
        public List<object> Intervals { get; set; }
        public List<object> LastX { get; set; }
        public decimal OverallHome { get; set; }
        public decimal OverallAway { get; set; }
    }

    public class NameShort
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class Name2
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class TypeLocalized2
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class Official
    {
        public string IdCountry { get; set; }
        public string OfficialId { get; set; }
        public List<NameShort> NameShort { get; set; }
        public List<Name2> Name { get; set; }
        public int OfficialType { get; set; }
        public List<TypeLocalized2> TypeLocalized { get; set; }
    }

    public class Properties2
    {
        public string IdCBS { get; set; }
        public string IdIFES { get; set; }
    }

    public class Result
    {
        public string IdCompetition { get; set; }
        public string IdSeason { get; set; }
        public string IdStage { get; set; }
        public string IdGroup { get; set; }
        public Weather Weather { get; set; }
        public string Attendance { get; set; }
        public string IdMatch { get; set; }
        public string MatchDay { get; set; }
        public List<StageName> StageName { get; set; }
        public List<GroupName> GroupName { get; set; }
        public List<CompetitionName> CompetitionName { get; set; }
        public DateTime Date { get; set; }
        public DateTime LocalDate { get; set; }
        public Home Home { get; set; }
        public Away Away { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public int AggregateHomeTeamScore { get; set; }
        public int AggregateAwayTeamScore { get; set; }
        public int HomeTeamPenaltyScore { get; set; }
        public int AwayTeamPenaltyScore { get; set; }
        public object LastPeriodUpdate { get; set; }
        public object Leg { get; set; }
        public object IsHomeMatch { get; set; }
        public Stadium Stadium { get; set; }
        public object IsTicketSalesAllowed { get; set; }
        public string MatchTime { get; set; }
        public object SecondHalfTime { get; set; }
        public object FirstHalfTime { get; set; }
        public object FirstHalfExtraTime { get; set; }
        public object SecondHalfExtraTime { get; set; }
        public string Winner { get; set; }
        public object MatchReportUrl { get; set; }
        public string PlaceHolderA { get; set; }
        public string PlaceHolderB { get; set; }
        public BallPossession BallPossession { get; set; }
        public List<Official> Officials { get; set; }
        public int MatchStatus { get; set; }
        public int ResultType { get; set; }
        public int MatchNumber { get; set; }
        public bool TimeDefined { get; set; }
        public int OfficialityStatus { get; set; }
        public Properties2 Properties { get; set; }
        public object IsUpdateable { get; set; }
    }

    public class RootObject
    {
        public object ContinuationToken { get; set; }
        public object ContinuationHash { get; set; }
        public List<Result> Results { get; set; }
    }
}