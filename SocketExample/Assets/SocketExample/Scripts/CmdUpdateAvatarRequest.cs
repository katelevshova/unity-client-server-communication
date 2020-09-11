using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdUpdateAvatarRequest : Command
{
    /**
     * This example could have only one parameter such as
     * int avatarHeadTypeId however this is an example for how it would look like if
     * we need to pass lots of other parameters
     * */
    public override void Execute(Dictionary<string, object> parameters)
    {
        base.Execute(parameters);
        PrintParameters();

        //Send message to the server
        string message = BuildMessageToServer();
        Debug.Log("message= " + message);
        //TODO: uncomment this line when the connection starts working
        //GameController.Instance.connectorProxy.Send(message);
    }
}
