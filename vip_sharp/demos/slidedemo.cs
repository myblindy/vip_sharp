using System;
using System.Linq;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
__bmpSwitch= new vip_sharp.VIPRuntime.BitmapRes(vip_sharp.VIPRuntime.BitmapType.RGB, vip_sharp.VIPRuntime.BitmapFilter.Linear, vip_sharp.VIPRuntime.BitmapClamp.Clamp, @"Switch.bmp");
__sw1 = new __TwoPosSwitch() { X = 0,Y = 0,s = 1};
}
public vip_sharp.VIPRuntime.BitmapRes __bmpSwitch;
public class __TVertex { 
public double __dX;
public double __dY;
}
public vip_sharp.BipolarArray<__TVertex> __uvDown= new vip_sharp.BipolarArray<__TVertex>(4) {new __TVertex {__dX = 0,__dY = 0},new __TVertex {__dX = 0,__dY = 1},new __TVertex {__dX = 0.5,__dY = 1},new __TVertex {__dX = 0.5,__dY = 0}};
public vip_sharp.BipolarArray<__TVertex> __uvUp= new vip_sharp.BipolarArray<__TVertex>(4) {new __TVertex {__dX = 0.5,__dY = 0},new __TVertex {__dX = 0.5,__dY = 1},new __TVertex {__dX = 1,__dY = 1},new __TVertex {__dX = 1,__dY = 0}};
public class __TwoPosSwitch : vip_sharp.VIPRuntime.VIPObject {
public __TwoPosSwitch() {
}
public class __struct_cOut {
public bool __bSel;
}
public __struct_cOut __cOut=new __struct_cOut();
public override void Run() {
bool __bSelUp = false;
bool __bSelDown = false;
vip_sharp.VIPRuntime.Instance.HotSpot(1, this,0,0,0.2,0.3,vip_sharp.VIPRuntime.PositionRef.CU,ref __bSelDown,vip_sharp.VIPRuntime.HotSpotTrigger.Selected,vip_sharp.VIPRuntime.HotSpotType.Momentary,true,false,vip_sharp.VIPRuntime.HoverBox.Never);
vip_sharp.VIPRuntime.Instance.HotSpot(2, this,0,0,0.2,0.3,vip_sharp.VIPRuntime.PositionRef.CL,ref __bSelUp,vip_sharp.VIPRuntime.HotSpotTrigger.Selected,vip_sharp.VIPRuntime.HotSpotType.Momentary,true,false,vip_sharp.VIPRuntime.HoverBox.Never);
if(Convert.ToBoolean(__bSelUp))
{
__cOut.__bSel = true;
}
else
{
if(Convert.ToBoolean(__bSelDown))
{
__cOut.__bSel = false;
}
}
if(Convert.ToBoolean(__cOut.__bSel))
{
vip_sharp.VIPRuntime.Instance.Bitmap(GlobalState.MainClass.__bmpSwitch, vip_sharp.VIPRuntime.BitmapBlend.Replace, 0,0,0.2,0.6,vip_sharp.VIPRuntime.PositionRef.CTR,GlobalState.MainClass.__uvUp);
}
else
{
vip_sharp.VIPRuntime.Instance.Bitmap(GlobalState.MainClass.__bmpSwitch, vip_sharp.VIPRuntime.BitmapBlend.Replace, 0,0,0.2,0.6,vip_sharp.VIPRuntime.PositionRef.CTR,GlobalState.MainClass.__uvDown);
}
}
}
public __TwoPosSwitch __sw1;
public override void Run() {
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__sw1);
}
}
