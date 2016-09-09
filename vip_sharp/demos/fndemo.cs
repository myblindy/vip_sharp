using System;
using System.Linq;
using System.Collections.Generic;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
this.__coloridx = 0;
}
public class __tcolor { 
public double __dr;
public double __dg;
public double __db;
}
public void __getcolorrgb (int __ncolorin,float __fint,vip_sharp.BipolarArray<__tcolor> __ccolorout) {
if(Convert.ToBoolean((__ncolorin==0)))
{
__ccolorout[0].__dr = Convert.ToDouble(0);
__ccolorout[0].__dg = Convert.ToDouble(0);
__ccolorout[0].__db = Convert.ToDouble(0);
}
if(Convert.ToBoolean((__ncolorin==1)))
{
__ccolorout[0].__dr = Convert.ToDouble(25);
__ccolorout[0].__dg = Convert.ToDouble(25);
__ccolorout[0].__db = Convert.ToDouble(25);
}
if(Convert.ToBoolean((__ncolorin==2)))
{
__ccolorout[0].__dr = Convert.ToDouble(50);
__ccolorout[0].__dg = Convert.ToDouble(50);
__ccolorout[0].__db = Convert.ToDouble(50);
}
if(Convert.ToBoolean((__ncolorin==3)))
{
__ccolorout[0].__dr = Convert.ToDouble(75);
__ccolorout[0].__dg = Convert.ToDouble(75);
__ccolorout[0].__db = Convert.ToDouble(75);
}
if(Convert.ToBoolean((__ncolorin==4)))
{
__ccolorout[0].__dr = Convert.ToDouble(100);
__ccolorout[0].__dg = Convert.ToDouble(100);
__ccolorout[0].__db = Convert.ToDouble(100);
}
if(Convert.ToBoolean((__ncolorin==5)))
{
__ccolorout[0].__dr = Convert.ToDouble(100);
__ccolorout[0].__dg = Convert.ToDouble(0);
__ccolorout[0].__db = Convert.ToDouble(0);
}
if(Convert.ToBoolean((__ncolorin==6)))
{
__ccolorout[0].__dr = Convert.ToDouble(0);
__ccolorout[0].__dg = Convert.ToDouble(100);
__ccolorout[0].__db = Convert.ToDouble(0);
}
if(Convert.ToBoolean((__ncolorin==7)))
{
__ccolorout[0].__dr = Convert.ToDouble(0);
__ccolorout[0].__dg = Convert.ToDouble(0);
__ccolorout[0].__db = Convert.ToDouble(100);
}
if(Convert.ToBoolean((__ncolorin==8)))
{
__ccolorout[0].__dr = Convert.ToDouble(0);
__ccolorout[0].__dg = Convert.ToDouble(100);
__ccolorout[0].__db = Convert.ToDouble(100);
}
if(Convert.ToBoolean((__ncolorin==9)))
{
__ccolorout[0].__dr = Convert.ToDouble(100);
__ccolorout[0].__dg = Convert.ToDouble(0);
__ccolorout[0].__db = Convert.ToDouble(100);
}
if(Convert.ToBoolean((__ncolorin==10)))
{
__ccolorout[0].__dr = Convert.ToDouble(100);
__ccolorout[0].__dg = Convert.ToDouble(100);
__ccolorout[0].__db = Convert.ToDouble(0);
}
if(Convert.ToBoolean((__ncolorin==11)))
{
__ccolorout[0].__dr = Convert.ToDouble(97.7);
__ccolorout[0].__dg = Convert.ToDouble(66.4);
__ccolorout[0].__db = Convert.ToDouble(23.4);
}
if(Convert.ToBoolean((__ncolorin==12)))
{
__ccolorout[0].__dr = Convert.ToDouble(100);
__ccolorout[0].__dg = Convert.ToDouble(64.5);
__ccolorout[0].__db = Convert.ToDouble(0);
}
if(Convert.ToBoolean((__ncolorin==13)))
{
__ccolorout[0].__dr = Convert.ToDouble(53.9);
__ccolorout[0].__dg = Convert.ToDouble(16.8);
__ccolorout[0].__db = Convert.ToDouble(88.3);
}
if(Convert.ToBoolean((__ncolorin==14)))
{
__ccolorout[0].__dr = Convert.ToDouble(64.5);
__ccolorout[0].__dg = Convert.ToDouble(16.4);
__ccolorout[0].__db = Convert.ToDouble(16.4);
}
if(Convert.ToBoolean((__ncolorin==15)))
{
__ccolorout[0].__dr = Convert.ToDouble(82);
__ccolorout[0].__dg = Convert.ToDouble(41);
__ccolorout[0].__db = Convert.ToDouble(11.7);
}
if(Convert.ToBoolean((__ncolorin==16)))
{
__ccolorout[0].__dr = Convert.ToDouble(0);
__ccolorout[0].__dg = Convert.ToDouble(50);
__ccolorout[0].__db = Convert.ToDouble(0);
}
if(Convert.ToBoolean((__ncolorin==17)))
{
__ccolorout[0].__dr = Convert.ToDouble(15.6);
__ccolorout[0].__dg = Convert.ToDouble(100);
__ccolorout[0].__db = Convert.ToDouble(15.6);
}
if(Convert.ToBoolean((__ncolorin==18)))
{
__ccolorout[0].__dr = Convert.ToDouble(100);
__ccolorout[0].__dg = Convert.ToDouble(21.5);
__ccolorout[0].__db = Convert.ToDouble(21.5);
}
if(Convert.ToBoolean((__ncolorin==19)))
{
__ccolorout[0].__dr = Convert.ToDouble(50);
__ccolorout[0].__dg = Convert.ToDouble(10.5);
__ccolorout[0].__db = Convert.ToDouble(10.5);
}
if(Convert.ToBoolean((__ncolorin==20)))
{
__ccolorout[0].__dr = Convert.ToDouble(0);
__ccolorout[0].__dg = Convert.ToDouble(54.3);
__ccolorout[0].__db = Convert.ToDouble(54.3);
}
if(Convert.ToBoolean((__ncolorin==21)))
{
__ccolorout[0].__dr = Convert.ToDouble(39.1);
__ccolorout[0].__dg = Convert.ToDouble(58.2);
__ccolorout[0].__db = Convert.ToDouble(92.6);
}
if(Convert.ToBoolean((__ncolorin==22)))
{
__ccolorout[0].__dr = Convert.ToDouble(100);
__ccolorout[0].__dg = Convert.ToDouble(7.8);
__ccolorout[0].__db = Convert.ToDouble(57.4);
}
if(Convert.ToBoolean((__ncolorin==23)))
{
__ccolorout[0].__dr = Convert.ToDouble(100);
__ccolorout[0].__dg = Convert.ToDouble(84);
__ccolorout[0].__db = Convert.ToDouble(0);
}
__ccolorout[0].__dr = Convert.ToDouble(__ccolorout[0].__dr*(__fint/100));
__ccolorout[0].__dg = Convert.ToDouble(__ccolorout[0].__dg*(__fint/100));
__ccolorout[0].__db = Convert.ToDouble(__ccolorout[0].__db*(__fint/100));
}
public int __coloridx;
public override void Run() {
__tcolor __c = new __tcolor();
GlobalState.MainClass.__coloridx = Convert.ToInt32(GlobalState.MainClass.__coloridx+1);
if(Convert.ToBoolean((GlobalState.MainClass.__coloridx==24)))
GlobalState.MainClass.__coloridx = Convert.ToInt32(0);
{
var _arg2 = new vip_sharp.BipolarArray<__tcolor>(1) { __c };
GlobalState.MainClass.__getcolorrgb(Convert.ToInt32(GlobalState.MainClass.__coloridx),Convert.ToSingle(100),_arg2);
__c = _arg2[0];}
vip_sharp.VIPRuntime.Instance.Color(__c);
vip_sharp.VIPRuntime.Instance.Circle(0,0,4,25,true);
}
}
