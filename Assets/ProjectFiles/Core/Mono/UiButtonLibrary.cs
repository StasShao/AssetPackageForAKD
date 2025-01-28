using ProjectFiles.Core.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ProjectFiles.Core.Mono
{
    public class UiButtonLibrary:MonoBehaviour
    {
        [Inject] private IInput _input;
        [SerializeField] private Text _text;
        [SerializeField] private string _grabText, _dropText;

        public void Grab()
        {
            if (!_input.Select)
            {
                _input.SelectButtonDown(true);
                _text.text = _dropText;
            }else{_input.SelectButtonDown(false);_text.text = _grabText;}
        }
    }
}