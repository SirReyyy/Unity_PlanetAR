using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracker : MonoBehaviour
{
    private ARTrackedImageManager trackedImages;
    public GameObject[] ArPrefabs;

    List<GameObject> ARObjects = new List<GameObject>();


    void Awake() {
        trackedImages = GetComponent<ARTrackedImageManager>();
    } // Awake end


    void OnEnable() {
        trackedImages.trackedImagesChanged += OnTrackedImageChanged;
    } // OnEnabled end


    void OnDisable() {
        trackedImages.trackedImagesChanged -= OnTrackedImageChanged;
    } // OnDisabled end


    private void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs) {
        // Create image based on image tracked
        foreach(var trackedImage in eventArgs.added) {
            foreach(var arPrefab in ArPrefabs) {
                if(trackedImage.referenceImage.name == arPrefab.name) {
                    var newPrefab = Instantiate(arPrefab, trackedImage.transform);
                    ARObjects.Add(newPrefab);
                }
            }
        }

        // Update tracking position
        foreach(var trackedImage in eventArgs.updated) {
            foreach(var gameObject in ARObjects) {
                if(gameObject.name == trackedImage.name) {
                    gameObject.SetActive(trackedImage.trackingState == TrackingState.Tracking);
                }
            }
        }

    } // OnTrackedImageChanged end
}
