
Shader "Custom/Mask"
{
  SubShader 
  {
    Pass 
    {
      // Render the mask after regular geometry, but before masked geometry and
      // transparent things.
      // You may need to adjust the queue value depending on your setup
      Tags {"RenderType"="Opaque" "Queue"="Geometry+10" "IgnoreProjector"="True" }

      // Don't draw in the RGBA channels; just the depth buffer
      // This is important for making our mask mesh invisible
      ColorMask 0

      // Writing to z depth isn't necessarily required, but might hide 
      // any extra effects your water has like caustics when the boat interior is below the water surface
      ZWrite On

      // We don't want anything to draw in front of our mask, 
      // as it would allow the water to then be drawn on top of us
      ZTest On

      // The real meat of the solution. 
      // Ref - The value this stencil operation is in reference to. I arbitrarily picked '1'.
      // Comp - The comparison method for deciding whether to draw a pixel. 
      //        For drawing the mask, we always want it to render regardless of the 
      //        stencil state, so I chose 'always'
      // Pass - What to do with the stencil state after drawing a pixel. I chose 'replace', 
      //        which means that whatever was in the stencil buffer will be replaced with '1' 
      //        where our mask is drawn.
      Stencil 
      {
        Ref 1
        Comp always
        Pass replace
      }
    }
  }
}
