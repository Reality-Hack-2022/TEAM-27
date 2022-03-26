using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Reaktion;

public class Team27GestureAudio : MonoBehaviour
{
    public static Team27GestureAudio Instance;

    public enum WhichWall { Wall1, Wall2, Wall3, Wall4}
    public List<AudioStem> activeStems;
    public AudioStem[] stems;

    public Reaktor kickReaktor;
    public Reaktor snareReaktor;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        activeStems.Add(stems[1]);
        activeStems.Add(stems[2]);
        activeStems.Add(stems[3]);
         foreach(AudioStem stem in stems)
        {
            stem.rhythmSource.volume = 0f;
            stem.rhythmSource.Play();
            stem.harmonySource.volume = 0f;
            stem.harmonySource.Play();
            stem.rhythmKickReaktion.Play();
            stem.rhythmSnareReaktion.Play();
        }
    }

    public void GestureReceived(Vector3 controllerPosition, Vector3 controllerVelocity)
    {
        Debug.DrawRay(controllerPosition, controllerVelocity, Color.green, 1f);
        if(Physics.Raycast(controllerPosition, controllerVelocity, out RaycastHit hit, 20f))
        {
            if (hit.transform.gameObject.CompareTag("TriggerWall"))
            {
                Debug.Log("I hit the trigger wall: " + hit.transform.gameObject.name);
                WhichWall hitWall = hit.transform.gameObject.GetComponent<WhichWallHolder>().whichWall;
                if(hitWall == WhichWall.Wall1)
                {
                    BumpStems(0);
                }
                else if(hitWall == WhichWall.Wall2)
                {
                    BumpStems(1);
                }
                else if(hitWall == WhichWall.Wall3)
                {
                    BumpStems(2);
                }
                else if (hitWall == WhichWall.Wall4)
                {
                    BumpStems(3);
                }
            }
            else
            {
                Debug.Log("I hit nothing.");
            }
        }
    }

    void BumpStems(int sentValue)
    {
       //Debug.Log("Bumping the stems with: " + stems[sentValue].name + "from int: " + sentValue);
        //at some point, implement play trigger sound

            //turn off last audiosource
            activeStems[2].rhythmSource.volume = 0f;
        activeStems[2].rhythmKickReaktion.volume = 0f;
        activeStems[2].rhythmSnareReaktion.volume = 0f;
            //Debug.Log("Turning down volume on: " + activeStems[2].rhythmSource.name);
            //bump on deck to last, disable harmony
            activeStems[2] = activeStems[1];
            activeStems[2].harmonySource.volume = 0f;
            //Debug.Log("Turning down volume on: " + activeStems[2].harmonySource.name);
            //bump most recent to on deck
            activeStems[1] = activeStems[0];
            //set most recent to the sent value
            activeStems[0] = stems[sentValue];
            activeStems[0].rhythmSource.volume = 1f;
            activeStems[0].harmonySource.volume = 1f;
        activeStems[0].rhythmKickReaktion.volume = 1f;
        kickReaktor.injector = activeStems[0].debugKickReaktor.injector;
        activeStems[0].rhythmSnareReaktion.volume = 1f;
        snareReaktor.injector = activeStems[0].debugSnareReaktor.injector;


    }

}