using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecterCharacter : MonoBehaviour
{
    [SerializeField] private List<MainCharacter> _characters;
    [SerializeField] private ViewMainCharacter _template;
    [SerializeField] private GameObject _container;

    private void Start()
    {
        for (int i = 0; i < _characters.Count; i++)
        {
            AddCharacter(_characters[i]);
        }
    }

    private void AddCharacter(MainCharacter character)
    {
        var ViewCharacter = Instantiate(_template, _container.transform);
        ViewCharacter.Init(character);
    }
}
