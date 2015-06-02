using System;
using System.Collections.Generic;
using System.Text;
using ServerTypes;

namespace ServerInterface
{
    public interface IServerAdministrationInterface
    {
        Boolean Started(String Password);
        void Start(String Password);
        void Stop(String Password);
        List<AdminSession> GetSessions(String Password);
        List<AdminSystemEvent> GetSystemEvents(String Password, AdminSystemEvent LastItem);

        Boolean CheckLogin(String Password);

        void SetDBPath(String Password, String DBPath);
        void SetPort(String Password, Int32 Port);
        void SetTimeout(String Password, Int32 Timeout);
        void Vacuum(String Password);

        String GetDBPath(String Password);
        Int32 GetPort(String Password);
        Int32 GetTimeout(String Password);

        List<AdminEmployees> GetEmployees(String Password);
        List<Permission> GetEmployeePermissions(String Password, Int32 Employee);

        void CleanSessions(String Password);
        void ChangePassword(String OldPassword, String NewPassword);
        void NewEmployee(String Password, String Employee, String EmployeePassword, Boolean Active, Int32 EmployeeType);
        void ChangeEmployeePassword(String Password, Int32 employee, String NewPassword);
        void DeleteEmployee(String Password, Int32 Employee);
        void SetEmployeeAccess(String Password, Int32 Employee, Boolean Access);
        void SetEmployeePermissions(String Password, Int32 Employee, List<Permission> permissions);
        void ResetEmployeePermissions(String Password, Int32 Employee);

        List<Company> GetCompanies(String Password);

        void NewCompany(String Password, String Name);
        void DeleteCompany(String Password, Int32 Company);
        void ChangeCompanyName(String Password, Int32 Company, String Name);

        Company GetUnloggedUserCompany(String Password);
        void SetUnloggedUserCompany(String Password, Int32 Company);

        List<Company> GetEmployeeCompanies(String Password, Int32 Employee);
        void SetEmployeeCompanies(String Password, Int32 Employee, List<Company> Companies);

        List<AdminDatabaseFiles> GetDatabases(String Password);
        string GetChecksum(String Password, String FileName);

        byte [] DownloadChunk(String Password, String FileName, Int32 ChunkOffset);
        Int32 DownloadChunkLength(String Password, String FileName);
        Int32 DownloadFileLength(String Password, String FileName);

        void UploadPrepare(String Password, String FileName);
        void UploadChunk(String Password, String FileName, byte[] Data);
        void UploadFinalize(String Password, String FileName, String CheckSum);

        List<TimeExport> GetTimeExports(String Password);
        void ExportTime(String Password, Int32 Year);
        void ClearTime(String Password, Int32 Year);

        byte[] GetCompanyLogo(String Password, Int32 Company);
        void SetCompanyLogo(String Password, Int32 Company, byte[] image);
        void DeleteCompanyLogo(String Password, Int32 Company);
    }

    public interface IServerInterface 
    {
        String GetSession(String UserName, String ComputerName, String RealName);
        Company GetCompany(String Session);
        byte[] GetCompanyLogo(String Session);

        Boolean IsSessionValid(String hash);
        Boolean Ping(String Session);
        List<ConnectedUser> GetConnectedUsers();
        List<LoginEmployee> GetEmployees(Boolean CanAccess);
        List<Permission> GetPermissions(String Session);

        Boolean LoginEmployee(String Session, String UserName, Int32 Group, String Password, Int32 Company);
        void LogoutEmployee(String Session);
        void ChangePassword(String Session, String OldPassword, String NewPassword);
        void LockDatabase(String Session);

        List<Event> GetEvents(String Session, Events.ReadFormat Format, object Argument, out Int32 MaxID, Events.ReadFilter Filter, out Boolean IsMin, out Boolean IsMax);
        String LastEventEmployee(String Session);
        Int32 GetRows(String Session, Events.ReadFilter Filter);
        Int16 GetLastTurn(String Session);

        void AddEvent(String Session, String Data, DateTime EventDate, Int32 Type, Int16 Turn);
        void DeleteEvent(String Session, Int32 ID);
        void LockEvent(String Session, Int32 ID);
        void UpdateEvent(String Session, Event ev);
        void MarkupEvent(String Session, Int32 ID, Int32 Mark);

        List<SubEvent> GetSubEvents(String Session, List<Int32> parentID);
        void AddSubEvent(String Session, SubEvent cm);
        void DeleteSubEvent(String Session, Int32 ID);
        void UpdateSubEvent(String Session, SubEvent cm);

        List<Failure> GetFailures(String Session, Failures.ReadFormat format, Failures.Search Search, Events.Range range);
        Int32 GetRowsFailures(String Session, Failures.ReadFormat format, Failures.Search Search);
        Int32 GetRowsFailuresInProgress(String Session);

        void AddFailure(String Session, Failure failure);
        void SetFailureFix(String Session, Int32 ID, Int32 fix);
        void DeleteFailure(String Session, Int32 ID);
        void UpdateFailure(String Session, Failure failure);
        void NoticeFailure(String Session, Int32 ID);

        List<StoredInlineTable> GetInlineTables(String Session);
        void AddInlineTable(String Session, StoredInlineTable sTable);
        void RemoveInlineTable(String Session, String Name);
    }
}
