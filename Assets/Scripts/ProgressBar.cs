using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Transform bar;

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}

