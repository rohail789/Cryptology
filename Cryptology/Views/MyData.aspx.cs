using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cryptology.Views
{
    public partial class MyData : System.Web.UI.Page
    {
        public static async Task Idontw()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var url = "https://coinranking.com/";
            var htt = new HttpClient();
            var html = await htt.GetStringAsync(url);
        }
        protected async Task Page_Load(object sender, EventArgs e)
        {

            await Idontw();


        }
    }
}