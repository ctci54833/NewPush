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
        public static void code9112(string AA,string BB ,out string CC,out string MSG)
        {
            string A = AA;
            string B = BB;
            string C = "AAA";
            CC = A + B + C;
            MSG = "this is test message!";
            //////
        }

        //ACI 318-14 9.6.1.2 最小鋼筋量
        public static void Code9_6_1_2_SI(double Fc, double Fy, double bw ,double d,double As,out double Rho,out double limitRho,out Boolean isPass , out string MSG)
        {
            double a = 0.25 *Math.Pow (Fc, 0.5) / Fy * bw * d;
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
                isPass = false ;
                MSG = "9.6.1.2 FAIL";   
            }
                       
        }

        //ACI 318-14 9.6.4.3 最小縱向扭力鋼筋量
        public static void Code9_6_4_3_SI(double Fc, double Fy, double bw,double Al,double Acp, double At,double s, double Ph,double Fyt, out double limitAl, out Boolean isPass, out string MSG)
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

        //ACI 318-14 9.7.3.3 d及12db之大者
        //public static void Code9_7_3_3_SI(double d, double db, out double distance)
        //{
        //    distance = Math.Max(d, 12 * db);
        //}




        //ACI 318-14 25.2.1 & 25.2.3 鋼筋最小水平淨間距(梁、柱)
        public static void Code25_2_1_SI(string memType ,double db, double dagg,double clearspace ,out double minRequiredDistance , out bool isPass,out string MSG)
        {
            if (memType =="BEAM")
                minRequiredDistance = Math.Min(Math.Min(25, db), 4 / 3 * dagg);
            else
                minRequiredDistance = Math.Min(Math.Min(40, 1.5*db), 4 / 3 * dagg);


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
        public static void Code25_2_2_SI(double clearspace  , out bool isPass,out string MSG)
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
            MaxSpacing = Math.Min(a,b);
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
        public static void Code9_7_6_4_2_SI(double Spacing, double MinSpacing, double maindb,double transdb,double B,double H,out bool isPass, out string MSG)
        {
            double a = 16 * maindb;
            double b = 48 * transdb;
            double c = Math.Min(B, H);
            MinSpacing = Math.Min(Math.Min (a,b),c);

            if (Spacing <= MinSpacing )
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
             if (Spacing < Math.Min(Ph/8,300))
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
        public static void Code9_6_3_3_SI(double s ,double Avmin, double Fc, double bw,double fyt,out double ReqAvmin,out bool isPass, out string MSG)
        {
            double a = 0.062 * Math.Pow(Fc, 0.5) * bw * s / fyt;
            double b = 0.35 * bw * s / fyt;
            
            ReqAvmin = Math.Max(a,b);

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
        public static void Code9_6_4_2_SI(double s ,double Av,double At, double Fc, double bw,double fyt,out double ReqAvmin,out bool isPass, out string MSG)
        {
            double a = 0.062 * Math.Pow(Fc, 0.5) * bw * s / fyt;
            double b = 0.35 * bw * s / fyt;

            ReqAvmin = Math.Max(a, b);
            if (Av+2*At >= ReqAvmin)
            {
                isPass = true;
                MSG = "9.6.4.2 PASS";
            }
            else
            {
                isPass = false;
                MSG = "9.6.4.2 FAIL";
            }

        //git test 2111








        }


            







    
        
    }

    





}
