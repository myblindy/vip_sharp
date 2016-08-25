using System;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
__VIP_Null = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__VIP_Smiley = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.5,0.5,16,false);
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.7,0.05,6,false);
vip_sharp.VIPRuntime.Instance.Circle(0.7,0.7,0.05,6,false);
vip_sharp.VIPRuntime.Instance.ArcLine(0.5,0.5,0.3,90,270,4);
});
__VIP_Smiley_Filled = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ColorSave();
vip_sharp.VIPRuntime.Instance.Color(0,0,0);
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.5,0.5,16,false);
vip_sharp.VIPRuntime.Instance.Color(100,100,100);
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.7,0.05,6,false);
vip_sharp.VIPRuntime.Instance.Circle(0.7,0.7,0.05,6,false);
vip_sharp.VIPRuntime.Instance.ArcLine(0.5,0.5,0.3,90,270,4);
vip_sharp.VIPRuntime.Instance.ColorRestore();
});
__VIP_Heart = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Polygon(0.5,0,0.1,0.4,0,0.6,0,0.8,0.2,1,0.3,1,0.4,0.9,0.5,0.7);
vip_sharp.VIPRuntime.Instance.Polygon(0.5,0.7,0.4,0.9,0.3,1,0.2,1,0,0.8,0,0.6,0.1,0.4,0.5,0);
});
__VIP_Diamond = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Quad(0.5,1,1,0.5,0.5,0,0,0.5);
});
__VIP_Clover = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Polygon(0.5,0.5,0.3,0.8,0.4,1,0.6,1,0.7,0.8);
vip_sharp.VIPRuntime.Instance.Polygon(0.5,0.5,0.4,0.3,0.3,0.2,0.1,0.2,0,0.3,0,0.4,0.2,0.5);
vip_sharp.VIPRuntime.Instance.Polygon(0.2,0.5,0,0.4,0,0.3,0.1,0.2,0.3,0.2,0.4,0.3,0.5,0.5);
vip_sharp.VIPRuntime.Instance.Triangle(0.4,0,0.5,0.3,0.6,0);
});
__VIP_Ace = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Polygon(0.5,1,0.5,0.5,0.4,0.3,0.3,0.2,0.2,0.2,0,0.4,0,0.6);
vip_sharp.VIPRuntime.Instance.Polygon(0,0.6,0,0.4,0.2,0.2,0.3,0.2,0.4,0.3,0.5,0.5,0.5,1);
vip_sharp.VIPRuntime.Instance.Triangle(0.4,0,0.5,0.3,0.6,0);
});
__VIP_Big_Dot = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__VIP_Quad_Big_Dot = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__VIP_Open_Circle = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__VIP_Circle_Filled = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__VIP_Male_Sign = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.3,0.3,12,false);
vip_sharp.VIPRuntime.Instance.Line(0.627,0.627,1,1);
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,1,1,1,1,0.7);
});
__VIP_Female_Sign = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.7,0.3,12,false);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.4);
});
__VIP_Note = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Circle(0.4,0.1,0.1,6,false);
vip_sharp.VIPRuntime.Instance.LineStrip(0.5,1,0.5,1,0.7,0.8,0.7,0.6,0.6,0.4);
});
__VIP_Double_Note = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.2,0.1,6,false);
vip_sharp.VIPRuntime.Instance.Circle(0.8,0.1,0.1,6,false);
vip_sharp.VIPRuntime.Instance.Line(0.3,0.3,0.3,1,0.9,0.1,0.9,0.8);
vip_sharp.VIPRuntime.Instance.Quad(0.3,0.9,0.3,1,0.9,0.8,0.9,0.7);
});
__VIP_Sun = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.5,0.3,12,false);
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Translate(0.5, 0.5);
vip_sharp.VIPRuntime.Instance.Line(0,0.3,0,0.5);
vip_sharp.VIPRuntime.Instance.Rotate(45);
vip_sharp.VIPRuntime.Instance.Line(0,0.3,0,0.5);
vip_sharp.VIPRuntime.Instance.Rotate(45);
vip_sharp.VIPRuntime.Instance.Line(0,0.3,0,0.5);
vip_sharp.VIPRuntime.Instance.Rotate(45);
vip_sharp.VIPRuntime.Instance.Line(0,0.3,0,0.5);
vip_sharp.VIPRuntime.Instance.Rotate(45);
vip_sharp.VIPRuntime.Instance.Line(0,0.3,0,0.5);
vip_sharp.VIPRuntime.Instance.Rotate(45);
vip_sharp.VIPRuntime.Instance.Line(0,0.3,0,0.5);
vip_sharp.VIPRuntime.Instance.Rotate(45);
vip_sharp.VIPRuntime.Instance.Line(0,0.3,0,0.5);
vip_sharp.VIPRuntime.Instance.Rotate(45);
vip_sharp.VIPRuntime.Instance.Line(0,0.3,0,0.5);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
});
__VIP_Triangle_Right = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0.9,0.5,0.1,0.9,0.1,0.1);
});
__VIP_Triangle_Left = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0.1,0.5,0.9,0.9,0.9,0.1);
});
__VIP_Arrow_Up_Down = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__VIP_Double_Exclamation = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__VIP_Pi_Sign = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__VIP_Double_S = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__VIP_Fat_Stripe = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__VIP_Arrow_Up_Down_Bottom = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0.4,0.7,0.5,1,0.6,0.7);
vip_sharp.VIPRuntime.Instance.Triangle(0.5,0,0.4,0.3,0.6,0.3);
vip_sharp.VIPRuntime.Instance.Line(0.3,0,0.7,0,0.5,0.4,0.5,0.7);
});
__VIP_Up_Arrow = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0.4,0.7,0.5,1,0.6,0.7);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.7);
});
__VIP_Down_Arrow = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0.5,0,0.4,0.3,0.6,0.3);
vip_sharp.VIPRuntime.Instance.Line(0.5,1,0.5,0.3);
});
__VIP_Right_Arrow = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(1,0.5,0.7,0.4,0.7,0.6);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,0.7,0.5);
});
__VIP_Left_Arrow = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0,0.5,0.3,0.6,0.3,0.4);
vip_sharp.VIPRuntime.Instance.Line(0.3,0.5,1,0.5);
});
__VIP_FS = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__VIP_Double_Arrow = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__VIP_Triangle_Up = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0.5,0.9,0.9,0.1,0.1,0.1);
});
__VIP_Triangle_Down = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0.1,0.9,0.9,0.9,0.5,0.1);
});
__VIP_Space = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__VIP_Exlamation_Point = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0.5,0.3,0.4,1,0.6,1);
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.1,0.1,6,true);
});
__VIP_Double_Quote = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,0.9,0.4,0.9,0.4,0.8,0.3,0.8,0.3,0.9,0.4,1);
vip_sharp.VIPRuntime.Instance.LineStrip(0.6,0.9,0.7,0.9,0.7,0.8,0.6,0.8,0.6,0.9,0.7,1);
});
__VIP_Number_Sign = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.25,0,0.35,1,0.65,0,0.75,1,0,0.3,0.95,0.3,0.05,0.7,1,0.7);
});
__VIP_Dollar_Sign = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.1,0.2,0.2,0.1,0.8,0.1,0.9,0.2,0.9,0.4,0.8,0.5,0.2,0.5,0.1,0.6,0.1,0.8,0.2,0.9,0.8,0.9,0.9,0.8);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,1);
});
__VIP_Percent = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.7,0.1,6,false);
vip_sharp.VIPRuntime.Instance.Circle(0.7,0.3,0.1,6,false);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.1,0.8,0.9);
});
__VIP_Ampersand = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,0,0.2,0.6,0.2,0.7,0.3,0.8,0.5,0.8,0.6,0.7,0.6,0.6,0.1,0.3,0.1,0.1,0.2,0,0.5,0,0.7,0.3);
});
__VIP_Apostrophe = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,0.9,0.5,0.9,0.5,0.8,0.4,0.8,0.4,0.9,0.5,1);
});
__VIP_Left_Parenthesis = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.6,0,0.5,0,0.4,0.2,0.4,0.8,0.5,1,0.6,1);
});
__VIP_Right_Parenthesis = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,0,0.5,0,0.6,0.2,0.6,0.8,0.5,1,0.4,1);
});
__VIP_Asterisk = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Translate(0.5, 0.7);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,0.3);
vip_sharp.VIPRuntime.Instance.Rotate(72);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,0.3);
vip_sharp.VIPRuntime.Instance.Rotate(72);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,0.3);
vip_sharp.VIPRuntime.Instance.Rotate(72);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,0.3);
vip_sharp.VIPRuntime.Instance.Rotate(72);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,0.3);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
});
__VIP_Plus_Sign = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,0.4,0.8,0.4);
vip_sharp.VIPRuntime.Instance.Line(0.4,0.1,0.4,0.7);
});
__VIP_Comma = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,0,0.2,0,0.2,0.1,0.3,0.1,0.3,0,0.2,-0.1);
});
__VIP_minus = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.2,0.5,0.8,0.5);
});
__VIP_Period = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.2,0.1,0.3,0.1,0.3,0,0.2,0);
});
__VIP_Slash = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.2,0,0.8,1);
});
__VIP_nr_0 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0,0,1,1,1,1,0);
});
__VIP_nr_1 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,1,0.5,1,0.5,0);
});
__VIP_nr_2 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,1,1,1,0.5,0,0.5,0,0,1,0);
});
__VIP_nr_3 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,1,1,1,0,0,0);
vip_sharp.VIPRuntime.Instance.Line(0.3,0.5,1,0.5);
});
__VIP_nr_4 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0,0.5,1,0.5);
vip_sharp.VIPRuntime.Instance.Line(1,0,1,1);
});
__VIP_nr_5 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,1,0,1,0.5,0,0.5,0,1,1,1);
});
__VIP_nr_6 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,1,0.5,1,0,0,0,0,1,1,1);
});
__VIP_nr_7 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,1,1,1,0);
});
__VIP_nr_8 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0,0,1,1,1,1,0);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,1,0.5);
});
__VIP_nr_9 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.5,0,0.5,0,1,1,1,1,0,0,0);
});
__VIP_Colon = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.4,0.7,0.4,0.8,0.5,0.8,0.5,0.7);
vip_sharp.VIPRuntime.Instance.ClosedLine(0.4,0.2,0.4,0.3,0.5,0.3,0.5,0.2);
});
__VIP_Semicolon = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.4,0.7,0.4,0.8,0.5,0.8,0.5,0.7);
vip_sharp.VIPRuntime.Instance.ClosedLine(0.4,0.2,0.4,0.3,0.5,0.3,0.5,0.2);
vip_sharp.VIPRuntime.Instance.Line(0.5,0.2,0.4,0.1);
});
__VIP_Less_Than = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.9,0.1,0.1,0.5,0.9,0.9);
});
__VIP_Equal_Sign = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.1,0.4,0.9,0.4,0.1,0.6,0.9,0.6);
});
__VIP_Greater_Than = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.1,0.1,0.9,0.5,0.1,0.9);
});
__VIP_Question_Mark = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.8,0,1,1,1,1,0.6,0.5,0.6,0.5,0.3);
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.1,0.1,6,false);
});
__VIP_AT_Symbol = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,0.4,0.6,0.3,0.3,0.3,0.3,0.6,0.4,0.7,0.7,0.7);
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,0.8,0.7,0.3,0.8,0.3,1,0.5,1,0.8,0.8,1,0.2,1,0,0.8,0,0.2,0.2,0,0.8,0,1,0.2);
});
__VIP_lt_A = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0.5,1,1,0);
vip_sharp.VIPRuntime.Instance.Line(0.15,0.3,0.85,0.3);
});
__VIP_lt_B = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0,0,1,0.7,1,0.9,0.9,0.9,0.6,0.7,0.5,1,0.3,1,0.1,0.8,0);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,0.7,0.5);
});
__VIP_lt_C = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.2,0.8,0,0.2,0,0,0.2,0,0.8,0.2,1,0.8,1,1,0.8);
});
__VIP_lt_D = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0,0,1,0.7,1,1,0.7,1,0.2,0.8,0);
});
__VIP_lt_E = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0,0,0,0,1,1,1);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,0.5,0.5);
});
__VIP_lt_F = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,1,1);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,0.5,0.5);
});
__VIP_lt_G = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.5,0.5,1,0.5,1,0.2,0.8,0,0.2,0,0,0.2,0,0.8,0.2,1,0.8,1,1,0.8);
});
__VIP_lt_H = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,1,0.5);
vip_sharp.VIPRuntime.Instance.Line(1,0,1,1);
});
__VIP_lt_I = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.3,0,0.7,0);
vip_sharp.VIPRuntime.Instance.Line(0.3,1,0.7,1);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,1);
});
__VIP_lt_J = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.5,1,0.9,1);
vip_sharp.VIPRuntime.Instance.LineStrip(0.2,0.2,0.4,0,0.5,0,0.7,0.2,0.7,1);
});
__VIP_lt_K = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.5,1,0);
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.5,1,1);
});
__VIP_lt_L = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0,0,1,0);
});
__VIP_lt_M = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,0.5,0.5,1,1,1,0);
});
__VIP_lt_N = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,1,0,1,1);
});
__VIP_lt_O = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.2,0,0,0.2,0,0.8,0.2,1,0.8,1,1,0.8,1,0.2,0.8,0);
});
__VIP_lt_P = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,0.8,1,1,0.8,1,0.6,0.8,0.4,0,0.4);
});
__VIP_lt_Q = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.2,0,0,0.2,0,0.8,0.2,1,0.8,1,1,0.8,1,0.2,0.8,0);
vip_sharp.VIPRuntime.Instance.Line(0.7,0.3,1,0);
});
__VIP_lt_R = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,0.8,1,1,0.8,1,0.6,0.8,0.4,0,0.4);
vip_sharp.VIPRuntime.Instance.Line(0.8,0.4,1,0);
});
__VIP_lt_S = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.1,0.2,0,0.8,0,1,0.2,1,0.4,0.9,0.5,0.1,0.5,0,0.6,0,0.8,0.2,1,0.8,1,1,0.9);
});
__VIP_lt_T = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,1,1,1);
vip_sharp.VIPRuntime.Instance.Line(0.5,1,0.5,0);
});
__VIP_lt_U = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0,0.2,0.2,0,0.8,0,1,0.2,1,1);
});
__VIP_lt_V = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0.5,0,1,1);
});
__VIP_lt_W = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0.2,0,0.5,0.4,0.8,0,1,1);
});
__VIP_lt_X = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,0,1,1);
vip_sharp.VIPRuntime.Instance.Line(0,1,1,0);
});
__VIP_lt_Y = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,0,1,1);
vip_sharp.VIPRuntime.Instance.Line(0,1,0.5,0.5);
});
__VIP_lt_Z = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0,0,0,1,1,0,1);
});
__VIP_Left_Square_Bracket = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.8,0,0.3,0,0.3,1,0.8,1);
});
__VIP_Back_Slash = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.2,1,0.8,0);
});
__VIP_Right_Square_Bracket = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.2,1,0.7,1,0.7,0,0.2,0);
});
__VIP_Caret = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,0.8,0.5,1,0.7,0.8);
});
__VIP_Underline = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,0,1,0);
});
__VIP_Accent = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,0.9,0.5,0.9,0.5,0.8,0.4,0.8,0.4,0.9,0.5,1);
});
__VIP_lt_la = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.4,0.2,0.6,0.8,0.6,1,0.4,1,0);
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0.2,0,0,0.1,0,0.2,0.2,0.3,0.8,0.3,1,0.2);
});
__VIP_lt_lb = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.1,0.8,0,0.2,0,0,0.1);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
});
__VIP_lt_lc = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5);
});
__VIP_lt_ld = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5);
vip_sharp.VIPRuntime.Instance.Line(1,0,1,1);
});
__VIP_lt_le = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.3,0,0.3);
});
__VIP_lt_lf = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,0,0.4,0.8,0.6,1,0.8,1);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.5,0.6,0.5);
});
__VIP_lt_lg = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5);
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.6,1,-0.2,0.8,-0.4,0.2,-0.4,0,-0.3);
});
__VIP_lt_lh = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0);
});
__VIP_lt_li = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.6,0.5,0.7,0.5,0.8);
});
__VIP_lt_lj = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,-0.4,0.5,-0.4,0.7,-0.3,0.7,0.6);
vip_sharp.VIPRuntime.Instance.Line(0.7,0.7,0.7,0.8);
});
__VIP_lt_lk = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
vip_sharp.VIPRuntime.Instance.Line(0,0.3,1,0.6);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.35,1,0);
});
__VIP_lt_ll = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,1);
});
__VIP_lt_lm = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.1,0.6,0.4,0.6,0.5,0.5,0.6,0.6,0.9,0.6,1,0.5,1,0);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,0.6);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.5);
});
__VIP_lt_ln = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.9,0.6,1,0.5,1,0);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,0.6);
});
__VIP_lt_lo = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.1,0.8,0,0.2,0);
});
__VIP_lt_lp = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.1,0.8,0,0.2,0,0,0.1);
vip_sharp.VIPRuntime.Instance.Line(0,0.6,0,-0.4);
});
__VIP_lt_lq = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.1,0.8,0,0.2,0);
vip_sharp.VIPRuntime.Instance.Line(0.7,0.2,1,0);
});
__VIP_lt_lr = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.9,0.6,1,0.5);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,0.6);
});
__VIP_lt_ls = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.1,0.2,0,0.9,0,1,0.1,1,0.2,0.8,0.3,0.2,0.3,0,0.4,0,0.5,0.1,0.6,0.8,0.6,1,0.5);
});
__VIP_lt_lt = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,1,0.4,0.1,0.5,0,0.6,0);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.7,0.6,0.7);
});
__VIP_lt_lu = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.6,0,0.1,0.2,0,0.8,0,1,0.1);
vip_sharp.VIPRuntime.Instance.Line(1,0.6,1,0);
});
__VIP_lt_lv = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.6,0.5,0,1,0.6);
});
__VIP_lt_lw = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.6,0.2,0,0.5,0.3,0.8,0,1,0.6);
});
__VIP_lt_lx = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,0,1,1,0,1,1,0);
});
__VIP_lt_ly = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,-0.4,0.5,0,1,0.6);
vip_sharp.VIPRuntime.Instance.Line(0,0.6,0.5,0);
});
__VIP_lt_lz = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.6,1,0.6,0,0,1,0);
});
__VIP_Left_Bracket_2 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,0,0.5,0,0.4,0.1,0.4,0.4,0.3,0.5,0.4,0.6,0.4,0.9,0.5,1,0.7,1);
});
__VIP_Vertical_Line = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,1);
});
__VIP_Right_Bracket_2 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,1,0.5,1,0.6,0.9,0.6,0.6,0.7,0.5,0.6,0.4,0.6,0.1,0.5,0,0.3,0);
});
__VIP_Tilde = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.2,0.5,0.4,0.6,0.7,0.4,0.9,0.5);
});
__VIP_Delete = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__LFont= new vip_sharp.VIPRuntime.StringRes(__VIP_Null,0.05,0.05,1.2);
__bmpSwitch= new vip_sharp.VIPRuntime.BitmapRes(vip_sharp.VIPRuntime.BitmapType.RGB, vip_sharp.VIPRuntime.BitmapFilter.Linear, vip_sharp.VIPRuntime.BitmapClamp.Clamp, @"Switch.bmp");
this.__uvDown= new vip_sharp.BipolarArray<__TVertex>(4) {new __TVertex {__dX = 0,__dY = 0},new __TVertex {__dX = 0,__dY = 1},new __TVertex {__dX = 0.5,__dY = 1},new __TVertex {__dX = 0.5,__dY = 0}};
this.__uvUp= new vip_sharp.BipolarArray<__TVertex>(4) {new __TVertex {__dX = 0.5,__dY = 0},new __TVertex {__dX = 0.5,__dY = 1},new __TVertex {__dX = 1,__dY = 1},new __TVertex {__dX = 1,__dY = 0}};
}
public vip_sharp.VIPRuntime.DisplayList __VIP_Null;
public vip_sharp.VIPRuntime.DisplayList __VIP_Smiley;
public vip_sharp.VIPRuntime.DisplayList __VIP_Smiley_Filled;
public vip_sharp.VIPRuntime.DisplayList __VIP_Heart;
public vip_sharp.VIPRuntime.DisplayList __VIP_Diamond;
public vip_sharp.VIPRuntime.DisplayList __VIP_Clover;
public vip_sharp.VIPRuntime.DisplayList __VIP_Ace;
public vip_sharp.VIPRuntime.DisplayList __VIP_Big_Dot;
public vip_sharp.VIPRuntime.DisplayList __VIP_Quad_Big_Dot;
public vip_sharp.VIPRuntime.DisplayList __VIP_Open_Circle;
public vip_sharp.VIPRuntime.DisplayList __VIP_Circle_Filled;
public vip_sharp.VIPRuntime.DisplayList __VIP_Male_Sign;
public vip_sharp.VIPRuntime.DisplayList __VIP_Female_Sign;
public vip_sharp.VIPRuntime.DisplayList __VIP_Note;
public vip_sharp.VIPRuntime.DisplayList __VIP_Double_Note;
public vip_sharp.VIPRuntime.DisplayList __VIP_Sun;
public vip_sharp.VIPRuntime.DisplayList __VIP_Triangle_Right;
public vip_sharp.VIPRuntime.DisplayList __VIP_Triangle_Left;
public vip_sharp.VIPRuntime.DisplayList __VIP_Arrow_Up_Down;
public vip_sharp.VIPRuntime.DisplayList __VIP_Double_Exclamation;
public vip_sharp.VIPRuntime.DisplayList __VIP_Pi_Sign;
public vip_sharp.VIPRuntime.DisplayList __VIP_Double_S;
public vip_sharp.VIPRuntime.DisplayList __VIP_Fat_Stripe;
public vip_sharp.VIPRuntime.DisplayList __VIP_Arrow_Up_Down_Bottom;
public vip_sharp.VIPRuntime.DisplayList __VIP_Up_Arrow;
public vip_sharp.VIPRuntime.DisplayList __VIP_Down_Arrow;
public vip_sharp.VIPRuntime.DisplayList __VIP_Right_Arrow;
public vip_sharp.VIPRuntime.DisplayList __VIP_Left_Arrow;
public vip_sharp.VIPRuntime.DisplayList __VIP_FS;
public vip_sharp.VIPRuntime.DisplayList __VIP_Double_Arrow;
public vip_sharp.VIPRuntime.DisplayList __VIP_Triangle_Up;
public vip_sharp.VIPRuntime.DisplayList __VIP_Triangle_Down;
public vip_sharp.VIPRuntime.DisplayList __VIP_Space;
public vip_sharp.VIPRuntime.DisplayList __VIP_Exlamation_Point;
public vip_sharp.VIPRuntime.DisplayList __VIP_Double_Quote;
public vip_sharp.VIPRuntime.DisplayList __VIP_Number_Sign;
public vip_sharp.VIPRuntime.DisplayList __VIP_Dollar_Sign;
public vip_sharp.VIPRuntime.DisplayList __VIP_Percent;
public vip_sharp.VIPRuntime.DisplayList __VIP_Ampersand;
public vip_sharp.VIPRuntime.DisplayList __VIP_Apostrophe;
public vip_sharp.VIPRuntime.DisplayList __VIP_Left_Parenthesis;
public vip_sharp.VIPRuntime.DisplayList __VIP_Right_Parenthesis;
public vip_sharp.VIPRuntime.DisplayList __VIP_Asterisk;
public vip_sharp.VIPRuntime.DisplayList __VIP_Plus_Sign;
public vip_sharp.VIPRuntime.DisplayList __VIP_Comma;
public vip_sharp.VIPRuntime.DisplayList __VIP_minus;
public vip_sharp.VIPRuntime.DisplayList __VIP_Period;
public vip_sharp.VIPRuntime.DisplayList __VIP_Slash;
public vip_sharp.VIPRuntime.DisplayList __VIP_nr_0;
public vip_sharp.VIPRuntime.DisplayList __VIP_nr_1;
public vip_sharp.VIPRuntime.DisplayList __VIP_nr_2;
public vip_sharp.VIPRuntime.DisplayList __VIP_nr_3;
public vip_sharp.VIPRuntime.DisplayList __VIP_nr_4;
public vip_sharp.VIPRuntime.DisplayList __VIP_nr_5;
public vip_sharp.VIPRuntime.DisplayList __VIP_nr_6;
public vip_sharp.VIPRuntime.DisplayList __VIP_nr_7;
public vip_sharp.VIPRuntime.DisplayList __VIP_nr_8;
public vip_sharp.VIPRuntime.DisplayList __VIP_nr_9;
public vip_sharp.VIPRuntime.DisplayList __VIP_Colon;
public vip_sharp.VIPRuntime.DisplayList __VIP_Semicolon;
public vip_sharp.VIPRuntime.DisplayList __VIP_Less_Than;
public vip_sharp.VIPRuntime.DisplayList __VIP_Equal_Sign;
public vip_sharp.VIPRuntime.DisplayList __VIP_Greater_Than;
public vip_sharp.VIPRuntime.DisplayList __VIP_Question_Mark;
public vip_sharp.VIPRuntime.DisplayList __VIP_AT_Symbol;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_A;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_B;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_C;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_D;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_E;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_F;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_G;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_H;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_I;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_J;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_K;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_L;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_M;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_N;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_O;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_P;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_Q;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_R;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_S;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_T;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_U;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_V;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_W;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_X;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_Y;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_Z;
public vip_sharp.VIPRuntime.DisplayList __VIP_Left_Square_Bracket;
public vip_sharp.VIPRuntime.DisplayList __VIP_Back_Slash;
public vip_sharp.VIPRuntime.DisplayList __VIP_Right_Square_Bracket;
public vip_sharp.VIPRuntime.DisplayList __VIP_Caret;
public vip_sharp.VIPRuntime.DisplayList __VIP_Underline;
public vip_sharp.VIPRuntime.DisplayList __VIP_Accent;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_la;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lb;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lc;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_ld;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_le;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lf;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lg;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lh;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_li;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lj;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lk;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_ll;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lm;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_ln;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lo;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lp;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lq;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lr;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_ls;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lt;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lu;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lv;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lw;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lx;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_ly;
public vip_sharp.VIPRuntime.DisplayList __VIP_lt_lz;
public vip_sharp.VIPRuntime.DisplayList __VIP_Left_Bracket_2;
public vip_sharp.VIPRuntime.DisplayList __VIP_Vertical_Line;
public vip_sharp.VIPRuntime.DisplayList __VIP_Right_Bracket_2;
public vip_sharp.VIPRuntime.DisplayList __VIP_Tilde;
public vip_sharp.VIPRuntime.DisplayList __VIP_Delete;
public vip_sharp.VIPRuntime.StringRes __LFont;
public vip_sharp.VIPRuntime.BitmapRes __bmpSwitch;
public class __TVertex { 
public double __dX;
public double __dY;
}
public vip_sharp.BipolarArray<__TVertex> __uvDown;
public vip_sharp.BipolarArray<__TVertex> __uvUp;
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
vip_sharp.VIPRuntime.Instance.HotSpot(1, this,0,0,0.2,0.3,vip_sharp.VIPRuntime.PositionRef.CU,ref __bSelDown,vip_sharp.VIPRuntime.HotSpotTrigger.Selected,vip_sharp.VIPRuntime.HotSpotType.Momentary,true,false,vip_sharp.VIPRuntime.HoverBox.Never);
vip_sharp.VIPRuntime.Instance.HotSpot(2, this,0,0,0.2,0.3,vip_sharp.VIPRuntime.PositionRef.CL,ref __bSelUp,vip_sharp.VIPRuntime.HotSpotTrigger.Selected,vip_sharp.VIPRuntime.HotSpotType.Momentary,true,false,vip_sharp.VIPRuntime.HoverBox.Never);
if(Convert.ToBoolean(__bSelUp)) {
{
__cOut.__bSel = true;
}
}
else {
if(Convert.ToBoolean(__bSelDown)) {
{
__cOut.__bSel = false;
}
}
}
if(Convert.ToBoolean(__cOut.__bSel)) {
{
vip_sharp.VIPRuntime.Instance.Bitmap(GlobalState.MainClass.__bmpSwitch, vip_sharp.VIPRuntime.BitmapBlend.Replace, 0,0,0.2,0.6,vip_sharp.VIPRuntime.PositionRef.CTR,GlobalState.MainClass.__uvUp);
}
}
else {
{
vip_sharp.VIPRuntime.Instance.Bitmap(GlobalState.MainClass.__bmpSwitch, vip_sharp.VIPRuntime.BitmapBlend.Replace, 0,0,0.2,0.6,vip_sharp.VIPRuntime.PositionRef.CTR,GlobalState.MainClass.__uvDown);
}
}
}
}
public __TwoPosSwitch __sw1 = new __TwoPosSwitch() { X = 0,Y = 0,s = 0.3};
public __TwoPosSwitch __sw2 = new __TwoPosSwitch() { X = 0,Y = 0.3,s = 0.3};
public __TwoPosSwitch __sw3 = new __TwoPosSwitch() { X = 0,Y = -0.3,s = 0.3};
public __TwoPosSwitch __sw4 = new __TwoPosSwitch() { X = 0.3,Y = 0,s = 0.3};
public __TwoPosSwitch __sw5 = new __TwoPosSwitch() { X = -0.3,Y = 0,s = 0.3};
public double __dZoom = 1;
public double __dZoomX = 0;
public double __dZoomY = 0;
public override void Run() {
double __dNewZoom = 0;
__dNewZoom = GlobalState.MainClass.__dZoom+(vip_sharp.VIPRuntime.Instance.VIPSystemClass.__fWheel/10);
if(Convert.ToBoolean(vip_sharp.VIPRuntime.Instance.VIPSystemClass.__fWheel!=0)) {
{
GlobalState.MainClass.__dZoomX = vip_sharp.VIPRuntime.Instance.VIPSystemClass.__fCursor_XPos/GlobalState.MainClass.__dZoom;
GlobalState.MainClass.__dZoomY = vip_sharp.VIPRuntime.Instance.VIPSystemClass.__fCursor_YPos/GlobalState.MainClass.__dZoom;
}
}
GlobalState.MainClass.__dZoom = __dNewZoom;
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Scale(GlobalState.MainClass.__dZoom);
vip_sharp.VIPRuntime.Instance.Translate(GlobalState.MainClass.__dZoomX*GlobalState.MainClass.__dZoom, GlobalState.MainClass.__dZoomY*GlobalState.MainClass.__dZoom);
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__sw1);
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__sw2);
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__sw3);
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__sw4);
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__sw5);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
vip_sharp.BipolarArray<char> __szValue= new vip_sharp.BipolarArray<char>(8);
double __tmp = 0;
__tmp = vip_sharp.VIPRuntime.Instance.VIPSystemClass.__fCursor_XPos/GlobalState.MainClass.__dZoom;
vip_sharp.VIPRuntime.Instance.Format(__szValue,"%.2f",__tmp);
vip_sharp.VIPRuntime.Instance.DrawString(-0.9,0.9,vip_sharp.VIPRuntime.PositionRef.LU,__szValue,0,GlobalState.MainClass.__LFont);
__tmp = vip_sharp.VIPRuntime.Instance.VIPSystemClass.__fCursor_YPos/GlobalState.MainClass.__dZoom;
vip_sharp.VIPRuntime.Instance.Format(__szValue,"%.2f",__tmp);
vip_sharp.VIPRuntime.Instance.DrawString(-0.9,0.8,vip_sharp.VIPRuntime.PositionRef.LU,__szValue,0,GlobalState.MainClass.__LFont);
}
}
