using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command
{
    public string name;
    public Dictionary<string, object> paramsDict;

    virtual public void Execute(Dictionary<string, object> parameters)
    {
        paramsDict = parameters;
        PrintParameters();
    }

    protected void PrintParameters()
    {
        Debug.Log("-----------------------------");
        Debug.Log("Command name = "+name);
        Debug.Log("paramsDict : ");
        foreach (KeyValuePair<string, object> kvp in paramsDict)
        {
            Debug.Log(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
        }
    }
}
