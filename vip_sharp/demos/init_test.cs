using System;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
}
public class __TColor3 { 
public double __dR;
public double __dG;
public double __dB;
}
public class __Blinker : vip_sharp.VIPRuntime.VIPObject {
public __Blinker(double __dBlinkFreq,double __dR,double __dG,double __dB) {
this.__m_dBlinkTime = 0;
this.__m_dCurrTime = 0;
this.__m_Color = new __TColor3();
__m_Color.__dR = __dR;
__m_Color.__dG = __dG;
__m_Color.__dB = __dB;
if(Convert.ToBoolean(__dBlinkFreq>0)) {
__m_dBlinkTime = 1/(__dBlinkFreq/2);
}
}
public double __m_dBlinkTime;
public double __m_dCurrTime;
public __TColor3 __m_Color;
public class __struct_cIn {
public bool __bStat;
}
public __struct_cIn __cIn=new __struct_cIn();
public override void Run() {
if(Convert.ToBoolean(__cIn.__bStat&&(__m_dCurrTime<__m_dBlinkTime))) {
vip_sharp.VIPRuntime.Instance.Color(__m_Color);
vip_sharp.VIPRuntime.Instance.Circle(0,0,2,40,true);
}
__m_dCurrTime = __m_dCurrTime+vip_sharp.VIPRuntime.Instance.VIPSystemClass.__dDT;
if(Convert.ToBoolean(__m_dCurrTime>(__m_dBlinkTime*2))) {
__m_dCurrTime = __m_dCurrTime-(__m_dBlinkTime*2);
}
}
}
public __Blinker __BL1 = new __Blinker(1,100,0,0) { X = -5,Y = 0};
public __Blinker __BL2 = new __Blinker(0.5,0,100,0) { X = 5,Y = 0};
public override void Run() {
__BL1.__cIn.__bStat = true;
__BL2.__cIn.__bStat = true;
vip_sharp.VIPRuntime.Instance.Draw(__BL1);
vip_sharp.VIPRuntime.Instance.Draw(__BL2);
}
}
