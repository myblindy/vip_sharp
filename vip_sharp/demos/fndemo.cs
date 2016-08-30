using System;
using System.Linq;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
}
public class __TColor { 
public double __dR;
public double __dG;
public double __dB;
}
public void __GetColorRGB (int __nColorIn,float __fInt,vip_sharp.BipolarArray< __TColor> __cColorOut) {
if(Convert.ToBoolean(__nColorIn==0))
{
__cColorOut[0].__dR = 0;
__cColorOut[0].__dG = 0;
__cColorOut[0].__dB = 0;
}
if(Convert.ToBoolean(__nColorIn==1))
{
__cColorOut[0].__dR = 25;
__cColorOut[0].__dG = 25;
__cColorOut[0].__dB = 25;
}
if(Convert.ToBoolean(__nColorIn==2))
{
__cColorOut[0].__dR = 50;
__cColorOut[0].__dG = 50;
__cColorOut[0].__dB = 50;
}
if(Convert.ToBoolean(__nColorIn==3))
{
__cColorOut[0].__dR = 75;
__cColorOut[0].__dG = 75;
__cColorOut[0].__dB = 75;
}
if(Convert.ToBoolean(__nColorIn==4))
{
__cColorOut[0].__dR = 100;
__cColorOut[0].__dG = 100;
__cColorOut[0].__dB = 100;
}
if(Convert.ToBoolean(__nColorIn==5))
{
__cColorOut[0].__dR = 100;
__cColorOut[0].__dG = 0;
__cColorOut[0].__dB = 0;
}
if(Convert.ToBoolean(__nColorIn==6))
{
__cColorOut[0].__dR = 0;
__cColorOut[0].__dG = 100;
__cColorOut[0].__dB = 0;
}
if(Convert.ToBoolean(__nColorIn==7))
{
__cColorOut[0].__dR = 0;
__cColorOut[0].__dG = 0;
__cColorOut[0].__dB = 100;
}
if(Convert.ToBoolean(__nColorIn==8))
{
__cColorOut[0].__dR = 0;
__cColorOut[0].__dG = 100;
__cColorOut[0].__dB = 100;
}
if(Convert.ToBoolean(__nColorIn==9))
{
__cColorOut[0].__dR = 100;
__cColorOut[0].__dG = 0;
__cColorOut[0].__dB = 100;
}
if(Convert.ToBoolean(__nColorIn==10))
{
__cColorOut[0].__dR = 100;
__cColorOut[0].__dG = 100;
__cColorOut[0].__dB = 0;
}
if(Convert.ToBoolean(__nColorIn==11))
{
__cColorOut[0].__dR = 97.7;
__cColorOut[0].__dG = 66.4;
__cColorOut[0].__dB = 23.4;
}
if(Convert.ToBoolean(__nColorIn==12))
{
__cColorOut[0].__dR = 100;
__cColorOut[0].__dG = 64.5;
__cColorOut[0].__dB = 0;
}
if(Convert.ToBoolean(__nColorIn==13))
{
__cColorOut[0].__dR = 53.9;
__cColorOut[0].__dG = 16.8;
__cColorOut[0].__dB = 88.3;
}
if(Convert.ToBoolean(__nColorIn==14))
{
__cColorOut[0].__dR = 64.5;
__cColorOut[0].__dG = 16.4;
__cColorOut[0].__dB = 16.4;
}
if(Convert.ToBoolean(__nColorIn==15))
{
__cColorOut[0].__dR = 82;
__cColorOut[0].__dG = 41;
__cColorOut[0].__dB = 11.7;
}
if(Convert.ToBoolean(__nColorIn==16))
{
__cColorOut[0].__dR = 0;
__cColorOut[0].__dG = 50;
__cColorOut[0].__dB = 0;
}
if(Convert.ToBoolean(__nColorIn==17))
{
__cColorOut[0].__dR = 15.6;
__cColorOut[0].__dG = 100;
__cColorOut[0].__dB = 15.6;
}
if(Convert.ToBoolean(__nColorIn==18))
{
__cColorOut[0].__dR = 100;
__cColorOut[0].__dG = 21.5;
__cColorOut[0].__dB = 21.5;
}
if(Convert.ToBoolean(__nColorIn==19))
{
__cColorOut[0].__dR = 50;
__cColorOut[0].__dG = 10.5;
__cColorOut[0].__dB = 10.5;
}
if(Convert.ToBoolean(__nColorIn==20))
{
__cColorOut[0].__dR = 0;
__cColorOut[0].__dG = 54.3;
__cColorOut[0].__dB = 54.3;
}
if(Convert.ToBoolean(__nColorIn==21))
{
__cColorOut[0].__dR = 39.1;
__cColorOut[0].__dG = 58.2;
__cColorOut[0].__dB = 92.6;
}
if(Convert.ToBoolean(__nColorIn==22))
{
__cColorOut[0].__dR = 100;
__cColorOut[0].__dG = 7.8;
__cColorOut[0].__dB = 57.4;
}
if(Convert.ToBoolean(__nColorIn==23))
{
__cColorOut[0].__dR = 100;
__cColorOut[0].__dG = 84;
__cColorOut[0].__dB = 0;
}
__cColorOut[0].__dR = __cColorOut[0].__dR*(__fInt/100);
__cColorOut[0].__dG = __cColorOut[0].__dG*(__fInt/100);
__cColorOut[0].__dB = __cColorOut[0].__dB*(__fInt/100);
}
int __coloridx = 0;
public override void Run() {
__TColor __c = new __TColor();
__coloridx = __coloridx+1;
if(Convert.ToBoolean(__coloridx==24))
__coloridx = 0;
{
var _arg2 = new vip_sharp.BipolarArray<__TColor>(1) { __c };
GlobalState.MainClass.__GetColorRGB(__coloridx,100,_arg2);
__c = _arg2[0];}
vip_sharp.VIPRuntime.Instance.Color(__c);
vip_sharp.VIPRuntime.Instance.Circle(0,0,4,25,true);
}
}
