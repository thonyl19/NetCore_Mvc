using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_Mvc.Controllers
{
    public class HelloWorldController : Controller
    {
        /// <summary>
        /// lession  1-1 - 處理文字輸出
        /// </summary>
        /// <returns></returns>
        public string C011()
        {
            return "Hello Word";
        }

        /// <summary>
        /// lession  1-2 - 參數化輸入文字
        /// </summary>
        /// <returns></returns>
        public string C012(string name, int ID = 1)
        {
            //ViewData["Message"] = "Your welcome message";
            return HtmlEncoder.Default.Encode($"Hello {name} , ID:{ID}");
            //return View();
        }


        /// <summary>
        /// lession 2-1 - 輸出頁面 , 並搭配參數 動態產生頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult C021(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }


    }
}