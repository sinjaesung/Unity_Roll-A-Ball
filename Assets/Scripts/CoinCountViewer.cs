using UnityEngine;
using TMPro;

public class CoinCountViewer : MonoBehaviour
{
    [SerializeField]
    private StageController stageController;
    private TextMeshProUGUI textCoinCount;

    private void Awake()
    {
        textCoinCount = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textCoinCount.text = "Coins : " + stageController.CurrentCoinCount + "/" + stageController.MaxCoinCount;
    }
}
