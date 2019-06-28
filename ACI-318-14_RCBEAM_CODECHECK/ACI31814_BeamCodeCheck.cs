using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ACI_318_14_RCBEAM_CODECHECK
{
    public class codecheck
    {
        //測試用樣板
        public static void code9112(string AA, string BB, out string CC, out string MSG)
        {
            string A = AA;
            string B = BB;
            string C = "AAA";
            CC = A + B + C;
            MSG = "this is test message!";

        }

        //ACI 318-14 9.6.1.2 最小鋼筋量
        public static void Code9_6_1_2_SI(double Fc, double Fy, double bw, double d, double As, out double Rho, out double limitRho, out Boolean isPass, out string MSG)
        {
            double a = 0.25 * Math.Pow(Fc, 0.5) / Fy * bw * d;
            double b = 1.4 / Fy * bw * d;
            limitRho = Math.Max(a, b);
            Rho = As / (bw * d);
            if (Rho > limitRho)
            {
                isPass = true;
                MSG = "9.6.1.2 PASS";

            }

            else
            {
                isPass = false;
                MSG = "9.6.1.2 FAIL";
            }

        }

        //ACI 318-14 9.6.4.3 最小縱向扭力鋼筋量
        public static void Code9_6_4_3_SI(double Fc, double Fy, double bw, double Al, double Acp, double At, double s, double Ph, double Fyt, out double limitAl, out Boolean isPass, out string MSG)
        {
            double a = 0.42 * Math.Pow(Fc, 0.5) * Acp / Fy - (At / s) * Ph * Fyt / Fy;
            double b = 0.42 * Math.Pow(Fc, 0.5) * Acp / Fy - (0.175 * bw / Fyt) * Ph * Fyt / Fy;
            limitAl = Math.Min(a, b);
            if (Al > limitAl)
            {
                isPass = true;
                MSG = "9.6.4.3 PASS";
            }
            else
            {
                isPass = false;
                MSG = "9.6.4.3 FAIL";
            }
        }


        //ACI 318-14 25.2.1 & 25.2.3 鋼筋最小水平淨間距(梁、柱)
        public static void Code25_2_1_SI(string memType, double db, double dagg, double clearspace, out double minRequiredDistance, out bool isPass, out string MSG)
        {
            if (memType == "BEAM")
                minRequiredDistance = Math.Min(Math.Min(25, db), 4 / 3 * dagg);
            else
                minRequiredDistance = Math.Min(Math.Min(40, 1.5 * db), 4 / 3 * dagg);


            if (memType == "BEAM" && clearspace > minRequiredDistance)
            {
                isPass = true;
                MSG = "BEAM rebar Clear space is enough";
            }
            else
            {
                isPass = false;
                MSG = "BEAM rebar Clear space is not enough";
            }

            if (memType == "COLUMN" && clearspace > minRequiredDistance)
            {
                isPass = true;
                MSG = "COLUMN rebar Clear space is enough";
            }
            else
            {
                isPass = false;
                MSG = "COLUMN rebar Clear space is not enough";
            }


        }

        //ACI 318-14 25.2.2 鋼筋最小垂直淨間距(梁、柱)
        public static void Code25_2_2_SI(double clearspace, out bool isPass, out string MSG)
        {
            if (clearspace >= 25)
            {
                isPass = true;
                MSG = "25.2.2 PASS";
            }
            else
            {
                isPass = false;
                MSG = "25.2.2 FAIL";
            }

        }

        //ACI 318-14 表 9.7.6.2.2 剪力鋼筋之最大間距
        public static void Code9_7_6_2_2_SI(double Vs, double Fc, double bw, double d, double spacing, out double MaxSpacing, out bool isPass, out string MSG)
        {
            if (Vs <= 0.33 * Math.Pow(Fc, 0.5) * bw * d)
                MaxSpacing = Math.Max(d / 2, 600);
            else
                MaxSpacing = Math.Max(d / 4, 300);

            if (spacing < MaxSpacing)
            {
                isPass = true;
                MSG = "9.7.6.2.2 PASS";
            }
            else
            {
                isPass = false;
                MSG = "9.7.6.2.2 FAIL";
            }
        }

        //ACI 318-14 表 24.3.2 握裹鋼筋於非預力梁中之最大間距
        public static void Code24_3_2_SI(double Fy, double Cc, double spacing, out double MaxSpacing, out bool isPass, out string MSG)
        {
            double fs = 2 / 3 * Fy;
            double a = 380 * (280 / fs) - 2.5 * Cc;
            double b = 300 * (280 / fs);
            MaxSpacing = Math.Min(a, b);
            if (spacing < MaxSpacing)
            {
                isPass = true;
                MSG = "24.3.2 PASS";
            }
            else
            {
                isPass = false;
                MSG = "24.3.2 FAIL";
            }
        }

        //ACI 318-14 9.7.6.4.4 縱向鋼筋之淨距不得超過6 in
        public static void Code9_7_6_4_4_SI(double ClearSpacing, out bool isPass, out string MSG)
        {
            if (ClearSpacing <= 150)
            {
                isPass = true;
                MSG = "9.7.6.4.4 PASS";
            }
            else
            {
                isPass = false;
                MSG = "9.7.6.4.4 FAIL";
            }

        }

        //ACI 318-14 9.7.6.4.2 橫向鋼筋之SIZE
        public static void Code9_7_6_4_2_SI(double mainbarsize, double stirrupsize, out bool isPass, out string MSG)
        {
            if (mainbarsize <= 32 && stirrupsize >= 10)
            {
                isPass = true;
                MSG = "9.7.6.4.2 PASS";
            }
            else
            {
                isPass = false;
                MSG = "9.7.6.4.2 FAIL";
            }

            if (mainbarsize > 32 && stirrupsize >= 13)
            {
                isPass = true;
                MSG = "9.7.6.4.2 PASS";
            }
            else
            {
                isPass = false;
                MSG = "9.7.6.4.2 FAIL";
            }
        }

        //ACI 318-14 9.7.6.4.3 橫向鋼筋之間距
        public static void Code9_7_6_4_2_SI(double Spacing, double MinSpacing, double maindb, double transdb, double B, double H, out bool isPass, out string MSG)
        {
            double a = 16 * maindb;
            double b = 48 * transdb;
            double c = Math.Min(B, H);
            MinSpacing = Math.Min(Math.Min(a, b), c);

            if (Spacing <= MinSpacing)
            {
                isPass = true;
                MSG = "9.7.6.4.3 PASS";
            }
            else
            {
                isPass = false;
                MSG = "9.7.6.4.3 FAIL";
            }
        }

        //ACI 318-14 9.7.6.3.3 橫向扭力鋼筋之間距
        public static void Code9_7_6_3_3(double Spacing, double Ph, out bool isPass, out string MSG)
        {
            if (Spacing < Math.Min(Ph / 8, 300))
            {
                isPass = true;
                MSG = "9.7.6.3.3 PASS";
            }
            else
            {
                isPass = false;
                MSG = "9.7.6.3.3 FAIL";
            }

        }

        //ACI 318-14 9.6.3.3 橫向扭力鋼筋之間距
        public static void Code9_6_3_3_SI(double s, double Avmin, double Fc, double bw, double fyt, out double ReqAvmin, out bool isPass, out string MSG)
        {
            double a = 0.062 * Math.Pow(Fc, 0.5) * bw * s / fyt;
            double b = 0.35 * bw * s / fyt;

            ReqAvmin = Math.Max(a, b);

            if (Avmin >= ReqAvmin)
            {
                isPass = true;
                MSG = "9.6.3.3 PASS";
            }
            else
            {
                isPass = false;
                MSG = "9.6.3.3 FAIL";
            }
        }

        //ACI 318-14 9.6.4.2 需扭力鋼筋時，最少橫向鋼筋量
        public static void Code9_6_4_2_SI(double s, double Av, double At, double Fc, double bw, double fyt, out double ReqAvmin, out bool isPass, out string MSG)
        {
            double a = 0.062 * Math.Pow(Fc, 0.5) * bw * s / fyt;
            double b = 0.35 * bw * s / fyt;

            ReqAvmin = Math.Max(a, b);
            if (Av + 2 * At >= ReqAvmin)
            {
                isPass = true;
                MSG = "9.6.4.2 PASS";
            }
            else
            {
                isPass = false;
                MSG = "9.6.4.2 FAIL";
            }
        }

        //ACI 318-14 9.7.5.2 縱向扭力筋直徑最小值
        public static void Code9_7_5_2_SI(double db_torsion, double S, out bool isPass, out string MSG)
        {
            double a = 0.042 * S;
            double b = 10;   //  3/8in
            if (db_torsion >= Math.Max(a, b))
            {
                isPass = true;
                MSG = "9.7.5.2 PASS";
            }
            else
            {
                isPass = false;
                MSG = "9.7.5.2 FAIL";
            }

        }

        //ACI 318-14 9.9.1.1   檢查是否為深梁
        public static void Code9_9_1_1_SI(double Lc, double h, double ConcLoadDistance, out bool isDeepBeam, out string MSG)
        {
            double a = 4 * h;
            double b = ConcLoadDistance;
            if (Lc < a || b < 2 * h)
            {
                isDeepBeam = true;
                MSG = "Deep Beam";
            }
            else
            {
                isDeepBeam = false;
                MSG = "Normal Beam";
            }

        }

        //ACI 318-14 9.9.2.1   檢查深梁尺寸
        public static void Code9_9_2_1_SI(double Lc, double h, double ConcLoadDistance, out bool isDeepBeam, out string MSG)
        {
            double a = 4 * h;
            double b = ConcLoadDistance;
            if (Lc < a || b < 2 * h)
            {
                isDeepBeam = true;
                MSG = "Deep Beam";
            }
            else
            {
                isDeepBeam = false;
                MSG = "Normal Beam";
            }

        }
        //ACI 318-14 25.7.2.1 箍筋間距檢核
        public static void Code25_7_2_1_SI(double b, double h, double dagg, double dbtrans, double dbtie, double spacing, out bool isPass, out string MSG)
        {
            double a = 4 / 3 * dagg;
            double b1 = 16 * dbtrans;
            double b2 = 48 * dbtie;
            double b3 = Math.Min(b, h);

            double minspacing = Math.Min(b1, Math.Min(b2, b3));
            double clearspacing = spacing - dbtrans;

            if (clearspacing >= a && spacing <= minspacing)
            {
                isPass = true;
                MSG = "25.7.2.1 PASS";
            }
            else
            {
                isPass = false;
                MSG = "25.7.2.1 FAIL";
            }

        }

        //ACI 318-14 25.7.2.3 無橫向支撐鋼筋至有橫向支撐鋼筋淨間距不得大於15cm
        public static void Code25_7_2_3_SI(double clearspacing, out bool isPass, out string MSG)
        {

            if (clearspacing <= 150)
            {
                isPass = true;
                MSG = "25.7.2.3 PASS";
            }
            else
            {
                isPass = false;
                MSG = "25.7.2.3 FAIL";
            }

        }

        //ACI 318-10_6_1_1 最小及最大縱向鋼筋
        public static void Code10_6_1_1_SI(double b, double h, double Astotal, out bool isPass, out string MSG)
        {
            double min = 0.01 * b * h;
            double max = 0.08 * b * h;

            if (Astotal >= min && Astotal <= max)
            {
                isPass = true;
                MSG = "10.6.1.1 PASS";
            }
            else
            {
                isPass = false;
                MSG = "10.6.1.1 FAIL";
            }

        }

        //ACI 318-10_6_2_2 最少剪力鋼筋
        public static void Code10_6_2_2_SI(double Av, double fc, double bw, double s, double fyt, out bool isPass, out string MSG)
        {
            double a = 0.062 * Math.Pow(fc, 0.5) * bw * s / fyt;
            double b = 0.35 * bw * s / fyt;



            if (Av >= Math.Max(a, b))
            {
                isPass = true;
                MSG = "10.6.2.2 PASS";
            }
            else
            {
                isPass = false;
                MSG = "10.6.2.2 FAIL";
            }

        }

        //ACI 318-10_7_3_1 縱向鋼筋最少根數
        public static void Code10_7_3_1_SI(string type, double Rebarnumber, out bool isPass, out string MSG)
        {
            if (type == "Triangle")
            {
                if (Rebarnumber < 3)
                {
                    isPass = true;
                    MSG = "10.7.3.1 PASS";
                }
                else
                {
                    isPass = false;
                    MSG = "10.7.3.1 FAIL";
                }
            }
            else if (type == "Rectangle")
            {
                if (Rebarnumber < 4)
                {
                    isPass = true;
                    MSG = "10.7.3.1 PASS";
                }
                else
                {
                    isPass = false;
                    MSG = "10.7.3.1 FAIL";
                }
            }
            else if (type == "Circle")
            {
                if (Rebarnumber < 6)
                {
                    isPass = true;
                    MSG = "10.7.3.1 PASS";
                }
                else
                {
                    isPass = false;
                    MSG = "10.7.3.1 FAIL";
                }
            }
            else
            {
                isPass = false;
                MSG = "No Input Type";
            }
        }

        //ACI 318-10_7_6_5_2 剪力鋼筋之最大間距
        public static void Code10_7_6_5_2_SI(double Vs, double fc, double bw, double d, double h, double s, out bool isPass, out string MSG)
        {
            double Smax = 0.0;
            if (Vs <= 0.33 *Math.Pow(fc,0.5)*bw*d)
            {
                Smax = Math.Min(Math.Min(d / 2, 3 * h / 4), 600);
            }
            else
            {
                Smax = Math.Min(Math.Min(d / 4, 3 * h / 8), 300);
            }
            if (s <= Smax)
            {
                isPass = true;
                MSG = "10.7.6.5.2 PASS";
            }
            else
            {
                isPass = false ;
                MSG = "10.7.6.5.2 FAIL";
            }
        }

       

    }

}
