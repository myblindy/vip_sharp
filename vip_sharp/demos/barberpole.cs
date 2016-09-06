using System;
using System.Linq;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
__Pole1 = new __BarberPole() { X = -4,Y = 0};
__Pole2 = new __BarberPole() { X = 4,Y = 0};
}
public class __TVertex { 
public double __dX;
public double __dY;
}
public class __BarberPole : vip_sharp.VIPRuntime.VIPObject {
public __BarberPole() {
this.__TextVertices2= new vip_sharp.BipolarArray<__TVertex>(4) {new __TVertex {__dX = 0,__dY = 0},new __TVertex {__dX = 0,__dY = 3},new __TVertex {__dX = 1,__dY = 3},new __TVertex {__dX = 1,__dY = 0}};
this.__dOffSet = 0;
__STRIPE = new vip_sharp.VIPRuntime.BitmapRes(vip_sharp.VIPRuntime.BitmapType.RGB, vip_sharp.VIPRuntime.BitmapFilter.Linear, vip_sharp.VIPRuntime.BitmapClamp.Repeat, @"stripe.bmp");
}
public vip_sharp.BipolarArray<__TVertex> __TextVertices2;
public double __dOffSet;
public vip_sharp.VIPRuntime.BitmapRes __STRIPE = null;
public override void Run() {
__TextVertices2[0].__dY = 0-__dOffSet;
__TextVertices2[1].__dY = 6-__dOffSet;
__TextVertices2[2].__dY = 6-__dOffSet;
__TextVertices2[3].__dY = 0-__dOffSet;
vip_sharp.VIPRuntime.Instance.Bitmap(__STRIPE, vip_sharp.VIPRuntime.BitmapBlend.Modulate, 0,0,0.5,8,vip_sharp.VIPRuntime.PositionRef.CTR,__TextVertices2);
__dOffSet = __dOffSet+0.01;
if(Convert.ToBoolean((__dOffSet>1)))
{
__dOffSet = 0;
}
}
}
public __BarberPole __Pole1;
public __BarberPole __Pole2;
public override void Run() {
vip_sharp.VIPRuntime.Instance.Scale(2.5);
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__Pole1);
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__Pole2);
}
}
