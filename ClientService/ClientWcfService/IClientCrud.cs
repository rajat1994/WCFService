using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClientWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IClientCrud" in both code and config file together.
    [ServiceContract]
    public interface IClientCrud
    {
        [OperationContract]
        List<ClientInfo> GetAllClients();
        [OperationContract]
        int AddClient(string FirstName, string LastName, string Email, string Nationality, string Address, string MobileNumber);
        [OperationContract]
        ClientInfo GetAllClientById(int id);

        [OperationContract]
        int UpdateClient(int Id, string FirstName, string LastName, string Email, string Nationality, string Address, string MobileNumber);

        [OperationContract]
        int DeleteClientById(int Id);
    }


    [DataContract]
    public class ClientInfoesss
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public DateTime DateOfBirth { get; set; }

        [DataMember]
        public string MaritalStatus { get; set; }

        [DataMember]
        public string MobileNumber { get; set; }

        [DataMember]
        public string Nationality { get; set; }


        [DataMember]
        public string Address { get; set; }


        [DataMember]
        public string Email { get; set; }


    }
}
