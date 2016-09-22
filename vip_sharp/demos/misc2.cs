using System;
using System.Linq;
using System.Collections.Generic;
public static class GlobalState { public static MainClass MainClass; }
public class MainClass : vip_sharp.VIPRuntime.VIPObject {
public MainClass() {
GlobalState.MainClass = this;
__cdu_null = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_smiley = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_smiley_filled = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_heart = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_diamond = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_clover = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_ace = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_big_dot = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_quad_big_dot = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_open_circle = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_circle_filled = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_male_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_female_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_note = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_double_note = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_sun = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_triangle_right = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_triangle_left = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_arrow_up_down = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_double_exclamation = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_pi_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_double_s = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_fat_stripe = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_arrow_up_down_bottom = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_up_arrow = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_down_arrow = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_right_arrow = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_left_arrow = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_fs = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_double_arrow = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0138,0.0845,0.1312,0.0845);
vip_sharp.VIPRuntime.Instance.Line(0.0138,0.0845,0.0431,0.0393);
vip_sharp.VIPRuntime.Instance.Line(0.1312,0.0845,0.1019,0.0393);
vip_sharp.VIPRuntime.Instance.Line(0.0138,0.0845,0.0431,0.1297);
vip_sharp.VIPRuntime.Instance.Line(0.1312,0.0845,0.1019,0.1297);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_triangle_up = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0301,0,0.116,0);
vip_sharp.VIPRuntime.Instance.Line(0.0301,0,0.0731,0.1695);
vip_sharp.VIPRuntime.Instance.Line(0.0731,0.1695,0.116,0);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_triangle_down = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_space = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_exlamation_point = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0635,0.1501,0.0635,0.1204);
vip_sharp.VIPRuntime.Instance.Line(0.068,0.1598,0.068,0.0952);
vip_sharp.VIPRuntime.Instance.Line(0.0815,0.1501,0.0815,0.1204);
vip_sharp.VIPRuntime.Instance.Line(0.077,0.1598,0.077,0.0952);
vip_sharp.VIPRuntime.Instance.Line(0.0635,0.0174,0.0635,0.0052);
vip_sharp.VIPRuntime.Instance.Line(0.068,0.02,0.068,0.0026);
vip_sharp.VIPRuntime.Instance.Line(0.0815,0.0174,0.0815,0.0052);
vip_sharp.VIPRuntime.Instance.Line(0.077,0.02,0.077,0.0026);
vip_sharp.VIPRuntime.Instance.Line(0.0725,0.0226,0.0725,0);
vip_sharp.VIPRuntime.Instance.Line(0.0725,0.1695,0.0725,0.07);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_double_quote = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0879,0.1622,0.0879,0.169);
vip_sharp.VIPRuntime.Instance.Line(0.0879,0.169,0.106,0.169);
vip_sharp.VIPRuntime.Instance.Line(0.106,0.169,0.0879,0.1283);
vip_sharp.VIPRuntime.Instance.Line(0.0585,0.169,0.0405,0.1283);
vip_sharp.VIPRuntime.Instance.Line(0.0405,0.169,0.0585,0.169);
vip_sharp.VIPRuntime.Instance.Line(0.0405,0.1622,0.0405,0.169);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_number_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0483,0.0456,0.0483,0.1312);
vip_sharp.VIPRuntime.Instance.Line(0.0964,0.0456,0.0964,0.1312);
vip_sharp.VIPRuntime.Instance.Line(0.0292,0.1104,0.1149,0.1104);
vip_sharp.VIPRuntime.Instance.Line(0.0292,0.0622,0.1149,0.0622);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_dollar_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0301,0,0.116,0);
vip_sharp.VIPRuntime.Instance.Line(0.0301,0,0.0731,0.1695);
vip_sharp.VIPRuntime.Instance.Line(0.0731,0.1695,0.116,0);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_percent = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Circle(0.094,0.0294,0.0203,12,false);
vip_sharp.VIPRuntime.Instance.Circle(0.0488,0.1401,0.0203,12,false);
vip_sharp.VIPRuntime.Instance.Line(0.029,0,0.1133,0.1694);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_ampersand = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.0643,0.1427,0.0275,0.0275,152,10,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.072,0.0419,0.0424,0.0424,168,88,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0679,0.0395,0.0395,0.0395,275,188,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.3604,-0.2666,0.4779,0.4779,324,318,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0876,0.0595,0.0591,0.0591,272,267,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.1495,0.1856,0.1163,0.1163,245,229,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0769,0.1381,0.0327,0.0327,344,268,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0851,0.0527,0.0577,0.0577,306,281,10,false);
vip_sharp.VIPRuntime.Instance.Line(0.0285,0.0636,0.0285,0.0433);
vip_sharp.VIPRuntime.Instance.Line(0.0624,0.0004,0.0805,0.0004);
vip_sharp.VIPRuntime.Instance.Line(0.0619,0.1091,0.1144,0.0004);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_apostrophe = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0635,0.1622,0.0635,0.169);
vip_sharp.VIPRuntime.Instance.Line(0.0635,0.169,0.0815,0.169);
vip_sharp.VIPRuntime.Instance.Line(0.0815,0.169,0.0635,0.1283);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_left_parenthesis = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.1718,0.0847,0.1174,0.1174,-44,-136,18,false);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_right_parenthesis = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(-0.0268,0.0847,0.1174,0.1174,136,44,18,false);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_asterisk = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0426,0.0944,0.1013,0.169);
vip_sharp.VIPRuntime.Instance.Line(0.0426,0.169,0.1013,0.0944);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1328,0.1149,0.1328);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_plus_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.029,0.0845,0.1149,0.0845);
vip_sharp.VIPRuntime.Instance.Line(0.0719,0.1274,0.0719,0.0416);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_comma = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0815,0.0203,0.0635,-0.0203);
vip_sharp.VIPRuntime.Instance.Line(0.0635,0.0203,0.0815,0.0203);
vip_sharp.VIPRuntime.Instance.Line(0.0635,0.0136,0.0635,0.0203);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_minus = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.029,0.0845,0.1133,0.0845);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_period = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Circle(0.0725,0.0113,0.0113,10,true);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_slash = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.029,0,0.1149,0.1695);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_nr_0 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.1027,0.0138,0.1165,0.0415);
vip_sharp.VIPRuntime.Instance.Line(0.0889,0,0.1027,0.0138);
vip_sharp.VIPRuntime.Instance.Line(0.0428,0.0138,0.0566,0);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.0415,0.0428,0.0138);
vip_sharp.VIPRuntime.Instance.Line(0.0428,0.1547,0.029,0.1271);
vip_sharp.VIPRuntime.Instance.Line(0.0566,0.1685,0.0428,0.1547);
vip_sharp.VIPRuntime.Instance.Line(0.1027,0.1547,0.1165,0.1271);
vip_sharp.VIPRuntime.Instance.Line(0.0889,0.1685,0.1027,0.1547);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1271,0.029,0.0415);
vip_sharp.VIPRuntime.Instance.Line(0.0889,0.1685,0.0566,0.1685);
vip_sharp.VIPRuntime.Instance.Line(0.1165,0.0415,0.1165,0.1271);
vip_sharp.VIPRuntime.Instance.Line(0.0566,0,0.0889,0);
vip_sharp.VIPRuntime.Instance.Line(0.029,0,0.1165,0.1685);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_nr_1 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.029,0,0.1165,0);
vip_sharp.VIPRuntime.Instance.Line(0.0728,0.1685,0.0378,0.1386);
vip_sharp.VIPRuntime.Instance.Line(0.0728,0,0.0728,0.1685);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_nr_2 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.0711,0.125,0.0445,0.0445,-70,120,10,false);
vip_sharp.VIPRuntime.Instance.Line(0.029,0,0.1096,0.1027);
vip_sharp.VIPRuntime.Instance.Line(0.029,0,0.1165,0);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_nr_3 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.0711,0.0439,0.0455,0.0455,28,230,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0715,0.1257,0.044,0.044,-70,152,10,false);
vip_sharp.VIPRuntime.Instance.Line(0.0901,0.0859,0.0645,0.0859);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_nr_4 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0287,0.0572,0.0992,0.1688);
vip_sharp.VIPRuntime.Instance.Line(0.0287,0.0572,0.1153,0.0572);
vip_sharp.VIPRuntime.Instance.Line(0.0992,-0.0004,0.0992,0.1688);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_nr_5 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.0635,0.0528,0.053,0.053,-40,230,15,false);
vip_sharp.VIPRuntime.Instance.Line(0.0289,0.168,0.0289,0.093);
vip_sharp.VIPRuntime.Instance.Line(0.1164,0.168,0.0289,0.168);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_nr_6 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.0911,0.1055,0.0641,0.0641,-80,20,15,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0719,0.0579,0.0458,0.0458,-73,73,15,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0719,0.0439,0.044,0.044,90,270,15,false);
vip_sharp.VIPRuntime.Instance.Line(0.1157,0.0714,0.1159,0.0439);
vip_sharp.VIPRuntime.Instance.Line(0.0282,0.1176,0.0282,0.0393);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_nr_7 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0538,0.0011,0.116,0.1689);
vip_sharp.VIPRuntime.Instance.Line(0.0285,0.1689,0.116,0.1689);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_nr_8 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Circle(0.0727,0.0425,0.0438,25,false);
vip_sharp.VIPRuntime.Instance.Circle(0.0727,0.127,0.0426,25,false);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_nr_9 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.005,0.1078,0.1129,0.1129,160,85,15,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0735,0.1248,0.0438,0.0438,-90,90,15,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0735,0.1193,0.0438,0.0438,90,270,15,false);
vip_sharp.VIPRuntime.Instance.Line(0.1173,0.1248,0.1173,0.1179);
vip_sharp.VIPRuntime.Instance.Line(0.0297,0.1248,0.0297,0.1179);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_colon = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Circle(0.0725,0.0852,0.0115,12,true);
vip_sharp.VIPRuntime.Instance.Circle(0.0725,0.0115,0.0115,12,true);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_semicolon = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Circle(0.0725,0.0852,0.0115,12,true);
vip_sharp.VIPRuntime.Instance.Line(0.0635,0.0136,0.0635,0.0203);
vip_sharp.VIPRuntime.Instance.Line(0.0635,0.0203,0.0815,0.0203);
vip_sharp.VIPRuntime.Instance.Line(0.0815,0.0203,0.0635,-0.0203);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_less_than = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.029,0.0845,0.1165,0.0361);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.0845,0.1165,0.1329);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_equal_sign = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1084,0.115,0.1084);
vip_sharp.VIPRuntime.Instance.Line(0.0285,0.0636,0.116,0.0636);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_greater_than = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.1156,0.082,0.028,0.0336);
vip_sharp.VIPRuntime.Instance.Line(0.1156,0.082,0.028,0.1304);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_question_mark = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.0906,0.0768,0.0182,0.0182,300,263,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.1413,0.019,0.0943,0.0943,326,313,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0749,0.1307,0.0361,0.0361,92,-72,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0715,0.1301,0.0394,0.0394,161,93,10,false);
vip_sharp.VIPRuntime.Instance.Line(0.0725,0.0746,0.0725,0.052);
vip_sharp.VIPRuntime.Instance.Circle(0.0725,0.0068,0.0068,10,false);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_at_symbol = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Circle(0.0586,0.1394,0.0294,10,false);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_a = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0725,0.169,0.116,0);
vip_sharp.VIPRuntime.Instance.Line(0.029,0,0.0725,0.169);
vip_sharp.VIPRuntime.Instance.Line(0.1012,0.0576,0.0433,0.0576);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_b = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.0768,0.1302,0.0382,0.0382,185,-5,8,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0675,0.0443,0.0494,0.0494,155,-15,8,false);
vip_sharp.VIPRuntime.Instance.Line(0.0892,0,0.029,0);
vip_sharp.VIPRuntime.Instance.Line(0.029,0,0.029,0.1682);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.0921,0.08,0.0921);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1682,0.08,0.1682);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_c = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.0755,0.1249,0.0449,0.0449,-90,75,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0755,0.0442,0.0449,0.0449,110,270,8,false);
vip_sharp.VIPRuntime.Instance.Line(0.0306,0.1249,0.0306,0.0442);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_d = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.067,0.0472,0.0495,0.0495,90,161,6,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0733,0.1252,0.0433,0.0433,90,1,6,false);
vip_sharp.VIPRuntime.Instance.Line(0.0359,0.1686,0.0733,0.1686);
vip_sharp.VIPRuntime.Instance.Line(0.082,0,0.0359,0);
vip_sharp.VIPRuntime.Instance.Line(0.1165,0.0461,0.1165,0.1271);
vip_sharp.VIPRuntime.Instance.Line(0.082,0,0.029,0);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1686,0.0728,0.1686);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1686,0.029,0);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_e = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.029,0.0967,0.1022,0.0967);
vip_sharp.VIPRuntime.Instance.Line(0.029,0,0.1183,0);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1684,0.029,0);
vip_sharp.VIPRuntime.Instance.Line(0.1183,0.1684,0.029,0.1684);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_f = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1685,0.029,0);
vip_sharp.VIPRuntime.Instance.Line(0.115,0.1685,0.029,0.1685);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.0967,0.1022,0.0967);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_g = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.0728,0.0422,0.044,0.044,96,264,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0728,0.1268,0.044,0.044,-84,84,10,false);
vip_sharp.VIPRuntime.Instance.Line(0.1165,0.0833,0.0866,0.0833);
vip_sharp.VIPRuntime.Instance.Line(0.1165,0.0373,0.1165,0.0833);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1317,0.029,0.0373);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_h = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.115,0.1708,0.115,-0.0018);
vip_sharp.VIPRuntime.Instance.Line(0.115,0.0941,0.029,0.0941);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1708,0.029,-0.0018);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_i = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0449,0.1686,0.1001,0.1686);
vip_sharp.VIPRuntime.Instance.Line(0.0449,0,0.1001,0);
vip_sharp.VIPRuntime.Instance.Line(0.0725,0,0.0725,0.1686);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_j = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.0724,0.0443,0.0438,0.0438,93,275,10,false);
vip_sharp.VIPRuntime.Instance.Line(0.116,0.1676,0.116,0.0397);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_k = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0523,0.0875,0.1167,0);
vip_sharp.VIPRuntime.Instance.Line(0.0292,0.0575,0.1167,0.1689);
vip_sharp.VIPRuntime.Instance.Line(0.0298,0.1689,0.0298,0);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_l = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.029,0,0.115,0);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.169,0.029,0);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_m = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0728,0.0928,0.1165,0.1688);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1688,0.0728,0.0928);
vip_sharp.VIPRuntime.Instance.Line(0.1165,-0.0001,0.1165,0.1688);
vip_sharp.VIPRuntime.Instance.Line(0.029,-0.0001,0.029,0.1688);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_n = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.1163,0,0.1163,0.1694);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1694,0.1163,0);
vip_sharp.VIPRuntime.Instance.Line(0.029,0,0.029,0.1694);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_o = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.0836,0.0324,0.0322,0.0322,90,180,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0613,0.0324,0.0322,0.0322,180,270,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0613,0.1367,0.0322,0.0322,-90,0,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0836,0.1367,0.0322,0.0322,0,90,10,false);
vip_sharp.VIPRuntime.Instance.Line(0.0609,0.1689,0.0836,0.1689);
vip_sharp.VIPRuntime.Instance.Line(0.0291,0.0324,0.0291,0.1371);
vip_sharp.VIPRuntime.Instance.Line(0.0836,0.0001,0.0613,0.0001);
vip_sharp.VIPRuntime.Instance.Line(0.1159,0.1371,0.1159,0.0324);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_p = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.0719,0.1249,0.0444,0.0444,0,180,15,false);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.0806,0.0719,0.0806);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1693,0.029,0);
vip_sharp.VIPRuntime.Instance.Line(0.0719,0.1693,0.029,0.1693);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_q = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.0836,0.0324,0.0322,0.0322,90,180,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0613,0.0324,0.0322,0.0322,180,270,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0613,0.1367,0.0322,0.0322,-90,0,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0836,0.1367,0.0322,0.0322,0,90,10,false);
vip_sharp.VIPRuntime.Instance.Line(0.0609,0.1689,0.0836,0.1689);
vip_sharp.VIPRuntime.Instance.Line(0.0291,0.0324,0.0291,0.1371);
vip_sharp.VIPRuntime.Instance.Line(0.0836,0.0001,0.0613,0.0001);
vip_sharp.VIPRuntime.Instance.Line(0.1159,0.1371,0.1159,0.0324);
vip_sharp.VIPRuntime.Instance.Line(0.0731,0.0383,0.116,-0.0001);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_r = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.0697,0.1242,0.0463,0.0463,13,180,15,false);
vip_sharp.VIPRuntime.Instance.Line(0.0619,0.079,0.116,-0.0001);
vip_sharp.VIPRuntime.Instance.Line(0.0302,0.079,0.0799,0.079);
vip_sharp.VIPRuntime.Instance.Line(0.0302,0.1694,0.0302,-0.0001);
vip_sharp.VIPRuntime.Instance.Line(0.0799,0.1694,0.0302,0.1694);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_s = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.0711,0.1366,0.0449,0.0449,234,197,5,false);
vip_sharp.VIPRuntime.Instance.Arc(0.071,0.0442,0.0453,0.0453,244,17,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0772,0.124,0.0449,0.0449,60,-108,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0056,-0.1905,0.289,0.289,16,10,5,false);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_t = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0712,-0.0005,0.0712,0.1689);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1689,0.1134,0.1689);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_u = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Arc(0.0731,0.0426,0.0432,0.0432,96,264,15,false);
vip_sharp.VIPRuntime.Instance.Line(0.116,0.0378,0.116,0.1689);
vip_sharp.VIPRuntime.Instance.Line(0.0302,0.1689,0.0302,0.0378);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_v = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0725,-0.0001,0.1147,0.1693);
vip_sharp.VIPRuntime.Instance.Line(0.0304,0.1693,0.0725,-0.0001);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_w = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.116,-0.0005,0.116,0.1689);
vip_sharp.VIPRuntime.Instance.Line(0.0739,0.0842,0.116,-0.0005);
vip_sharp.VIPRuntime.Instance.Line(0.0317,-0.0005,0.0739,0.0842);
vip_sharp.VIPRuntime.Instance.Line(0.0317,0.1689,0.0317,-0.0005);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_x = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1693,0.1134,-0.0001);
vip_sharp.VIPRuntime.Instance.Line(0.029,-0.0001,0.1134,0.1693);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_y = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0725,0,0.0725,0.0863);
vip_sharp.VIPRuntime.Instance.Line(0.03,0.169,0.0725,0.0863);
vip_sharp.VIPRuntime.Instance.Line(0.0725,0.0863,0.116,0.169);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_z = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0295,0.169,0.1152,0.169);
vip_sharp.VIPRuntime.Instance.Line(0.1152,0.169,0.029,0);
vip_sharp.VIPRuntime.Instance.Line(0.029,0,0.1146,0);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_left_square_bracket = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.081,0.1695,0.029,0.1695);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1695,0.029,0);
vip_sharp.VIPRuntime.Instance.Line(0.029,0,0.081,0);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_back_slash = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0301,0.1695,0.116,0);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_right_square_bracket = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.064,0.1695,0.116,0.1695);
vip_sharp.VIPRuntime.Instance.Line(0.116,0.1695,0.116,0);
vip_sharp.VIPRuntime.Instance.Line(0.116,0,0.064,0);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_caret = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Translate(6, 12);
vip_sharp.VIPRuntime.Instance.ClosedLine(0,-6.693,6,-3.25,6,3.25,0,6.693,-6,3.25,-6,-3.25);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_underline = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0275,0,0.115,0);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_accent = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_lt_la = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_lt_lb = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0138,0,0.1312,0);
vip_sharp.VIPRuntime.Instance.Line(0.1312,0,0.1312,0.1695);
vip_sharp.VIPRuntime.Instance.Line(0.1312,0.1695,0.0138,0.1695);
vip_sharp.VIPRuntime.Instance.Line(0.0138,0.1695,0.0138,0);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_lc = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Circle(0.042,0.145,0.0225,8,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0855,0.0805,0.0349,0.0349,-90,75,10,false);
vip_sharp.VIPRuntime.Instance.Arc(0.0855,0.0442,0.0349,0.0349,95,260,10,false);
vip_sharp.VIPRuntime.Instance.Line(0.0505,0.0805,0.0505,0.0375);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_ld = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0725,0,0.0296,0.0529);
vip_sharp.VIPRuntime.Instance.Line(0.0725,0,0.1154,0.0529);
vip_sharp.VIPRuntime.Instance.Line(0.0725,0,0.0725,0.1695);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_le = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_lt_lf = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Circle(0.042,0.145,0.0225,8,false);
vip_sharp.VIPRuntime.Instance.Line(0.057,0.1105,0.057,0.003);
vip_sharp.VIPRuntime.Instance.Line(0.057,0.1105,0.121,0.1105);
vip_sharp.VIPRuntime.Instance.Line(0.057,0.055,0.112,0.055);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_lg = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_lt_lh = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0294,0.0596,0.0725,0.0347);
vip_sharp.VIPRuntime.Instance.Line(0.0294,0.1094,0.0294,0.0596);
vip_sharp.VIPRuntime.Instance.Line(0.0725,0.1343,0.0294,0.1094);
vip_sharp.VIPRuntime.Instance.Line(0.1156,0.1094,0.0725,0.1343);
vip_sharp.VIPRuntime.Instance.Line(0.1156,0.0596,0.1156,0.1094);
vip_sharp.VIPRuntime.Instance.Line(0.0725,0.0347,0.1156,0.0596);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_li = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_lt_lj = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_lt_lk = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_lt_ll = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(-0.0012,0.085,0.045,0.148);
vip_sharp.VIPRuntime.Instance.Line(-0.0012,0.085,0.045,0.022);
vip_sharp.VIPRuntime.Instance.Line(-0.0012,0.085,0.132,0.085);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_lm = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0301,0.0764,0.0753,-0.0005);
vip_sharp.VIPRuntime.Instance.Line(0.0753,-0.0005,0.116,0.169);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_ln = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_lt_lo = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1695,0.029,0);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1695,0.116,0.1695);
vip_sharp.VIPRuntime.Instance.Line(0.116,0.1695,0.116,0);
vip_sharp.VIPRuntime.Instance.Line(0.029,0,0.116,0);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_lp = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_lt_lq = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_lt_lr = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.094,0.148,0.132,0.085);
vip_sharp.VIPRuntime.Instance.Line(0.094,0.022,0.132,0.085);
vip_sharp.VIPRuntime.Instance.Line(-0.0012,0.085,0.132,0.085);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_ls = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_lt_lt = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_lt_lu = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0296,0.117,0.0725,0.1695);
vip_sharp.VIPRuntime.Instance.Line(0.115,0.117,0.0725,0.1695);
vip_sharp.VIPRuntime.Instance.Line(0.0725,0,0.0725,0.1695);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_lt_lv = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_lt_lw = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_lt_lx = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_lt_ly = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_lt_lz = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
}, false);
__cdu_left_bracket_2 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.081,0.1695,0.029,0.1695);
vip_sharp.VIPRuntime.Instance.Line(0.029,0.1695,0.029,0);
vip_sharp.VIPRuntime.Instance.Line(0.029,0,0.081,0);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_vertical_line = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0725,0.1695,0.0725,0);
vip_sharp.VIPRuntime.Instance.Line(0.0725,0.1695,0.1154,0.1265);
vip_sharp.VIPRuntime.Instance.Line(0.0725,0.1695,0.0296,0.1265);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_right_bracket_2 = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.064,0.1695,0.116,0.1695);
vip_sharp.VIPRuntime.Instance.Line(0.116,0.1695,0.116,0);
vip_sharp.VIPRuntime.Instance.Line(0.116,0,0.064,0);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
__cdu_tilde = new vip_sharp.VIPRuntime.DisplayList(this, _this => {
vip_sharp.VIPRuntime.Instance.MatrixSave();
vip_sharp.VIPRuntime.Instance.Line(0.0138,0.0845,0.1312,0.0845);
vip_sharp.VIPRuntime.Instance.Line(0.0138,0.0845,0.0431,0.0393);
vip_sharp.VIPRuntime.Instance.Line(0.1312,0.0845,0.1019,0.0393);
vip_sharp.VIPRuntime.Instance.Line(0.0138,0.0845,0.0431,0.1297);
vip_sharp.VIPRuntime.Instance.Line(0.1312,0.0845,0.1019,0.1297);
vip_sharp.VIPRuntime.Instance.MatrixRestore();
}, false);
}
public vip_sharp.VIPRuntime.DisplayList __cdu_null;
public vip_sharp.VIPRuntime.DisplayList __cdu_smiley;
public vip_sharp.VIPRuntime.DisplayList __cdu_smiley_filled;
public vip_sharp.VIPRuntime.DisplayList __cdu_heart;
public vip_sharp.VIPRuntime.DisplayList __cdu_diamond;
public vip_sharp.VIPRuntime.DisplayList __cdu_clover;
public vip_sharp.VIPRuntime.DisplayList __cdu_ace;
public vip_sharp.VIPRuntime.DisplayList __cdu_big_dot;
public vip_sharp.VIPRuntime.DisplayList __cdu_quad_big_dot;
public vip_sharp.VIPRuntime.DisplayList __cdu_open_circle;
public vip_sharp.VIPRuntime.DisplayList __cdu_circle_filled;
public vip_sharp.VIPRuntime.DisplayList __cdu_male_sign;
public vip_sharp.VIPRuntime.DisplayList __cdu_female_sign;
public vip_sharp.VIPRuntime.DisplayList __cdu_note;
public vip_sharp.VIPRuntime.DisplayList __cdu_double_note;
public vip_sharp.VIPRuntime.DisplayList __cdu_sun;
public vip_sharp.VIPRuntime.DisplayList __cdu_triangle_right;
public vip_sharp.VIPRuntime.DisplayList __cdu_triangle_left;
public vip_sharp.VIPRuntime.DisplayList __cdu_arrow_up_down;
public vip_sharp.VIPRuntime.DisplayList __cdu_double_exclamation;
public vip_sharp.VIPRuntime.DisplayList __cdu_pi_sign;
public vip_sharp.VIPRuntime.DisplayList __cdu_double_s;
public vip_sharp.VIPRuntime.DisplayList __cdu_fat_stripe;
public vip_sharp.VIPRuntime.DisplayList __cdu_arrow_up_down_bottom;
public vip_sharp.VIPRuntime.DisplayList __cdu_up_arrow;
public vip_sharp.VIPRuntime.DisplayList __cdu_down_arrow;
public vip_sharp.VIPRuntime.DisplayList __cdu_right_arrow;
public vip_sharp.VIPRuntime.DisplayList __cdu_left_arrow;
public vip_sharp.VIPRuntime.DisplayList __cdu_fs;
public vip_sharp.VIPRuntime.DisplayList __cdu_double_arrow;
public vip_sharp.VIPRuntime.DisplayList __cdu_triangle_up;
public vip_sharp.VIPRuntime.DisplayList __cdu_triangle_down;
public vip_sharp.VIPRuntime.DisplayList __cdu_space;
public vip_sharp.VIPRuntime.DisplayList __cdu_exlamation_point;
public vip_sharp.VIPRuntime.DisplayList __cdu_double_quote;
public vip_sharp.VIPRuntime.DisplayList __cdu_number_sign;
public vip_sharp.VIPRuntime.DisplayList __cdu_dollar_sign;
public vip_sharp.VIPRuntime.DisplayList __cdu_percent;
public vip_sharp.VIPRuntime.DisplayList __cdu_ampersand;
public vip_sharp.VIPRuntime.DisplayList __cdu_apostrophe;
public vip_sharp.VIPRuntime.DisplayList __cdu_left_parenthesis;
public vip_sharp.VIPRuntime.DisplayList __cdu_right_parenthesis;
public vip_sharp.VIPRuntime.DisplayList __cdu_asterisk;
public vip_sharp.VIPRuntime.DisplayList __cdu_plus_sign;
public vip_sharp.VIPRuntime.DisplayList __cdu_comma;
public vip_sharp.VIPRuntime.DisplayList __cdu_minus;
public vip_sharp.VIPRuntime.DisplayList __cdu_period;
public vip_sharp.VIPRuntime.DisplayList __cdu_slash;
public vip_sharp.VIPRuntime.DisplayList __cdu_nr_0;
public vip_sharp.VIPRuntime.DisplayList __cdu_nr_1;
public vip_sharp.VIPRuntime.DisplayList __cdu_nr_2;
public vip_sharp.VIPRuntime.DisplayList __cdu_nr_3;
public vip_sharp.VIPRuntime.DisplayList __cdu_nr_4;
public vip_sharp.VIPRuntime.DisplayList __cdu_nr_5;
public vip_sharp.VIPRuntime.DisplayList __cdu_nr_6;
public vip_sharp.VIPRuntime.DisplayList __cdu_nr_7;
public vip_sharp.VIPRuntime.DisplayList __cdu_nr_8;
public vip_sharp.VIPRuntime.DisplayList __cdu_nr_9;
public vip_sharp.VIPRuntime.DisplayList __cdu_colon;
public vip_sharp.VIPRuntime.DisplayList __cdu_semicolon;
public vip_sharp.VIPRuntime.DisplayList __cdu_less_than;
public vip_sharp.VIPRuntime.DisplayList __cdu_equal_sign;
public vip_sharp.VIPRuntime.DisplayList __cdu_greater_than;
public vip_sharp.VIPRuntime.DisplayList __cdu_question_mark;
public vip_sharp.VIPRuntime.DisplayList __cdu_at_symbol;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_a;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_b;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_c;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_d;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_e;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_f;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_g;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_h;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_i;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_j;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_k;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_l;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_m;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_n;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_o;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_p;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_q;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_r;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_s;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_t;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_u;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_v;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_w;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_x;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_y;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_z;
public vip_sharp.VIPRuntime.DisplayList __cdu_left_square_bracket;
public vip_sharp.VIPRuntime.DisplayList __cdu_back_slash;
public vip_sharp.VIPRuntime.DisplayList __cdu_right_square_bracket;
public vip_sharp.VIPRuntime.DisplayList __cdu_caret;
public vip_sharp.VIPRuntime.DisplayList __cdu_underline;
public vip_sharp.VIPRuntime.DisplayList __cdu_accent;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_la;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lb;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lc;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_ld;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_le;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lf;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lg;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lh;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_li;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lj;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lk;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_ll;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lm;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_ln;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lo;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lp;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lq;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lr;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_ls;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lt;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lu;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lv;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lw;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lx;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_ly;
public vip_sharp.VIPRuntime.DisplayList __cdu_lt_lz;
public vip_sharp.VIPRuntime.DisplayList __cdu_left_bracket_2;
public vip_sharp.VIPRuntime.DisplayList __cdu_vertical_line;
public vip_sharp.VIPRuntime.DisplayList __cdu_right_bracket_2;
public vip_sharp.VIPRuntime.DisplayList __cdu_tilde;
public override void Run() {
vip_sharp.VIPRuntime.Instance.Color(23);
vip_sharp.VIPRuntime.Instance.DrawString(0,0,vip_sharp.VIPRuntime.PositionRef.cc,"MEEP SST 1 2 3",0,GlobalState.MainClass.__cdu_null,5,5,0.4);
vip_sharp.VIPRuntime.Instance.Arc(-2,-10,4,4,0,45,10,false);
}
}
