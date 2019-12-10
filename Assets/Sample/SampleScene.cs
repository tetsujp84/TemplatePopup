using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ボタン入力サンプルシーン
/// </summary>
public class SampleScene : MonoBehaviour
{
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button selectionButton;

    [SerializeField] private Text text;

    private void Start()
    {
        confirmButton.onClick.AddListener(async () =>
        {
            var popup = await PopupCreator.CreateAsync<ConfirmPopupContent>();
            popup.Initialize("ポップアップ確認？");
            var isYes = await popup.ShowAsync();
            if (isYes)
            {
                text.text = "Yesが押された";
            }
            else
            {
                text.text = "Noが押された";
            }
        });
        
        selectionButton.onClick.AddListener(async () =>
        {
            var popup = await PopupCreator.CreateAsync<SelectionPopupContent>();
            var labels = new string[]{"A","B","C"};
            popup.Initialize("選択肢を表示します", labels);
            var index = await popup.ShowAsync(); 
            text.text = $"{labels[index]}ボタンが押された";
        });
    }
}
