using UnityEngine;

/// <summary>
/// ポップアップの格納、フレーム部分
/// アニメーションへの参照と要素の紐づけを行う
/// </summary>
public class PopupContainer : MonoBehaviour
{
    [SerializeField] private PopupAnimator animator;

    public PopupAnimator PopupAnimator => animator;
    
    /// <summary>
    /// ポップアップの要素を設定する
    /// </summary>
    /// <param name="content"></param>
    public void SetContent(PopupContentBase content)
    {
        content.transform.SetParent(animator.transform, false);
        content.Initialize(this);
    }
}
