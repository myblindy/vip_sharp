using System;
using System.Linq;
using System.Collections.Generic;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
__c1 = new __ocomplex__autogen_0() { };
__c2 = new __ocomplex__autogen_3() { };
__c3 = new __ocomplex__autogen_6() { };
__c4 = new __ocomplex__autogen_6() { };
__s1 = new __osimple() { };
__s2 = new __osimple() { };
}
public class __oinner__autogen_1 : vip_sharp.VIPRuntime.VIPObject {
public __oinner__autogen_1(double __iv) {
this.__meep = 0;
__meep = Convert.ToDouble(__iv);
}
public double __meep;
public override void Run() {
}
}
public class __oinner__autogen_2 : vip_sharp.VIPRuntime.VIPObject {
public __oinner__autogen_2(int __iv) {
this.__meep = 0;
__meep = Convert.ToInt32(__iv);
}
public int __meep;
public override void Run() {
}
}
public class __oinner__autogen_4 : vip_sharp.VIPRuntime.VIPObject {
public __oinner__autogen_4(double __iv) {
this.__moop = 0;
__moop = Convert.ToDouble(__iv);
}
public double __moop;
public override void Run() {
}
}
public class __oinner__autogen_5 : vip_sharp.VIPRuntime.VIPObject {
public __oinner__autogen_5(int __iv) {
this.__moop = 0;
__moop = Convert.ToInt32(__iv);
}
public int __moop;
public override void Run() {
}
}
public class __oinner__autogen_7 : vip_sharp.VIPRuntime.VIPObject {
public __oinner__autogen_7(double __iv) {
this.__maep = 0;
__maep = Convert.ToDouble(__iv);
}
public double __maep;
public override void Run() {
}
}
public class __oinner__autogen_8 : vip_sharp.VIPRuntime.VIPObject {
public __oinner__autogen_8(int __iv) {
this.__maep = 0;
__maep = Convert.ToInt32(__iv);
}
public int __maep;
public override void Run() {
}
}
public class __ocomplex__autogen_0 : vip_sharp.VIPRuntime.VIPObject {
public __ocomplex__autogen_0() {
this.__meep = 0;
__o1 = new __oinner__autogen_1(Convert.ToDouble(1)) { };
__o2 = new __oinner__autogen_2(Convert.ToInt32(11)) { };
__meep = Convert.ToDouble(1);
}
public double __meep;
public __oinner__autogen_1 __o1;
public __oinner__autogen_2 __o2;
public override void Run() {
}
}
public class __ocomplex__autogen_3 : vip_sharp.VIPRuntime.VIPObject {
public __ocomplex__autogen_3() {
this.__moop = 0;
__o1 = new __oinner__autogen_4(Convert.ToDouble(4)) { };
__o2 = new __oinner__autogen_5(Convert.ToInt32(11)) { };
__moop = Convert.ToDouble(4);
}
public double __moop;
public __oinner__autogen_4 __o1;
public __oinner__autogen_5 __o2;
public override void Run() {
}
}
public class __ocomplex__autogen_6 : vip_sharp.VIPRuntime.VIPObject {
public __ocomplex__autogen_6() {
this.__maep = 0;
__o1 = new __oinner__autogen_7(Convert.ToDouble(2)) { };
__o2 = new __oinner__autogen_8(Convert.ToInt32(11)) { };
__maep = Convert.ToDouble(2);
}
public double __maep;
public __oinner__autogen_7 __o1;
public __oinner__autogen_8 __o2;
public override void Run() {
}
}
public class __osimple : vip_sharp.VIPRuntime.VIPObject {
public __osimple() {
}
public override void Run() {
}
}
public __ocomplex__autogen_0 __c1;
public __ocomplex__autogen_3 __c2;
public __ocomplex__autogen_6 __c3;
public __ocomplex__autogen_6 __c4;
public __osimple __s1;
public __osimple __s2;
public override void Run() {
}
}
