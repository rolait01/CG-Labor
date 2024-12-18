using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public Animator animator; // Referenz auf den Animator

    void Start()
    {
        if (animator == null)
        {
            Debug.LogError("Animator ist nicht zugewiesen!");
        }
    }

    public void PlayAnimation()
    {
        animator.SetTrigger("PlayAnimation"); // Trigger auslösen
    }
}