using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioStem
{
    public AudioSource rhythmSource;
    public AudioSource harmonySource;
}

public class Team27GestureAudio : MonoBehaviour
{
    public static Team27GestureAudio Instance;

    public enum WhichWall { Wall1, Wall2, Wall3, Wall4}
    public Dictionary<int, AudioStem> activeStems;
    public AudioStem[] stems;

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
        foreach(AudioStem stem in stems)
        {
            stem.rhythmSource.volume = 0f;
            stem.rhythmSource.Play();
            stem.harmonySource.volume = 0f;
            stem.harmonySource.Play();
        }
    }

    public void GestureReceived(Vector3 controllerPosition, Vector3 controllerVelocity)
    {
        if(Physics.Raycast(controllerPosition, controllerVelocity, out RaycastHit hit, 20f))
        {
            if (hit.transform.gameObject.CompareTag("TriggerWall"))
            {
                WhichWall hitWall = hit.transform.gameObject.GetComponent<WhichWallHolder>().whichWall;
                if(hitWall == WhichWall.Wall1)
                {
                    BumpStems(0);
                }
                else if(hitWall == WhichWall.Wall2)
                {
                    BumpStems(1);
                }
                else if(hitWall == WhichWall.Wall2)
                {
                    BumpStems(2);
                }
                else if (hitWall == WhichWall.Wall4)
                {
                    BumpStems(3);
                }
            }
        }
    }

    void BumpStems(int sentValue)
    {
        //at some point, implement play trigger sound

        if(activeStems[0] != stems[sentValue] && activeStems[1] != stems[sentValue])
        {
            //turn off last audiosource
            activeStems[2].rhythmSource.volume = 0f;
            //bump on deck to last, disable harmony
            activeStems[2] = activeStems[1];
            activeStems[2].harmonySource.volume = 0f;
            //bump most recent to on deck
            activeStems[1] = activeStems[0];
            //set most recent to the sent value
            activeStems[0] = stems[sentValue];
            activeStems[0].rhythmSource.volume = 1f;
            activeStems[0].harmonySource.volume = 1f;
        }

            
    }

}