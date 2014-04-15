using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TestApp.Resources;
using SocketIOClient;

namespace TestApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            SimpleExample();
        }

        Client socket;
        String url = "http://216.151.208.237:1337/";

        private void SimpleExample()
        {
            socket = new Client(url);
            socket.Connect();
        }

    }
}