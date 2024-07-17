using TEngine;
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic
{
    public class ScrollItem : MonoBehaviour
    {
        public Image img;
        public string itemName;

        public string getName()
        {
            return itemName;
        }
    }
}
