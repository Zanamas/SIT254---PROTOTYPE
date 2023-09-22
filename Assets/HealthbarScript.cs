using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{
    public PlayerScript pScript;

    public Image health1;
    public Image health2;
    public Image health3;
    public Image health4;
    public Image health5;
    public Image health6;

    public Sprite hYes;
    public Sprite hNo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(pScript.pHealth.Health)
        {
            case 0:
                health1.sprite = hNo;
                health2.sprite = hNo;
                health3.sprite = hNo;
                health4.sprite = hNo;
                health5.sprite = hNo;
                health6.sprite = hNo;

                break;

            case 1:
                health1.sprite = hYes;
                health2.sprite = hNo;
                health3.sprite = hNo;
                health4.sprite = hNo;
                health5.sprite = hNo;
                health6.sprite = hNo;
                break;

            case 2:
                health1.sprite = hYes;
                health2.sprite = hYes;
                health3.sprite = hNo;
                health4.sprite = hNo;
                health5.sprite = hNo;
                health6.sprite = hNo;
                break;

            case 3:
                health1.sprite = hYes;
                health2.sprite = hYes;
                health3.sprite = hYes;
                health4.sprite = hNo;
                health5.sprite = hNo;
                health6.sprite = hNo;
                break;

            case 4:
                health1.sprite = hYes;
                health2.sprite = hYes;
                health3.sprite = hYes;
                health4.sprite = hYes;
                health5.sprite = hNo;
                health6.sprite = hNo;
                break;

            case 5:
                health1.sprite = hYes;
                health2.sprite = hYes;
                health3.sprite = hYes;
                health4.sprite = hYes;
                health5.sprite = hYes;
                health6.sprite = hNo;
                break;

            case 6:
                health1.sprite = hYes;
                health2.sprite = hYes;
                health3.sprite = hYes;
                health4.sprite = hYes;
                health5.sprite = hYes;
                health6.sprite = hYes;


                break;


        }
        
    }
}
