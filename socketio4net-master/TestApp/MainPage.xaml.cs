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
using System.Diagnostics;
using System.Threading;
using System.Net.Http;

namespace TestApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static MainPage Current;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Current = this;
            SimpleExample();
         
        }

        Client socket;
        String url = "http://216.151.208.237:1337/";

        public class Message
        {
            public string message { set; get; }
        }
        
        public void Update(SocketIOClient.Messages.IMessage data)
        {
            Action action = () =>
            {
                Display.Text = data.Json.GetFirstArgAs<Message>().message;
            };
            Dispatcher.BeginInvoke(action);
        }

        private void SimpleExample()
        {
            socket = new Client(url);

            socket.On("message_to_client", Update);

            socket.Connect();
        }

    }
}