using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugWallTrigger : MonoBehaviour
{
    public Team27GestureAudio.WhichWall whichWall;

    public void TriggerDebugWall()
    {
        Vector3 controllerPosition = new Vector3(0, 1, 0);
        if(whichWall == Team27GestureAudio.WhichWall.Wall1)
        {
            Team27GestureAudio.Instance.GestureReceived(controllerPosition, Vector3.forward);
        }
        else if(whichWall == Team27GestureAudio.WhichWall.Wall2)
        {
            Team27GestureAudio.Instance.GestureReceived(controllerPosition, Vector3.right);
        }
        else if (whichWall == Team27GestureAudio.WhichWall.Wall3)
        {
            Team27GestureAudio.Instance.GestureReceived(controllerPosition, Vector3.back);
        }
        else if (whichWall == Team27GestureAudio.WhichWall.Wall4)
        {
            Team27GestureAudio.Instance.GestureReceived(controllerPosition, Vector3.left);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
