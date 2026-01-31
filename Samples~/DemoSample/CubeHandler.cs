using UnityEngine;

namespace Rabbi32.SimpleDynamicInteractions.Sample
{
    public class CubeHandler : MonoBehaviour
    {
        private Material cubeMat;
    
        void Start()
        {
            cubeMat = GetComponent<Renderer>().material;
        }

        public void ChangeMaterial()
        {
            cubeMat.color = Random.ColorHSV();
        }
    
    }
}

