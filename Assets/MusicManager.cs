using UnityEngine;
using System;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MusicManager : MonoBehaviour
{
    private static FMOD.Studio.EventInstance Music; //An event instance variable.

    private float Distance; //A variable which will hold the distance between the player and the goal that we set for them.
    private Vector3 GoalLocation; //A variable for holding co-ordinates of the goal our player is trying to reach.
    public GameObject Goal;  //A reference which we'll use to reference the goal, and through that we'll get the goals co-ordinates.
    private float progressLevel;  //Holds a value to represent how many "progress switches" the player has hit.


    void Start()
    {
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/Music");
        Music.start();
        Music.release();

        GoalLocation = Goal.transform.position;
    }

    /*public void Progress(float ProgressLevel)
    {
        Music.setParameterByName("Danger", ProgressLevel);
        progressLevel = ProgressLevel;
    }*/

    private void Update()
    {

        Distance = Vector3.Distance(Controller.Instance.transform.position, GoalLocation);
        Music.setParameterByName("DistanceToGoal", Distance);
        Debug.Log(Distance);

    }

    private void OnDestroy()
    {
        Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}

