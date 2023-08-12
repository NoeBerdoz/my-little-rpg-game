using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ScreenShakeManager : Singleton<ScreenShakeManager>
{
    private const string GLOBAL_VOLUME_PROFILE = "Global Volume";
    
    private float redVignetteColorTime = 0.1f;

    private CinemachineImpulseSource source;
    private Volume globalVolume;

    private Vignette originalVignette;
    private Color originalVignetteColor;
    
    protected override void Awake()
    {
        base.Awake();
        
        source = GetComponent<CinemachineImpulseSource>();
        globalVolume = GameObject.Find(GLOBAL_VOLUME_PROFILE).GetComponent<Volume>();
        globalVolume.profile.TryGet<Vignette>(out Vignette vignette);
        originalVignette = vignette;
        originalVignetteColor = vignette.color.value;
    }

    public void ShakeScreen()
    {
        source.GenerateImpulse();
    }

    public void ChangeVignetteColor()
    {
        StartCoroutine(ChangeVignetteColorRoutine());
    }

    private IEnumerator ChangeVignetteColorRoutine()
    {
        originalVignette.color.Override(Color.red);    
        yield return new WaitForSeconds(redVignetteColorTime);
        originalVignette.color.Override(originalVignetteColor);
    }
}
