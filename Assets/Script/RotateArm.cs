using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArm : MonoBehaviour
{
    // onemli olan detay sol taraftaki rotate armi yaparken animasyonu direkt doner kol objesine ekleyecektik ancak kopyaladigimizda animasyon ayni konumda calisir olmaz dedi 
    // bos bir obje acti doner kolu icine koyup konumu bos objeden ayarladi animasyonu sonra doner kola ekledi 
    bool rotate = false;
    [SerializeField] float rotateValue;

    // doner kollarin alttan cikis animasyonu sonunda add event diyerek bu fonksiyonu ekledik animasyon tamamlandiginda donmeye basliyor 
    public void RotateOn()
    {
        rotate = true;
    }
    void Update()
    {
        if (rotate)
        {
            transform.Rotate(0, 0, rotateValue, Space.Self);
        }
    }
}
