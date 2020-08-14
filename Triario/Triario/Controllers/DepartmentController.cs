using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Triario.Models;
using Triario.Models.ViewModels;


namespace Triario.Controllers
{
    public class DepartmentController : ApiController
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
                    List<DepartmentViewModel> lst = (from d in db.Department
                                                     select new DepartmentViewModel
                                                     {
                                                         Id_Department = d.Id_Department,
                                                         Name = d.Name
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
        public Reply Search([FromBody] DepartmentViewModel model)
        {

            Reply oR = new Reply
            {
                Result = 0
            };


            try
            {
                using (TriarioEntities1 db = new TriarioEntities1())
                {
                    List<Search_Department_Result> SearchDeparment = db.Search_Department(model.Id_Department).ToList();
                    if (SearchDeparment.Count() > 0)
                    {
                        oR.Data = SearchDeparment;
                        oR.Result = 1;
                    }
                    else { oR.Message = "Departamento Inexistente"; }
                }
            }
            catch (Exception)
            {
                oR.Message = "Error del servidor";
            }

            return oR;
        }
        [HttpPost]
        public Reply NewDepartment([FromBody] DepartmentViewModel model)
        {

            Reply oR = new Reply
            {
                Result = 0
            };


            try
            {
                using (TriarioEntities1 db = new TriarioEntities1())
                {

                    int NewDepartment = db.Create_Department(model.Id_Department, model.Name);
                    oR.Data = NewDepartment;
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
        public Reply AlterDepartment([FromBody] DepartmentViewModel model)
        {

            Reply oR = new Reply
            {
                Result = 0
            };


            try
            {
                using (TriarioEntities1 db = new TriarioEntities1())
                {
                    List<Search_Department_Result> SearchDepartment = db.Search_Department(model.Id_Department).ToList();
                    if (SearchDepartment.Count() > 0)
                    {
                        int AlterDepartment = db.Actualizate_Department(model.Id_Department, model.Name);
                        oR.Data = AlterDepartment;
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
        public Reply DeleteDepartment([FromUri] string id)
        {

            Reply oR = new Reply
            {
                Result = 0
            };


            try
            {
                using (TriarioEntities1 db = new TriarioEntities1())
                {

                    string FkDepartment = id;
                    List<Search_Department_Result> SearchDepartment = db.Search_Department(id).ToList();

                    if (SearchDepartment.Count() > 0)
                    {

                        foreach (Employee em in db.Employee)
                        {
                            if (em.Fk_Department ==id) 
                            { oR.Message = "No s puede borrar por la existencia de usuarios relacionados con el";
                                return oR;
                            }
                        }
                        int DeleteDepartment = db.Delete_Department(id);
                        oR.Data = DeleteDepartment;
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
    }
}
