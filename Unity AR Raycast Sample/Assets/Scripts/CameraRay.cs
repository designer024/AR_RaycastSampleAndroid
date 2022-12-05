using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRay : MonoBehaviour
{
    [SerializeField] private Text _objectLabel;

    private void Update()
    {
        var ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100000f))
        {
            if (hit.collider.tag.Equals("Somethings"))
            {
                _objectLabel.text = $"{hit.collider.name}";
            }
            else
            {
                _objectLabel.text = " ";
            }
        }
        else
        {
            _objectLabel.text = " ";
        }
    }
}