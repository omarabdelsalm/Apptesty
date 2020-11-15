using System;
using System.Collections.Generic;
using System.Text;
[assembly:Xamarin.Forms.Dependency(typeof(Apptesty.WebsiteImplantion))]
namespace Apptesty
{
  public class WebsiteImplantion : IwebSiteHelper
    {
        public string Geturl()
        {
            return " Url ";
            
        }
    }
}
