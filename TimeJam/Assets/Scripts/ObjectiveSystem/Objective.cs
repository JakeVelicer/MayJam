using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{

    public string name;
    public Task[] tasks;

    public void Complete(string taskToComplete)
    {
        foreach (Task t in tasks)
        {
            if (t.name == taskToComplete)
            {
                t.Complete();
            }
        }
    }

    public bool AnyVariationCompleted()
    {
        foreach (Task t in tasks)
        {
            if (t.GetCompleted())
            {
                return true;
            }
        }
        return false;
    }

    public bool AllVariationsCompleted()
    {
        foreach (Task t in tasks)
        {
            if (!t.GetCompleted())
            {
                return false;
            }
        }
        return true;
    }
}
