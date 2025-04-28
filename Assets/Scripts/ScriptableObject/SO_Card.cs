using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(menuName = "Profile/Card")]
public class SO_Card : ScriptableObject
{
    public string Name;
    public string Description;
    public Type ElementalType;
    
    public int Cost;
    public int Health;
    public int AttackDamage;

    public Vector3 Offset;

    [Space, ShowAssetPreview]
    public Sprite CharacterImage;

    public enum Type{
        Fire,
        Ice,
        Wind,
        Lightning,
        Earth,
        Water

    }
    
}
