using UnityEngine;
using UnityEngine.UI;

public class InfoPanelController : MonoBehaviour
{
    public Text text = null;

    void Start()
    {
        text.text = "No flag defined";
#if DEVELOPMENT_FLAG
        text.text = "Development flag defined";
#endif
#if PRODUCTION_FLAG
        text.text = "Production flag defined";
#endif
    }
}
