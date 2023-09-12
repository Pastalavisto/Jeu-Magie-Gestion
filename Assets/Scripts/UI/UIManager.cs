using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    private UIDocument _uiDocument;
    private VisualTreeAsset _mainUI;
    private VisualTreeAsset _inventoryUI;
    private VisualTreeAsset _currentUI;
    private MainUI _mainUIScript;
    void Start()
    {
        _mainUIScript = GetComponent<MainUI>();
        _mainUI = Resources.Load<VisualTreeAsset>("UI/MainUI");
        _inventoryUI = Resources.Load<VisualTreeAsset>("UI/InventoryUI");
        _currentUI = _mainUI;
        _uiDocument = GetComponent<UIDocument>();
    }

    public void SwitchUI() {
        if (_currentUI == _mainUI) {
            _uiDocument.visualTreeAsset = _inventoryUI;
            _currentUI = _inventoryUI;
        }else {
            _uiDocument.visualTreeAsset = _mainUI;
            _currentUI = _mainUI;
            _mainUIScript.UpdateRoot();
        }
    }

}
