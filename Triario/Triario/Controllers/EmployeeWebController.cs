using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Triario.Models;
using Triario.Models.ViewModels;
namespace Triario.Controllers
{
    public class EmployeeWebController : Controller
    {
        // GET: EmployeeWeb
        [Route("/")]
        public async Task<ActionResult> Index()
        {
            try
            {
                var urlBase = "https://localhost:44374/";
                var prefix = "api/";
                var controller = "Employee/all";
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = $"{prefix}{controller}";
                var response = await client.GetAsync(url);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return View(new List<Employee>());
                }

                var list = JsonConvert.DeserializeObject<Reply>(answer);

                List<Employee> items = ((JArray)list.Data).Select(x => new Employee
                {
                    CC=(int)x["cc"],
                    FName = (string)x["fName"],
                    LName=(string)x["lName"],
                    EUser=(string)x["eUser"],
                    Email=(string)x["email"],
                    Salary=(decimal)x["salary"],
                    Fk_Department=(string)x["fk_Department"],

                }).ToList();

                IEnumerable<Employee> employees = items;
                return View(employees);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(new List<Employee>());
            }
        }



        // GET: EmployeeWeb/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: EmployeeWeb/Create
        [HttpPost]
        public async Task<ActionResult> Create(Employee model)
        {
            string urlBase = "https://localhost:44374/";
            string prefix = "api/";
            string controller = "Employee/NewEmployee";

            try
            {
                //DepartmentViewModel vm = new DepartmentViewModel { Name = "puto" };

                //Department d = new Department 
                //{
                //    Name = vm.Name,
                //    Id_Department = vm.Id_Department
                //};


                string request = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };
                string url = $"{prefix}{controller}";
                HttpResponseMessage response = await client.PostAsync(url, content);
                string answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Error.");
                    return View();
                }

                Employee obj = JsonConvert.DeserializeObject<Employee>(answer);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        // GET: EmployeeWeb/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                Employee getRequest = new Employee
                {
                    CC = id
                };
                string request = JsonConvert.SerializeObject(getRequest);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");

                string urlBase = "https://localhost:44374/";
                string prefix = "api/";
                string controller = $"Employee/Search";
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };
                string url = $"{prefix}{controller}";

                HttpResponseMessage response = await client.PostAsync(url, content);



                string answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return View(new Employee());
                }

                Reply list = JsonConvert.DeserializeObject<Reply>(answer);

                Employee item = new Employee
                {
                    CC = (int)((JArray)list.Data).First()["cc"],
                    FName = (string)((JArray)list.Data).First()["fName"],
                    LName = (string)((JArray)list.Data).First()["lName"],
                    EUser = (string)((JArray)list.Data).First()["eUser"],
                    Email = (string)((JArray)list.Data).First()["email"],
                    Salary = (decimal)((JArray)list.Data).First()["salary"],
                    Fk_Department = (string)((JArray)list.Data).First()["fk_Department"],
                };

                return View(item);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(new Employee());
            }
        }

        // POST: EmployeeWeb/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Employee model)
        {
            try
            {
                string urlBase = "https://localhost:44374/";
                string prefix = "api/";
                string controller = "Employee/AlterEmployee";

                string request = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };
                string url = $"{prefix}{controller}/{model.CC}";
                HttpResponseMessage response = await client.PutAsync(url, content);
                string answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Error.");
                    return View(model);
                }

                Employee obj = JsonConvert.DeserializeObject<Employee>(answer);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);

            }
        }
        // GET: EmployeeWeb/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Employee getRequest = new Employee
                {
                    CC = id
                };
                string request = JsonConvert.SerializeObject(getRequest);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");

                string urlBase = "https://localhost:44374/";
                string prefix = "api/";
                string controller = $"Employee/Search";
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };
                string url = $"{prefix}{controller}";

                HttpResponseMessage response = await client.PostAsync(url, content);



                string answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return View(new Employee());
                }

                Reply list = JsonConvert.DeserializeObject<Reply>(answer);

                Employee item = new Employee
                {
                    CC = (int)((JArray)list.Data).First()["cc"],
                    FName = (string)((JArray)list.Data).First()["fName"],
                    LName = (string)((JArray)list.Data).First()["lName"],
                    EUser = (string)((JArray)list.Data).First()["eUser"],
                    Email = (string)((JArray)list.Data).First()["email"],
                    Salary = (decimal)((JArray)list.Data).First()["salary"],
                    Fk_Department = (string)((JArray)list.Data).First()["fk_Department"],
                };

                return View(item);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(new Employee());
            }
        }

        // POST: EmployeeWeb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                string urlBase = "https://localhost:44374/";
                string prefix = "api/";
                string controller = $"Employee/DeleteEmployee/{id}";


                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };
                string url = $"{prefix}{controller}";
                HttpResponseMessage response = await client.DeleteAsync(url);
                string answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Error");
                    return View(id);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(id);
            }
        }

        [Route("FullSearch"), HttpGet]
        public async Task<ActionResult> FullSearch()
        {
            try
            {
                var urlBase = "https://localhost:44374/";
                var prefix = "api/";
                var controller = "Employee/GeneralInformation";
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = $"{prefix}{controller}";
                var response = await client.GetAsync(url);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return View(new List<JoinViewModel>());
                }

                var list = JsonConvert.DeserializeObject<Reply>(answer);

                List<JoinViewModel> items = ((JArray)list.Data).Select(x => new JoinViewModel
                {
                    CC = (int)x["cc"],
                    FullName = (string)x["fullName"],
                    DName = (string)x["dName"],
                    Salary = (decimal)x["salary"],
                    PSalary = (decimal)x["pSalary"]
                }).ToList();

                IEnumerable<JoinViewModel> JoinViewModel = items;
                return View(JoinViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(new List<JoinViewModel>());
            }
        }
    }
}
