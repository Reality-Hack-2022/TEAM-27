using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;


public class VFXSizeControl : MonoBehaviour
{
	
	public VisualEffect yourVisualEffect;
	
	private Slider vfx_size;
	
	public float size;
	
	
	
    void Start()
    {
        vfx_size = this.gameObject.GetComponent<Slider>();
		
    }

    
    public void SetSize()
    {
        size = vfx_size.value;
		yourVisualEffect.SetFloat("Size over time", size);
		
    }
}
