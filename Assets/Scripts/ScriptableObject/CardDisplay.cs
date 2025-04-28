using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NaughtyAttributes;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private SO_Card _cardProfile;

    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _type;

    [SerializeField] private TMP_Text _costText;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _atkText;

    [SerializeField] private Image _characterImage;

    [Button]
    public void SetupCard(){
        _name.text = _cardProfile.Name;
        _description.text = _cardProfile.Description;
        _type.text = _cardProfile.ElementalType.ToString();

        _costText.text = _cardProfile.Cost.ToString();
        _healthText.text = _cardProfile.Health.ToString();
        _atkText.text = _cardProfile.AttackDamage.ToString();

        _characterImage.sprite = _cardProfile.CharacterImage;

        _characterImage.rectTransform.localPosition = _cardProfile.Offset;
    }

}
