using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour
{
    public float RotateSpeed = 1.0f;

    Vector3 spinSpeed = new Vector3(0, 0, 0);
    Vector3 spinAxis = Vector3.down;

    void Start()
    {
        //spinSpeed = new Vector3(Random.value, Random.value, Random.value);
        // spinAxis.x = .1f; //* (Random.value - Random.value);
    }

    public void SetSize(float size)
    {
        this.transform.localScale = new Vector3(size, size, size);
    }
    public void SetSpinAxis(float speed)
    {
        spinAxis.x = speed;
    }

    void Update()
    {
        this.transform.Rotate(spinSpeed);
        this.transform.RotateAround(Vector3.zero, spinAxis, RotateSpeed);
    }
}
