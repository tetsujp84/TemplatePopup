using UniRx.Async;
using UnityEngine;

/// <summary>
/// ポップアップアニメーション
/// </summary>
public class PopupAnimator : MonoBehaviour
{
    // ShowPopupとHidePopupのアニメーションが設定されている
    [SerializeField] private Animator animator;

    public async UniTask PlayAnimationAsync()
    {
        animator.Play("ShowPopup");
        await UniTask.WaitUntil(IsFinish);
    }

    public async UniTask HideAnimationAsync()
    {
        animator.Play("HidePopup");
        await UniTask.WaitUntil(IsFinish);
    }

    private bool IsFinish()
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1;
    }
}
