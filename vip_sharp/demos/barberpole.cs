using System;
public class __MainClass {
public class __TVertex { 
public double __dX;
public double __dY;
}
public class __BarberPole : vip_sharp.VIPUtils.IVIPObject {
public double X=0, Y=0;
public double GetX() { return X; }
public double GetY() { return Y; }
vip_sharp.BipolarArray<__TVertex> __TextVertices2 = new vip_sharp.BipolarArray<__TVertex>(4) {new __TVertex{__dX = 0,__dY = 0},new __TVertex{__dX = 0,__dY = 3},new __TVertex{__dX = 1,__dY = 3},new __TVertex{__dX = 1,__dY = 0}};
double __dOffSet = 0;
vip_sharp.VIPUtils.BitmapRes __STRIPE = new vip_sharp.VIPUtils.BitmapRes(vip_sharp.VIPUtils.BitmapType.RGB, vip_sharp.VIPUtils.BitmapFilter.Linear, vip_sharp.VIPUtils.BitmapClamp.Repeat, @"stripe.bmp");
public void Run() {
__TextVertices2[0].__dY = 0-__dOffSet;
__TextVertices2[1].__dY = 6-__dOffSet;
__TextVertices2[2].__dY = 6-__dOffSet;
__TextVertices2[3].__dY = 0-__dOffSet;
vip_sharp.VIPUtils.Instance.Bitmap(__STRIPE, vip_sharp.VIPUtils.BitmapBlend.Modulate, 0,0,0.5,8,vip_sharp.VIPUtils.PositionRef.CTR,__TextVertices2);
__dOffSet = __dOffSet+0.01;
if(__dOffSet>1) {
__dOffSet = 0;
}
}
}
__BarberPole __Pole1 = new __BarberPole() { X = -4,Y = 0};
__BarberPole __Pole2 = new __BarberPole() { X = 4,Y = 0};
public void Run() {
vip_sharp.VIPUtils.Instance.Scale(2.5);
vip_sharp.VIPUtils.Instance.Draw(__Pole1);
vip_sharp.VIPUtils.Instance.Draw(__Pole2);
}
}
