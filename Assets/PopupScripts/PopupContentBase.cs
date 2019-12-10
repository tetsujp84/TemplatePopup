using UniRx.Async;
using UnityEngine;

/// <summary>
/// ポップアップの中身
/// 実際は継承して使われる
/// </summary>
public abstract class PopupContentBase : MonoBehaviour
{
    private PopupContainer container;
    
    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="container"></param>
    public void Initialize(PopupContainer container)
    {
        this.container = container;
    }
    
    /// <summary>
    /// 表示する
    /// </summary>
    /// <returns></returns>
    protected async UniTask ShowAnimationAsync()
    {
        await container.PopupAnimator.PlayAnimationAsync();
    }

    /// <summary>
    /// 非表示にする
    /// </summary>
    /// <returns></returns>
    protected async UniTask HideAnimationAsync()
    {
        await container.PopupAnimator.HideAnimationAsync();
        Destroy(container.transform.gameObject);
    }
}
