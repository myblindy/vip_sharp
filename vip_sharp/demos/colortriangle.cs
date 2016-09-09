using System;
using System.Linq;
using System.Collections.Generic;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
this.__angle = 0;
}
public class __tvertex { 
public double __dx;
public double __dy;
}
public class __tcolor4 { 
public double __dr;
public double __dg;
public double __db;
public double __da;
}
public double __angle;
public override void Run() {
vip_sharp.BipolarArray<__tvertex> __vertices= new vip_sharp.BipolarArray<__tvertex>(3) {new __tvertex {__dx = -4.33,__dy = -5},new __tvertex {__dx = -4.33,__dy = 5},new __tvertex {__dx = 4.33,__dy = 0}};
vip_sharp.BipolarArray<__tcolor4> __colors= new vip_sharp.BipolarArray<__tcolor4>(3) {new __tcolor4 {__dr = 100,__dg = 0,__db = 0,__da = 100},new __tcolor4 {__dr = 0,__dg = 100,__db = 0,__da = 100},new __tcolor4 {__dr = 0,__dg = 0,__db = 100,__da = 100}};
vip_sharp.VIPRuntime.Instance.Translate(2, 0);
vip_sharp.VIPRuntime.Instance.Scale(1.5);
vip_sharp.VIPRuntime.Instance.Rotate(GlobalState.MainClass.__angle);
GlobalState.MainClass.__angle = Convert.ToDouble(GlobalState.MainClass.__angle+0.2);
vip_sharp.VIPRuntime.Instance.Polygon(__vertices,__colors);
}
}
