using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public string name;
    public string description;
    private bool completed;

    public void Complete()
    {
        completed = true;
    }

    public bool GetCompleted()
    {
        return completed;
    }
}
