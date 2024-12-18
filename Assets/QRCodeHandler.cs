using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class QRCodeHandler : MonoBehaviour
{
    [SerializeField] private GameObject objectToPlace;
    private ARTrackedImageManager trackedImageManager;

    void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            // Platzierung des Objekts auf dem QR-Code
            Instantiate(objectToPlace, trackedImage.transform.position, trackedImage.transform.rotation);
        }
    }
}