using System;
public class __MainClass {
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
double __angle = 0;
public void Run() {
__TVertex[] __Vertices = new __TVertex[3]{new __TVertex{__dX = -4.33,__dY = -5},new __TVertex{__dX = -4.33,__dY = 5},new __TVertex{__dX = 4.33,__dY = 0}};
__TColor4[] __Colors = new __TColor4[3]{new __TColor4{__dR = 100,__dG = 0,__dB = 0,__dA = 100},new __TColor4{__dR = 0,__dG = 100,__dB = 0,__dA = 100},new __TColor4{__dR = 0,__dG = 0,__dB = 100,__dA = 100}};
vip_sharp.VIPUtils.Instance.Translate(2, 0);
vip_sharp.VIPUtils.Instance.Scale(1.5);
vip_sharp.VIPUtils.Instance.Rotate(__angle);
__angle = __angle+0.2;
vip_sharp.VIPUtils.Instance.Polygon(__Vertices,__Colors);
}
}
