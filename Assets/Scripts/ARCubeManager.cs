using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Random = UnityEngine.Random;

public class ARCubeManager : MonoBehaviour
{
    public GameObject spawnedPrefab;
    public GameObject particleEffect;
    public GameObject onButton;
    public GameObject offButton;
    public AudioSource audioSource;
    public AudioClip clip;
    
    private GameObject _spawnedObject;
    private GameObject _lastSpawnedObject;
    private bool _blowEmUpMode;
    private ARRaycastManager _arrayManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        _blowEmUpMode = false;
        _arrayManager = GetComponent<ARRaycastManager>();
    }

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
                        var cubePosition = hit.collider.transform.position;
                        if (_blowEmUpMode)
                        {
                            particleEffect = Instantiate(particleEffect, cubePosition, quaternion.identity);
                            Destroy(hit.collider.gameObject);
                            audioSource.PlayOneShot(clip, 1);

                        }
                    }
                    else if (_arrayManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
                    {
                        var hitpose = hits[0].pose;
                        _spawnedObject = Instantiate(spawnedPrefab, hitpose.position, hitpose.rotation);
                        _spawnedObject.tag = "Cube";
                    }
                }
            }
        }
    }
    public void BlowEmUpMode()
    {
        _blowEmUpMode = true;
        offButton.SetActive(false);
        onButton.SetActive(true);
    }
    
    public void BlowEmUpModeOff()
    {
        _blowEmUpMode = false;
        offButton.SetActive(true);
        onButton.SetActive(false);
    }
}


