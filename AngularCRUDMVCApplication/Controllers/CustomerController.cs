using AngularCRUDMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularCRUDMVCApplication.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>  
        ///   
        /// Get All Employee  
        /// </summary>  
        /// <returns></returns>  
        public JsonResult GetAllCustomers()
        {
            using (SampleDBEntities Obj = new SampleDBEntities())
            {
                List<Customer> Emp = Obj.Customers.ToList();
                return Json(Emp, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>  
        /// Get Employee With Id  
        /// </summary>  
        /// <param name="Id"></param>  
        /// <returns></returns>  
        public JsonResult GetCustomers(string Id)
        {
            using (SampleDBEntities Obj = new SampleDBEntities())
            {
                int EmpId = int.Parse(Id);
                return Json(Obj.Customers.Find(EmpId), JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>  
        /// Insert New Employee  
        /// </summary>  
        /// <param name="Employe"></param>  
        /// <returns></returns>  
        public string InsertCustomers(Customer Customer)
        {
            if (Customer != null)
            {
                using (SampleDBEntities Obj = new SampleDBEntities())
                {
                    Obj.Customers.Add(Customer);
                    Obj.SaveChanges();
                    return "Employee Added Successfully";
                }
            }
            else
            {
                return "Employee Not Inserted! Try Again";
            }
        }
        /// <summary>  
        /// Delete Employee Information  
        /// </summary>  
        /// <param name="Emp"></param>  
        /// <returns></returns>  
        public string DeleteCustomer(Customer Customer)
        {
            if (Customer != null)
            {
                using (SampleDBEntities Obj = new SampleDBEntities())
                {
                    var Emp_ = Obj.Entry(Customer);
                    if (Emp_.State == System.Data.Entity.EntityState.Detached)
                    {
                        Obj.Customers.Attach(Customer);
                        Obj.Customers.Remove(Customer);
                    }
                    Obj.SaveChanges();
                    return "Employee Deleted Successfully";
                }
            }
            else
            {
                return "Employee Not Deleted! Try Again";
            }
        }
        /// <summary>  
        /// Update Employee Information  
        /// </summary>  
        /// <param name="Emp"></param>  
        /// <returns></returns>  
        public string UpdateCustomer(Customer Customer)
        {
            if (Customer != null)
            {
                using (SampleDBEntities Obj = new SampleDBEntities())
                {
                    var Customers = Obj.Entry(Customer);
                    Customer CustObj = Obj.Customers.Where(x => x.CustomerID == Customer.CustomerID).FirstOrDefault();
                    CustObj.Name = Customer.Name;
                    CustObj.Address = Customer.Address;
                    CustObj.EmailID = Customer.EmailID;
                    CustObj.Birthdate = Customer.Birthdate;
                    CustObj.Mobileno = Customer.Mobileno;

                    Obj.SaveChanges();
                    return "Employee Updated Successfully";
                }
            }
            else
            {
                return "Employee Not Updated! Try Again";
            }
        }
    }
}
