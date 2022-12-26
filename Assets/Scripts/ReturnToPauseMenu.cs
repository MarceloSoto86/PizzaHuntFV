using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPauseMenu : MonoBehaviour
{

    public static bool isOptionsActive = true;
    [SerializeField] GameObject optionsMenu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        { optionsMenu.SetActive(false); }
    }
    /*public void OnClick()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOptionsActive)
            {
                volverAMenuPausa();
            }
            else
            {
                continuaMenuOpcionesPausa();
            }
        }
    }


    public void volverAMenuPausa()
    {
        optionsMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isOptionsActive = false;
    }

    public void continuaMenuOpcionesPausa()
    {
        optionsMenu.SetActive(true);
        Time.timeScale = 1.0f;
        isOptionsActive = true;*/
    /*}*/
}
