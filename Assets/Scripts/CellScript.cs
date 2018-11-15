using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellScript : MonoBehaviour {

	public int iResult = -1;
	public static int x = 1;
	public static int y = 1;

	public void getEventButtonClick()
	{	
		if (iResult == -1) {
			x = (int)(gameObject.transform.localPosition.x - (-486)) / 108;
			y = (int)(432 - gameObject.transform.localPosition.y ) / 108;
			//Debug.Log (y + " " + x);
			//Debug.Log(gameObject.transform.localPosition.x+" "+gameObject.transform.localPosition.y);
			loadMap.Map [y, x] = loadMap.player;

			if (loadMap.player == 1) {
				gameObject.GetComponent<Image> ().color = Color.blue; 
				loadMap.player = 2;
			} else {
				gameObject.GetComponent<Image> ().color = Color.red;
				loadMap.player =  1;
			}
			iResult = loadMap.player;
			if (loadMap.win () == true)
				Debug.Log ("Win");
		}
	}
}
