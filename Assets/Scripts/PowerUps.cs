using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class PowerUps : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] float powerTime = 10f;
    [SerializeField] int powerType = 0;
    [SerializeField] PostProcessProfile profile;
    [SerializeField] GameObject PostProController;

    [SerializeField] private PostProcessVolume  _postProcessVolume;

    bool isPowered = false;
    Vector3 originalScale;

    void Update()
    {
        if (isPowered)
        {
            powerTime -= Time.deltaTime;
        }
        if (powerTime <= 0.0f)
        {
            
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            timerEnded();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            originalScale = transform.localScale;
            PostProController.GetComponent<PostProController>().ChangeProfile(profile);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            

            if (powerType == 0) // Código de power-up GIGANTE
            {
                isPowered = true;
                other.transform.localScale = Vector3.Scale(Vector3.one, new Vector3(originalScale.x +1, originalScale.y + 1, originalScale.z + 1));
                Debug.Log("It's so big!");

                gameObject.GetComponent<Renderer>().enabled = false;
            }
            if (powerType == 1) // Código de power-up PEQUEÑO
            {
                isPowered = true;
                other.transform.localScale = Vector3.Scale(Vector3.one, new Vector3(originalScale.x -0.8f, originalScale.y -0.8f, originalScale.z -0.8f));
                Debug.Log("Ok, so basically im very smol");

                gameObject.GetComponent<Renderer>().enabled = false;
            }
            if (powerType == 2) // Código de power-up SUPER SALTO
            {
                isPowered = true;
                other.GetComponentInChildren<PlayerMovement>().jumpForce = 10f;
                //other.GetComponentInChildren<PlayerMovement>().JumpHeight = 3f;
                Debug.Log("Gave my love to a shooting star :'(");
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                
                _postProcessVolume.isGlobal = true;

                
            }
        }
    }
    void timerEnded()
    {
        Debug.Log("Time ended!");
        Player.transform.localScale = originalScale;
        Player.GetComponentInChildren<PlayerMovement>().jumpForce = 5f;
        _postProcessVolume.isGlobal = false;
        _postProcessVolume.weight = 0;
        //Player.GetComponentInChildren<PlayerMovement>().JumpHeight = 1.2f;
    }
    

}
