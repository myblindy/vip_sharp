using System;
public class __MainClass {
public class __TColor3 { 
public double __dR;
public double __dG;
public double __dB;
}
public class __Blinker : vip_sharp.VIPUtils.IVIPObject {
public double X=0, Y=0;
public double GetX() { return X; }
public double GetY() { return Y; }
double __m_dBlinkTime = 0;
double __m_dCurrTime = 0;
__TColor3 __m_Color = new __TColor3();
public class __struct_cIn {public bool __bStat;
} public __struct_cIn __cIn=new __struct_cIn();
public __Blinker(double __dBlinkFreq,double __dR,double __dG,double __dB) {
__m_Color.__dR = __dR;
__m_Color.__dG = __dG;
__m_Color.__dB = __dB;
if(__dBlinkFreq>0) {
__m_dBlinkTime = 1/(__dBlinkFreq/2);
}
}
public void Run() {
if(__cIn.__bStat&&(__m_dCurrTime<__m_dBlinkTime)) {
vip_sharp.VIPUtils.Instance.Color(__m_Color);
vip_sharp.VIPUtils.Instance.Circle(0,0,2,40,true);}
__m_dCurrTime = __m_dCurrTime+vip_sharp.VIPUtils.Instance.VIPSystemClass.__dDT;
if(__m_dCurrTime>(__m_dBlinkTime*2)) {
__m_dCurrTime = __m_dCurrTime-(__m_dBlinkTime*2);
}
}
}
__Blinker __BL1 = new __Blinker(1,100,0,0) { X = -5,Y = 0};
__Blinker __BL2 = new __Blinker(0.5,0,100,0) { X = 5,Y = 0};
public void Run() {
__BL1.__cIn.__bStat = true;
__BL2.__cIn.__bStat = true;
vip_sharp.VIPUtils.Instance.Draw(__BL1);
vip_sharp.VIPUtils.Instance.Draw(__BL2);
}
}
