using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GraphicQualityController : MonoBehaviour
{

    public TMP_Dropdown dropdown;
    public int quality;

    // Start is called before the first frame update
    void Start()
    {
        quality = PlayerPrefs.GetInt("numeroCalidad", 3);
        dropdown.value = quality;
        AjustarCalidad();
        
    }

   public void AjustarCalidad()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroCalidad",dropdown.value);
        quality = dropdown.value;
    }
}
