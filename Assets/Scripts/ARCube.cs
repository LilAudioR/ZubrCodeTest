using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARCube : MonoBehaviour
{
    public GameObject _spawnedPrefab;

    private GameObject _spawnedObject;
    private GameObject _lastSpawnedObject;

    private bool _objectSpawned;

    private ARRaycastManager arrayManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        _objectSpawned = false;
        arrayManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("HIT");
                    if (hit.collider.CompareTag("Cube"))
                    {
                        Color newColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f),
                            Random.Range(0.0f, 1.0f), 1);
                        hit.collider.GetComponent<MeshRenderer>().material.color = newColor;
                        Debug.Log("Colour Changed!");
                        
                    }
                    else if (arrayManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
                    {
                        var hitpose = hits[0].pose;
                        _spawnedObject = Instantiate(_spawnedPrefab, hitpose.position, hitpose.rotation);
                        _spawnedObject.tag = "Cube";
                        _objectSpawned = true;
                    }
                }
            }
        }
    }
}


