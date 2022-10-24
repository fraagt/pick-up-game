using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameUiBehaviour : MonoBehaviour
    {
        [SerializeField] private Text pointAmountText;
        [SerializeField] private GameManager gameManager;

        private void Awake()
        {
            gameManager.OnPointsChanged += SetPointsAmount;
        }
    
        private void OnDestroy()
        {
            gameManager.OnPointsChanged -= SetPointsAmount;
        }

        public void SetPointsAmount(int pointsAmount)
        {
            pointAmountText.text = $"{pointsAmount}";
        }
    }
}
