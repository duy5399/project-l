using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance { get; private set; }

    [SerializeField] private TMP_InputField nicknameInputField;
    [SerializeField] private Button createCharacterButton;
    [SerializeField] private TextMeshProUGUI _alertText;

    public TextMeshProUGUI alertText
    {
        get { return _alertText; }
        set { _alertText = value; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        nicknameInputField = transform.GetChild(0).GetComponent<TMP_InputField>();
        createCharacterButton = transform.GetChild(1).GetComponent<Button>();
        alertText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        nicknameInputField.text = string.Empty;
        createCharacterButton.onClick.AddListener(OnClick_CreateCharacter);
        alertText.text = string.Empty;
    }

    private void OnDisable()
    {
        nicknameInputField.text = string.Empty;
        createCharacterButton.onClick.RemoveListener(OnClick_CreateCharacter);
        alertText.text = string.Empty;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick_CreateCharacter()
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(true);
        SocketIO.instance.characterSocketIO.Emit_CreateCharacter(nicknameInputField.text);
    }
}
