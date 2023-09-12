using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainUI : MonoBehaviour
{
    [SerializeField] Mana _mana;
    private UIDocument _uiDocument;
    private VisualElement _root;
    // Start is called before the first frame update
    void Start()
    {
        _uiDocument = GetComponent<UIDocument>();
        _root = _uiDocument.rootVisualElement;
    }

    // Update is called once per frame
    void Update()
    {
        _root.Q<Label>("Mana").text = _mana.ToString();
    }

    public void UpdateRoot() {
        _root = _uiDocument.rootVisualElement;
    }
}
