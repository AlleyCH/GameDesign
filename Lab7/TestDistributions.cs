using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDistributions : MonoBehaviour
{
    public int NumberOfSamples = 5000;
    public int NumberOfRepeats = 10;

    //Test MonteCarlo sim method
    // x -> UD01
    // y -> UD01
    // is r^2=x^2+y^2 <= R^2 = 1^2=1
    // add to inQuandrant

    //4000 inQuadrant => 5000 - 4000 = 1000 were out of quarterCircle
    // area of querterCircle=pi/4  => 4000/5000 is approx. of pi/4

    //
    public float GetAproximationOfPI(int NumberOfSamples)
    {
        float result;
        int inQuarterCircle = 0;
        for(int i = 0; i < NumberOfSamples; i++)
        {
            float x = UnityEngine.Random.value;
            float y = UnityEngine.Random.value;
            if(x*x+y*y <= 1f)
            {
                inQuarterCircle += 1;
            }
        }
        result = 4f*inQuarterCircle / NumberOfSamples ;
        return result;
    }

    public float GetRelativeError(float exact, float calculated)
    {
        return Mathf.Abs((exact-calculated)/exact);
    }

    void OneShotPICalculation()
    {
        float pi = Mathf.PI;

        float pi_aprox = GetAproximationOfPI(NumberOfSamples);

        Debug.Log(pi_aprox.ToString("F7") + "," + pi.ToString("F7"));

        Debug.Log("RelativeError:pi vs pi_aprox=" + GetRelativeError(pi, pi_aprox).ToString("F7"));

    }
    void RepeatPICalculation(int NumberOfSamples, int NumberOfRepeats)
    {
        print($"NumberOfSamples = {NumberOfSamples}, NumberOfRepeats = {NumberOfRepeats}");

        float pi = Mathf.PI;
        float pi_aprox_ave = 0;
        for (int i = 0; i < NumberOfRepeats; i++)
        {
            float pi_aprox = GetAproximationOfPI(NumberOfSamples);
            pi_aprox_ave += pi_aprox;
        }
        pi_aprox_ave /= NumberOfRepeats;

        Debug.Log("pi_aprox_ave=" + pi_aprox_ave.ToString("F7") + "," + pi.ToString("F7"));

        Debug.Log("RelativeError:pi vs pi_aprox_ave=" + GetRelativeError(pi, pi_aprox_ave).ToString("F7"));

        

    }
    // Start is called before the first frame update
    void Start()
    {
        //UnityEngine.Random.i
        
        //OneShotPICalculation();

        RepeatPICalculation(NumberOfSamples, NumberOfRepeats);

    }

    public float ApproxND01(int NumberOfUDVars)
    {
        //See Ref: https://en.wikipedia.org/wiki/Central_limit_theorem
        //  for the meaning of the following

        float result = 0;
        for (int i = 0; i < NumberOfUDVars; i++)
        {
            float r = UnityEngine.Random.value;
            result += r;
        }

        float AN_N_bar = result / NumberOfUDVars;
        float my = 1f / 2f;
        float var_UD01 = 1f / 12;
        float sigma_UD01 = Mathf.Sqrt(var_UD01);
        float sigma_AN_N_bar = sigma_UD01 / Mathf.Sqrt(NumberOfUDVars);
        float z = (AN_N_bar - my) / sigma_AN_N_bar;
        result = z;

        return result;
    }
    public float ApproxND_my_sigma(int NumberOfUDVars, float my, float sigma)
    {
        return my + ApproxND01(NumberOfUDVars) * sigma;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
