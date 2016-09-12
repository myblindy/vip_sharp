using System;
using System.Linq;
using System.Collections.Generic;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
__vip_null = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__vip_smiley = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.5,0.5,16,false);
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.7,0.05,6,false);
vip_sharp.VIPRuntime.Instance.Circle(0.7,0.7,0.05,6,false);
vip_sharp.VIPRuntime.Instance.ArcLine(0.5,0.5,0.3,90,270,4);
}, false);
__vip_smiley_filled = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ColorSave();
vip_sharp.VIPRuntime.Instance.Color(0,0,0);
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.5,0.5,16,false);
vip_sharp.VIPRuntime.Instance.Color(100,100,100);
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.7,0.05,6,false);
vip_sharp.VIPRuntime.Instance.Circle(0.7,0.7,0.05,6,false);
vip_sharp.VIPRuntime.Instance.ArcLine(0.5,0.5,0.3,90,270,4);
vip_sharp.VIPRuntime.Instance.ColorRestore();
}, false);
__vip_heart = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Polygon(0.5,0,0.1,0.4,0,0.6,0,0.8,0.2,1,0.3,1,0.4,0.9,0.5,0.7);
vip_sharp.VIPRuntime.Instance.Polygon(0.5,0.7,0.4,0.9,0.3,1,0.2,1,0,0.8,0,0.6,0.1,0.4,0.5,0);
}, false);
__vip_diamond = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Quad(0.5,1,1,0.5,0.5,0,0,0.5);
}, false);
__vip_clover = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Polygon(0.5,0.5,0.3,0.8,0.4,1,0.6,1,0.7,0.8);
vip_sharp.VIPRuntime.Instance.Polygon(0.5,0.5,0.4,0.3,0.3,0.2,0.1,0.2,0,0.3,0,0.4,0.2,0.5);
vip_sharp.VIPRuntime.Instance.Polygon(0.2,0.5,0,0.4,0,0.3,0.1,0.2,0.3,0.2,0.4,0.3,0.5,0.5);
vip_sharp.VIPRuntime.Instance.Triangle(0.4,0,0.5,0.3,0.6,0);
}, false);
__vip_ace = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Polygon(0.5,1,0.5,0.5,0.4,0.3,0.3,0.2,0.2,0.2,0,0.4,0,0.6);
vip_sharp.VIPRuntime.Instance.Polygon(0,0.6,0,0.4,0.2,0.2,0.3,0.2,0.4,0.3,0.5,0.5,0.5,1);
vip_sharp.VIPRuntime.Instance.Triangle(0.4,0,0.5,0.3,0.6,0);
}, false);
__vip_big_dot = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__vip_quad_big_dot = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__vip_open_circle = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__vip_circle_filled = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__vip_male_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.3,0.3,12,false);
vip_sharp.VIPRuntime.Instance.Line(0.627,0.627,1,1);
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,1,1,1,1,0.7);
}, false);
__vip_female_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.7,0.3,12,false);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.4);
}, false);
__vip_note = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Circle(0.4,0.1,0.1,6,false);
vip_sharp.VIPRuntime.Instance.LineStrip(0.5,1,0.5,1,0.7,0.8,0.7,0.6,0.6,0.4);
}, false);
__vip_double_note = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.2,0.1,6,false);
vip_sharp.VIPRuntime.Instance.Circle(0.8,0.1,0.1,6,false);
vip_sharp.VIPRuntime.Instance.Line(0.3,0.3,0.3,1,0.9,0.1,0.9,0.8);
vip_sharp.VIPRuntime.Instance.Quad(0.3,0.9,0.3,1,0.9,0.8,0.9,0.7);
}, false);
__vip_sun = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
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
}, false);
__vip_triangle_right = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0.9,0.5,0.1,0.9,0.1,0.1);
}, false);
__vip_triangle_left = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0.1,0.5,0.9,0.9,0.9,0.1);
}, false);
__vip_arrow_up_down = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__vip_double_exclamation = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__vip_pi_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__vip_double_s = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__vip_fat_stripe = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__vip_arrow_up_down_bottom = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0.4,0.7,0.5,1,0.6,0.7);
vip_sharp.VIPRuntime.Instance.Triangle(0.5,0,0.4,0.3,0.6,0.3);
vip_sharp.VIPRuntime.Instance.Line(0.3,0,0.7,0,0.5,0.4,0.5,0.7);
}, false);
__vip_up_arrow = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0.4,0.7,0.5,1,0.6,0.7);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.7);
}, false);
__vip_down_arrow = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0.5,0,0.4,0.3,0.6,0.3);
vip_sharp.VIPRuntime.Instance.Line(0.5,1,0.5,0.3);
}, false);
__vip_right_arrow = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(1,0.5,0.7,0.4,0.7,0.6);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,0.7,0.5);
}, false);
__vip_left_arrow = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0,0.5,0.3,0.6,0.3,0.4);
vip_sharp.VIPRuntime.Instance.Line(0.3,0.5,1,0.5);
}, false);
__vip_fs = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__vip_double_arrow = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__vip_triangle_up = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0.5,0.9,0.9,0.1,0.1,0.1);
}, false);
__vip_triangle_down = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0.1,0.9,0.9,0.9,0.5,0.1);
}, false);
__vip_space = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__vip_exlamation_point = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0.5,0.3,0.4,1,0.6,1);
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.1,0.1,6,true);
}, false);
__vip_double_quote = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,0.9,0.4,0.9,0.4,0.8,0.3,0.8,0.3,0.9,0.4,1);
vip_sharp.VIPRuntime.Instance.LineStrip(0.6,0.9,0.7,0.9,0.7,0.8,0.6,0.8,0.6,0.9,0.7,1);
}, false);
__vip_number_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.25,0,0.35,1,0.65,0,0.75,1,0,0.3,0.95,0.3,0.05,0.7,1,0.7);
}, false);
__vip_dollar_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.1,0.2,0.2,0.1,0.8,0.1,0.9,0.2,0.9,0.4,0.8,0.5,0.2,0.5,0.1,0.6,0.1,0.8,0.2,0.9,0.8,0.9,0.9,0.8);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,1);
}, false);
__vip_percent = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.7,0.1,6,false);
vip_sharp.VIPRuntime.Instance.Circle(0.7,0.3,0.1,6,false);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.1,0.8,0.9);
}, false);
__vip_ampersand = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,0,0.2,0.6,0.2,0.7,0.3,0.8,0.5,0.8,0.6,0.7,0.6,0.6,0.1,0.3,0.1,0.1,0.2,0,0.5,0,0.7,0.3);
}, false);
__vip_apostrophe = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,0.9,0.5,0.9,0.5,0.8,0.4,0.8,0.4,0.9,0.5,1);
}, false);
__vip_left_parenthesis = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.6,0,0.5,0,0.4,0.2,0.4,0.8,0.5,1,0.6,1);
}, false);
__vip_right_parenthesis = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,0,0.5,0,0.6,0.2,0.6,0.8,0.5,1,0.4,1);
}, false);
__vip_asterisk = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
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
}, false);
__vip_plus_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,0.4,0.8,0.4);
vip_sharp.VIPRuntime.Instance.Line(0.4,0.1,0.4,0.7);
}, false);
__vip_comma = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,0,0.2,0,0.2,0.1,0.3,0.1,0.3,0,0.2,-0.1);
}, false);
__vip_minus = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.2,0.5,0.8,0.5);
}, false);
__vip_period = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.2,0.1,0.3,0.1,0.3,0,0.2,0);
}, false);
__vip_slash = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.2,0,0.8,1);
}, false);
__vip_nr_0 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0,0,1,1,1,1,0);
}, false);
__vip_nr_1 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,1,0.5,1,0.5,0);
}, false);
__vip_nr_2 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,1,1,1,0.5,0,0.5,0,0,1,0);
}, false);
__vip_nr_3 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,1,1,1,0,0,0);
vip_sharp.VIPRuntime.Instance.Line(0.3,0.5,1,0.5);
}, false);
__vip_nr_4 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0,0.5,1,0.5);
vip_sharp.VIPRuntime.Instance.Line(1,0,1,1);
}, false);
__vip_nr_5 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,1,0,1,0.5,0,0.5,0,1,1,1);
}, false);
__vip_nr_6 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,1,0.5,1,0,0,0,0,1,1,1);
}, false);
__vip_nr_7 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,1,1,1,0);
}, false);
__vip_nr_8 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0,0,1,1,1,1,0);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,1,0.5);
}, false);
__vip_nr_9 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.5,0,0.5,0,1,1,1,1,0,0,0);
}, false);
__vip_colon = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.4,0.7,0.4,0.8,0.5,0.8,0.5,0.7);
vip_sharp.VIPRuntime.Instance.ClosedLine(0.4,0.2,0.4,0.3,0.5,0.3,0.5,0.2);
}, false);
__vip_semicolon = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.4,0.7,0.4,0.8,0.5,0.8,0.5,0.7);
vip_sharp.VIPRuntime.Instance.ClosedLine(0.4,0.2,0.4,0.3,0.5,0.3,0.5,0.2);
vip_sharp.VIPRuntime.Instance.Line(0.5,0.2,0.4,0.1);
}, false);
__vip_less_than = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.9,0.1,0.1,0.5,0.9,0.9);
}, false);
__vip_equal_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.1,0.4,0.9,0.4,0.1,0.6,0.9,0.6);
}, false);
__vip_greater_than = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.1,0.1,0.9,0.5,0.1,0.9);
}, false);
__vip_question_mark = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.8,0,1,1,1,1,0.6,0.5,0.6,0.5,0.3);
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.1,0.1,6,false);
}, false);
__vip_at_symbol = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,0.4,0.6,0.3,0.3,0.3,0.3,0.6,0.4,0.7,0.7,0.7);
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,0.8,0.7,0.3,0.8,0.3,1,0.5,1,0.8,0.8,1,0.2,1,0,0.8,0,0.2,0.2,0,0.8,0,1,0.2);
}, false);
__vip_lt_a = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0.5,1,1,0);
vip_sharp.VIPRuntime.Instance.Line(0.15,0.3,0.85,0.3);
}, false);
__vip_lt_b = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0,0,1,0.7,1,0.9,0.9,0.9,0.6,0.7,0.5,1,0.3,1,0.1,0.8,0);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,0.7,0.5);
}, false);
__vip_lt_c = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.2,0.8,0,0.2,0,0,0.2,0,0.8,0.2,1,0.8,1,1,0.8);
}, false);
__vip_lt_d = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0,0,1,0.7,1,1,0.7,1,0.2,0.8,0);
}, false);
__vip_lt_e = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0,0,0,0,1,1,1);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,0.5,0.5);
}, false);
__vip_lt_f = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,1,1);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,0.5,0.5);
}, false);
__vip_lt_g = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.5,0.5,1,0.5,1,0.2,0.8,0,0.2,0,0,0.2,0,0.8,0.2,1,0.8,1,1,0.8);
}, false);
__vip_lt_h = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,1,0.5);
vip_sharp.VIPRuntime.Instance.Line(1,0,1,1);
}, false);
__vip_lt_i = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.3,0,0.7,0);
vip_sharp.VIPRuntime.Instance.Line(0.3,1,0.7,1);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,1);
}, false);
__vip_lt_j = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.5,1,0.9,1);
vip_sharp.VIPRuntime.Instance.LineStrip(0.2,0.2,0.4,0,0.5,0,0.7,0.2,0.7,1);
}, false);
__vip_lt_k = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.5,1,0);
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.5,1,1);
}, false);
__vip_lt_l = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0,0,1,0);
}, false);
__vip_lt_m = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,0.5,0.5,1,1,1,0);
}, false);
__vip_lt_n = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,1,0,1,1);
}, false);
__vip_lt_o = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.2,0,0,0.2,0,0.8,0.2,1,0.8,1,1,0.8,1,0.2,0.8,0);
}, false);
__vip_lt_p = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,0.8,1,1,0.8,1,0.6,0.8,0.4,0,0.4);
}, false);
__vip_lt_q = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.2,0,0,0.2,0,0.8,0.2,1,0.8,1,1,0.8,1,0.2,0.8,0);
vip_sharp.VIPRuntime.Instance.Line(0.7,0.3,1,0);
}, false);
__vip_lt_r = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,0.8,1,1,0.8,1,0.6,0.8,0.4,0,0.4);
vip_sharp.VIPRuntime.Instance.Line(0.8,0.4,1,0);
}, false);
__vip_lt_s = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.1,0.2,0,0.8,0,1,0.2,1,0.4,0.9,0.5,0.1,0.5,0,0.6,0,0.8,0.2,1,0.8,1,1,0.9);
}, false);
__vip_lt_t = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,1,1,1);
vip_sharp.VIPRuntime.Instance.Line(0.5,1,0.5,0);
}, false);
__vip_lt_u = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0,0.2,0.2,0,0.8,0,1,0.2,1,1);
}, false);
__vip_lt_v = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0.5,0,1,1);
}, false);
__vip_lt_w = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0.2,0,0.5,0.4,0.8,0,1,1);
}, false);
__vip_lt_x = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,0,1,1);
vip_sharp.VIPRuntime.Instance.Line(0,1,1,0);
}, false);
__vip_lt_y = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,0,1,1);
vip_sharp.VIPRuntime.Instance.Line(0,1,0.5,0.5);
}, false);
__vip_lt_z = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0,0,0,1,1,0,1);
}, false);
__vip_left_square_bracket = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.8,0,0.3,0,0.3,1,0.8,1);
}, false);
__vip_back_slash = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.2,1,0.8,0);
}, false);
__vip_right_square_bracket = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.2,1,0.7,1,0.7,0,0.2,0);
}, false);
__vip_caret = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,0.8,0.5,1,0.7,0.8);
}, false);
__vip_underline = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,0,1,0);
}, false);
__vip_accent = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,0.9,0.5,0.9,0.5,0.8,0.4,0.8,0.4,0.9,0.5,1);
}, false);
__vip_lt_la = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.4,0.2,0.6,0.8,0.6,1,0.4,1,0);
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0.2,0,0,0.1,0,0.2,0.2,0.3,0.8,0.3,1,0.2);
}, false);
__vip_lt_lb = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.1,0.8,0,0.2,0,0,0.1);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
}, false);
__vip_lt_lc = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5);
}, false);
__vip_lt_ld = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5);
vip_sharp.VIPRuntime.Instance.Line(1,0,1,1);
}, false);
__vip_lt_le = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.3,0,0.3);
}, false);
__vip_lt_lf = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,0,0.4,0.8,0.6,1,0.8,1);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.5,0.6,0.5);
}, false);
__vip_lt_lg = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5);
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.6,1,-0.2,0.8,-0.4,0.2,-0.4,0,-0.3);
}, false);
__vip_lt_lh = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0);
}, false);
__vip_lt_li = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.6,0.5,0.7,0.5,0.8);
}, false);
__vip_lt_lj = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,-0.4,0.5,-0.4,0.7,-0.3,0.7,0.6);
vip_sharp.VIPRuntime.Instance.Line(0.7,0.7,0.7,0.8);
}, false);
__vip_lt_lk = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
vip_sharp.VIPRuntime.Instance.Line(0,0.3,1,0.6);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.35,1,0);
}, false);
__vip_lt_ll = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,1);
}, false);
__vip_lt_lm = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.1,0.6,0.4,0.6,0.5,0.5,0.6,0.6,0.9,0.6,1,0.5,1,0);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,0.6);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.5);
}, false);
__vip_lt_ln = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.9,0.6,1,0.5,1,0);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,0.6);
}, false);
__vip_lt_lo = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.1,0.8,0,0.2,0);
}, false);
__vip_lt_lp = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.1,0.8,0,0.2,0,0,0.1);
vip_sharp.VIPRuntime.Instance.Line(0,0.6,0,-0.4);
}, false);
__vip_lt_lq = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.1,0.8,0,0.2,0);
vip_sharp.VIPRuntime.Instance.Line(0.7,0.2,1,0);
}, false);
__vip_lt_lr = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.9,0.6,1,0.5);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,0.6);
}, false);
__vip_lt_ls = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.1,0.2,0,0.9,0,1,0.1,1,0.2,0.8,0.3,0.2,0.3,0,0.4,0,0.5,0.1,0.6,0.8,0.6,1,0.5);
}, false);
__vip_lt_lt = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,1,0.4,0.1,0.5,0,0.6,0);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.7,0.6,0.7);
}, false);
__vip_lt_lu = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.6,0,0.1,0.2,0,0.8,0,1,0.1);
vip_sharp.VIPRuntime.Instance.Line(1,0.6,1,0);
}, false);
__vip_lt_lv = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.6,0.5,0,1,0.6);
}, false);
__vip_lt_lw = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.6,0.2,0,0.5,0.3,0.8,0,1,0.6);
}, false);
__vip_lt_lx = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,0,1,1,0,1,1,0);
}, false);
__vip_lt_ly = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,-0.4,0.5,0,1,0.6);
vip_sharp.VIPRuntime.Instance.Line(0,0.6,0.5,0);
}, false);
__vip_lt_lz = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.6,1,0.6,0,0,1,0);
}, false);
__vip_left_bracket_2 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,0,0.5,0,0.4,0.1,0.4,0.4,0.3,0.5,0.4,0.6,0.4,0.9,0.5,1,0.7,1);
}, false);
__vip_vertical_line = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,1);
}, false);
__vip_right_bracket_2 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,1,0.5,1,0.6,0.9,0.6,0.6,0.7,0.5,0.6,0.4,0.6,0.1,0.5,0,0.3,0);
}, false);
__vip_tilde = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.2,0.5,0.4,0.6,0.7,0.4,0.9,0.5);
}, false);
__vip_delete = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__lfont = new vip_sharp.VIPRuntime.StringRes(__vip_null,0.05,0.05,1.2);
__bmpswitch = new vip_sharp.VIPRuntime.BitmapRes(vip_sharp.VIPRuntime.BitmapType.RGB, vip_sharp.VIPRuntime.BitmapFilter.Linear, vip_sharp.VIPRuntime.BitmapClamp.Clamp, @"Switch.bmp");
this.__uvdown= new vip_sharp.BipolarArray<__tvertex>(4) {new __tvertex {__dx = 0,__dy = 0},new __tvertex {__dx = 0,__dy = 1},new __tvertex {__dx = 0.5,__dy = 1},new __tvertex {__dx = 0.5,__dy = 0}};
this.__uvup= new vip_sharp.BipolarArray<__tvertex>(4) {new __tvertex {__dx = 0.5,__dy = 0},new __tvertex {__dx = 0.5,__dy = 1},new __tvertex {__dx = 1,__dy = 1},new __tvertex {__dx = 1,__dy = 0}};
__sw1 = new __twoposswitch() { x = 0,y = 0,s = 0.3};
__sw2 = new __twoposswitch() { x = 0,y = 0.3,s = 0.3};
__sw3 = new __twoposswitch() { x = 0,y = -0.3,s = 0.3};
__sw4 = new __twoposswitch() { x = 0.3,y = 0,s = 0.3};
__sw5 = new __twoposswitch() { x = -0.3,y = 0,s = 0.3};
this.__dzoom = 1;
this.__dzoomx = 0;
this.__dzoomy = 0;
}
public vip_sharp.VIPRuntime.DisplayList __vip_null;
public vip_sharp.VIPRuntime.DisplayList __vip_smiley;
public vip_sharp.VIPRuntime.DisplayList __vip_smiley_filled;
public vip_sharp.VIPRuntime.DisplayList __vip_heart;
public vip_sharp.VIPRuntime.DisplayList __vip_diamond;
public vip_sharp.VIPRuntime.DisplayList __vip_clover;
public vip_sharp.VIPRuntime.DisplayList __vip_ace;
public vip_sharp.VIPRuntime.DisplayList __vip_big_dot;
public vip_sharp.VIPRuntime.DisplayList __vip_quad_big_dot;
public vip_sharp.VIPRuntime.DisplayList __vip_open_circle;
public vip_sharp.VIPRuntime.DisplayList __vip_circle_filled;
public vip_sharp.VIPRuntime.DisplayList __vip_male_sign;
public vip_sharp.VIPRuntime.DisplayList __vip_female_sign;
public vip_sharp.VIPRuntime.DisplayList __vip_note;
public vip_sharp.VIPRuntime.DisplayList __vip_double_note;
public vip_sharp.VIPRuntime.DisplayList __vip_sun;
public vip_sharp.VIPRuntime.DisplayList __vip_triangle_right;
public vip_sharp.VIPRuntime.DisplayList __vip_triangle_left;
public vip_sharp.VIPRuntime.DisplayList __vip_arrow_up_down;
public vip_sharp.VIPRuntime.DisplayList __vip_double_exclamation;
public vip_sharp.VIPRuntime.DisplayList __vip_pi_sign;
public vip_sharp.VIPRuntime.DisplayList __vip_double_s;
public vip_sharp.VIPRuntime.DisplayList __vip_fat_stripe;
public vip_sharp.VIPRuntime.DisplayList __vip_arrow_up_down_bottom;
public vip_sharp.VIPRuntime.DisplayList __vip_up_arrow;
public vip_sharp.VIPRuntime.DisplayList __vip_down_arrow;
public vip_sharp.VIPRuntime.DisplayList __vip_right_arrow;
public vip_sharp.VIPRuntime.DisplayList __vip_left_arrow;
public vip_sharp.VIPRuntime.DisplayList __vip_fs;
public vip_sharp.VIPRuntime.DisplayList __vip_double_arrow;
public vip_sharp.VIPRuntime.DisplayList __vip_triangle_up;
public vip_sharp.VIPRuntime.DisplayList __vip_triangle_down;
public vip_sharp.VIPRuntime.DisplayList __vip_space;
public vip_sharp.VIPRuntime.DisplayList __vip_exlamation_point;
public vip_sharp.VIPRuntime.DisplayList __vip_double_quote;
public vip_sharp.VIPRuntime.DisplayList __vip_number_sign;
public vip_sharp.VIPRuntime.DisplayList __vip_dollar_sign;
public vip_sharp.VIPRuntime.DisplayList __vip_percent;
public vip_sharp.VIPRuntime.DisplayList __vip_ampersand;
public vip_sharp.VIPRuntime.DisplayList __vip_apostrophe;
public vip_sharp.VIPRuntime.DisplayList __vip_left_parenthesis;
public vip_sharp.VIPRuntime.DisplayList __vip_right_parenthesis;
public vip_sharp.VIPRuntime.DisplayList __vip_asterisk;
public vip_sharp.VIPRuntime.DisplayList __vip_plus_sign;
public vip_sharp.VIPRuntime.DisplayList __vip_comma;
public vip_sharp.VIPRuntime.DisplayList __vip_minus;
public vip_sharp.VIPRuntime.DisplayList __vip_period;
public vip_sharp.VIPRuntime.DisplayList __vip_slash;
public vip_sharp.VIPRuntime.DisplayList __vip_nr_0;
public vip_sharp.VIPRuntime.DisplayList __vip_nr_1;
public vip_sharp.VIPRuntime.DisplayList __vip_nr_2;
public vip_sharp.VIPRuntime.DisplayList __vip_nr_3;
public vip_sharp.VIPRuntime.DisplayList __vip_nr_4;
public vip_sharp.VIPRuntime.DisplayList __vip_nr_5;
public vip_sharp.VIPRuntime.DisplayList __vip_nr_6;
public vip_sharp.VIPRuntime.DisplayList __vip_nr_7;
public vip_sharp.VIPRuntime.DisplayList __vip_nr_8;
public vip_sharp.VIPRuntime.DisplayList __vip_nr_9;
public vip_sharp.VIPRuntime.DisplayList __vip_colon;
public vip_sharp.VIPRuntime.DisplayList __vip_semicolon;
public vip_sharp.VIPRuntime.DisplayList __vip_less_than;
public vip_sharp.VIPRuntime.DisplayList __vip_equal_sign;
public vip_sharp.VIPRuntime.DisplayList __vip_greater_than;
public vip_sharp.VIPRuntime.DisplayList __vip_question_mark;
public vip_sharp.VIPRuntime.DisplayList __vip_at_symbol;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_a;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_b;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_c;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_d;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_e;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_f;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_g;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_h;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_i;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_j;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_k;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_l;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_m;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_n;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_o;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_p;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_q;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_r;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_s;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_t;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_u;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_v;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_w;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_x;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_y;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_z;
public vip_sharp.VIPRuntime.DisplayList __vip_left_square_bracket;
public vip_sharp.VIPRuntime.DisplayList __vip_back_slash;
public vip_sharp.VIPRuntime.DisplayList __vip_right_square_bracket;
public vip_sharp.VIPRuntime.DisplayList __vip_caret;
public vip_sharp.VIPRuntime.DisplayList __vip_underline;
public vip_sharp.VIPRuntime.DisplayList __vip_accent;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_la;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lb;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lc;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_ld;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_le;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lf;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lg;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lh;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_li;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lj;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lk;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_ll;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lm;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_ln;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lo;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lp;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lq;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lr;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_ls;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lt;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lu;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lv;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lw;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lx;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_ly;
public vip_sharp.VIPRuntime.DisplayList __vip_lt_lz;
public vip_sharp.VIPRuntime.DisplayList __vip_left_bracket_2;
public vip_sharp.VIPRuntime.DisplayList __vip_vertical_line;
public vip_sharp.VIPRuntime.DisplayList __vip_right_bracket_2;
public vip_sharp.VIPRuntime.DisplayList __vip_tilde;
public vip_sharp.VIPRuntime.DisplayList __vip_delete;
public vip_sharp.VIPRuntime.StringRes __lfont;public vip_sharp.VIPRuntime.BitmapRes __bmpswitch = null;
public class __tvertex { 
public double __dx;
public double __dy;
}
public vip_sharp.BipolarArray<__tvertex> __uvdown;
public vip_sharp.BipolarArray<__tvertex> __uvup;
public class __twoposswitch : vip_sharp.VIPRuntime.VIPObject {
public __twoposswitch() {
}
public class __struct_cout {
public int __bsel;
}
public __struct_cout __cout=new __struct_cout();
public override void Run() {
int __bselup = 0;
int __bseldown = 0;
__bseldown = Convert.ToInt32(vip_sharp.VIPRuntime.Instance.HotSpot(1, this,0,0,0.2,0.3,vip_sharp.VIPRuntime.PositionRef.cu,__bseldown,vip_sharp.VIPRuntime.HotSpotTrigger.Selected,vip_sharp.VIPRuntime.HotSpotType.Momentary,Convert.ToInt32(1),Convert.ToInt32(0),vip_sharp.VIPRuntime.HoverBox.Never));
__bselup = Convert.ToInt32(vip_sharp.VIPRuntime.Instance.HotSpot(2, this,0,0,0.2,0.3,vip_sharp.VIPRuntime.PositionRef.cl,__bselup,vip_sharp.VIPRuntime.HotSpotTrigger.Selected,vip_sharp.VIPRuntime.HotSpotType.Momentary,Convert.ToInt32(1),Convert.ToInt32(0),vip_sharp.VIPRuntime.HoverBox.Never));
if(Convert.ToBoolean(__bselup))
{
__cout.__bsel = Convert.ToInt32(1);
}
else
if(Convert.ToBoolean(__bseldown))
{
__cout.__bsel = Convert.ToInt32(0);
}
if(Convert.ToBoolean(__cout.__bsel))
{
vip_sharp.VIPRuntime.Instance.Bitmap(GlobalState.MainClass.__bmpswitch, vip_sharp.VIPRuntime.BitmapBlend.Replace, 0,0,0.2,0.6,vip_sharp.VIPRuntime.PositionRef.ctr,GlobalState.MainClass.__uvup);
}
else
{
vip_sharp.VIPRuntime.Instance.Bitmap(GlobalState.MainClass.__bmpswitch, vip_sharp.VIPRuntime.BitmapBlend.Replace, 0,0,0.2,0.6,vip_sharp.VIPRuntime.PositionRef.ctr,GlobalState.MainClass.__uvdown);
}
}
}
public __twoposswitch __sw1;
public __twoposswitch __sw2;
public __twoposswitch __sw3;
public __twoposswitch __sw4;
public __twoposswitch __sw5;
public double __dzoom;
public double __dzoomx;
public double __dzoomy;
public override void Run() {
double __dnewzoom = 0;
__dnewzoom = Convert.ToDouble(GlobalState.MainClass.__dzoom+(vip_sharp.VIPRuntime.Instance.VIPSystemClass.__fwheel/10));
if(Convert.ToBoolean((vip_sharp.VIPRuntime.Instance.VIPSystemClass.__fwheel!=0)))
{
GlobalState.MainClass.__dzoomx = Convert.ToDouble(vip_sharp.VIPRuntime.Instance.VIPSystemClass.__fcursor_xpos/GlobalState.MainClass.__dzoom);
GlobalState.MainClass.__dzoomy = Convert.ToDouble(vip_sharp.VIPRuntime.Instance.VIPSystemClass.__fcursor_ypos/GlobalState.MainClass.__dzoom);
}
GlobalState.MainClass.__dzoom = Convert.ToDouble(__dnewzoom);
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Scale(GlobalState.MainClass.__dzoom);
vip_sharp.VIPRuntime.Instance.Translate(GlobalState.MainClass.__dzoomx*GlobalState.MainClass.__dzoom, GlobalState.MainClass.__dzoomy*GlobalState.MainClass.__dzoom);
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__sw1);
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__sw2);
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__sw3);
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__sw4);
vip_sharp.VIPRuntime.Instance.Draw(GlobalState.MainClass.__sw5);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
vip_sharp.BipolarArray<char> __szvalue= new vip_sharp.BipolarArray<char>(8);
double __tmp = 0;
__tmp = Convert.ToDouble(vip_sharp.VIPRuntime.Instance.VIPSystemClass.__fcursor_xpos/GlobalState.MainClass.__dzoom);
vip_sharp.VIPRuntime.Instance.Format(__szvalue,"%.2f",__tmp);
vip_sharp.VIPRuntime.Instance.DrawString(-0.9,0.9,vip_sharp.VIPRuntime.PositionRef.lu,__szvalue,0,GlobalState.MainClass.__lfont);
__tmp = Convert.ToDouble(vip_sharp.VIPRuntime.Instance.VIPSystemClass.__fcursor_ypos/GlobalState.MainClass.__dzoom);
vip_sharp.VIPRuntime.Instance.Format(__szvalue,"%.2f",__tmp);
vip_sharp.VIPRuntime.Instance.DrawString(-0.9,0.8,vip_sharp.VIPRuntime.PositionRef.lu,__szvalue,0,GlobalState.MainClass.__lfont);
}
}
