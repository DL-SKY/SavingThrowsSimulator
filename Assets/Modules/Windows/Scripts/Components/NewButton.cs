using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Modules.Windows.Components
{
    public class NewButton : Button
    {
        public static HashSet<string> AvailableTags = new HashSet<string>();

        [FormerlySerializedAs("onDisableClick"), SerializeField] private ButtonClickedEvent _onDisableClick = new ButtonClickedEvent();

        public string Tag => _tag;
        [SerializeField] private string _tag;

        public ButtonClickedEvent onDisableClick
        {
            get { return _onDisableClick; }
            set { _onDisableClick = value; }
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (IsLocked())
                return;

            if (interactable)
                base.OnPointerClick(eventData);
            else
                _onDisableClick?.Invoke();
        }

        public override void OnSubmit(BaseEventData eventData)
        {
            if (IsLocked())
                return;

            base.OnSubmit(eventData);
        }

        public bool IsLocked()
        {
            return NewButton.AvailableTags.Count > 0 && !NewButton.AvailableTags.Contains(Tag);
        }
    }
}
