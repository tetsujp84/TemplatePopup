using UniRx.Async;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 確認メッセージがあり、Yes or Noで選択するポップアップ
/// </summary>
public class ConfirmPopupContent : PopupContentBase
{
    [SerializeField] private Text _confirmMessage;
    // noが左、yesが右想定
    [SerializeField] private Button noButton;
    [SerializeField] private Button okButton;

    public void Initialize(string message)
    {
        _confirmMessage.text = message;
    }
    
    public async UniTask<bool> ShowAsync()
    {
        await ShowAnimationAsync();
        var isYes = await UniTask.WhenAny(noButton.OnClickAsync(), okButton.OnClickAsync()) == 1;
        await HideAnimationAsync();
        return isYes;
    }
}
