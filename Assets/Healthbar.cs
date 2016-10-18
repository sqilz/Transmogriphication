using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
	void Start()
	{
		Image image = GetComponent<Image>();
		
		image.fillAmount = 50;
	}
	void Update()
	{

	}

}
