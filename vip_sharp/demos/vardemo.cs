using System;
using System.Linq;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
}
public class __t1 { 
public double __x;
public double __y;
}
public override void Run() {
vip_sharp.BipolarArray<double> __a= new vip_sharp.BipolarArray<double>(5) {100,101};
vip_sharp.BipolarArray<char> __b= new vip_sharp.BipolarArray<char>(5,"meep");
vip_sharp.BipolarArray<int> __c= new vip_sharp.BipolarArray<int>(5);
vip_sharp.BipolarArray<int> __d= new vip_sharp.BipolarArray<int>() {100,101};
vip_sharp.BipolarArray<char> __e= new vip_sharp.BipolarArray<char>("meep");
int __f = 100+101;
int __g = 0;
__t1 __h= new __t1 {__x = 1,__y = 1.1};
vip_sharp.BipolarArray<__t1> __i= new vip_sharp.BipolarArray<__t1>() {new __t1 {__x = 1,__y = 2},new __t1 {__x = 3,__y = 4},new __t1 {__x = 5,__y = 6}};
vip_sharp.BipolarArray<__t1> __j= new vip_sharp.BipolarArray<__t1>(3) {new __t1 {__x = 1,__y = 3},new __t1 {__x = 5,__y = 6},new __t1 {__x = 0,__y = 0}};
double __tmp = __a[0]-0.05;
double __tmp2 = __a[0]-0.05;
double __tmp3 = __a[2]+2;
}
}
