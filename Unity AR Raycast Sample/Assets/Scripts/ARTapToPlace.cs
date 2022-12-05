using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlace : MonoBehaviour
{
    [SerializeField] private ARRaycastManager _arRaycastManager;

    [SerializeField] private GameObject _objectToPlace;

    private Vector2 touchPosition;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Update()
    {
        if (!CanGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            Instantiate(_objectToPlace, hitPose.position, hitPose.rotation);
        }
    }
    private bool CanGetTouchPosition(out Vector2 touchPosition)
    {
        touchPosition = default;

        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        return false;
    }
}
