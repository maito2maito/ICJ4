using UnityEngine;

public class RandomParticleSpeed : MonoBehaviour
{
    // Julkinen muuttuja, johon voidaan asettaa haluttu ParticleSystem
    public ParticleSystem targetParticleSystem;

    private ParticleSystem.MainModule mainModule;

    // M‰‰rittele minimi ja maksimi nopeus
    public float minSpeed = 1f;
    public float maxSpeed = 5f;

    // M‰‰rittele tuulen voimakkuus (tuuli voi vaikuttaa partikkelien nopeuteen)
    public float windForceMin = 0f;  // Minimi tuulivoima
    public float windForceMax = 2f;  // Maksimi tuulivoima

    // M‰‰rittele, kuinka paljon tuulen voima vaikuttaa nopeuteen
    public float windEffectStrength = 0.5f;  // Kuinka paljon tuuli voi muuttaa nopeutta

    void Start()
    {
        // Jos targetParticleSystem ei ole asetettu, k‰yt‰ t‰m‰n skriptin GameObjectin ParticleSystemia
        if (targetParticleSystem == null)
        {
            targetParticleSystem = GetComponent<ParticleSystem>();
        }

        // Hae MainModule valitusta ParticleSystemist‰
        mainModule = targetParticleSystem.main;

        // Aseta satunnainen nopeus heti alussa
        SetRandomSpeed();
    }

    void Update()
    {
        // Voit myˆs muuttaa nopeutta satunnaisesti ajan kuluessa, jos haluat
        if (Random.Range(0f, 1f) < 0.01f)  // 1% mahdollisuus joka frame
        {
            SetRandomSpeed();
        }
    }

    // Metodi satunnaisen nopeuden asettamiseen, joka ottaa tuulen voiman huomioon
    void SetRandomSpeed()
    {
        // Satunnainen tuulen voimakkuus, joka vaikuttaa nopeuteen
        float windForce = Random.Range(windForceMin, windForceMax);

        // Satunnainen nopeus ilman tuulta
        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        // Tuulen voiman vaikutus nopeuteen
        float finalSpeed = randomSpeed + windForce * windEffectStrength;

        // Aseta lopullinen nopeus partikkelille
        mainModule.startSpeed = finalSpeed;
    }
}
