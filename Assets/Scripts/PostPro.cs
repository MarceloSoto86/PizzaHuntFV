using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostPro : MonoBehaviour

{
    [SerializeField] private PostProcessVolume _postProcessVolume;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_postProcessVolume.isGlobal == true)
        {
            _postProcessVolume.weight = Mathf.Lerp(_postProcessVolume.weight, 1f, Time.deltaTime);
        }
        
        
    }
}
