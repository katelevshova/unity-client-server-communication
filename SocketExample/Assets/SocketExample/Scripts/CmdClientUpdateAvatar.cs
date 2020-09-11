using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdClientUpdateAvatar: Command
{
    public override void Execute(Dictionary<string, object> parameters)
    {
        base.Execute(parameters);
        //Update UI

        //Send message to the server
        string message = BuildMessageToServer();
        Debug.Log("message= " + message);
        GameController.Instance.connectorProxy.Send(message);
    }
}
