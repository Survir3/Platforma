using UnityEngine;
using UnityEngine.UI;

public abstract class Viewer : MonoBehaviour
{
    [SerializeField] protected Text _text;

    protected virtual void OnValueChanged(int value)
    {

    }

    protected virtual void OnValueChanged(float value)
    {

    }
}