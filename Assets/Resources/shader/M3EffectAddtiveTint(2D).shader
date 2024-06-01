Shader "M3Effect/2D/Additive Tint(2D)" {
Properties {
 _TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
 _MainTex ("Particle Texture", 2D) = "white" {}
}
SubShader { 
 Tags { "QUEUE"="Transparent+5" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent+5" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZWrite Off
  Cull Off
  Fog {
   Color (0,0,0,0)
  }
  Blend SrcAlpha One
Program "vp" {
SubProgram "gles " {
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
uniform highp mat4 _Object2World;
uniform highp mat4 unity_MatrixVP;
uniform highp mat4 _2DCamVP;
uniform highp mat4 _PosM;
uniform highp vec4 _MainTex_ST;
varying lowp vec4 xlv_COLOR;
varying highp vec2 xlv_TEXCOORD0;
void main ()
{
  highp vec4 localPos_1;
  highp vec4 retPos_2;
  highp vec4 tmpvar_3;
  tmpvar_3 = (_2DCamVP * (_Object2World * _glesVertex));
  localPos_1.xyw = tmpvar_3.xyw;
  localPos_1.z = 0.0;
  highp vec4 tmpvar_4;
  tmpvar_4 = ((unity_MatrixVP * _PosM) * localPos_1);
  retPos_2.xyw = tmpvar_4.xyw;
  retPos_2.z = (tmpvar_4.z + (tmpvar_3.z * 0.004));
  retPos_2.z = (retPos_2.z + 0.698);
  gl_Position = retPos_2;
  xlv_COLOR = _glesColor;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform highp vec4 _TintColor;
varying highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 color_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD0);
  highp vec4 tmpvar_3;
  tmpvar_3 = ((_TintColor * tmpvar_2) * 2.0);
  color_1 = tmpvar_3;
  gl_FragData[0] = color_1;
}



#endif"
}
SubProgram "gles3 " {
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec4 _glesMultiTexCoord0;
uniform highp mat4 _Object2World;
uniform highp mat4 unity_MatrixVP;
uniform highp mat4 _2DCamVP;
uniform highp mat4 _PosM;
uniform highp vec4 _MainTex_ST;
out lowp vec4 xlv_COLOR;
out highp vec2 xlv_TEXCOORD0;
void main ()
{
  highp vec4 localPos_1;
  highp vec4 retPos_2;
  highp vec4 tmpvar_3;
  tmpvar_3 = (_2DCamVP * (_Object2World * _glesVertex));
  localPos_1.xyw = tmpvar_3.xyw;
  localPos_1.z = 0.0;
  highp vec4 tmpvar_4;
  tmpvar_4 = ((unity_MatrixVP * _PosM) * localPos_1);
  retPos_2.xyw = tmpvar_4.xyw;
  retPos_2.z = (tmpvar_4.z + (tmpvar_3.z * 0.004));
  retPos_2.z = (retPos_2.z + 0.698);
  gl_Position = retPos_2;
  xlv_COLOR = _glesColor;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform highp vec4 _TintColor;
in highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 color_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture (_MainTex, xlv_TEXCOORD0);
  highp vec4 tmpvar_3;
  tmpvar_3 = ((_TintColor * tmpvar_2) * 2.0);
  color_1 = tmpvar_3;
  _glesFragData[0] = color_1;
}



#endif"
}
}
Program "fp" {
SubProgram "gles " {
"!!GLES"
}
SubProgram "gles3 " {
"!!GLES3"
}
}
 }
}
}