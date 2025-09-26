using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FortuneTeller : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI fortuneText;   // Ԥ������
    public Image clanImage;               // ����ͼƬ
    public Button generateButton;         // ��ť

    [Header("Fortune Data")]
    // �������֣��̶�д����
    private string[] clanNames = {
        "(Konoha)",
        "(Sunagakure)",
        "Kirigakure)",
        "(Iwagakure)",
        "(Kumogakure)",
        "(Akatsuki)"
    };

    // ��Ӧ��ͼƬ��Ҫ�� Inspector ���Ͻ�����˳��������������һ�£�
    public Sprite[] clanSprites;

    void Start()
    {
        // ����ť���¼�
        if (generateButton != null)
            generateButton.onClick.AddListener(GenerateFortune);

        // ��ʼ��ʾ
        if (fortuneText != null)
            fortuneText.text = "Click the button or press the space bar to see your prophecy. ...";
    }

    void Update()
    {
        // �ո������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateFortune();
        }
    }

    public void GenerateFortune()
    {
        int rand = Random.Range(0, clanNames.Length);

        // ��������
        fortuneText.text = "If you traveled to the Naruto world, you would be born in ���� " + clanNames[rand] + "��";

        // ����ͼƬ
        if (clanSprites.Length > rand && clanImage != null)
        {
            clanImage.sprite = clanSprites[rand];
        }
    }
}
