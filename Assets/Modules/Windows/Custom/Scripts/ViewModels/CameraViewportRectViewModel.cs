using Modules.Windows.ViewModels;
using UnityEngine;

namespace Modules.Windows.Custom.ViewModels
{
    public struct Anchors
    {
        public Vector2 Min { get; private set; }
        public Vector2 Max { get; private set; }

        public Anchors(Vector2 min, Vector2 max)
        {
            Min = min;
            Max = max;
        }

        public void Set(Vector2 min, Vector2 max)
        {
            Min = min;
            Max = max;
        }
    }

    public class CameraViewportRectViewModel : ViewModel
    {
        private Rect _viewportRect;

        public CameraViewportRectViewModel(Rect viewportRect) : base()
        {
            _viewportRect = viewportRect;
        }

        public Anchors[] GetAnchors()
        {
            var result = new Anchors[4];

            for (int i = 0; i < result.Length; i++)
            {
                var anchors = new Anchors();
                switch (i)
                {
                    //Top
                    case 0:
                        anchors.Set(new Vector2(0.0f, _viewportRect.y + _viewportRect.height), new Vector2(1.0f, 1.0f));
                        break;

                    //Right
                    case 1:
                        anchors.Set(new Vector2(_viewportRect.x + _viewportRect.width, _viewportRect.y), new Vector2(1.0f, _viewportRect.y + _viewportRect.height));
                        break;

                    //Botton
                    case 2:
                        anchors.Set(new Vector2(0.0f, 0.0f), new Vector2(1.0f, _viewportRect.y));
                        break;

                    //Left
                    case 3:
                        anchors.Set(new Vector2(0.0f, _viewportRect.y), new Vector2(_viewportRect.x, _viewportRect.y + _viewportRect.height));
                        break;
                }
                result[i] = anchors;
            }

            return result;
        }

        public override void Dispose()
        {

        }
    }
}
