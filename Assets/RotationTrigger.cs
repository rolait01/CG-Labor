using UnityEngine;

public class RotationTrigger : MonoBehaviour
{
    public GameObject switchObject; // Das Schalter-Objekt
    public Animator animator;       // Der Animator für die Animation
    public string triggerName = "PlayAnimation"; // Trigger-Name im Animator

    private bool hasTriggered = false; // Verhindert mehrfaches Abspielen

    void Update()
    {
        // Hole die Y-Rotation des Objekts
        float rotationY = switchObject.transform.rotation.eulerAngles.y;

        // Debug-Ausgabe zur Überprüfung der Rotation
        Debug.Log("Current Y-Rotation: " + rotationY);

        // Überprüfe, ob die Rotation ungefähr 0 ist
        if (Mathf.Approximately(rotationY, 0f) || Mathf.Approximately(rotationY, 270f) && !hasTriggered)
        {
            animator.SetTrigger(triggerName);
            hasTriggered = true; // Trigger nur einmal auslösen
        }
        else if (!Mathf.Approximately(rotationY, 0f) && !Mathf.Approximately(rotationY, 270f))
        {
            hasTriggered = false; // Rücksetzen, wenn Rotation nicht mehr zutrifft
        }

    }
}