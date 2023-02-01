#ifndef GRADIENT4_INCLUDED
#define GRADIENT4_INCLUDED

void SampleGradient_float(
                   float4 color1,
                   float4 color2,
                   float4 color3,
                   float4 color4,
                   float position1,
                   float position2,
                   float position3,
                   float position4,
                   float t,
                   out float4 outFloat)
{
    if(t<position1)
    {
        outFloat = color1;
    }
    else if(t<position2)
    {
        float pos = (t-position1)/(position2-position1);
        outFloat = lerp(color1, color2, pos);
    }
    else if(t<position3)
    {
        float pos = (t-position2)/(position3-position2);
        outFloat = lerp(color2, color3, pos);
    }
    else if(t<position4)
    {
        float pos = (t-position3)/(position4-position3);
        outFloat = lerp(color3, color4, pos);
    }
    else
    {
        outFloat = color4;
    }
}

#endif