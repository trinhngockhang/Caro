using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellScript : MonoBehaviour {
	public int iResult = -1;
	public static int x = 1;
	public static int y = 1;
    public Controller controller;
    public static int[] bigSize = new int[4];
	public void getEventButtonClick()
	{

		if (iResult == -1) {
			x = (int)(gameObject.transform.localPosition.x - (-486)) / 108;
			y = (int)(432 - gameObject.transform.localPosition.y ) / 108;
			Debug.Log (x + " " + y);
            loadMap.Border =  updateSize(x, y, loadMap.Border);

            Debug.Log("minwidth : " + loadMap.Border[0] + " max width " + loadMap.Border[1] + " min height" + loadMap.Border[2] + " max height " + loadMap.Border[3]);
            //Debug.Log(gameObject.transform.localPosition.x+" "+gameObject.transform.localPosition.y);
            loadMap.BigMap[y, x] = loadMap.player;

			if (loadMap.player == 1) {
				gameObject.GetComponent<Image> ().color = Color.blue; 
				loadMap.player = 2;

                Controller.MiniMax();


			} else {
				gameObject.GetComponent<Image> ().color = Color.red;
				loadMap.player =  1;
			}
			iResult = loadMap.player;
            if (loadMap.win (loadMap.BigMap,y,x) == true)
				Debug.Log ("Win");
		}
	}

    public static int[] updateSize(int x,int y,int[] arr){
        int[] border = new int[4];
        int newMaxWidth = (x + 1 <= loadMap.width - 1 ? (x + 1) : loadMap.width - 1);
        int newMaxHeight = y + 1 <= loadMap.height - 1 ? (y + 1) : loadMap.height - 1;
        int newMinWidth = x - 1 >= 0 ? (x - 1) : 0;
        int newMinHeight = y - 1 >= 0 ? y - 1 : 0;

        arr[1] = newMaxWidth > arr[1] ? newMaxWidth : arr[1];
        arr[3] = newMaxHeight > arr[3] ? newMaxHeight : arr[3];
        arr[0] = newMinWidth < arr[0] ? newMinWidth : arr[0];
        arr[2] = newMinHeight < arr[2] ? newMinHeight : arr[2];
        return arr;
    }
}
