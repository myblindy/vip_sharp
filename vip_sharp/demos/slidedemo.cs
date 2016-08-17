using System;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass {
public MainClass() { GlobalState.MainClass = this; }
public vip_sharp.VIPRuntime.BitmapRes __bmpSwitch = new vip_sharp.VIPRuntime.BitmapRes(vip_sharp.VIPRuntime.BitmapType.RGB, vip_sharp.VIPRuntime.BitmapFilter.Linear, vip_sharp.VIPRuntime.BitmapClamp.Clamp, @"Switch.bmp");
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
vip_sharp.VIPRuntime.Instance.HotSpot(0,0,0.2,0.3,vip_sharp.VIPRuntime.PositionRef.CU,ref __bSelDown,vip_sharp.VIPRuntime.HotSpotTrigger.Selected,vip_sharp.VIPRuntime.HotSpotType.Momentary,true,false,vip_sharp.VIPRuntime.HotSpotHoverBox.Never);
vip_sharp.VIPRuntime.Instance.HotSpot(0,0,0.2,0.3,vip_sharp.VIPRuntime.PositionRef.CL,ref __bSelUp,vip_sharp.VIPRuntime.HotSpotTrigger.Selected,vip_sharp.VIPRuntime.HotSpotType.Momentary,true,false,vip_sharp.VIPRuntime.HotSpotHoverBox.Never);
if(__bSelUp) {
__cOut.__bSel = true;
}
else {
if(__bSelDown) {
__cOut.__bSel = false;
}
}
if(__cOut.__bSel) {
vip_sharp.VIPRuntime.Instance.Bitmap(GlobalState.MainClass.__bmpSwitch, vip_sharp.VIPRuntime.BitmapBlend.Replace, 0,0,0.2,0.6,vip_sharp.VIPRuntime.PositionRef.CTR,GlobalState.MainClass.__uvUp);
}
else {
vip_sharp.VIPRuntime.Instance.Bitmap(GlobalState.MainClass.__bmpSwitch, vip_sharp.VIPRuntime.BitmapBlend.Replace, 0,0,0.2,0.6,vip_sharp.VIPRuntime.PositionRef.CTR,GlobalState.MainClass.__uvDown);
}
}
}
public __TwoPosSwitch __sw1 = new __TwoPosSwitch() { X = 0,Y = 0,s = 1};
public void Run() {
vip_sharp.VIPRuntime.Instance.Draw(__sw1);
}
}
