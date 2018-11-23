using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {

    public void onePlayer(){
        SceneManager.LoadScene("AI");
    }

    public void twoPlayers()
    {
        SceneManager.LoadScene("Game");
    }
}
