using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorControl2 : MonoBehaviour
{
	public Material ball;
	

	private Slider color_picker2;

	public float hue2;
	
	
    void Start()
    {
     
		color_picker2 = this.gameObject.GetComponent<Slider>();
    }

    
    public void GetColor2()
    {
      
		hue2 = color_picker2.value;
		ball.SetFloat("_hue2", hue2);
    }
}
