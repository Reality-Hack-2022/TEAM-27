using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TriggerScatter : MonoBehaviour
{
   
   
		public string floatParameterName;
       
        public VisualEffect yourVisualEffect;
		
  
    void OnTriggerEnter(Collider other)
    {
       yourVisualEffect.SetFloat(floatParameterName, 0.62f);
	   Debug.Log("entered");
    }
   
    void OnTriggerExit(Collider other)
    {
       yourVisualEffect.SetFloat(floatParameterName, 0.01f);
	   Debug.Log("exited");
    }
}
