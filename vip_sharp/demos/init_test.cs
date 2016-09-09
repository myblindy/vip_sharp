using System;
using System.Linq;
using System.Collections.Generic;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
__bl1 = new __blinker(Convert.ToDouble(1),Convert.ToDouble(100),Convert.ToDouble(0),Convert.ToDouble(0)) { x = -5,y = 0};
__bl2 = new __blinker(Convert.ToDouble(0.5),Convert.ToDouble(0),Convert.ToDouble(100),Convert.ToDouble(0)) { x = 5,y = 0};
}
public class __tcolor3 { 
public double __dr;
public double __dg;
public double __db;
}
public class __blinker : vip_sharp.VIPRuntime.VIPObject {
public __blinker(double __dblinkfreq,double __dr,double __dg,double __db) {
this.__m_dblinktime = 0;
this.__m_dcurrtime = 0;
this.__m_color = new __tcolor3();
__m_color.__dr = Convert.ToDouble(__dr);
__m_color.__dg = Convert.ToDouble(__dg);
__m_color.__db = Convert.ToDouble(__db);
if(Convert.ToBoolean((__dblinkfreq>0)))
{
__m_dblinktime = Convert.ToDouble(1/(__dblinkfreq/2));
}
}
public double __m_dblinktime;
public double __m_dcurrtime;
public __tcolor3 __m_color;
public class __struct_cin {
public int __bstat;
}
public __struct_cin __cin=new __struct_cin();
public override void Run() {
if(Convert.ToBoolean((__cin.__bstat&&(__m_dcurrtime<__m_dblinktime))))
{
vip_sharp.VIPRuntime.Instance.Color(__m_color);
vip_sharp.VIPRuntime.Instance.Circle(0,0,2,40,true);
}
__m_dcurrtime = Convert.ToDouble(__m_dcurrtime+vip_sharp.VIPRuntime.Instance.VIPSystemClass.__ddt);
if(Convert.ToBoolean((__m_dcurrtime>(__m_dblinktime*2))))
{
__m_dcurrtime = Convert.ToDouble(__m_dcurrtime-(__m_dblinktime*2));
}
}
}
public __blinker __bl1;
public __blinker __bl2;
public override void Run() {
GlobalState.MainClass.__bl1.__cin.__bstat = Convert.ToInt32(1);
GlobalState.MainClass.__bl2.__cin.__bstat = Convert.ToInt32(1);
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__bl1);
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__bl2);
}
}
