
using UnityEngine.Events;

public static class ButtonHelper
{
    public static void AddOnClick(this UnityEngine.UI.Button self, UnityAction action, bool isRemoveButtonAction = true)
    {
        if (isRemoveButtonAction)
        {
            self.onClick.RemoveAllListeners();
        }
        self.onClick.AddListener(action);
    }
}
