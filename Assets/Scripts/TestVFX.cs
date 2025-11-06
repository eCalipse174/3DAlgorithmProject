using UnityEngine;
using UnityEngine.VFX;

public class TestVFX : MonoBehaviour
{
    [SerializeField] private VisualEffect[] effects = new VisualEffect[3];

    public void PlayVFX(int index)
    {
        effects[index].Play();
    }
}
