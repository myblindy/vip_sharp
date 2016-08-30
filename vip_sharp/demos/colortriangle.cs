using System;
using System.Linq;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
}
public class __TVertex { 
public double __dX;
public double __dY;
}
public class __TColor4 { 
public double __dR;
public double __dG;
public double __dB;
public double __dA;
}
public double __angle = 0;
public override void Run() {
vip_sharp.BipolarArray<__TVertex> __Vertices= new vip_sharp.BipolarArray<__TVertex>(3) {new __TVertex {__dX = -4.33,__dY = -5},new __TVertex {__dX = -4.33,__dY = 5},new __TVertex {__dX = 4.33,__dY = 0}};
vip_sharp.BipolarArray<__TColor4> __Colors= new vip_sharp.BipolarArray<__TColor4>(3) {new __TColor4 {__dR = 100,__dG = 0,__dB = 0,__dA = 100},new __TColor4 {__dR = 0,__dG = 100,__dB = 0,__dA = 100},new __TColor4 {__dR = 0,__dG = 0,__dB = 100,__dA = 100}};
vip_sharp.VIPRuntime.Instance.Translate(2, 0);
vip_sharp.VIPRuntime.Instance.Scale(1.5);
vip_sharp.VIPRuntime.Instance.Rotate(GlobalState.MainClass.__angle);
GlobalState.MainClass.__angle = GlobalState.MainClass.__angle+0.2;
vip_sharp.VIPRuntime.Instance.Polygon(__Vertices,__Colors);
}
}
