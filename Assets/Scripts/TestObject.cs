using UnityEngine;

public class TestObject : MonoBehaviour
{
    public PlayerController playerController;
    void Start()
    {
        Debug.Log(PlayerController.Instance._jumpForce);
    }
}
