using UnityEngine;

[RequireComponent(typeof(ShipSettings))]
public class HumanPlayer : MonoBehaviour
{
    [SerializeField] float speedSelectionSpeed = 10f;


    ShipSettings ship;
    ProjectileWeapon[] laserCannons;

    bool rolling = false;
    float rollStart;
    float rollDir;
    float rollLength;
    float barrelRef = 0f;
    float barrelRoll;


    void Start()
    {
        ship = GetComponent<ShipSettings>();
        laserCannons = GetComponentsInChildren<ProjectileWeapon>();
        Cursor.visible = false;
    }

    void Update()
    {
        Steer();
        Throttle();
        FireGuns();
    }

    void Steer()
    {
        ship.yaw = Mathf.Clamp((Input.mousePosition.x / Screen.width) * 2f - 1f, -1f, 1f);
        ship.pitch = Mathf.Clamp((Input.mousePosition.y / Screen.height) * 2f - 1f, -1f, 1f); ;
    }

    void Throttle()
    {
        var fullStop = Input.GetKey(KeyCode.S);             // S for Stop
        var fullSpeed = Input.GetKey(KeyCode.W);            // W for full speed ahead
        var afterBurn = Input.GetKey(KeyCode.LeftShift);    // Shift for boost
        var afterBurnOff = Input.GetKeyUp(KeyCode.LeftShift);
        var accelerate = Input.GetKey(KeyCode.Q);     // Up arrow to accelerate
        var decelerate = Input.GetKey(KeyCode.E);
        var rollLeft = Input.GetKey(KeyCode.A);
        var rollRight = Input.GetKey(KeyCode.D);

        if (afterBurnOff)
        {
            ship.targetSpeed = ship.topSpeed / 2;
        }

        if (afterBurn)
        {
            ship.targetSpeed = ship.burnSpeed;
        }
        else
        {

            if (fullSpeed)
            {
                ship.targetSpeed = ship.topSpeed;
            }
            if (fullStop)
            {
                ship.targetSpeed = 0f;
            }
            else
            {
                if (accelerate && !decelerate && ship.targetSpeed < ship.topSpeed)
                {
                    ship.targetSpeed += speedSelectionSpeed * Time.deltaTime;
                }
                else if (decelerate && !accelerate && ship.targetSpeed > 0f)
                {
                    ship.targetSpeed -= speedSelectionSpeed * Time.deltaTime;
                }
            }
        }
        //if (rolling)
        //{
        //    DoABarrelRoll(rollDir, 3f);
        //    return;
        //}
        //else StopRoll();


        //if (rollLeft)
        //{
        //    rollStart = Time.time;
        //    rolling = true;
        //    rollDir = -1;
        //}
        //if (rollRight)
        //{
        //    rollStart = Time.time;
        //    rollDir = 1;
        //    rolling = true;
        //}

    }

    void FireGuns()
    {
        var fire = Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0);
        foreach (ProjectileWeapon laserCannon in laserCannons)
        {
            laserCannon.fire = fire;
            if (fire)
            {
                ship.isFiring = true;
            }
            else
            {
                ship.isFiring = false;
            }
        }
    }

    //void DoABarrelRoll(float direction, float length)
    //{
    //    print("ROLLING");
    //    if (Time.time <= rollStart + length)
    //    {
    //        barrelRef = Mathf.SmoothStep(barrelRef, direction, .05f);
    //    }
    //    else
    //    {
    //        barrelRef = Mathf.Lerp(barrelRef, 0f, .05f);
    //        rolling = false;
    //    }
    //    barrelRoll += barrelRef * ship.turnRate * Time.deltaTime;
    //}
    //void StopRoll()
    //{
    //    ship.roll = Mathf.SmoothStep(ship.roll, 0, .05f);
    //}
}
