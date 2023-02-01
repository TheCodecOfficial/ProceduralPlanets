#ifndef RING_INCLUDED
#define RING_INCLUDED

void Ring_float(float2 uv, float r1, float r2, out float dist){
	
	float d = (r2 - length(uv))*(length(uv)-r1);

    dist = d > 0 ? 2 * sqrt(d)/(r2-r1) : 0;

}

#endif