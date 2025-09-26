using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FortuneTeller : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI fortuneText;   // 预言文字
    public Image clanImage;               // 势力图片
    public Button generateButton;         // 按钮

    [Header("Fortune Data")]
    // 势力名字（固定写死）
    private string[] clanNames = {
        "(Konoha)",
        "(Sunagakure)",
        "Kirigakure)",
        "(Iwagakure)",
        "(Kumogakure)",
        "(Akatsuki)"
    };

    // 对应的图片（要在 Inspector 里拖进来，顺序必须和名字数组一致）
    public Sprite[] clanSprites;

    void Start()
    {
        // 给按钮绑定事件
        if (generateButton != null)
            generateButton.onClick.AddListener(GenerateFortune);

        // 初始提示
        if (fortuneText != null)
            fortuneText.text = "Click the button or press the space bar to see your prophecy. ...";
    }

    void Update()
    {
        // 空格键触发
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateFortune();
        }
    }

    public void GenerateFortune()
    {
        int rand = Random.Range(0, clanNames.Length);

        // 更新文字
        fortuneText.text = "If you traveled to the Naruto world, you would be born in —— " + clanNames[rand] + "！";

        // 更新图片
        if (clanSprites.Length > rand && clanImage != null)
        {
            clanImage.sprite = clanSprites[rand];
        }
    }
}
