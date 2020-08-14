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
    public class DeparmentWebController : Controller
    {
        // GET: DeparmentWeb
        [Route("/")]
        public async Task<ActionResult> Index()
        {
            try
            {
                string urlBase = "https://localhost:44374/";
                string prefix = "api/";
                string controller = "Department/all";
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };
                string url = $"{prefix}{controller}";
                HttpResponseMessage response = await client.GetAsync(url);
                string answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return View(new List<Department>());
                }

                Reply list = JsonConvert.DeserializeObject<Reply>(answer);

                List<Department> items = ((JArray)list.Data).Select(x => new Department
                {
                    Name = (string)x["name"],
                    Id_Department = (string)x["id_Department"],
                }).ToList();

                IEnumerable<Department> departments = items;
                return View(departments);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(new List<Department>());
            }
        }



        // GET: DeparmentWeb/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeparmentWeb/Create
        [HttpPost]
        public async Task<ActionResult> Create(Department model)
        {
            string urlBase = "https://localhost:44374/";
            string prefix = "api/";
            string controller = "Department/NewDepartment";

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

                Department obj = JsonConvert.DeserializeObject<Department>(answer);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        // GET: DeparmentWeb/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            try
            {
                Department getRequest = new Department
                {
                    Id_Department = id
                };
                string request = JsonConvert.SerializeObject(getRequest);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");

                string urlBase = "https://localhost:44374/";
                string prefix = "api/";
                string controller = $"Department/Search";
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
                    return View(new Department());
                }

                Reply list = JsonConvert.DeserializeObject<Reply>(answer);

                Department item = new Department
                {
                    Name = (string)((JArray)list.Data).First()["name"],

                    Id_Department = (string)((JArray)list.Data).First()["id_Department"],
                };

                return View(item);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(new Department());
            }
        }

        // POST: DeparmentWeb/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Department model)
        {
            try
            {
                string urlBase = "https://localhost:44374/";
                string prefix = "api/";
                string controller = "Department/AlterDepartment";

                string request = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };
                string url = $"{prefix}{controller}/{model.Id_Department}";
                HttpResponseMessage response = await client.PutAsync(url, content);
                string answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Error.");
                    return View(model);
                }

                Department obj = JsonConvert.DeserializeObject<Department>(answer);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);

            }
        }

        // GET: DeparmentWeb/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                Department getRequest = new Department
                {
                    Id_Department = id
                };
                string request = JsonConvert.SerializeObject(getRequest);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");

                string urlBase = "https://localhost:44374/";
                string prefix = "api/";
                string controller = $"Department/Search";
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
                    return View(new Department());
                }

                Reply list = JsonConvert.DeserializeObject<Reply>(answer);

                Department item = new Department
                {
                    Name = (string)((JArray)list.Data).First()["name"],

                    Id_Department = (string)((JArray)list.Data).First()["id_Department"],
                };

                return View(item);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(new Department());
            }
        }

        // POST: DeparmentWeb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            try
            {
                string urlBase = "https://localhost:44374/";
                string prefix = "api/";
                string controller = $"Department/DeleteDepartment/{id}";


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
    }
}
