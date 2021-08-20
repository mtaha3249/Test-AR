using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageRecognitionExample : MonoBehaviour
{
    private ARTrackedImageManager m_ARTrackedImageManager;

    void Awake()
    {
        m_ARTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        m_ARTrackedImageManager.trackedImagesChanged += ARTrackedImageManagerOntrackedImagesChanged;
    }

    private void OnDisable()
    {
        m_ARTrackedImageManager.trackedImagesChanged -= ARTrackedImageManagerOntrackedImagesChanged;
    }

    private void ARTrackedImageManagerOntrackedImagesChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (var trackedImage in obj.added)
        {
            Debug.Log(trackedImage.name);
        }
    }
}