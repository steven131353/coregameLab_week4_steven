using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FortuneTeller : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI fortuneText;   
    public Image clanImage;               
    public Button generateButton;         

    [Header("Fortune Data")]
    
    private string[] clanNames = {
        "(Konoha)",
        "(Sunagakure)",
        "Kirigakure)",
        "(Iwagakure)",
        "(Kumogakure)",
        "(Akatsuki)"
    };

  
    public Sprite[] clanSprites;

    void Start()
    {
        
        if (generateButton != null)
            generateButton.onClick.AddListener(GenerateFortune);

        
        if (fortuneText != null)
            fortuneText.text = "Click the button or press the space bar to see your prophecy. ...";
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateFortune();
        }
    }

    public void GenerateFortune()
    {
        int rand = Random.Range(0, clanNames.Length);

        
        fortuneText.text = "If you traveled to the Naruto world, you would be born in ¡ª¡ª " + clanNames[rand] + "£¡";

        
        if (clanSprites.Length > rand && clanImage != null)
        {
            clanImage.sprite = clanSprites[rand];
        }
    }
}
