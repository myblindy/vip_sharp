using System;
using System.Linq;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
}
public override void Run() {
vip_sharp.BipolarArray<int> __a= new vip_sharp.BipolarArray<int>(5) {100,101};
vip_sharp.BipolarArray<char> __b= new vip_sharp.BipolarArray<char>(5,"meep");
vip_sharp.BipolarArray<int> __c= new vip_sharp.BipolarArray<int>(5);
vip_sharp.BipolarArray<int> __d= new vip_sharp.BipolarArray<int>() {100,101};
vip_sharp.BipolarArray<char> __e= new vip_sharp.BipolarArray<char>("meep");
int __f = 100+101;
int __g = 0;
}
}
