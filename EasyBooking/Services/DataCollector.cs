using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyBooking.Data;
using EasyBooking.Models.ViewModels;
using EasyBooking.Models;

namespace EasyBooking.Services
{
    public class DataCollector
    {
        Dictionary<string, string> AiportsDictionary = new Dictionary<string, string>
            {
                {"INNSBRUCK", "INN"},
                {"LINZ", "LNZ"},
                {"SALZBURG", "SZG"},
                {"VIENNA", "VIE"},
                {"BRUSSELS", "BRU"},
                {"CHARLEROI", "CRL"},
                {"OSTENDBELGIUM", "OST"},
                {"BANJA LUKA", "BNX"},
                {"BURGAS", "BOJ"},
                {"PLOVDIV", "PDV"},
                {"SOFIA", "SOF"},
                {"VARNA", "VAR"},
                {"OSIJEK", "OSI"},
                {"PULA", "PUY"},
                {"RIJEKA", "RJK"},
                {"ZADAR", "ZAD"},
                {"PAPHOS", "PFO"},
                {"LARNACA", "LCA"},
                {"BRNO", "BRQ"},
                {"OSTRAVA", "OSR"},
                {"PARDUBICE", "PED"},
                {"PRAGUE", "PRG"},
                {"AALBORG", "AAL"},
                {"AARHUS", "AAR"},
                {"BILLUND", "BLL"},
                {"COPENHAGEN", "CPH"},
                {"TALLINN", "TLL"},
                {"TAMPERE", "TMP"},
                {"LAPPEENRANTA", "LPP"},
                {"BERGERAC", "EGC"},
                {"BÉZIERS", "BZR"},
                {"BIARRITZ", "BIQ"},
                {"BORDEAUX", "BOD"},
                {"BREST", "BES"},
                {"BRIVE-LA-GAILLARDE", "BVE"},
                {"CARCASSONNE", "CCF"},
                {"CLERMONT-FERRAND", "CFE"},
                {"DEAUVILLE", "DOL"},
                {"DOLE", "DLE"},
                {"FIGARI", "FSC"},
                {"GRENOBLE", "GNB"},
                {"LA ROCHELLE", "LRH"},
                {"LILLE", "LIL"},
                {"LIMOGES", "LIG"},
                {"LORIENT", "LRT"},
                {"LOURDES", "LDE"},
                {"LYON", "LYS"},
                {"MARSEILLE", "MRS"},
                {"MONTPELLIER", "MPL"},
                {"NICE", "NCE"},
                {"NÎMES", "FNI"},
                {"PARIS", "BVA"},
                {"PERPIGNAN", "PGF"},
                {"POITIERS", "PIS"},
                {"RODEZ", "RDZ"},
                {"SAINT-ÉTIENNE", "EBU"},
                {"SAINT-MALO", "DNR"},
                {"STRASBOURG", "SXB"},
                {"TOULOUSE", "TLS"},
                {"TOURS", "TUF"},
                {"BERLIN", "SXF"},
                {"BREMEN", "BRE"},
                {"COLOGNE", "CGN"},
                {"DORTMUND", "DTM"},
                {"DÜSSELDORF", "DUS"},
                {"HAMBURG", "HAM"},
                {"HANNOVER", "HAJ"},
                {"KARLSRUHE", "FKB"},
                {"LEIPZIG", "LEJ"},
                {"MEMMINGEN", "FMM"},
                {"MUNICH", "MUC"},
                {"MÜNSTER", "FMO"},
                {"NUREMBERG", "NUE"},
                {"PADERBORN", "PAD"},
                {"STUTTGART", "STR"},
                {"CEPHALONIA", "EFL"},
                {"CHANIA", "CHQ"},
                {"CORFU", "CFU"},
                {"HERAKLION", "HER"},
                {"KALAMATA", "KLX"},
                {"KOS", "KGS"},
                {"MYKONOS", "JMK"},
                {"RHODES", "RHO"},
                {"SANTORINI", "JTR"},
                {"THESSALONIKI", "SKG"},
                {"BUDAPEST", "BUD"},
                {"CORK", "ORK"},
                {"DUBLIN", "DUB"},
                {"GALWAY", "GWY"},
                {"KERRY", "KIR"},
                {"KNOCK", "NOC"},
                {"SHANNON", "SNN"},
                {"WATERFORD", "WAT"},
                {"EILAT", "VDA"},
                {"TEL AVIV", "TLV"},
                {"ALGHERO", "AHO"},
                {"ANCONA", "AOI"},
                {"BARI", "BRI"},
                {"BOLOGNA", "BLQ"},
                {"CAGLIARI", "CAG"},
                {"CATANIA", "CTA"},
                {"COMISO", "CIY"},
                {"CROTONE", "CRV"},
                {"CUNEO", "CUF"},
                {"GENOA", "GOA"},
                {"LAMEZIA TERME", "SUF"},
                {"MILAN", "MXP"},
                {"NAPLES", "NAP"},
                {"OLBIA", "OLB"},
                {"PALERMO", "PMO"},
                {"RIMINI", "RMI"},
                {"ROME", "CIA"},
                {"TRAPAN", "TPS"},
                {"TRIESTE", "TRS"},
                {"TURIN", "TRN"},
                {"VENICE", "VCE"},
                {"VERONA", "VRN"},
                {"VALLETTA", "MLA"},
                {"PODGORICA", "TGD"},
                {"AGADIR", "AGA"},
                {"FEZ", "FEZ"},
                {"MARRAKESH", "RAK"},
                {"NADOR", "NDR"},
                {"OUJDA", "OUD"},
                {"RABAT", "RBA"},
                {"TANGIER", "TNG"},
                {"AMSTERDAM", "AMS"},
                {"EINDHOVEN", "EIN"},
                {"MAASTRICHT", "MST"},
                {"HAUGESUND", "HAU"},
                {"OSLO", "OSL"},
                {"BYDGOSZCZ", "BZG"},
                {"GDAŃSK", "GDN"},
                {"KATOWICE", "KTW"},
                {"KRAKÓW", "KRK"},
                {"ŁÓDŹ", "LCJ"},
                {"LUBLIN", "LUZ"},
                {"OLSZTYN","SZY"},
                {"POZNAŃ", "POZ"},
                {"RZESZÓW", "RZE"},
                {"SZCZECIN", "SZZ"},
                {"WARSAW", "WAW"},
                {"WROCŁAW", "WRO"},
                {"FARO", "FAO"},
                {"LISBON", "LIS"},
                {"PONTA DELGADA", "PDL"},
                {"PORTO", "OPO"},
                {"TERCEIRA", "TER"},
                {"BUCHAREST", "OTP"},
                {"CRAIOVA", "CRA"},
                {"ORADEA", "OMR"},
                {"TIMIȘOARA", "TSR"},
                {"NIŠ", "INI"},
                {"BRATISLAVA", "BTS"},
                {"A CORUÑA", "LCG"},
                {"ALICANTE", "ALC"},
                {"ALMERÍA", "LEI"},
                {"BARCELONA", "BCN"},
                {"BILBAO BIO CASTELLÓN", "CDT"},
                {"CIUDAD REAL", "CQM"},
                {"FUERTEVENTURA", "FUE"},
                {"GIRONA", "GRO"},
                {"GRAN CANARIA", "LPA"},
                {"IBIZA", "IBZ"},
                {"JEREZ DE LA FRONTERA", "XRY"},
                {"LANZAROTE", "ACE"},
                {"MADRID", "MAD"},
                {"MÁLAGA", "AGP"},
                {"MENORCA", "MAH"},
                {"MURCIA", "MJV"},
                {"PALMA DE MALLORCA", "PMI"},
                {"REUS", "REU"},
                {"SANTANDER", "SDR"},
                {"SANTIAGO DE COMPOSTELA", "SCQ"},
                {"SEVILLE", "SVQ"},
                {"TENERIFE", "TFN"},
                {"VALENCIA", "VLC"},
                {"VALLADOLID", "VLL"},
                {"VIGO", "VGO"},
                {"VITORIA", "VIT"},
                {"ZARAGOZA", "ZAZ"},
                {"GOTHENBURG", "GOT"},
                {"MALMÖ", "MMX"},
                {"STOCKHOLM", "NYO"},
                {"VÄXJÖ", "VXO"},
                {"BASEL / MULHOUSE", "BSL"},
                {"ZURICH", "ZRH"},
                {"DALAMAN", "DLM"},
                {"KYIV", "KBP"},
                {"LVIV", "LWO"},
                {"ABERDEEN", "ABZ"},
                {"BELFAST", "BFS"},
                {"BIRMINGHAM", "BHX"},
                {"BOURNEMOUTH", "BOH"},
                {"BRISTOL", "BRS"},
                {"CARDIFF", "CWL"},
                {"DERRY", "LDY"},
                {"EAST MIDLANDS", "EMA"},
                {"EDINBURGH", "EDI"},
                {"GLASGOW", "GLA"},
                {"LEEDS / BRADFORD", "LBA"},
                {"LIVERPOOL", "LPL"},
                {"LONDON", "LGW"},
                {"LONDONUNITED KINGDOM", "STN"},
                {"MANCHESTER", "MAN"},
                {"NEWCASTLE", "NCL"},
                {"NEWQUAY", "NQY"}
            };

