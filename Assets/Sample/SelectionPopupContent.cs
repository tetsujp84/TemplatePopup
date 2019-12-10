using System.Linq;
using UniRx.Async;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// メッセージと複数選択肢があるポップアップ
/// </summary>
public class SelectionPopupContent : PopupContentBase
{
    [SerializeField] private Text confirmMessage;
    [SerializeField] private Button[] buttons;

    public void Initialize(string message, string[] buttonLabels)
    {
        confirmMessage.text = message;
        var length = Mathf.Min(buttons.Length, buttonLabels.Length);
        for (var i = 0; i < length; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = buttonLabels[i];
        }
    }

    /// <summary>
    /// Yes or Noのポップアップを表示
    /// </summary>
    /// <returns></returns>
    public async UniTask<int> ShowAsync()
    {
        await ShowAnimationAsync();
        var index = await UniTask.WhenAny(buttons.Select(b => b.OnClickAsync()).ToArray());
        await HideAnimationAsync();
        return index;
    }
}
