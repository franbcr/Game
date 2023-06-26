using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessController : MonoBehaviour
{
    [SerializeField] private Volume myPostProcess;
    [SerializeField] private float intensity;

    private Bloom bloomEffect;

    private void ChangeBloomIntensity()
    {
        if (myPostProcess.sharedProfile.TryGet(out Bloom valueBloom))
        {
            valueBloom.intensity.value = intensity;
        }
    }

    private void DisableBloom()
    {
        if (myPostProcess.sharedProfile.TryGet(out Bloom valueBloom))
        {
            valueBloom.intensity.value = 0;
        }
    }

    void Update()
    {
        if (Input.GetKey("l"))
        {
            ChangeBloomIntensity();
        }
        if (Input.GetKey("o"))
        {
            DisableBloom();
        }
    }
}
