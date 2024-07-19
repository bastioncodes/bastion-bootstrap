using UnityEngine;
using System.Collections;

namespace Bastion.Utilities
{
    public class FpsCounter : MonoBehaviour
    {
        private float _count;
        private GUIStyle _style;
        private GUIStyle _outlineStyle;

        private IEnumerator Start()
        {
            _style = new GUIStyle
            {
                fontSize = 24,
                normal =
                {
                    textColor = Color.white
                }
            };
            // Initialize the outline GUIStyle
            _outlineStyle = new GUIStyle(_style)
            {
                normal =
                {
                    textColor = Color.black
                }
            };

            GUI.depth = 2;
            while (true)
            {
                _count = 1f / Time.unscaledDeltaTime;
                yield return new WaitForSeconds(0.1f);
            }
        }
    
        private void OnGUI()
        {
            var rect = new Rect(60, 50, 100, 50);
            var text = "FPS: " + Mathf.Round(_count);

            // Draw the outline by rendering the text multiple times slightly offset in each direction
            GUI.Label(new Rect(rect.x - 1, rect.y, rect.width, rect.height), text, _outlineStyle);
            GUI.Label(new Rect(rect.x + 1, rect.y, rect.width, rect.height), text, _outlineStyle);
            GUI.Label(new Rect(rect.x, rect.y - 1, rect.width, rect.height), text, _outlineStyle);
            GUI.Label(new Rect(rect.x, rect.y + 1, rect.width, rect.height), text, _outlineStyle);
            GUI.Label(new Rect(rect.x - 1, rect.y - 1, rect.width, rect.height), text, _outlineStyle);
            GUI.Label(new Rect(rect.x + 1, rect.y - 1, rect.width, rect.height), text, _outlineStyle);
            GUI.Label(new Rect(rect.x - 1, rect.y + 1, rect.width, rect.height), text, _outlineStyle);
            GUI.Label(new Rect(rect.x + 1, rect.y + 1, rect.width, rect.height), text, _outlineStyle);

            // Draw the main text
            GUI.Label(rect, text, _style);
        }
    }
}