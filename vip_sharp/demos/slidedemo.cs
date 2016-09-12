using System;
using System.Linq;
using System.Collections.Generic;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
__bmpswitch = new vip_sharp.VIPRuntime.BitmapRes(vip_sharp.VIPRuntime.BitmapType.RGB, vip_sharp.VIPRuntime.BitmapFilter.Linear, vip_sharp.VIPRuntime.BitmapClamp.Clamp, @"Switch.bmp");
this.__uvdown= new vip_sharp.BipolarArray<__tvertex>(4) {new __tvertex {__dx = 0,__dy = 0},new __tvertex {__dx = 0,__dy = 1},new __tvertex {__dx = 0.5,__dy = 1},new __tvertex {__dx = 0.5,__dy = 0}};
this.__uvup= new vip_sharp.BipolarArray<__tvertex>(4) {new __tvertex {__dx = 0.5,__dy = 0},new __tvertex {__dx = 0.5,__dy = 1},new __tvertex {__dx = 1,__dy = 1},new __tvertex {__dx = 1,__dy = 0}};
__sw1 = new __twoposswitch() { x = 0,y = 0,s = 1};
}
public vip_sharp.VIPRuntime.BitmapRes __bmpswitch = null;
public class __tvertex { 
public double __dx;
public double __dy;
}
public vip_sharp.BipolarArray<__tvertex> __uvdown;
public vip_sharp.BipolarArray<__tvertex> __uvup;
public class __twoposswitch : vip_sharp.VIPRuntime.VIPObject {
public __twoposswitch() {
}
public class __struct_cout {
public int __bsel;
}
public __struct_cout __cout=new __struct_cout();
public override void Run() {
int __bselup = 0;
int __bseldown = 0;
__bseldown = Convert.ToInt32(vip_sharp.VIPRuntime.Instance.HotSpot(1, this,0,0,0.2,0.3,vip_sharp.VIPRuntime.PositionRef.cu,__bseldown,vip_sharp.VIPRuntime.HotSpotTrigger.Selected,vip_sharp.VIPRuntime.HotSpotType.Momentary,Convert.ToInt32(1),Convert.ToInt32(0),vip_sharp.VIPRuntime.HoverBox.Never));
__bselup = Convert.ToInt32(vip_sharp.VIPRuntime.Instance.HotSpot(2, this,0,0,0.2,0.3,vip_sharp.VIPRuntime.PositionRef.cl,__bselup,vip_sharp.VIPRuntime.HotSpotTrigger.Selected,vip_sharp.VIPRuntime.HotSpotType.Momentary,Convert.ToInt32(1),Convert.ToInt32(0),vip_sharp.VIPRuntime.HoverBox.Never));
if(Convert.ToBoolean(__bselup))
{
__cout.__bsel = Convert.ToInt32(1);
}
else
{
if(Convert.ToBoolean(__bseldown))
{
__cout.__bsel = Convert.ToInt32(0);
}
}
if(Convert.ToBoolean(__cout.__bsel))
{
vip_sharp.VIPRuntime.Instance.Bitmap(GlobalState.MainClass.__bmpswitch, vip_sharp.VIPRuntime.BitmapBlend.Replace, 0,0,0.2,0.6,vip_sharp.VIPRuntime.PositionRef.ctr,GlobalState.MainClass.__uvup);
}
else
{
vip_sharp.VIPRuntime.Instance.Bitmap(GlobalState.MainClass.__bmpswitch, vip_sharp.VIPRuntime.BitmapBlend.Replace, 0,0,0.2,0.6,vip_sharp.VIPRuntime.PositionRef.ctr,GlobalState.MainClass.__uvdown);
}
}
}
public __twoposswitch __sw1;
public override void Run() {
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__sw1);
}
}
