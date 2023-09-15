using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Making the game manager a singleton
    public static GameManager gameManager { get; private set; }

    // Awake is called before the first frame update
    void Awake()
    {

        //checks if a gamemanager is already created
        if(gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
