using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacterManager : MonoBehaviour
{
    public static CreateCharacterManager instance { get; private set; }

    [SerializeField] private BasicClassJSON[] basicClass;
    [SerializeField] private JobJSON[] job;
    [SerializeField] private bool curGender;
    [SerializeField] private string curJobId;

    [SerializeField] private Button maleButton;
    [SerializeField] private Button femaleButton;

    [SerializeField] private TMP_InputField nicknameInputField;
    [SerializeField] private Button createButton;
    [SerializeField] private TextMeshProUGUI _alertText;

    [SerializeField] private Button swordmanClassButton;
    [SerializeField] private Button mageClassButton;
    [SerializeField] private Button archerClassButton;

    [SerializeField] private Image mainClass;
    [SerializeField] private Button subClass1Button;
    [SerializeField] private Button subClass2Button;
    [SerializeField] private TextMeshProUGUI curJobNameText;
    [SerializeField] private TextMeshProUGUI curJobDesText;

    [SerializeField] private List<GameObject> mainModelChar;

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
        maleButton = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Button>();
        femaleButton = transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Button>();

        nicknameInputField = transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<TMP_InputField>();
        createButton = transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Button>();
        alertText = transform.GetChild(0).GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>();

        swordmanClassButton = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(0).GetComponent<Button>();
        mageClassButton = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(1).GetComponent<Button>();
        archerClassButton = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(2).GetComponent<Button>();

        mainClass = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(3).GetChild(0).GetComponent<Image>();
        subClass1Button = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(3).GetChild(1).GetComponent<Button>();
        subClass2Button = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(3).GetChild(2).GetComponent<Button>();
        curJobNameText = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(3).GetChild(3).GetComponent<TextMeshProUGUI>();
        curJobDesText = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(3).GetChild(4).GetComponent<TextMeshProUGUI>();

        transform.GetChild(0).GetComponent<Canvas>().worldCamera = GameManager.instance.mainCamera.GetComponent<Camera>();
        transform.GetChild(1).GetComponent<Canvas>().worldCamera = GameManager.instance.mainCamera.GetComponent<Camera>();
    }

    private void OnEnable()
    {
        curJobId = string.Empty;
        nicknameInputField.text = string.Empty;
        alertText.text = string.Empty;
        createButton.onClick.AddListener(OnClick_CreateCharacter);
        maleButton.onClick.AddListener(OnClick_MaleGender);
        femaleButton.onClick.AddListener(OnClick_FemaleGender);
        swordmanClassButton.onClick.AddListener(OnClick_SwordmanClass);
        mageClassButton.onClick.AddListener(OnClick_MageClass);
        archerClassButton.onClick.AddListener(OnClick_ArcherClass);

        //maleButton.onClick?.Invoke();
        //swordmanClassButton.onClick?.Invoke();
    }

    private void OnDisable()
    {
        curJobId = string.Empty;
        nicknameInputField.text = string.Empty;
        alertText.text = string.Empty;
        createButton.onClick.RemoveListener(OnClick_CreateCharacter);
        maleButton.onClick.RemoveListener(OnClick_MaleGender);
        femaleButton.onClick.RemoveListener(OnClick_FemaleGender);
        swordmanClassButton.onClick.RemoveListener(OnClick_SwordmanClass);
        mageClassButton.onClick.RemoveListener(OnClick_MageClass);
        archerClassButton.onClick.RemoveListener(OnClick_ArcherClass);
    }

    void Start()
    {
        SocketIO.instance.createCharacterSocketIO.Emit_GetJobClasses();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick_MaleGender()
    {
        curGender = true;
        maleButton.transform.GetChild(0).GetComponent<Image>().enabled = true;
        femaleButton.transform.GetChild(0).GetComponent<Image>().enabled = false;
        DisplayMainMode();
    }

    void OnClick_FemaleGender()
    {
        curGender = false;
        femaleButton.transform.GetChild(0).GetComponent<Image>().enabled = true;
        maleButton.transform.GetChild(0).GetComponent<Image>().enabled = false;
        DisplayMainMode();
    }

    void OnClick_SwordmanClass()
    {
        swordmanClassButton.transform.GetChild(0).GetComponent<Image>().enabled = true;
        mageClassButton.transform.GetChild(0).GetComponent<Image>().enabled = false;
        archerClassButton.transform.GetChild(0).GetComponent<Image>().enabled = false;
        DisplayClassInfo("class_1");
    }

    void OnClick_MageClass()
    {
        mageClassButton.transform.GetChild(0).GetComponent<Image>().enabled = true;
        swordmanClassButton.transform.GetChild(0).GetComponent<Image>().enabled = false;
        archerClassButton.transform.GetChild(0).GetComponent<Image>().enabled = false;
        DisplayClassInfo("class_2");
    }

    void OnClick_ArcherClass()
    {
        archerClassButton.transform.GetChild(0).GetComponent<Image>().enabled = true;
        swordmanClassButton.transform.GetChild(0).GetComponent<Image>().enabled = false;
        mageClassButton.transform.GetChild(0).GetComponent<Image>().enabled = false;
        DisplayClassInfo("class_3");
    }

    void OnClick_CreateCharacter()
    {
        UIManager.instance.loading01Panel.gameObject.SetActive(true);
        SocketIO.instance.createCharacterSocketIO.Emit_CreateCharacter(nicknameInputField.text, curGender, curJobId);
    }

    public void LoadJobClasses(string basicClass, string job)
    {
        this.basicClass = JsonConvert.DeserializeObject<BasicClassJSON[]>(basicClass);
        this.job = JsonConvert.DeserializeObject<JobJSON[]>(job);
        maleButton.onClick?.Invoke();
        swordmanClassButton.onClick?.Invoke();
    }

    void DisplayClassInfo(string class_id)
    {
        BasicClassJSON basicClassJSON = basicClass.ToList().FirstOrDefault(x => x.class_id == class_id);
        if (basicClassJSON != null)
        {
            mainClass.sprite = Resources.Load<Sprite>("image/icon/class/" + basicClassJSON.class_id);
            mainClass.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = basicClassJSON.class_name;
            for(int i = 0; i < basicClassJSON.class_subclasses.Count(); i++)
            {
                JobJSON jobJSON = job.ToList().FirstOrDefault(x => x.job_id == basicClassJSON.class_subclasses[i]);
                if (jobJSON != null)
                {
                    if(i == 0)
                    {
                        subClass1Button.image.sprite = Resources.Load<Sprite>("image/icon/class/" + jobJSON.job_id);
                        subClass1Button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = jobJSON.job_name;
                        subClass1Button.onClick.RemoveAllListeners();
                        subClass1Button.onClick.AddListener(() =>
                        {
                            DisplaySubClasses(jobJSON);
                        });
                        subClass1Button.onClick?.Invoke();
                    }
                    else if (i == 1)
                    {
                        subClass2Button.image.sprite = Resources.Load<Sprite>("image/icon/class/" + jobJSON.job_id);
                        subClass2Button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = jobJSON.job_name;
                        subClass2Button.onClick.RemoveAllListeners();
                        subClass2Button.onClick.AddListener(() =>
                        {
                            DisplaySubClasses(jobJSON);
                        });
                    }
                }
            }
        }
    }

    void DisplaySubClasses(JobJSON jobJSON)
    {
        curJobId = jobJSON.job_id;
        curJobNameText.text = jobJSON.job_name;
        curJobDesText.text = "Giới tính: " + jobJSON.job_gender +"\nVị trí: " + jobJSON.job_role + "\n" + jobJSON.job_des;
        DisplayMainMode();
    }

    void DisplayMainMode()
    {
        string model = string.Empty;
        switch (curJobId)
        {
            case "class_1_1_1":
                if (curGender)
                {
                    model = "Pc_Knight3_M";
                }
                else
                {
                    model = "Pc_Knight3_W";
                }
                break;
            case "class_1_2_1":
                if (curGender)
                {
                    model = "Pc_Cursader3_M";
                }
                else
                {
                    model = "Pc_Cursader3_W";
                }
                break;
            case "class_2_1_1":
                if (curGender)
                {
                    model = "Pc_Wirzard3_M";
                }
                else
                {
                    model = "Pc_Wirzard3_W";
                }
                break;
            case "class_2_2_1":
                if (curGender)
                {
                    model = "Pc_BlackWirzard3_M";
                }
                else
                {
                    model = "Pc_BlackWirzard3_W";
                }
                break;
            case "class_3_1_1":
                if (curGender)
                {
                    model = "Pc_Archer3_M";
                }
                else
                {
                    model = "Pc_Archer3_W";
                }
                break;
            case "class_3_2_1":
                if (curGender)
                {
                    model = "Pc_Ranger3_M";
                }
                else
                {
                    model = "Pc_Ranger3_W";
                }
                break;
        }
        foreach (var modelChar in mainModelChar)
        {
            if (modelChar.name == model)
            {
                modelChar.SetActive(true);
                modelChar.GetComponent<Animator>().Play("new_zhuanzhi");
            }
            else
            {
                modelChar.SetActive(false);
            }
        }
    }
}
