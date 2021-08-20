using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;

    private GameObject spawnedObject;
    private ARRaycastManager m_ARRaycastManager;
    private Vector2 touchPosition;

    private static List<ARRaycastHit> m_arRaycastHits = new List<ARRaycastHit>();

    private void Awake()
    {
        m_ARRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        else
        {
            touchPosition = default;
            return false;
        }
    }

    private void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;
        if (m_ARRaycastManager.Raycast(touchPosition, m_arRaycastHits, TrackableType.PlaneWithinPolygon))
        {
            var hitpos = m_arRaycastHits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(gameObjectToInstantiate, hitpos.position, hitpos.rotation);
            }
            else
            {
                spawnedObject.transform.position = hitpos.position;
            }
        }
    }
}