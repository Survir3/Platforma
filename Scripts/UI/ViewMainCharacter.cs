using IJunior.TypedScenes;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ViewMainCharacter : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Image _image;
    [SerializeField] private Button _selectButton;

    private AnimatorController _animatorController;

    private void OnEnable()
    {
        _selectButton.onClick.AddListener(SelectCharacter);
    }

    private void OnDisable()
    {
        _selectButton.onClick.RemoveListener(SelectCharacter);
    }

    public void Init(MainCharacter character)
    {
        _name.text = character.Name;
        _image.sprite = character.Sprite;
        _animatorController = character.AnimatorController;
    }

    private void SelectCharacter()
    {
        Time.timeScale = 1;
        Level_1.Load(_animatorController);
    }
}
