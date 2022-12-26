using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
     
    private HealthPoints _healthPoints;

    /*public HealthPoints healthPoints;*/

    private void Start()
    {
        _healthPoints = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPoints>();
        _healthPoints.MuerteJugador += ActivarMenu;
    }

    private void ActivarMenu(object sender, EventArgs e)
    {  gameOverScreen.SetActive(true); }

  /*  public void SetGameOver()
    {
       //77if(HealthPoints.health <= 0)
       // {
            //Estamos muertos
            //Activar animación muerte (activar en variables arriba la línea de código para el animator)
            // animDeath.SetBool("IsDead",true);
            //Activar GameOver screen


            gameOverScreen.SetActive(true);

        }*/
        //*/
        

        /*Time.timeScale = 0;*/

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
    }

    public void ReturnGame()
    {
       /* Time.timeScale = 1;*/
        SceneManager.LoadScene("Menu Principal");
    }

    public void Salir()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
