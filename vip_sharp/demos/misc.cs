using System;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass {
public MainClass() {
GlobalState.MainClass = this;
__VIP_Null = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineWidth(8);
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
__ARIAL_Null = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineWidth(10);
});
__ARIAL_Smiley = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.5,0.5,16,false);
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.7,0.05,6,false);
vip_sharp.VIPRuntime.Instance.Circle(0.7,0.7,0.05,6,false);
vip_sharp.VIPRuntime.Instance.ArcLine(0.5,0.5,0.3,90,270,4);
});
__ARIAL_Smiley_Filled = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ColorSave();
vip_sharp.VIPRuntime.Instance.Color(0,0,0);
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.5,0.5,16,false);
vip_sharp.VIPRuntime.Instance.Color(100,100,100);
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.7,0.05,6,false);
vip_sharp.VIPRuntime.Instance.Circle(0.7,0.7,0.05,6,false);
vip_sharp.VIPRuntime.Instance.ArcLine(0.5,0.5,0.3,90,270,4);
vip_sharp.VIPRuntime.Instance.ColorRestore();
});
__ARIAL_Heart = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Polygon(0.5,0,0.1,0.4,0,0.6,0,0.8,0.2,1,0.3,1,0.4,0.9,0.5,0.7);
vip_sharp.VIPRuntime.Instance.Polygon(0.5,0.7,0.4,0.9,0.3,1,0.2,1,0,0.8,0,0.6,0.1,0.4,0.5,0);
});
__ARIAL_Diamond = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Quad(0.5,1,1,0.5,0.5,0,0,0.5);
});
__ARIAL_Clover = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Polygon(0.5,0.5,0.3,0.8,0.4,1,0.6,1,0.7,0.8);
vip_sharp.VIPRuntime.Instance.Polygon(0.5,0.5,0.4,0.3,0.3,0.2,0.1,0.2,0,0.3,0,0.4,0.2,0.5);
vip_sharp.VIPRuntime.Instance.Polygon(0.2,0.5,0,0.4,0,0.3,0.1,0.2,0.3,0.2,0.4,0.3,0.5,0.5);
vip_sharp.VIPRuntime.Instance.Triangle(0.4,0,0.5,0.3,0.6,0);
});
__ARIAL_Ace = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Polygon(0.5,1,0.5,0.5,0.4,0.3,0.3,0.2,0.2,0.2,0,0.4,0,0.6);
vip_sharp.VIPRuntime.Instance.Polygon(0,0.6,0,0.4,0.2,0.2,0.3,0.2,0.4,0.3,0.5,0.5,0.5,1);
vip_sharp.VIPRuntime.Instance.Triangle(0.4,0,0.5,0.3,0.6,0);
});
__ARIAL_Big_Dot = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__ARIAL_Quad_Big_Dot = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__ARIAL_Open_Circle = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__ARIAL_Circle_Filled = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__ARIAL_Male_Sign = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.3,0.3,12,false);
vip_sharp.VIPRuntime.Instance.Line(0.627,0.627,1,1);
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,1,1,1,1,0.7);
});
__ARIAL_Female_Sign = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.7,0.3,12,false);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.4);
});
__ARIAL_Note = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Circle(0.4,0.1,0.1,6,false);
vip_sharp.VIPRuntime.Instance.LineStrip(0.5,1,0.5,1,0.7,0.8,0.7,0.6,0.6,0.4);
});
__ARIAL_Double_Note = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.2,0.1,6,false);
vip_sharp.VIPRuntime.Instance.Circle(0.8,0.1,0.1,6,false);
vip_sharp.VIPRuntime.Instance.Line(0.3,0.3,0.3,1,0.9,0.1,0.9,0.8);
vip_sharp.VIPRuntime.Instance.Quad(0.3,0.9,0.3,1,0.9,0.8,0.9,0.7);
});
__ARIAL_Sun = new vip_sharp.VIPRuntime.DisplayList(() => {
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
__ARIAL_Triangle_Right = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0.9,0.5,0.1,0.9,0.1,0.1);
});
__ARIAL_Triangle_Left = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0.1,0.5,0.9,0.9,0.9,0.1);
});
__ARIAL_Arrow_Up_Down = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__ARIAL_Double_Exclamation = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__ARIAL_Pi_Sign = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__ARIAL_Double_S = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__ARIAL_Fat_Stripe = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__ARIAL_Arrow_Up_Down_Bottom = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0.4,0.7,0.5,1,0.6,0.7);
vip_sharp.VIPRuntime.Instance.Triangle(0.5,0,0.4,0.3,0.6,0.3);
vip_sharp.VIPRuntime.Instance.Line(0.3,0,0.7,0,0.5,0.4,0.5,0.7);
});
__ARIAL_Up_Arrow = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0.4,0.7,0.5,1,0.6,0.7);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.7);
});
__ARIAL_Down_Arrow = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0.5,0,0.4,0.3,0.6,0.3);
vip_sharp.VIPRuntime.Instance.Line(0.5,1,0.5,0.3);
});
__ARIAL_Right_Arrow = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(1,0.5,0.7,0.4,0.7,0.6);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,0.7,0.5);
});
__ARIAL_Left_Arrow = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0,0.5,0.3,0.6,0.3,0.4);
vip_sharp.VIPRuntime.Instance.Line(0.3,0.5,1,0.5);
});
__ARIAL_FS = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__ARIAL_Double_Arrow = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__ARIAL_Triangle_Up = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0.5,0.9,0.9,0.1,0.1,0.1);
});
__ARIAL_Triangle_Down = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0.1,0.9,0.9,0.9,0.5,0.1);
});
__ARIAL_Space = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__ARIAL_Exlamation_Point = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Triangle(0.5,0.3,0.4,1,0.6,1);
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.1,0.1,6,true);
});
__ARIAL_Double_Quote = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,0.9,0.4,0.9,0.4,0.8,0.3,0.8,0.3,0.9,0.4,1);
vip_sharp.VIPRuntime.Instance.LineStrip(0.6,0.9,0.7,0.9,0.7,0.8,0.6,0.8,0.6,0.9,0.7,1);
});
__ARIAL_Number_Sign = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.25,0,0.35,1,0.65,0,0.75,1,0,0.3,0.95,0.3,0.05,0.7,1,0.7);
});
__ARIAL_Dollar_Sign = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.1,0.2,0.2,0.1,0.8,0.1,0.9,0.2,0.9,0.4,0.8,0.5,0.2,0.5,0.1,0.6,0.1,0.8,0.2,0.9,0.8,0.9,0.9,0.8);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,1);
});
__ARIAL_Percent = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.7,0.1,6,false);
vip_sharp.VIPRuntime.Instance.Circle(0.7,0.3,0.1,6,false);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.1,0.8,0.9);
});
__ARIAL_Ampersand = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,0,0.2,0.6,0.2,0.7,0.3,0.8,0.5,0.8,0.6,0.7,0.6,0.6,0.1,0.3,0.1,0.1,0.2,0,0.5,0,0.7,0.3);
});
__ARIAL_Apostrophe = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,0.9,0.5,0.9,0.5,0.8,0.4,0.8,0.4,0.9,0.5,1);
});
__ARIAL_Left_Parenthesis = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.6,0,0.5,0,0.4,0.2,0.4,0.8,0.5,1,0.6,1);
});
__ARIAL_Right_Parenthesis = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,0,0.5,0,0.6,0.2,0.6,0.8,0.5,1,0.4,1);
});
__ARIAL_Asterisk = new vip_sharp.VIPRuntime.DisplayList(() => {
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
__ARIAL_Plus_Sign = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,0.4,0.8,0.4);
vip_sharp.VIPRuntime.Instance.Line(0.4,0.1,0.4,0.7);
});
__ARIAL_Comma = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,0,0.2,0,0.2,0.1,0.3,0.1,0.3,0,0.2,-0.1);
});
__ARIAL_minus = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.2,0.5,0.8,0.5);
});
__ARIAL_Period = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.2,0.1,0.3,0.1,0.3,0,0.2,0);
});
__ARIAL_Slash = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.2,0,0.8,1);
});
__ARIAL_nr_0 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0,0,1,1,1,1,0);
});
__ARIAL_nr_1 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,1,0.5,1,0.5,0);
});
__ARIAL_nr_2 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,1,1,1,0.5,0,0.5,0,0,1,0);
});
__ARIAL_nr_3 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,1,1,1,0,0,0);
vip_sharp.VIPRuntime.Instance.Line(0.3,0.5,1,0.5);
});
__ARIAL_nr_4 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0,0.5,1,0.5);
vip_sharp.VIPRuntime.Instance.Line(1,0,1,1);
});
__ARIAL_nr_5 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,1,0,1,0.5,0,0.5,0,1,1,1);
});
__ARIAL_nr_6 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,1,0.5,1,0,0,0,0,1,1,1);
});
__ARIAL_nr_7 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,1,1,1,0);
});
__ARIAL_nr_8 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0,0,1,1,1,1,0);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,1,0.5);
});
__ARIAL_nr_9 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.5,0,0.5,0,1,1,1,1,0,0,0);
});
__ARIAL_Colon = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.4,0.7,0.4,0.8,0.5,0.8,0.5,0.7);
vip_sharp.VIPRuntime.Instance.ClosedLine(0.4,0.2,0.4,0.3,0.5,0.3,0.5,0.2);
});
__ARIAL_Semicolon = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.4,0.7,0.4,0.8,0.5,0.8,0.5,0.7);
vip_sharp.VIPRuntime.Instance.ClosedLine(0.4,0.2,0.4,0.3,0.5,0.3,0.5,0.2);
vip_sharp.VIPRuntime.Instance.Line(0.5,0.2,0.4,0.1);
});
__ARIAL_Less_Than = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.9,0.1,0.1,0.5,0.9,0.9);
});
__ARIAL_Equal_Sign = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.1,0.4,0.9,0.4,0.1,0.6,0.9,0.6);
});
__ARIAL_Greater_Than = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.1,0.1,0.9,0.5,0.1,0.9);
});
__ARIAL_Question_Mark = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.8,0,1,1,1,1,0.6,0.5,0.6,0.5,0.3);
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.1,0.1,6,false);
});
__ARIAL_AT_Symbol = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,0.4,0.6,0.3,0.3,0.3,0.3,0.6,0.4,0.7,0.7,0.7);
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,0.8,0.7,0.3,0.8,0.3,1,0.5,1,0.8,0.8,1,0.2,1,0,0.8,0,0.2,0.2,0,0.8,0,1,0.2);
});
__ARIAL_lt_A = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0.5,1,1,0);
vip_sharp.VIPRuntime.Instance.Line(0.15,0.3,0.85,0.3);
});
__ARIAL_lt_B = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0,0,1,0.7,1,0.9,0.9,0.9,0.6,0.7,0.5,1,0.3,1,0.1,0.8,0);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,0.7,0.5);
});
__ARIAL_lt_C = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.2,0.8,0,0.2,0,0,0.2,0,0.8,0.2,1,0.8,1,1,0.8);
});
__ARIAL_lt_D = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0,0,1,0.7,1,1,0.7,1,0.2,0.8,0);
});
__ARIAL_lt_E = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0,0,0,0,1,1,1);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,1,0.5);
});
__ARIAL_lt_F = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,1,1);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,0.9,0.5);
});
__ARIAL_lt_G = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.5,0.5,1,0.5,1,0.2,0.8,0,0.2,0,0,0.2,0,0.8,0.2,1,0.8,1,1,0.8);
});
__ARIAL_lt_H = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,1,0.5);
vip_sharp.VIPRuntime.Instance.Line(1,0,1,1);
});
__ARIAL_lt_I = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,1);
});
__ARIAL_lt_J = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,1,1,0.25,0.875,0.125,0.625,0,0.375,0,0.125,0.125,0,0.25,0,0.375);
});
__ARIAL_lt_K = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.5,1,0);
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.5,1,1);
});
__ARIAL_lt_L = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0,0,1,0);
});
__ARIAL_lt_M = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,0.5,0.5,1,1,1,0);
});
__ARIAL_lt_N = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,1,0,1,1);
});
__ARIAL_lt_O = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.2,0,0,0.2,0,0.8,0.2,1,0.8,1,1,0.8,1,0.2,0.8,0);
});
__ARIAL_lt_P = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,0.8,1,1,0.8,1,0.6,0.8,0.4,0,0.4);
});
__ARIAL_lt_Q = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.2,0,0,0.2,0,0.8,0.2,1,0.8,1,1,0.8,1,0.2,0.8,0);
vip_sharp.VIPRuntime.Instance.Line(0.7,0.3,1,0);
});
__ARIAL_lt_R = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,0.8,1,1,0.8,1,0.6,0.8,0.4,0,0.4);
vip_sharp.VIPRuntime.Instance.Line(0.8,0.4,1,0);
});
__ARIAL_lt_S = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.1,0.2,0,0.8,0,1,0.2,1,0.4,0.9,0.5,0.1,0.5,0,0.6,0,0.8,0.2,1,0.8,1,1,0.9);
});
__ARIAL_lt_T = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,1,1,1);
vip_sharp.VIPRuntime.Instance.Line(0.5,1,0.5,0);
});
__ARIAL_lt_U = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0,0.2,0.2,0,0.8,0,1,0.2,1,1);
});
__ARIAL_lt_V = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0.5,0,1,1);
});
__ARIAL_lt_W = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0.2,0,0.5,1,0.8,0,1,1);
});
__ARIAL_lt_X = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,0,1,1);
vip_sharp.VIPRuntime.Instance.Line(0,1,1,0);
});
__ARIAL_lt_Y = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0.5,0.5,1,1);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.5);
});
__ARIAL_lt_Z = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0,0,0,1,1,0,1);
});
__ARIAL_Left_Square_Bracket = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.8,0,0.3,0,0.3,1,0.8,1);
});
__ARIAL_Back_Slash = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.2,1,0.8,0);
});
__ARIAL_Right_Square_Bracket = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.2,1,0.7,1,0.7,0,0.2,0);
});
__ARIAL_Caret = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,0.8,0.5,1,0.7,0.8);
});
__ARIAL_Underline = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,0,1,0);
});
__ARIAL_Accent = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,0.9,0.5,0.9,0.5,0.8,0.4,0.8,0.4,0.9,0.5,1);
});
__ARIAL_lt_la = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.4,0.2,0.6,0.8,0.6,1,0.4,1,0);
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0.2,0,0,0.1,0,0.2,0.2,0.3,0.8,0.3,1,0.2);
});
__ARIAL_lt_lb = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.1,0.8,0,0.2,0,0,0.1);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
});
__ARIAL_lt_lc = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5);
});
__ARIAL_lt_ld = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5);
vip_sharp.VIPRuntime.Instance.Line(1,0,1,1);
});
__ARIAL_lt_le = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.3,0,0.3);
});
__ARIAL_lt_lf = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,0,0.4,0.8,0.6,1,0.8,1);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.5,0.6,0.5);
});
__ARIAL_lt_lg = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5);
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.6,1,-0.2,0.8,-0.4,0.2,-0.4,0,-0.3);
});
__ARIAL_lt_lh = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0);
});
__ARIAL_lt_li = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.6,0.5,0.7,0.5,0.8);
});
__ARIAL_lt_lj = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,-0.4,0.5,-0.4,0.7,-0.3,0.7,0.6);
vip_sharp.VIPRuntime.Instance.Line(0.7,0.7,0.7,0.8);
});
__ARIAL_lt_lk = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
vip_sharp.VIPRuntime.Instance.Line(0,0.3,1,0.6);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.35,1,0);
});
__ARIAL_lt_ll = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,1);
});
__ARIAL_lt_lm = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.1,0.6,0.4,0.6,0.5,0.5,0.6,0.6,0.9,0.6,1,0.5,1,0);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,0.6);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.5);
});
__ARIAL_lt_ln = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.9,0.6,1,0.5,1,0);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,0.6);
});
__ARIAL_lt_lo = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.1,0.8,0,0.2,0);
});
__ARIAL_lt_lp = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.1,0.8,0,0.2,0,0,0.1);
vip_sharp.VIPRuntime.Instance.Line(0,0.6,0,-0.4);
});
__ARIAL_lt_lq = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.1,0.8,0,0.2,0);
vip_sharp.VIPRuntime.Instance.Line(0.7,0.2,1,0);
});
__ARIAL_lt_lr = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.9,0.6,1,0.5);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,0.6);
});
__ARIAL_lt_ls = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.1,0.2,0,0.9,0,1,0.1,1,0.2,0.8,0.3,0.2,0.3,0,0.4,0,0.5,0.1,0.6,0.8,0.6,1,0.5);
});
__ARIAL_lt_lt = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,1,0.4,0.1,0.5,0,0.6,0);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.7,0.6,0.7);
});
__ARIAL_lt_lu = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.6,0,0.1,0.2,0,0.8,0,1,0.1);
vip_sharp.VIPRuntime.Instance.Line(1,0.6,1,0);
});
__ARIAL_lt_lv = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.6,0.5,0,1,0.6);
});
__ARIAL_lt_lw = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.6,0.2,0,0.5,0.3,0.8,0,1,0.6);
});
__ARIAL_lt_lx = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0,0,1,1,0,1,1,0);
});
__ARIAL_lt_ly = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,-0.4,0.5,0,1,0.6);
vip_sharp.VIPRuntime.Instance.Line(0,0.6,0.5,0);
});
__ARIAL_lt_lz = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.6,1,0.6,0,0,1,0);
});
__ARIAL_Left_Bracket_2 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,0,0.5,0,0.4,0.1,0.4,0.4,0.3,0.5,0.4,0.6,0.4,0.9,0.5,1,0.7,1);
});
__ARIAL_Vertical_Line = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,1);
});
__ARIAL_Right_Bracket_2 = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,1,0.5,1,0.6,0.9,0.6,0.6,0.7,0.5,0.6,0.4,0.6,0.1,0.5,0,0.3,0);
});
__ARIAL_Tilde = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.2,0.5,0.4,0.6,0.7,0.4,0.9,0.5);
});
__ARIAL_Delete = new vip_sharp.VIPRuntime.DisplayList(() => {
});
__STRIPE= new vip_sharp.VIPRuntime.BitmapRes(vip_sharp.VIPRuntime.BitmapType.RGB, vip_sharp.VIPRuntime.BitmapFilter.Linear, vip_sharp.VIPRuntime.BitmapClamp.Clamp, @"stripe.bmp");
__SWITCH= new vip_sharp.VIPRuntime.BitmapRes(vip_sharp.VIPRuntime.BitmapType.RGB, vip_sharp.VIPRuntime.BitmapFilter.Linear, vip_sharp.VIPRuntime.BitmapClamp.Clamp, @"sw.png");
__KNOB= new vip_sharp.VIPRuntime.BitmapRes(vip_sharp.VIPRuntime.BitmapType.RGB, vip_sharp.VIPRuntime.BitmapFilter.Linear, vip_sharp.VIPRuntime.BitmapClamp.Clamp, @"knob.png");
__KNOBLIST = new vip_sharp.VIPRuntime.DisplayList(() => {
vip_sharp.VIPRuntime.Instance.Bitmap(GlobalState.MainClass.__KNOB, vip_sharp.VIPRuntime.BitmapBlend.Replace, 0,0,4,4,vip_sharp.VIPRuntime.PositionRef.CC);
});
this.__UpUV= new vip_sharp.BipolarArray<__TVector>(4) {new __TVector {__X = 0,__Y = 1},new __TVector {__X = 0,__Y = 0},new __TVector {__X = 0.33,__Y = 0},new __TVector {__X = 0.33,__Y = 1}};
this.__DownUV= new vip_sharp.BipolarArray<__TVector>(4) {new __TVector {__X = 0.66,__Y = 1},new __TVector {__X = 0.66,__Y = 0},new __TVector {__X = 1,__Y = 0},new __TVector {__X = 1,__Y = 1}};
this.__swstate = false;
this.__cnt = 0;
this.__knobvar = 0;
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
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Null;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Smiley;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Smiley_Filled;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Heart;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Diamond;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Clover;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Ace;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Big_Dot;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Quad_Big_Dot;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Open_Circle;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Circle_Filled;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Male_Sign;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Female_Sign;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Note;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Double_Note;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Sun;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Triangle_Right;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Triangle_Left;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Arrow_Up_Down;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Double_Exclamation;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Pi_Sign;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Double_S;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Fat_Stripe;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Arrow_Up_Down_Bottom;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Up_Arrow;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Down_Arrow;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Right_Arrow;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Left_Arrow;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_FS;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Double_Arrow;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Triangle_Up;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Triangle_Down;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Space;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Exlamation_Point;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Double_Quote;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Number_Sign;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Dollar_Sign;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Percent;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Ampersand;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Apostrophe;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Left_Parenthesis;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Right_Parenthesis;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Asterisk;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Plus_Sign;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Comma;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_minus;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Period;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Slash;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_nr_0;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_nr_1;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_nr_2;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_nr_3;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_nr_4;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_nr_5;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_nr_6;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_nr_7;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_nr_8;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_nr_9;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Colon;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Semicolon;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Less_Than;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Equal_Sign;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Greater_Than;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Question_Mark;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_AT_Symbol;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_A;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_B;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_C;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_D;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_E;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_F;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_G;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_H;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_I;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_J;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_K;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_L;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_M;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_N;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_O;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_P;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_Q;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_R;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_S;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_T;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_U;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_V;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_W;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_X;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_Y;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_Z;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Left_Square_Bracket;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Back_Slash;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Right_Square_Bracket;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Caret;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Underline;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Accent;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_la;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lb;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lc;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_ld;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_le;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lf;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lg;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lh;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_li;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lj;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lk;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_ll;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lm;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_ln;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lo;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lp;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lq;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lr;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_ls;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lt;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lu;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lv;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lw;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lx;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_ly;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_lt_lz;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Left_Bracket_2;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Vertical_Line;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Right_Bracket_2;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Tilde;
public vip_sharp.VIPRuntime.DisplayList __ARIAL_Delete;
public vip_sharp.VIPRuntime.BitmapRes __STRIPE;
public vip_sharp.VIPRuntime.BitmapRes __SWITCH;
public vip_sharp.VIPRuntime.BitmapRes __KNOB;
public vip_sharp.VIPRuntime.DisplayList __KNOBLIST;
public class __TVector { 
public double __X;
public double __Y;
}
public vip_sharp.BipolarArray<__TVector> __UpUV;
public vip_sharp.BipolarArray<__TVector> __DownUV;
public bool __swstate;
public double __cnt;
public double __knobvar;
public void Run() {
vip_sharp.BipolarArray<char> __sData2= new vip_sharp.BipolarArray<char>(15,"Werkt Het ?");
vip_sharp.BipolarArray<char> __sData= new vip_sharp.BipolarArray<char>("\x1 Ja, het Werkt");
vip_sharp.BipolarArray<char> __tmpbuffer= new vip_sharp.BipolarArray<char>(15);
vip_sharp.VIPRuntime.Instance.Color(23);
vip_sharp.VIPRuntime.Instance.DrawString(0,0,vip_sharp.VIPRuntime.PositionRef.CC,__sData,0,__VIP_Null,1,1,1.2);
vip_sharp.VIPRuntime.Instance.DrawString(0,2,vip_sharp.VIPRuntime.PositionRef.CC,__sData2,0,__VIP_Null,1,1,1.2);
vip_sharp.VIPRuntime.Instance.Color(5);
vip_sharp.VIPRuntime.Instance.DrawString(-3,6,vip_sharp.VIPRuntime.PositionRef.LC,"multiline test 2 | worked yay!",0,__ARIAL_Null,0.3,0.6,1.2);
vip_sharp.VIPRuntime.Instance.RotaryKnob(1, this,11,-11,2,ref GlobalState.MainClass.__knobvar,-20,20,-50,50,vip_sharp.VIPRuntime.HoverBox.Hover,0,__KNOBLIST);
vip_sharp.VIPRuntime.Instance.Format(__tmpbuffer,"%.02f",GlobalState.MainClass.__knobvar);
vip_sharp.VIPRuntime.Instance.DrawString(11,-8,vip_sharp.VIPRuntime.PositionRef.CC,__tmpbuffer,0,__ARIAL_Null,0.4,0.7,1.2);
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Rotate(-25);
bool __up = false;
vip_sharp.VIPRuntime.Instance.HotSpot(2, this,9,9,5,5,vip_sharp.VIPRuntime.PositionRef.CL,ref __up,vip_sharp.VIPRuntime.HotSpotTrigger.Selected,vip_sharp.VIPRuntime.HotSpotType.Momentary,true,false,vip_sharp.VIPRuntime.HoverBox.Hover);
if(Convert.ToBoolean(__up)) {
GlobalState.MainClass.__swstate = true;
}
bool __down = false;
vip_sharp.VIPRuntime.Instance.HotSpot(3, this,9,9,5,5,vip_sharp.VIPRuntime.PositionRef.CU,ref __down,vip_sharp.VIPRuntime.HotSpotTrigger.Selected,vip_sharp.VIPRuntime.HotSpotType.Momentary,true,false,vip_sharp.VIPRuntime.HoverBox.Hover);
if(Convert.ToBoolean(__down)) {
GlobalState.MainClass.__swstate = false;
}
if(Convert.ToBoolean(GlobalState.MainClass.__swstate)) {
vip_sharp.VIPRuntime.Instance.Bitmap(GlobalState.MainClass.__SWITCH, vip_sharp.VIPRuntime.BitmapBlend.Replace, 9,9,5,5,vip_sharp.VIPRuntime.PositionRef.CL,GlobalState.MainClass.__UpUV);
vip_sharp.VIPRuntime.Instance.Color(6);
vip_sharp.VIPRuntime.Instance.DrawString(6,9,vip_sharp.VIPRuntime.PositionRef.RC,"State:  ON",0,__ARIAL_Null,0.4,0.7,1.2);
}
else {
vip_sharp.VIPRuntime.Instance.Bitmap(GlobalState.MainClass.__SWITCH, vip_sharp.VIPRuntime.BitmapBlend.Replace, 9,9,5,5,vip_sharp.VIPRuntime.PositionRef.CU,GlobalState.MainClass.__DownUV);
vip_sharp.VIPRuntime.Instance.Color(5);
vip_sharp.VIPRuntime.Instance.DrawString(6,9,vip_sharp.VIPRuntime.PositionRef.RC,"State: OFF",0,__ARIAL_Null,0.4,0.7,1.2);
}
vip_sharp.VIPRuntime.Instance.MatrixRestore();
vip_sharp.VIPRuntime.Instance.Color(4);
bool __b = false;
vip_sharp.VIPRuntime.Instance.HotSpot(4, this,0,-3,3,3,vip_sharp.VIPRuntime.PositionRef.CC,ref __b,vip_sharp.VIPRuntime.HotSpotTrigger.SelectEdge,vip_sharp.VIPRuntime.HotSpotType.Momentary,true,false,vip_sharp.VIPRuntime.HoverBox.Always,GlobalState.MainClass.__STRIPE);
if(Convert.ToBoolean(__b)) {
GlobalState.MainClass.__cnt = GlobalState.MainClass.__cnt+0.15;
}
vip_sharp.VIPRuntime.Instance.Format(__tmpbuffer,"cnt: %.02f",GlobalState.MainClass.__cnt);
vip_sharp.VIPRuntime.Instance.DrawString(0,-5,vip_sharp.VIPRuntime.PositionRef.LC,__tmpbuffer,0,__ARIAL_Null,0.4,0.7,1.2);
vip_sharp.VIPRuntime.Instance.Translate(2, 2);
vip_sharp.VIPRuntime.Instance.Rotate(50);
vip_sharp.VIPRuntime.Instance.Scale(4);
vip_sharp.VIPRuntime.Instance.HotSpot(5, this,0,-3,1,1,vip_sharp.VIPRuntime.PositionRef.CC,ref __b,vip_sharp.VIPRuntime.HotSpotTrigger.Selected,vip_sharp.VIPRuntime.HotSpotType.Momentary,true,false,vip_sharp.VIPRuntime.HoverBox.Always,GlobalState.MainClass.__STRIPE);
if(Convert.ToBoolean(__b)) {
vip_sharp.VIPRuntime.Instance.DrawString(1,-3,vip_sharp.VIPRuntime.PositionRef.LC,"WOOHOO",0,__ARIAL_Null,0.4,0.7,1.2);
}
}
}
