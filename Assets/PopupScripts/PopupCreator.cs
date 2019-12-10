using UniRx.Async;
using UnityEngine;

/// <summary>
/// ポップアップ生成クラス
/// </summary>
public static class PopupCreator
{
    /// <summary>
    /// PopupとContentをロードしポップアップを生成する
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async UniTask<T> CreateAsync<T>() where T : PopupContentBase
    {
        var popupContainer = await Resources.LoadAsync<PopupContainer>("Popup/PopupContainer") as PopupContainer;
        if (!popupContainer)
        {
            Debug.LogAssertion("PopupContainerが見つかりません");
            return null;
        }

        var popupInstance = Object.Instantiate(popupContainer);
        var content = await Resources.LoadAsync<T>("Popup/Content/" + typeof(T).Name) as T;
        if (!content)
        {
            Debug.LogAssertion($"{typeof(T).Name}が見つかりません");
            return null;
        }

        var contentInstance = Object.Instantiate(content);
        popupInstance.SetContent(contentInstance);
        return contentInstance;
    }
}