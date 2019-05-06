using UnityEngine;

public class shake : MonoBehaviour
{
    public Animator cameraAnimation;

    public void CameraShake()
    {
        cameraAnimation.SetTrigger("shake");
    }
}
