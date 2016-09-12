using System;
using System.Linq;
using System.Collections.Generic;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
__vip_null = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineWidth(8);
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
__arial_null = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineWidth(10);
}, false);
__arial_smiley = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.5,0.5,16,false);
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.7,0.05,6,false);
vip_sharp.VIPRuntime.Instance.Circle(0.7,0.7,0.05,6,false);
vip_sharp.VIPRuntime.Instance.ArcLine(0.5,0.5,0.3,90,270,4);
}, false);
__arial_smiley_filled = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ColorSave();
vip_sharp.VIPRuntime.Instance.Color(0,0,0);
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.5,0.5,16,false);
vip_sharp.VIPRuntime.Instance.Color(100,100,100);
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.7,0.05,6,false);
vip_sharp.VIPRuntime.Instance.Circle(0.7,0.7,0.05,6,false);
vip_sharp.VIPRuntime.Instance.ArcLine(0.5,0.5,0.3,90,270,4);
vip_sharp.VIPRuntime.Instance.ColorRestore();
}, false);
__arial_heart = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Polygon(0.5,0,0.1,0.4,0,0.6,0,0.8,0.2,1,0.3,1,0.4,0.9,0.5,0.7);
vip_sharp.VIPRuntime.Instance.Polygon(0.5,0.7,0.4,0.9,0.3,1,0.2,1,0,0.8,0,0.6,0.1,0.4,0.5,0);
}, false);
__arial_diamond = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Quad(0.5,1,1,0.5,0.5,0,0,0.5);
}, false);
__arial_clover = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Polygon(0.5,0.5,0.3,0.8,0.4,1,0.6,1,0.7,0.8);
vip_sharp.VIPRuntime.Instance.Polygon(0.5,0.5,0.4,0.3,0.3,0.2,0.1,0.2,0,0.3,0,0.4,0.2,0.5);
vip_sharp.VIPRuntime.Instance.Polygon(0.2,0.5,0,0.4,0,0.3,0.1,0.2,0.3,0.2,0.4,0.3,0.5,0.5);
vip_sharp.VIPRuntime.Instance.Triangle(0.4,0,0.5,0.3,0.6,0);
}, false);
__arial_ace = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Polygon(0.5,1,0.5,0.5,0.4,0.3,0.3,0.2,0.2,0.2,0,0.4,0,0.6);
vip_sharp.VIPRuntime.Instance.Polygon(0,0.6,0,0.4,0.2,0.2,0.3,0.2,0.4,0.3,0.5,0.5,0.5,1);
vip_sharp.VIPRuntime.Instance.Triangle(0.4,0,0.5,0.3,0.6,0);
}, false);
__arial_big_dot = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__arial_quad_big_dot = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__arial_open_circle = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__arial_circle_filled = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__arial_male_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.3,0.3,12,false);
vip_sharp.VIPRuntime.Instance.Line(0.627,0.627,1,1);
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,1,1,1,1,0.7);
}, false);
__arial_female_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.7,0.3,12,false);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.4);
}, false);
__arial_note = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Circle(0.4,0.1,0.1,6,false);
vip_sharp.VIPRuntime.Instance.LineStrip(0.5,1,0.5,1,0.7,0.8,0.7,0.6,0.6,0.4);
}, false);
__arial_double_note = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.2,0.1,6,false);
vip_sharp.VIPRuntime.Instance.Circle(0.8,0.1,0.1,6,false);
vip_sharp.VIPRuntime.Instance.Line(0.3,0.3,0.3,1,0.9,0.1,0.9,0.8);
vip_sharp.VIPRuntime.Instance.Quad(0.3,0.9,0.3,1,0.9,0.8,0.9,0.7);
}, false);
__arial_sun = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
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
__arial_triangle_right = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0.9,0.5,0.1,0.9,0.1,0.1);
}, false);
__arial_triangle_left = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0.1,0.5,0.9,0.9,0.9,0.1);
}, false);
__arial_arrow_up_down = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__arial_double_exclamation = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__arial_pi_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__arial_double_s = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__arial_fat_stripe = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__arial_arrow_up_down_bottom = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0.4,0.7,0.5,1,0.6,0.7);
vip_sharp.VIPRuntime.Instance.Triangle(0.5,0,0.4,0.3,0.6,0.3);
vip_sharp.VIPRuntime.Instance.Line(0.3,0,0.7,0,0.5,0.4,0.5,0.7);
}, false);
__arial_up_arrow = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0.4,0.7,0.5,1,0.6,0.7);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.7);
}, false);
__arial_down_arrow = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0.5,0,0.4,0.3,0.6,0.3);
vip_sharp.VIPRuntime.Instance.Line(0.5,1,0.5,0.3);
}, false);
__arial_right_arrow = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(1,0.5,0.7,0.4,0.7,0.6);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,0.7,0.5);
}, false);
__arial_left_arrow = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0,0.5,0.3,0.6,0.3,0.4);
vip_sharp.VIPRuntime.Instance.Line(0.3,0.5,1,0.5);
}, false);
__arial_fs = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__arial_double_arrow = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__arial_triangle_up = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0.5,0.9,0.9,0.1,0.1,0.1);
}, false);
__arial_triangle_down = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0.1,0.9,0.9,0.9,0.5,0.1);
}, false);
__arial_space = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__arial_exlamation_point = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Triangle(0.5,0.3,0.4,1,0.6,1);
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.1,0.1,6,true);
}, false);
__arial_double_quote = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,0.9,0.4,0.9,0.4,0.8,0.3,0.8,0.3,0.9,0.4,1);
vip_sharp.VIPRuntime.Instance.LineStrip(0.6,0.9,0.7,0.9,0.7,0.8,0.6,0.8,0.6,0.9,0.7,1);
}, false);
__arial_number_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.25,0,0.35,1,0.65,0,0.75,1,0,0.3,0.95,0.3,0.05,0.7,1,0.7);
}, false);
__arial_dollar_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.1,0.2,0.2,0.1,0.8,0.1,0.9,0.2,0.9,0.4,0.8,0.5,0.2,0.5,0.1,0.6,0.1,0.8,0.2,0.9,0.8,0.9,0.9,0.8);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,1);
}, false);
__arial_percent = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Circle(0.3,0.7,0.1,6,false);
vip_sharp.VIPRuntime.Instance.Circle(0.7,0.3,0.1,6,false);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.1,0.8,0.9);
}, false);
__arial_ampersand = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,0,0.2,0.6,0.2,0.7,0.3,0.8,0.5,0.8,0.6,0.7,0.6,0.6,0.1,0.3,0.1,0.1,0.2,0,0.5,0,0.7,0.3);
}, false);
__arial_apostrophe = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,0.9,0.5,0.9,0.5,0.8,0.4,0.8,0.4,0.9,0.5,1);
}, false);
__arial_left_parenthesis = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.6,0,0.5,0,0.4,0.2,0.4,0.8,0.5,1,0.6,1);
}, false);
__arial_right_parenthesis = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,0,0.5,0,0.6,0.2,0.6,0.8,0.5,1,0.4,1);
}, false);
__arial_asterisk = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
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
__arial_plus_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,0.4,0.8,0.4);
vip_sharp.VIPRuntime.Instance.Line(0.4,0.1,0.4,0.7);
}, false);
__arial_comma = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,0,0.2,0,0.2,0.1,0.3,0.1,0.3,0,0.2,-0.1);
}, false);
__arial_minus = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.2,0.5,0.8,0.5);
}, false);
__arial_period = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.2,0.1,0.3,0.1,0.3,0,0.2,0);
}, false);
__arial_slash = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.2,0,0.8,1);
}, false);
__arial_nr_0 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0,0,1,1,1,1,0);
}, false);
__arial_nr_1 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,1,0.5,1,0.5,0);
}, false);
__arial_nr_2 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,1,1,1,0.5,0,0.5,0,0,1,0);
}, false);
__arial_nr_3 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,1,1,1,0,0,0);
vip_sharp.VIPRuntime.Instance.Line(0.3,0.5,1,0.5);
}, false);
__arial_nr_4 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0,0.5,1,0.5);
vip_sharp.VIPRuntime.Instance.Line(1,0,1,1);
}, false);
__arial_nr_5 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,1,0,1,0.5,0,0.5,0,1,1,1);
}, false);
__arial_nr_6 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,1,0.5,1,0,0,0,0,1,1,1);
}, false);
__arial_nr_7 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,1,1,1,0);
}, false);
__arial_nr_8 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0,0,1,1,1,1,0);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,1,0.5);
}, false);
__arial_nr_9 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.5,0,0.5,0,1,1,1,1,0,0,0);
}, false);
__arial_colon = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.4,0.7,0.4,0.8,0.5,0.8,0.5,0.7);
vip_sharp.VIPRuntime.Instance.ClosedLine(0.4,0.2,0.4,0.3,0.5,0.3,0.5,0.2);
}, false);
__arial_semicolon = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.4,0.7,0.4,0.8,0.5,0.8,0.5,0.7);
vip_sharp.VIPRuntime.Instance.ClosedLine(0.4,0.2,0.4,0.3,0.5,0.3,0.5,0.2);
vip_sharp.VIPRuntime.Instance.Line(0.5,0.2,0.4,0.1);
}, false);
__arial_less_than = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.9,0.1,0.1,0.5,0.9,0.9);
}, false);
__arial_equal_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.1,0.4,0.9,0.4,0.1,0.6,0.9,0.6);
}, false);
__arial_greater_than = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.1,0.1,0.9,0.5,0.1,0.9);
}, false);
__arial_question_mark = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.8,0,1,1,1,1,0.6,0.5,0.6,0.5,0.3);
vip_sharp.VIPRuntime.Instance.Circle(0.5,0.1,0.1,6,false);
}, false);
__arial_at_symbol = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,0.4,0.6,0.3,0.3,0.3,0.3,0.6,0.4,0.7,0.7,0.7);
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,0.8,0.7,0.3,0.8,0.3,1,0.5,1,0.8,0.8,1,0.2,1,0,0.8,0,0.2,0.2,0,0.8,0,1,0.2);
}, false);
__arial_lt_a = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0.5,1,1,0);
vip_sharp.VIPRuntime.Instance.Line(0.15,0.3,0.85,0.3);
}, false);
__arial_lt_b = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0,0,1,0.7,1,0.9,0.9,0.9,0.6,0.7,0.5,1,0.3,1,0.1,0.8,0);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,0.7,0.5);
}, false);
__arial_lt_c = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.2,0.8,0,0.2,0,0,0.2,0,0.8,0.2,1,0.8,1,1,0.8);
}, false);
__arial_lt_d = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0,0,1,0.7,1,1,0.7,1,0.2,0.8,0);
}, false);
__arial_lt_e = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0,0,0,0,1,1,1);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,1,0.5);
}, false);
__arial_lt_f = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,1,1);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,0.9,0.5);
}, false);
__arial_lt_g = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.5,0.5,1,0.5,1,0.2,0.8,0,0.2,0,0,0.2,0,0.8,0.2,1,0.8,1,1,0.8);
}, false);
__arial_lt_h = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
vip_sharp.VIPRuntime.Instance.Line(0,0.5,1,0.5);
vip_sharp.VIPRuntime.Instance.Line(1,0,1,1);
}, false);
__arial_lt_i = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,1);
}, false);
__arial_lt_j = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,1,1,0.25,0.875,0.125,0.625,0,0.375,0,0.125,0.125,0,0.25,0,0.375);
}, false);
__arial_lt_k = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.5,1,0);
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.5,1,1);
}, false);
__arial_lt_l = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0,0,1,0);
}, false);
__arial_lt_m = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,0.5,0.5,1,1,1,0);
}, false);
__arial_lt_n = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,1,0,1,1);
}, false);
__arial_lt_o = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.2,0,0,0.2,0,0.8,0.2,1,0.8,1,1,0.8,1,0.2,0.8,0);
}, false);
__arial_lt_p = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,0.8,1,1,0.8,1,0.6,0.8,0.4,0,0.4);
}, false);
__arial_lt_q = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0.2,0,0,0.2,0,0.8,0.2,1,0.8,1,1,0.8,1,0.2,0.8,0);
vip_sharp.VIPRuntime.Instance.Line(0.7,0.3,1,0);
}, false);
__arial_lt_r = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0,0,1,0.8,1,1,0.8,1,0.6,0.8,0.4,0,0.4);
vip_sharp.VIPRuntime.Instance.Line(0.8,0.4,1,0);
}, false);
__arial_lt_s = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.1,0.2,0,0.8,0,1,0.2,1,0.4,0.9,0.5,0.1,0.5,0,0.6,0,0.8,0.2,1,0.8,1,1,0.9);
}, false);
__arial_lt_t = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,1,1,1);
vip_sharp.VIPRuntime.Instance.Line(0.5,1,0.5,0);
}, false);
__arial_lt_u = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0,0.2,0.2,0,0.8,0,1,0.2,1,1);
}, false);
__arial_lt_v = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0.5,0,1,1);
}, false);
__arial_lt_w = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0.2,0,0.5,1,0.8,0,1,1);
}, false);
__arial_lt_x = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,0,1,1);
vip_sharp.VIPRuntime.Instance.Line(0,1,1,0);
}, false);
__arial_lt_y = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,1,0.5,0.5,1,1);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.5);
}, false);
__arial_lt_z = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0,0,0,1,1,0,1);
}, false);
__arial_left_square_bracket = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.8,0,0.3,0,0.3,1,0.8,1);
}, false);
__arial_back_slash = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.2,1,0.8,0);
}, false);
__arial_right_square_bracket = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.2,1,0.7,1,0.7,0,0.2,0);
}, false);
__arial_caret = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,0.8,0.5,1,0.7,0.8);
}, false);
__arial_underline = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,0,1,0);
}, false);
__arial_accent = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,0.9,0.5,0.9,0.5,0.8,0.4,0.8,0.4,0.9,0.5,1);
}, false);
__arial_lt_la = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.4,0.2,0.6,0.8,0.6,1,0.4,1,0);
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0.2,0,0,0.1,0,0.2,0.2,0.3,0.8,0.3,1,0.2);
}, false);
__arial_lt_lb = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.1,0.8,0,0.2,0,0,0.1);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
}, false);
__arial_lt_lc = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5);
}, false);
__arial_lt_ld = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5);
vip_sharp.VIPRuntime.Instance.Line(1,0,1,1);
}, false);
__arial_lt_le = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.3,0,0.3);
}, false);
__arial_lt_lf = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,0,0.4,0.8,0.6,1,0.8,1);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.5,0.6,0.5);
}, false);
__arial_lt_lg = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.1,0.8,0,0.2,0,0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5);
vip_sharp.VIPRuntime.Instance.LineStrip(1,0.6,1,-0.2,0.8,-0.4,0.2,-0.4,0,-0.3);
}, false);
__arial_lt_lh = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0);
}, false);
__arial_lt_li = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.6,0.5,0.7,0.5,0.8);
}, false);
__arial_lt_lj = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,-0.4,0.5,-0.4,0.7,-0.3,0.7,0.6);
vip_sharp.VIPRuntime.Instance.Line(0.7,0.7,0.7,0.8);
}, false);
__arial_lt_lk = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,0,0,1);
vip_sharp.VIPRuntime.Instance.Line(0,0.3,1,0.6);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.35,1,0);
}, false);
__arial_lt_ll = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,1);
}, false);
__arial_lt_lm = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.1,0.6,0.4,0.6,0.5,0.5,0.6,0.6,0.9,0.6,1,0.5,1,0);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,0.6);
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,0.5);
}, false);
__arial_lt_ln = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.9,0.6,1,0.5,1,0);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,0.6);
}, false);
__arial_lt_lo = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.1,0.8,0,0.2,0);
}, false);
__arial_lt_lp = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.1,0.8,0,0.2,0,0,0.1);
vip_sharp.VIPRuntime.Instance.Line(0,0.6,0,-0.4);
}, false);
__arial_lt_lq = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ClosedLine(0,0.1,0,0.5,0.2,0.6,0.8,0.6,1,0.5,1,0.1,0.8,0,0.2,0);
vip_sharp.VIPRuntime.Instance.Line(0.7,0.2,1,0);
}, false);
__arial_lt_lr = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.5,0.2,0.6,0.9,0.6,1,0.5);
vip_sharp.VIPRuntime.Instance.Line(0,0,0,0.6);
}, false);
__arial_lt_ls = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.1,0.2,0,0.9,0,1,0.1,1,0.2,0.8,0.3,0.2,0.3,0,0.4,0,0.5,0.1,0.6,0.8,0.6,1,0.5);
}, false);
__arial_lt_lt = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.4,1,0.4,0.1,0.5,0,0.6,0);
vip_sharp.VIPRuntime.Instance.Line(0.2,0.7,0.6,0.7);
}, false);
__arial_lt_lu = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.6,0,0.1,0.2,0,0.8,0,1,0.1);
vip_sharp.VIPRuntime.Instance.Line(1,0.6,1,0);
}, false);
__arial_lt_lv = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.6,0.5,0,1,0.6);
}, false);
__arial_lt_lw = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.6,0.2,0,0.5,0.3,0.8,0,1,0.6);
}, false);
__arial_lt_lx = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0,0,1,1,0,1,1,0);
}, false);
__arial_lt_ly = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,-0.4,0.5,0,1,0.6);
vip_sharp.VIPRuntime.Instance.Line(0,0.6,0.5,0);
}, false);
__arial_lt_lz = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0,0.6,1,0.6,0,0,1,0);
}, false);
__arial_left_bracket_2 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.7,0,0.5,0,0.4,0.1,0.4,0.4,0.3,0.5,0.4,0.6,0.4,0.9,0.5,1,0.7,1);
}, false);
__arial_vertical_line = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Line(0.5,0,0.5,1);
}, false);
__arial_right_bracket_2 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.3,1,0.5,1,0.6,0.9,0.6,0.6,0.7,0.5,0.6,0.4,0.6,0.1,0.5,0,0.3,0);
}, false);
__arial_tilde = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.LineStrip(0.2,0.5,0.4,0.6,0.7,0.4,0.9,0.5);
}, false);
__arial_delete = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__stripe = new vip_sharp.VIPRuntime.BitmapRes(vip_sharp.VIPRuntime.BitmapType.RGB, vip_sharp.VIPRuntime.BitmapFilter.Linear, vip_sharp.VIPRuntime.BitmapClamp.Clamp, @"stripe.bmp");
__switch = new vip_sharp.VIPRuntime.BitmapRes(vip_sharp.VIPRuntime.BitmapType.RGB, vip_sharp.VIPRuntime.BitmapFilter.Linear, vip_sharp.VIPRuntime.BitmapClamp.Clamp, @"sw.png");
__knob = new vip_sharp.VIPRuntime.BitmapRes(vip_sharp.VIPRuntime.BitmapType.RGB, vip_sharp.VIPRuntime.BitmapFilter.Linear, vip_sharp.VIPRuntime.BitmapClamp.Clamp, @"knob.png");
__knoblist = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.Bitmap(_this.__knob, vip_sharp.VIPRuntime.BitmapBlend.Replace, 0,0,4,4,vip_sharp.VIPRuntime.PositionRef.cc);
}, true);
__sliderlist = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.ColorSave();
vip_sharp.VIPRuntime.Instance.Color(6);
vip_sharp.VIPRuntime.Instance.Circle(0,0,0.5,10,true);
vip_sharp.VIPRuntime.Instance.ColorRestore();
}, false);
this.__upuv= new vip_sharp.BipolarArray<__tvector>(4) {new __tvector {__x = 0,__y = 1},new __tvector {__x = 0,__y = 0},new __tvector {__x = 0.33,__y = 0},new __tvector {__x = 0.33,__y = 1}};
this.__downuv= new vip_sharp.BipolarArray<__tvector>(4) {new __tvector {__x = 0.66,__y = 1},new __tvector {__x = 0.66,__y = 0},new __tvector {__x = 1,__y = 0},new __tvector {__x = 1,__y = 1}};
this.__swstate = 0;
this.__cnt = 0;
this.__knobvar = 0;
this.__slidervar = 0;
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
public vip_sharp.VIPRuntime.DisplayList __arial_null;
public vip_sharp.VIPRuntime.DisplayList __arial_smiley;
public vip_sharp.VIPRuntime.DisplayList __arial_smiley_filled;
public vip_sharp.VIPRuntime.DisplayList __arial_heart;
public vip_sharp.VIPRuntime.DisplayList __arial_diamond;
public vip_sharp.VIPRuntime.DisplayList __arial_clover;
public vip_sharp.VIPRuntime.DisplayList __arial_ace;
public vip_sharp.VIPRuntime.DisplayList __arial_big_dot;
public vip_sharp.VIPRuntime.DisplayList __arial_quad_big_dot;
public vip_sharp.VIPRuntime.DisplayList __arial_open_circle;
public vip_sharp.VIPRuntime.DisplayList __arial_circle_filled;
public vip_sharp.VIPRuntime.DisplayList __arial_male_sign;
public vip_sharp.VIPRuntime.DisplayList __arial_female_sign;
public vip_sharp.VIPRuntime.DisplayList __arial_note;
public vip_sharp.VIPRuntime.DisplayList __arial_double_note;
public vip_sharp.VIPRuntime.DisplayList __arial_sun;
public vip_sharp.VIPRuntime.DisplayList __arial_triangle_right;
public vip_sharp.VIPRuntime.DisplayList __arial_triangle_left;
public vip_sharp.VIPRuntime.DisplayList __arial_arrow_up_down;
public vip_sharp.VIPRuntime.DisplayList __arial_double_exclamation;
public vip_sharp.VIPRuntime.DisplayList __arial_pi_sign;
public vip_sharp.VIPRuntime.DisplayList __arial_double_s;
public vip_sharp.VIPRuntime.DisplayList __arial_fat_stripe;
public vip_sharp.VIPRuntime.DisplayList __arial_arrow_up_down_bottom;
public vip_sharp.VIPRuntime.DisplayList __arial_up_arrow;
public vip_sharp.VIPRuntime.DisplayList __arial_down_arrow;
public vip_sharp.VIPRuntime.DisplayList __arial_right_arrow;
public vip_sharp.VIPRuntime.DisplayList __arial_left_arrow;
public vip_sharp.VIPRuntime.DisplayList __arial_fs;
public vip_sharp.VIPRuntime.DisplayList __arial_double_arrow;
public vip_sharp.VIPRuntime.DisplayList __arial_triangle_up;
public vip_sharp.VIPRuntime.DisplayList __arial_triangle_down;
public vip_sharp.VIPRuntime.DisplayList __arial_space;
public vip_sharp.VIPRuntime.DisplayList __arial_exlamation_point;
public vip_sharp.VIPRuntime.DisplayList __arial_double_quote;
public vip_sharp.VIPRuntime.DisplayList __arial_number_sign;
public vip_sharp.VIPRuntime.DisplayList __arial_dollar_sign;
public vip_sharp.VIPRuntime.DisplayList __arial_percent;
public vip_sharp.VIPRuntime.DisplayList __arial_ampersand;
public vip_sharp.VIPRuntime.DisplayList __arial_apostrophe;
public vip_sharp.VIPRuntime.DisplayList __arial_left_parenthesis;
public vip_sharp.VIPRuntime.DisplayList __arial_right_parenthesis;
public vip_sharp.VIPRuntime.DisplayList __arial_asterisk;
public vip_sharp.VIPRuntime.DisplayList __arial_plus_sign;
public vip_sharp.VIPRuntime.DisplayList __arial_comma;
public vip_sharp.VIPRuntime.DisplayList __arial_minus;
public vip_sharp.VIPRuntime.DisplayList __arial_period;
public vip_sharp.VIPRuntime.DisplayList __arial_slash;
public vip_sharp.VIPRuntime.DisplayList __arial_nr_0;
public vip_sharp.VIPRuntime.DisplayList __arial_nr_1;
public vip_sharp.VIPRuntime.DisplayList __arial_nr_2;
public vip_sharp.VIPRuntime.DisplayList __arial_nr_3;
public vip_sharp.VIPRuntime.DisplayList __arial_nr_4;
public vip_sharp.VIPRuntime.DisplayList __arial_nr_5;
public vip_sharp.VIPRuntime.DisplayList __arial_nr_6;
public vip_sharp.VIPRuntime.DisplayList __arial_nr_7;
public vip_sharp.VIPRuntime.DisplayList __arial_nr_8;
public vip_sharp.VIPRuntime.DisplayList __arial_nr_9;
public vip_sharp.VIPRuntime.DisplayList __arial_colon;
public vip_sharp.VIPRuntime.DisplayList __arial_semicolon;
public vip_sharp.VIPRuntime.DisplayList __arial_less_than;
public vip_sharp.VIPRuntime.DisplayList __arial_equal_sign;
public vip_sharp.VIPRuntime.DisplayList __arial_greater_than;
public vip_sharp.VIPRuntime.DisplayList __arial_question_mark;
public vip_sharp.VIPRuntime.DisplayList __arial_at_symbol;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_a;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_b;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_c;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_d;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_e;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_f;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_g;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_h;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_i;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_j;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_k;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_l;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_m;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_n;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_o;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_p;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_q;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_r;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_s;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_t;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_u;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_v;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_w;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_x;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_y;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_z;
public vip_sharp.VIPRuntime.DisplayList __arial_left_square_bracket;
public vip_sharp.VIPRuntime.DisplayList __arial_back_slash;
public vip_sharp.VIPRuntime.DisplayList __arial_right_square_bracket;
public vip_sharp.VIPRuntime.DisplayList __arial_caret;
public vip_sharp.VIPRuntime.DisplayList __arial_underline;
public vip_sharp.VIPRuntime.DisplayList __arial_accent;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_la;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lb;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lc;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_ld;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_le;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lf;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lg;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lh;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_li;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lj;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lk;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_ll;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lm;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_ln;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lo;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lp;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lq;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lr;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_ls;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lt;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lu;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lv;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lw;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lx;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_ly;
public vip_sharp.VIPRuntime.DisplayList __arial_lt_lz;
public vip_sharp.VIPRuntime.DisplayList __arial_left_bracket_2;
public vip_sharp.VIPRuntime.DisplayList __arial_vertical_line;
public vip_sharp.VIPRuntime.DisplayList __arial_right_bracket_2;
public vip_sharp.VIPRuntime.DisplayList __arial_tilde;
public vip_sharp.VIPRuntime.DisplayList __arial_delete;
public vip_sharp.VIPRuntime.BitmapRes __stripe = null;
public vip_sharp.VIPRuntime.BitmapRes __switch = null;
public vip_sharp.VIPRuntime.BitmapRes __knob = null;
public vip_sharp.VIPRuntime.DisplayList __knoblist;
public vip_sharp.VIPRuntime.DisplayList __sliderlist;
public class __tvector { 
public double __x;
public double __y;
}
public vip_sharp.BipolarArray<__tvector> __upuv;
public vip_sharp.BipolarArray<__tvector> __downuv;
public int __swstate;
public double __cnt;
public double __knobvar;
public double __slidervar;
public override void Run() {
vip_sharp.BipolarArray<char> __sdata2= new vip_sharp.BipolarArray<char>(15,"Werkt Het ?");
vip_sharp.BipolarArray<char> __sdata= new vip_sharp.BipolarArray<char>("\x1 Ja, het Werkt");
vip_sharp.BipolarArray<char> __tmpbuffer= new vip_sharp.BipolarArray<char>(15);
vip_sharp.VIPRuntime.Instance.Color(23);
vip_sharp.VIPRuntime.Instance.DrawString(0,0,vip_sharp.VIPRuntime.PositionRef.cc,__sdata,0,GlobalState.MainClass.__vip_null,1,1,1.2);
vip_sharp.VIPRuntime.Instance.DrawString(0,2,vip_sharp.VIPRuntime.PositionRef.cc,__sdata2,0,GlobalState.MainClass.__vip_null,1,1,1.2);
vip_sharp.VIPRuntime.Instance.Color(5);
vip_sharp.VIPRuntime.Instance.DrawString(-3,6,vip_sharp.VIPRuntime.PositionRef.lc,"multiline test 2 | worked yay!",0,GlobalState.MainClass.__arial_null,0.3,0.6,1.2);
GlobalState.MainClass.__slidervar = Convert.ToDouble(vip_sharp.VIPRuntime.Instance.Slider(1, this,-13,10,1,8,vip_sharp.VIPRuntime.PositionRef.cc,45,GlobalState.MainClass.__slidervar,-5,200,vip_sharp.VIPRuntime.HoverBox.Hover,0,GlobalState.MainClass.__sliderlist));
vip_sharp.VIPRuntime.Instance.Color(23);
vip_sharp.VIPRuntime.Instance.Format(__tmpbuffer,"%.02f",GlobalState.MainClass.__slidervar);
vip_sharp.VIPRuntime.Instance.DrawString(-12,13,vip_sharp.VIPRuntime.PositionRef.lc,__tmpbuffer,0,GlobalState.MainClass.__arial_null,0.4,0.7,1.2);
GlobalState.MainClass.__knobvar = Convert.ToDouble(vip_sharp.VIPRuntime.Instance.RotaryKnob(2, this,11,-11,2,GlobalState.MainClass.__knobvar,-20,20,Convert.ToDouble(-50),Convert.ToDouble(50),vip_sharp.VIPRuntime.HoverBox.Hover,0,GlobalState.MainClass.__knoblist));
vip_sharp.VIPRuntime.Instance.Format(__tmpbuffer,"%.02f",GlobalState.MainClass.__knobvar);
vip_sharp.VIPRuntime.Instance.DrawString(11,-8,vip_sharp.VIPRuntime.PositionRef.cc,__tmpbuffer,0,GlobalState.MainClass.__arial_null,0.4,0.7,1.2);
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Rotate(-25);
int __up = 0;
__up = Convert.ToInt32(vip_sharp.VIPRuntime.Instance.HotSpot(3, this,9,9,5,5,vip_sharp.VIPRuntime.PositionRef.cl,__up,vip_sharp.VIPRuntime.HotSpotTrigger.Selected,vip_sharp.VIPRuntime.HotSpotType.Momentary,Convert.ToInt32(1),Convert.ToInt32(0),vip_sharp.VIPRuntime.HoverBox.Hover));
if(Convert.ToBoolean(__up))
{
GlobalState.MainClass.__swstate = Convert.ToInt32(1);
}
int __down = 0;
__down = Convert.ToInt32(vip_sharp.VIPRuntime.Instance.HotSpot(4, this,9,9,5,5,vip_sharp.VIPRuntime.PositionRef.cu,__down,vip_sharp.VIPRuntime.HotSpotTrigger.Selected,vip_sharp.VIPRuntime.HotSpotType.Momentary,Convert.ToInt32(1),Convert.ToInt32(0),vip_sharp.VIPRuntime.HoverBox.Hover));
if(Convert.ToBoolean(__down))
{
GlobalState.MainClass.__swstate = Convert.ToInt32(0);
}
if(Convert.ToBoolean(GlobalState.MainClass.__swstate))
{
vip_sharp.VIPRuntime.Instance.Bitmap(GlobalState.MainClass.__switch, vip_sharp.VIPRuntime.BitmapBlend.Replace, 9,9,5,5,vip_sharp.VIPRuntime.PositionRef.cl,GlobalState.MainClass.__upuv);
vip_sharp.VIPRuntime.Instance.Color(6);
vip_sharp.VIPRuntime.Instance.DrawString(6,9,vip_sharp.VIPRuntime.PositionRef.rc,"State:  ON",0,GlobalState.MainClass.__arial_null,0.4,0.7,1.2);
}
else
{
vip_sharp.VIPRuntime.Instance.Bitmap(GlobalState.MainClass.__switch, vip_sharp.VIPRuntime.BitmapBlend.Replace, 9,9,5,5,vip_sharp.VIPRuntime.PositionRef.cu,GlobalState.MainClass.__downuv);
vip_sharp.VIPRuntime.Instance.Color(5);
vip_sharp.VIPRuntime.Instance.DrawString(6,9,vip_sharp.VIPRuntime.PositionRef.rc,"State: OFF",0,GlobalState.MainClass.__arial_null,0.4,0.7,1.2);
}
vip_sharp.VIPRuntime.Instance.MatrixRestore();
vip_sharp.VIPRuntime.Instance.Color(4);
int __b = 0;
__b = Convert.ToInt32(vip_sharp.VIPRuntime.Instance.HotSpot(5, this,0,-3,3,3,vip_sharp.VIPRuntime.PositionRef.cc,__b,vip_sharp.VIPRuntime.HotSpotTrigger.SelectEdge,vip_sharp.VIPRuntime.HotSpotType.Momentary,Convert.ToInt32(1),Convert.ToInt32(0),vip_sharp.VIPRuntime.HoverBox.Always,GlobalState.MainClass.__stripe));
if(Convert.ToBoolean(__b))
{
GlobalState.MainClass.__cnt = Convert.ToDouble(GlobalState.MainClass.__cnt+0.15);
}
vip_sharp.VIPRuntime.Instance.Format(__tmpbuffer,"cnt: %.02f",GlobalState.MainClass.__cnt);
vip_sharp.VIPRuntime.Instance.DrawString(0,-5,vip_sharp.VIPRuntime.PositionRef.lc,__tmpbuffer,0,GlobalState.MainClass.__arial_null,0.4,0.7,1.2);
vip_sharp.VIPRuntime.Instance.Translate(2, 2);
vip_sharp.VIPRuntime.Instance.Rotate(50);
vip_sharp.VIPRuntime.Instance.Scale(4);
__b = Convert.ToInt32(vip_sharp.VIPRuntime.Instance.HotSpot(6, this,0,-3,1,1,vip_sharp.VIPRuntime.PositionRef.cc,__b,vip_sharp.VIPRuntime.HotSpotTrigger.Selected,vip_sharp.VIPRuntime.HotSpotType.Momentary,Convert.ToInt32(1),Convert.ToInt32(0),vip_sharp.VIPRuntime.HoverBox.Always,GlobalState.MainClass.__stripe));
if(Convert.ToBoolean(__b))
{
vip_sharp.VIPRuntime.Instance.DrawString(1,-3,vip_sharp.VIPRuntime.PositionRef.lc,"WOOHOO",0,GlobalState.MainClass.__arial_null,0.4,0.7,1.2);
}
}
}
