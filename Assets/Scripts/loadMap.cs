using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadMap : MonoBehaviour {

	Button[,] buttons = new Button[10, 10];
	int i,j;
	public static int player = 1;
	public Transform parent;
	public static int[,] Map = new int[10, 10]; 

	void Start () {
		for (i = 0; i < 10; i++){
				for (j = 0; j < 10; j++) {
					Vector3 pos = new Vector3 ((-486) + i * 108f, (432) - j * 108, 0);	
					buttons [i, j] = (Button)Instantiate (Resources.Load ("Prefabs/Cell", typeof(Button))) as Button;
					buttons [i, j].transform.SetParent (parent);  
					buttons [i, j].transform.localPosition = pos;
					Map [i, j] = 0;
				}
			}
	}

	public static bool win(){
		for (int x = 0; x < 10; x++) {
			for (int y = 0; y < 10; y++) {
				int Count = 0;
				int i = x;
				int j = y;

				//Xet theo chieu ngang 
				if (Map [x, y] != 0) {
					while ((j < 10) && (Map [x, y] == Map [i, j])) {
						Count = Count + 1;
						j = j + 1;
						if (Count == 5) {
							//Debug.Log (x + " " + y);
							return true;
						}
					}
					j = y;
					Count = Count - 1;
					while ((j >= 0) && (Map [x, y] == Map [i, j])) {
						Count = Count + 1;
						j = j - 1;
						if (Count == 5) {
							//Debug.Log (x + " " + y);
							return true;
						}
					}
					// Xet chieu doc
					Count = 0; i = x; j = y;
					while ((i < 10) && (Map [x, y] == Map [i, j])) {
						Count = Count + 1;
						i = i + 1;
						if (Count == 5)
							return true;
					}
					i = x; Count = Count - 1;
					while ((x >= 0) && (Map [x, y] == Map [i, j])) {
						Count = Count + 1;
						i = i - 1;
						if (Count == 5)
							return true;
					}
					// Xet duong cheo
					Count = 0; i = x; j = y;
					while ((i < 10) && (j < 10) && (Map [x, y] == Map [i, j])) {
						Count = Count + 1;
						i = i + 1;
						j = j + 1;
						if (Count == 5)
							return true;
					}
					Count = Count - 1; i = x; j = y;
					while ((i >= 0) && (j >= 0) && (Map [x, y] == Map [i, j])) {
						Count = Count + 1;
						i = i - 1;
						j = j - 1;
						if (Count == 5)
							return true;
					}
					//Xet duong cheo
					Count = 0; i = x; j = y;
					while ((i < 10) && (j >= 0) && (Map [x, y] == Map [i, j])) {
						Count = Count + 1;
						i = i + 1;
						j = j -	1;
						if (Count == 5)
							return true;
					}
					Count = Count - 1; i = x; j = y;
					while ((i >= 0) && (j < 10) && (Map [x, y] == Map [i, j])) {
						Count = Count + 1;
						i = i - 1;
						j = j + 1;
						if (Count == 5)
							return true;
					}
				}
			}
		}
		return false;
	}
}
