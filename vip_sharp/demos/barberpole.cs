using System;
using System.Linq;
using System.Collections.Generic;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
__pole1 = new __barberpole() { x = -4,y = 0};
__pole2 = new __barberpole() { x = 4,y = 0};
}
public class __tvertex { 
public double __dx;
public double __dy;
}
public class __barberpole : vip_sharp.VIPRuntime.VIPObject {
public __barberpole() {
this.__textvertices2= new vip_sharp.BipolarArray<__tvertex>(4) {new __tvertex {__dx = 0,__dy = 0},new __tvertex {__dx = 0,__dy = 3},new __tvertex {__dx = 1,__dy = 3},new __tvertex {__dx = 1,__dy = 0}};
this.__doffset = 0;
__stripe = new vip_sharp.VIPRuntime.BitmapRes(vip_sharp.VIPRuntime.BitmapType.RGB, vip_sharp.VIPRuntime.BitmapFilter.Linear, vip_sharp.VIPRuntime.BitmapClamp.Repeat, @"stripe.bmp");
}
public vip_sharp.BipolarArray<__tvertex> __textvertices2;
public double __doffset;
public vip_sharp.VIPRuntime.BitmapRes __stripe = null;
public override void Run() {
__textvertices2[0].__dy = Convert.ToDouble(0-__doffset);
__textvertices2[1].__dy = Convert.ToDouble(6-__doffset);
__textvertices2[2].__dy = Convert.ToDouble(6-__doffset);
__textvertices2[3].__dy = Convert.ToDouble(0-__doffset);
vip_sharp.VIPRuntime.Instance.Bitmap(__stripe, vip_sharp.VIPRuntime.BitmapBlend.Modulate, 0,0,0.5,8,vip_sharp.VIPRuntime.PositionRef.ctr,__textvertices2);
__doffset = Convert.ToDouble(__doffset+0.01);
if(Convert.ToBoolean((__doffset>1)))
{
__doffset = Convert.ToDouble(0);
}
}
}
public __barberpole __pole1;
public __barberpole __pole2;
public override void Run() {
vip_sharp.VIPRuntime.Instance.Scale(2.5);
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__pole1);
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__pole2);
}
}
