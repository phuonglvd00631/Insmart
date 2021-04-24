using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Insmart.Areas.Admin.Controllers
{
    public class SearchMemberController : Controller
    {
        private string EndPoint = "http://192.168.1.21:9900/";
        // GET: Admin/SearchMember
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Search(string policyNo, string cardNo, string insuredName, string idNum, string bod, string indexPage)
        {
            try
            {
          
                string Path = "api/MVL/v1/SearchMembers?" +
                "pol_num=" + policyNo +
                "&card_no=" + cardNo +
                "&ins_cli_nm=" + insuredName +
                "&ins_id_num=" + idNum +
                "&ins_dob=" + bod +
                "&page_index=" + indexPage + 
                "&page_len=10";

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(EndPoint);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("Authorization", String.Format("Basic {0}", "ZGV2MDE6MTIzNDU2"));

                HttpResponseMessage response = await client.GetAsync(Path);

                var result = response.Content.ReadAsStringAsync().Result;

                return Json(new { code = 200, result = result, msg = "response Success" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                
                return Json(new { code = 500, msg = ex.StackTrace }, JsonRequestBehavior.AllowGet);
            }
          
        }
    }
}