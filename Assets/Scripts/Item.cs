using UnityEngine;

public class Item : MonoBehaviour, ICollectable
{
    public void Collect(){
        Debug.Log("Item collected!");
        Destroy(gameObject); //destroy the item
    }
}
