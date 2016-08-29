using System;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
}
public class __OComplex__autogen_0 : vip_sharp.VIPRuntime.VIPObject {
public __OComplex__autogen_0() {
this.__meep = 0;
__meep = 1;
}
public double __meep;
public override void Run() {
}
}
public class __OComplex__autogen_1 : vip_sharp.VIPRuntime.VIPObject {
public __OComplex__autogen_1() {
this.__moop = 0;
__moop = 4;
}
public double __moop;
public override void Run() {
}
}
public class __OComplex__autogen_2 : vip_sharp.VIPRuntime.VIPObject {
public __OComplex__autogen_2() {
this.__maep = 0;
__maep = 2;
}
public double __maep;
public override void Run() {
}
}
public class __OSimple : vip_sharp.VIPRuntime.VIPObject {
public __OSimple() {
}
public override void Run() {
}
}
public __OComplex__autogen_0 __c1 = new __OComplex__autogen_0() { };
public __OComplex__autogen_1 __c2 = new __OComplex__autogen_1() { };
public __OComplex__autogen_2 __c3 = new __OComplex__autogen_2() { };
public __OComplex__autogen_2 __c4 = new __OComplex__autogen_2() { };
public __OSimple __s1 = new __OSimple() { };
public __OSimple __s2 = new __OSimple() { };
public override void Run() {
}
}
