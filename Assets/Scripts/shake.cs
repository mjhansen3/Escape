using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator cameraAnimation;

    public void CameraShake()
    {
        cameraAnimation.SetTrigger("Shake");
    }
}