        public List<Flight> GetFromRyanair(DateTime ArrivalDate, string fromCity, string toCity)
        {
            List<ScheduleFlight> ScheduleFlights = GetSchedule(ArrivalDate, fromCity, toCity);

            List<RyanairFlight> rFlights = GetFlights(ScheduleFlights);


            return rFlights.Select(f => new Flight(f, ArrivalDate)).ToList();

        }
        private List<RyanairFlight> GetFlights(List<ScheduleFlight> ScheduleFlights)
        {
            List<string> adresses = ScheduleFlights.Select(d =>
            {
                return string.Format(
                     "https://api.ryanair.com/flightinfo/3/flights/?" +
                     "number={0}",
                     Uri.EscapeDataString(d.Number.ToString()));
            }).ToList();

            using (WebClient client = new WebClient())
            {
                List<RyanairFlight> result = new List<RyanairFlight>();
                foreach (var a in adresses)
                {
                    var f = DeserializeRyanairResponse.FromJson(client.DownloadString(a)).Flights;
                    if (f.Count() > 0)
                    {
                        result.Add(f.First());
                    }
                }
                return result;
            }
        }
        private List<ScheduleFlight> GetSchedule(DateTime ArrivalDate, string fromCity, string toCity)
        {
            string scheduleAddress = string.Format(
              "https://api.ryanair.com/timetable/3/schedules/" +
              "{0}/" +
              "{1}/" +
              "years/{2}/" +
              "months/{3}",
              Uri.EscapeDataString(AiportsDictionary[fromCity.ToUpper()]),
              Uri.EscapeDataString(AiportsDictionary[toCity.ToUpper()]),
              Uri.EscapeDataString(ArrivalDate.Year.ToString()),
              Uri.EscapeDataString(ArrivalDate.Month.ToString())
            );
            string text;
            using (WebClient client = new WebClient())
            {
                text = client.DownloadString(scheduleAddress);
                RyanairSchedule rr = DeserializeRyanairScheduleResponseConverter.FromJson(text);
                var v = rr.Days.Where(d => d.DayDay.Equals(ArrivalDate.Day));
                List<ScheduleFlight> result = new List<ScheduleFlight>();
                if (v.Count() > 0)
                {
                    result = rr.Days.Where(d => d.DayDay.Equals(ArrivalDate.Day)).First().ScheduleFlights;
                }


                return result;
            }
        }
    }
}
