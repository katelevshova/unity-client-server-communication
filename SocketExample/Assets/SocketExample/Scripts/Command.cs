using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command
{
    public string name;
    public List<string> parameters;

    virtual public void Execute(List<string> parameters)
    {
    }
}
