﻿using System;
using WebSocket4Net;


namespace SocketIOClient
{
	/// <summary>
	/// C# Socket.IO client interface
	/// </summary>
	interface IClient
	{
		event EventHandler Opened;
		event EventHandler<MessageEventArgs> Message;
		event EventHandler SocketConnectionClosed;
		event EventHandler<ErrorEventArgs> Error;

		SocketIOHandshake HandShake { get; }
		bool IsConnected { get; }
		WebSocketState ReadyState { get; }

		void Connect();
		IEndPointClient Connect(string endPoint);

		void Close();
		void Dispose();

		void On(string eventName, Action<SocketIOClient.Messages.IMessage> action);
		void On(string eventName, string endPoint, Action<SocketIOClient.Messages.IMessage> action);

		void Emit(string eventName, object payload);
		void Emit(string eventName, object payload, string endPoint = "", Action<object> callBack = null);
		
		void Send(SocketIOClient.Messages.IMessage msg);
		//void Send(string rawEncodedMessageText);
	}
}
