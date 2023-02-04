using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DestroyerAfterAnimation : MonoBehaviour
{    
    public void Destroy()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}