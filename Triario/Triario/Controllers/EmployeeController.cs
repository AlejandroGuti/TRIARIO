using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Triario.Models;
using Triario.Models.ViewModels;

namespace Triario.Controllers
{
    public class EmployeeController : ApiController
    {


        [HttpGet]
        public Reply All()
        {

            Reply oR = new Reply
            {
                Result = 0
            };


            try
            {
                using (TriarioEntities1 db = new TriarioEntities1())
                {
                    List<EmployeeViewModel> lst = (from d in db.Employee
                                                   select new EmployeeViewModel
                                                   {
                                                       Id_Num = d.id_num,
                                                       CC = d.CC,
                                                       FName = d.FName,
                                                       LName = d.LName,
                                                       EUser = d.EUser,
                                                       Email = d.Email,
                                                       Salary = (decimal)d.Salary,
                                                       Fk_Department = d.Fk_Department
                                                   }).ToList();

                    oR.Data = lst;
                    oR.Result = 1;

                }
            }
            catch (Exception)
            {
                oR.Message = "Error del servidor";
            }

            return oR;
        }

        [HttpPost]
        public Reply Search([FromBody] EmployeeViewModel model)
        {

            Reply oR = new Reply
            {
                Result = 0
            };


            try
            {
                using (TriarioEntities1 db = new TriarioEntities1())
                {
                    List<Search_Employee_Result> SearchEmployee = db.Search_Employee(model.CC).ToList();
                    if (SearchEmployee.Count() > 0)
                    {
                        oR.Data = SearchEmployee;
                        oR.Result = 1;
                    }
                    else { oR.Message = "Usuario Inexistente"; }
                }
            }
            catch (Exception)
            {
                oR.Message = "Error del servidor";
            }

            return oR;
        }
        [HttpPost]
        public Reply NewEmployee([FromBody] EmployeeViewModel model)
        {

            Reply oR = new Reply
            {
                Result = 0
            };


            try
            {
                using (TriarioEntities1 db = new TriarioEntities1())
                {

                    int NewEmployee = db.Create_Employee(model.CC, model.FName, model.LName, model.EUser, model.Email, model.Salary, model.Fk_Department);
                    oR.Data = NewEmployee;
                    oR.Result = 1;



                }
            }
            catch (Exception)
            {
                oR.Message = "Error De Creacion";
            }

            return oR;
        }
        [HttpPut]
        public Reply AlterEmployee([FromBody] EmployeeViewModel model)
        {

            Reply oR = new Reply
            {
                Result = 0
            };


            try
            {
                using (TriarioEntities1 db = new TriarioEntities1())
                {
                    List<Search_Employee_Result> SearchEmployee = db.Search_Employee(model.CC).ToList();
                    if (SearchEmployee.Count() > 0)
                    {
                        int AlterEmployee = db.Actualizate_Employee(model.CC, model.FName, model.LName, model.EUser, model.Email, model.Salary, model.Fk_Department);
                        oR.Data = AlterEmployee;
                        oR.Result = 1;
                    }
                    else { oR.Message = "Usuario no encontrado"; }
                }
            }
            catch (Exception)
            {
                oR.Message = "Error De Actualizacion";
            }

            return oR;
        }
        [HttpDelete]
        public Reply DeleteEmployee([FromUri] int id)
        {

            Reply oR = new Reply
            {
                Result = 0
            };


            try
            {
                using (TriarioEntities1 db = new TriarioEntities1())
                {
                    int CC = id;
                    List<Search_Employee_Result> SearchEmployee = db.Search_Employee(CC).ToList();
                    if (SearchEmployee.Count() > 0)
                    {
                        int DeleteEmployee = db.Delete_Employee(CC);
                        oR.Data = DeleteEmployee;
                        oR.Result = 1;
                        oR.Message = "Borrado correctamente";
                    }
                    else { oR.Message = "Usuario no encontrado"; }
                }
            }
            catch (Exception)
            {
                oR.Message = "Error De Borrado";
            }

            return oR;
        }
        [HttpGet]
        public Reply GeneralInformation()
        {

            Reply oR = new Reply
            {
                Result = 0
            };


            try
            {
                using (TriarioEntities1 db = new TriarioEntities1())
                {
                         List<JoinViewModel> listJ = new List<JoinViewModel>();
                        foreach(var em in db.Employee)
                        {
                            listJ.Add(new JoinViewModel
                            {
                                CC = em.CC,
                                FullName = em.FullName,
                                DName = em.Department.Name,
                                Salary = (decimal)em.Salary,
                                PSalary = (decimal)em.Salary * 100 / (decimal)(((Sum_Salary_Department_Result)
                                        (db.Sum_Salary_Department(em.Department.Id_Department).ToList().FirstOrDefault())).Sum_Salary)
                            }); 
                        }

                        oR.Data = listJ;
                        oR.Result = 1;
                }
            }
            catch (Exception ex)
            {
                oR.Message = ex.Message;
            }

            return oR;
        }

    }
}
