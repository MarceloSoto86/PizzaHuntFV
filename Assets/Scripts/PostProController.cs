using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering.PostProcessing;

public class PostProController : MonoBehaviour
{
    [SerializeField] PostProcessProfile defaultProfile;

    private void Start()
    {
        GetComponent<PostProcessVolume>().sharedProfile = defaultProfile;
    }
    public void ChangeProfile(PostProcessProfile profile)
    {
        GetComponent<PostProcessVolume>().sharedProfile = profile;
        Debug.Log(profile.ToString());
    }
}
