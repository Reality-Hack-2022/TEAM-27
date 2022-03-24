using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorControl : MonoBehaviour
{
	public Material ball;
	
	private Slider color_picker;
	
	public float hue;
	
	
	
    void Start()
    {
        color_picker = this.gameObject.GetComponent<Slider>();
		
    }

    
    public void GetColor()
    {
        hue = color_picker.value;
		ball.SetFloat("_hue", hue);
		
    }
}
