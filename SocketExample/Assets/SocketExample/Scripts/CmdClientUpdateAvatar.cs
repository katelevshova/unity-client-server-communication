using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdClientUpdateAvatar: Command
{
    public delegate void ActionUpdateAvatar(int playerId);
    public static event ActionUpdateAvatar OnUpdateAvatar;

    public override void Execute(Dictionary<string, object> parameters)
    {
        base.Execute(parameters);
        //Update UI
        OnUpdateAvatar?.Invoke((int)parameters["PlayerId"]);

        //Send message to the server
        string message = BuildMessageToServer();
        Debug.Log("message= " + message);
        //GameController.Instance.connectorProxy.Send(message);
    }
}
