using System;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
__c1 = new __OComplex__autogen_0() { };
__c2 = new __OComplex__autogen_3() { };
__c3 = new __OComplex__autogen_6() { };
__c4 = new __OComplex__autogen_6() { };
__s1 = new __OSimple() { };
__s2 = new __OSimple() { };
}
public class __OInner__autogen_1 : vip_sharp.VIPRuntime.VIPObject {
public __OInner__autogen_1(double __IV) {
this.__meep = 0;
__meep = __IV;
}
public double __meep;
public override void Run() {
}
}
public class __OInner__autogen_2 : vip_sharp.VIPRuntime.VIPObject {
public __OInner__autogen_2(int __IV) {
this.__meep = 0;
__meep = __IV;
}
public int __meep;
public override void Run() {
}
}
public class __OInner__autogen_4 : vip_sharp.VIPRuntime.VIPObject {
public __OInner__autogen_4(double __IV) {
this.__moop = 0;
__moop = __IV;
}
public double __moop;
public override void Run() {
}
}
public class __OInner__autogen_5 : vip_sharp.VIPRuntime.VIPObject {
public __OInner__autogen_5(int __IV) {
this.__moop = 0;
__moop = __IV;
}
public int __moop;
public override void Run() {
}
}
public class __OInner__autogen_7 : vip_sharp.VIPRuntime.VIPObject {
public __OInner__autogen_7(double __IV) {
this.__maep = 0;
__maep = __IV;
}
public double __maep;
public override void Run() {
}
}
public class __OInner__autogen_8 : vip_sharp.VIPRuntime.VIPObject {
public __OInner__autogen_8(int __IV) {
this.__maep = 0;
__maep = __IV;
}
public int __maep;
public override void Run() {
}
}
public class __OComplex__autogen_0 : vip_sharp.VIPRuntime.VIPObject {
public __OComplex__autogen_0() {
this.__meep = 0;
__o1 = new __OInner__autogen_1(1) { };
__o2 = new __OInner__autogen_2(11) { };
__meep = 1;
}
public double __meep;
public __OInner__autogen_1 __o1;
public __OInner__autogen_2 __o2;
public override void Run() {
}
}
public class __OComplex__autogen_3 : vip_sharp.VIPRuntime.VIPObject {
public __OComplex__autogen_3() {
this.__moop = 0;
__o1 = new __OInner__autogen_4(4) { };
__o2 = new __OInner__autogen_5(11) { };
__moop = 4;
}
public double __moop;
public __OInner__autogen_4 __o1;
public __OInner__autogen_5 __o2;
public override void Run() {
}
}
public class __OComplex__autogen_6 : vip_sharp.VIPRuntime.VIPObject {
public __OComplex__autogen_6() {
this.__maep = 0;
__o1 = new __OInner__autogen_7(2) { };
__o2 = new __OInner__autogen_8(11) { };
__maep = 2;
}
public double __maep;
public __OInner__autogen_7 __o1;
public __OInner__autogen_8 __o2;
public override void Run() {
}
}
public class __OSimple : vip_sharp.VIPRuntime.VIPObject {
public __OSimple() {
}
public override void Run() {
}
}
public __OComplex__autogen_0 __c1;
public __OComplex__autogen_3 __c2;
public __OComplex__autogen_6 __c3;
public __OComplex__autogen_6 __c4;
public __OSimple __s1;
public __OSimple __s2;
public override void Run() {
}
}
