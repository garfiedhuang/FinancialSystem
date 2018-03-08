using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Garfield.Utility
{
   public class PdfFontHelper
    {
        #region Font Setting
        public static iTextSharp.text.Font SetFont()
        {
            return SetFont("宋体");
        }

        public static iTextSharp.text.Font SetFont(string strFontName)
        {
            return SetFont(strFontName, 16f);
        }

        public static iTextSharp.text.Font SetFont(string strFontName, float size)
        {
            return SetFont(strFontName, size, 0);
        }

        public static iTextSharp.text.Font SetFont(string strFontName, float size, int fontStyle)
        {
            return SetFont(strFontName, size, fontStyle, iTextSharp.text.Color.BLACK);
        }

        public static iTextSharp.text.Font SetFont(string strFontName, float size, int fontStyle, iTextSharp.text.Color color)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\..\Fonts\";
            string str2 = path;
            string str3 = strFontName;
            if (str3 != null)
            {
                if (!(str3 == "隶书"))
                {
                    if (str3 == "幼圆")
                    {
                        path = path + "SIMYOU.TTF";
                        goto Label_0093;
                    }
                    if (str3 == "黑体")
                    {
                        path = path + "SIMHEI.TTF";
                        goto Label_0093;
                    }
                    if (str3 == "楷体")
                    {
                        path = path + "SIMKAI.TTF";
                        goto Label_0093;
                    }
                    if (str3 == "微软雅黑")
                    {
                        path = path + "MSYH.TTF";
                        goto Label_0093;
                    }
                }
                else
                {
                    path = path + "SIMLI.TTF";
                    goto Label_0093;
                }
            }
            path = path + "SIMSUN.TTC,1";
            Label_0093:
            if (!File.Exists(path))
            {
                path = str2 + "SIMSUN.TTC,1";
            }
            return new iTextSharp.text.Font(BaseFont.CreateFont(path, "Identity-H", false), size, fontStyle, color);
        }
        #endregion
    }
}
