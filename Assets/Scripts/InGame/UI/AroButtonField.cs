using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class AroButtonField : MonoBehaviour
{
    [SerializeField] Toggle toggle;
    [SerializeField] Image fieldImage;
    [SerializeField] Image markerImage;
    [SerializeField] Image toggleImage;

    public AroManager AM { get; set; }

    InputReceiver receiver;
    SpriteRenderer markerSr;

    Color onColor = Color.white;
    Color offColor = Color.gray;
    Color nullColor =Color.black;



    public void AroRegister(AroManager aro)
    {
        AM = aro;
    }
    IEnumerator Start()
    {
        yield return null;

        if (AM == null)
        {
            SetupNullField();
            yield break;
        }

        receiver = AM.Receiver;
        markerSr = AM.Marker.GetComponentInChildren<SpriteRenderer>();

        Color markerColor = markerImage.color;

        ColorShadow colorShadow = AM.GetComponentInChildren<ColorShadow>();
        SpriteRenderer colorShadowSr = colorShadow.GetComponent<SpriteRenderer>();
        colorShadowSr.color = markerColor;

        markerColor.a = 0.2f;
        markerSr.color = markerColor;

       

        var bodySprite = AM.transform.root
            .GetComponentInChildren<BodySprite>()
            .GetComponent<SpriteRenderer>();

        toggleImage.sprite = bodySprite.sprite;

        toggle.onValueChanged.AddListener(OnToggleValueChanged);
        OnToggleValueChanged(toggle.isOn);
    }

    void SetupNullField()
    {
        fieldImage.color = nullColor;
    }

    void OnToggleValueChanged(bool isOn)
    {
        receiver.gameObject.SetActive(isOn);
        fieldImage.color = isOn ? onColor : offColor;
    }
}
