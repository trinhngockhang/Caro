using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CellScript : MonoBehaviour {
    public int iResult = -1;
	public static int x = 1;
	public static int y = 1;
    public Sprite X;
    public Sprite O;
    public static int win = 0;
    public Text text;
    public static int player = 1;
    public Controller controller;
    public static int[] bigSize = new int[4];
	public void getEventButtonClick()
	{
        if (win == 0)
        {
            if (iResult == -1)
            {
                x = (int)(gameObject.transform.localPosition.x - (-486)) / 108;
                y = (int)(600 - gameObject.transform.localPosition.y) / 108;
                Debug.Log(x + " " + y + "  " + player);
                loadMap.Border = updateSize(x, y, loadMap.Border);
                Debug.Log("minwidth : " + loadMap.Border[0] + " max width " + loadMap.Border[1] + " min height" + loadMap.Border[2] + " max height " + loadMap.Border[3]);
                //Debug.Log(gameObject.transform.localPosition.x+" "+gameObject.transform.localPosition.y);
                loadMap.BigMap[y, x] = player;
                if (loadMap.win(loadMap.BigMap, y, x) == true)
                {
                    Debug.Log("Win");
                    win = 1;
                }
                if (player == 1)
                {
                    gameObject.GetComponent<Image>().sprite = X;
                    player = 2;
                    if (SceneManager.GetActiveScene().name.ToString() == "AI")
                    {
                        Controller.MiniMax();
                    }
                    //Debug.Log(player);
                }
                else
                {
                    gameObject.GetComponent<Image>().sprite = O;

                    player = 1;
                }
                iResult = player;

                loadMap.instance.checkTurn();
            }
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
