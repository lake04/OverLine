using UnityEngine;
using UnityEngine.UI;

public class UnitView : MonoBehaviour
{
    private Unit unitHp;
    private Slider sliderHp;

    public void Setup(Unit unitHp)
    {
        this.unitHp = unitHp;
        sliderHp = GetComponent<Slider>();
    }

    void Update()
    {
        sliderHp.value = unitHp.currentHp / unitHp.maxHp;
    }
}
