using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreenController : MonoBehaviour
{
 

    [SerializeField] GameObject winScreen;

    public void OnCollisionEnter(Collision collision)
    {
       
        winScreen.SetActive(true);

       /* Time.timeScale = 0;*/

    }

    public void ReturnGame()
    {
        /*Time.timeScale = 1;*/
        SceneManager.LoadScene("Menu Principal");
        
    }
}