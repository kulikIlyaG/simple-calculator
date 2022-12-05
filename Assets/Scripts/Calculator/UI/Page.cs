using UnityEngine;

namespace Calculator.UI
{
    public class Page : MonoBehaviour
    {
        public virtual void Initialize(){}
        
        public void Show()
        {
            gameObject.SetActive(true);
        }
        

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}