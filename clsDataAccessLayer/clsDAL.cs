using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace clsDataAccessLayer
{
    public class clsDAL
    {
        //People
        public static DataTable GetAllInfoPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = "Select * From People";
            SqlCommand command = new SqlCommand(query, connection); ;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch
            {
                //
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static bool IsPersontUsed(int prodId)
        {
            bool isUsed = false;
            SqlConnection con = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Select top 1 1 from Applications where ApplicantPersonID = @pId";
            SqlCommand cmn = new SqlCommand(query, con);
            cmn.Parameters.AddWithValue("@pId", prodId);
            try
            {
                con.Open();
                object result = cmn.ExecuteScalar();
                isUsed = (result != null);
            }
            catch
            {
                //
            }
            finally
            {
                con.Close();
            }
            return isUsed;
        }
        public static bool FoundPersonByID(int id, ref string National, ref string First, ref string Second, ref string third, ref string Last, ref DateTime dateofbirth, ref int gendor, ref string adress, ref string phone, ref string email, ref int Nationalcountry, ref string imagePath)
        {
            bool found = false;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Select PersonID,NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID,ImagePath
                             From People where PersonID = @ID";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@ID", id);
            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    found = true;
                    reader.Read();
                    National = reader["NationalNo"].ToString();
                    First = reader["FirstName"].ToString();
                    Second = reader["SecondName"].ToString();
                    third = reader["ThirdName"].ToString();
                    Last = reader["LastName"].ToString();
                    dateofbirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    gendor = Convert.ToInt32(reader["Gendor"]);
                    adress = reader["Address"].ToString();
                    phone = reader["Phone"].ToString();
                    email = reader["Email"].ToString();
                    Nationalcountry = Convert.ToInt32(reader["NationalityCountryID"]);
                    imagePath = reader["ImagePath"].ToString();
                }
                reader.Close();
            }
            catch
            {
                //
            }
            finally
            {
                cn.Close();
            }

            return found;
        }
        public static bool AddNewPerson(string nat, string fn, string sn, string tn, string ln, DateTime db, int g, string a, string p, string e, int natc, string ip)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Insert into People(NationalNo , FirstName , SecondName,ThirdName,LastName,DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID,ImagePath)
                             Values (@national,@first,@second,@third,@last,@date,@gendor,@address,@phone,@email,@nationalcountry,@imagepath)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@national", nat);
            command.Parameters.AddWithValue("@first", fn);
            command.Parameters.AddWithValue("@second", sn);
            command.Parameters.AddWithValue("@third", tn);
            command.Parameters.AddWithValue("@last", ln);
            command.Parameters.AddWithValue("@date", db);
            command.Parameters.AddWithValue("@gendor", g);
            command.Parameters.AddWithValue("@address", a);
            command.Parameters.AddWithValue("@phone", p);
            command.Parameters.AddWithValue("@email", e);
            command.Parameters.AddWithValue("@nationalcountry", natc);
            if (!string.IsNullOrEmpty(ip))
                command.Parameters.AddWithValue("@imagepath", ip);
            else
                command.Parameters.AddWithValue("@imagepath", System.DBNull.Value);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                    isSuccess = true;
            }
            catch
            {
                //
            }
            finally
            {
                connection.Close();
            }
            return isSuccess;
        }
        public static bool UpdatePeople(int ID, string nat, string fn, string sn, string tn, string ln, DateTime db, int g, string a, string p, string e, int natc, string ip)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"Update People set
                               NationalNo = @nat,
                               FirstName = @Firs,
                               SecondName = @Seco,
                               ThirdName = @thir,
                               LastName = @Las,
                               DateOfBirth = @dat,
                               Gendor = @gen,
                               Address = @adr,
                               Phone = @pho,
                               Email = @ema,
                               NationalityCountryID = @natc,
                               ImagePath = @img
                             where PersonID = @id
                            ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", ID);
            command.Parameters.AddWithValue("@nat", nat);
            command.Parameters.AddWithValue("@Firs", fn);
            command.Parameters.AddWithValue("@Seco", sn);
            command.Parameters.AddWithValue("@thir", tn);
            command.Parameters.AddWithValue("@Las", ln);
            command.Parameters.AddWithValue("@dat", db);
            command.Parameters.AddWithValue("@gen", g);
            command.Parameters.AddWithValue("@adr", a);
            command.Parameters.AddWithValue("@pho", p);
            command.Parameters.AddWithValue("@ema", e);
            command.Parameters.AddWithValue("@natc", natc);
            if (!string.IsNullOrEmpty(ip))
                command.Parameters.AddWithValue("@img", ip);
            else
                command.Parameters.AddWithValue("@img", System.DBNull.Value);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                //
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
        public static bool DeletePeople(int id)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Delete From People where PersonID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                //
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
        public static int GetPersonIdByNationalNumber(string nationalNo)
        {
            int personid = 0;
            SqlConnection con = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Select PersonID  from People where NationalNo = @nat";
            SqlCommand cmn = new SqlCommand(query, con);
            cmn.Parameters.AddWithValue("@nat", nationalNo);
            try
            {
                con.Open();
                object result = cmn.ExecuteScalar();
                if (result != null)
                    personid = Convert.ToInt32(result);
            }
            catch
            {
                //
            }
            finally
            {
                con.Close();
            }
            return personid;
        }
        public static bool UpdateImage(int personId,string imagePath)
        {
            int rowsAffected = 0;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Update People set  ImagePath = @img where PersonID = @id";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id", personId);
            cmd.Parameters.AddWithValue("@img", imagePath);
            try
            {
                cn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch
            {
                //
            }
            finally
            {
                cn.Close();
            }
            return (rowsAffected > 0);
        }

        //Countries
        public static DataTable GetAllCountrie()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = "Select * From Countries";
            SqlCommand command = new SqlCommand(query, connection); ;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch
            {
                //
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static string GetCountryNameByID(int id)
        {
            string name = "";
            SqlConnection con = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Select CountryName from Countries where CountryID = @id";
            SqlCommand cmn = new SqlCommand(query, con);
            cmn.Parameters.AddWithValue("@id", id);
            try
            {
                con.Open();
                object result = cmn.ExecuteScalar();
                if (result != null)
                    name = result.ToString();
            }
            catch
            {
                //
            }
            finally
            {
                con.Close();
            }
            return name;
        }


        //User
        public static DataTable GetAllInfoUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = "Select * From Users";
            SqlCommand command = new SqlCommand(query, connection); ;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch
            {
                //
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static bool UserUsed(int prodId)
        {
            bool isUsed = false;
            SqlConnection con = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Select top 1 1 from People where PersonID = @pId";
            SqlCommand cmn = new SqlCommand(query, con);
            cmn.Parameters.AddWithValue("@pId", prodId);
            try
            {
                con.Open();
                object result = cmn.ExecuteScalar();
                isUsed = (result != null);
            }
            catch
            {
                //
            }
            finally
            {
                con.Close();
            }
            return isUsed;
        }
        public static bool IsUserFoundAndActive(string name, string password)
        {
            bool isValid = false;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Select top 1 IsActive from Users where UserName = @n and Password = @p";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@n", name);
            cmd.Parameters.AddWithValue("@p", password);

            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    bool Active = (bool)result;
                    if (Active)
                        isValid = true;
                }
            }
            catch
            {
                //
            }
            finally
            {
                cn.Close();
            }
            return isValid;
        }
        public static bool GetUserByID(int id, ref int PersonId, ref string UserName, ref string Password, ref bool Active)
        {
            bool found = false;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Select UserID,PersonID,UserName,Password,IsActive
                             From Users where UserID = @ID";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@ID", id);
            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    found = true;
                    reader.Read();
                    PersonId = Convert.ToInt32(reader["PersonID"].ToString());
                    UserName = reader["UserName"].ToString();
                    Password = reader["Password"].ToString();
                    Active = Convert.ToBoolean(reader["IsActive"]);

                }
                reader.Close();
            }
            catch
            {
                //
            }
            finally
            {
                cn.Close();
            }

            return found;
        }
        public static bool AddNewUser(int person, string name, string pasword, bool active)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Insert into Users (PersonID,UserName,Password,IsActive)
                             Values (@per,@name,@pas,@act)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@per", person);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@pas", pasword);
            command.Parameters.AddWithValue("@act", active);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                //
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
        public static bool UpdateUser(int ID, int personid, string name, string password, bool active)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"Update Users set
                               PersonID = @per,
                               UserName = @name,
                               Password = @pas,
                               IsActive = @act
                             where UserID = @id";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", ID);
            command.Parameters.AddWithValue("@per", personid);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@pas", password);
            command.Parameters.AddWithValue("@act", active);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                //
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
        public static bool DeleteUser(int id)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Delete From Users where UserID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                //
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
        public static bool IsPeopleIsUSer(int personId)
        {
            bool isUsed = false;
            SqlConnection con = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Select top 1 1 from Users where PersonID = @pId";
            SqlCommand cmn = new SqlCommand(query, con);
            cmn.Parameters.AddWithValue("@pId", personId);
            try
            {
                con.Open();
                object result = cmn.ExecuteScalar();
                isUsed = (result != null);
            }
            catch
            {
                //
            }
            finally
            {
                con.Close();
            }
            return isUsed;
        }
        public static bool GetUserByPersonId(int id, ref int userid, ref string name, ref string paswword, ref bool active)
        {
            bool isFound = false;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = "Select UserID , UserName , Password , IsActive from Users where PersonID = @id";
            SqlCommand cmn = new SqlCommand(query, cn);
            cmn.Parameters.AddWithValue("@id", id);
            try
            {
                cn.Open();
                SqlDataReader reader = cmn.ExecuteReader();
                if (reader.Read())
                {
                    userid = (int)reader["UserID"];
                    name = reader["UserName"].ToString();
                    paswword = reader["Password"].ToString();
                    active = (bool)reader["IsActive"];
                    isFound = true;
                }
                reader.Close();
            }
            catch
            {
                //
            }
            finally
            {
                cn.Close();
            }
            return isFound;
        }
        public static bool GetCurrentUser(string name, string password, ref int userid, ref int personid, ref bool active)
        {
            bool isFound = false;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = "Select UserID, PersonID , UserName , Password , IsActive from Users where UserName = @name and Password = @password";
            SqlCommand cmn = new SqlCommand(query, cn);
            cmn.Parameters.AddWithValue("@name", name);
            cmn.Parameters.AddWithValue("@password", password);
            try
            {
                cn.Open();
                SqlDataReader reader = cmn.ExecuteReader();
                if (reader.Read())
                {
                    userid = (int)reader["UserID"];
                    personid = (int)reader["PersonID"];
                    active = (bool)reader["IsActive"];
                    isFound = true;
                }
                reader.Close();
            }
            catch
            {
                //
            }
            finally
            {
                cn.Close();
            }
            return isFound;
        }
        public static bool UpdatePassword(int id, string newPassword)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Update Users set
                               Password = @pas
                             where UserID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@pas", newPassword);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                //
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }


        //Application types
        public static DataTable GetAllInfoApplicationTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = "Select * From ApplicationTypes";
            SqlCommand command = new SqlCommand(query, connection); ;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
                reader.Close();
            }
            catch
            {
                //
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static bool GetApplicationTypeOfId(int id, ref string type, ref Decimal fees)
        {
            bool flag = false;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = "Select ApplicationTypeID , ApplicationTypeTitle,ApplicationFees from ApplicationTypes where ApplicationTypeID = @ID";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@ID", id);
            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    flag = true;
                    type = (string)reader["ApplicationTypeTitle"];
                    fees = (Decimal)reader["ApplicationFees"];
                }
                reader.Close();
            }
            catch
            {
                //
            }
            finally
            {
                cn.Close();
            }
            return flag;
        }
        public static bool UpdateNameOfTypeOrFess(int id, string title, Decimal fees)
        {
            int rowsAffected = 0;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Update ApplicationTypes set
                             ApplicationTypeTitle = @title,
                             ApplicationFees = @fees
                             where ApplicationTypeID = @ID";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@fees", fees);
            try
            {
                cn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch
            {
                //
            }
            finally
            {
                cn.Close();
            }
            return (rowsAffected > 0);
        }
        public static Decimal GetFeesOfApplicationType(int id)
        {
            Decimal fees = 0;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = "Select ApplicationFees from ApplicationTypes where ApplicationTypeID = @ID";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@ID", id);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    fees = Convert.ToDecimal(result);
            }
            catch
            {
                //
            }
            finally
            {
                cn.Close();
            }
            return fees;
        }
       

        //Test Types
        public static DataTable GetAllInfoTestTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = "Select * From TestTypes";
            SqlCommand command = new SqlCommand(query, connection); ;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
                reader.Close();
            }
            catch
            {
                //
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static bool GetTestTypeOfId(int id, ref string type, ref string Description, ref Decimal fees)
        {
            bool flag = false;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = "Select TestTypeID , TestTypeTitle,TestTypeDescription,TestTypeFees from TestTypes where TestTypeID = @ID";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@ID", id);
            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    flag = true;
                    type = (string)reader["TestTypeTitle"];
                    Description = (string)reader["TestTypeDescription"];
                    fees = Convert.ToDecimal(reader["TestTypeFees"]);
                }
                reader.Close();
            }
            catch
            {
                //
            }
            finally
            {
                cn.Close();
            }
            return flag;
        }
        public static bool UpdateInfoforTestType(int id, string title, string Description, Decimal fees)
        {
            int rowsAffected = 0;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Update TestTypes set
                             TestTypeTitle = @title,
                             TestTypeDescription = @Description,
                             TestTypeFees = @fees
                             where TestTypeID = @ID";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@fees", fees);
            try
            {
                cn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch
            {
                //
            }
            finally
            {
                cn.Close();
            }
            return (rowsAffected > 0);
        }
       

        //LocalDriving ViewTable
        public static DataTable GetInfoForLocalDriving()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = "Select * From LocalDriving";
            SqlCommand command = new SqlCommand(query, connection); ;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
                reader.Close();
            }
            catch
            {
                //
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static int GetPassedTest(int LDALID)
        {
            int passed = -1;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Select PassedTests from LocalDriving where LDLAppID = @id";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id", LDALID);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    passed = Convert.ToInt32(result);
            }
            catch
            {
                //
                passed = -1;
            }
            finally
            {
                cn.Close();
            }
            return passed;
        }

        //Applications
        public static int AddNewApplication(int personID, DateTime date, int apptypeid, int applicationStatus,DateTime laststatusdate,decimal Paidfees, int CreateByUser)
        {
            int appId = 0;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Insert into Applications (ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)
                                             Values(@personID, @date, @apptypeid, @applicationStatus, @laststatusdate, @Paidfees, @CreateByUser);
                                              SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@personID", personID);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@apptypeid", apptypeid);
            cmd.Parameters.AddWithValue("@applicationStatus", applicationStatus);
            cmd.Parameters.AddWithValue("@laststatusdate", laststatusdate);
            cmd.Parameters.AddWithValue("@Paidfees", Paidfees);
            cmd.Parameters.AddWithValue("@CreateByUser", CreateByUser);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if(result != null)
                    appId = Convert.ToInt32(result);

            }
            catch
            {
                //
                appId = 0;
            }
            finally
            {
                cn.Close();
            }
            return appId;
        }
        public static bool HasActiveApplication(int personID,int LicenseClassID)
        {
            bool check = false;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"SELECT 1
                         FROM Applications A
                         INNER JOIN LocalDrivingLicenseApplications L
                         ON A.ApplicationID = L.ApplicationID
                         WHERE A.ApplicantPersonID = @personID
                         AND L.LicenseClassID = @lcid
                         AND A.ApplicationStatus = 1";
            SqlCommand cmd = new SqlCommand(query, cn);

            cmd.Parameters.AddWithValue("@personID", personID);
            cmd.Parameters.AddWithValue("@lcid", LicenseClassID);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    check = true;
            }
            catch
            {
                //
                check = false;
            }
            finally
            {
                cn.Close();
            }

            return check;
        }
        public static bool ConvertingNewRequestToCanceled(int ldlAppID)
        {
            int transfer = 0;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"UPDATE Applications
                     SET ApplicationStatus = 2
                     WHERE ApplicationID = 
                     (
                         SELECT ApplicationID
                         FROM LocalDrivingLicenseApplications
                         WHERE LocalDrivingLicenseApplicationID = @id
                     )";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id", ldlAppID);
            try
            {
                cn.Open();
                transfer = cmd.ExecuteNonQuery();
            }
            catch
            {
                //
                transfer = 0;
            }
            finally
            {
                cn.Close();
            }

            return (transfer > 0);
        }
        public static bool GetInfoApplicationByID(int id, ref int personID, ref DateTime date,ref int apptypeid, ref int applicationStatus,ref DateTime laststatusdate,ref decimal Paidfees,ref int CreateByUser)
        {
            bool result = false;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = "Select * from Applications where ApplicationID =@id";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    personID = (int)reader["ApplicantPersonID"];
                    date = (DateTime)reader["ApplicationDate"];
                    apptypeid = (int)reader["ApplicationTypeID"];
                    applicationStatus = Convert.ToInt32(reader["ApplicationStatus"]);
                    laststatusdate = (DateTime)reader["LastStatusDate"];
                    Paidfees = Convert.ToDecimal(reader["PaidFees"]);
                    CreateByUser = (int)reader["CreatedByUserID"];
                }
                reader.Close();
            }
            catch
            {
                //
                result = false;
            }
            finally
            {
                cn.Close();
            }

            return result;
        }
        public static bool UpdateRequestToCompleted(int LdaID)
        {
            int update = 0;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Update Applications Set
                                ApplicationStatus = 3
                                 WHERE ApplicationID = 
                     (
                         SELECT ApplicationID
                         FROM LocalDrivingLicenseApplications
                         WHERE LocalDrivingLicenseApplicationID = @id
                     )";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id", LdaID);
            try
            {
                cn.Open();
                update = cmd.ExecuteNonQuery();
            }
            catch
            {
                //
                update = 0;
            }
            finally
            {
                cn.Close();
            }

            return (update > 0);
        }


        //LicenseClasses
        public static DataTable GetLicenseClasses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = "Select * From LicenseClasses";
            SqlCommand command = new SqlCommand(query, connection); ;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
                reader.Close();
            }
            catch
            {
                //
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static int GetLicenseClassID(string ClassName)
        {
            int id = 0;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Select LicenseClassID From LicenseClasses Where ClassName = @clsName";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@clsName", ClassName);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    id = Convert.ToInt32(result);
            }
            catch
            {
                //
                id = 0;
            }
            finally
            {
                cn.Close();
            }
            return id;
        }
        public static string GetLicenseClassNameByID(int id)
        {
            string classNAme = "";
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"select ClassName From LicenseClasses Where LicenseClassID = @id";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    classNAme = Convert.ToString(result);
            }
            catch
            {
                //
                classNAme = "";
            }
            finally
            {
                cn.Close();
            }
            return classNAme;
        }
        public static bool GetAllInfoLicenseClass(int id,ref string className,ref string ClassDescription ,ref int  MinimumAllowedAge ,ref int DefaultValidytLength ,ref Decimal ClassFees)
        {
            bool result = false;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = "Select * from LicenseClasses where LicenseClassID = @id";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    className =  reader["ClassName"].ToString();
                    ClassDescription = reader["ClassDescription"].ToString();
                    MinimumAllowedAge = Convert.ToInt32(reader["MinimumAllowedAge"]);
                    DefaultValidytLength = Convert.ToInt32(reader["DefaultValidityLength"]);
                    ClassFees = Convert.ToDecimal(reader["ClassFees"]);
                }
                reader.Close();
            }
            catch
            {
                //
                result = false;
            }
            finally
            {
                cn.Close();
            }
            return result;
        } 


        //LocalDrivingLicenseApplications
        public static int AddNewLocalDrivingLicenseApp(int AppID,int LicneseClassID)
        {
            int rowsAffcted = 0;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Insert Into LocalDrivingLicenseApplications (ApplicationID,LicenseClassID)
                                             Values(@AppID, @LicneseClassID);
                                              SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@AppID", AppID);
            cmd.Parameters.AddWithValue("@LicneseClassID", LicneseClassID);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if(result != null)
                     rowsAffcted = Convert.ToInt32(result);
            }
            catch
            {
                //
                rowsAffcted = 0;
            }
            finally
            {
                cn.Close();
            }
            return rowsAffcted ;
        }
        public static bool GetInfoLocalDrivingLicenseByID(int id,ref int appID,ref int LicenseClassID)
        {
            bool result = false;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = "Select * from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @ID";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@ID", id);
            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    appID          = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                reader.Close();
            }
            catch
            {
                //
                result = false;
            }
            finally
            {
                cn.Close();
            }
            return result;
        }


        //TestAppointment
        public static bool GetAllInfoTestAppointmenByTestAppoID(int TestAppoID, ref int TestTypeId, ref int LocalDrivingId, ref DateTime AppointmentDate, ref Decimal PaidFees, ref int UserCreating, ref bool Locked)
        {
            bool info = false;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"select * from TestAppointments where TestAppointmentID = @id";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id", TestAppoID);
            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    info = true;
                    TestTypeId = (int)reader["TestTypeID"];
                    LocalDrivingId = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToDecimal(reader["PaidFees"].ToString());
                    UserCreating = (int)reader["CreatedByUserID"];
                    Locked = (bool)reader["IsLocked"];
                }
                reader.Close();
            }
            catch
            {
                //
                info = false;
            }
            finally
            {
                cn.Close();
            }
            return info;
        }
        public static int AddNewTestAppointmentByTestAppoID(int TestTypeId, int LocalDrivingId, DateTime AppointmentDate, Decimal PaidFees, int UserCreating, bool Locked)
        {
            int newID = 0;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Insert Into TestAppointments (TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked)
                                                   Values (@testtype,@ldlApp,@AppointmentDate,@Fees,@usercreating,@locked);
                                                    SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@testtype", TestTypeId);
            cmd.Parameters.AddWithValue("@ldlApp", LocalDrivingId);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@Fees", PaidFees);
            cmd.Parameters.AddWithValue("@usercreating", UserCreating);
            cmd.Parameters.AddWithValue("@locked", Locked);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    newID = Convert.ToInt32(result);
            }
            catch
            {
                //
                newID = 0;
            }
            finally
            {
                cn.Close();
            }
            return newID;
        }
        public static DataTable AvaibleInfoByLDALIDANDTestTypeID(int LocalDrLicenseID,int TestTypeID)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = "Select * from TestAppointments where LocalDrivingLicenseApplicationID = @ldalid and TestTypeID = @ttid";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@ldalid", LocalDrLicenseID);
            cmd.Parameters.AddWithValue("@ttid", TestTypeID);
            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                    dt.Load(reader);
                reader.Close();
            }
            catch
            {
                //
            }
            finally
            {
                cn.Close();
            }
            return dt;
        }
        public static bool ConvertingTestAppointmentToLockedByTestAppoiID(int testAppoID)
        {
            int rowsAffected = 0;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Update TestAppointments set IsLocked = 1 where TestAppointmentID = @id ";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id", testAppoID);
            try 
            { 
                cn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch
            {
              //
            }
            finally
            {
                cn.Close();
            }
            return rowsAffected > 0;
        }
        public static bool IsLocked(int TeAppoID)
        {
            bool locked = false; ;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Select IsLocked from TestAppointments  where TestAppointmentID = @id ";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id", TeAppoID);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && Convert.ToBoolean(result) == true)
                    locked = true;

            }
            catch
            {
                //
                locked = false;
            }
            finally
            {
                cn.Close();
            }
            return locked;
        }
        public static bool UpdateDateByTestAppoID(int id,DateTime AppointmentDate)
        {
            int rowsAffected = 0;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Update TestAppointments set AppointmentDate =@Date where TestAppointmentID = @id";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("Date", AppointmentDate);
            try
            {
                cn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch
            {
                //
            }
            finally
            {
                cn.Close();
            }
            return (rowsAffected > 0);

        }
        public static bool IsFirstTest(int testAppointmentId, int ldlId, int testTypeId)
        {
            bool isFirst = false;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"
            SELECT CASE 
                WHEN @TAppID = (
                    SELECT MIN(TestAppointmentID)
                    FROM TestAppointments
                    WHERE LocalDrivingLicenseApplicationID = @ldl
                    AND TestTypeID = @type
                )
                THEN 1
                ELSE 0
            END";

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@TAppID", testAppointmentId);
            cmd.Parameters.AddWithValue("@ldl", ldlId);
            cmd.Parameters.AddWithValue("@type", testTypeId);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && Convert.ToInt32(result) == 1)
                    isFirst = true;
            }
            catch
            {
                //
                isFirst = false;
            }
            finally { cn.Close(); }

            return isFirst;
        }

        //Tests
        public static int AddNewTest(int TestAppointmentID,bool TestResult,int CreatedUserID, string Note = "")
        {
            int newID = 0;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Insert Into Tests(TestAppointmentID,TestResult,Notes,CreatedByUserID)
                            Values(@testAppoID,@testRes,@notes,@createdUser);
                                          SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@testAppoID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@testRes", TestResult);
            cmd.Parameters.AddWithValue("@notes", Note);
            cmd.Parameters.AddWithValue("@createdUser", CreatedUserID);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    newID = Convert.ToInt32(result); 
            }
            catch
            {
                //
                newID = 0;
            }
            finally
            {
                cn.Close();
            }
            return newID;
        }
        public static bool NoYetTestedByTAppoID(int TAppoID)
        {
            bool TestResult = false;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"SELECT TOP 1 TestResult FROM Tests WHERE TestAppointmentID = @id ORDER BY TestID DESC";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id", TAppoID);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result == null)
                    TestResult = true;
            }
            catch
            {
                //
                TestResult = false;
            }
            finally
            {
                cn.Close();
            }
            return TestResult;
        }
        public static bool HasFailedTestByLocalDrivingID(int LDLAppID, int testTypeID)
        {
            bool TestResult = false;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @" SELECT COUNT(*)  FROM Tests T  INNER JOIN TestAppointments TA  ON T.TestAppointmentID = TA.TestAppointmentID 
                                WHERE TA.LocalDrivingLicenseApplicationID = @ldlID  AND TA.TestTypeID = @typeID  AND T.TestResult = 0;";
            SqlCommand cmd = new SqlCommand(query, cn);
             cmd.Parameters.AddWithValue("@ldlID", LDLAppID);
             cmd.Parameters.AddWithValue("@typeID", testTypeID);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    TestResult = true;
            }
            catch
            {
                //
                TestResult = false;
            }
            finally
            {
                cn.Close();
            }
            return TestResult;
        }
        public static bool HasPassedTest(int ldlAppID, int testTypeID)
        {
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"
                            SELECT COUNT(*)
                            FROM Tests T
                            INNER JOIN TestAppointments TA
                            ON T.TestAppointmentID = TA.TestAppointmentID
                            WHERE TA.LocalDrivingLicenseApplicationID = @ldl
                            AND TA.TestTypeID = @type
                            AND T.TestResult = 1";

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@ldl", ldlAppID);
            cmd.Parameters.AddWithValue("@type", testTypeID);

            try
            {
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
            finally
            {
                cn.Close();
            }
        }


        //License
        //ApplicationID DriverID LicenseClass IssueDate ExpirationDate Notes PaidFees IsActive IssueReason CreatedByUserID
        public static int AddNewLicense(int AppID,int DrID,int LC,DateTime issueDate,DateTime ExpirationDate ,Decimal PaidFees , bool Active,int IssueReason , int CreatingUser,string Note = "")
        {
            int rowsAffected = 0;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Insert into Licenses (ApplicationID ,DriverID ,LicenseClass ,IssueDate ,ExpirationDate ,Notes ,PaidFees ,IsActive ,IssueReason ,CreatedByUserID)
                                          Values (@appid,@driverid,@licenseclass,@isuueDate,@expirationDate,@notes,@paidfees,@active,@issueReason,@creting);
                                          SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@appid", AppID);
            cmd.Parameters.AddWithValue("@driverid", DrID);
            cmd.Parameters.AddWithValue("@licenseclass", LC);
            cmd.Parameters.AddWithValue("@isuueDate", issueDate);
            cmd.Parameters.AddWithValue("@expirationDate", ExpirationDate);
            cmd.Parameters.AddWithValue("@notes", Note);
             cmd.Parameters.AddWithValue("@paidfees", PaidFees);
             cmd.Parameters.AddWithValue("@active",Active);
             cmd.Parameters.AddWithValue("@issueReason",IssueReason);
             cmd.Parameters.AddWithValue("@creting",CreatingUser);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    rowsAffected = Convert.ToInt32(result);
            }
            catch
            {
                //
                rowsAffected = 0;
            }
            finally
            {
                cn.Close();
            }
            return rowsAffected;
        }
        public static bool HasLicense(int PersonID, int LicenseClassID)
        {
            bool existing = false;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Select Top 1 1 from LicenseClasses where PersonID = @idPerson and LicenseClass = @idLicense";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@idPerson", PersonID);
            cmd.Parameters.AddWithValue("@idLicense", LicenseClassID);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    existing = true;
            }
            catch
            {
                //
                existing = false;
            }
            finally
            {
                cn.Close();
            }
            return existing;
        }


        //Drivers
        public static bool IsPersonDriver(int id)
        {
            bool existing = false;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Select 1 from Drivers where PersonID = @id";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    existing = true;
            }
            catch
            {
                //
                existing = false;
            }
            finally
            {
                cn.Close();
            }
            return existing;
        }
        public static int GetDriversIdByPersonID(int personID)
        {
            int id = 0;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Select DriverID from Drivers where PersonID = @id";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id", personID);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    id = Convert.ToInt32(result);
            }
            catch
            {
                //
                id = 0;
            }
            finally
            {
                cn.Close();
            }
            return id;
        }
        public static int AddNewDrivers(int PersonID,int CreatedUserID,DateTime CreateDate)
        {
            int newID = 0;
            SqlConnection cn = new SqlConnection(clsDataAccessSetting.connectionString);
            string query = @"Insert Into Drivers (PersonID,CreatedByUserID,CreatedDate)
                                        Values(@pID,@uId,@date);
                                         SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@pID", PersonID);
            cmd.Parameters.AddWithValue("@uID",CreatedUserID);
            cmd.Parameters.AddWithValue("@date",CreateDate);
            try
            {
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    newID = Convert.ToInt32(result);
            }
            catch
            {
                //
                newID = 0;
            }
            finally
            {
                cn.Close();
            }
            return newID;
        }

       
    }
}
