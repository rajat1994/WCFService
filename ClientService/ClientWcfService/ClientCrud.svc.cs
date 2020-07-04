using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClientWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ClientCrud" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ClientCrud.svc or ClientCrud.svc.cs at the Solution Explorer and start debugging.
    public class ClientCrud : IClientCrud
    {
        public List<ClientInfo> GetAllClients()
        {
            List<ClientInfo> clientList = new List<ClientInfo>();
            ClientEntities clnDb = new ClientEntities();
            var lstClient = from k in clnDb.ClientInfoes select k;
            foreach (var item in lstClient)
            {
                ClientInfo cln = new ClientInfo();

                cln.pkclientId = item.pkclientId;
                cln.FirstName = item.FirstName;
                cln.LastName = item.LastName;
                cln.Email = item.Email;
                cln.Gender = item.Gender;
                cln.Nationality = item.Nationality;
                cln.Address = item.Address;
                cln.DateOfBirth = item.DateOfBirth;
                cln.MobileNumber = item.MobileNumber;
                cln.MaritalStatus = item.MaritalStatus;
                cln.Gender = item.Gender;
                clientList.Add(cln);

            }

            return clientList;
        }



        public ClientInfo GetAllClientById(int id)
        {

            ClientEntities clnDb = new ClientEntities();
            var lstCln = from k in clnDb.ClientInfoes where k.pkclientId == id select k;
            ClientInfo cln = new ClientInfo();
            foreach (var item in lstCln)
            {

                
                cln.FirstName = item.FirstName;
                cln.LastName = item.LastName;
                cln.Email = item.Email;
                cln.Gender = item.Gender;
                cln.Nationality = item.Nationality;
                cln.Address = item.Address;
                cln.DateOfBirth = item.DateOfBirth;
                cln.MobileNumber = item.MobileNumber;
                cln.MaritalStatus = item.MaritalStatus;
                cln.Gender = item.Gender;

            }

            return cln;
        }

        public int DeleteClientById(int Id)
        {

            ClientEntities clnDb = new ClientEntities();
            ClientInfo clnDtl = new ClientInfo();
            clnDtl.pkclientId = Id;
            clnDb.Entry(clnDtl).State = EntityState.Deleted;
            int Retval = clnDb.SaveChanges();
            return Retval;
        }

        public int AddClient(string FirstName, string LastName, string Email,  string Nationality, string Address, string MobileNumber)
        {
            ClientEntities clnDb = new ClientEntities();
            ClientInfo cln = new ClientInfo();
            cln.FirstName = FirstName;
            cln.LastName =LastName;
            cln.Email = Email;
           
            cln.Nationality = Nationality;
            cln.Address = Address;
           
            cln.MobileNumber = MobileNumber;
            
           
            clnDb.ClientInfoes.Add(cln);
            int Retval = clnDb.SaveChanges();
            return Retval;
        }
        public int UpdateClient( int Id,string FirstName, string LastName,string Email, string Nationality, string Address, string MobileNumber)
        {
            ClientEntities clnDb = new ClientEntities();
            ClientInfo clnDl = new ClientInfo();
            clnDl.pkclientId = Id;
            clnDl.FirstName = FirstName;
            clnDl.Email = Email;
            clnDl.Nationality = Nationality;
            clnDl.Address = Address;
            clnDl.LastName = LastName;
            clnDl.MobileNumber = MobileNumber;

            clnDb.Entry(clnDl).State = EntityState.Modified;

            int Retval = clnDb.SaveChanges();
            return Retval;
        }
    }
}
