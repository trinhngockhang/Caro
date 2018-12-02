using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class loadMap : MonoBehaviour {
    public static int height = 15;
    public static int width = 10;
    public Text turn;
    public static Button[,] buttons = new Button[width, height];
    public static int[] Border = { 15, 0, 15, 0 };
    int i,j;
	
	public Transform parent;
	public static int[,] BigMap = new int[height, height];
    public static bool End ;
    public static loadMap instance;
    public Text winText;

	void Start () {
      initial();
      _makeInstance();
    }

    void _makeInstance()
    {
        if (instance == null) instance = this;
    }
    void initial(){
    End = false;
    winText.text = "";
    CellScript.win = 0;
    CellScript.player = 1;
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

   public  void checkTurn(){
        if (CellScript.win != 1)
        {
            if (SceneManager.GetActiveScene().name.ToString() != "AI")
            {
                if (CellScript.player == 2)
                {
                    turn.text = "Turn:P2";
                }
                else
                {
                    turn.text = "Turn:P1";
                }
            }
        }
        else
        {

            if (SceneManager.GetActiveScene().name.ToString() == "AI")
            {
                if (CellScript.player == 1)
                {
                    winText.text = "AI WIN";
                }
                else
                {
                    winText.text = "YOU WIN";
                }
            }
            else
            {
                turn.text = "";
                if (CellScript.player == 1)
                {
                    winText.text = "P2 win";
                }
                else
                {
                    winText.text = "P1 win";
                }
            }
        }
    }
    void Update()
    {
       
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
    public void returnHome(){
      SceneManager.LoadScene("Menu");
      initial();
      clear();
    }

    public void clear(){
        initial();
        Border[0] = 15;
        Border[1] = 0;
        Border[2] = 15;
        Border[3] = 0;
    }

    public void again(){
        if (SceneManager.GetActiveScene().name.ToString() == "AI")
        {
            SceneManager.LoadScene("AI");
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
        clear();
    }
  

  
}
