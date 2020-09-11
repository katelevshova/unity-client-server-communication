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
        //PrintParameters();

        // Update UI
        OnUpdateAvatar?.Invoke((int)parameters["PlayerId"]);
        // Do here something additional using other parameters
    }
}
