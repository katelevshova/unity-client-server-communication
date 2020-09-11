using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

/**
 * Asynchronous Client Socket Example
 * from Microsoft official documentation
 * https://docs.microsoft.com/en-us/dotnet/framework/network-programming/asynchronous-client-socket-example
 */
public class ConnectorProxy
{
    // The port number for the remote device.  
    private const int port = 11000;

    // ManualResetEvent instances signal completion.  
    private static ManualResetEvent connectDone =
        new ManualResetEvent(false);
    private static ManualResetEvent sendDone =
        new ManualResetEvent(false);
    private static ManualResetEvent receiveDone =
        new ManualResetEvent(false);

    // The response from the remote device.  
    private static string response = "";

    private Socket _client;

    public ConnectorProxy()
    {
        Debug.Log("Constructor ConnectorProxy");
        InitSocketConnection();
    }


    private void InitSocketConnection()
    {
        // Connect to a remote device.  
        try
        {
            // Establish the remote endpoint for the socket.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP socket.  
            _client = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect to the remote endpoint.  
            _client.BeginConnect(remoteEP,
                new AsyncCallback(ConnectCallback), _client);
            connectDone.WaitOne();

            // Send test data to the remote device.  
            Send("This is a test<EOF>");
            sendDone.WaitOne();

            // Receive the response from the remote device.  
            Receive();
            receiveDone.WaitOne();

            // Write the response to the console.  
            Debug.Log("Response received : "+ response.ToString());

            // Release the socket.  
            _client.Shutdown(SocketShutdown.Both);
            _client.Close();

        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    private void CloseConnection()
    {
        // Release the socket.  
        //_client.GetStream().Close();
        _client.Shutdown(SocketShutdown.Both);
        _client.Close();
    }

    private void ConnectCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the socket from the state object.  
            Socket client = (Socket)ar.AsyncState;

            // Complete the connection.  
            client.EndConnect(ar);

            Debug.Log("Socket connected to " + client.RemoteEndPoint.ToString());

            // Signal that the connection has been made.  
            connectDone.Set();
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    public void Receive()
    {
        try
        {
            // Create the state object.  
            ConnectorStateObject state = new ConnectorStateObject();
            state.workSocket = _client;

            // Begin receiving the data from the remote device.  
            _client.BeginReceive(state.buffer, 0, ConnectorStateObject.BufferSize, 0,
                new AsyncCallback(ReceiveCallback), state);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    private static void ReceiveCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the state object and the client socket
            // from the asynchronous state object.  
            ConnectorStateObject state = (ConnectorStateObject)ar.AsyncState;
            Socket client = state.workSocket;

            // Read data from the remote device.  
            int bytesRead = client.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There might be more data, so store the data received so far.  
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                // Get the rest of the data.  
                client.BeginReceive(state.buffer, 0, ConnectorStateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            else
            {
                // All the data has arrived; put it in response.  
                if (state.sb.Length > 1)
                {
                    response = state.sb.ToString();
                }
                // Signal that all bytes have been received.  
                receiveDone.Set();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    public void Send(String data)
    {
        // Convert the string data to byte data using ASCII encoding.  
        byte[] byteData = Encoding.ASCII.GetBytes(data);

        // Begin sending the data to the remote device.  
        _client.BeginSend(byteData, 0, byteData.Length, 0,
            new AsyncCallback(SendCallback), _client);
    }

    private static void SendCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the socket from the state object.  
            Socket client = (Socket)ar.AsyncState;

            // Complete sending the data to the remote device.  
            int bytesSent = client.EndSend(ar);
            Debug.Log("Sent" + bytesSent.ToString() + " bytes to server.");

            // Signal that all bytes have been sent.  
            sendDone.Set();
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }
}
