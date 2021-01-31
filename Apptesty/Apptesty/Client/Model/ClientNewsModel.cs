using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Apptesty.Client.Model
{
    public class ClientNewsModel
    {
        public string News { get; set; }
        public ImageSource NewsImagePath { get; set; }

        public ClientNewsModel()
        {

        }
    }

    public class GroupedClientNewsModel : ObservableCollection<ClientNewsModel>
    {
        public string NewsDateTime { get; set; }
    }
}
