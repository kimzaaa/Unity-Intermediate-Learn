using UnityEngine;

public class SpinDatShi : MonoBehaviour
{
    public float RotSpeed = 2f; //100f
    public float UpDownSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * RotSpeed * Time.deltaTime, Space.World);
        transform.position += Vector3.up * Mathf.Sin(Time.time * UpDownSpeed) * Time.deltaTime;
    }
}
//:D