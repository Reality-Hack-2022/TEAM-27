using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TriggerScatter : MonoBehaviour
{
   
   
		public string floatParameterName;
		//public string floatParameterName1;
		//public string floatParameterName2;
		//public string floatParameterName3;
		//public string floatParameterName4;
        public GameObject audioreact;
        public VisualEffect yourVisualEffect;
		 AudioSource audiostem;
		public GameObject audiostemhome;
	public float fadeOutTime = 5f;
		
  
	 void Start()
    {
		 audiostem = audiostemhome.GetComponent<AudioSource>();
    } 
	
	
  
  
    void OnTriggerEnter(Collider other)
    {
      yourVisualEffect.SetFloat(floatParameterName, 0.62f);
	   Debug.Log("entered");
	  // yourVisualEffect.SetFloat(floatParameterName1, 5.0f);
	  // yourVisualEffect.SetFloat(floatParameterName2, 20.0f);
	  // yourVisualEffect.SetFloat(floatParameterName3, 0.1f);
	   //yourVisualEffect.SetFloat(floatParameterName4, 50.0f);
	   audioreact.SetActive(true);
	   audiostem.Play();	
	   
    }
   
    void OnTriggerExit(Collider other)
    {
       yourVisualEffect.SetFloat(floatParameterName, 0.01f);
	   Debug.Log("exited");
	   //yourVisualEffect.SetFloat(floatParameterName1, 0.0f);
	  // yourVisualEffect.SetFloat(floatParameterName2, 0.0f);
	  // yourVisualEffect.SetFloat(floatParameterName3, 0.0f);
	   //yourVisualEffect.SetFloat(floatParameterName4, 0.0f);
	   audioreact.SetActive(false);
		//audiostem.Stop();	
		StartCoroutine(FadeOut());
    }

	IEnumerator FadeOut()
    {
		for(float i = 1; i >=0; i -= .1f)
        {
			audiostem.volume = i;
			yield return new WaitForSeconds(fadeOutTime / 10f);
        }
		audiostem.Stop();
    }
}
