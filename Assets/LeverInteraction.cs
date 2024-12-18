using UnityEngine;

public class LeverInteraction : MonoBehaviour
{
    public Transform leverHandle; // Der Hebelgriff
    public float minYRotation = -60f; // Minimaler Drehwinkel (aktiviert bei -60°)
    public float maxYRotation = 0f;   // Maximaler Drehwinkel (Startposition)
    public float activationAngle = -60f; // Winkel, bei dem die Animation ausgelöst wird
    public Animator targetAnimator;  // Animator für die Animation
    public string animationTriggerName = "PlayAnimation"; // Trigger-Name für die Animation

    private bool isTriggered = false; // Ob die Animation ausgelöst wurde

    void Update()
    {
        // Hebelrotation basierend auf Benutzerinteraktion
        HandleLeverRotation();

        // Überprüfen, ob der Hebel den Aktivierungswinkel erreicht hat
        float currentYRotation = leverHandle.localEulerAngles.y;

        // Korrigiere den Winkel für sinnvolle Berechnung (-180 bis 180 Grad)
        if (currentYRotation > 180)
            currentYRotation -= 360;

        // Trigger auslösen, wenn der Hebel genau den Aktivierungswinkel erreicht
        if (!isTriggered && Mathf.Approximately(currentYRotation, activationAngle))
        {
            isTriggered = true;

            // Zufällige Verzögerung vor der Animation
            float randomDelay = Random.Range(0.5f, 2.0f);
            Invoke(nameof(TriggerAnimation), randomDelay);
        }
    }

    void HandleLeverRotation()
    {
        // Simulierte Hebelsteuerung für Tests im Editor (ersetze dies mit AR-Interaktion)
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 leverScreenPosition = Camera.main.WorldToScreenPoint(leverHandle.position);

            // Berechne die Drehung basierend auf der Mausposition
            Vector3 direction = mousePosition - leverScreenPosition;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Begrenze den Winkelbereich
            angle = Mathf.Clamp(angle, minYRotation, maxYRotation);

            // Setze die Hebelrotation
            leverHandle.localEulerAngles = new Vector3(
                leverHandle.localEulerAngles.x,
                angle,
                leverHandle.localEulerAngles.z
            );
        }
    }

    void TriggerAnimation()
    {
        if (targetAnimator != null)
        {
            targetAnimator.SetTrigger(animationTriggerName);
        }
    }
}
