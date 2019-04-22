/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
///
/// Changes made to this file could be overwritten when upgrading the Vuforia version.
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>

public class AnimTrackable : MonoBehaviour, ITrackableEventHandler
{
    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;
    public Animator objectAnim1;
    public Animator objectAnim2;
    public GameObject bunny;
    public GameObject messages;
    FadeObject fade;
    public GameObject btnInsta;
    public float waitMessagesAct;
    public float waitMessagesActPos;
    //public GameObject canvas1;
    //fade
    public UnityEngine.UI.Image homeScreenSprite;
    public float fadeSpeed = 0.8f;
    int drawDepth = -1000;
    float alpha = 1.0f;
    int fadeDir = -1;

    private YieldInstruction fadeInstruction = new YieldInstruction();

    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        var videoPlayer = gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();
        fade = GetComponent<FadeObject>();
        
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();

        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
            //vp.Pause();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {

        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);
        waitMessagesAct = 20.54f;
        waitMessagesActPos = 9.35f;
        StartCoroutine(FadeOut());
        //canvas1.SetActive(false);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
        StopCoroutine(AnimSwitch());
        StartCoroutine(AnimSwitch());
    }


    protected virtual void OnTrackingLost()
    {

        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);
        //canvas1.SetActive(true);
        btnInsta.SetActive(false);
        StartCoroutine(FadeIn());
      
        

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;


        bunny.SetActive(false);

    }

    #endregion // PROTECTED_METHODS

    public IEnumerator AnimSwitch()
    {
    
        bunny.SetActive(true);
        messages.SetActive(false);
        yield return new WaitForSeconds(waitMessagesAct);
        messages.SetActive(true);
        yield return new WaitForSeconds(waitMessagesActPos);
        messages.SetActive(false);
        btnInsta.SetActive(true);

    }


    IEnumerator FadeOut()
    {
        float elapsedTime = 0.0f;
        Color c = homeScreenSprite.color;
        while (elapsedTime < fadeSpeed)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeSpeed);
            homeScreenSprite.color = c;
        }
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0.0f;
        Color c = homeScreenSprite.color;
        while (elapsedTime < fadeSpeed)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / fadeSpeed);
            homeScreenSprite.color = c;
        }
    }

}
