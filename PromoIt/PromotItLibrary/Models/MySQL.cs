using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PromotItLibrary.Models
{
    public class MySQL
    {
        private string _server;
        private string _userId;
        private string _password;
        private string _dataBase;

        private MySqlCommand Cmd { get; set; }
        private string Stm { get; set; }
        private MySqlDataReader Rdr { get; set; }
        private MySqlDataAdapter Dar { get; set; } //Sync
        private MySqlConnection Con { get; set; }

        //Connection string get\set
        public string Server { get { return _server; } set { _server = value; ConnectionReset(); } }
        public string UserId { get { return _userId; } set { _userId = value; ConnectionReset(); } }
        public string Password { private get { return _password; } set { _password = value; ConnectionReset(); } }
        public string DataBase { get { return _dataBase; } set { _dataBase = value; ConnectionReset(); } }

        /// <summary>
        /// Tries Counter
        /// </summary>
        private static int _tries = TriesReset();
        private static int Tries { get { return _tries; } set { _tries = value; } }
        public static int TriesReset() { Tries = 0; return _tries; }
        public static bool IsTries(int maxTries = 3, int sleepBetWeenTries = 500) { Task.Delay(sleepBetWeenTries * _tries); return Tries++ < maxTries; }    //Number of tries is 3//between tries 500ms

        public MySQL(string server, string userId, string password, string dataBase)
        {
            (Server, UserId, Password, DataBase) = (server, userId, password, dataBase);
            try { ConnectionOpen(); } catch { Console.WriteLine($"Connection Error\n"); }
        }
        ~MySQL() => ConnectClose();

        public void Procedure(string proc) { Quary(proc); Procedure(); }
        public void Procedure() { if (Cmd != null) Cmd.CommandType = CommandType.StoredProcedure; }
        public void ProcedureParameter<T>(string name, T value) => SetParameter<T>(name, value);

        public bool ProceduteExecute() =>  QuaryExecute();
        public async Task<bool> ProceduteExecuteAsync() => await QuaryExecuteAsync();

        public void Quary(string stmQuary) { Stm = stmQuary; SetCmd(); }
        public void SetQuary(string stmQuary) => Quary(stmQuary);

        public void QuaryParameter<T>(string name, T value) => SetParameter(name, value);
        public void SetParameter<T>(string name, T value) => Cmd?.Parameters.AddWithValue(name, value);

        public  MySqlDataReader ProceduteExecuteMultyResults() =>  GetQueryMultyResults();
        public async Task<MySqlDataReader> ProceduteExecuteMultyResultsAsync() => await GetQueryMultyResultsAsync();

        public bool QuaryExecute(string stmQuary) { Quary(stmQuary); return QuaryExecute(); }
        public async Task<bool> QuaryExecuteAsync(string stmQuary) { Quary(stmQuary); return await QuaryExecuteAsync(); }

        public bool QuaryExecute()  // inserts
        {
            try
            {
                if (Stm == null) { Console.WriteLine("No Quary"); return false; }
                if (Cmd?.CommandType == CommandType.StoredProcedure) { } //procedure
                else if (Cmd?.Parameters.Count > 0) Cmd?.Prepare(); //parametars
                else if (Cmd != null) Cmd.CommandText = Stm; //insert quary
                int? outPut = Cmd?.ExecuteNonQuery();
                if (outPut == null && outPut <= 0)
                {
                    while (IsTries()) return QuaryExecute();
                    TriesReset();
                    NullifiedValues();
                    return false;
                }
                TriesReset();
                NullifiedValues();
                return true;
            }
            catch { }
            TriesReset();
            NullifiedValues();
            return false;
        }
        public async Task<bool> QuaryExecuteAsync()  // inserts
        {
            try
            {
                if (Stm == null) { Console.WriteLine("No Quary"); return false; }
                if (Cmd?.CommandType == CommandType.StoredProcedure) { } //procedure
                else if (Cmd?.Parameters.Count > 0) Cmd?.Prepare(); //parametars
                else if (Cmd != null) Cmd.CommandText = Stm; //insert quary
                int? outPut = await Cmd?.ExecuteNonQueryAsync();
                if (outPut == null && outPut <= 0)
                {
                    while ( IsTries() )  return await QuaryExecuteAsync();
                    TriesReset();
                    NullifiedValues();
                    return false;
                }
                TriesReset();
                NullifiedValues();
                return true;
            }
            catch { }
            TriesReset();
            NullifiedValues();
            return false;
        }

        public MySqlDataReader GetQueryMultyResults() // selects
        {
            try
            {
                while (IsTries())
                {
                    using MySqlDataReader rdr = Rdr;
                    Rdr =  Cmd?.ExecuteReader();
                    if (Rdr == null)
                        return  GetQueryMultyResults();
                    TriesReset();
                    NullifiedValues();
                    return Rdr;
                }
            }
            catch { return GetQueryMultyResults(); }
            TriesReset();
            return null;
        }
        public async Task<MySqlDataReader> GetQueryMultyResultsAsync() // selects
        {
            try
            {
                while (IsTries())
                {
                    using MySqlDataReader rdr = Rdr;
                    Rdr = (MySqlDataReader)await Cmd?.ExecuteReaderAsync();
                    if (Rdr == null)
                        return await GetQueryMultyResultsAsync();
                    TriesReset();
                    NullifiedValues();
                    return Rdr;
                }
            }
            catch { return await GetQueryMultyResultsAsync(); }
            TriesReset();
            return null;
        }

        public MySqlDataAdapter QuaryDataAdapter()
        {
            try
            {
                while (IsTries())
                {
                    using MySqlDataAdapter dar = Dar;
                    Dar = new MySqlDataAdapter(Cmd);
                    if (Dar == null)
                        return  QuaryDataAdapter();
                    TriesReset();
                    NullifiedValues();
                    return dar;
                }
            }
            catch { return  QuaryDataAdapter(); }
            TriesReset();
            return null;
        }
        public async Task<MySqlDataAdapter> QuaryDataAdapterAsync()
        {
            try
            {
                while (IsTries())
                {
                    using MySqlDataAdapter dar = Dar;
                    Dar = new MySqlDataAdapter(Cmd);
                    if (Dar == null)
                        return await QuaryDataAdapterAsync();
                    TriesReset();
                    NullifiedValues();
                    return dar;
                }
            }
            catch { return await QuaryDataAdapterAsync(); }
            TriesReset();
            return null;
        }

        public string QuaryScalarExecuteAsync() { if (Stm == null) return "NoQuery"; string output = Cmd?.ExecuteScalar().ToString(); NullifiedValues(); return output; } //1 value data as string
        public async Task<string> QuaryScalarExecute() { if (Stm == null) return "NoQuery"; string output = (await Cmd?.ExecuteScalarAsync()).ToString(); NullifiedValues(); return output; } //1 value data as string

        public void ConnectClose() { if (Con != null && Con.State == ConnectionState.Open) { NullifiedValues(); Rdr = null; Con.Close(); } } //close connection to database
        private void SetCmd() => Cmd = ((Stm, Cmd) != (null, null) ? new MySqlCommand(Stm, Con) : null);
        private void NullifiedValues() { (Stm, Cmd) = (null, null); } //myview = null; //Check if you can dispose some of theme
        private string ConnectionString()
            => Server != null && UserId != null && Password != null && DataBase != null ? @$"server={Server};userid={UserId};password={Password};database={DataBase}" : null;
        private void ConnectionOpen()
        {
            if (ConnectionString() == null || Con != null && Con?.State != ConnectionState.Closed) { Console.WriteLine("Connection Fail: No connection sting"); return; }
            Con = new MySqlConnection(ConnectionString()); Con.Open(); SetCmd();
        }
        public void ConnectionReset() { if (Con != null && Con.State == ConnectionState.Open) { ConnectClose(); ConnectionOpen(); } } // recheck

    }
}