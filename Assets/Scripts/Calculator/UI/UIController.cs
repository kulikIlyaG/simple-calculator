using UnityEngine;

namespace Calculator.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Page[] pages;


        public void Initialize()
        {
            foreach (Page page in pages)
            {
                page.Initialize();
            }
        }
    }
}