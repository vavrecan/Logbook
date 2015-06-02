using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ServerTypes
{
    [Serializable]
    public class AdminEmployees
    {
        public Int32 id;
        public string user;
        public bool active;
		public Int32 type;
		public List<Company> companies;
    }

    [Serializable]
    public class AdminSession
    {
        public string username;
        public string pcname;
        public string realname;
        public DateTime activity;
        public string loggeduser;
        public Int32 loggedusergroup;
    }

    [Serializable]
    public class AdminSystemEvent
    {
        public Int32 id;
        public DateTime date;
        public string text;
        public Int32 type;
    }

    [Serializable]
    public class AdminDatabaseFiles
    {
        public string filename;
        public Int64 size;
        public DateTime created;
    }

    [Serializable]
    public class ConnectedUser
    {
        public string userName;
        public string pcName;
        public string ownerName;
		public string company;
    }

    [Serializable]
    public class LoginEmployee
    {
        public string userName;
        public Int32 cathegory;
        public bool canAccess;
		public List<Company> companies;
    }

	[Serializable]
	public class Company
	{
		public Int32 id;
		public string name;
	}

    [Serializable]
    public class Event
    {
        public Int32 id;
        public string data;
        public DateTime added;
        public DateTime date;
        public bool locked;
        public Int32 type;
        public string owner;
        public short turn;
        public short mark;
    }

    [Serializable]
    public class Failure
    {
        public Int32 id;
        public string name;
        public string owner;
        public string code;
        public string type;
        public string cause;
        public string description;
        public string notice;
        public Int32 level;
        public Int32 fix;
        public Boolean inprogress;
        public Boolean noticed;
        public DateTime noticedate;
        public DateTime start;
        public DateTime end;
    }

    [Serializable]
    public class SubEvent
    {
        public Int32 id;
        public string data;
        public DateTime added;
        public string owner;
        public Int32 parent;
        public Int32 type;
        public short mark;
    }

    [Serializable]
    public class InlineTable
    {
        public String Summary;
        public List<InlineTableRow> Rows;
        public List<String> RowsFormat;
        public List<String> RowsType;
        public InlineTable NextTable;
    }

    [Serializable]
    public class InlineTableRow
    {
        public List<String> Cells;
    }

    [Serializable]
    public struct StoredInlineTable
    {
        public InlineTable table;
        public String name;
    }

    [Serializable]
    public class NewTurn
    {
        public String Given;
        public String Received;
        public List<String> Avalible;
        public List<String> AvalibleOthers;
    }

    [Serializable]
    public class TimeExport
    {
        public Int32 Year;
        public Int32 EventsCount;
    }

    [Serializable]
    public static class Failures
    {
        public static string[] FailuresFixTranslated = 
        {             
            "Pri plánovanej odstávke",
            "V prípade výpadku celku",
            "Podľa voľných kapacít",
            "Do požadovaného termínu",
            "Okamžite"
        };

        public enum ReadFormat
        {
            Normal,
            Unnoticed,
            InProgress,
            LastTwoDays,
            Search
        }
        
        [Serializable]
        public struct Search
        {
            public string searchText;
            public string fromOwner;

            public bool includeCode;
            public bool includeType;
            public bool includeName;
            public bool includeCause;
            public bool includeDescription;

            public bool searchMinDate;
            public bool searchMaxDate;
            public DateTime minDate;
            public DateTime maxDate;

            public Int32 limit;
        }
    }

    [Serializable]
    public static class Events
    {
        public enum ReadFormat
        {
            LastTwoDays,
            UnlockedItems,
            SelectedDay,
            Range,
            Search,
            Turn,
            Selection
        }

        public enum ReadFilter
        {
            Normal,
            OnlySubEvents,
            OnlyMarked,
            OnlyMarkedSubEvents,
            OnlyEvents,
            OnlyTurnSwitchs,
            OnlyTables
        }

        [Serializable]
        public struct IDRange
        {
            public Int32 start;
            public Int32 end;
        }

        [Serializable]
        public struct Range
        {
            public Int32 start;
            public Int32 lenght;
        }

        [Serializable]
        public struct TurnWay
        {
            public Int32 id;
            public Boolean back;
        }

        [Serializable]
        public struct Search
        {
            public string searchText;
            public string fromOperator;
            public bool searchMinDate;
            public bool searchMaxDate;
            public DateTime minDate;
            public DateTime maxDate;
            public bool includeComments;
            public bool includeCommands;
            public bool includeEvents;
            public bool[] searchTurns;
            public Int32 limit;
        }
    }

    public static class Employees
    {
        public enum EmployeesCathegory
        {
            MainOperator,
            SubOperator,
            WatchDog,
            Other,
            Administrator,
			Dispatcher,
        }

        public static string[] EmployeesTranslated = 
        {
            "Zmenový inžinier",
            "Operátor",
            "Kontrola", 
            "Nezaradený",
            "Správca",
			"Dispečer"
        };
    }
        
    public enum Permission
    {
        EventsRead,
        EventsLock,
        EventsAdd,
        EventsDelete,
        EventsUpdate,
        EventsMark,
        EventsAddComment,
        EventsAddCommand,
        EventsDeleteComment,
        EventsDeleteCommand,
        EventsUpdateComment,
        EventsUpdateCommand,
        FailuresRead,
        FailuresAdd,
        FailuresDelete,
        FailuresSetFix,
        FailuresNotice,
        FailuresUpdate,
        OthersChangePassword,
        InlineTableRead,
        InlineTableAdd,
        InlineTableDelete,
        None
    }
    
    [Serializable]
    public static class Permissions
    {
        public static Dictionary<string, string> PermissionTranslated = new Dictionary<string,string>()
        {
            {Permission.EventsRead.ToString(),           "Zobraziť"},
            {Permission.EventsLock.ToString(),           "Zamknúť"},
            {Permission.EventsAdd.ToString(),            "Pridať"},
            {Permission.EventsDelete.ToString(),         "Zmazať"},
            {Permission.EventsUpdate.ToString(),         "Upraviť"},
            {Permission.EventsMark.ToString(),           "Zvýrazniť"},
            {Permission.EventsAddComment.ToString(),     "Pridať poznámku"},
            {Permission.EventsAddCommand.ToString(),     "Pridať príkaz"},
            {Permission.EventsDeleteComment.ToString(),  "Zmazať poznámku"},
            {Permission.EventsDeleteCommand.ToString(),  "Zmazať príkaz"},
            {Permission.EventsUpdateComment.ToString(),  "Upraviť poznámku"},
            {Permission.EventsUpdateCommand.ToString(),  "Upraviť príkaz"},
            {Permission.FailuresRead.ToString(),         "Zobraziť"},
            {Permission.FailuresAdd.ToString(),          "Pridať"},
            {Permission.FailuresDelete.ToString(),       "Zmazať"},
            {Permission.FailuresSetFix.ToString(),       "Nastaviť opravu"},
            {Permission.FailuresNotice.ToString(),       "Zobrať na vedomie"},
            {Permission.FailuresUpdate.ToString(),       "Upraviť"},
            {Permission.OthersChangePassword.ToString(), "Zmeniť heslo"},
            {Permission.InlineTableRead.ToString(),      "Zobraziť"},
            {Permission.InlineTableAdd.ToString(),       "Pridať"},
            {Permission.InlineTableDelete.ToString(),    "Zmazať"}
        };
    }
}
