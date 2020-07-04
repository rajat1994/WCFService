using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientWeb.Models;
using System.Dynamic;


namespace ClientWeb.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client

        ClientCrudReference.ClientCrudClient clClient = new ClientCrudReference.ClientCrudClient();
        public ActionResult Index()
        {

            

            return View();
        }

        //Create


        public ActionResult Create ()
        {
            return View();
        }



        
        public ActionResult LoadData()
        {

            List<Client> lstRecord = new List<Client>();

            var lst = clClient.GetAllClients();

            foreach (var item in lst)
            {
                Client cln = new Client();

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
                lstRecord.Add(cln);

            }


            return Json(new { lstRecord = lstRecord }, JsonRequestBehavior.AllowGet);

        }


        //Add

        [HttpPost]
        public ActionResult Add(Client item)
        {

            Client cln = new Client();
            string FirstName = item.FirstName;
            string LastName = item.LastName;
            string Email = item.Email;
            string Nationality = item.Nationality;
            string Address = item.Address;
            string MobileNumber = item.MobileNumber;
            clClient.AddClient(FirstName,LastName,Email,Nationality,Address,MobileNumber);
            return RedirectToAction("Index", "Home");

        }


        //Delete

        public ActionResult Delete(int id)
        {
            int retval = clClient.DeleteClientById(id);
            if (retval > 0)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        public ActionResult Edit(int id)
        {
            var lst = clClient.GetAllClientById(id);
            Client usr = new Client();
            usr.pkclientId = lst.pkclientId;
            usr.FirstName = lst.FirstName;
            usr.Email = lst.Email;
            return View(usr);

        }


        //Edit
        [HttpPost]
        public ActionResult Edit(Client mdl)
        {
            Client usr = new Client();
            usr.pkclientId = mdl.pkclientId;
            usr.FirstName = mdl.FirstName;
            usr.Email = mdl.Email;
            usr.LastName = mdl.LastName;
            usr.Nationality = mdl.Nationality;
            usr.Address = mdl.Address;
            usr.MobileNumber = mdl.MobileNumber;


            int Retval = clClient.UpdateClient(usr.pkclientId, usr.FirstName, usr.LastName, usr.Email, usr.Nationality, usr.Address,usr.MobileNumber);
            if (Retval > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }






    }
}