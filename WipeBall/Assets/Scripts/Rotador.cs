using UnityEngine;
public class Rotator : MonoBehaviour
{
    public float speedY = 100f;
    void Update()
    {
        transform.Rotate(0, speedY * Time.deltaTime, 0);
    }
}