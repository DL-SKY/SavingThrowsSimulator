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
                        anchors.Set(new Vector2(), new Vector2());
                        break;

                    //Right
                    case 1:
                        anchors.Set(new Vector2(), new Vector2());
                        break;

                    //Botton
                    case 2:
                        anchors.Set(new Vector2(), new Vector2());
                        break;

                    //Left
                    case 3:
                        anchors.Set(new Vector2(), new Vector2());
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
