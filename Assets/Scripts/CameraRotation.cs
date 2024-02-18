using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    public Transform CameraAxisTransform;

    public float sensitivity;
    public float minValue;
    public float maxValue;

    private void Update()
    {
        var AngleY = transform.localEulerAngles.y + Time.deltaTime * sensitivity * Input.GetAxis(MouseX);
        transform.localEulerAngles = new Vector3(0, AngleY, 0);

        var AngleX = CameraAxisTransform.localEulerAngles.x + Time.deltaTime * sensitivity * Input.GetAxis(MouseY);

        if (AngleX > 180)
        {
            AngleX -= 360;
        }

        AngleX = Mathf.Clamp(AngleX, minValue, maxValue);
        CameraAxisTransform.localEulerAngles = new Vector3(AngleX, 0, 0);

        //transform.Rotate(Input.GetAxis(MouseX) * Time.deltaTime * Vector3.up * _sensitivity);
        //AngleX = (Mathf.Clamp(AngleX, _minValue, _maxValue));
        //CameraAxisTransform.transform.Rotate(Input.GetAxis(MouseY) * Time.deltaTime * Vector3.left * _sensitivity);
        //CameraAxisTransform.transform.Rotate(AngleX * Vector3.left);

    }
}