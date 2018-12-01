﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadMap : MonoBehaviour {
    public static int height = 15;
    public static int width = 10;
    //public Text turn;
    public static Button[,] buttons = new Button[width, height];
    public static int[] Border = { 15, 0, 15, 0 };
    int i,j;
	public static int player = 1;
	public Transform parent;
	public static int[,] BigMap = new int[height, height]; 
    public static bool End = false;

    public GameObject win1;
    public GameObject win2;
    public Text text;

	void Start () {

        for (i = 0; i < width; i++){
            for (j = 0; j < height; j++) {
                Vector3 pos = new Vector3((-486) + i * 108f, (600) - j * 108, 0);
                buttons [i, j] = (Button)Instantiate (Resources.Load ("Prefabs/Cell", typeof(Button))) as Button;
					buttons [i, j].transform.SetParent (parent);  
					buttons [i, j].transform.localPosition = pos;
                    BigMap[i, j] = 0;
				}
			}
    }

    void Update()
    {   
        if (CellScript.win == 1) {
            win1.SetActive(true);
            win2.SetActive(true);
            if (player == 1)
            {
                text.text = "AI WIN";
            }
            else {
                text.text = "YOU WIN";
            }
        }    
    }

    public static bool win(int[,] fakeMap, int posX, int posY)
    {
        int Count = 0;
        int x = posX;
        int y = posY;
        int i = x;
        int j = y;

        //Xet theo chieu ngang 
        if (fakeMap[x, y] != 0)
        {
            while (j < 10)
            {
                if (fakeMap[x, y] == fakeMap[i, j])
                {
                    Count = Count + 1;
                }
                else
                    break;
                j = j + 1;
                if (Count == 5)
                {
                    //Debug.Log (x + " " + y);
                    return true;
                }
            }
            j = y;
            Count = Count - 1;
            while (j >= 0)
            {
                if (fakeMap[x, y] == fakeMap[i, j])
                {
                    Count = Count + 1;
                }
                else
                    break;
                j = j - 1;
                if (Count == 5)
                {
                    //Debug.Log (x + " " + y);
                    return true;
                }
            }
            // Xet chieu doc
            Count = 0; i = x; j = y;
            while (i < 15)
            {
                if (fakeMap[x, y] == fakeMap[i, j])
                {
                    Count = Count + 1;
                }
                else
                    break;
                i = i + 1;
                if (Count == 5)
                    return true;
            }
            i = x; Count = Count - 1;
            while (i >= 0)
            {
                if (fakeMap[x, y] == fakeMap[i, j])
                {
                    Count = Count + 1;
                }
                else
                    break;
                i = i - 1;
                if (Count == 5)
                    return true;
            }
            // Xet duong cheo
            Count = 0; i = x; j = y;
            while ((i < 15) && (j < 10))
            {
                if (fakeMap[x, y] == fakeMap[i, j])
                {
                    Count = Count + 1;
                }
                else
                    break;
                i = i + 1;
                j = j + 1;
                if (Count == 5)
                    return true;
            }
            Count = Count - 1; i = x; j = y;
            while ((i >= 0) && (j >= 0))
            {
                if (fakeMap[x, y] == fakeMap[i, j])
                {
                    Count = Count + 1;
                }
                else
                    break;
                i = i - 1;
                j = j - 1;
                if (Count == 5)
                    return true;
            }
            //Xet duong cheo
            Count = 0; i = x; j = y;
            while ((i < 15) && (j >= 0))
            {
                if (fakeMap[x, y] == fakeMap[i, j])
                {
                    Count = Count + 1;
                }
                else
                    break;
                i = i + 1;
                j = j - 1;
                if (Count == 5)
                    return true;
            }
            Count = Count - 1; i = x; j = y;
            while ((i >= 0) && (j < 10))
            {
                if (fakeMap[x, y] == fakeMap[i, j])
                {
                    Count = Count + 1;
                }
                else
                    break;
                i = i - 1;
                j = j + 1;
                if (Count == 5)
                    return true;
            }
        }
        return false;
    }
}
