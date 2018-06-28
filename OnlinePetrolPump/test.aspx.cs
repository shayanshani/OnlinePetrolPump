using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePetrolPump
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            //create delegate instances using anonymous method
            NumberChanger nc = delegate(int x)
            {
                Response.Write("Anonymous Method:" + x);
            };

            //calling the delegate using the anonymous method 
            nc(10);

            //instantiating the delegate using the named methods 
            nc = new NumberChanger(TestDelegate.AddNum);

            //calling the delegate using the named methods 
            nc(5);

            //instantiating the delegate using another named methods 
            nc = new NumberChanger(TestDelegate.MultNum);

            //calling the delegate using the named methods 
            nc(2);
        }

        delegate void NumberChanger(int n);
        class TestDelegate
        {
            static int num = 10;
            public static void AddNum(int p)
            {
                num += p;
                HttpContext.Current.Response.Write("Named Method: {0}" + num);
            }

            public static void MultNum(int q)
            {
                num *= q;
                HttpContext.Current.Response.Write("Named Method:" + num);
            }

            public static int getNum()
            {
                return num;
            }
        }
    }
}