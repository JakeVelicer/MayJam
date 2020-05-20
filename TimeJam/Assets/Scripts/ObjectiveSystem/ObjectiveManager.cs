using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager instance;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public Objective[] objectiveList;

    public void CompleteTask(string objectiveName, string taskName)
    {
        foreach(Objective o in objectiveList)
        {
            if (o.name == objectiveName)
            {
                o.Complete(taskName);
            }
        }
    }

    public void CheckProgress()
    {
        foreach(Objective o in objectiveList)
        {
            if (!o.AnyVariationCompleted())
            {
                return;
            }
        }

        FinishGame();
    }

    public void FinishGame()
    {
        //Spawn the exit to the game.
    }
}
